using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBT
{
   public class MonstruMic:IMonstru
    {
        
        public MonstruMic(Pozitie poz)
        {
            Puncte = 5;
            MaxDamage = 3;
            Bonus = 5;
            Pozitie = poz;
        }
    }
}
