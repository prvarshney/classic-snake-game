// this is the configuration file of Snake Game
// alter this to change Screen Dimensions, box dimensions, etc.

using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    class Config
    {
        // defining display configurations, this will alter screen dimensions of the game
        public static uint SCREEN_HEIGHT = 600;
        public static uint SCREEN_WIDTH = 800;
        public static uint FRAME_RATE = 10;
        public static int PIXEL_HEIGHT = 20;
        public static int PIXEL_WIDTH = 20;
        public static int UP = 0;
        public static int LEFT = 1;
        public static int DOWN = 1;
        public static int RIGHT = 3;
        public static int NOT_DEFINE = 4;
        public static int MAX_LENGTH_OF_SNAKE = 500;
        public static string HELVETICA_FONT = "assets/fonts/Helvetica-Bold.ttf";
        public static string PAC_FONT = "assets/fonts/PAC-FONT.TTF";
        public static string ARCADE_CLASSIC_FONT = "assets/fonts/ARCADECLASSIC.TTF";
    }
}
