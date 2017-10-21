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

		/// <summary>
		/// generates a response to the client based on the incoming data and sends updates to the client
		/// </summary>
		/// <param name="requestData">analysed data from the request class</param>
		/// <param name="sWriter">stream writer</param>
		/// <param name="client">tcp client</param>
		/// <param name="share">thread share object with updated game information</param>
		public Response(string requestData, StreamWriter sWriter, TcpClient client, ThreadShareObject share)
		{
			//splits incoming data
			if (requestData.Contains(pwd) || requestData.Contains(cmd))
			{
				splitData = requestData.Split(' ');
				command = splitData[0];
				content = splitData[1];
			}

			//response to the transmitted password
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

			//response to the transmitted command
			else if (command == cmd)
			{
				if (content == "accepted")
				{
					sWriter.WriteLine("cmd accepted");
					sWriter.Flush();
					UpdateGame(sWriter, share);
				}

				else if (content == "error")
				{
					sWriter.WriteLine("cmd rejected");
					sWriter.Flush();
					UpdateGame(sWriter, share);
				}

				else if (content == "update")
				{
					UpdateGame(sWriter, share);
				}
			}
		}

		/// <summary>
		/// sends the game informations to the client, information passed via the thread share object
		/// </summary>
		/// <param name="sWriter">streamwriter</param>
		/// <param name="share">thread share object for the needed informations</param>
		private void UpdateGame(StreamWriter sWriter, ThreadShareObject share)
		{
			sWriter.WriteLine("game p1 " + share.P1posX.ToString() + " " + share.P1posY.ToString());
			sWriter.WriteLine("game p2 " + share.P2posX.ToString() + " " + share.P2posY.ToString());
			sWriter.WriteLine("game ball " + share.BallPosX.ToString() + " " + share.BallPosY.ToString());
			sWriter.WriteLine("game scoreP1 " + share.ScoreP1.ToString());
			sWriter.WriteLine("game scoreP2 " + share.ScoreP2.ToString());
			sWriter.Flush();
		}
	}
}
