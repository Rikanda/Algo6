using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo6
{
   public class Edge
    {
        public int Weight { get; set; } //вес связи
        public Node Node { get; set; } // узел, на который связь ссылается

        // конструктор

        public Edge (Node node, int weight)
        {
            Node = node;
            Weight = weight;
        }
    }
}
