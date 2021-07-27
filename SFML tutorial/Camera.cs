using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    public class Camera
    {

        private RenderWindow window;
        private View view;
        private Vector2f currentPositionCamera;
    
        public Camera(RenderWindow window)
        {
            this.window = window;
            view = window.GetView();
            currentPositionCamera = view.Center;  
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

    }
}
