using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_tutorial
{
    class Gameplay
    {
        private Background background;
        private Player player;
        private Vector2f initialPlayerPosition = new Vector2f(0.5f,0.5f);

        public Gameplay()
        {
            background = new Background();
            player = new Player(initialPlayerPosition, "Sprites/reaperok01.png", 4, 3);
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
