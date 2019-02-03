using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Objects
{
    class Player
    {
        string Name;
        Location CurrentLocation;
        public RemoteClient Client;
        
        public Player(string Name)
        {
            this.Name = Name;
            CurrentLocation = Global.Locations["Town of Beginnings"];


        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string Name)
        {
            this.Name = Name;
        }
        public Location GetLocation()
        {
            return this.CurrentLocation;
        }
        public void MovePlayer(Location Destination)
        {
            Location destination = Global.Locations[Destination.GetName()];
            int DistanceToMove = CurrentLocation.GetDistance(Destination);
        }
    }
}
