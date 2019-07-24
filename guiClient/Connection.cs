using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace guiClient
{
    class Connection
    {
        private const int portNum = 5500;
        private const string hostName = "localhost";
        private TcpClient client;
        private NetworkStream ns;
        bool connected = false;
        public Connection()
        {
            try
            {
                client = new TcpClient(hostName, portNum);
                ns = client.GetStream();
                connected = true;
            }
            catch(Exception e)
            {
                connected = false;
            }
        }

        public TcpClient GetTcpClient()
        {
            return client;
        }

        public NetworkStream GetNetworkStream()
        {
            return ns;
        }
    }
}
