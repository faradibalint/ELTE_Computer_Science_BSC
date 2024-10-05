using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public abstract class Ork : Entity, OrkDefense
    {
        protected Ork(string name, int hp, int shield, int damage, int treasure) : base(name, hp, shield, damage)
        {
            this.treasure = treasure;
        }
        public abstract void Attack(Elf ork);
        public abstract void Defend(Vakmero elf);
        public abstract void Defend(Ugyes elf);
        public abstract void Defend(Bolcs elf);
    }
}
