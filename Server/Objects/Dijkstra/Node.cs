using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Objects.Dijkstra
{
    class Node
    {
        public Dictionary<Location, int> Distances = new Dictionary<Location, int>();
        public int DistanceToStart = 0;
        public Location Location;
        public Node()
        {
            
        }
    }
}
