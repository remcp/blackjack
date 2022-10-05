using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Kaart
    {
        public int Random()
        {
            Random rnd = new Random();
            int rndnum = rnd.Next(1, 52);
            int a = rndnum;
            return a;
        }

        public int Kaartteller(Boolean[] gespeeld)
        {
            int count = 52;
            for (int i = 0; i < 52; i++)
            {
                if (gespeeld[i] == true)
                {
                    count--;
                }
                if (count == 0)
                {
                    Console.WriteLine("deck wordt geschud");
                    for (i = 0; i < 52; i++)
                    {
                        gespeeld[i] = false;
                    }
                }
            }
            return count;
        }

        public int Kaartpakken(Boolean[] gespeeld)
        {
            Kaart kaart = new();
            int random = kaart.Random();
            string[] allekaarten = new string[52] {"harten 2", "harten 3", "harten 4", "harten 5", "harten 6", "harten 7", "harten 8", "harten 9", "harten 10", "harten boer", "harten vrouw", "harten heer", "harten aas", "schoppen 2", "schoppen 3", "schoppen 4", "schoppen 5", "schoppen 6", "schoppen 7", "schoppen 8", "schoppen 9", "schoppen 10", "schoppen boer", "schoppen vrouw", "schoppen heer", "schoppen aas", "ruiten 2", "ruiten 3", "ruiten 4", "ruiten 5", "ruiten 6", "ruiten 7", "ruiten 8", "ruiten 9", "ruiten 10", "ruiten boer", "ruiten vrouw", "ruiten heer", "ruiten aas", "klaveren 2", "klaveren 3", "klaveren 4", "klaveren 5", "klaveren 6", "klaveren 7", "klaveren 8", "klaveren 9", "klaveren 10", "klaveren boer", "klaveren vrouw", "klaveren heer", "klaveren aas" };
            if (gespeeld[random] == false)
            {
                gespeeld[random] = true;
                Console.WriteLine(allekaarten[random]);
            }
            else
            {
                while(gespeeld[random] == true)
                {
                    random = kaart.Random();
                }
                if(gespeeld[random] == false)
                {
                    gespeeld[random] = true;
                    Console.WriteLine(allekaarten[random]);
                }
            }
            return random;
        }

        public int Kaartwaarde(int card, int totaal)
        {
            int waarde = card;

            waarde = waarde % 13;
            waarde = waarde + 2;
            if (waarde == 14)
            {
                if (totaal > 10)
                {
                    waarde = 1;
                }
                else
                {
                    waarde = 11;
                }
            }
            else if (waarde > 9)
            {
                waarde = 10;
            }

            return waarde;
        }
    }
}
