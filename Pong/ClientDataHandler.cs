using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class ClientDataHandler
    {
        string game = "game";
        string p1 = "p1";
        string p2 = "p2";
        string scoreP1 = "scoreP1";
        string scoreP2 = "scoreP2";
        string ball = "ball";


        private string[] splitData;
        string id;
        float vector;
        string p1VecX;
        string p1VecY;
        string p2VecX;
        string p2VecY;
        string ballVecX;
        string ballVecY;
        string scorePlayer1;
        string scorePlayer2;

        string pwdCorrect = "pwd accepted";
        string content;

        public string DataRequest(string scData, ThreadShareObject share)
        {
            if (scData.Contains(pwdCorrect))
            {
                splitData = scData.Split(' ');
                id = splitData[0];
            }

            if (id == pwdCorrect)
            {
                Console.WriteLine("Password correct.");
            }

            if (scData.Contains(game))
            {
                content = splitData[1];

                if (content == "p1")
                {
                    share.p1pos.X = Convert.ToSingle(p1VecX);
                    p1VecX = splitData[2];

                    share.p1pos.Y = Convert.ToSingle(p1VecY);
                    p1VecY = splitData[3];
                }
                
                else if (content == "p2")
                {
                    share.p2pos.X = Convert.ToSingle(p2VecX);
                    p2VecX = splitData[2];

                    share.p2pos.Y = Convert.ToSingle(p2VecY);
                    p2VecY = splitData[3];
                }

                else if (content == "ball")
                {
                    share.ballPos.X = Convert.ToSingle(ballVecX);
                    ballVecX = splitData[2];

                    share.ballPos.X = Convert.ToSingle(ballVecY);
                    ballVecY = splitData[3];
                }

                else if (content == "scoreP1")
                {
                    share.scoreP1 = Convert.ToChar(scorePlayer1); 
                    scorePlayer1 = splitData[2];
                }

                else if (content == "scoreP2")
                {
                    share.scoreP2 = Convert.ToChar(scorePlayer2);
                    scorePlayer2 = splitData[2];
                }
            }



        }
    }
}
