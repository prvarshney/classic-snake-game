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
        
        public Snake(ref RenderWindow window,int length=5, int speed=1)
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
                Console.WriteLine(this.PixelPositions[i]);
                this.pixel.FillColor = Color.White;
                this.window.Draw(pixel);
            }
        }
    }
}
