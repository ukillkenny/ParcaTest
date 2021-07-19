using SFML.System;
using System;

namespace SFML_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            FrameRate.InitFrameRateSystem();

            while(game.UpdateWindow())
            {
                game.UpdateGame();
                game.DrawGame();

                FrameRate.OnFrameEnd();
                Console.WriteLine(FrameRate.GetCurrentFPS());
            }

            Console.ReadKey();
        }
    }
}
