using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
	class StreamInClient
	{
		private string rData;
		string pwd = "pwd";
		string cmd = "cmd";
		string game = "game";
		string p1 = "p1";
		string p2 = "p2";
		string ball = "ball";
		string scoreP1 = "scoreP1";
		string scoreP2 = "scoreP2";
		private string[] splitData;
		private string identifier;
		private string p1posX;
		private string p1poxY;

		public string InData(string sData, ThreadShareObject share)
		{
			if (sData.Contains(pwd) || sData.Contains(cmd))
			{
				Console.WriteLine(sData);
				rData = "cmd or password answer";
			}

			//store the values transmitted via game in the thread share object
			else if (sData.Contains(game))
			{
				if (sData.Contains(p1) || sData.Contains(p2) || sData.Contains(ball))
				{
					splitData = sData.Split(' ');
					identifier = splitData[1];
					if (identifier == p1)
					{
						share.P1posX = float.Parse(splitData[2], CultureInfo.InvariantCulture.NumberFormat);
						share.P1posY = float.Parse(splitData[3], CultureInfo.InvariantCulture.NumberFormat);
					}
					else if (identifier == p2)
					{
						share.P2posX = float.Parse(splitData[2], CultureInfo.InvariantCulture.NumberFormat);
						share.P2posY = float.Parse(splitData[3], CultureInfo.InvariantCulture.NumberFormat);
					}
					else if (identifier == ball)
					{
						share.BallPosX = float.Parse(splitData[2], CultureInfo.InvariantCulture.NumberFormat);
						share.BallPosY = float.Parse(splitData[3], CultureInfo.InvariantCulture.NumberFormat);
					}
				}
				else if (sData.Contains(scoreP1) || sData.Contains(scoreP2))
				{
					splitData = sData.Split(' ');
					identifier = splitData[1];
					if (identifier == scoreP1)
					{
						share.ScoreP1 = int.Parse(splitData[2], CultureInfo.InvariantCulture.NumberFormat);
					}
					else if (identifier == scoreP2)
					{
						share.ScoreP2 = int.Parse(splitData[2], CultureInfo.InvariantCulture.NumberFormat);
					}
				}
				rData = "game update";
			}
			return rData;
		}
	}
}
