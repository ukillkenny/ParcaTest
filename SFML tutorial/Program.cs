using System;

namespace SFML_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            while(game.UpdateWindow())
            {
                game.UpdateGame();
                game.DrawGame();
            }

            Console.ReadKey();
        }
    }
}
