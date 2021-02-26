using PWToolKit.Packets;
using System.IO;
using System.Runtime.InteropServices;

namespace PWConnector
{
    public class gDeliveryConfig : IPwDaemonConfig
    {        
        public string Host { get; }
        public int Port { get; }

        public gDeliveryConfig(string host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
