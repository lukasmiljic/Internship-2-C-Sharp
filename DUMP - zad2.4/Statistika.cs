using System;
using System.Collections.Generic;

namespace DUMP___zad2._4
{
    internal class Statistika
    {
        public static string adminLozinka = "1234";
        public static void StatistikaMeni(List<Racun> racuni, List<Artikal> artikli)
        {
            var userChoice = -1;

            if (UnosLozinke() == 1) return;

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Ukupan broj artikala u trgovini");
                Console.WriteLine("2 - Vrijednost artikala koji nisu jos prodani");
                Console.WriteLine("3 - Vrijednosti svih artikala koji su prodani");
                Console.WriteLine("4 - Stanje po mjesecima");
                Console.WriteLine("0 - Povratak na glavni meni");

                if (!Helper.ValidateInput(ref userChoice, 4))
                {
                    Helper.ErrorMessage(0);
                    continue;
                }
                break;
            } while (true);

            switch (userChoice)
            {
                case 1:
                    UkupnoArtikala(artikli);
                    break;

                case 2:
                    VrijednostNeprodanih(artikli);
                    break;

                case 3:
                    VrijednostProdanih(racuni);
                    break;

                case 4:
                    StanjeMjeseci(racuni);
                    break;

                case 0:
                    break;

                default:
                    break;
            }
        }
        public static int UnosLozinke()
        {
            string unesenaLozinka = "";
            do
            {
                Console.Clear();
                Console.Write("Unesite 0 za povratak na glavni meni\nLozinka: ");
                unesenaLozinka = Console.ReadLine();
                if (unesenaLozinka == "0") return 1;

                if (!ProvjeraLozinke(unesenaLozinka))
                {
                    Helper.ErrorMessage(1);
                    continue;
                }
                break;
            } while (true);
            return 0;
        }
        public static bool ProvjeraLozinke(string unesenaLozinka)
        {
            if (unesenaLozinka == adminLozinka) return true;
            return false;
        }
        public static void UkupnoArtikala(List<Artikal> artikli)
        {
            int sum = 0;
            Console.Clear();
            foreach (var artikal in artikli)
            {
                sum += artikal.Kolicina;
            }
            Console.WriteLine($"U trgovini je ukupno {sum} artikala");
            Console.WriteLine("Pritisnite bilo sto za nastavak...");
            Console.ReadLine();
        }
        public static void VrijednostNeprodanih(List<Artikal> artikli)
        {
            double sum = 0;
            Console.Clear();
            foreach (var artikal in artikli)
            {
                sum += artikal.Cijena;
            }
            Console.WriteLine($"Vrijednost svih ne prodanih artikala je {sum}");
            Console.WriteLine("Pritisnite bilo sto za nastavak...");
            Console.ReadLine();
        }
        public static void VrijednostProdanih(List<Racun> racuni)
        {
            double sum = 0;
            Console.Clear();
            
            foreach (var racun in racuni)
            {
                
                foreach (var proizvod in racuni[racuni.IndexOf(racun)].proizvodi)
                {
                    sum += proizvod.Cijena;
                }
            }
            Console.WriteLine($"Vrijednost svih prodanih artikala je {sum}");
            Console.WriteLine("Pritisnite bilo sto za nastavak...");
            Console.ReadLine();
        }
        public static void StanjeMjeseci(List<Racun> racuni)
        {
            var godina = 0;
            var mjesec = 0;
            var placa = 0;
            var ostaliTroskovi = 0;
            var ukupno = 0.0;
            Console.Clear();
            Console.WriteLine("Stanje po mjescima");
            Console.Write("Godina:");
            godina = int.Parse(Console.ReadLine());
            Console.Write("Mjesec:");
            mjesec = int.Parse(Console.ReadLine());
            Console.WriteLine("Placa: ");
            placa = int.Parse(Console.ReadLine());
            Console.WriteLine("Ostali troskovi: ");
            ostaliTroskovi=int.Parse(Console.ReadLine());
            foreach (var racun in racuni)
            {
                if (racun.DatumIzdavanja.Year == godina && racun.DatumIzdavanja.Month == mjesec)
                {
                    foreach (var proizvod in racuni[racuni.IndexOf(racun)].proizvodi)
                    {
                        ukupno += proizvod.Cijena;
                    }
                }
            }

            Console.WriteLine($"Ukupna zarada je {ukupno*1/3-placa-ostaliTroskovi}");
            Console.WriteLine("Pritsnite bilo sto za nastavak...");
            Console.ReadLine();
        }
    }
}
