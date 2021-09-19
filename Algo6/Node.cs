using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo6
{
   public class Node
    {
        public int Number { get; set; } // номер вершины
        public List<Edge> Edges { get; set; } //исходящие связи

        // конструктор

        public Node(int number)
        {
            Number = number;
            Edges = new List<Edge>();
        
        }

        // добавить ребро

        public void AddEdge(Edge newEdge)
        {
            Edges.Add(newEdge);
        }

        public void AddEdge(Node node, int weight)
        {
            AddEdge(new Edge(node, weight));
        }

    }
}
