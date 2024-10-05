using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class Ravasz : Ork
    {
        public Ravasz(string name, int treasure) : base(name, 90, 20, 15, treasure) { }
        public override void Attack(Elf elf)
        {
            elf.Defend(this);
            if (!elf.Alive()) this.treasure += elf.acquireTreasure();
        }
        public override void Defend(Vakmero elf)
        {
            this.hit(10);
        }
        public override void Defend(Ugyes elf)
        {
            this.hit(0);
        }
        public override void Defend(Bolcs elf)
        {
            this.hit(0);
        }
        public override string ToString()
        {
            return $"Name: {name}, Type: Ravasz, Health: {health}, Treasure: {treasure}";
        }

    }
}
