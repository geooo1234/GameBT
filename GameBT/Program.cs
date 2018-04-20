using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBT
{
    class Program
    {
       public  static void  Main(string[] args)
        {
            Console.WriteLine("Introduceti username-ul:");
            string username = Console.ReadLine();
            Console.WriteLine("Selectati nivelul de dificultate:");
            Console.WriteLine("1.Low");
            Console.WriteLine("2.Normal");
            Console.WriteLine("3.High");
            string nivel = Console.ReadLine();

            //Console.WriteLine(nivel);
            int n = int.Parse(nivel);
            Joc joc = new Joc(n, username);
            int dim = 0; ;
            switch (n)
            {
                case 1:
                    dim = 3;
                    break;
                case 2:
                    dim = 4;
                    break;
                case 3:
                    dim = 5;
                    break;

            }
            while (!joc.Finished)
            {
                for (int i = 0; i < dim; i++)
                {
                    for (int j = 0; j < dim; j++)
                    {
                        Console.Write(joc.Harta[i, j]);

                    }
                    Console.WriteLine();
                }
                Console.WriteLine(String.Format("Potiuni Healing:{0}",joc.jucator.Potiuni[Potiuni.Healing]));
                Console.WriteLine(String.Format("Potiuni Toxica:{0}", joc.jucator.Potiuni[Potiuni.Toxica]));
                Console.WriteLine("Selectati urmatorul pas");
                Console.WriteLine("1.Stanga");
                Console.WriteLine("2.Dreapta");
                Console.WriteLine("3.Sus");
                Console.WriteLine("4.Jos");
                Console.WriteLine("5.Foloseste Potiunea Healing");
                Console.WriteLine(String.Format("Punctaj:{0}", joc.jucator.Puncte));
                string s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        {
                            if (joc.jucator.Pozitie.Y > 0)
                            {
                                joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = -1;
                                switch (joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y - 1])
                                {
                                    case 1:
                                        {
                                            joc.jucator.Puncte += 1;

                                            joc.jucator.Pozitie.Y -= 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case -1:
                                        {
                                            //joc.jucator.Puncte += 1;

                                            joc.jucator.Pozitie.Y -= 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 4:
                                        {
                                            joc.jucator.Potiuni[Potiuni.Healing]++;
                                            joc.jucator.Pozitie.Y -= 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 5:
                                        {
                                            joc.jucator.Potiuni[Potiuni.Toxica]++;
                                            joc.jucator.Pozitie.Y -= 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 2:
                                        
                                        {
                                            joc.jucator.Pozitie.Y -= 1;//mut stanga cu 1
                                            IMonstru monstru = joc.Monstri.FirstOrDefault(m => m.Pozitie.X == joc.jucator.Pozitie.X && m.Pozitie.Y== joc.jucator.Pozitie.Y);
                                            while (monstru.Puncte > 0 && joc.jucator.Puncte > 0) {
                                                Console.WriteLine(String.Format("Punctaj Jucator:{0}", joc.jucator.Puncte));
                                                Console.WriteLine(String.Format("Punctaj monstru:{0}", monstru.Puncte));
                                                Console.WriteLine("1.Skil1");
                                                Console.WriteLine("2.Skill2");
                                                Console.WriteLine("3.Skill3");
                                                if(joc.jucator.Potiuni[Potiuni.Toxica] >0)
                                                  Console.WriteLine("4.Foloseste potiune toxica");
                                                string skill = Console.ReadLine();
                                                
                                                switch (skill) {
                                                    case "1":
                                                        monstru.Puncte -= joc.jucator.Skill1;
                                                        break;
                                                    case "2":
                                                        monstru.Puncte -= joc.jucator.Skill2;
                                                        break;
                                                    case "3":
                                                        monstru.Puncte -= joc.jucator.Skill3;
                                                        break;
                                                    case "4":
                                                        monstru.Puncte = 0; 
                                                        break;
                                                }
                                                if (monstru.Puncte > 0) {
                                                    Random rand = new Random();
                                                    int nr = rand.Next(1,monstru.MaxDamage+1);
                                                    joc.jucator.Puncte -= nr;
                                                }
                                            }
                                            if (joc.jucator.Puncte <= 0)
                                            {
                                                joc.Castigator = false;
                                                joc.Finished = true;
                                            }
                                            else {
                                                joc.jucator.Puncte += monstru.Bonus;
                                                joc.Monstri.Remove(monstru);
                                                joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;
                                                if (joc.Monstri.Count == 0) {
                                                    joc.Castigator = true;
                                                    joc.Finished = true;
                                                }
                                            }

                                            break;
                                        }



                                }
                            }
                            break;
                        }
                    case "2":
                        {
                            if (joc.jucator.Pozitie.Y < 3)
                            {
                                joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = -1;
                                switch (joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y + 1])
                                {
                                    case 1:
                                        {
                                            joc.jucator.Puncte += 1;

                                            joc.jucator.Pozitie.Y += 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case -1:
                                        {
                                            //joc.jucator.Puncte += 1;

                                            joc.jucator.Pozitie.Y += 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 4:
                                        {
                                            joc.jucator.Potiuni[Potiuni.Healing]++;
                                            joc.jucator.Pozitie.Y += 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 5:
                                        {
                                            joc.jucator.Potiuni[Potiuni.Toxica]++;
                                            joc.jucator.Pozitie.Y += 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 2:

                                        {
                                            joc.jucator.Pozitie.Y += 1;//mut stanga cu 1
                                            IMonstru monstru = joc.Monstri.FirstOrDefault(m => m.Pozitie.X == joc.jucator.Pozitie.X && m.Pozitie.Y == joc.jucator.Pozitie.Y);
                                            while (monstru.Puncte > 0 && joc.jucator.Puncte > 0)
                                            {
                                                Console.WriteLine(String.Format("Punctaj Jucator:{0}", joc.jucator.Puncte));
                                                Console.WriteLine(String.Format("Punctaj monstru:{0}", monstru.Puncte));
                                                Console.WriteLine("1.Skil1");
                                                Console.WriteLine("2.Skill2");
                                                Console.WriteLine("3.Skill3");
                                                if (joc.jucator.Potiuni[Potiuni.Toxica] > 0)
                                                    Console.WriteLine("4.Foloseste potiune toxica");
                                                string skill = Console.ReadLine();

                                                switch (skill)
                                                {
                                                    case "1":
                                                        monstru.Puncte -= joc.jucator.Skill1;
                                                        break;
                                                    case "2":
                                                        monstru.Puncte -= joc.jucator.Skill2;
                                                        break;
                                                    case "3":
                                                        monstru.Puncte -= joc.jucator.Skill3;
                                                        break;
                                                    case "4":
                                                        monstru.Puncte = 0;
                                                        break;
                                                }
                                                if (monstru.Puncte > 0)
                                                {
                                                    Random rand = new Random();
                                                    int nr = rand.Next(1, monstru.MaxDamage + 1);
                                                    joc.jucator.Puncte -= nr;
                                                }
                                            }
                                            if (joc.jucator.Puncte <= 0)
                                            {
                                                joc.Castigator = false;
                                                joc.Finished = true;
                                            }
                                            else
                                            {
                                                joc.jucator.Puncte += monstru.Bonus;
                                                joc.Monstri.Remove(monstru);
                                                joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;
                                                if (joc.Monstri.Count == 0)
                                                {
                                                    joc.Castigator = true;
                                                    joc.Finished = true;
                                                }
                                            }

                                            break;
                                        }


                                }
                            }
                            break;
                        }
                    case "3":
                        {
                            if (joc.jucator.Pozitie.X > 0)
                            {
                                joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = -1;
                                switch (joc.Harta[joc.jucator.Pozitie.X - 1, joc.jucator.Pozitie.Y])
                                {
                                    case 1:
                                        {
                                            joc.jucator.Puncte += 1;

                                            joc.jucator.Pozitie.X -= 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case -1:
                                        {
                                            //joc.jucator.Puncte += 1;

                                            joc.jucator.Pozitie.X -= 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 4:
                                        {
                                            joc.jucator.Potiuni[Potiuni.Healing]++;
                                            joc.jucator.Pozitie.X -= 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 5:
                                        {
                                            joc.jucator.Potiuni[Potiuni.Toxica]++;
                                            joc.jucator.Pozitie.X -= 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 2:

                                        {
                                            joc.jucator.Pozitie.X -= 1;//mut stanga cu 1
                                            IMonstru monstru = joc.Monstri.FirstOrDefault(m => m.Pozitie.X == joc.jucator.Pozitie.X && m.Pozitie.Y == joc.jucator.Pozitie.Y);
                                            while (monstru.Puncte > 0 && joc.jucator.Puncte > 0)
                                            {
                                                Console.WriteLine(String.Format("Punctaj Jucator:{0}", joc.jucator.Puncte));
                                                Console.WriteLine(String.Format("Punctaj monstru:{0}", monstru.Puncte));
                                                Console.WriteLine("1.Skil1");
                                                Console.WriteLine("2.Skill2");
                                                Console.WriteLine("3.Skill3");
                                                if (joc.jucator.Potiuni[Potiuni.Toxica] > 0)
                                                    Console.WriteLine("4.Foloseste potiune toxica");
                                                string skill = Console.ReadLine();

                                                switch (skill)
                                                {
                                                    case "1":
                                                        monstru.Puncte -= joc.jucator.Skill1;
                                                        break;
                                                    case "2":
                                                        monstru.Puncte -= joc.jucator.Skill2;
                                                        break;
                                                    case "3":
                                                        monstru.Puncte -= joc.jucator.Skill3;
                                                        break;
                                                    case "4":
                                                        monstru.Puncte = 0;
                                                        break;
                                                }
                                                if (monstru.Puncte > 0)
                                                {
                                                    Random rand = new Random();
                                                    int nr = rand.Next(1, monstru.MaxDamage + 1);
                                                    joc.jucator.Puncte -= nr;
                                                }
                                            }
                                            if (joc.jucator.Puncte <= 0)
                                            {
                                                joc.Castigator = false;
                                                joc.Finished = true;
                                            }
                                            else
                                            {
                                                joc.jucator.Puncte += monstru.Bonus;
                                                joc.Monstri.Remove(monstru);
                                                joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;
                                                if (joc.Monstri.Count == 0)
                                                {
                                                    joc.Castigator = true;
                                                    joc.Finished = true;
                                                }
                                            }

                                            break;
                                        }


                                }
                            }
                            break;
                        }
                    case "4":
                        {
                            if (joc.jucator.Pozitie.X < 3)
                            {
                                joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = -1;
                                switch (joc.Harta[joc.jucator.Pozitie.X + 1, joc.jucator.Pozitie.Y])
                                {
                                    case 1:
                                        {
                                            joc.jucator.Puncte += 1;

                                            joc.jucator.Pozitie.X += 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case -1:
                                        {
                                            //joc.jucator.Puncte += 1;

                                            joc.jucator.Pozitie.X += 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 4:
                                        {
                                            joc.jucator.Potiuni[Potiuni.Healing]++;
                                            joc.jucator.Pozitie.X += 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 5:
                                        {
                                            joc.jucator.Potiuni[Potiuni.Toxica]++;
                                            joc.jucator.Pozitie.X += 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 2:

                                        {
                                            joc.jucator.Pozitie.X += 1;//mut stanga cu 1
                                            IMonstru monstru = joc.Monstri.FirstOrDefault(m => m.Pozitie.X == joc.jucator.Pozitie.X && m.Pozitie.Y == joc.jucator.Pozitie.Y);
                                            while (monstru.Puncte > 0 && joc.jucator.Puncte > 0)
                                            {
                                                Console.WriteLine(String.Format("Punctaj Jucator:{0}", joc.jucator.Puncte));
                                                Console.WriteLine(String.Format("Punctaj monstru:{0}", monstru.Puncte));
                                                Console.WriteLine("1.Skil1");
                                                Console.WriteLine("2.Skill2");
                                                Console.WriteLine("3.Skill3");
                                                if (joc.jucator.Potiuni[Potiuni.Toxica] > 0)
                                                    Console.WriteLine("4.Foloseste potiune toxica");
                                                string skill = Console.ReadLine();

                                                switch (skill)
                                                {
                                                    case "1":
                                                        monstru.Puncte -= joc.jucator.Skill1;
                                                        break;
                                                    case "2":
                                                        monstru.Puncte -= joc.jucator.Skill2;
                                                        break;
                                                    case "3":
                                                        monstru.Puncte -= joc.jucator.Skill3;
                                                        break;
                                                    case "4":
                                                        monstru.Puncte = 0;
                                                        break;
                                                }
                                                if (monstru.Puncte > 0)
                                                {
                                                    Random rand = new Random();
                                                    int nr = rand.Next(1, monstru.MaxDamage + 1);
                                                    joc.jucator.Puncte -= nr;
                                                }
                                            }
                                            if (joc.jucator.Puncte <= 0)
                                            {
                                                joc.Castigator = false;
                                                joc.Finished = true;
                                            }
                                            else
                                            {
                                                joc.jucator.Puncte += monstru.Bonus;
                                                joc.Monstri.Remove(monstru);
                                                joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;
                                                if (joc.Monstri.Count == 0)
                                                {
                                                    joc.Castigator = true;
                                                    joc.Finished = true;
                                                }
                                            }

                                            break;
                                        }


                                }
                            }
                            break;
                        }
                    case "5":
                        { 
                            joc.jucator.Puncte = 10;
                            joc.jucator.Potiuni[Potiuni.Healing]--;
                            break;
                        }
                }

                // Console.ReadLine();
            }
            Console.WriteLine("Joc Terminat");
            Console.WriteLine(joc.Castigator ? String.Format("Castigator\nPunctaj: {0}", joc.jucator.Puncte) : "Joc pierdut");
            var jucator_joc = new Jucator_Joc
            {
                username = joc.jucator.username,
                scor = joc.jucator.Puncte
            };
            var respPost =  RequestHelper.MakePostRequest<int>("test/save/", jucator_joc);
            Console.ReadLine();
    

        }

    
    }
}
