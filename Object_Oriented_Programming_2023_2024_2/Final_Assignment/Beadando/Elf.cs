using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public abstract class Elf : Entity, ElfDefese
    {
        protected int elixir;
        protected Elf(string name, int hp, int shield, int damage) : base(name, hp, shield, damage){
            
            this.treasure = 0;
            this.elixir = 0;
        }
        public int getElixir() => this.elixir;
        public void Healing() {
            elixir += sellTrasureForElixir();
            this.health += useElixir();
        }
        protected abstract int useElixir();
        protected abstract int sellTrasureForElixir();
        public abstract void Attack(Ork ork);
    
        public abstract void Defend(Verengzo ork);
        public abstract void Defend(Ravasz ork);
        public abstract void Defend(Ovatos ork);
        
    }
}
