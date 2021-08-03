using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    class gameOver
    {
        private Texture textureBack;
        private Sprite spriteBack;
        private Vector2f positionBack;
        //private float backSpeed;

        public gameOver()
        {
            textureBack = new Texture("Sprites/game-over.png");
            spriteBack = new Sprite(textureBack);
            spriteBack.Scale = new Vector2f(1.0f, 1.0f);
            positionBack = new Vector2f(0.0f, 0.0f);
            spriteBack.Position = positionBack;
        }

        public bool Update()
        {
            spriteBack.Position = positionBack;

            return true;
            // BackgroundMovement();
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(spriteBack);

        }
    }
}
