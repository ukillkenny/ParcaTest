using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SFML_tutorial
{
    class Enemy : GameObjectBase , IColisionable
    {
        private string name;
        private int life;
        private int maxLife;

        private float speed;
        private IntRect frameRect;
        private int sheetColumns;
        private int sheetRow;
        private Clock frameTimer;
        private int currentFrame = 0;
        private float animationTime = 1f;
        private Clock timerAnimation;
        private Clock moveAnimationTime;
        private float moveTime = 1f;

        //private Vector2f initialEnemyArea;
        //private Clock enemyMoveTimer;

        private int MinAttack;
        private int MaxAttack;
        public Enemy(Vector2f setEnemyPosition, string spriteSheetPath, int sheetColumns, int sheetRow, string name, int maxLife, int minAttack, int maxAttack) : base()
        {
            Random random = new Random();
            setEnemyPosition = new Vector2f((float)random.Next(1000, 6000), ((float)random.Next(720, 760)));
            //setEnemyPosition = new Vector2f(1000.0f, 750.0f);
            currentPosition = setEnemyPosition;
            this.sheetColumns = sheetColumns;
            this.sheetRow = sheetRow;
            texture = new Texture(spriteSheetPath);
            frameRect = new IntRect(0, 0, (int)texture.Size.X / sheetColumns, (int)texture.Size.Y / sheetRow);
            sprite = new Sprite(texture, frameRect);
            sprite.Scale = new Vector2f(0.8f, 0.8f);
            speed = 150.0f;
            frameTimer = new Clock();
            timerAnimation = new Clock();
            moveAnimationTime = new Clock();
            CollisionManager.GetInstance().AddToCollisionManager(this);

            this.name = name;
            this.maxLife = maxLife;
            this.life = maxLife;
            this.MinAttack = minAttack;
            this.MaxAttack = maxAttack;

        }

       // public Enemy(Vector2f position, string spriteSheetPath, int sheetColumns, int sheetRow, string name, int maxLife, int minAttack, int maxAttack) : base()
       // {
       //     currentPosition = position;
       //     this.sheetColumns = sheetColumns;
       //     this.sheetRow = sheetRow;
       //     texture = new Texture(spriteSheetPath);
       //     frameRect = new IntRect(0, 0, (int)texture.Size.X / sheetColumns, (int)texture.Size.Y / sheetRow);
       //     sprite = new Sprite(texture, frameRect);
       //     sprite.Scale = new Vector2f(0.8f, 0.8f);
       //     speed = 450.0f;
       //     frameTimer = new Clock();
       //     timerAnimation = new Clock();
       //     CollisionManager.GetInstance().AddToCollisionManager(this);
       //
       //     this.name = name;
       //     this.maxLife = maxLife;
       //     this.life = maxLife;
       //     this.MinAttack = minAttack;
       //     this.MaxAttack = maxAttack;
       //
       // }

        public override void Update()
        {
            UpdateAnimation();
            UpdateEnemyArea();
            base.Update();
        }

        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
            
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

        public void UpdateEnemyArea()
        {
            currentPosition.X -= speed * FrameRate.GetDeltaTime();
            //if (moveAnimationTime.ElapsedTime.AsSeconds() > moveTime)
            //{
            //    currentPosition.X -= speed * FrameRate.GetDeltaTime();
            //}
            //moveAnimationTime.Restart();
        }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }

        public string GetTag()
        {
            return "Dementor";
        }

        public void OnColision(IColisionable other)
        {
            if (other is Shoot)
            {

                DoDamage(Shoot.ShootDamage(200));
                
            }
            
        }

        public override void DisposeNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.DisposeNow();
        }

        public void DoDamage(int amount)
        {
            life -= amount;
            IsDead();
        }

        public bool IsDead()
        {
            if(life <= 0)
            {
                LateDispose();
            }
            //LateDispose();
            return life <= 0;
        }

        public static int enemyDamage(int damage)
        {

            return damage;

        }
    }
}
