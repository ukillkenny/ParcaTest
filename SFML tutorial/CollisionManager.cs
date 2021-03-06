using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    class CollisionManager
    {
        private static CollisionManager instance;
        public static CollisionManager GetInstance()
        {
            if (instance == null)
            {
                instance = new CollisionManager();
            }
            return instance;
        }

        private List<IColisionable> colisionables;

        private CollisionManager()
        {
            colisionables = new List<IColisionable>();
        }

        public void AddToCollisionManager(IColisionable colisionable)
        {
            colisionables.Add(colisionable);
        }

        public void RemoveFromCollisionManager(IColisionable colisionable)
        {
            if (colisionables.Contains(colisionable))
            {
                colisionables.Remove(colisionable);
            }
        }

        public void CheckCollisions()
        {
            for (int i = 0; i < colisionables.Count; i++)
            {
                for (int j = 0; j < colisionables.Count; j++)
                {
                    if (i != j)
                    {
                        if (colisionables[i].GetBounds().Intersects(colisionables[j].GetBounds()))
                        {
                            colisionables[i].OnColision(colisionables[j]);
                        }
                    }
                }
            }
         }
    }
}
