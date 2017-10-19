using System;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;

namespace Pong
{

	class SocketServer
	{
		private TcpListener _server;
		private Boolean _isRunning;
		private Request request;
		private Response respone;
		private string responseData;
		private Vector2 p1pos;
		private Vector2 p2pos;
		private Vector2 ballPos;
		private int scoreP1;
		private int scoreP2;
		private int port = 11000;
		ThreadShareObject shareObject;

		public Vector2 P1pos
		{
			get { return p1pos; }
			set { p1pos = value; }
		}

		public Vector2 P2pos
		{
			get { return p2pos; }
			set { p2pos = value; }
		}

		public Vector2 BallPos
		{
			get { return ballPos; }
			set { ballPos = value; }
		}

		public int ScoreP1
		{
			get { return scoreP1; }
			set { scoreP1 = value; }
		}

		public int ScoreP2
		{
			get { return scoreP2; }
			set { scoreP2 = value; }
		}

		public SocketServer(ThreadShareObject share)
		{
			shareObject = share;
			_server = new TcpListener(IPAddress.Any, port);
			_server.Start();

			_isRunning = true;

			LoopClients();
		}

		public void LoopClients()
		{
			while (_isRunning)
			{
				// wait for client connection
				TcpClient newClient = _server.AcceptTcpClient();

				// client found.
				// create a thread to handle communication
				Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
				t.Start(newClient);
			}
		}

		public void HandleClient(object obj)
		{
			// retrieve client from parameter passed to thread
			TcpClient client = (TcpClient)obj;

			// sets two streams
			StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
			StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
			// you could use the NetworkStream to read and write, 
			// but there is no forcing flush, even when requested

			Boolean bClientConnected = true;
			String sData = null;

			while (bClientConnected)
			{
				// reads from stream
				sData = sReader.ReadLine();
				Console.WriteLine("Client: " + sData);
				Request request = new Request();
				string requestData = request.RequestData(sData, shareObject);
				Response response = new Response(requestData, sWriter, client, shareObject);
				//shareObject.Up = false;
				//shareObject.Down = false;
			}
		}
	}
}