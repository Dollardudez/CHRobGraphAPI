using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CHRobGraphAPI.Model
{
    public class CountryGraph
    {
        #region FIELDS
        /// The GraphNodes that must be visited to reach a destination GraphNode
        /// </summary>
        public Stack<string> Path = new Stack<string>();
        /// <summary>
        /// GraphNodes contained in the CountryGraph
        /// </summary>
        private List<GraphNode> _allNodes = new List<GraphNode>();

        private GraphNode _usa = new GraphNode("USA");
        private GraphNode _can = new GraphNode("CAN");
        private GraphNode _mex = new GraphNode("MEX");
        private GraphNode _blz = new GraphNode("BLZ");
        private GraphNode _gtm = new GraphNode("GTM");
        private GraphNode _slv = new GraphNode("SLV");
        private GraphNode _hnd = new GraphNode("HND");
        private GraphNode _nic = new GraphNode("NIC");
        private GraphNode _cri = new GraphNode("CRI");
        private GraphNode _pan = new GraphNode("PAN");
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// Initializes the Graph with vertices/nodes
        /// </summary>
        private void FillAllCountries()
        {
            _allNodes.Add(_usa);
            _allNodes.Add(_can);
            _allNodes.Add(_mex);
            _allNodes.Add(_blz);
            _allNodes.Add(_gtm);
            _allNodes.Add(_slv);
            _allNodes.Add(_hnd);
            _allNodes.Add(_nic);
            _allNodes.Add(_cri);
            _allNodes.Add(_pan);
        }
        /// <summary>
        /// Add all edges
        /// </summary>
        private void AddEdges()
        {
            //usa
            _usa.AddEdge(_can);
            _usa.AddEdge(_mex);
            //mexico
            _mex.AddEdge(_gtm);
            _mex.AddEdge(_blz);
            //guatamala
            _gtm.AddEdge(_slv);
            _gtm.AddEdge(_hnd);
            //honduras
            _hnd.AddEdge(_nic);
            //nicaragua
            _nic.AddEdge(_cri);
            //costa rica
            _cri.AddEdge(_pan);
        }
        #endregion

        #region PUBLIC METHODS
        /// Resets the Path property
        /// </summary>
        public void ResetPath()
        {
            Path.Clear();
        }

        /// <summary>
        /// Depth First Search to find the path from root to destination node
        /// </summary>
        /// <param name="root">The GraphNode that the </param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public bool DepthFirstSearch(GraphNode root, GraphNode dest)
        {
            //root has been visited
            root.Visited = true;
            // include the current node in the path
            Path.Push(root.Value);

            // if we have reached the destination node
            if (root.Value == dest.Value)
            {
                return true;
            }
            // recurse through the adjency list
            foreach (GraphNode node in root.AdjencyList)
            {
                // if the node has not been visited
                if (node.Visited != true)
                {
                    // return true if the destination is found
                    if (DepthFirstSearch(node, dest))
                    {
                        return true;
                    }
                }
            }
            // backtrack
            Path.Pop();
            // false if destination was never reached
            return false;
        }
        /// <summary>
        /// Gets the GraphNode associated with the 'nodeValue' string value
        /// </summary>
        /// <param name="dest">The Value property of the GraphNode we are trying to find
        /// in the Graph</param>
        /// <returns></returns>
        public GraphNode GetNodeInGraph(string nodeValue)
        {
            GraphNode destNode = null;
            for (int i = 0; i < _allNodes.Count; i++)
            {
                if (_allNodes[i].Value.Equals(nodeValue))
                {
                    destNode = _allNodes[i];
                    break;
                }
            }
            return destNode;
        }

        #endregion

        public CountryGraph()
        {
            AddEdges();
            FillAllCountries();
        }
    }
}
