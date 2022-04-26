namespace CbOAlgorithms
{
    public class Edge
    {
        public readonly Concept firstVertex;

        public readonly Concept secondVertex;

        public Edge(Concept first, Concept second)
        {
            firstVertex = first;
            secondVertex = second;
        }

        public override int GetHashCode()
        {
            return firstVertex.GetHashCode() + secondVertex.GetHashCode();
        }
    }
}