using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBT
{
  public  abstract class IMonstru
    {
       public int Puncte { get; set; }
        public int MaxDamage { get; set; }
        public int Bonus { get; set; }
        public Pozitie Pozitie { get; set; }
    }
}
