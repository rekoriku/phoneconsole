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

            SendMessage(ns, "Hello Server!");
            client.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        return 0;
    }

    private static string ReadMessage(NetworkStream stream)
    {
        if(stream != null && stream.CanRead)
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
        if(stream != null && stream.CanWrite)
        {
            byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(message);
            stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
            Console.WriteLine("Client sent his message - should be received by server");
        }
    }
}