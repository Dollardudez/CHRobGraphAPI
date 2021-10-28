using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHRobGraphAPI.Model
{
    public class PathModel
    {
        #region FIELDS
        /// <summary>
        /// The path that is sent to 
        /// </summary>
        private Stack<string> _muhstack = new Stack<string>();
        /// <summary>
        /// reference to the actual Graph that defines countries
        /// and their relationships
        /// </summary>
        private CountryGraph _countryGraph = new CountryGraph();

        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public Stack<string> FindPath(string root, string dest)
        {
            //reset the CountryGraph.Path property
            _countryGraph.ResetPath();

            //get the nodes from the strings in function parameters
            GraphNode rootNode = _countryGraph.GetNodeInGraph(root);
            GraphNode destNode = _countryGraph.GetNodeInGraph(dest);

            //if destination node is not in the graph
            if (destNode == null || rootNode == null)
            {
                _muhstack.Push("");
                return _muhstack;
            }
            if (_countryGraph.DepthFirstSearch(rootNode, destNode) == true)
            {
                _muhstack = _countryGraph.Path;
                return _muhstack;
            }
            return _muhstack;
        }
        #endregion
    }
}
