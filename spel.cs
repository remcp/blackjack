using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Blackjack
{
    internal class Speler
    {
        public int spelen(int card,Boolean[] gespeeld, int totaal, Boolean stop)
        {
            Kaart kaart = new Kaart();
            string speler;
            while (stop == false)
            {
                Console.WriteLine("wil je een kaart? (y/n)");
                speler = Console.ReadLine();

                if (speler == "y")
                {
                    card = kaart.Kaartpakken(gespeeld);
                    totaal = totaal + kaart.Kaartwaarde(card, totaal);
                    Console.WriteLine(totaal);
                    gespeeld[card] = true;
                    if (totaal > 21)
                    {
                        Console.WriteLine("oepsie");
                        stop = true;
                    }
                }
                else
                {
                    stop = true;
                }
            }
            return totaal;
        }

        public string uitslag(int totaal_deler, int totaal_speler1, int totaal_speler2)
        {
            string money = " ";
            if (totaal_deler < 22)
            {
                if (totaal_speler1 > totaal_speler2 & totaal_speler1 < 22)
                {
                    if (totaal_speler1 > totaal_deler & totaal_speler1 < 22)
                    {
                        Console.WriteLine("speler1 je hebt gewonnen");
                    }
                    else if (totaal_speler1 == totaal_deler)
                    {
                        Console.WriteLine("speler1 je krijgt je geld terug");
                    }
                    else
                    {
                        Console.WriteLine("speler1 je hebt verloren");
                    }
                }
                else if (totaal_speler1 < 22 & totaal_speler2 > 21 & totaal_speler1 > totaal_deler)
                {
                    Console.WriteLine("speler 1 heeft gewonnen");
                }
                else if (totaal_speler2 > totaal_speler1 & totaal_speler2 < 22)
                {
                    if (totaal_speler2 > totaal_deler & totaal_speler2 < 22)
                    {
                        Console.WriteLine("speler2 je hebt gewonnen");
                    }
                    else if (totaal_speler2 == totaal_deler)
                    {
                        Console.WriteLine("speler2 je krijgt je geld terug");
                    }
                    else
                    {
                        Console.WriteLine("speler2 je hebt verloren");
                    }
                }
                else if (totaal_speler2 < 22 & totaal_speler1 > 21 & totaal_speler2 > totaal_deler)
                {
                    Console.WriteLine("speler 1 heeft gewonnen");
                }
                else if (totaal_speler1 == totaal_speler2 & totaal_speler1 > totaal_deler & totaal_speler1 < 22)
                {
                    Console.WriteLine("spelers verdelen het geld");
                }
                else
                {
                    Console.WriteLine("da's pech. geld weg");
                }
            }
            else
            {
                if (totaal_speler1 > totaal_speler2 & totaal_speler1 < 22)
                {
                    Console.WriteLine("speler1 je hebt gewonnen");
                }
                else if (totaal_speler2 > totaal_speler1 & totaal_speler2 < 22)
                {
                    Console.WriteLine("speler2 je hebt gewonnen");
                }
                else if (totaal_speler1 == totaal_speler2 & totaal_speler1 < 22)
                {
                    Console.WriteLine("spelers verdelen het geld");
                }
                else if (totaal_speler1 < 22 & totaal_speler2 > 21)
                {
                    Console.WriteLine("speler 1 heeft gewonnen");
                }
                else if (totaal_speler2 < 22 & totaal_speler1 > 21)
                {
                    Console.WriteLine("speler 1 heeft gewonnen");
                }
                else
                {
                    Console.WriteLine("da's pech. geld weg");
                }
            }
            return money;
        }
    }
}
