using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_tutorial
{

    class FirstLevel
    {
        private Background background;
        private Player player;
        private Enemy enemy;
        private Vector2f initialPlayerPosition = new Vector2f(1.0f, 750.0f);
        private Vector2f initialEnemiesPosition = new Vector2f(1000.0f, 750.0f);
        private List<Enemy> enemies;
        public bool toDelete;

        private Rock rock;
        private RockTwo rockTwo;
        private InvisibleBottomWall invisibleBottomWall;
        private InvisibleTopWall invisibleTopWall;
        private invisibleLimitLeft invisibleLimitLeft;
        private InvisibleLimitRight InvisibleLimitRight;

        public FirstLevel(int maxEnemeiesInFloor)
        {
            background = new Background();
            player = new Player(initialPlayerPosition, "Sprites/reaperok01.png", 4, 3, "Reaper", 800, 150, 100);
            //enemy = new Enemy(initialEnemiesPosition, "Enemy/animacion-enemigo.png", 4, 2, "Dementor", 800, 120, 200);
            rock = new Rock();
            rockTwo = new RockTwo();

            invisibleBottomWall = new InvisibleBottomWall(new Vector2f(0.1f, 1080.0f), new Vector2f(6000.0f, 0.1f));
            invisibleTopWall = new InvisibleTopWall(new Vector2f(0.1f, 680.0f), new Vector2f(6000.0f, 0.1f));
            invisibleLimitLeft = new invisibleLimitLeft(new Vector2f(0.1f, 0.1f), new Vector2f(0.1f, 1080.0f));
            InvisibleLimitRight = new InvisibleLimitRight(new Vector2f(6000.0f, 0.1f), new Vector2f(0.1f, 1080.0f));

            enemies = new List<Enemy>();
            Random random = new Random();
            maxEnemeiesInFloor = 1;
            int enemiesInFloor = maxEnemeiesInFloor;
            for (int i = 0; i < enemiesInFloor; i++)
            {
                enemies.Add(new Enemy(initialEnemiesPosition, "Enemy/animacion-enemigo.png", 4, 2, "Dementor", 800, 120, 200));
            }

            toDelete = false;

            //enemies = new List<Enemy>();
            //Random random = new Random();
            //int enemiesInFloor = random.Next(1, maxEnemeiesInFloor);
            //for (int i = 0; i < enemiesInFloor; i++)
            //{
            //    
            //}
        }


        public void Update()
        {
            background.Update();
            if (player != null)
            {
                player.Update();
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].Update();
                }
            }
            DeleteEnemies();



        }

        public void Draw(RenderWindow window)
        {
            background.Draw(window);
            if (player != null)
            {
                player.Draw(window);
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].Draw(window);
                }
            }
            //if (enemy != null)
            //{
            //    enemy.Draw(window);
            //}
            rock.Draw(window);
            rockTwo.Draw(window);
        }

        private void DeleteEnemies()
        {
            List<int> indexToDelet = new List<int>();

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update();

                if (enemies[i] == null)
                {
                    indexToDelet.Add(i);

                }

            }

            for (int i = indexToDelet.Count - 1; i >= 0; i--)
            {
                enemies[i].DisposeNow();
                enemies.RemoveAt(i);
            }
        }

        public void CheckGarbage()
        {
            if (player != null)
            {
                player.CheckGarbage();

                if (player.toDelete)
                {
                    player = null;
                }
            }

            List<int> indexToDelet = new List<int>();

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].CheckGarbage();
                if (enemies[i].toDelete)
                {
                    indexToDelet.Add(i);
                }
            }
            for (int i = 0; i < indexToDelet.Count; i++)
            {
                enemies.RemoveAt(i);
            }
            if (toDelete == true)
            {
                enemy.DisposeNow();
            }


        }
    }
}
