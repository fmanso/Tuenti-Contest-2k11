using System;
using System.Collections.Generic;

namespace C16_TheBusStations
{
    class Program
    {
        private static List<String> _vertices = new List<string>();
        private static int _index = -1;
        // Algorithm EdmondsKarp knows nothing about strings so we are going to translate
        // vertex name to int
        private static int GetIndex(String vertex)
        {
            if (_vertices.Contains(vertex)) return _vertices.IndexOf(vertex);
            _vertices.Insert(++_index, vertex);
            return _index;
        }

        static void Main()
        {
            var stream = Console.In;
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                _index = -1;
                _vertices = new List<string>();
                var split = line.Split(' ');
                var size = Int32.Parse(split[0]);
                var capacity = new double[size, size];
                var source = split[1];
                var dest = split[2];
                int sourceIndex = GetIndex(source);
                int destIndex = GetIndex(dest);
                for (var i = 3; i < split.Length; i++)
                {
                    var split2 = split[i].Split(',');
                    var s = split2[0];
                    var d = split2[1];
                    var c = Int32.Parse(split2[2]);
                    capacity[GetIndex(s), GetIndex(d)] = c;

                }

                EdmondsKarpFlowGraph g = new EdmondsKarpFlowGraph(size, capacity, sourceIndex, destIndex);
                g.MaxFlow();
                Console.WriteLine(g.GetMaxFlow());
                // CHECK EOF));
                if (stream.Peek() == -1) break;
            }
        }
    }
}
