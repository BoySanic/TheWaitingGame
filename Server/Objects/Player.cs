using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Objects
{
    class Player
    {
        public string Name;
        public Location CurrentLocation;
        public Player(string Name)
        {
            this.Name = Name;
            this.CurrentLocation = Global.Locations[0];
        }
        public MovePlayer(string Destination)
        {
            Location destination = Global.Locations[Destination]
        }
    }
}
