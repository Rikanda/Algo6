using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo6
{
   public class Graph
    {
        // список вершин графа
        public List<Node> Nodes { get; set; }

        

        // конструктор
        public Graph()
        {
            Nodes = new List<Node>();
        }


        // добавление вершины
        public void AddNode (int number)
        {
            Nodes.Add(new Node(number));
        }

        // поиск вершины
        public Node FindNode(int number)
        {
            foreach(var n in Nodes)
            {
                if(n.Number.Equals(number))
                {
                    return n;
                }
            }

            return null;
        }

        // добавление ребра

        public void AddEdge (int firstNumber, int secondNumber, int weight)
        {
            var n1 = FindNode(firstNumber);
            var n2 = FindNode(secondNumber);
            if(n2!=null && n1!= null)
                    {
               n1.AddEdge(n2, weight);
               n2.AddEdge(n1, weight); // добавляем ребра
                

            }

        }

    }
}
