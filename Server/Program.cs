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
            Dictionary<string, int> TOBDistances = new Dictionary<string, int>();
            TOBDistances.Add("ShitShack", 5);
            Dictionary<string, int> SSDistances = new Dictionary<string, int>();
            SSDistances.Add("Town Of Beginnings", 5);
            Objects.Location TownOfBeginnings = new Objects.Location("Town of Beginnnings", new int[] { 0, 0 }, TOBDistances);
            Objects.Location ShitShack = new Objects.Location("Shit Shack", new int[] { 1, 0 }, SSDistances);
            Global.Locations.Add("Town of Beginnnings", TownOfBeginnings);
            Global.Locations.Add("Shit Shack", ShitShack);
            Objects.Player player = new Objects.Player("BoySanic");
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
