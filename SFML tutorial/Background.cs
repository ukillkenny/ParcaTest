using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    class Background
    {
        private Texture textureBack;
        private Sprite spriteBack;
        private Vector2f positionBack;
        //private float backSpeed;


        public Background()
        {
            textureBack = new Texture("landscape/Desierto_Entero.png");
            spriteBack = new Sprite(textureBack);
            spriteBack.Scale = new Vector2f(1.0f, 1.0f);
            positionBack = new Vector2f(0.0f, 0.0f);
            spriteBack.Position = positionBack;
            //backSpeed = 50.0f;

        }

        public void Update()
        {
            spriteBack.Position = positionBack;

           // BackgroundMovement();
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(spriteBack);

        }

       // public void BackgroundMovement()
       // {
       //     if (Keyboard.IsKeyPressed(Keyboard.Key.D))
       //     {
       //         positionBack.X += backSpeed * FrameRate.GetDeltaTime();
       //     }
       //
       //     if (Keyboard.IsKeyPressed(Keyboard.Key.D))
       //     {
       //         positionBackOne.X += backOneSpeed * FrameRate.GetDeltaTime();
       //     }
       //
       // }
    }
}
