using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class Entity
    {
        protected string name;
        protected int health;
        protected int shield;
        protected int damage;
        protected int treasure;

        protected Entity(string name, int hp, int shield, int damage) 
        {
            this.name = name;
            this.health = hp;
            this.shield = shield;
            this.damage = damage;
        }
        public int acquireTreasure() => this.treasure;
        protected void hit(int amount)
        {
            this.health -= amount;
        }
        public bool Alive()
        {
            return this.health > 0;
        }
        public int getHealth() => this.health;

    }
}
