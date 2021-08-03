using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.Audio;

namespace SFML_tutorial
{
    class Shoot : GameObjectBase, IColisionable
    {
        private Sound sound;
        public Shoot(Vector2f startPosition) : base("sprites" + Path.DirectorySeparatorChar + "shoot.png", startPosition)
        {
            
            sprite.Scale = new Vector2f(0.2f, 0.2f);
            CollisionManager.GetInstance().AddToCollisionManager(this);
            SoundBuffer soundBuffer = new SoundBuffer("Audio" + Path.DirectorySeparatorChar + "sound" + Path.DirectorySeparatorChar + "master-fx-disparo.wav");
            sound = new Sound(soundBuffer);
        
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
            sound.Play();
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
