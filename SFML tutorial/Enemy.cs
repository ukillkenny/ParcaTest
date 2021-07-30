﻿using SFML.Graphics;
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


        private int MinAttack;
        private int MaxAttack;
        public Enemy(Vector2f position, string spriteSheetPath, int sheetColumns, int sheetRow, string name, int maxLife, int minAttack, int maxAttack)
        {
            currentPosition = position;
            this.sheetColumns = sheetColumns;
            this.sheetRow = sheetRow;
            texture = new Texture(spriteSheetPath);
            frameRect = new IntRect(0, 0, (int)texture.Size.X / sheetColumns, (int)texture.Size.Y / sheetRow);
            sprite = new Sprite(texture, frameRect);
            sprite.Scale = new Vector2f(0.8f, 0.8f);
            speed = 450.0f;
            frameTimer = new Clock();
            timerAnimation = new Clock();
            CollisionManager.GetInstance().AddToCollisionManager(this);

            this.name = name;
            this.maxLife = maxLife;
            this.life = maxLife;
            this.MinAttack = minAttack;
            this.MaxAttack = maxAttack;

        }

        public override void Update()
        {
            UpdateAnimation();
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
                LateDispose();
            }
            
        }

        public override void DisposeNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.DisposeNow();
        }
    }
}
