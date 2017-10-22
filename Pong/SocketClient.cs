using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Pong
{
	class SocketClient
	{
		private bool cConnected;
		private Encoding rEncoding;
		private string data;
		private Encoding sEncoding;
		private string sData;
		private string rData;
        ThreadShareObject shareObject;

		public SocketClient(ThreadShareObject share)
		{
			// Data buffer for incoming data.
			byte[] bytes = new byte[1024];
            Boolean isServer = false;

			//IPAddress ip = { '127.0.0.1' };

			// Connect to a remote device.
			try
			{
				// Establish the remote endpoint for the socket.
				// This example uses port 11000 on the local computer.
				IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());

				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

				// Create a TCP/IP  socket.
				Socket sender = new Socket(AddressFamily.InterNetwork,
					SocketType.Stream, ProtocolType.Tcp);

				// Connect the socket to the remote endpoint. Catch any errors.
				try
				{
					sender.Connect(remoteEP);

					Console.WriteLine("Socket connected to {0}",
						sender.RemoteEndPoint.ToString());

					// sets up networkstream and reader/writer to communicate with server
					NetworkStream ns = new NetworkStream(sender);
					StreamWriter sWriter = new StreamWriter(ns);
					sEncoding = sWriter.Encoding;
					Console.WriteLine(sEncoding.ToString());
					StreamReader sReader = new StreamReader(ns);
					rEncoding = sReader.CurrentEncoding;
					Console.WriteLine(rEncoding.ToString());
					//replace "hello" with pwd transmission?
					sWriter.WriteLine("hello");
					sWriter.Flush();
					data = sReader.ReadLine();
					Console.WriteLine(data);

					// Send the data through the socket.
					cConnected = true;

                    // Receive the response from the remote device.
                    while (cConnected)
					{
						sData = sReader.ReadLine();
						StreamInClient sIn = new StreamInClient();
						//analyzes  the incoming data and stores return value, mostly done i guess
						rData = sIn.InData(sData, share);
                        //sends a new msg out
                        StreamOutClient sOut = new StreamOutClient();

                        GameState state = GameState.None;

                        while(state != GameState.Started)
                        {
                            //string cPwd = Console.ReadLine();
                            sWriter.WriteLine("pongPwd");
                            sWriter.Flush();
                            state = GameState.Started;
                        }

                        while(state == GameState.Started)
                        {
                            if (shareObject.Up == true)
                            {
                                sWriter.WriteLine("cmd up");
                                sWriter.Flush();
                                shareObject.Up = false;
                            }
                            else if (shareObject.Down == true)
                            {
                                sWriter.WriteLine("cmd down");
                                sWriter.Flush();
                                shareObject.Down = false;
                            }
                            else if (shareObject.Up == false && shareObject.Down == false)
                            {
                                sWriter.WriteLine("cmd update");
                                sWriter.Flush();
                            }
                        }
                    }

				}
				catch (ArgumentNullException ane)
				{
					Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
				}
				catch (SocketException se)
				{
					Console.WriteLine("SocketException : {0}", se.ToString());
				}
				catch (Exception e)
				{
					Console.WriteLine("Unexpected exception : {0}", e.ToString());
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
	}
}