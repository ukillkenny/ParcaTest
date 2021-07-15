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
        private Texture texture;
        private Sprite sprite;
        private Vector2f position;
       

        public Background()
        {
            texture = new Texture("Sprites/background.png");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(1.0f, 1.0f);
            position = new Vector2f(0.0f, 0.0f);
            sprite.Position = position;
        }

        public void Update()
        {
            sprite.Position = position;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
    }
}
