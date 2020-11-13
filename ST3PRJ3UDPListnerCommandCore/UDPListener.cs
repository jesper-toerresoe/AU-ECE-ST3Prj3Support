using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ST3Prj3DomaineCore.Models.DTO;

namespace ST3PRJ3UDPListnerCommandCore
{
    /// <summary>
    /// Using this way to JSON Serialize and Deserialize
    /// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-core-3-1
    /// </summary>

    public class UDPListener
    {
        private const int listenPort = 11000;
        private const int listenPortCommand = 12000;

        public  void StartListener()
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);

                    Console.WriteLine($"Received broadcast from {groupEP} :");
                    Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }

        public  void StartListenerJSONCommands()
        {
            UdpClient listener = new UdpClient(listenPortCommand);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            CommandDTO rxCommand;
            string jsonString;
            byte[] bytes;

            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast of a Command");
                    bytes = listener.Receive(ref groupEP);
                    jsonString = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    rxCommand = JsonSerializer.Deserialize<CommandDTO>(jsonString);

                    Console.WriteLine($"Received broadcast command from {groupEP} :");
                    Console.WriteLine(rxCommand);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }

    }
}
