using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class Vakmero : Elf
    {
        public Vakmero(string name) : base(name, 100, 10, 30){}
        protected override int useElixir()
        {
            return 0;
        }
        protected override int sellTrasureForElixir()
        {
            return 0;
        }
        public override void Attack(Ork ork)
        {
            ork.Defend(this);
            if (!ork.Alive()) this.treasure += ork.acquireTreasure();
        }
       
        public override void Defend(Verengzo ork)
        {
            this.hit(20);
        }
        public override void Defend(Ravasz ork)
        {
            this.hit(5);
        }
        public override void Defend(Ovatos ork)
        {
            this.hit(0);
        }
        public override string ToString()
        {
            return $"Name: {name}, Type: Vakmerő, Health: {health}, Elixir: {elixir}, Treasure: {treasure}";
        }
    }
}
