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
	class UpdateClient
	{
		public UpdateClient(StreamWriter sWriter, Vector2 posP1, Vector2 posP2, Vector2 posBall, int scoreP1, int scoreP2)
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
	}
}
