using System;
using System.Runtime.InteropServices;

namespace Blackjack
{
    class Exe
    {
        static void Main()
        {
            string[] allekaarten = new string[52] { "harten 2", "harten 3", "harten 4", "harten 5", "harten 6", "harten 7", "harten 8", "harten 9", "harten 10", "harten boer", "harten vrouw", "harten heer", "harten aas", "schoppen 2", "schoppen 3", "schoppen 4", "schoppen 5", "schoppen 6", "schoppen 7", "schoppen 8", "schoppen 9", "schoppen 10", "schoppen boer", "schoppen vrouw", "schoppen heer", "schoppen aas",
                "ruiten 2", "ruiten 3", "ruiten 4", "ruiten 5", "ruiten 6", "ruiten 7", "ruiten 8", "ruiten 9", "ruiten 10", "ruiten boer", "ruiten vrouw", "ruiten heer", "ruiten aas", "klaveren 2", "klaveren 3", "klaveren 4", "klaveren 5", "klaveren 6", "klaveren 7", "klaveren 8", "klaveren 9", "klaveren 10", "klaveren boer", "klaveren vrouw", "klaveren heer", "klaveren aas" };
            Boolean[] gespeeld = new Boolean[52];
            int totaal_speler1 = 0;
            int totaal_speler2 = 0;
            int totaaldeler = 0;
            int card = 0;
            Kaart kaart = new();
            Speler speler = new();
            int kaartenover = kaart.Kaartteller(gespeeld, allekaarten);
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
                card = kaart.Kaartpakken(gespeeld, allekaarten);
                totaaldeler = totaaldeler + kaart.Kaartwaarde(card, totaaldeler);
                gespeeld[card] = true;

                Console.WriteLine(totaaldeler);
                Console.WriteLine();
                //de spelers pakken een kaart. de waarde hiervan word bij de totale waarden opgeteld.
                while (stop1 == false)
                {
                    totaal_speler1 = speler.spelen(card,gespeeld, totaal_speler1, stop1, 1, allekaarten);
                    stop1 = true;
                }
                Thread.Sleep(1000);
                Console.Clear();
                while (stop2 == false)
                {
                    totaal_speler2 = speler.spelen(card,gespeeld, totaal_speler2, stop2, 2, allekaarten);
                    stop2 = true;
                }
                Thread.Sleep(1000);
                Console.Clear();
                //deler pakt kaarten tot hij minstens 17 punten heeft. Hierna word gekeken wie heeft gewonnen en worden alle waardes gereset.
                Console.WriteLine();
                Console.WriteLine("deler pakt..");
                while (totaaldeler < 17)
                {
                    card = kaart.Kaartpakken(gespeeld, allekaarten);
                    totaaldeler = totaaldeler + kaart.Kaartwaarde(card, totaaldeler);
                    gespeeld[card] = true;
                }
                Console.WriteLine();

                string uitslag = speler.uitslag(totaaldeler, totaal_speler1, totaal_speler2);
                Console.WriteLine("nog een spel? (y/n)");
                spel = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("er zijn nog" + " " + kaart.Kaartteller(gespeeld, allekaarten) + " " + "kaarten over");
                totaaldeler = 0;
                totaal_speler1 = 0;
                totaal_speler2 = 0;
                stop1 = false;
                stop2 = false;
            }
        }
    }
}