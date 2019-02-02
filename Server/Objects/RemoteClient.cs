using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
namespace Server.Objects
{
    class RemoteClient
    {
        public IPAddress IP;

        public RemoteClient(string IPAddress)
        {
            if (!System.Net.IPAddress.TryParse(IPAddress, out IP))
            {
                Console.WriteLine($"{IPAddress} is not a valid IPv4 address.");
            }
            Console.WriteLine("This worked {0} ", IP);
        }
        public RemoteClient(IPAddress IPAddress)
        {
            IP = IPAddress;
        }
    }
}
