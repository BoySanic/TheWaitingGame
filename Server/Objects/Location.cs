using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Objects
{
    class Location
    {
        public string Name;
        public int[] Coordinates;
        Dictionary<string, int> Distances;

        public Location(string Name, int[] Coordinates, Dictionary<string, int> Distances)
        {
            this.Name = Name;
            this.Coordinates = Coordinates;
            this.Distances = Distances;
        }

        public int GetDistance(string Destination)
        {
            int Distance = 0;
            Distance = Distances[Destination];
            return Distance;
        }
    }
}
