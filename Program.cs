using System;
using System.Runtime.InteropServices;

namespace Blackjack
{
    class Exe
    {
        static void Main()
        {
            Boolean[] gespeeld = new Boolean[52];
            int gestopt = 0;
            int totaal_speler1 = 0;
            int totaal_speler2 = 0;
            int totaaldeler = 0;
            int card = 0;
            Kaart kaart = new();
            Speler speler = new();
            int kaartenover = kaart.Kaartteller(gespeeld);
            string spel = "y";
            string spelers = "y";
            Boolean stop1 = false;
            Boolean stop2 = false;

            while (spel == "y")
            {
                Console.SetWindowSize(40, 30);
                Console.WriteLine("2 spelers? (y/n)");
                spelers = Console.ReadLine();
                if (spelers == "n")
                {
                    stop2 = true;
                }
                //deze code pakt een random getal en haald dan de bijbehorende kaart uit een array. De waarde van de kaart word dan berekend.
                Console.WriteLine("deler pakt..");
                card = kaart.Kaartpakken(gespeeld);
                totaaldeler = totaaldeler + kaart.Kaartwaarde(card, totaaldeler);
                gespeeld[card] = true;

                Console.WriteLine(totaaldeler);
                Console.WriteLine();

                while (stop1 == false)
                {
                    totaal_speler1 = speler.spelen(card,gespeeld, totaal_speler1, stop1);
                    stop1 = true;
                }
                while (stop2 == false)
                {
                    totaal_speler2 = speler.spelen(card,gespeeld, totaal_speler2, stop2);
                    stop2 = true;
                }
                Console.WriteLine();
                Console.WriteLine("deler pakt..");
                while (totaaldeler < 17)
                {
                    card = kaart.Kaartpakken(gespeeld);
                    totaaldeler = totaaldeler + kaart.Kaartwaarde(card, totaaldeler);
                    gespeeld[card] = true;
                }
                Console.WriteLine();
                Console.WriteLine("speler1 jij had" + " " + totaal_speler1);
                Console.WriteLine("speler2 jij had" + " " + totaal_speler2);
                Console.WriteLine("deler had" + " " + totaaldeler);
                Console.WriteLine();
                string uitslag = speler.uitslag(totaaldeler, totaal_speler1, totaal_speler2);
                Console.WriteLine("nog een spel? (y/n)");
                spel = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("er zijn nog" + " " + kaart.Kaartteller(gespeeld) + " " + "kaarten over");
                totaal_speler1 = 0;
                totaal_speler2 = 0;
                stop1 = false;
                stop2 = false;
                gestopt = 0;
            }
        }
    }
}