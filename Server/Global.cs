using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Global
    {
        public static Dictionary<string, Objects.Location> Locations = new Dictionary<string, Objects.Location>();
        public static Dictionary<string, Objects.Player> Players = new Dictionary<string, Objects.Player>();
        public static Dictionary<Objects.Player, DateTime> PlayerTimers = new Dictionary<Objects.Player, DateTime>();
        //Maybe make a PlayerCollection and a LocationCollection
    }
}
