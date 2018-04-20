using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBT
{

    public class Jucator
    {
        public int Puncte { get; set; }
        public int Skill1 { get; set; }
        public int Skill2 { get; set; }
        public int Skill3 { get; set; }
        public Pozitie Pozitie { get; set; }
        public Dictionary<Potiuni, int> Potiuni { get; set; }
        public string username;
        public Jucator(int Dificultate, string username)
        {
            this.username = username;
            Puncte = 10;
            Skill1 = 1;
            Skill2 = 2;
            Skill3 = 3;
            switch (Dificultate)
            {
                case 1:
                    Pozitie = new Pozitie { X = 2, Y = 0 };
                    break;
                case 2:
                    Pozitie = new Pozitie { X = 3, Y = 0 };
                    break;
                case 3:
                    Pozitie = new Pozitie { X = 4, Y = 0 };
                    break;
            }
            Potiuni = new Dictionary<Potiuni, int>();
            Potiuni.Add(GameBT.Potiuni.Healing, 0);
            Potiuni.Add(GameBT.Potiuni.Toxica, 0);

        }
    }

    public enum Potiuni
    {
        Healing = 0,
        Toxica = 1
    }
}
