using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

using SFML;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace Snake_Game
{
    class Score
    {
        private RenderWindow window;

        public Score(ref RenderWindow window)
        {
            this.window = window;
        }
        public void WriteScore(int Score)
        {
            // 4. Updating data to a simple text file
            using (StreamWriter ScoreFile = File.AppendText(Config.SCORE_FILE))
            {
                ScoreFile.WriteLine(Score.ToString());
                ScoreFile.Flush();
            }
        }

        public int[] ReadScore()
        {
            // 2. Reading data from a simple text file
            int[] Scores = new int[10];
            using (StreamReader ScoreFile = new StreamReader(Config.SCORE_FILE))
            {
                for(int i = 0; i<10; i++)
                {
                    string line = ScoreFile.ReadLine();
                    if (line == null) break;
                    Scores[i] = int.Parse(line);
                }
            }
            return Scores;
        }

        public void Draw()
        {
            // ScoreBoard banner
            Text banner = new Text("Score Board", new Font(Config.ARCADE_CLASSIC_FONT), 80);
            banner.Color = Color.Cyan;
            banner.Position = new Vector2f(Config.SCREEN_WIDTH / 2 - 210, 50);

            // section between score board banner and user scores
            RectangleShape section = new RectangleShape(new Vector2f(Config.SCREEN_WIDTH - 180, 2));
            section.Position = new Vector2f(85, 150);
            section.FillColor = Color.Cyan;

            // 8. Use of array(s)
            int[] Scores = new int[10];
            Scores = this.ReadScore();
            
            // 3. Sorting data
            Array.Sort(Scores);
            Array.Reverse(Scores);

            // printing Scores
            Text genericText = new Text("", new Font(Config.HELVETICA_FONT), 20);
            genericText.Color = Color.White;

            // Printing Table Header
            genericText.DisplayedString = "SNO.";
            genericText.Position = new Vector2f(180, 200);
            window.Draw(genericText);

            genericText.DisplayedString = "Score";
            genericText.Position = new Vector2f(580, 200);
            window.Draw(genericText);
            for (int i = 0; i < 5; i++)
            {
                genericText.DisplayedString = (i + 1).ToString();
                genericText.Position = new Vector2f(200, 240+i*40);
                window.Draw(genericText);

                genericText.DisplayedString = Scores[i].ToString();
                genericText.Position = new Vector2f(600, 240 + i * 40);
                window.Draw(genericText);
            }

            window.Draw(banner);
            window.Draw(section);
        }
    }
}
