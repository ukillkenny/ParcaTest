using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    class InvisibleBottomWall : IColisionable
    {
        private Vector2f position;
        private Vector2f size;
        public InvisibleBottomWall(Vector2f position, Vector2f size)
        {
            this.position = position;
            this.size = size;
            CollisionManager.GetInstance().AddToCollisionManager(this);
        }
            


        public FloatRect GetBounds()
        {
            return new FloatRect(position, size);
        }

        public string GetTag()
        {
            return "InvisibleBottomWall";
        }

        public void OnColision(IColisionable other)
        {
        }
    }
}
