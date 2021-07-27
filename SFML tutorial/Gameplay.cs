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

        private Rock rock;
        private RockTwo rockTwo;

        public Gameplay()
        {
            background = new Background();
            player = new Player(initialPlayerPosition, "Sprites/reaperok01.png", 4, 3, "Reaper", 800, 120);
            rock = new Rock();
            rockTwo = new RockTwo();
        }

        public void Update()
        {
            background.Update();
            if (player != null)
            {
                player.Update();
            }
           

        }

        public void Draw(RenderWindow window)
        {
            background.Draw(window);
            if (player != null)
            {
                player.Draw(window);
            }
            rock.Draw(window);
            rockTwo.Draw(window);
        }

        public void CheckGarbage()
        {
            if (player != null)
            {
                player.CheckGarbage();

                if (player.toDelete)
                {
                    player = null; 
                }
            }
            
            
        }
    }
}
