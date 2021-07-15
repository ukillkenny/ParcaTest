using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace SFML_tutorial
{
    class Gameplay
    {
        private Background background;
        private Player player;

        public Gameplay()
        {
            background = new Background();
            player = new Player();
        }

        public void Update()
        {
            background.Update();
            player.Update();

        }

        public void Draw(RenderWindow window)
        {
            background.Draw(window);
            player.Draw(window);
        }
    }
}
