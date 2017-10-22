﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pong
{
    public class Player
    {
        private PlayerIndex playerInex;
        private Keys upKey;
        private Keys downKey;
		ThreadShareObject shareObject;
		private bool isPlayer;
		private bool isServer;
		private Slider slider;
        private int points;
        private Rectangle endZone;

        public event EventHandler OnLeft; 

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public Slider Slider
        {
            get
            { return slider; }
        }

        public PlayerIndex Index
        {
            get
            { return playerInex; }
        }

        public Player(PlayerIndex playerIndex, Vector2 position, Texture2D texture, Vector2 size, Keys upKey, Keys downKey, ThreadShareObject share, Rectangle endZone, float fieldMinY, float fieldMaxY, bool isPlayer, bool isServer)
        {
            this.playerInex = playerIndex;
            this.slider = new Slider(position, texture, size, fieldMinY, fieldMaxY);
            this.points = 0;
            this.upKey = upKey;
            this.downKey = downKey;
            this.endZone = endZone;
            this.shareObject = share;
			this.isPlayer = isPlayer;
			this.isServer = isServer;
        }

		public Player(PlayerIndex playerIndex, Vector2 position, Texture2D texture, Vector2 size, ThreadShareObject share, Rectangle endZone, float fieldMinY, float fieldMaxY, bool isPlayer, bool isServer)
		{
			this.playerInex = playerIndex;
			this.slider = new Slider(position, texture, size, fieldMinY, fieldMaxY);
			this.points = 0;
			this.shareObject = share;
			this.endZone = endZone;
			this.isPlayer = isPlayer;
			this.isServer = isServer;
		}

		public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            GamePadState padState = GamePad.GetState(playerInex);
            slider.ResetMoveVector();
			if (isPlayer)
			{
				if (state.IsKeyDown(upKey) || padState.ThumbSticks.Left.Y < 0)
				{
					if (padState.ThumbSticks.Left.Y < 0)
						slider.Move(-1, padState.ThumbSticks.Left.Y);
					else
						slider.Move(-1, 1);

					if (!isServer)
					{
						shareObject.UpKey = true;
					}
				}
				if (state.IsKeyDown(downKey) || padState.ThumbSticks.Right.Y > 0)
				{
					if (padState.ThumbSticks.Left.Y > 0)
						slider.Move(1, padState.ThumbSticks.Left.Y);
					else
						slider.Move(1, 1);

					if (!isServer)
					{
						shareObject.DownKey = true;
					}
				}
			}

			else
			{
				if (shareObject.Up)
				{
					if (padState.ThumbSticks.Left.Y < 0)
						slider.Move(-1, padState.ThumbSticks.Left.Y);
					else
						slider.Move(-1, 1);

					shareObject.Up = false;
				}
				if (shareObject.Down)
				{
					if (padState.ThumbSticks.Left.Y > 0)
						slider.Move(1, padState.ThumbSticks.Left.Y);
					else
						slider.Move(1, 1);

					shareObject.Down = false;
				}
			}

            slider.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            slider.Draw(spriteBatch);
        }

        /// <summary>
        /// Checks Collision between ball and player slider
        /// </summary>
        /// <param name="ball">Ball ball</param>
        public void Collision(Ball ball)
        {
            if (ball.CollisionBox.Intersects(slider.CollisionBox))
            {
                float width = ball.MoveVector.X > 0 ? -ball.CollisionBox.Width : ball.CollisionBox.Width; //prevents the ball from stucking in a slider

                ball.Position = new Vector2(slider.CollisionBox.X + width, ball.Position.Y);
                Vector2 sideVec = slider.GetSideVector(ball.CollisionBox);
                ball.ChangeMoveVector((ball.MoveVector * -1) + (slider.MoveVector / 2) + sideVec);
            }

            if (ball.CollisionBox.Intersects(endZone)) //ball out of field
            {
                OnLeft?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
