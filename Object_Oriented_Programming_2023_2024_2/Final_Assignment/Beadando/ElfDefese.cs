using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public interface ElfDefese
    {
        public void Defend(Verengzo ork);
        public void Defend(Ravasz ork);
        public void Defend(Ovatos ork);
    }
}
