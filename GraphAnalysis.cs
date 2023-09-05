using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public static class GraphAnalysis
    {



        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <param name="vertices"></param>
        /// <param name="edges"></param>
        /// <param name="startVertex"></param>
        /// <param name="outputs"></param>

        /// <summary>
        /// Analyze the edges of the given DIRECTED graph by applying DFS starting from the given "startVertex" and count the occurrence of each type of edges
        /// NOTE: during search, break ties (if any) by selecting the vertices in ASCENDING alpha-numeric order
        /// </summary>
        /// <param name="vertices">array of vertices in the graph</param>
        /// <param name="edges">array of edges in the graph</param>
        /// <param name="startVertex">name of the start vertex to begin from it</param>
        /// <returns>return array of 3 numbers: outputs[0] number of backward edges, outputs[1] number of forward edges, outputs[2] number of cross edges</returns>


        public static int[] AnalyzeEdges(string[] vertices, KeyValuePair<string, string>[] edges, string startVertex)
        {
            int[] results = new int[3];

            Dictionary<string, char> visited = new Dictionary<string, char>();
             
            Dictionary<string, int> vdiscover = new Dictionary<string, int>();
            int time = 0;
            int L = vertices.Length;
            Dictionary<string, ArrayList > adjList = new Dictionary<string, ArrayList >();
             
            foreach (string vertex in vertices)
            {
                visited[vertex] = 'w';
                vdiscover[vertex] = 0;
                adjList[vertex] = new ArrayList();
            }
            foreach (KeyValuePair<string, string> edge in edges)
            {
                adjList[edge.Key].Add(edge.Value);
                adjList[edge.Key].Sort();

            }
            
            DFS_visit(startVertex,   adjList,   visited,  results,   vdiscover,   ref  time );
             
            return results;

            }

        private static void DFS_visit( string vertex,   Dictionary<string, ArrayList> adjList,   Dictionary<string, char> visited,   int[] result,   Dictionary<string, int> vdiscover ,  ref  int time )
        {
            visited[vertex] = 'g';
             time += 1;
            vdiscover[vertex] = time;

                   foreach (string neighbor in adjList[vertex])
               {

                if (visited[neighbor] == 'g')
                    result[0]++;
               else  if (  visited[neighbor] == 'b' && vdiscover[vertex] < vdiscover[neighbor])
                        result[1]++;
                      

                     else  if ( visited[neighbor] == 'b' && vdiscover[vertex] > vdiscover[neighbor])
                        
                        result[2]++;
                if (visited[neighbor] == 'w')

                     DFS_visit(neighbor, adjList, visited, result, vdiscover, ref time);


            }
 
                 visited[vertex] = 'b';
             time += 1;

        }
 
    }
}








#endregion



