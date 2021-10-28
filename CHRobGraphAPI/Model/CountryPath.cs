using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHRobGraphAPI.Model
{
    public class CountryPath
    {
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

        private List<GraphNode> _allCountries = new List<GraphNode>();
        private Stack<string> _muhstack = new Stack<string>();


        private CountryGraph _countryGraph;

        private void FillAllCountries()
        {
            _allCountries.Add(_usa);
            _allCountries.Add(_can);
            _allCountries.Add(_mex);
            _allCountries.Add(_blz);
            _allCountries.Add(_gtm);
            _allCountries.Add(_slv);
            _allCountries.Add(_hnd);
            _allCountries.Add(_nic);
            _allCountries.Add(_cri);
            _allCountries.Add(_pan);
        }

        private void AddEdges()
        {
            _usa.AddEdge(_can);
            _usa.AddEdge(_mex);

            _mex.AddEdge(_gtm);
            _mex.AddEdge(_blz);

            _gtm.AddEdge(_slv);
            _gtm.AddEdge(_hnd);

            _hnd.AddEdge(_nic);

            _nic.AddEdge(_cri);
            _cri.AddEdge(_pan);
        }

        public CountryPath()
        {
            AddEdges();
            FillAllCountries();
            _countryGraph = new CountryGraph(_allCountries);
        }

        public Stack<string> FindPath(string dest)
        {
            _countryGraph.ResetPath();
            GraphNode destNode = null;
            for(int i = 0; i < _allCountries.Count; i++)
            {
                if (_allCountries[i].Value.Equals(dest))
                {
                    destNode = _allCountries[i];
                    break;
                }
            }
            if (destNode == null)
            {
                _muhstack.Push("");
                return _muhstack;
            }
            if (_countryGraph.DepthFirstSearch(_usa, destNode) == true)
            {
                _muhstack = _countryGraph.Path;
                return _muhstack;
            }
            return _muhstack;
        }

    }
}
