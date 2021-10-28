using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHRobGraphAPI.Model
{
    public class GraphNode
    {
        private List<GraphNode> _adjencyList = new List<GraphNode>();
        public List<GraphNode> AdjencyList { get => _adjencyList; }
        public string Value { get; set; }

        private bool _visited = false;
        public bool Visited 
        {
            get { return _visited; }
            set { _visited = value; }
        }

        public GraphNode(string val)
        {
            this.Value = val;
        }

        public void AddEdge(GraphNode node)
        {
            _adjencyList.Add(node);
        }
    }
}

