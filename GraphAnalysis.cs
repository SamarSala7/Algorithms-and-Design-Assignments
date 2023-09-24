using System;
using System.Collections.Generic;
using System.Linq;
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
            //REMOVE THIS LINE BEFORE START CODING
            // throw new NotImplementedException();

            //Init Dictionaries
            Dictionary<string, string> Root = new Dictionary<string, string>();
            Dictionary<string, int> Time_D = new Dictionary<string, int>();
            Dictionary<string, string> State = new Dictionary<string, string>();
            Dictionary<string, List<string>> List_Adj = new Dictionary<string, List<string>>();

            //Init Var
            int[] C = new int[3];
            int T = 0;

            //Foreaches
            foreach (string Ver_State in vertices)
                State[Ver_State] = "white";
            foreach (string Ver_Root in vertices)
                Root[Ver_Root] = null;
            foreach (string Ver in vertices)
                List_Adj[Ver] = new List<string>();
            foreach (KeyValuePair<string, string> E in edges)
                List_Adj[E.Key].Add(E.Value);      
            
            //DFS Function
            void DFS(string V)
            {
                Time_D[V] = T;
                State[V] = "gray";
                T = T + 1;
                foreach (string neighbor in List_Adj[V].OrderBy(n => n)){
                    if (State[neighbor] == "gray") C[0]++;
                    else if (State[neighbor] == "black"){
                        if (Time_D[V] < Time_D[neighbor]) C[1]++;
                        else C[2]++;
                    }
                    else /*(State[neighbor] == "white")*/{
                        Root[neighbor] = V;
                        DFS(neighbor);
                    }
                }
                State[V] = "black";
                T++;
            }
            DFS(startVertex);
            return C;
        }
    }
    #endregion
}