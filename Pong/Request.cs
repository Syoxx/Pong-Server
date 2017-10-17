using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;

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
		private string command;
		string passwd;
		string password = "pongPwd";
		string correct = "pwd correct";
		string incorrect = "pwd incorrect";
		private string[] splitData;

		public string RequestData(string sData)
		{
			splitData = sData.Split();
			identifier = splitData[1];
			content = splitData[2];

			//server receives a password from the client
			if (identifier == pwd)
			{
				if (content == password)
				{
					return correct;
				}

				return incorrect;
			}

			//server receives a cmd from the client
			else if (identifier == cmd)
			{
				switch(content)
				{
					//client sent up command, moves the player object up
					case "up":
						SendKe
						break;
					//client sent down command, moces the player object down
					case "down":
						break;
				}
				return rData;
			}

			return eData;
		}
	}
}
