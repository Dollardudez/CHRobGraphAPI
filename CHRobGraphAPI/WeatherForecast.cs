using CHRobGraphAPI.Model;
using System;
using System.Collections.Generic;

namespace CHRobGraphAPI
{
    public class WeatherForecast
    {
        CountryPath _cpath = new CountryPath();
        public string Destination { get; set; }

        public Stack<string> List { get; set; }

        public WeatherForecast(string dest)
        {
            Destination = dest;
            Stack<string> originalStack = _cpath.FindPath(dest);
            List = GetReversePath(originalStack);
        }

        private Stack<string> GetReversePath(Stack<string> originalStack)
        {
            Stack<string> reversedStack = new Stack<string>();
            while (originalStack.Count != 0)
            {
                reversedStack.Push(originalStack.Pop());
            }
            return reversedStack;
        }
    }
}
