using System;
using System.Collections.Generic;
using System.Text;

using SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Snake_Game
{
    class Snake
    {
        private RectangleShape pixel = new RectangleShape();
        private Vector2f[] PixelPositions = new Vector2f[Config.MAX_LENGTH_OF_SNAKE];
        private int CurrentDirection;
        private int OrderedDirection;
        private int length;
        private int speed;
        private RenderWindow window;
        
        public Snake(ref RenderWindow window,int length=3, int speed=1)
        {
            // initialising private datamembers using constructor
            this.window = window;
            this.length = length;
            this.CurrentDirection = Config.RIGHT;
            this.OrderedDirection = Config.NOT_DEFINE;
            this.speed = speed;
            this.pixel.Size = new Vector2f(Config.PIXEL_WIDTH, Config.PIXEL_HEIGHT);
            // initializing snake head position over window
            this.PixelPositions[0].X = 100;
            this.PixelPositions[0].Y = 300;
            // initializing snake body position over window
            for (int i=1; i<length; i++)
            {
                this.PixelPositions[i].X = this.PixelPositions[0].X - 20 * i;
                this.PixelPositions[i].Y = this.PixelPositions[0].Y;
            }
        }

        public void draw()
        {
            // drawing snake body over window
            for (int i = 0; i < this.length; i++)
            {
                this.PixelPositions[i].X = ( this.PixelPositions[i].X + Config.SCREEN_WIDTH ) % Config.SCREEN_WIDTH;
                this.PixelPositions[i].Y = ( this.PixelPositions[i].Y + Config.SCREEN_HEIGHT ) % Config.SCREEN_HEIGHT;
                this.pixel.Position = this.PixelPositions[i];
                this.pixel.FillColor = Color.White;
                this.window.Draw(pixel);
            }
        }

        public void changeDirection(int direction)
        {
            this.OrderedDirection = direction;
        }

        public void move()
        {
            Vector2f PositionOfHead = new Vector2f();
            if ( this.CurrentDirection == Config.LEFT)
            {
                if ( this.OrderedDirection == Config.UP)
                {
                    PositionOfHead.Y = PixelPositions[0].Y - this.speed;
                    PositionOfHead.X = PixelPositions[0].X;
                    this.CurrentDirection = Config.UP;
                }
                if ( this.OrderedDirection == Config.DOWN)
                {
                    PositionOfHead.Y = PixelPositions[0].Y + this.speed;
                    PositionOfHead.X = PixelPositions[0].X;
                    this.CurrentDirection = Config.DOWN;
                }
                if ( this.OrderedDirection == Config.LEFT)
                {
                    PositionOfHead.Y = PixelPositions[0].Y;
                    PositionOfHead.X = PixelPositions[0].X - this.speed;
                    this.CurrentDirection = Config.LEFT;
                }
                if ( this.OrderedDirection == Config.NOT_DEFINE || this.OrderedDirection == Config.RIGHT)
                {
                    PositionOfHead.X = PixelPositions[0].X - this.speed;
                    PositionOfHead.Y = PixelPositions[0].Y;
                }
            }

			if ( this.CurrentDirection == Config.RIGHT)
			{
				if ( this.OrderedDirection == Config.UP )
				{
					PositionOfHead.Y = this.PixelPositions[0].Y - this.speed;
					PositionOfHead.X = this.PixelPositions[0].X;
					this.CurrentDirection = Config.UP;
				}
				if ( this.OrderedDirection == Config.DOWN )
				{
					PositionOfHead.Y = this.PixelPositions[0].Y + this.speed;
					PositionOfHead.X = this.PixelPositions[0].X;
					this.CurrentDirection = Config.DOWN;
				}
				if ( this.OrderedDirection == Config.RIGHT)
				{
					PositionOfHead.Y = this.PixelPositions[0].Y;
					PositionOfHead.X = this.PixelPositions[0].X + this.speed;
					this.CurrentDirection = Config.RIGHT;
				}
				if ( this.OrderedDirection == Config.NOT_DEFINE || this.OrderedDirection == Config.LEFT)
				{
					PositionOfHead.X = this.PixelPositions[0].X + this.speed;
					PositionOfHead.Y = this.PixelPositions[0].Y;
				}
			}

			if ( this.CurrentDirection == Config.DOWN )
			{
				if ( this.OrderedDirection == Config.RIGHT )
				{
					PositionOfHead.Y = this.PixelPositions[0].Y;
					PositionOfHead.X = this.PixelPositions[0].X + this.speed;
					this.CurrentDirection = Config.RIGHT;
				}
				if ( this.OrderedDirection == Config.LEFT )
				{
					PositionOfHead.Y = this.PixelPositions[0].Y;
					PositionOfHead.X = this.PixelPositions[0].X - speed;
					this.CurrentDirection = Config.LEFT;
				}
				if ( this.OrderedDirection == Config.DOWN )
				{
					PositionOfHead.Y = this.PixelPositions[0].Y + this.speed;
					PositionOfHead.X = this.PixelPositions[0].X;
					this.CurrentDirection = Config.DOWN;
				}
				if ( this.OrderedDirection == Config.NOT_DEFINE || this.OrderedDirection == Config.UP )
				{
					PositionOfHead.X = this.PixelPositions[0].X;
					PositionOfHead.Y = this.PixelPositions[0].Y + this.speed;
				}
			}

			if ( this.CurrentDirection == Config.UP )
			{
				if ( this.OrderedDirection == Config.UP)
				{
					PositionOfHead.Y = this.PixelPositions[0].Y - this.speed;
					PositionOfHead.X = this.PixelPositions[0].X;
					this.CurrentDirection = Config.UP;
				}
				if ( this.OrderedDirection == Config.LEFT )
				{
					PositionOfHead.Y = this.PixelPositions[0].Y;
					PositionOfHead.X = this.PixelPositions[0].X - this.speed;
					this.CurrentDirection = Config.LEFT;
				}
				if ( this.OrderedDirection == Config.RIGHT )
				{
					PositionOfHead.Y = this.PixelPositions[0].Y;
					PositionOfHead.X = this.PixelPositions[0].X + this.speed;
					this.CurrentDirection = Config.RIGHT;
				}
				if ( this.OrderedDirection == Config.NOT_DEFINE || this.OrderedDirection == Config.DOWN )
				{
					PositionOfHead.X = this.PixelPositions[0].X;
					PositionOfHead.Y = this.PixelPositions[0].Y - this.speed;
				}
			}

			this.OrderedDirection = Config.NOT_DEFINE;
			for (int i = this.length - 1; i > 0; i--)
			{
				this.PixelPositions[i] = this.PixelPositions[i - 1];
			}
			this.PixelPositions[0] = PositionOfHead;

		}
    }
}
