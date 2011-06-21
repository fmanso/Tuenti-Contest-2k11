using System;

namespace C16_TheBusStations
{
    public class EdmondsKarpFlowGraph
    {
        public static readonly int WHITE = 0, GRAY = 1, BLACK = 2;
        private double[,] flow, capacity, res_capacity;
        private int[] parent, color, queue;
        private double[] min_capacity;
        private int size, source, sink, first, last;
        private double max_flow;
 
        public EdmondsKarpFlowGraph(int size, double[,] capacity, int source, int sink)
        {
            this.size = size;
            this.capacity = capacity;
            this.source = source;
            this.sink = sink;
        }

        public double GetMaxFlow()
        {
            return max_flow;
        }

        public void MaxFlow()  // Edmonds-Karp algorithm with O(V³E) complexity
        {
                flow = new double[size,size];
                res_capacity = new double[size,size];
                parent = new int[size];
                min_capacity = new double[size];
                color = new int[size];
                queue = new int[size];
 
                for (int i = 0; i < size; i++)
                        for (int j = 0; j < size; j++)
                                res_capacity[i,j] = capacity[i,j];
 
                while (BFS(source))
                {
                        max_flow += min_capacity[sink];
                        int v = sink, u;
                        while (v != source)
                        {
                                u = parent[v];
                                flow[u,v] += min_capacity[sink];
                                flow[v,u] -= min_capacity[sink];
                                res_capacity[u,v] -= min_capacity[sink];
                                res_capacity[v,u] += min_capacity[sink];
                                v = u;
                        }
                }
        }
 
        private bool BFS(int source)  // Breadth First Search in O(V<sup>2</sup>)
        {
                for (int i = 0; i < size; i++)
                {
                        color[i] = WHITE;
                        min_capacity[i] = Double.MaxValue;
                }
 
                first = last = 0;
                queue[last++] = source;
                color[source] = GRAY;
 
                while (first != last)  // While "queue" not empty..
                {
                        int v = queue[first++];
                        for (int u = 0; u < size; u++)
                                if (color[u] == WHITE && res_capacity[v,u] > 0)
                                {
                                        min_capacity[u] = Math.Min(min_capacity[v], res_capacity[v,u]);
                                        parent[u] = v;
                                        color[u] = GRAY;
                                        if (u == sink) return true;
                                        queue[last++] = u;
                                }
                }
                return false;
        }
    }
}