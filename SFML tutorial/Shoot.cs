using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    class Shoot
    {
        private Texture texture;
        private Sprite sprite;
        private float ShootSpeed;
        public Shoot(Vector2f position)
        {
            texture = new Texture("Sprites/shoot.png");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(1.0f, 1.0f);
            sprite.Position = position;
            ShootSpeed = 450.0f;

        }

        public void Update()
        {
            sprite.Position += new Vector2f( ShootSpeed * (1.0f / (float)Game.FRAMERATE_LIMIT), 0.0f);           

        }

        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }

    }
}
