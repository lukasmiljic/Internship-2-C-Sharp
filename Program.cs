using System;
using System.Threading;

namespace DUMP___zad2._1
{
    internal class Program
    {
        public static string adminLozinka = "1234";
        static void Main(string[] args)
        {
            GlavniMeni();
        }
        static void GlavniMeni()
        {
            var userChoice = -1;
            var inputSuccess = false;

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Artikli");
                Console.WriteLine("2 - Radnici");
                Console.WriteLine("3 - Računi");
                Console.WriteLine("4 - Statistika");
                Console.WriteLine("0 - Izlaz iz aplikacije");

                inputSuccess = int.TryParse(Console.ReadLine(), out userChoice);
                if (inputSuccess == false || userChoice > 4 || userChoice < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Greska pri odabiru! Molimo ponovno unesite vrijednost\nUnesite bilo sto za nastavak...");
                    Console.ReadLine();
                    continue;
                }
                break;
            } while (true);

            switch (userChoice)
            {
                case 1:
                    Artikli();
                    break;

                case 2:
                    Radnici();
                    break;

                case 3:
                    Racuni();
                    break;

                case 4:
                    Statistika();
                    break;

                case 0:
                    Izlaz();
                    break;

                default:
                    break;
            }
        }

        static void Izlaz()
        {
            do
            {
                Console.Clear();
                char userChoice;
                Console.Write("Jeste li sigurni da zelite izaci iz aplikacije [y/n]: ");
                userChoice = char.Parse(Console.ReadLine());
                if (userChoice == 'y') 
                {
                    Console.Clear();
                    Console.WriteLine("Zbogom...");
                    Thread.Sleep(1000);
                    return;
                }
                else if (userChoice == 'n')
                {
                    GlavniMeni();
                    break;
                }
                else
                {
                    Console.WriteLine("Unesite ili y ili n.\nUnesite bilo sto za nastavak...");
                    Console.ReadLine();
                }
            } while (true);   
        }

        //artikli
        static void Artikli()
        {
            var userChoice = -1;
            var inputSuccess = false;

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Brisanje artikala");
                Console.WriteLine("2 - Popusti");
                Console.WriteLine("3 - Ispisi");
                Console.WriteLine("0 - Nazad na glavni izbornik");

                inputSuccess = int.TryParse(Console.ReadLine(), out userChoice);
                if (inputSuccess == false || userChoice > 3 || userChoice < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Greska pri odabiru! Molimo ponovno unesite vrijednost\nUnesite bilo sto za nastavak...");
                    Console.ReadLine();
                    continue;
                }
                break;
            } while (true);

            switch (userChoice)
            {
                case 1:
                    Brisanje();
                    break;

                case 2:
                    Popusti();
                    break;

                case 3:
                    IspisiArtikala();
                    break;

                case 0:
                    GlavniMeni();
                    break;

                default:
                    break;
            }
        }

        static void Brisanje()
        {

        }

        static void Popusti()
        {

        }

        static void IspisiArtikala()
        {

        }

        //radnici
        static void Radnici()
        {
            var userChoice = -1;
            var inputSuccess = false;

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Unos radnika");
                Console.WriteLine("2 - Brisanje radnika");
                Console.WriteLine("3 - Uredivanje radnika");
                Console.WriteLine("4 - Ispis");
                Console.WriteLine("0 - Povratak na glavni meni");

                inputSuccess = int.TryParse(Console.ReadLine(), out userChoice);
                if (inputSuccess == false || userChoice > 3 || userChoice < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Greska pri odabiru! Molimo ponovno unesite vrijednost\nUnesite bilo sto za nastavak...");
                    Console.ReadLine();
                    continue;
                }
                break;
            } while (true);

            switch (userChoice)
            {
                case 1:
                    UnosRadnika();
                    break;

                case 2:
                    BrisanjeRadnika();
                    break;

                case 3:
                    UredivanjeRadnika();
                    break;

                case 4:
                    IspisiRadnika();
                    break;

                case 0:
                    GlavniMeni();
                    break;

                default:
                    break;
            }
        }

        static void UnosRadnika()
        {

        }

        static void BrisanjeRadnika()
        {

        }

        static void UredivanjeRadnika()
        {

        }

        static void IspisiRadnika()
        {

        }

        //racuni
        static void Racuni()
        {
            var userChoice = -1;
            var inputSuccess = false;

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Unos novog racuna");
                Console.WriteLine("2 - Ispis");
                Console.WriteLine("0 - Povratak na glavni meni");

                inputSuccess = int.TryParse(Console.ReadLine(), out userChoice);
                if (inputSuccess == false || userChoice > 2 || userChoice < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Greska pri odabiru! Molimo ponovno unesite vrijednost\nUnesite bilo sto za nastavak...");
                    Console.ReadLine();
                    continue;
                }
                break;
            } while (true);

            switch (userChoice)
            {
                case 1:
                    UnosRacuna();
                    break;

                case 2:
                    IspisRacuna();
                    break;

                case 0:
                    GlavniMeni();
                    break;

                default:
                    break;
            }
        }

        static void UnosRacuna()
        {

        }

        static void IspisRacuna()
        {

        }

        //statistika
        static void Statistika()
        {
            var userChoice = -1;
            var inputSuccess = false;

            if (UnosLozinke() == 1) GlavniMeni();

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Ukupan broj artikala u trgovini");
                Console.WriteLine("2 - Vrijednost artikala koji nisu jos prodani");
                Console.WriteLine("3 - Vrijednosti svih artikala koji su prodani");
                Console.WriteLine("4 - Stanje po mjesecima");
                Console.WriteLine("0 - Povratak na glavni meni");



                inputSuccess = int.TryParse(Console.ReadLine(), out userChoice);
                if (inputSuccess == false || userChoice > 4 || userChoice < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Greska pri odabiru! Molimo ponovno unesite vrijednost\nUnesite bilo sto za nastavak...");
                    Console.ReadLine();
                    continue;
                }
                break;
            } while (true);

            switch (userChoice)
            {
                case 1:
                    UkupnoRacuni();
                    break;

                case 2:
                    VrijednostNeprodanih();
                    break;

                case 3:
                    VrijednostProdanih();
                    break;

                case 4:
                    StanjeMjeseci();
                    break;

                case 0:
                    GlavniMeni();
                    break;

                default:
                    break;
            }
        }

        static int UnosLozinke()
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
                    Console.Clear();
                    Console.WriteLine("Greska pri unosu lozinke! Pokusajte ponovno.\nUnesite bilo sto za nastavak...");
                    Console.ReadLine();
                    continue;
                }
                break;
            } while (true);
            return 0;
}

        static bool ProvjeraLozinke(string unesenaLozinka)
        {
            if (unesenaLozinka == adminLozinka) return true;
            return false;
        }

        static void UkupnoRacuni()
        {

        }

        static void VrijednostNeprodanih()
        {

        }

        static void VrijednostProdanih()
        {

        }

        static void StanjeMjeseci()
        {

        }
    }
}