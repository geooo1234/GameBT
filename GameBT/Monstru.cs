using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBT
{
    public class Monstru
    {
        int Puncte { get; set; }
        int MaxDamage { get; set; }
        int Bonus { get; set; }
        Pozitie Pozitie { get; set; }
        public Monstru(int maxDamage, int bonus, int puncteViata, Pozitie poz)
        {
            Puncte = puncteViata;
            MaxDamage = maxDamage;
            Bonus = bonus;
            Pozitie = poz;
        }
    }
}
