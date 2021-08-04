using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SFML_tutorial
{
    class RockTwo : GameObjectBase, IColisionable
    {
        public RockTwo() : base("sprites" + Path.DirectorySeparatorChar + "rock-02.png", new Vector2f(4000.0f, 888.0f))
        {
            sprite.Scale = new Vector2f(0.5f, 0.5f);
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
            return "decorationOne";
        }

        public void OnColision(IColisionable other)
        {

        }
    }
}
