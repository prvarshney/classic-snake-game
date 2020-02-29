using System;
using System.Collections.Generic;
using System.Text;

using SFML;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace Snake_Game
{
    class SnakeFood
    {
        private Vector2f PositionOfFood;        // 2D vector to store the random position of snake food
        private RectangleShape Pixel = new RectangleShape();    // an elementary box to be plotted as pixel
        public void RandomizeFoodPosition()
        {
            Random RandomInt = new Random();
            PositionOfFood.X = RandomInt.Next(20, (int)Config.SCREEN_WIDTH - 20);
            PositionOfFood.Y = RandomInt.Next(20, (int)Config.SCREEN_HEIGHT - 20);
        }
        public SnakeFood()      // constructor of this class
        {
            Pixel.Size = new Vector2f(Config.PIXEL_WIDTH, Config.PIXEL_HEIGHT);
            RandomizeFoodPosition();
        }
        public void Draw(ref RenderWindow window)
        {
            Pixel.Position = PositionOfFood;
            window.Draw(Pixel);
        }
    }
}
