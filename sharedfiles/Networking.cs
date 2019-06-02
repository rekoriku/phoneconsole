using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;


    static class Networking
    {
        public static string ReadMessage(NetworkStream stream)
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

        public static void SendMessage(NetworkStream stream, string message)
        {
            if (stream != null && stream.CanWrite)
            {
                byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(message);
                stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
                Console.WriteLine("Client sent his message - should be received by server");
            }
        }
    }

