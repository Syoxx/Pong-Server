using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace Pong
{
	public class SocketClient
	{
        // Data buffer for incoming data.
        static byte[] bytes = new byte[1024];

        static IPHostEntry ipHostInfo;
        static IPEndPoint remoteEP;
        static Socket sender;

        public static void StartClient()
        {
            // Establish the remote endpoint for the socket.
            // This example uses port 11000 on the local computer.
#pragma warning disable CS0618 // Typ oder Element ist veraltet
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
#pragma warning restore CS0618 // Typ oder Element ist veraltet
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            remoteEP = new IPEndPoint(ipAddress, 11000);

            Thread tClient = new Thread(ClientHandler);
            tClient.Start();

            // Create a TCP/IP  socket.
            sender = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(remoteEP);
        }

        static void ClientHandler()
        {
            while (true)
            {
                try
                {
                    sender.Send(Encoding.UTF8.GetBytes(dataHandler));

                    StreamWriter cWriter = new StreamWriter(clientWriter);
                    StreamReader cReader = new StreamReader(clientReader);
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
        
        }

        public static int Main(String[] args)
        {
            StartClient();
            return 0;
        }
    }
}