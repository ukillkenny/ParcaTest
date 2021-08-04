using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
using System.IO;

namespace SFML_tutorial
{

    class FirstLevel : GameObjectBase
    {

        private Background background;
        private Player player;
        private Enemy enemy;
        private Vector2f initialPlayerPosition = new Vector2f(1.0f, 750.0f);
        private DoorLvlTwo DoorLvlTwo;


        // private Vector2f initialEnemiesPosition = new Vector2f(1000.0f, 750.0f);
        private Vector2f setEnemyPosition;
        private List<Enemy> enemies;
        //public bool toDelete;

        private Music music;

        private Rock rock;
        private RockTwo rockTwo;
        private InvisibleBottomWall invisibleBottomWall;
        private InvisibleTopWall invisibleTopWall;
        private invisibleLimitLeft invisibleLimitLeft;
        private InvisibleLimitRight InvisibleLimitRight;

        private float enemySpawnTimer;
        private float enemySpawnTimerMax;
        int maxEnemiesInLevel;

        public FirstLevel()
        {
            background = new Background();
            player = new Player(initialPlayerPosition, "Sprites/reaperok01.png", 4, 3, "Reaper", 800, 150, 100);

            rock = new Rock();
            rockTwo = new RockTwo();
            DoorLvlTwo = new DoorLvlTwo();


            music = new Music("Audio" + Path.DirectorySeparatorChar + "music" + Path.DirectorySeparatorChar + "master-accion-desierto.wav");
            music.Play();
            music.Volume = 30;
            music.Loop = true;
            invisibleBottomWall = new InvisibleBottomWall(new Vector2f(0.1f, 1080.0f), new Vector2f(6000.0f, 0.1f));
            invisibleTopWall = new InvisibleTopWall(new Vector2f(0.1f, 680.0f), new Vector2f(6000.0f, 0.1f));
            invisibleLimitLeft = new invisibleLimitLeft(new Vector2f(0.1f, 0.1f), new Vector2f(0.1f, 1080.0f));
            InvisibleLimitRight = new InvisibleLimitRight(new Vector2f(6000.0f, 0.1f), new Vector2f(0.1f, 1080.0f));

            CreateEnemy();

            //toDelete = false;

        }

        public void CreateEnemy()
        {
            // Crear enemigos
            enemies = new List<Enemy>();
            maxEnemiesInLevel = 1;
            int enemiesInLevel = maxEnemiesInLevel;
            for (int i = 0; i < enemiesInLevel; i++)
            {
                enemies.Add(new Enemy(setEnemyPosition, "Enemy/animacion-enemigo.png", 4, 2, "Dementor", 800, 120, 200));
                
            }

            // Fin de creacion de enemigos
        }

        // FUNCIONABA ANTERIORMENTE

        //public void CreateEnemy()
        //{
        //    
        //    //enemySpawnTimerMax = FrameRate.GetDeltaTime();
        //    //enemySpawnTimer = enemySpawnTimerMax;
        //    
        //    enemies = new List<Enemy>();
        //
        //    maxEnemeiesInLevel = 10;
        //    int enemiesInLevel = maxEnemeiesInLevel;
        //    for (int i = 0; i < enemiesInLevel; i++)
        //    {
        //        
        //        enemies.Add(new Enemy(setEnemyPosition, "Enemy/animacion-enemigo.png", 4, 2, "Dementor", 800, 120, 200));
        //    }
        //}



        //public void SpawnEnemy()
        //{
        //    //setPosition = new Vector2f(1000.0f, 750.0f);
        //
        //    for (int i = 0; i < enemies.Count; i++)
        //    {
        //        
        //        //if (enemies[i] != null)
        //        //{
        //            CreateEnemy();
        //            //enemies[i].Update();
        //        //}
        //
        //    }
        //}
        
        //public void UpdateEnemies()
        //{
        //
        //    if (enemies.Count < maxEnemiesInLevel)
        //    {
        //
        //
        //        if (enemySpawnTimer >= enemySpawnTimerMax)
        //        {
        //            //SpawnEnemy();
        //            
        //            
        //        
        //            enemySpawnTimer = 0f;
        //        }
        //
        //        enemySpawnTimer += 1.0f;
        //    }
        //
        //
        //}

        // FIN DE FUNCIONABA ANTERIORMENTE

        public override void Update()
        {
            
            background.Update();
            if (player != null)
            {
                player.Update();
            }
            //CreateEnemy();
            //UpdateEnemies();
            DeleteEnemies();
            rock.Update();
            rockTwo.Update();
            DoorLvlTwo.Update();
        }

        public override void Draw(RenderWindow window)
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
            DoorLvlTwo.Draw(window);
            
        }

        public void DeleteEnemies()
        {
            List<int> indexToDelete = new List<int>();

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update();

                //if(enemies[i].IsDead())
                //{
                //    indexToDelete.Add(i);
                //}
                if ((enemies[i].GetPosition().X < 0))
                {
                    indexToDelete.Add(i);
                    
                }
            }

            for (int i = indexToDelete.Count - 1; i >= 0; i--)
            {
                enemies[i].DisposeNow();
                enemies.RemoveAt(i);
            }
        }

        // ELIMINACION DE ENEMIGOS QUE FUNCIONABA

        //private void DeleteEnemies()
        //{
        //    List<int> indexToDelet = new List<int>();
        //    List<Enemy> enemiesAlive = new List<Enemy>();
        //
        //
        //    for (int i = 0; i < enemies.Count; i++)
        //    {
        //        enemies[i].Update();
        //
        //        if (enemies[i].IsDead())
        //        {
        //            indexToDelet.Add(i);
        //        }
        //    
        //        if (enemies[i].IsDead() == false)
        //        {
        //    
        //            enemiesAlive.Add(enemies[i]);
        //    
        //            if(enemiesAlive.Count == 0)
        //            {
        //                enemiesAlive[i] = null;
        //            }
        //              
        //        }
        //
        //        if ((enemies[i].GetPosition().X < 0))
        //        {
        //            indexToDelet.Add(i);
        //            
        //        }
        //    
        //    }
        //
        //    enemies = enemiesAlive;
        //
        //    for (int j = indexToDelet.Count - 1; j > 0; j--)
        //    {
        //
        //        enemiesAlive[j].DisposeNow();
        //        enemiesAlive.RemoveAt(j);
        //
        //       
        //        //enemies[i].DisposeNow();
        //        //enemies.RemoveAt(i);
        //
        //    }
        //
        //}

        // FIN DE ELIMINACION DE ENEMIGOS QUE FUNCIONABA

        public override void CheckGarbage()
        {
            if (player != null)
            {
                player.CheckGarbage();

                if (player.toDelete)
                {
                    player = null;
                }
            }

            List<int> indexToDelete = new List<int>();

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].CheckGarbage();
                if (enemies[i].toDelete)
                {
                    indexToDelete.Add(i);
                }
            }
            for (int i = 0; i < indexToDelete.Count; i++)
            {
                enemies.RemoveAt(i);
            }
            if (toDelete == true)
            {
                DisposeNow();
            }
            base.CheckGarbage();
        }


        // LO QUE ANTES FUNCIONABA

        //List<int> indexToDelet = new List<int>();
        //
        //for (int i = 0; i < enemies.Count; i++)
        //{
        //    enemies[i].CheckGarbage();
        //    if (enemies[i].toDelete)
        //    {
        //        indexToDelet.Add(i);
        //    }
        //}
        //for (int i = 0; i < indexToDelet.Count; i++)
        //{
        //    enemies.RemoveAt(i);
        //}
        //if (toDelete == true)
        //{
        //    enemy.DisposeNow();
        //}

        // FIN DE LO QUE ANTES FUNCIONABA

    }

}

