using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    public abstract class GameObjectBase
    {
        protected Texture texture;
        protected Sprite sprite;
        protected Vector2f currentPosition;
        public bool toDelete;



        public GameObjectBase(string texturePath, Vector2f startPosition)
        {
            texture = new Texture(texturePath);
            sprite = new Sprite(texture);
            currentPosition = startPosition;
            sprite.Position = currentPosition;
            toDelete = false;

        }

        public GameObjectBase()
        {

        }


        public virtual void Update()
        {
            sprite.Position = currentPosition;
        }    

        public virtual void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
 

        public virtual void Dispose()
        {
            sprite.Dispose();
            texture.Dispose();
            toDelete = true;
        }

        public abstract void CheckGarbage();

        public Vector2f GetPosition()
        {
            return currentPosition;
        }
    }
}
