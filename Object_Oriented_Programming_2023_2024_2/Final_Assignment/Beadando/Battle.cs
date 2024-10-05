using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class Battle
    {
        private List<Elf> elfek;
        private List<Ork> orkok;

        public Battle(List<Elf> e, List<Ork> o)
        {
            this.elfek = e;
            this.orkok = o;
        }
        public List<Elf> getElves() => elfek;
        public List<Ork> getOrks() => orkok;
        public void Start()
        {
            bool state = true;
            int round = 1;
            Console.WriteLine("The Battle has started.");
            while (state)
            {
                Console.WriteLine("\nRound " + round + "\n");
                switch (Round())
                {
                    case 0:
                        break;
                    case 1:
                        state = false;
                        Console.WriteLine("The battle has ended.");
                        Console.WriteLine("The elves have won the battle");
                        break;
                    case -1:
                        state = false;
                        Console.WriteLine("\nThe battle has ended.");
                        Console.WriteLine("The orks have won the battle");
                        break;
                }
                round++;
            }
        }
        private int Round()
        {
            int len = elfek.Count < orkok.Count ? elfek.Count : orkok.Count;
            for (int i = 0; i < len; i++)
            {
                if(elfek.Count > i && orkok.Count > i)
                {
                    elfek[i].Attack(orkok[i]);
                    removeDead();
                    if (elfek.Count > i && orkok.Count > i)
                    {
                        orkok[i].Attack(elfek[i]);
                        removeDead();
                    }
                    elfek[i].Healing();
                }
                
                

            }
            Console.WriteLine("Elf army:");
            foreach(Elf elf in elfek)
            {
                Console.WriteLine(elf);
            }
            Console.WriteLine("Ork army:");
            foreach (Ork ork in orkok)
            {
                Console.WriteLine(ork);
            }
            if (!elfek.Any())
            {
                return -1;
            }else if(!orkok.Any())
            {
                return 1;
            }
            return 0;
        }
        private void removeDead()
        {
            elfek.RemoveAll(elf => !elf.Alive());
            orkok.RemoveAll(ork => !ork.Alive());
        }
    }
}
