using System;
using System.Collections.Generic;
using System.Text;

namespace SFML_tutorial
{
    class Enemy
    {
        private string name;
        private int life;
        private int maxLife;


        private int MinAttack;
        private int MaxAttack;
        public Enemy(string name, int maxLife, int maxMana, int minAttack, int maxAttack)
        {
            this.name = name;
            this.maxLife = maxLife;
            this.life = maxLife;
            this.MinAttack = minAttack;
            this.MaxAttack = maxAttack;

        }



    }
}
