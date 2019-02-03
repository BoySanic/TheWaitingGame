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
        double Speed = 4.82803;
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
            double TimeToWait = DistanceToMove / Speed;
            DateTime dt = DateTime.Now.AddHours(TimeToWait);
            Global.PlayerTimers.Add(this, dt);
            Console.WriteLine("You will arrive at your destination at {0}", dt);
        }
    }
}
