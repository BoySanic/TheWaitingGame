using System;
using System.Collections;
using System.Collections.Generic;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> TOBDistances = new Dictionary<string, int>();
            TOBDistances.Add("ShitShack", 5);
            Dictionary<string, int> SSDistances = new Dictionary<string, int>();
            SSDistances.Add("Town Of Beginnings", 5);
            Objects.Location TownOfBeginnings = new Objects.Location("Town of Beginnnings", new int[] { 0, 0 }, TOBDistances);
            Objects.Location ShitShack = new Objects.Location("Shit Shack", new int[] { 1, 0 }, SSDistances);
            Global.Locations.Add(TownOfBeginnings);
            Global.Locations.Add(ShitShack);
            Objects.Player player = new Objects.Player("BoySanic");

        }
        static void Listen()
        {

        }
    }
}
