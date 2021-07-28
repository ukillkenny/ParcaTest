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
        private Vector2f initialPlayerPosition = new Vector2f(1.0f,750.0f);

        private Rock rock;
        private RockTwo rockTwo;
        private InvisibleBottomWall invisibleBottomWall;
        private InvisibleTopWall invisibleTopWall;
        private invisibleLimitLeft invisibleLimitLeft;
        private InvisibleLimitRight InvisibleLimitRight;

        public Gameplay()
        {
            background = new Background();
            player = new Player(initialPlayerPosition, "Sprites/reaperok01.png", 4, 3, "Reaper", 800, 120);
            rock = new Rock();
            rockTwo = new RockTwo();

            invisibleBottomWall = new InvisibleBottomWall(new Vector2f(0.1f, 1080.0f), new Vector2f(6000.0f, 0.1f));
            invisibleTopWall = new InvisibleTopWall(new Vector2f(0.1f, 680.0f), new Vector2f(6000.0f, 0.1f));
            invisibleLimitLeft = new invisibleLimitLeft(new Vector2f(0.1f, 0.1f), new Vector2f(0.1f, 1080.0f));
            InvisibleLimitRight = new InvisibleLimitRight(new Vector2f(6000.0f, 0.1f), new Vector2f(0.1f, 1080.0f));
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
