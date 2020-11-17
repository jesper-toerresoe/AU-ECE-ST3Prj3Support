using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.CompilerServices;
using ST3Prj3DomaineCore.Models.DTO;

namespace STPRJ3UDPSenderCommandCore
{
    public class UDPSender
    {
        /// <summary>
        /// Using this way to JSON Serialize and Deserialize
        /// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-core-3-1
        /// </summary>
        private const int listenPort = 11000;
        private const int listenPortCommand = 12000;


        public void SendTextSimple()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse("192.168.1.255");
            IPEndPoint ep = new IPEndPoint(broadcast, listenPort);
            string message;

            while (true)
            {
                System.Console.WriteLine("Send en besked: ");

                message = System.Console.ReadLine();
                byte[] sendbuf = Encoding.ASCII.GetBytes(message);


                s.SendTo(sendbuf, ep);

                Console.WriteLine("Message sent to the broadcast address");
            }
        }


        public void SendJSONCommands()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress broadcast = IPAddress.Parse("192.168.1.255"); //10.255.255.255 class A B + C
            IPEndPoint ep = new IPEndPoint(broadcast, listenPortCommand);
            CommandDTO sendCommand = new CommandDTO() { sendID = "Laptop 57", ComNo = 45 };
            byte[] jsonUtf8Bytes;
            JsonSerializerOptions sendopt = new JsonSerializerOptions() { WriteIndented = true };
            string com;

            while (true)
            {
                System.Console.WriteLine("Send en kommando: ");
                com = System.Console.ReadLine();
                sendCommand.ComNo = IntegerType.FromString(com);
                jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(sendCommand, sendopt);
                s.SendTo(jsonUtf8Bytes, ep);

                Console.WriteLine("Message sent to the broadcast address");
            }
        }

        /// <summary>
        /// http://www.jarloo.com/c-udp-multicasting-tutorial/
        /// https://en.wikipedia.org/wiki/Multicast_address
        /// </summary>
        public void SendTextMultiCast()
        {
            UdpClient udpclient = new UdpClient();

            //IPAddress multicastaddress = IPAddress.Parse("239.0.0.222");
            IPAddress multicastaddress = IPAddress.Parse("224.0.0.222");
            udpclient.JoinMulticastGroup(multicastaddress);
            IPEndPoint remoteep = new IPEndPoint(multicastaddress, 2222);

            Byte[] buffer = null;
 
            Console.WriteLine("Press ENTER to start sending messages");
            Console.ReadLine();

            for (int i = 0; i <= 100; i++)
            {
                buffer = Encoding.Unicode.GetBytes(i.ToString());
                udpclient.Send(buffer, buffer.Length, remoteep);
                Console.WriteLine("Sent " + i);
            }

            Console.WriteLine("All Done! Press ENTER to quit.");
            Console.ReadLine();
        }

        /// <summary>
        /// http://www.jarloo.com/c-udp-multicasting-tutorial/
        /// https://en.wikipedia.org/wiki/Multicast_address
        /// </summary>
        public void SendJSONCommandsMultiCast()
        {
            UdpClient udpclient = new UdpClient();

            //IPAddress multicastaddress = IPAddress.Parse("239.0.0.222");
            IPAddress multicastaddress = IPAddress.Parse("224.0.1.222");
            udpclient.JoinMulticastGroup(multicastaddress);
            IPEndPoint remoteep = new IPEndPoint(multicastaddress, 2222);
            CommandDTO sendCommand = new CommandDTO() { sendID = "Laptop 57", ComNo = 45 };
            byte[] jsonUtf8Bytes;
            JsonSerializerOptions sendopt = new JsonSerializerOptions() { WriteIndented = true };
            string com;

            Console.WriteLine("Start sending ! Press ENTER Ctr C quit.");
            while (true)
            {
                System.Console.Write("Send en kommando: ");
                com = System.Console.ReadLine();
                sendCommand.ComNo = IntegerType.FromString(com);
                jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(sendCommand, sendopt);
                udpclient.Send(jsonUtf8Bytes, jsonUtf8Bytes.Length, remoteep); //Remark no specific endpoint given 

                Console.WriteLine($"Message sent to the broadcast address {sendCommand}");
            }
                                   
        }

    }
}
