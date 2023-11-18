using DUMP___zad2._4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace DUMP___zad2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var artikli = new List<Artikal>
            {
                new Artikal("Cokolada", 5, 1.0, new DateTime(2023, 2, 2)),
                new Artikal("Bonbone", 10, 2.0, new DateTime(2023, 2, 2)),
                new Artikal("Kruh", 15, 4.0, new DateTime(2024, 2, 2)),
                new Artikal("Piletina", 20, 8.0, new DateTime(2024, 2, 2)),
                new Artikal("Mlijeko", 25, 16.0, new DateTime(2024, 2, 2))
            };
            var radnici = new List<Radnik>
            {
                new Radnik("Ante Antic", new DateTime(2000, 1, 1)),
                new Radnik("Bante Bantic", new DateTime(1950, 1, 1))
            };
            var racuni = new List<Racun>()
            {
                new Racun(++Racuni.id_racuna, new DateTime(2023, 10, 1), new List<(string Naziv, int Kolicina, double Cijena)>{("Keks", 2, 3.0), ("Voda", 1, 2.0) })
            };


            int userChoice = -1;
            while (userChoice != 0)
            {
                userChoice = Helper.GlavniMeni();
                switch (userChoice)
                {
                    case 1:
                        Artikli.ArtikliMeni(artikli, racuni);
                        break;

                    case 2:
                        Radnici.RadniciMeni(radnici);
                        break;

                    case 3:
                        Racuni.RacuniMeni(racuni, artikli);
                        break;

                    case 4:
                        Statistika.StatistikaMeni(racuni, artikli);
                        break;

                    case 0:
                        if (Helper.Izlaz() == 0) userChoice = -1;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}