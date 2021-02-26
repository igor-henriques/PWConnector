using PWToolKit.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWConnector
{
    class gamedbdConfig : IPwDaemonConfig
    {
        public string Host { get; }
        public int Port { get; }

        public gamedbdConfig(string host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
