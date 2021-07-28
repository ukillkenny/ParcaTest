using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    public class Camera //: IColisionable
    {

        private RenderWindow window;
        private View view;
        private Vector2f currentPositionCamera;
    
        public Camera(RenderWindow window)
        {
            this.window = window;
            view = window.GetView();
            currentPositionCamera = view.Center;
            //CollisionManager.GetInstance().AddToCollisionManager(this);
        }

        public void UpdateCamera()
        {
            if ((Keyboard.IsKeyPressed(Keyboard.Key.D)))
            {
                currentPositionCamera.X += 380 * FrameRate.GetDeltaTime();
            }

            if ((Keyboard.IsKeyPressed(Keyboard.Key.A)))
            {
                currentPositionCamera.X -= 380 * FrameRate.GetDeltaTime();
            }

            view.Center = currentPositionCamera;
            window.SetView(view);

        }

        //public FloatRect GetBounds()
        //{
        //    return currentPositionCamera.GetGlobalBounds();
        //}
        //
        //public string GetTag()
        //{
        //    return "colisionCamera";
        //}
        //
        //public void OnColision(IColisionable other)
        //{
        //    if (other is invisibleLimitLeft)
        //    {
        //        if (Keyboard.IsKeyPressed(Keyboard.Key.A))
        //        {
        //            currentPositionCamera.X += 380 * FrameRate.GetDeltaTime();
        //        }
        //
        //    }
        //
        //    if (Keyboard.IsKeyPressed(Keyboard.Key.D))
        //    {
        //        currentPositionCamera.X -= 380 * FrameRate.GetDeltaTime();
        //    }
        //}

    }
}
