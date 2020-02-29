// This game application built using SFML (simple and fast multimedia library).
// This library handles graphics drawing, event listening, music and networking related operations

using System;
using SFML;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;

namespace Snake_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // defining display configurations, this will alter screen dimensions of the game
            uint SCREEN_HEIGHT = 960;
            uint SCREEN_WIDTH = 1280;
            RenderWindow window = new RenderWindow(new VideoMode(SCREEN_WIDTH,SCREEN_HEIGHT),"Snake Game");
            // starting game loop, the game window is open till any closing event doesn't occurs in event stack
            while (window.IsOpen)
            {
                window.Clear(Color.Blue);
                window.Display();
            }
        }
    }
}
