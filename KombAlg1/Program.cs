using System;
using System.Collections.Generic;
using System.Linq;

namespace KombAlg1
{
    public class Node
    {
        public int Number;
        public List<Edge> Edges = new List<Edge>();

        public Edge AddNode(Node other, int cost)
        {
            var edge = new Edge(cost, this, other);
            other.Edges.Add(edge);
            this.Edges.Add(edge);
            return edge;
        }

        public Node(int n)
        {
            Number = n;
        }
    }

    public class Edge
    {
        public Node Start;
        public Node End;

        public int Cost;

        public Edge() { }

        public Edge(int cost, Node start, Node end)
        {
            Cost = cost;
            Start = start;
            End = end;
        }
    }

    public class Point
    {
        public int X;
        public int Y;

        public int GetDistance(Point other)
        {
            return Math.Abs(this.X - other.X) + Math.Abs(this.Y - other.Y);
        }

        public Point()
        {

        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var points = new Point[n];
            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                var point = new Point(input[0], input[1]);
                points[i] = point;
            }

            var k = 0;
            var pointToNodeDict = points.ToDictionary(x => x, y => new Node(k++));
            var edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                var currentNode = pointToNodeDict[points[i]];
                for (int j = i + 1; j < n; j++)
                {
                    var otherNode = pointToNodeDict[points[j]];
                    edges.Add(currentNode.AddNode(otherNode, points[i].GetDistance(points[j])));
                }
            }

            var sortedEdges = edges.OrderBy(x => x.Cost).ToArray();
            var usedEdges = new List<Edge>();
            //система непересекающихся множеств

            for (int i = 0; i < sortedEdges.Length; i++)
            {
                var thisEdge = sortedEdges[i];
                if ()
                {
                    continue;
                }

                usedEdges.Add(thisEdge);
            }

            var list = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                list.Add(new List<int>());
            }

            foreach (var edge in usedEdges)
            {
                var n1 = edge.Start.Number;
                var n2 = edge.End.Number;
                list[n1].Add(n2);
                list[n2].Add(n1);
            }

            Console.WriteLine();
            foreach (var l in list)
            {
                Console.WriteLine(string.Join(" ", l.Select(x => x + 1).OrderBy(x => x)) + " 0");
            }
        }
    }
}
