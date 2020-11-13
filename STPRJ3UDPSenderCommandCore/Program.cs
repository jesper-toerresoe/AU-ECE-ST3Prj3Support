using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ST3Prj3DomaineCore.Models.DTO;

namespace STPRJ3UDPSenderCommandCore
{
   

    class Program
    {
        static void Main(string[] args)
        {
            UDPSender localSender = new UDPSender();
            localSender.SendJSONCommands();
        }
    }
}
