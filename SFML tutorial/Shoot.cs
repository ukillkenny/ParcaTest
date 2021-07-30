using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SFML_tutorial
{
    class Shoot : GameObjectBase, IColisionable
    {
        
        public Shoot(Vector2f startPosition) : base("sprites" + Path.DirectorySeparatorChar + "shoot.png", startPosition)
        {
            
            sprite.Scale = new Vector2f(0.4f, 0.4f);
            CollisionManager.GetInstance().AddToCollisionManager(this);
            
        
        }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }

        public string GetTag()
        {
            return "Shoot";
        }

        public void OnColision(IColisionable other)
        {
            if (other is Enemy)
            {
                LateDispose();
            }   
        }

        public override void Update()
        {
            
            currentPosition.X += 1300 * FrameRate.GetDeltaTime();
            base.Update();  
            
        }

        public override void DisposeNow()
        {
            CollisionManager.GetInstance().RemoveFromCollisionManager(this);
            base.DisposeNow();
        }

        public static int ShootDamage(int damage)
        {

            return damage;
           
        }

    }
}
