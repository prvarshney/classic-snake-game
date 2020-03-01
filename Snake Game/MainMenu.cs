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
    // 1. One or Menu from which user can select text
    class MainMenu
    {
        private Text banner;
        private RectangleShape section;
        private Text start;
        private Text HighScore;
        private Text quit;
        private RenderWindow window;
        public int CurrentSelection;

        private void ChangeColorOfSelectedText(int position, Color color, Text.Styles style)
        {
            if(position == 0)
            {
                this.start.Color = color;
                this.start.Style = style;
            }
            if (position == 1)
            {
                this.HighScore.Color = color;
                this.HighScore.Style = style;
            }
            if (position == 2)
            {
                this.quit.Color = color;
                this.quit.Style = style;
            }
        }
        public MainMenu(ref RenderWindow window)
        {
            // main menu banner
            this.banner = new Text("Snake Game", new Font(Config.ARCADE_CLASSIC_FONT), 80);
            this.banner.Color = Color.Cyan;
            this.banner.Position = new Vector2f(Config.SCREEN_WIDTH / 2 - 200, 100);

            // section between main menu banner and other available options
            this.section = new RectangleShape(new Vector2f(Config.SCREEN_WIDTH - 200, 2));
            this.section.Position = new Vector2f(85, 195);
            this.section.FillColor = Color.Cyan;

            // creating options to select like start game, high scores, etc.
            this.start = new Text("Start", new Font(Config.ARCADE_CLASSIC_FONT), 50);
            this.start.Color = Color.Cyan;
            this.start.Position = new Vector2f(Config.SCREEN_WIDTH / 2 - 65, 210);

            this.HighScore = new Text("High Score", new Font(Config.ARCADE_CLASSIC_FONT), 50);
            this.HighScore.Color = Color.White;
            this.HighScore.Position = new Vector2f(Config.SCREEN_WIDTH / 2 - 125, 270);

            this.quit = new Text("Quit", new Font(Config.ARCADE_CLASSIC_FONT), 50);
            this.quit.Color = Color.White;
            this.quit.Position = new Vector2f(Config.SCREEN_WIDTH / 2 - 50, 330);

            // referencing to main window object
            this.window = window;

            // referencing to the Start text as currently selected text
            this.CurrentSelection = 0;      // 0 -> start, 1 -> HighScore, 2 -> quit 
        }

        public void ChangeSelectionText(int delta)
        {
            // changing color of previously selected text to white
            ChangeColorOfSelectedText(CurrentSelection, Color.White, Text.Styles.Regular);
            // updating CurrentSelection
            CurrentSelection = (CurrentSelection + delta) % 3;
            CurrentSelection =  (CurrentSelection < 0) ? (3 + CurrentSelection) : CurrentSelection;
            // changing color of currently selected text to Cyan
            ChangeColorOfSelectedText(CurrentSelection, Color.Cyan, Text.Styles.Bold);
        }
        public void draw()
        {
            // drawing objects on window
            window.Draw(this.banner);
            window.Draw(this.section);
            window.Draw(this.start);
            window.Draw(this.HighScore);
            window.Draw(this.quit);
        }
    }
}
