using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class Ugyes : Elf
    {
        public Ugyes(string name) : base(name, 80, 20, 20){}
        protected override int useElixir()
        {
            if (this.health < 50)
            {
                if (50-this.health <= this.elixir)
                {
                    this.elixir -= (50 - this.health);
                    return (50 - this.health);
                }
                int allElixir = this.elixir;
                this.elixir = 0;
                return allElixir;
            }
            return 0;
        }
        protected override int sellTrasureForElixir()
        {
            if(this.treasure % 2 == 0)
            {
                this.treasure /= 2;
                return this.treasure;
            }
            else
            {
                this.treasure /= 2;
                this.treasure += 1;
                return this.treasure - 1;
            }
        }
        public override void Attack(Ork ork)
        {
            ork.Defend(this);
            if (!ork.Alive()) this.treasure += ork.acquireTreasure();
        }
        public override void Defend(Verengzo ork)
        {
            this.hit(10);
        }
        public override void Defend(Ravasz ork)
        {
            this.hit(0);
        }
        public override void Defend(Ovatos ork)
        {
            this.hit(0);
        }
        public override string ToString()
        {
            return $"Name: {name}, Type: Ügyes, Health: {health}, Elixir: {elixir}, Treasure: {treasure}";
        }
    }
}
