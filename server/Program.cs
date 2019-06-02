using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

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

            //             byte[] byteTime = Encoding.ASCII.GetBytes(DateTime.Now.ToString());
            // 
            //             try
            //             {
            //                 ns.Write(byteTime, 0, byteTime.Length);
            //                 ns.Close();
            //                 client.Close();
            //             }
            //             catch (Exception e)
            //             {
            //                 Console.WriteLine(e.ToString());
            //             }

            Console.WriteLine(ReadMessage(ns));
        }

        listener.Stop();

        return 0;
    }

    private static string ReadMessage(NetworkStream stream)
    {
        if (stream != null && stream.CanRead)
        {
            byte[] bytes = new byte[1024];
            int bytesRead = stream.Read(bytes, 0, bytes.Length);

            return Encoding.ASCII.GetString(bytes, 0, bytesRead);
        }
        else
        {
            return "";
        }
    }

    private static void SendMessage(NetworkStream stream, string message)
    {
        if (stream != null && stream.CanWrite)
        {
            byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(message);
            stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
            Console.WriteLine("Client sent his message - should be received by server");
        }
    }
}