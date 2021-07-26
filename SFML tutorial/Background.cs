using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    class Background
    {
        private Texture textureBack;
        private Sprite spriteBack;
        private Vector2f positionBack;

        private Texture textureBackOne;
        private Sprite spriteBackOne;
        private Vector2f positionBackOne;

        private Texture textureBackTwo;
        private Sprite spriteBackTwo;
        private Vector2f positionBackTwo;


        public Background()
        {
            textureBack = new Texture("landscape/cielo.png");
            spriteBack = new Sprite(textureBack);
            spriteBack.Scale = new Vector2f(1.0f, 1.0f);
            positionBack = new Vector2f(0.0f, 0.0f);
            spriteBack.Position = positionBack;

            textureBackOne = new Texture("landscape/desierto2.png");
            spriteBackOne = new Sprite(textureBackOne);
            spriteBackOne.Scale = new Vector2f(1.0f, 1.0f);
            positionBackOne = new Vector2f(0.0f, 0.0f);
            spriteBackOne.Position = positionBackOne;

            textureBackTwo = new Texture("landscape/desierto3.png");
            spriteBackTwo = new Sprite(textureBackTwo);
            spriteBackTwo.Scale = new Vector2f(1.0f, 1.0f);
            positionBackTwo = new Vector2f(0.0f, 0.0f);
            spriteBackTwo.Position = positionBackTwo;

        }

        public void Update()
        {
            spriteBack.Position = positionBack;
            spriteBackOne.Position = positionBack;
            spriteBackTwo.Position = positionBack;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(spriteBack);
            window.Draw(spriteBackOne);
            window.Draw(spriteBackTwo);
        }
    }
}
