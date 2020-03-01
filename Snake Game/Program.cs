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

            // creating resources object for game manipulation
            MainMenu menu = new MainMenu(ref window);
            Snake snake = new Snake(ref window);
            SnakeFood food = new SnakeFood(ref window);
            CollisionDetection collision = new CollisionDetection();

            // ActivityNumber tells which activity is currently need to draw
            // for example : 0 -> MainMenu, 1 -> StartGame, 2 -> HighScore, 3 -> Quit
            int ActivityNumber = 0;
            uint Frame_Rate = 60;
            bool FirstRun = true;

            // starting game loop, the game window is open till any closing event doesn't occurs in event stack
            while (window.IsOpen)
            {
                // processing events that occured after window gets opened
                window.DispatchEvents();
                window.Clear(Color.Black);


                // 
                switch ( ActivityNumber)
                {
                    case 0:
                        // checking keypresses
                        window.SetFramerateLimit(Config.FRAME_RATE);
                        if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) menu.ChangeSelectionText(-1);
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) menu.ChangeSelectionText(1);
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Return)) ActivityNumber = menu.CurrentSelection + 1;
                        // drawing menu over window
                        menu.draw();
                        FirstRun = true;
                        break;
                    case 1:
                        // starting snake game
                        window.SetFramerateLimit(Frame_Rate);
                        window.Clear(Color.Black);
                        if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) snake.ChangeDirection(Config.UP);
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) snake.ChangeDirection(Config.DOWN);
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) snake.ChangeDirection(Config.LEFT);
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) snake.ChangeDirection(Config.RIGHT);
                        else if (Keyboard.IsKeyPressed(Keyboard.Key.Escape)) ActivityNumber = 0;

                        if (collision.IsCollide(food.GetPosition(), snake.getPositionOfHead()))
                        {
                            snake.ChangeLength(10);
                            Frame_Rate += 10;
                            Console.WriteLine(Frame_Rate);
                            food.RandomizeFoodPosition();
                            window.SetFramerateLimit(Frame_Rate);
                        }

                        if (snake.isSnakeEatsItself())
                        {
                            Text GameOver = new Text("Game Over", new Font(Config.ARCADE_CLASSIC_FONT), 150);
                            GameOver.Position = new Vector2f(70, Config.SCREEN_HEIGHT / 2 - 150);
                            GameOver.FillColor = Color.Cyan;
                            window.Draw(GameOver);
                            window.Display();
                            System.Threading.Thread.Sleep(2000);
                            ActivityNumber = 0;
                            break;
                        }

                        snake.move();
                        snake.draw();
                        food.Draw();
                        break;
                    case 2:
                        // displaying high score
                        break;
                    case 3:
                        // quitting game window
                        window.Close();
                        break;
                }
                
                window.Display();
            }
        }
    }
}
