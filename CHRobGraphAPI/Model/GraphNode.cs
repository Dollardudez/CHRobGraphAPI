using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHRobGraphAPI.Model
{
    public class GraphNode
    {
        #region FIELDS
        /// <summary>
        /// List of neighbor GraphNodes
        /// </summary>
        private List<GraphNode> _adjencyList = new List<GraphNode>();
        #endregion

        #region PROPERTIES
        /// <summary>
        /// List of neigbor GraphNodes
        /// </summary>
        public List<GraphNode> AdjencyList { get => _adjencyList; }
        /// <summary>
        /// The string value of the GraphNode
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// If the GraphNode has been visited
        /// </summary>
        public bool Visited { get; set; }
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// Add the GraphNode in the argument to an adjency list
        /// </summary>
        /// <param name="node">GraphNode to be added to the AdjencyList</param>
        public void AddEdge(GraphNode node)
        {
            _adjencyList.Add(node);
        }
        #endregion

        /// <summary>
        /// Constructor Initializes the GraphNode Value property to the string
        /// in the argument
        /// </summary>
        /// <param name="val">The string value of the Value property</param>
        public GraphNode(string val)
        {
            this.Value = val;
        }
    }
}

