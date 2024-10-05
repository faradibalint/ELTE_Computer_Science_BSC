using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public interface OrkDefense
    {
        public void Defend(Vakmero elf);
        public void Defend(Ugyes elf);
        public void Defend(Bolcs elf);
    }
}
