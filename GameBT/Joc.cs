using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBT
{
    public class Joc
    {
        public int Dificultate { get; set; }
        public int[,] Harta { get; set; }
        public bool Finished { get; set; }
        public List<Monstru> Monstri = new List<Monstru>();
        public Jucator jucator;

        public Joc(int Dificultate, string username)
        {
            Finished = false;
            this.Dificultate = Dificultate;
            switch (Dificultate)
            {
                case 1:
                    {
                        Harta = new int[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                Harta[i, j] = 1;

                            }
                        }
                        jucator = new Jucator(Dificultate, username);
                        Harta[2, 0] = 0;
                        Monstri.Add(new Monstru(5, 10, 10, new Pozitie { X = 3, Y = 3 }));
                        Harta[2, 2] = 2;// ca sa indentific pe harta 
                        int x, y;
                        for (int i = 0; i < 2; i++)
                        {

                            do
                            {
                                Random rand = new Random();
                                x = rand.Next(3);
                                y = rand.Next(3);
                            } while (Harta[x, y] != 1);
                            Monstri.Add(new Monstru(3, 5, 5, new Pozitie { X = x, Y = y }));
                            Harta[x, y] = 3;// adauga mosntri pe harta

                        }
                        do
                        {
                            Random rand = new Random();
                            x = rand.Next(3);
                            y = rand.Next(3);
                        } while (Harta[x, y] != 1);
                        Harta[x, y] = 4;//potiune Healing

                        break;
                    }

                case 2:
                    {
                        Harta = new int[4, 4];
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                Harta[i, j] = 1;

                            }
                        }
                        jucator = new Jucator(Dificultate, username);
                        Harta[3, 0] = 0;
                        Monstri.Add(new Monstru(5, 10, 10, new Pozitie { X = 4, Y = 4 }));
                        Harta[3, 3] = 2;// ca sa indentific pe harta 
                        int x, y;
                        for (int i = 0; i < 5; i++)
                        {

                            do
                            {
                                Random rand = new Random();
                                x = rand.Next(4);
                                y = rand.Next(4);
                            } while (Harta[x, y] != 1);
                            Monstri.Add(new Monstru(3, 5, 5, new Pozitie { X = x, Y = y }));
                            Harta[x, y] = 3;// adauga mosntri pe harta

                        }
                        for (int i = 0; i < 2; i++)
                        {
                            do
                            {
                                Random rand = new Random();
                                x = rand.Next(4);
                                y = rand.Next(4);
                            } while (Harta[x, y] != 1);
                            Harta[x, y] = 4;//potiune Healing

                        }
                        do
                        {
                            Random rand = new Random();
                            x = rand.Next(4);
                            y = rand.Next(4);
                        } while (Harta[x, y] != 1);
                        Harta[x, y] = 5;//potiune Toxica


                        break;
                    }
                case 3:
                    {
                        Harta = new int[5, 5];
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Harta[i, j] = 1;

                            }
                        }
                        jucator = new Jucator(Dificultate, username);
                        Harta[4, 0] = 0;
                        Monstri.Add(new Monstru(5, 10, 10, new Pozitie { X = 5, Y = 5 }));
                        Harta[4, 4] = 2;// ca sa indentific pe harta 
                        int x, y;
                        for (int i = 0; i < 8; i++)
                        {

                            do
                            {
                                Random rand = new Random();
                                x = rand.Next(5);
                                y = rand.Next(5);
                            } while (Harta[x, y] != 1);
                            Monstri.Add(new Monstru(3, 5, 5, new Pozitie { X = x, Y = y }));
                            Harta[x, y] = 3;// adauga mosntri pe harta

                        }
                        for (int i = 0; i < 4; i++)
                        {
                            do
                            {
                                Random rand = new Random();
                                x = rand.Next(5);
                                y = rand.Next(5);
                            } while (Harta[x, y] != 1);
                            Harta[x, y] = 4;//potiune Healing

                        }
                        for (int i = 0; i < 2; i++)
                        {
                            do
                            {
                                Random rand = new Random();
                                x = rand.Next(5);
                                y = rand.Next(5);
                            } while (Harta[x, y] != 1);
                            Harta[x, y] = 5;//potiune Toxica
                        }


                        break;
                    }
            }

        }
    }
}
