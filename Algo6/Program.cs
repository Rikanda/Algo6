using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo6
{
    public class Program
    {
       public static List<RelationNodes> listRelations = new List<RelationNodes>(); // переменная для хранения всех связанных вершин графа
       public static RelationNodes testRelation = new RelationNodes(); // объект хранящий пару вершин, для проверки комбинации вершин
        static void Main(string[] args)
        {
            // заполнение графа

            Console.WriteLine("Заполнение графа");
            Graph MyGraph = new Graph();

            int v = 20; // задали количество вершин графа
            int c = 3; //задали максимальное количество связей для каждой вершины
            int w = 15; // задали максимальный вес связи

            for (int i = 1; i <= v; i++) // добавляем вершины
            {
                MyGraph.AddNode(i);
            }

            // добавляем связи

           
        

            for (int i = 1; i <= v; i++)
            {
                Console.WriteLine("Генерация для вершины " + i);
                int r = rRandom(c); // определяем количество связей 
                Console.WriteLine("Количество связей " + r);
                for (int j = 0; j< r; j++) // для каждой связи выполняем проверку и добавляем со случайным весом
                {
                    int s = 0;
                    while (s == 0)
                    {                   
                        
                        s = sRandom(v);// случайная вторая вершина
                        if(s==i)
                        {
                            Console.WriteLine("Вторая вершина "+s+ " Вторая вершина не прошла проверку");
                            s = 0;
                            
                            
                        }

                        else
                        {
                            Console.WriteLine("Вторая вершина " + s);
                            
                           
                             // список всех связанных между собой вершин графа
                            testRelation.Node1 = MyGraph.FindNode(i); // складываем в переменную новую связь для проверки
                            testRelation.Node2 = MyGraph.FindNode(s);


                            if (!InList(testRelation, listRelations)) // проверка, что такой комбинации вершин еще нет в графе
                            {
                                int wei = wRandom(w);


                                MyGraph.AddEdge(i, s, wei);

                                RelationNodes ndn = new RelationNodes();
                                ndn.Node1 = MyGraph.FindNode(i);
                                ndn.Node2 = MyGraph.FindNode(s);
                                listRelations.Add(ndn);
                                RelationNodes ndnInv = new RelationNodes();
                                ndnInv.Node1 = MyGraph.FindNode(s);
                                ndnInv.Node2 = MyGraph.FindNode(i);
                                listRelations.Add(ndnInv);

                                int count = listRelations.Count;
                                Console.WriteLine("В листе " + count + " записей");
                                for (int ti = 0; ti < count; ti++)
                                {
                                    int fir = listRelations[ti].Node1.Number;
                                    int sec = listRelations[ti].Node2.Number;
                                    Console.WriteLine(fir + " " + sec);
                                }

                               

                                
                                Console.WriteLine("Для вершины " + i + " создана связь с вершиной " + s + " и весом связи " + wei);

                            }
                            else
                            {
                                Console.WriteLine("Вторая вершина " + s + " Такая связь уже есть");
                                s = 0;

                                

                            }
                        }
                        

                       


                    }
                        
                }
            }

            // выполнение поиска
            int searchValue = 16; // искомое значение в графе

            // BFS поиск значения в ширину с помощью очереди

            Console.WriteLine("Поиск в ширину (волновой метод) с помощью очереди");

            Node searchNodeQ = SearchByQueue(MyGraph, searchValue);

            // DFS поиск значения в глубину с помощью стека
            Console.WriteLine("Поиск в глубину с помощью стака");
            Node searchNodeS = SearchByStack(MyGraph, searchValue);

        }

       

        public static bool InList(RelationNodes testr, List<RelationNodes> lrn) // проверка, что такой связи еще нет
        {
            
            if (lrn is null)
            {
                return false;
            }
            else
            {
                var xs1 = testr.Node1.Number;
                var xs2 = testr.Node2.Number;

                for(int ii=0; ii<lrn.Count; ii++)
                {
                    if (xs1==lrn[ii].Node1.Number&& xs2 == lrn[ii].Node2.Number)
                    {
                        
                            return true;
                        
                    }

                }

            }


            return false;
        }

        public static int wRandom(int w) // случайный вес связи
        {
            var we = new Random().Next(1, w+1);
            return we;

        }

        public static int rRandom(int c) // случайное количество связей
        {

            var r = new Random().Next(1, c+1);
            return r;

        }

        public static int sRandom(int v) // случайная вторая вершина
        {

            var s = new Random().Next(1, v+1);
            return s;

        }

      

        public static Node SearchByQueue(Graph mygraph, int svalue)
        {
            List<int> Wave = new List<int>(); // в лист добавляются номера вершин, через которые прошла волна, для исключения из повторного добавления в очередь

            Queue<Node> Q = new Queue<Node>(); // очередь для поиска 
            Node root = mygraph.Nodes[0];
            Q.Enqueue(root); // добавили начальную вершину в очередь
            Wave.Add(root.Number);
            foreach (Node node in mygraph.Nodes) // обходим весь список вершин
            {
                if (Q is null)
                {
                    Console.WriteLine("Список пуст, значение не найдено");
                    return null;
                }

                else
                {
                    var n = Q.Dequeue(); // берем элемент из очереди
                    Console.WriteLine("test= " + n.Number);
                    
                    if (n.Number == svalue) // проверяем совпадение значения
                    {
                        Console.WriteLine("Искомый элемент найден");
                        return n;
                    }
                    else // если не совпало, добавляем в очередь дочерние элементы
                    {
                        Console.WriteLine("удален из очереди " + n.Number);

                        var k = n.Edges.Count; // берем все дочерние элементы по ребрам из данной вершины
                        for(int i=0; i<k; i++)
                        {
                            var vc = n.Edges[i].Node;
                            if(!Wave.Contains(vc.Number)) // если элемент еще не добавлен в очередь
                            {
                                Q.Enqueue(vc);
                                Wave.Add(vc.Number);
                                Console.WriteLine("добавлены в очередь " + vc.Number);
                            }
                           
                        }

                    }
                }
            }
            return null; // если ничего не нашли

        

            
        }

        public static Node SearchByStack(Graph mygraph, int svalue)
        {
            List<int> Wave = new List<int>(); // в лист добавляются номера вершин, которые уже проверены
            Stack<Node> S = new Stack<Node>(); // стак для поиска 
            Node root = mygraph.Nodes[0];
            S.Push(root);
            foreach (Node node in mygraph.Nodes) // обходим весь список вершин
            {


                if (S is null)
                {
                    Console.WriteLine("Список пуст, значение не найдено");
                    return null;
                }
                else
                {
                    var n = S.Pop(); // берем элемент стака
                    Console.WriteLine("test= " + n.Number);
                    Wave.Add(n.Number); // добавляем проверенный элемент для исключения из списка
                    if (n.Number == svalue) // проверяем совпадение значения
                    {
                        Console.WriteLine("Искомый элемент найден");
                        return n;
                    }
                    else // если не совпало, добавляем в стак дочерние элементы 
                    {
                        Console.WriteLine("удален из стака " + n.Number);

                        var k = n.Edges.Count; // берем все дочерние элементы по ребрам из данной вершины
                        for (int i = 0; i < k; i++)
                        {
                            var vc = n.Edges[i].Node;
                            if (!Wave.Contains(vc.Number)) // если элемент еще не проверен
                            {

                                S.Push(vc);
                               
                                Console.WriteLine("добавлены в стак " + vc.Number);
                            }

                        }
                      
                        
                    }
                }

            }



            return null; // если ничего не нашли
        }

    }

}




