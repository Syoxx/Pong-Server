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

		public Response(string requestData, StreamWriter sWriter, TcpClient client, ThreadShareObject share)
		{
			if (requestData.Contains(pwd) || requestData.Contains(cmd))
			{
				splitData = requestData.Split(' ');
				command = splitData[0];
				content = splitData[1];
			}

			if (command == pwd)
			{
				if (content == "correct")
				{
					sWriter.WriteLine("pwd accepted");
					sWriter.Flush();
					Console.WriteLine("Client sent correct Password, resuming");
				}

				else
				{
					sWriter.WriteLine("pwd denied");
					sWriter.Flush();
					client.Close();
					Console.WriteLine("Client sent wrong Password, closing Connection");
				}
			}

			//when a cmd was sent by the client the server sends all game informations back
			else if (command == cmd)
			{
				if (content == "accepted")
				{
					sWriter.WriteLine("cmd accepted");
					sWriter.Flush();
				}

				else if (content == "error")
				{
					sWriter.WriteLine("cmd rejected");
					sWriter.Flush();
				}

				else if (content == "update")
				{
					sWriter.WriteLine("game p1 " + share.P1pos.ToString());
					sWriter.WriteLine("game p2 " + share.P2pos.ToString());
					sWriter.WriteLine("game ball " + share.BallPos.ToString());
					sWriter.WriteLine("game scoreP1 " + share.ScoreP1.ToString());
					sWriter.WriteLine("game scoreP2 " + share.ScoreP2.ToString());
					sWriter.Flush();
				}
			}
		}
	}
}
