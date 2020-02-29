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
        // this method destroys the window, whenever it gets called
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
        static void Main(string[] args)
        {
            // creating game window
            RenderWindow window = new RenderWindow(new VideoMode(Config.SCREEN_WIDTH,Config.SCREEN_HEIGHT),"Snake Game");   // creating window object
            window.SetFramerateLimit(Config.FRAME_RATE);                // setting fps limit

            window.Closed += new EventHandler(OnClose);     // registering OnClose function as a callback function
                                                            // whenever window.Closed event occurs
           
            // starting game loop, the game window is open till any closing event doesn't occurs in event stack
            while (window.IsOpen)
            {
                // processing events that occured after window gets opened
                window.DispatchEvents();
      
                window.Clear(Color.Black);
                
                window.Display();
            }
        }
    }
}
