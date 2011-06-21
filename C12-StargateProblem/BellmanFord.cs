using System;
using System.Collections.Generic;

namespace C12_StargateProblem
{
    public class BellmanFord
    {
        public class Vertex
        {
            public int id = -1;
            public double Distance = 0;
            public Vertex Predecessor = null;
            public override string ToString()
            {
                return id.ToString();
            }
        }

        public class Edge
        {
            public Vertex Source;
            public Vertex Destination;
            public double Weight = Double.PositiveInfinity;
            public override string ToString()
            {
                return Source + " => " + Destination + " (" + Weight + ")";
            }
        }

        public static void Run(List<Vertex> vertices, List<Edge> edges, Vertex source)
        {
            foreach (var vertex in vertices)
            {
                if (vertex == source)
                    vertex.Distance = 0;
                else
                    vertex.Distance = Double.PositiveInfinity;

                vertex.Predecessor = null;
            }

            for (int i = 0; i < vertices.Count; i++)
            {
                foreach (var edge in edges)
                {
                    if (edge.Source.Distance + edge.Weight < edge.Destination.Distance)
                    {
                        edge.Destination.Distance = edge.Source.Distance + edge.Weight;
                        edge.Destination.Predecessor = edge.Source;
                    }
                }
            }

            foreach (var edge in edges)
            {
                if (edge.Source.Distance + edge.Weight < edge.Destination.Distance)
                    throw new Exception("No path");
            }
        }
    }
}