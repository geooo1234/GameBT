using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBT
{
    class Program
    {
        static void Main(string[] args)
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
                                            joc.jucator.Potiuni.Add(Potiuni.Healing);
                                            joc.jucator.Pozitie.Y -= 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 5:
                                        {
                                            joc.jucator.Potiuni.Add(Potiuni.Toxica);
                                            joc.jucator.Pozitie.Y -= 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

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
                                            joc.jucator.Potiuni.Add(Potiuni.Healing);
                                            joc.jucator.Pozitie.Y += 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 5:
                                        {
                                            joc.jucator.Potiuni.Add(Potiuni.Toxica);
                                            joc.jucator.Pozitie.Y += 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

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
                                            joc.jucator.Potiuni.Add(Potiuni.Healing);
                                            joc.jucator.Pozitie.X -= 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 5:
                                        {
                                            joc.jucator.Potiuni.Add(Potiuni.Toxica);
                                            joc.jucator.Pozitie.X -= 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

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
                                            joc.jucator.Potiuni.Add(Potiuni.Healing);
                                            joc.jucator.Pozitie.X += 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }
                                    case 5:
                                        {
                                            joc.jucator.Potiuni.Add(Potiuni.Toxica);
                                            joc.jucator.Pozitie.X += 1;//mut stanga cu 1
                                            joc.Harta[joc.jucator.Pozitie.X, joc.jucator.Pozitie.Y] = 0;

                                            break;
                                        }


                                }
                            }
                            break;
                        }
                    case "5":
                        joc.jucator.Puncte = 10;
                        break;

                }

                // Console.ReadLine();
            }

        }
    
    }
}
