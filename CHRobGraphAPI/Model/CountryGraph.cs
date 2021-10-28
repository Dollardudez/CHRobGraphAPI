using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CHRobGraphAPI.Model
{
    public class CountryGraph
    {
        // The list of vertices in the graph
        private List<GraphNode> vertices;

        // The number of vertices
        int size;

        public Stack<string> Path = new Stack<string>();

        public List<GraphNode> Vertices { get { return vertices; } }
        public int Size { get { return vertices.Count; } }

        public CountryGraph(List<GraphNode> allCountries)
        {
            vertices = allCountries;
            size = vertices.Count;
        }

        public void ResetPath()
        {
            Path.Clear();
        }
        public bool DepthFirstSearch(GraphNode root, GraphNode dest)
        {
            root.Visited = true;

            // include the current node in the path
            Path.Push(root.Value);

            // if destination vertex is found
            if (root.Value == dest.Value)
            {
                return true;
            }

            // do for every edge `src —> i`
            foreach(GraphNode node in root.AdjencyList)
            {
                // if `u` is not yet discovered
                if (node.Visited != true)
                {
                    // return true if the destination is found
                    if (DepthFirstSearch(node, dest))
                    {
                        return true;
                    }
                }
            }

            // backtrack: remove the current node from the path
            Path.Pop();

            // return false if destination vertex is not reachable from src
            return false;
        }
    }
}
