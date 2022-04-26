using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;

namespace CbOAlgorithms
{
    public class Grid
    {
        public Grid()
        {
            Verties = new List<Concept>();
            Edges = new List<Edge>();
            Neighbours = new Dictionary<Concept, List<Concept>>();
        }


        public Grid(List<Concept> listOfVertices, Context context)
        {
            Verties = listOfVertices;
            Edges = new List<Edge>();
            Neighbours = new Dictionary<Concept, List<Concept>>();
            var fullObjConcept = new Concept(context.G, new List<string>());
            Verties.Add(fullObjConcept);
            var fullAttrConcept = new Concept(new List<string>(), context.M);
            Verties.Add(fullAttrConcept);

            foreach (var vertice in Verties)
            {
                Neighbours.Add(vertice, new List<Concept>());
            }


            foreach (var vertice in Verties)
            {
                foreach (var concept in from concept in
                             Verties.Where(it => it.C.Count() > vertice.C.Count() && it != vertice).ToList()
                         let flag = vertice.C.Any(obj => !concept.C.Contains(obj))
                         where flag == false && !ContainEdge(vertice, concept)
                         select concept)
                {
                    AddEdge(vertice, concept);
                }
            }

            foreach (var vertice in Verties)
            {
                var highVert = Neighbours[vertice].Where(it => it.C.Count > vertice.C.Count).ToList();
                var lowVert = Neighbours[vertice].Where(it => it.C.Count < vertice.C.Count).ToList();
                foreach (var hv in highVert)
                {
                    foreach (var lv in lowVert.Where(lv => ContainEdge(hv, lv)))
                    {
                        RemoveEdge(hv, lv);
                    }
                }
            }
        }

        public List<Concept> Verties { get; private set; }
        public List<Edge> Edges { get; private set; }

        public Dictionary<Concept, List<Concept>> Neighbours { get; private set; }


        public bool ContainEdge(Concept firstVertex, Concept secondVertex)
        {
            return Edges.Any(e =>
                e.firstVertex == firstVertex && e.secondVertex == secondVertex ||
                e.firstVertex == secondVertex && e.secondVertex == firstVertex);
        }

        public void AddEdge(Concept firstVertex, Concept secondVertex)
        {
            if (!Verties.Contains(firstVertex))
                throw new NonExistentVertexException("Vertex" + firstVertex + " doesn`t exist in grid");
            if (!Verties.Contains(secondVertex))
                throw new NonExistentVertexException("Vertex " + secondVertex + " doesn`t exist in grid");
            Edges.Add(new Edge(firstVertex, secondVertex));
            Neighbours[firstVertex].Add(secondVertex);
            Neighbours[secondVertex].Add(firstVertex);
        }

        public Edge GetEdge(Concept firstVertex, Concept secondVertex)
        {
            var result = Edges.Where(it =>
                it.firstVertex == firstVertex && it.secondVertex == secondVertex ||
                it.firstVertex == secondVertex && it.secondVertex == firstVertex).ToList();
            return result.Count > 0 ? result[0] : null;
        }

        public void RemoveEdge(Concept firstVertex, Concept secondVertex)
        {
            var removingEdge = GetEdge(firstVertex, secondVertex);
            Edges.Remove(removingEdge);
            Neighbours[firstVertex].Remove(secondVertex);
            Neighbours[secondVertex].Remove(firstVertex);
        }

        public Grid Copy()
        {
            var copy = new Grid();
            var copyVert = new List<Concept>();
            copyVert.AddRange(Verties);
            copy.Verties = copyVert;
            var copyEdges = new List<Edge>();
            copyEdges.AddRange(copyEdges);
            copy.Edges = copyEdges;
            var copyNeighbours = Neighbours.ToDictionary(n => n.Key, n => n.Value);
            copy.Neighbours = copyNeighbours;

            return copy;
        }

        public void RemoveVertex(Concept removingVertex)
        {
            Verties.Remove(removingVertex);
            while (Neighbours[removingVertex].Count > 0)
            {
                RemoveEdge(removingVertex, Neighbours[removingVertex][0]);
            }
        }

        public void SaveInFile(string filepath, bool objectRank)
        {
            File.Delete(filepath + ".dot");
            var g = new AdjacencyGraph<string, TaggedEdge<string, string>>();
            var vertOnLevels = new List<string>();
            if (objectRank)
            {
                var maxObjCount = Verties.Select(it => it.C.Count).Max();
                var counter = 0;
                for (var i = maxObjCount; i >= 0; i--)
                {
                    var vertices = Verties.Where(it => it.C.Count == i).Select(it => it.ToString()).ToList();
                    if (vertices.Count <= 0) continue;
                    var levelStr = "{ rank = same; ";
                    for (var k = counter; k < counter + vertices.Count; k++) levelStr += "\"" + k + "\"; ";
                    levelStr += "}";
                    counter += vertices.Count;
                    vertOnLevels.Add(levelStr);
                    g.AddVertexRange(vertices);
                }
            }

            foreach (var e in Edges)
                g.AddEdge(new TaggedEdge<string, string>(e.firstVertex.ToString(), e.secondVertex.ToString(), ""));

            var path = filepath + ".dot";

            var graph = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(g);

            graph.FormatVertex += (sender, args) => args.VertexFormatter.Comment = args.Vertex;
            graph.CommonEdgeFormat.Dir = GraphvizEdgeDirection.None;
            graph.ImageType = GraphvizImageType.Png;
            graph.Generate(new FileDotEngine(), path);

            var readText = File.ReadAllLines(path);
            var writeText = new string[readText.Length - 1];
            Array.Copy(readText, 0, writeText, 0, readText.Length - 1);
            var fileText = writeText.ToList();
            fileText.AddRange(vertOnLevels);
            fileText.Add("}");
            File.WriteAllLines(path, fileText);
        }

        public void SavePng(string filepath, bool objectRank)
        {
            File.Delete(filepath + ".png");

            SaveInFile(filepath, objectRank);
            var fileName = filepath.Substring(filepath.LastIndexOf("/", StringComparison.Ordinal) + 1);
            var command = "/c dot -Tpng " + fileName + ".dot > " + fileName + ".png";
            var psi = new ProcessStartInfo
            {
                FileName = "cmd",
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = filepath.Substring(0, filepath.LastIndexOf("/", StringComparison.Ordinal)),
                Arguments = command
            };
            var proc = Process.Start(psi);
            if (proc == null) return;
            proc.WaitForExit();
            proc.Close();
        }

        public class NonExistentVertexException : Exception
        {
            public NonExistentVertexException(string message)
                : base(message)
            {
            }
        }

        public class FileDotEngine : IDotEngine
        {
            public string Run(GraphvizImageType imageType, string dot, string outputFileName)
            {
                using (var writer = new StreamWriter(outputFileName))
                {
                    writer.Write(dot);
                }

                return Path.GetFileName(outputFileName);
            }
        }
    }
}