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



        public GameObjectBase(string texturePath, IntRect area, Vector2f startPosition)
        {
            texture = new Texture(texturePath);
            sprite = new Sprite(texture, area);
            currentPosition = startPosition;
            sprite.Position = currentPosition;


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
 

        public void Dispose()
        {
            sprite.Dispose();
            texture.Dispose();
        }

        public Vector2f GetPosition()
        {
            return currentPosition;
        }
    }
}
