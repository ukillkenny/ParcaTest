using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    public interface IColisionable
    {
        public FloatRect GetBounds();
        public void OnColision(IColisionable other);
        public string GetTag();
    }
}
