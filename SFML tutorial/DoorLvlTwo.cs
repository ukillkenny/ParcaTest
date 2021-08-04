using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SFML_tutorial
{
    class DoorLvlTwo : GameObjectBase, IColisionable
    {
        public DoorLvlTwo() : base("sprites" + Path.DirectorySeparatorChar + "doorLevelTwo.png", new Vector2f(5655.0f, 0.0f))
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
            return "decorationOne";
        }

        public void OnColision(IColisionable other)
        {

        }
    }
}
