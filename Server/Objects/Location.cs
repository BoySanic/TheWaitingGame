using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Objects
{
    class Location
    {
        string Name;
        Dictionary<string, int> Distances;
        double BankBalance = 1000;
        double BankLimit = 1000;
        public Location(string Name, Dictionary<string, int> Distances)
        {
            this.Name = Name;
            this.Distances = Distances;
        }
        public Location(string Name)
        {
            this.Name = Name;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public int GetDistance(string Destination)
        {
            int Distance = 0;
            Distance = Distances[Destination];
            return Distance;
        }
        public int GetDistance(Location Destination)
        {
            int Distance = Destination.Distances[Destination.Name];
            return Distance;
        }
        public void AddLocationToMap(Location Location, int DistanceToLocation)
        {
            Distances.Add(Location.GetName(), DistanceToLocation);
        }
        public void AddLocationToMap(string Location, int DistanceToLocation)
        {
            Distances.Add(Location, DistanceToLocation);
        }
        public double GetBankBalance()
        {
            return BankBalance;
        }
        public double GetBankLimit()
        {
            return BankLimit;
        }
        public void IncreaseBankLimit(double AmountToAdd)
        {
            BankLimit += AmountToAdd;
        }
        public void ReplenishBankBalance()
        {
            BankBalance = BankLimit;
        }
    }
}
