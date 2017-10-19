using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    /// <summary>
    /// Every input comming from client.
    /// </summary>
    class ClientPlayer
    {
        string pwd = "pwd";
		string cmd = "cmd";
		string rData = "cmd accepted";
		string eData = "cmd error";
		string identifier;
		private string content;

		private string[] splitData;

        string inputPwd;

		public string RequestData(string sData, ThreadShareObject share)
		{
            if (ClientConnectionUp == true)
            {
                Console.WriteLine("Enter password to connect a game: " + inputPwd);

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
			 if (identifier == cmd)
			{
				//client sent up command, moves the player object up
				if (content == "up")
				{
					share.Up = true;
					rData = "cmd accepted";
				}
				//client sent down command, moces the player object down
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
