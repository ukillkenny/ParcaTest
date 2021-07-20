using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SFML_tutorial
{
    class Player : GameObjectBase
    {
        private float speed;
        private List<Shoot> shoots;
        //private Clock clock;
        //private Time shootingTime;
        //private float deltaShootingTime;
       

        public Player() : base("Sprites/reaperok01.png", new IntRect (0, 0,  300,  300), new Vector2f(5.0f, 0.0f))
        {
          
            sprite.Scale = new Vector2f(1f, 1f);
            speed = 250.0f;
            shoots = new List<Shoot>();

        }

        public override void Update()
        {
            Movement();
            Shooting();
            DeletAllShoots();
            base.Update();
        }

        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
            for (int i = 0; i < shoots.Count; i++)
            {
                shoots[i].Draw(window);
            }

            
        }

        private void Movement()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                currentPosition.X += speed * FrameRate.GetDeltaTime();
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                currentPosition.X -= speed * FrameRate.GetDeltaTime();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                currentPosition.Y -= speed * FrameRate.GetDeltaTime();

            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                currentPosition.Y += speed * FrameRate.GetDeltaTime();

            }

        }

        private void Shooting()
        {
            

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                Vector2f spawnPosition = currentPosition;
                spawnPosition.X += (texture.Size.X * sprite.Scale.X) / 4f;
                spawnPosition.Y += (texture.Size.Y * sprite.Scale.Y)/ 100f;
                shoots.Add(new Shoot(spawnPosition));


            }


        }

        private void DeletAllShoots()
        {
            List<int> indexToDelet = new List<int>();

            for (int i = 0; i < shoots.Count; i++)
            {
                shoots[i].Update();

                if (shoots[i].GetPosition().X > Game.GetWindowSize().X)
                {
                    indexToDelet.Add(i);

                }
            }

            for (int i = indexToDelet.Count - 1; i >= 0; i--)
            {
                shoots[i].Dispose();
                shoots.RemoveAt(i);
            }
        }
       

    }
}
