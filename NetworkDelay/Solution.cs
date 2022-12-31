using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDelay
{
    public class Solution
    {
        List<int> unvisited = new List<int>();
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            int totalTime = -1;
            int[] vertices = new int[n+1];
            Dictionary<int, PriorityQueue<int, int>> graph = new Dictionary<int, PriorityQueue<int, int>>();
           
            for (int i = 0; i <= n; i++)
            {
                if ( i!=0)
                    unvisited.Add(i);

                //Set time to max value as default.
                vertices[i] = int.MaxValue;

                graph.Add(i, new PriorityQueue<int, int>());

            }

            //set start node time as 0.
            vertices[k] = 0;

            foreach (var t in times)
                graph[t[0]].Enqueue(t[1], t[2]);
            
            vertices = Dijkstra(graph, vertices, k);

            for(int v=1;v<=n;v++)
            {
                if (vertices[v] == int.MaxValue)
                    return -1;

                totalTime = Math.Max(totalTime, vertices[v]);
            }
            return totalTime;
        }

        private int[] Dijkstra(Dictionary<int, PriorityQueue<int, int>> graph, int[] vertices, int k)
        {
            unvisited.Remove(k);
            while (graph[k].Count > 0)
            {

                graph[k].TryPeek(out int adjNode, out int adjTime);
                graph[k].Dequeue();

                int altTime = vertices[k] + adjTime;

                if (vertices[adjNode] > altTime)
                    vertices[adjNode] = altTime;
            }


            if (unvisited.Any())
            {
                int leastUnvisitedTime = int.MaxValue;
                int leastUnvisitedNode = unvisited.First();

                foreach (int v in unvisited)
                {
                    if (leastUnvisitedTime > vertices[v])
                    {
                        leastUnvisitedTime = vertices[v];
                        leastUnvisitedNode = v;
                    }
                }

                Dijkstra(graph, vertices, leastUnvisitedNode);
            }
            return vertices;
        }
    }
}
