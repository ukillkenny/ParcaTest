using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    class Shoot : GameObjectBase
    {

        public Shoot(Vector2f startPosition) : base("Sprites/shootsAn.png", new IntRect(0, 0 , 300, 300), startPosition)
        {
            
            sprite.Scale = new Vector2f(0.8f, 0.8f);
            
        }

        public override void Update()
        {
            currentPosition.X += 700 * FrameRate.GetDeltaTime();
            base.Update();  
            
        }



    }
}
