using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Objects.Location TownOfBeginnings = new Objects.Location("Town Of Beginnings");
            Objects.Location ShitShack = new Objects.Location("Shit Shack");
            Objects.Location Cave = new Objects.Location("Cave");
            Objects.Location Portal = new Objects.Location("Portal");
            Dictionary<Objects.Location, int> TOBDistances = new Dictionary<Objects.Location, int>();
            TOBDistances.Add(ShitShack, 5);
            TOBDistances.Add(TownOfBeginnings, 0);
            TOBDistances.Add(Cave, int.MaxValue);
            TOBDistances.Add(Portal, int.MaxValue);
            Dictionary<Objects.Location, int> SSDistances = new Dictionary<Objects.Location, int>();
            SSDistances.Add(TownOfBeginnings, 5);
            SSDistances.Add(ShitShack, 0);
            SSDistances.Add(Cave, 10);
            SSDistances.Add(Portal, int.MaxValue);
            Dictionary<Objects.Location, int> CaveDistances = new Dictionary<Objects.Location, int>();
            CaveDistances.Add(TownOfBeginnings, int.MaxValue);
            CaveDistances.Add(ShitShack, 10);
            CaveDistances.Add(Cave, 0);
            CaveDistances.Add(Portal, 3);
            Dictionary<Objects.Location, int> PortalDistances = new Dictionary<Objects.Location, int>();
            PortalDistances.Add(TownOfBeginnings, int.MaxValue);
            PortalDistances.Add(ShitShack, int.MaxValue);
            PortalDistances.Add(Cave, 3);
            PortalDistances.Add(Portal, 0);
            TownOfBeginnings.SetDistances(TOBDistances);
            ShitShack.SetDistances(SSDistances);
            Cave.SetDistances(CaveDistances);
            Portal.SetDistances(PortalDistances);
            Global.Locations.Add("Town of Beginnings", TownOfBeginnings);
            Global.Locations.Add("Shit Shack", ShitShack);
            Global.Locations.Add("Cave", Cave);
            Global.Locations.Add("Portal", Portal);
            Objects.Player player = new Objects.Player("BoySanic");
            player.MovePlayer(Portal);
            Console.ReadLine();
            //Listen();
        }
        static void Listen()
        {
            TcpListener Server = null;
            try
            {
                Int32 Port = 6969;
                IPAddress localAddress = IPAddress.Parse("127.0.0.1");
                Server = new TcpListener(localAddress, Port);
                Server.Start();
                Byte[] bytes = new byte[256];
                String data = null;
                while (true)
                {
                    Console.Write("Waiting for a connection...");
                    TcpClient client = Server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    Console.WriteLine($"Incoming connection from:");
                    data = null;
                    NetworkStream stream = client.GetStream();
                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes);
                        Console.WriteLine("Received: {0}", data);
                        data = data.ToUpper();
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                        //Change this to status codes at some point, along with a reply containing a JSON object.
                        stream.Write(bytes);
                        Console.WriteLine("Send: {0}", data);

                    }
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                Server.Stop();
            }
            Console.WriteLine("\n Hit enter to continue...");
            Console.Read();
        }
    }
}
