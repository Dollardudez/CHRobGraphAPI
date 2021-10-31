using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHRobGraphAPI
{
    public interface IPath
    {
        public string Destination { get; set; }
        public Stack<string> List { get; }
    }
}
