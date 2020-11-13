using System;

namespace ST3PRJ3UDPListnerCommandCore
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Der lyttes!");
            var locallistener = new UDPListener();
            //locallistener.StartListener();//Starts a simple listener
            locallistener.StartListenerJSONCommands();
        }
        
    }
}
