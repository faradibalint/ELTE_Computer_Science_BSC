using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class Bolcs : Elf
    {
        public Bolcs(string name) : base(name, 60, 10, 10){}
        protected override int useElixir()
        {
            if (60 - this.health <= this.elixir)
            {
                this.elixir -= 60 - this.health;
                return 60 - this.elixir;
            }
            else
            {
                int allElixir = this.elixir;
                this.elixir = 0;
                return allElixir;
            }
        }
        protected override int sellTrasureForElixir()
        {
            int allTreasure = this.treasure;
            this.treasure = 0;
            return allTreasure;
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
            return $"Name: {name}, Type: Bölcs, Health: {health}, Elixir: {elixir}, Treasure: {treasure}";
        }
    }
}
