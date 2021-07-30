using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_tutorial
{
    class Gameplay
    {
        private FirstLevel firstLevel;


        public Gameplay()
        {
            firstLevel = new FirstLevel(1);
        }

        public void Update()
        {
            firstLevel.Update();

        }

        public void Draw(RenderWindow window)
        {
            firstLevel.Draw(window);
        }

        public void CheckGarbage()
        {
            firstLevel.CheckGarbage();


        }
    }
}
