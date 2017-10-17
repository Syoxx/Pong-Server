using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using Microsoft.Xna.Framework;


namespace Pong
{
	class Response
	{
		string pwd = "pwd";
		string cmd = "cmd";
		private string[] splitData;
		private string command;
		private string content;

		public Response(string requestData, StreamWriter sWriter, TcpClient client)
		{
			splitData = requestData.Split();
			command = splitData[1];
			content = splitData[2];

			if (command == pwd)
			{
				if (content == "correct")
				{
					sWriter.WriteLine("pwd accepted");
					Console.WriteLine("Client sent correct Password, resuming");
				}

				else
				{
					sWriter.WriteLine("pwd denied");
					client.Close();
					Console.WriteLine("Client sent wrong Password, closing Connection");
				}
			}

			//when a cmd was sent by the client the server sends all game informations back
			else if (requestData == cmd)
			{
				switch(content)
				{
					case "accepted":
						break;
					case "error":
						break;
				}
			}
		}

		//sends all game Information to the client
		public void SendGameInfo(StreamWriter sWriter, Vector2 posP1, Vector2 posP2, Vector2 posBall, int scoreP1, int scoreP2)
		{
			//player 1 position
			sWriter.WriteLine("game p1 " + posP1.ToString());
			//player 2 position
			sWriter.WriteLine("game p2 " + posP2.ToString());
			//ball position
			sWriter.WriteLine("game ball " + posBall.ToString());
			//ScoreP1
			sWriter.WriteLine("game scoreP1 " + scoreP1.ToString());
			//ScoreP2
			sWriter.WriteLine("game scoreP2 " + scoreP2.ToString());
		}

		//sends an error message to the client
		private void SendError(StreamWriter sWriter)
		{
			sWriter.WriteLine("cmd error");
		}
	}
}
