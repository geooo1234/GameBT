using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBT
{
   public class MonstruMare:IMonstru
    {
        
        public MonstruMare(Pozitie poz)
        {
            Puncte = 10;
            MaxDamage = 5;
            Bonus =10;
            Pozitie = poz;
        }
    }
}
