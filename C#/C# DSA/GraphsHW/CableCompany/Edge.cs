using System;

namespace CableCompany
{
    public class Edge : IComparable
    {
        public char StartNode { get; set; }
        public char EndNode { get; set; }
        public int Weight { get; set; }

        public Edge(char startNode, char endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("The obj is null");
            }

            Edge objAsEdge = obj as Edge;
            if (obj == null)
            {
                throw new InvalidCastException("The obj can't be cast to an Edge");
            }

            if (this.StartNode != objAsEdge.StartNode)
            {
                return false;
            }

            if (this.EndNode != objAsEdge.EndNode)
            {
                return false;
            }

            if (this.Weight != objAsEdge.Weight)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return
                this.StartNode.GetHashCode() ^
                this.EndNode.GetHashCode() &
                this.Weight.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return this.Weight.CompareTo((obj as Edge).Weight);
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", this.StartNode, this.EndNode, this.Weight);
        }
    }
}
