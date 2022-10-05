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

        public int Kaartteller(Boolean[] gespeeld,string[] allekaarten)
            //kijk hoeveel kaarten er al zijn gepakt en laat deze op het scherm zien. 
        {
            int count = 52;
            for (int i = 0; i < 52; i++)
            {
                if (gespeeld[i] == true)
                {
                    count--;
                    Console.WriteLine(allekaarten[i]);
                }
                if (count <= 12)
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

        public int Kaartpakken(Boolean[] gespeeld, string[] allekaarten)
        {
            //er word een random getal meegegeven. Hiermee wordt er gekozen welke kaart uit de array wordt gepakt.
            //Dan word ook deze waarden in de boolean array aangepast naar false zodat de kaart geen tweede keer kan worden gepakt.
            Kaart kaart = new();
            int random = kaart.Random();
            
            if (gespeeld[random] == false)
            {
                gespeeld[random] = true;
                Console.WriteLine(allekaarten[random]);
            }
            else
            {
                //wanneer de kaart al eerder is gespeeld wordt er een nieuw random getal gemaakt. Dit blijft gebeuren tot er een getal word gepakt die nog niet eerder is getrokken. 
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
            //de waarde word berekend. de waarde krijgt het overblijfsel wanneer deze door 13 word gedeeld.
            //dan word er 2 bij opgeteld, al komt dit op 14 uit(de aas) dan wordt gekeken of 11/1 dichter bij blackjack komt, Deze word dan gekozen.
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
