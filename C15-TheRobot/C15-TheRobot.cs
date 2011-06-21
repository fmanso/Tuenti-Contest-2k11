using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace C15_TheRobot
{
    class Program
    {
        static void Main()
        {
            var stream = Console.In;
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                var strings = line.Split(' ');

                var w = Int32.Parse(strings[0]);
                var l = Int32.Parse(strings[1]);
                var n = Int32.Parse(strings[2]);
                int[,] canvas = new int[w,l];
                for (int i = 0; i < w; i++)
                    for (int z = 0; z < l; z++)
                        canvas[i, z] = 1;


                for (int i = 0; i < n; i++)
                {
                    Point lowerLeft = new Point(Int32.Parse(strings[3 + (i * 5)]), Int32.Parse(strings[4 + (i * 5)]));
                    Point upperRight = new Point(Int32.Parse(strings[5 + (i * 5)]), Int32.Parse(strings[6 + (i * 5)]));
                    var color = Int32.Parse(strings[7 + (i*5)]);
                    Paint(canvas, w, l, lowerLeft, upperRight, color);
                    _debugCanvas(canvas, w, l);
                }

                SortedDictionary<int, int> counter = new SortedDictionary<int, int>();
                for (int i = 0; i < w; i++)
                {
                    for (int z = 0; z < l; z++)
                    {
                        if (!counter.ContainsKey(canvas[i, z])) counter.Add(canvas[i, z], 0);
                        counter[canvas[i, z]]++;
                    }
                }

                bool first = true;
                foreach (var keyPair in counter)
                {
                    if (!first)
                        Console.Write(" ");
                    first = false;
                    Console.Write(String.Format("{0} {1}", keyPair.Key, keyPair.Value));
                }
                Console.WriteLine();
                // CHECK EOF));
                if (stream.Peek() == -1) break;
            }
        }

        private static void _debugCanvas(int[,] canvas, int w, int l)
        {
            for (int i = 0; i < w; i++)
            {
                for (int z = 0; z < l; z++)
                {
                   Debug.Write(canvas[i,z] + "|");
                }
                Debug.WriteLine("");
            }
        }

        private static void Paint(int[,] canvas, int w, int l, Point lowerLeft, Point upperRight, int color)
        {
            for (int i = 0; i < w; i++)
            {
                for (int z = 0; z < l; z++)
                {
                    if (i >= lowerLeft.X && i < upperRight.X && z >= lowerLeft.Y && z < upperRight.Y )
                    {
                        canvas[i, z] = color;                        
                    }
                }
            }
        }
    }
}
