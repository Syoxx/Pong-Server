using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
	class Request
	{
		string pwd = "pwd";
		string cmd = "cmd";
		string rData = "cmd accepted";
		string eData = "cmd error";
		string identifier;
		private string content;
		string password = "pongPwd";
		string correct = "pwd correct";
		string incorrect = "pwd incorrect";
		private string[] splitData;

		/// <summary>
		/// analyses the data from the client and updates the thread share object accordingly
		/// </summary>
		/// <param name="sData">stream data</param>
		/// <param name="share">thread share object to give revceived informations to the game</param>
		/// <returns></returns>
		public string RequestData(string sData, ThreadShareObject share)
		{
			if (sData.Contains(pwd) || sData.Contains(cmd))
			{
				splitData = sData.Split(' ');
				identifier = splitData[0];
				content = splitData[1];
			}
			//server receives a password from the client
			if (identifier == pwd)
			{
				if (content == password)
				{
					share.PwdAccepted = true;
					return correct;
				}

				return incorrect;
			}

			//server receives a cmd from the client
			else if (identifier == cmd)
			{
				//client sent up command, moves the player object up
				if (content == "up")
				{
					share.Up = true;
					rData = "cmd accepted";
				}
				//client sent down command, moves the player object down
				else if (content == "down")
				{
					//SendKeys.Send(Keys.Down.ToString());
					share.Down = true;
					rData = "cmd accepted";
				}

				else if (content == "update")
				{
					rData = "cmd update";
				}

				else
				{
					rData = "cmd wrong";
				}

				return rData;
			}

			return eData;
		}
	}
}
