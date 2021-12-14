using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Graph<ID, NodeValue> where ID : notnull
    {
        private Dictionary<ID, Node<NodeValue>> nodes;
        private Dictionary<ID, List<ID>> edges;

        public Graph()
        {
            nodes = new Dictionary<ID, Node<NodeValue>>();
            edges = new Dictionary<ID, List<ID>>();
        }

        public void AddEdge(ID nodeId1, ID nodeId2)
        {
            AddEdge(nodeId1, default, nodeId2, default);
        }

        public void AddEdge(ID nodeId1, NodeValue nodeValue1, ID nodeId2, NodeValue nodeValue2)
        {
            if (edges.ContainsKey(nodeId1))
            {
                edges[nodeId1].Add(nodeId2);
            }
            else
            {
                edges[nodeId1] = new List<ID> { nodeId2 };
            }

            if (!nodes.ContainsKey(nodeId1))
            {
                nodes[nodeId1] = new Node<NodeValue>(nodeValue1);
            }
            if (!nodes.ContainsKey(nodeId2))
            {
                nodes[nodeId2] = new Node<NodeValue>(nodeValue2);
            }
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public IEnumerable<Node<T>> GetNeighbours()
        {
            return Enumerable.Empty<Node<T>>();
        }
    }
}
