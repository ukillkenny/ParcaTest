using System;
using System.Collections.Generic;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace SFML_tutorial
{
    class Game
    {
        
        private static Vector2f windowSize;
        private RenderWindow window;
        private Gameplay gameplay;

        public Game()
        {
            VideoMode videomode = new VideoMode();
            videomode.Width = 1920;
            videomode.Height = 1080;

            window = new RenderWindow(videomode, "My Game");
            window.Closed += CloseWindow;
            window.SetFramerateLimit(FrameRate.FRAMERATE_LIMIT);

            gameplay = new Gameplay();
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            window.Close();
        }

        public bool UpdateWindow()
        {
            window.DispatchEvents();
            window.Clear(Color.Black);
            return window.IsOpen;

        }

        public void UpdateGame()
        {
            gameplay.Update();
            windowSize = window.GetView().Size;
        }

        public void DrawGame()
        {
            gameplay.Draw(window);
            window.Display();
        }


        public static Vector2f GetWindowSize()
        {
            return windowSize;
        }
        
    
    }
}
