using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace C12_StargateProblem
{
    class Program
    {
        static void Main(string[] args)
        {
             var stream = Console.In;
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                File.AppendAllLines("debug.txt", new[] {line});
                var strings = line.Split(' ');
                var planets = Int32.Parse(strings[0]);
                var earthIndex = Int32.Parse(strings[1]);
                var atlantisIndex = Int32.Parse(strings[2]);
                var distances = new Int32[planets,planets];
                _initializeDistances(distances);

                for (int i = 3; i < strings.Length; i++)
                {
                    var aux = strings[i].Split(',');
                    if (aux.Length != 3) continue;
                    distances[Int32.Parse(aux[0]), Int32.Parse(aux[1])] = Int32.Parse(aux[2]);
                }

                List<BellmanFord.Vertex> vertices = new List<BellmanFord.Vertex>();
                for (int i = 0; i < planets; i++)
                {
                    vertices.Add(new BellmanFord.Vertex() { id = i});
                }

                List<BellmanFord.Edge> edges = new List<BellmanFord.Edge>();
                for (int i = 0; i < distances.GetLength(0); i++)
                {
                    for (int z = 0; z < distances.GetLength(1); z++)
                    {
                        edges.Add(new BellmanFord.Edge()
                                      {
                                          Source = vertices[i],
                                          Destination = vertices[z],
                                          Weight = Int32.MaxValue == distances[i,z] ? Double.PositiveInfinity : distances[i,z]                   
                                      });
                    }
                }

                try
                {
                    BellmanFord.Run(vertices, edges,  vertices[earthIndex]);
                    Console.WriteLine(25000 + vertices[atlantisIndex].Distance);

                }
                catch (Exception e)
                {
                    Console.WriteLine("BAZINGA");
                }
                if (stream.Peek() == -1) break;
            }
        }

        private static void _initializeDistances(int[,] distances)
        {
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                for (int z = 0; z < distances.GetLength(1); z++)
                {
                    distances[i, z] = Int32.MaxValue;
                }
            }
        }
    }
}
