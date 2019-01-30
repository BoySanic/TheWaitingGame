using System;
using System.Net;
using System.Net.Sockets;
namespace Client_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What data will you send?");
                string Data = Console.ReadLine();
                Data = SendData(Data);
                Console.WriteLine("the reply was: {0}", Data);
            }

        }
        static string SendData(string message)
        {
            string server = "127.0.0.1";
            string reply = null;
            try
            {
                Int32 port = 6969;
                TcpClient Client = new TcpClient(server, port);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                NetworkStream stream = Client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);
                data = new byte[256];
                Int32 bytes = stream.Read(data, 0, data.Length);
                reply = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                stream.Close();
                Client.Close();

            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            return reply;
        }
        
    }
}
