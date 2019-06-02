using System;
using System.Net.Sockets;
using System.Text;

public class TcpTimeClient
{
    private const int portNum = 5500;
    private const string hostName = "localhost";

    public static int Main(String[] args)
    {
        try
        {
            TcpClient client = new TcpClient(hostName, portNum);

            NetworkStream ns = client.GetStream();

            //Console.WriteLine(ReadMessage(ns));

            Networking.SendMessage(ns, "Hello Server!");
            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        return 0;
    }

   
}