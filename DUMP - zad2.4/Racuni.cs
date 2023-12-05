using System;
using System.Collections.Generic;

namespace DUMP___zad2._4
{
    public class Racun
    {
        public int id;
        public DateTime DatumIzdavanja;
        public List<(string Naziv, int Kolicina, double Cijena)> proizvodi;

        public Racun(int id, DateTime datumIzdavanja, List<(string Naziv, int Kolicina, double Cijena)> proizvodi)
        {
            this.id = id;
            DatumIzdavanja = datumIzdavanja;
            this.proizvodi = proizvodi;
        }
    }
    internal class Racuni
    {
        public static int id_racuna = 0;
        public static void RacuniMeni(List<Racun> racuni, List<Artikal> artikli)
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Unos novog racuna");
                Console.WriteLine("2 - Ispis");
                Console.WriteLine("0 - Povratak na glavni meni");

                if (!Helper.ValidateInput(ref userChoice, 2))
                {
                    Helper.ErrorMessage(0);
                    continue;
                }
                break;
            } while (true);

            switch (userChoice)
            {
                case 1:
                    UnosRacuna(racuni,artikli);
                    break;

                case 2:
                    IspisSvihRacuna(racuni);
                    break;

                default:
                    break;
            }
        }
        public static void UnosRacuna(List<Racun> racuni, List<Artikal> artikli)
        {
            var naziv = "";
            var kolicina = 0;
            var kraj = "KRAJ";
            var articleIndex = 0;
            List<(string Naziv, int Kolicina, double Cijena)> proizvodi = new List<(string Naziv, int Kolicina, double Cijena)>();

            Console.Clear();
            Console.WriteLine("Unos novog racuna\nUnesite KRAJ kao naziv proizvoda za prekid unosa");
            Artikli.IspisArtikala(artikli);
            do
            {
                Console.Write("Naziv proizvoda: ");
                naziv = Console.ReadLine();
                if (naziv == kraj)
                {
                    if (Helper.Sigurni() == 1)
                    {
                        break;
                    }
                    else continue;
                }
                articleIndex = artikli.FindIndex(x => x.Naziv == naziv);
                if (articleIndex == -1)
                {
                    Console.Write($"Artikal s nazivom {naziv} nije pronaden\nPritisnite bilo sto za nastavak...");
                    Console.ReadLine();
                    return;
                }
                Console.Write("Kolicina: ");
                kolicina = int.Parse(Console.ReadLine());
                if (kolicina > artikli[articleIndex].Kolicina)
                {
                    Console.WriteLine("Greska pri unosu kolicine\nPritisnite bilo sto za nastavak...");
                    return;
                }
                proizvodi.Add((naziv, kolicina, artikli[articleIndex].Cijena));
            } while (true);

            Console.WriteLine("Zelite li nastaviti s ovim racunom");

            var tempRacun = new Racun(++id_racuna, DateTime.Today, proizvodi);
            IspisRacuna(tempRacun);

            if(Helper.Sigurni() == 1)
            {
                artikli[articleIndex].Kolicina -= kolicina;
                racuni.Add(tempRacun);
                Console.WriteLine("Uspjesno upisan racun\nPritisnite bilo sto za povratak...");
                Console.ReadLine();
            }
        }
        public static void IspisRacuna(Racun racun)
        {
            Console.WriteLine("Id racuna: " + racun.id + " Datum izdavanja: " + racun.DatumIzdavanja.ToString("d M yyyy"));
            foreach (var proizvod in racun.proizvodi)
            {
                Console.WriteLine("\tNaziv: " + proizvod.Naziv + " Kolicina: " + proizvod.Kolicina);
            }
        }

        public static void IspisSvihRacuna(List<Racun> racuni)
        {
            Console.Clear();
            var articleIndex = 0;
            int userChoice = -1;
            Console.WriteLine("Ispis svih racuna");
            foreach (var racun in racuni)
            {
                Console.WriteLine("Id " + racun.id + " Datum i vrijeme " + racun.DatumIzdavanja.ToString("d MM yyyy") + " Ukupni iznos: " + RacunCijena(racun));
            }

            do
            {
                Console.WriteLine("Za vise informacija unesite id racuna. 0 za izlaz");
                userChoice = int.Parse(Console.ReadLine());
                Console.Clear();
                articleIndex = racuni.FindIndex(x => x.id == userChoice);
                if (userChoice == 0) return;
                if (articleIndex == -1)
                {
                    Console.Write($"Racun s id {userChoice} nije pronaden\nPritisnite bilo sto za nastavak...");
                    Console.ReadLine();
                    return;
                }
                Console.Clear();
                IspisRacuna(racuni[articleIndex]);
                RacunCijena(racuni[articleIndex]);
                Console.WriteLine("Pritisnite bilo sto za nastavak...");
                Console.ReadLine();
                break;
            } while (true);
        }

        public static double RacunCijena(Racun racun)
        {
            double sum = 0;
            foreach (var proizvod in racun.proizvodi)
            {
                sum += proizvod.Kolicina * proizvod.Cijena;
            }

            return sum;
        }
    }
}
