using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pong
{
    /// <summary>
    /// class to share information between the threads(game and server/client) via getter/setter
    /// it is accessible from the game and the server/client
    /// stores the informations regarding players/ball/score
    /// </summary>
    public class ThreadShareObject
    {
        GameState state;
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
        public bool upKey;
        public bool downKey;

        public bool PwdAccepted
        {
            get { return pwdAccepted; }
            set { pwdAccepted = value; }
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

        public bool UpKey
        {
            get { return upKey; }
            set { upKey = value; }
        }

        public bool DownKey
        {
            get { return downKey; }
            set { downKey = value; }
        }

        public GameState State
        {
            get { return state; }
            set { state = value; }
        }

		public ThreadShareObject()
		{
			p1posX = 0;
			p1posY = 0;
			p2posX = 0;
			p2posY = 0;
			ballPosX = 0;
			ballPosY = 0;
			scoreP1 = 0;
			scoreP2 = 0;
			up = false;
			down = false;
			pwdAccepted = false;
		}
	}
}