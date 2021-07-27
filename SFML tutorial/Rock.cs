using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SFML_tutorial
{
    class Rock : GameObjectBase, IColisionable
    {

        public Rock() : base ("sprites" + Path.DirectorySeparatorChar + "rock-01.png", new Vector2f(2000.0f, 960.0f))
        {
            sprite.Scale = new Vector2f(1.0f, 1.0f);
        }

        public override void CheckGarbage()
        {
            
        }

        public override void Draw(RenderWindow window)
        {
            base.Draw(window);
        }

        public FloatRect GetBounds()
        {
            return sprite.GetGlobalBounds();
        }

        public string GetTag()
        {
            return "decoration";
        }

        public void OnColision(IColisionable other)
        {
            
        }
    }
}
