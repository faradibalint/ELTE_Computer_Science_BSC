using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class Verengzo : Ork
    {
        public Verengzo(string name, int treasure) : base(name, 100, 5, 30, treasure){}

        public override void Attack(Elf elf)
        {
            elf.Defend(this);
            if (!elf.Alive()) this.treasure += elf.acquireTreasure();
        }
        public override void Defend(Vakmero elf)
        {
            this.hit(25);
        }
        public override void Defend(Ugyes elf)
        {
            this.hit(15);
        }
        public override void Defend(Bolcs elf)
        {
            this.hit(5);
        }
        public override string ToString()
        {
            return $"Name: {name}, Type: Vérengző, Health: {health}, Treasure: {treasure}";
        }
    }
}
