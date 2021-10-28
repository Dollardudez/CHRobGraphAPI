using CHRobGraphAPI.Model;
using System;
using System.Collections.Generic;

namespace CHRobGraphAPI
{
    public class CountryPath : IPath
    {
        #region FIELDS
        /// <summary>
        /// refrence to the path that it takes to go from root node
        /// to destination node.
        /// </summary>
        private PathModel _cpath = new PathModel();

        private string _destination { get; set; }

        private Stack<string> _list { get; set; }
        #endregion

        #region PROPERTIES
        public string Destination { get => _destination;}
        /// <summary>
        /// JSON property to be returned on API call
        /// </summary>
        public Stack<string> List { get => _list; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dest"></param>
        /// 
        #endregion

        #region PUBLIC METHODS
        /// <summary>
        /// PathModel.FindPath() returns a 'backwards' path.
        /// This function reverses that path to appease the API requirements.
        /// </summary>
        /// <param name="originalStack"></param>
        /// <returns></returns>
        private Stack<string> GetReversePath(Stack<string> originalStack)
        {
            Stack<string> reversedStack = new Stack<string>();
            while (originalStack.Count != 0)
            {
                reversedStack.Push(originalStack.Pop());
            }
            return reversedStack;
        }
        #endregion
        public CountryPath(string dest)
        {
            Stack<string> originalStack = _cpath.FindPath("USA", dest);
            _destination = dest;
            _list = GetReversePath(originalStack);
        }
    }
}
