using System.Collections.Generic;
using System.Linq;

namespace CbOAlgorithms
{
    public static class Algorithms
    {
        /// <summary>
        /// Реализация алгоритма Close by one (добавление объектов)
        /// </summary>
        /// <param name="context"></param>
        public static List<Concept> CloseByOne(Context context)
        {
            var closeByOne = new List<Concept>();
            var objects = new List<string>();
            foreach (var g in context.G)
            {
                objects.Clear();
                objects.Add(g);
                Generate(context, ref closeByOne, objects, g,
                    new Concept(context.GaluaOperatorFromObjectToSign(context.GaluaOperatorUp(objects)),
                        context.GaluaOperatorUp(objects)));
            }

            return closeByOne;
        }

        /// <summary>
        /// Реализация алгоритма Close by one (добавление признаков)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<Concept> CloseByOneV1(Context context)
        {
            var closeByOneV1 = new List<Concept>();
            GenerateFrom(context, closeByOneV1, context.G, context.M, 0);
            return closeByOneV1;
        }

        /// <summary>
        /// Реализация алгоритма LCM (without pruning)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<Concept> LCMWithoutPruning(Context context)
        {
            var lcmWithoutPruning = new List<Concept>();
            GenerateFromLCMWithoutPruning(context, lcmWithoutPruning, context.G, context.GaluaOperatorUp(context.G), 0);
            return lcmWithoutPruning;
        }

        private static void GenerateFromLCMWithoutPruning(Context context, List<Concept> lcmWithoutPruning, List<string> A, List<string> B, int y)
        {
            var nSum = new List<string>();
            foreach (var x in A)
            {
                var xForGalua = new List<string>() { x };
                nSum.AddRange(context.GaluaOperatorUp(xForGalua).ToArray());
            }
            var N = nSum.Distinct().Except(B).ToList();
            var K = context;
            var frequencies = Frequencies(K, N);
            foreach (var i in N)
            {
                if (context.M.IndexOf(i) < y)
                {
                    if (frequencies[i] == A.Count)
                    {
                        return;
                    }
                }
            }

            var toRemoveFromN = new List<string>();
            foreach (var i in N)
            {
                if (context.M.IndexOf(i)+1 > y)
                {
                    if (frequencies[i] == A.Count)
                    {
                        B.Add(i);
                        B.Distinct();
                        toRemoveFromN.Add(i);
                        //N.Remove(i);
                    }
                }
            }
            N.Except(toRemoveFromN);

            lcmWithoutPruning.Add(new Concept(A, B));

            foreach (var i in N.OrderByDescending(s => s))
            {
                var newK = CreateConditionalDb(K, A, N, y, B);
                var listI = new List<string>();
                if (context.M.IndexOf(i)+1 > y)
                {
                    listI.Add(i);
                    B.Add(i);
                    GenerateFromLCMWithoutPruning(newK, lcmWithoutPruning, newK.GaluaOperatorFromObjectToSign(listI), B, context.M.IndexOf(i) + 1);
                    B.Clear();
                }
            }
            return;
        }
            private static Context CreateConditionalDb(Context K, List<string> A, List<string> N, int y, List<string> B)
        {
            var attrForstepC = "";
            if (y == 0)
            {
                attrForstepC = K.M[y];
            }
            else
            {
                attrForstepC = K.M[y-1];
            }
            // a
            var beforeDeletedG = K.G;
            if (B.Any())
            {
                K.G = K.GaluaOperatorFromObjectToSign(B);
                foreach (var i in beforeDeletedG.Except(K.G).OrderByDescending(e => e))
                {
                    K.Table.RemoveAt(int.Parse(i) - 1);
                }
            }

            //b
            // remove full
            var beforeDeletedM = K.M;
            K.M = K.M.Except(K.GaluaOperatorUp(K.G)).ToList();
            foreach(var i in beforeDeletedM.Except(K.M).OrderByDescending(e => e))
            {
                K.Table.ForEach(x => x.RemoveAt(beforeDeletedM.IndexOf(i)));
            }

            //remove empty
            foreach (var m in K.M.OrderByDescending(e => e))
            {
                var mForGalua = new List<string>() { m };
                if (K.GaluaOperatorFromObjectToSign(mForGalua).Count == 0)
                {
                    K.Table.ForEach(x => x.RemoveAt(K.M.IndexOf(m)));
                    K.M.Remove(m);
                }
            }

            // c. Remove attributes lesser than y
            var removeC = new List<string>();
            var delKTable = new List<List<bool>>();
            for (var i = 0; i < K.G.Count ; i++)
            {
                delKTable.Add(K.Table[i].Take(y-1).ToList());
            }

            foreach (var c in K.M.OrderByDescending(e => e))
            {
                if (c.CompareTo(attrForstepC) < 0)
                {
                    K.Table.ForEach(x => x.RemoveAt(K.M.IndexOf(c)));
                    K.M.Remove(c);
                    removeC.Add(c);
                }
            }

            var removeDic = new Dictionary<string, List<bool>>();
            for ( var i = 0; i < K.G.Count(); i++)
            {
                removeDic.Add(K.G[i], delKTable[i]);
            }
                
            // d. Merge identical objects together.
            var dic = new Dictionary<string, List<bool>>();
            for (int i = 0; i < K.G.Count(); i++)
            {
                for (int j = 0; j < K.G.Count(); j++)
                {
                    if (K.Table[i].SequenceEqual(K.Table[j]) &&
                        !dic.Keys.Any(x => x.Contains(K.G[j].ToString())) &&
                        !dic.Keys.Any(x => x.Contains(K.G[i].ToString())))
                    {
                        if (dic.Values.Any(x => x.SequenceEqual(K.Table[j])))
                        {
                            var copyDic = (from x in dic
                                              select x).ToDictionary(x => x.Key, x => x.Value);
                            foreach (var k in copyDic)
                            {
                                if (k.Value.SequenceEqual(K.Table[j]))
                                {
                                    dic.Add(k.Key + K.G[j], K.Table[j]);
                                    dic.Remove(k.Key);
                                }
                            }
                        }
                        else
                        {
                            dic.Add(K.G[i] + K.G[j], K.Table[j].ToList());
                        }
                    }
                }
            }
            var copyDicForDistinct = (from x in dic
                           select x).ToDictionary(x => x.Key, x => x.Value);
            foreach (var s in copyDicForDistinct)
            {
                var str = new string(s.Key.Distinct().ToArray());
                if (!str.Equals(s.Key))
                {
                    dic.Add(str, s.Value);
                    dic.Remove(s.Key);
                }
            }

            // e. Add interior intersections
            var eDic = new Dictionary<string, List<bool>>();
            
            foreach (var i in dic)
            {
                foreach(var j in removeDic.Where(x => i.Key.Contains(x.Key)))
                {
                    foreach (var l in removeDic.Where(x => i.Key.Contains(x.Key)))
                    {
                        if ((l.Key != j.Key && j.Key.CompareTo(l.Key) < 0) || (i.Key.Count() == 1))
                        {
                            var listBool = new List<bool>();
                            if (i.Key.Count() == 1)
                            {
                                var copyRemoveDic = (from x in removeDic
                                                     select x).ToDictionary(x => x.Key, x => x.Value);
                                eDic.Add(i.Key, copyRemoveDic[l.Key]);
                            }
                            else
                            {
                                for (var a = 0; a < removeC.Count; a++)
                                {
                                    if (j.Value[a] == l.Value[a])
                                    {
                                        listBool.Add(true);
                                    }
                                    else
                                    {
                                        listBool.Add(false);
                                    }
                                }
                                if (!eDic.ContainsKey(i.Key))
                                {
                                    eDic.Add(i.Key, listBool);
                                }
                                else
                                {
                                    eDic.Remove(i.Key);
                                    eDic.Add(i.Key, listBool);
                                }
                            }
                        }
                    }
                        
                }
            }

            K.G.Clear();
            K.Table.Clear();

            foreach (var a in dic.OrderBy(x => x.Key.Substring(0)))
            {
                if (eDic.ContainsKey(a.Key))
                {
                    K.G.Add(a.Key);
                    K.Table.Add(eDic[a.Key].Concat(dic[a.Key]).ToList());
                }
            }
            var km = K.M;
            K.M = removeC.OrderBy(x => x.Substring(0)).ToList();
            foreach (var m in km)
            {
                K.M.Add(m);
            }
            return K;
        }
        private static Dictionary<string, int> Frequencies(Context K, List<string> N)
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            foreach (var i in N)
            {
                var iForGalua = new List<string>() { i };
                frequencies.Add(i, K.GaluaOperatorFromObjectToSign(iForGalua).Count);
            }
            return frequencies;
        }
        private static void GenerateFrom(Context context, List<Concept>closeByOneV1, List<string> A, List<string> B, int y)
        {
            //(1) D <- A'
            var D = context.GaluaOperatorUp(A);

            //(2-3) if (Dy != By) then return
            if (D.Count < y+1 && B.Count < y+1)
            {
                if (D[y] != B[y])
                {
                    return;
                }
            }

            //(4) print(<A,D>)
            closeByOneV1.Add(new Concept(A, D));

            for (var i = y+1 ; i < context.M.Count; i++)
            {
                var iList = context.M.Except(D).ToList();

                foreach (var a in iList)
                {
                    var iForGalua = new List<string>();
                    iForGalua.Add(a);
                    var C = A.Intersect(context.GaluaOperatorFromObjectToSign(iForGalua)).ToList();
                    D.Add(a);
                    GenerateFrom(context, closeByOneV1, C, D, context.M.IndexOf(a));
                }
            }
            return;
        }

        private static void Generate(Context context, ref List<Concept> closeByOne, List<string> A, string g,
            Concept concept)
        {
            var cA = new List<string>();
            cA.AddRange(concept.C);
            foreach (var a in A) cA.Remove(a);
            var any = cA.Any(h => context.G.IndexOf(g) < context.G.IndexOf(h));
            if (any == false)
            {
                var f = closeByOne.All(c => !c.C.SequenceEqual(concept.C) || !c.D.SequenceEqual(concept.D));
                if (f && concept.C.Count > 0 && concept.D.Count > 0) closeByOne.Add(concept);
            }

            var gA = new List<string>();
            gA.AddRange(context.G);
            foreach (var a in A) gA.Remove(a);
            for (var i = 0; i < gA.Count; i++)
            {
                if (context.G.IndexOf(gA[i]) >= context.G.IndexOf(g)) continue;
                gA.Remove(gA[i]);
                i--;
            }

            foreach (var f in gA)
            {
                var z = new List<string>();
                z.AddRange(concept.C);
                z.Add(f);
                var F = new List<string> {f};
                var y = concept.D.Intersect(context.GaluaOperatorUp(F)).ToList();
                var x = context.GaluaOperatorFromObjectToSign(y);

                Generate(context, ref closeByOne, z, f, new Concept(x, y));
            }
        }
    }
}