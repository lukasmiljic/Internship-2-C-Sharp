using System;
using System.Collections.Generic;
using System.Linq;

namespace DUMP___zad2._4
{

    public class Radnik
    {
        public string ImePrezime;
        public DateTime DatumRodenja;

        public Radnik(string ImePrezime, DateTime DatumRodenja)
        {
            this.ImePrezime = ImePrezime;
            this.DatumRodenja = DatumRodenja;
        }
    }
    public class Radnici
    {
        public static void RadniciMeni(List<Radnik> radnici)
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Unos radnika");
                Console.WriteLine("2 - Brisanje radnika");
                Console.WriteLine("3 - Uredivanje radnika");
                Console.WriteLine("4 - Ispis");
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
                    UnosRadnika(radnici);
                    break;

                case 2:
                    BrisanjeRadnika(radnici);
                    break;

                case 3:
                    UredivanjeRadnika(radnici);
                    break;

                case 4:
                    IspisiRadnika(radnici);
                    break;

                case 0:
                    return;

                default:
                    break;
            }
        }
        public static void UnosRadnika(List<Radnik> radnici)
        {
            var ime_prezime = "";
            DateTime datumRodenja = new DateTime(1, 1, 1);
            var inputSuccess = false;

            do
            {
                Console.Clear();

                Console.WriteLine("Unesite podatke o radniku");

                Console.Write("Ime Prezime: ");
                ime_prezime = Console.ReadLine();

                Console.Write("Datum rodenja [yyyy/mm/dd]: ");
                inputSuccess = DateTime.TryParse(Console.ReadLine(), out datumRodenja);
                if (!inputSuccess)
                {
                    Console.WriteLine("Greska prilikom unosa datuma\nPritisnite bilo sto kako bi pokusali ponovno...");
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine($"Uspjesno unesen radnik {ime_prezime} roden {datumRodenja}");

                Console.WriteLine("Pritisnite bilo sta za povratak na glavni izbornik...");
                Console.ReadLine();
                break;
            } while (true);
        }
        public static void BrisanjeRadnika(List<Radnik> radnici)
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Brisanje radnika");
                Console.WriteLine("1 - Po imenu");
                Console.WriteLine("2 - Koji imaju vise od 65 godina");
                Console.WriteLine("0 - Nazad na glavni izbornik");

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
                    BrisanjeRadnikaIme(radnici);
                    break;

                case 2:
                    BrisanjeRadnikaGodine(radnici);
                    break;

                case 0:
                    break;

                default:
                    break;
            }
        }
        public static void BrisanjeRadnikaIme(List<Radnik> radnici)
        {
            var imePrezime = "";
            var foundPersonFlag = false;
            Console.WriteLine("Brisanje radnika po imenu");
            Console.WriteLine("Unesite ime i prezime radnika: ");
            imePrezime = Console.ReadLine();
            foundPersonFlag = radnici.Any(x => x.ImePrezime == imePrezime);
            if (foundPersonFlag == false)
            {
                Console.Write($"Radnik s imenom {imePrezime} nije pronaden\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                return;
            }
            Console.WriteLine($"Radnik {imePrezime} je pronaden i biti ce obrisan");
            if (Helper.Sigurni() == 0)
            {
                Console.WriteLine("Brisanje radnika otkazano\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                return;
            }

            radnici.Remove(radnici.Find(x => x.ImePrezime== imePrezime));

            Console.WriteLine("Pritisnite bilo sto za nastavak...");
            Console.ReadLine();
            return;
        }
        public static void BrisanjeRadnikaGodine(List<Radnik> radnici)
        {
            var today = DateTime.Today;
            var count = radnici.Count(x => (today.Year - x.DatumRodenja.Year) >= 65);
            Console.WriteLine("Brisanje svih artikala kojima je istekao datum");
            if (count == 0)
            {
                Console.WriteLine("Nije pronaden nijedan radnik stariji od 65 godina\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                return;
            }
            Console.WriteLine($"Za izbrisat {count} radnika starijih od 65");
            if (Helper.Sigurni() == 0)
            {
                Console.WriteLine("Brisanje artikla otkazano\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                return;
            }

            radnici.RemoveAll(x => (today.Year - x.DatumRodenja.Year) >= 65);

            Console.WriteLine("Uspjesno obrisani radnici\nPritisnite bilo sto za nastavak...");
            Console.ReadLine();
        }
        public static void UredivanjeRadnika(List<Radnik> radnici)
        {
            var imePrezime = "";
            var radnikIndex = 0;
            var userChoice = -1;
            Console.WriteLine("Uredivanje radnika po imenu");
            Console.WriteLine("Unesite ime i prezime radnika: ");
            imePrezime = Console.ReadLine();

            radnikIndex = radnici.FindIndex(x => x.ImePrezime == imePrezime);
            if (radnikIndex == -1)
            {
                Console.Write($"Radnik s imenom {imePrezime} nije pronaden\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                return;
            }

            if (Helper.Sigurni() == 0)
            {
                Console.WriteLine("Uredivanje radnika otkazano\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                return;
            }

            do
            {
                Console.Clear();
                Console.WriteLine("Sta zelite promjeniti:");
                Console.WriteLine("1 - Ime i prezime");
                Console.WriteLine("2 - Datum rodenja");
                Console.WriteLine("0 - Povratak na glavni meni");
                if (!Helper.ValidateInput(ref userChoice, 2))
                {
                    Helper.ErrorMessage(0);
                    continue;
                }
                break;
            } while (true);

            do
            {
                switch (userChoice)
                {
                    case 1:
                        var novoImePrezime = "";
                        Console.WriteLine("Unesite novo ime radnika: ");
                        novoImePrezime = Console.ReadLine();
                        radnici[radnikIndex].ImePrezime = novoImePrezime;
                        break;

                    case 2:
                        var noviDatum = new DateTime();
                        Console.WriteLine("Unesite novi datum rodenja: ");
                        noviDatum = DateTime.Parse(Console.ReadLine());
                        radnici[radnikIndex].DatumRodenja = noviDatum;
                        break;
                    default:
                        break;
                }
                break;
            } while (true);
            Console.WriteLine("Uspjesno spremljene promjene\nPritisnite bilo sto za nastavak");
            Console.ReadLine();
        }
        public static void IspisiRadnika(List<Radnik> radnici)
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Ispis artikala");
                Console.WriteLine("1 - Ispis");
                Console.WriteLine("2 - Ispis(rodendan ovaj mjesec)");
                Console.WriteLine("0 - Nazad na glavni izbornik");

                if (!Helper.ValidateInput(ref userChoice, 7))
                {
                    Helper.ErrorMessage(0);
                    continue;
                }

                Console.Clear();

                switch (userChoice)
                {
                    case 1:
                        foreach (var radnik in radnici)
                        {
                            Console.WriteLine(radnik.ImePrezime + " " + radnik.DatumRodenja.ToString("d M yyyy"));
                        }
                        break;

                    case 2:
                        DateTime today = DateTime.Now;
                        foreach (var radnik in radnici)
                        {
                            if (radnik.DatumRodenja.Month == today.Month)
                            {
                                Console.WriteLine(radnik.ImePrezime + " " + radnik.DatumRodenja.ToString("d M yyyy"));
                            }
                        }
                        Console.WriteLine("Pritsnite bilo sto za nastavak");
                        Console.ReadLine();
                        break;

                    case 0:
                        return;

                    default:
                        break;
                }

            } while (true);
        }
    }
}
