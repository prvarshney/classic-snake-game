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
        public void WriteScore(User usr)
        {
            using (StreamWriter ScoreFileWriter = File.AppendText(Config.SCORE_FILE))
            {
                System.Xml.Serialization.XmlSerializer SerializeObj = new System.Xml.Serialization.XmlSerializer(usr.GetType());
                SerializeObj.Serialize(ScoreFileWriter, usr);
            }
            
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

            // font to print scores on scoreboard
            Text txt = new Text("", new Font(Config.HELVETICA_FONT), 30);
            txt.Color = Color.White;
            txt.Position = new Vector2f(Config.SCREEN_WIDTH / 2 - 210, 50);

            // fetching scores from files


            window.Draw(banner);
            window.Draw(section);
        }
    }
}
