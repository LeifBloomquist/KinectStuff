using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KinectC64.Network
{
    class UDPSender
    {
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint endPoint = null;

        public UDPSender(String IpAddress, int port)
        {
            IPAddress serverAddr = IPAddress.Parse(IpAddress);
            endPoint = new IPEndPoint(serverAddr, port);
        }

        public void sendData(byte[] tosend)
        {
            if (endPoint != null)
            {
                sock.SendTo(tosend, endPoint);
            }
        }
    }
}
