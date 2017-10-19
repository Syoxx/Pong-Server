using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pong
{
	public class ThreadShareObject
	{
		public Vector2 p1pos;
		public Vector2 p2pos;
		public Vector2 ballPos;
		public float p1posX;
		public float p1posY;
		public float p2posX;
		public float p2posY;
		public float ballPosX;
		public float ballPosY;
		public int scoreP1;
		public int scoreP2;
		public bool up;
		public bool down;
		public bool pwdAccepted;

		public bool PwdAccepted
		{
			get { return pwdAccepted; }
			set { pwdAccepted = value; }
		}

		public Vector2 P1pos
		{
			get { return p1pos; }
			set { p1pos = value; }
		}

		public float P1posX
		{
			get { return p1posX; }
			set { p1posX = value; }
		}

		public float P1posY
		{
			get { return p1posY; }
			set { p1posY = value; }
		}

		public Vector2 P2pos
		{
			get { return p2pos; }
			set { p2pos = value; }
		}

		public float P2posX
		{
			get { return p2posX; }
			set { p2posX = value; }
		}

		public float P2posY
		{
			get { return p2posY; }
			set { p2posY = value; }
		}

		public Vector2 BallPos
		{
			get { return ballPos; }
			set { ballPos = value; }
		}

		public float BallPosX
		{
			get { return ballPosX; }
			set { ballPosX = value; }
		}

		public float BallPosY
		{
			get { return ballPosY; }
			set { ballPosY = value; }
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

		public bool Up
		{
			get { return up; }
			set { up = value; }
		}

		public bool Down
		{
			get { return down; }
			set { down = value; }
		}

		public ThreadShareObject()
		{
			p1pos = new Vector2(0, 0);
			p2pos = new Vector2(0, 0);
			ballPos = new Vector2(0, 0);
			scoreP1 = 0;
			scoreP2 = 0;
			up = false;
			down = false;
			pwdAccepted = false;
		}
	}
}