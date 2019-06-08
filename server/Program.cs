using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server
{
    public class TcpTimeServer
    {
        private const int portNum = 5500;

        public static int Main(String[] args)
        {
            bool done = false;
             
            TcpListener listener = new TcpListener(IPAddress.Any,portNum);
             
            listener.Start();
             
            while (!done)
            {
                Console.Write("Waiting for connection...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Connection accepted.");
                NetworkStream ns = client.GetStream();
                Console.WriteLine(Networking.ReadMessage(ns));
            }
             
            listener.Stop();

            //Database db = new Database("niisku.lamk.fi", "laurtomi", "Koodaus1", "user_laurtomi");
            //db.GetAllEntries("ds19_phonenumbers ");


            return 0;
        }

    }
}