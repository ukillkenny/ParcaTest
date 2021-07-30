using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    public class Camera : IColisionable
    {
        private static Vector2f cameraSize;
        //private static FloatRect cameraSize;
        private RenderWindow window;
        private View view;
        private Vector2f currentPositionCamera;
        private FloatRect viewport;
        //private FloatRect currenPositionCamera;
     

        public Camera(RenderWindow window)
        {
            this.window = window;
            view = window.GetView();
            viewport = new FloatRect(2.0f, 2.0f, 300.0f, 300.0f);
            currentPositionCamera = view.Center;
            //currenPositionCamera = view.Viewport;
            CollisionManager.GetInstance().AddToCollisionManager(this);
        }


        public void UpdateCamera()
        {
            //cameraSize = new Vector2f(1.0f, 6000.0f);

            cameraSize = window.GetView().Size;

            //cameraSize = new FloatRect(1.0f, 1.0f, 1.0f, 1.0f);

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

        //public static Vector2f GetCameraSize()
        //{
        //    return cameraSize;
        //}

        public static Vector2f GetCameraSize()
        {
            return cameraSize;
        }

        public FloatRect GetBounds()
        {
            return view.Viewport;
                          
        }
        
        public string GetTag()
        {
            return "colisionCamera";
        }
        
        public void OnColision(IColisionable other)
        {
            //if (other is invisibleLimitLeft || other is InvisibleLimitRight)
            //{
            //    if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            //    {
            //        currentPositionCamera.X += 380 * FrameRate.GetDeltaTime();
            //        
            //    }
            //
            //    if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            //    {
            //        currentPositionCamera.X -= 380 * FrameRate.GetDeltaTime();
            //        
            //    }
            //}

            //--------------------------------------------------------------------

            //if (other is InvisibleLimitRight)
            //{
            //    
            //}

        }

        ///if (Keyboard.IsKeyPressed(Keyboard.Key.D))
        ///{
        ///    currentPositionCamera.X -= 380 * FrameRate.GetDeltaTime();
        ///}

    }
}
