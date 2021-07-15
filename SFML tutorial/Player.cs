using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;


namespace SFML_tutorial
{
    class Player
    {
        private Texture texture;
        private Sprite sprite;
        private Vector2f position;
        private float speed;
        private Shoot shoot;


        public Player()
        {
            texture = new Texture("Sprites/reaper1.png");
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f(0.5f, 0.5f);
            position = new Vector2f(5.0f, 0.0f);
            sprite.Position = position;
            speed = 250.0f;
            

        }

        public void Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                position.X += speed * (1.0f / (float)Game.FRAMERATE_LIMIT);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                position.X -= speed * (1.0f / (float)Game.FRAMERATE_LIMIT);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                position.Y -= speed * (1.0f / (float)Game.FRAMERATE_LIMIT);

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                position.Y += speed * (1.0f / (float)Game.FRAMERATE_LIMIT);

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                shoot = new Shoot(position);                
            }
            if (shoot != null)
            {
                shoot.Update();
            }
            

            sprite.Position = position;
        
        }

        public void Draw(RenderWindow window)
        {
            if (shoot != null)
            {
                shoot.Draw(window);
            }
            
            window.Draw(sprite);
        }

    }
}
