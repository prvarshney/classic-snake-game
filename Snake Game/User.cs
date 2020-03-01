using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    public class User
    {
        public string name;
        public int scores;

        public void SetValue(string name, int scores)
        {
            this.name = new string(name);
            this.scores = scores;
        }
    }
}
