using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SFML.Audio;
using System.IO;

namespace SFML_tutorial
{
    class Player : GameObjectBase, IColisionable
    {
        private float speed;
        private List<Shoot> shoots;
        private float fireDelay;
        private float fireRate;
        private IntRect frameRect;
        private int sheetColumns;
        private int sheetRow;
        private Clock frameTimer;
        private int currentFrame = 0;
        private float animationTime = 1f;
        private Clock timerAnimation;
        private Vector2f fireRange;
        private float damageDelay;
        private float damageRate;


        private string name;
        private int life;
        private int maxLife;
        private int mana;
        private int maxMana;
        private Sound sound;

        public Player(Vector2f position, string spriteSheetPath, int sheetColumns, int sheetRow, string name, int maxLife, int minMana, int maxMana) : base()
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
            fireRate = 0.2f;
            fireDelay = 0.2f;
            fireRange = new Vector2f(1300.0f, 0.0f);
            damageDelay = 4.0f;
            damageRate = 4.0f;

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

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && fireDelay >= fireRate)
            {
               
                Vector2f spawnPosition = currentPosition;
                spawnPosition.X += (texture.Size.X * sprite.Scale.X) / 5f;
                spawnPosition.Y += (texture.Size.Y * sprite.Scale.Y)/ 10f;
                shoots.Add(new Shoot(spawnPosition));
                SoundBuffer soundBuffer = new SoundBuffer("Audio" + Path.DirectorySeparatorChar + "sound" + Path.DirectorySeparatorChar + "master-fx-disparo.wav");
                sound = new Sound(soundBuffer);
                sound.Play();
                fireDelay = 0.0f;
            }
            
            fireDelay += FrameRate.GetDeltaTime();

        }

        private void DeletAllShoots()
        {
            List<int> indexToDelet = new List<int>();

            for (int i = 0; i < shoots.Count; i++)
            {
                shoots[i].Update();

                if (shoots[i].GetPosition().X > currentPosition.X + fireRange.X)
                {
                    indexToDelet.Add(i);
                
                }

            }

            for (int i = indexToDelet.Count - 1; i >= 0; i--)
            {
                shoots[i].DisposeNow();
                shoots.RemoveAt(i);
            }
        }


        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }

        public void OnColision(IColisionable other)
        {
            if (other is InvisibleBottomWall || other is InvisibleTopWall || other is invisibleLimitLeft || other is InvisibleLimitRight)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    currentPosition.Y -= speed * FrameRate.GetDeltaTime();
                    if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                    {
                        currentPosition.X += speed * FrameRate.GetDeltaTime();
                    }
                    else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    {
                        currentPosition.X -= speed * FrameRate.GetDeltaTime();
                    }
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                {
                    currentPosition.Y += speed * FrameRate.GetDeltaTime();
                    if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                    {
                        currentPosition.X += speed * FrameRate.GetDeltaTime();
                    }
                    else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    {
                        currentPosition.X -= speed * FrameRate.GetDeltaTime();
                    }
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                {
                    currentPosition.X += speed * FrameRate.GetDeltaTime();

                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                {
                    currentPosition.X -= speed * FrameRate.GetDeltaTime();
                }
            }

            if(other is Enemy)
            {
                if(damageDelay >= damageRate)
                {

                    playerDoDamage(Enemy.enemyDamage(200));
                    damageDelay = 0.0f;
                }
                damageDelay += FrameRate.GetDeltaTime();
            }

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
            if (toDelete == true)
            {
                DisposeNow();
            }
            base.CheckGarbage();
        }


        public override void DisposeNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.DisposeNow();
        }

        public void playerDoDamage(int amount)
        {
            life -= amount;
            IsDead();

        }

        public bool IsDead()
        {
            if (life <= 0)
            {
                //DisposeNow();
                LateDispose();
            }

            return life <= 0;
        }
    }
}
