using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SFML_tutorial
{
    class Player : GameObjectBase, IColisionable
    {
        private float speed;
        private List<Shoot> shoots;
        private IntRect frameRect;
        private int sheetColumns;
        private int sheetRow;
        private Clock frameTimer;
        private int currentFrame = 0;
        private float animationTime = 1f;
        private Clock timerAnimation;

        private string name;
        private int life;
        private int maxLife;
        private int mana;
        private int maxMana;


        public Player(Vector2f position, string spriteSheetPath, int sheetColumns, int sheetRow, string name, int maxLife, int maxMana) : base()
        {
            
            currentPosition = position;
            this.sheetColumns = sheetColumns;
            this.sheetRow = sheetRow;
            texture = new Texture(spriteSheetPath);
            frameRect = new IntRect(0, 0, (int)texture.Size.X / sheetColumns, (int)texture.Size.Y / sheetRow);
            sprite = new Sprite(texture, frameRect);
            sprite.Scale = new Vector2f(0.8f, 0.8f);
            speed = 450.0f;
            shoots = new List<Shoot>();
            frameTimer = new Clock();
            timerAnimation = new Clock();
            CollisionManager.GetInstance().AddToCollisionManager(this);

            this.name = name;
            this.maxLife = maxLife;
            this.life = maxLife;
            this.maxMana = maxMana;
            this.mana = maxMana;
        }

        public override void Update()
        {
            UpdateAnimation();
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

        private void UpdateAnimation()
        {
            if (frameTimer.ElapsedTime.AsSeconds() > animationTime / sheetColumns)
            {
                currentFrame++;
                if (currentFrame >= sheetColumns)
                {
                    currentFrame = 0;
                }
                frameRect.Left = currentFrame * frameRect.Width;
                sprite.TextureRect = frameRect;
                frameTimer.Restart(); 
   
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

            //currentPosition.Y += 250f * FrameRate.GetDeltaTime();

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

        public void DoDamage(int amount)
        {
            life -= amount;
            if (life <= 0)
            {
                Console.WriteLine("F");
            }
        }

        public bool IsDead()
        {
            return life <= 0;
        }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }

        public void OnColision(IColisionable other)
        {
            
        }

        public string GetTag()
        {
            return "Reaper";
        }

        public override void CheckGarbage()
        {
            List<int> indexToDelet = new List<int>();

            for (int i = 0; i < shoots.Count; i++)
            {
                shoots[i].CheckGarbage();
                if (shoots[i].toDelete)
                {
                    indexToDelet.Add(i);
                }
            }
            for (int i = 0; i < indexToDelet.Count; i++)
            {
                shoots.RemoveAt(i);
            }
        }

        public override void Dispose()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.Dispose();
        }

    }
}
