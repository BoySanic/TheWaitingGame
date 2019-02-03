using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Objects
{
    class Location
    {
        string Name;
        Dictionary<Location, int> Distances;
        double BankBalance = 1000;
        double BankLimit = 1000;
        public Location(string Name, Dictionary<Location, int> Distances)
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

        public int GetDistance(Location Destination)
        {
            //Here too
            int Distance = 0;
            Distance = Dijkstra(this, Destination);
            return Distance;
        }
        public void SetDistances(Dictionary<Location, int> Distances)
        {
            this.Distances = Distances;
        }
        public void AddLocationToMap(Location Location, int DistanceToLocation)
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
        private int Dijkstra(Location start, Location Destination)
        {
            int FinalDistance = int.MaxValue;
            List<Location> UnvisitedNodes = new List<Location>();
            foreach (KeyValuePair<string, Location> kvp in Global.Locations)
            {
                UnvisitedNodes.Add(kvp.Value);
            }
            Dictionary<Objects.Location, int> FinalDistances = new Dictionary<Location, int>();
            //1. Mark all nodes unvisited, create set of all unvisited nodes
            //2. Assign to every node a distance value, zero for current node and infinity for all other nodes. Set initial node as current.
            //3. For the current node, consider all unvisited neighbors and calculate tentative distances through current node. (currentNodeDistance + nextNodeDistance)
            //   Take the lowest distance for each node. As in, if A is 6, and it's got a length of 2 to B, then B is 8, but only if the shortest path to B is over 8 at this point.
            //4. Once we consider all connected nodes in the currentNode, mark it as visited and remove it from the unvisited set.
            //5. If destination node has been marked visited, or if the smallest distance in the unvisited set is infinity, then stop. It's done.
            //6. Otherwise, select the unvisited node that has the smallest distance and make it the currentNode, go back to step 3
            Objects.Dijkstra.Node currentNode = new Dijkstra.Node();
            currentNode.Location = start;
            currentNode.Distances = start.Distances;
            Console.WriteLine(currentNode.Distances[start]);
            while (UnvisitedNodes.Count != 0)
            {
                if (!(currentNode.Location == Destination))
                {
                    foreach (KeyValuePair<Location, int> kvp in currentNode.Distances)
                    {
                        //Find the distances for each adjacent node
                        if (!(FinalDistances.ContainsKey(kvp.Key)))
                        {
                            FinalDistances.Add(kvp.Key, int.MaxValue);
                            Console.WriteLine("It doesn't contain it HAHA");
                        }
                        if (FinalDistances.ContainsKey(kvp.Key))
                        {
                            int distance = currentNode.DistanceToStart + kvp.Value;
                            //if the distance to this node through the currentNode is better than the current distance, change the current distance.
                            if (distance < FinalDistances[kvp.Key])
                            {
                                FinalDistances[kvp.Key] = distance;
                            }
                            //else, the current distance is better, don't change it.

                        }
                    }
                    //Find the lowest tentative distance node adjacent to this one that hasn't been visited and move to that node
                    int NextBestDistance = int.MaxValue;
                    Location BestNextLocation = new Location("test");
                    foreach (KeyValuePair<Location, int> kvp in currentNode.Distances)
                    {
                        //If distance to that node is shorter than the current shortest, then select that
                        int test = kvp.Value + currentNode.DistanceToStart;
                        if (test < NextBestDistance && test > 0 && UnvisitedNodes.Contains(kvp.Key))
                        {
                            BestNextLocation = kvp.Key;
                            NextBestDistance = currentNode.Distances[kvp.Key] + currentNode.DistanceToStart;
                            Console.WriteLine("Next best location is set to {0}", BestNextLocation.GetName());
                        }

                    }
                    Console.ReadLine();
                    //Take the best node, already found, and continue.
                    UnvisitedNodes.Remove(currentNode.Location);
                    FinalDistance = currentNode.DistanceToStart;
                    currentNode.Location = BestNextLocation;
                    currentNode.Distances = BestNextLocation.Distances;
                    currentNode.DistanceToStart = NextBestDistance;
                    Console.WriteLine("currentNode.Location = {0}", currentNode.Location.GetName());
                    Console.ReadLine();
                }
                else
                {
                    //Made it to destination
                    return currentNode.DistanceToStart;
                }
            }
            return FinalDistance;
        }
       
    }
}
