using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Elf> elfek = new List<Elf>();
            List<Ork> orkok = new List<Ork>();
            FileReader f = new FileReader(@"..\..\..\test.txt");
            string[] data = f.ReadLines();
            foreach(string line in data)
            {
                string[] fields = line.Split(' ');
                if(fields.Length == 4 ) 
                {
                    switch (fields[2])
                    {
                        case "v":
                            orkok.Add(new Verengzo(fields[0], int.Parse(fields[3])));
                            break;
                        case "r":
                            orkok.Add(new Ravasz(fields[0], int.Parse(fields[3])));
                            break;
                        case "o":
                            orkok.Add(new Ovatos(fields[0], int.Parse(fields[3])));
                            break;
                    }

                }else if(fields.Length == 3 )
                {
                    switch(fields[2])
                    {
                        case "v":
                            elfek.Add(new Vakmero(fields[0]));
                            break;
                        case "u":
                            elfek.Add(new Ugyes(fields[0]));
                            break;
                        case "b":
                            elfek.Add(new Bolcs(fields[0]));
                            break;
                    }
                }
            }
            Battle battle = new Battle(elfek, orkok);
            battle.Start();
        }
    }
}
