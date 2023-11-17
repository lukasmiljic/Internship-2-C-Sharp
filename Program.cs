using System;
using System.Threading;

namespace DUMP___zad2._1
{
    internal class Program
    {
        public static string adminLozinka = "1234";
        public static int id_racuna = 0;
        static void Main(string[] args)
        {
            GlavniMeni();
        }

        //helper fje
        static void GlavniMeni()
        {
            var userChoice = -1;
            
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Artikli");
                Console.WriteLine("2 - Radnici");
                Console.WriteLine("3 - Računi");
                Console.WriteLine("4 - Statistika");
                Console.WriteLine("0 - Izlaz iz aplikacije");

                if (!ValidateInput(ref userChoice, 4))
                {
                    ErrorMessage(0);
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
        static void ErrorMessage(int errorCode) 
        {
            Console.Clear();

            switch (errorCode)
            {
                case 0:
                    Console.WriteLine("Greska pri odabiru! Molimo ponovno unesite vrijednost");
                    break;

                case 1:
                    Console.WriteLine("Greska pri unosu lozinke! Pokusajte ponovno.");
                    break;

                default:
                    break;
            }

            Console.WriteLine("Unesite bilo sto za nastavak...");
            Console.ReadLine();
        }
        static bool ValidateInput(ref int userChoice, int maxValue)
        {
            var inputSuccess = false;
            inputSuccess = int.TryParse(Console.ReadLine(), out userChoice);
            if (inputSuccess == false || userChoice > maxValue || userChoice < 0) return false;
            else return true;
        }
        static void Izlaz()
        {
            //do
            //{
            //    Console.Clear();
            //    char userChoice;
            //    Console.Write("Jeste li sigurni [y/n]: ");
            //    userChoice = char.Parse(Console.ReadLine());
            //    if (userChoice == 'y') 
            //    {
            //        Console.Clear();
            //        Console.WriteLine("Zbogom...");
            //        Thread.Sleep(1000);
            //        return;
            //    }
            //    else if (userChoice == 'n')
            //    {
            //        GlavniMeni();
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Unesite ili y ili n.\nUnesite bilo sto za nastavak...");
            //        Console.ReadLine();
            //    }
            //} while (true);   
            if (Sigurni() == 1)
            {
                Console.WriteLine("Zbogom...");
                Thread.Sleep(1000);
                return;
            }
            else
            {
                GlavniMeni();
                return;
            }
        }
        static int Sigurni()
        {
            do
            {
                Console.Clear();
                char userChoice;
                Console.Write("Jeste li sigurni [y/n]: ");
                userChoice = char.Parse(Console.ReadLine());
                if (userChoice == 'y')
                {
                    Console.Clear();
                    return 1;
                }
                else if (userChoice == 'n')
                {
                    Console.Clear();
                    return 0;
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

            do
            {
                Console.Clear();
                Console.WriteLine("Artikli");
                Console.WriteLine("1 - Unos");
                Console.WriteLine("2 - Brisanje");
                Console.WriteLine("3 - Uredivanje");
                Console.WriteLine("4 - Ispis");
                Console.WriteLine("0 - Nazad na glavni izbornik");

                if (!ValidateInput(ref userChoice, 4))
                {
                    ErrorMessage(0);
                    continue;
                }
                break;
            } while (true);

            switch (userChoice)
            {
                case 1:
                    UnosArtikla();
                    break;

                case 2:
                    BrisanjeArtikla();
                    break;

                case 3:
                    UredivanjeArtikala();
                    break;

                case 4:
                    IspisiArtikala();
                    break;

                case 0:
                    GlavniMeni();
                    break;

                default:
                    break;
            }
        }
        static void UnosArtikla()
        {
            var naziv = "\0";
            var kolicina = 0;
            var cijena = 0.0;
            DateTime datumIsteka = new DateTime(1, 1, 1);
            var inputSuccess = false;

            do
            {
                Console.Clear();

                Console.WriteLine("Unesite podatke o artiklu");

                Console.Write(String.Format("{0,30}", "Naziv: "));
                naziv = Console.ReadLine();

                Console.Write(String.Format("{0,30}", "Količina: "));
                inputSuccess = int.TryParse(Console.ReadLine(), out kolicina);
                if (!inputSuccess)
                {
                    Console.WriteLine("Greska pri unosu kolicine!\n" +
                        "Pritisnite bilo sto kako bi pokusali ponovno...");
                    continue;
                }

                Console.Write(String.Format("{0,30}", "Cijena: "));
                inputSuccess = double.TryParse(Console.ReadLine(), out cijena);
                if (!inputSuccess)
                {
                    Console.WriteLine("Greska pri unosu cijene!\nPritisnite bilo sto kako bi pokusali ponovno...");
                    continue;
                }

                Console.Write(String.Format("{0,30}", "Datum isteka [yyyy/mm/dd]: "));
                inputSuccess = DateTime.TryParse(Console.ReadLine(),out datumIsteka);
                if (!inputSuccess)
                {
                    Console.WriteLine("Greska prilikom unosa datuma\nPritisnite bilo sto kako bi pokusali ponovno...");
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine($"Uspjesno unesen proizvod pod nazivom {naziv}, " +
                    $"s cijenom {cijena} EUR, kolicinom {kolicina} i " +
                    $"datum isteka valjanosti od {datumIsteka.ToString("dd/mm/yyyy")}");

                Console.WriteLine("Pritisnite bilo sta za povratak na glavni izbornik...");
                Console.ReadLine();
                GlavniMeni();
                break;
            } while (true);
        }
        static void BrisanjeArtikla()
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Brisanje artikala");
                Console.WriteLine("1 - Po imenu");
                Console.WriteLine("2 - Kojima je istekao rok trajanja");
                Console.WriteLine("0 - Nazad na glavni izbornik");

                if (!ValidateInput(ref userChoice, 2))
                {
                    ErrorMessage(0);
                    continue;
                }
                break;
            } while (true);
            switch (userChoice)
            {
                case 1:
                    BrisanjeArtiklaNaziv();
                    break;

                case 2:
                    BrisanjeArtiklaDatum();
                    break;

                case 0:
                    GlavniMeni();
                    break;

                default:
                    break;
            }
        }
        static void BrisanjeArtiklaNaziv()
        {
            var naziv = "\0";
            Console.WriteLine("Brisanje artikla po nazivu");
            Console.WriteLine("Unesite naziv artikla: ");
            naziv = Console.ReadLine();
            //pokusat pronaci artikal s odgovarajucim nazivom
            //if exists false write artikal sa nazivom naziv nije pronaden
            //else
            //jeste li sigurni da zelite obrisati artikal y/n
            if (Sigurni() == 0)
            {
                Console.WriteLine("Brisanje artikla otkazano\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                GlavniMeni();
            }
            //izbrisat artikal s odgovorajucim nazivom
            Console.WriteLine("Pritisnite bilo sto za nastavak...");
            Console.ReadLine();
            GlavniMeni();
        }
        static void BrisanjeArtiklaDatum()
        {
            Console.WriteLine("Brisanje svih artikala kojima je istekao datum");
            if (Sigurni() == 0)
            {
                Console.WriteLine("Brisanje artikla otkazano\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                GlavniMeni();
            }

            //obrisat sve artikle s datumom manjim od trenutnog datuma
        }
        static void UredivanjeArtikala()
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Uredivanje artikala");
                Console.WriteLine("1 - Zasebno");
                Console.WriteLine("2 - Popusti/poskupljenja");
                Console.WriteLine("0 - Nazad na glavni izbornik");

                if (!ValidateInput(ref userChoice, 2))
                {
                    ErrorMessage(0);
                    continue;
                }
                break;
            } while (true);
            switch (userChoice)
            {
                case 1:
                    UrediArtikal();
                    break;

                case 2:
                    Popusti();
                    break;

                case 0:
                    GlavniMeni();
                    break;

                default:
                    break;
            }
        }
        static void UrediArtikal()
        {
            var naziv = "\0";
            Console.WriteLine("Uredivanje artikla po nazivu");
            Console.WriteLine("Unesite naziv artikla: ");
            naziv = Console.ReadLine();
            //pokusat pronaci artikal s odgovarajucim nazivom
            //if exists false write artikal sa nazivom naziv nije pronaden
            //else
            //jeste li sigurni da zelite urediti artikal y/n
            if (Sigurni() == 0)
            {
                Console.WriteLine("Uredivanje artikla otkazano\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                GlavniMeni();
            }
            //odabrat sta se zeli promjenit
            //promjeni
            Console.WriteLine("Pritisnite bilo sto za nastavak...");
            Console.ReadLine();
            GlavniMeni();

        }
        static void Popusti()
        {
            var postotak = 0.0;

            Console.WriteLine("Uredivanje artikla popusti/poskupljenja");
            Console.WriteLine("Unesite iznos popusa/poskupljenja: ");
            postotak = double.Parse(Console.ReadLine());
            //jeste li sigurni da zelite primjeniti popust/poskupljenje y/n
            if (Sigurni() == 0)
            {
                Console.WriteLine("Uredivanje artikla otkazano\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                GlavniMeni();
            }
            //za svaki proizvod cijena = cijena * postotak
            Console.WriteLine("Pritisnite bilo sto za nastavak...");
            Console.ReadLine();
            GlavniMeni();
        }
        static void IspisiArtikala()
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Ispis artikala");
                Console.WriteLine("1 - Ispis");
                Console.WriteLine("2 - Ispis(Sortirano po imenu)");
                Console.WriteLine("3 - Ispis(Sortirano po datumu-silazno)");
                Console.WriteLine("4 - Ispis(Sortirano po datumu-uzlazno)");
                Console.WriteLine("5 - Ispis(Sortirano po kolicni)");
                Console.WriteLine("6 - Ispis najprodavanijeg artikla");
                Console.WriteLine("7 - Ispis najmanje prodavanog artikla");
                Console.WriteLine("0 - Nazad na glavni izbornik");

                if (!ValidateInput(ref userChoice, 7))
                {
                    ErrorMessage(0);
                    continue;
                }

                Console.Clear();

                switch (userChoice)
                {
                    case 1:
                        //ispis()
                        break;

                    case 2:
                        //ime
                        break;

                    case 3:
                        //datum-silazno
                        break;

                    case 4:
                        //datum-uzlazno
                        break;

                    case 5:
                        //kolicina
                        break;

                    case 6:
                        //najprodavaniji
                        break;

                    case 7:
                        //najmanje prodavani
                        break;

                    case 0:
                        GlavniMeni();
                        break;

                    default:
                        break;
                }

            } while (true);
        }
        static void IspisSvihArtikala()
        {
            Console.WriteLine(":D");
        }

        //radnici
        static void Radnici()
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

                if (!ValidateInput(ref userChoice, 4))
                {
                    ErrorMessage(0);
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
            var ime_prezime = "\0";
            DateTime datumRodenja = new DateTime(1, 1, 1);
            var inputSuccess = false;

            do
            {
                Console.Clear();

                Console.WriteLine("Unesite podatke o artiklu");

                Console.Write(String.Format("{0,30}", "Ime Prezime: "));
                ime_prezime = Console.ReadLine();

                Console.Write(String.Format("{0,30}", "Datum rodenja [yyyy/mm/dd]: "));
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
                GlavniMeni();
                break;
            } while (true);
        }
        static void BrisanjeRadnika()
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Brisanje radnika");
                Console.WriteLine("1 - Po imenu");
                Console.WriteLine("2 - Koji imaju vise od 65 godina");
                Console.WriteLine("0 - Nazad na glavni izbornik");

                if (!ValidateInput(ref userChoice, 2))
                {
                    ErrorMessage(0);
                    continue;
                }
                break;
            } while (true);
            switch (userChoice)
            {
                case 1:
                    BrisanjeRadnikaIme();
                    break;

                case 2:
                    BrisanjeRadnikaGodine();
                    break;

                case 0:
                    GlavniMeni();
                    break;

                default:
                    break;
            }
        }
        static void BrisanjeRadnikaIme()
        {
            var ime_prezime = "\0";
            Console.WriteLine("Brisanje radnika po imenu");
            Console.WriteLine("Unesite ime i prezime radnika: ");
            ime_prezime = Console.ReadLine();
            //pokusat pronaci radnika s odgovarajucim imenom
            //if exists false write radnik sa nazivom naziv nije pronaden
            //else
            //jeste li sigurni da zelite obrisati radnika y/n
            if (Sigurni() == 0)
            {
                Console.WriteLine("Brisanje radnika otkazano\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                GlavniMeni();
            }
            //izbrisat radnika s odgovorajucim nazivom
            Console.WriteLine("Pritisnite bilo sto za nastavak...");
            Console.ReadLine();
            GlavniMeni();
        }
        static void BrisanjeRadnikaGodine()
        {
            Console.WriteLine("Brisanje svih radnika koji imaju vise od 65 godina");
            if (Sigurni() == 0)
            {
                Console.WriteLine("Brisanje artikla otkazano\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                GlavniMeni();
            }

            //obrisat sve radnike za koje vrijedi current.date - radnik.date >= 65
        }
        static void UredivanjeRadnika()
        {
            var ime_prezime = "\0";
            Console.WriteLine("Uredivanje artikla po imenu");
            Console.WriteLine("Unesite ime i prezime radnika: ");
            ime_prezime = Console.ReadLine();
            //pokusat pronaci radnika s odgovarajucim nazivom
            //if exists false write radnik sa nazivom naziv nije pronaden
            //else
            //jeste li sigurni da zelite urediti radnika y/n
            if (Sigurni() == 0)
            {
                Console.WriteLine("Uredivanje radnika otkazano\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                GlavniMeni();
            }
            //odabrat sta se zeli promjenit
            //promjeni
            Console.WriteLine("Pritisnite bilo sto za nastavak...");
            Console.ReadLine();
            GlavniMeni();
        }
        static void IspisiRadnika()
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Ispis artikala");
                Console.WriteLine("1 - Ispis");
                Console.WriteLine("2 - Ispis(rodendan ovaj mjesec)");
                Console.WriteLine("0 - Nazad na glavni izbornik");

                if (!ValidateInput(ref userChoice, 7))
                {
                    ErrorMessage(0);
                    continue;
                }

                Console.Clear();

                switch (userChoice)
                {
                    case 1:
                        //ispis svih
                        break;

                    case 2:
                        //ispis rodendan radnik.date.month == current month
                        break;

                    case 0:
                        GlavniMeni();
                        break;

                    default:
                        break;
                }

            } while (true);
        }

        //racuni
        static void Racuni()    
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Unos novog racuna");
                Console.WriteLine("2 - Ispis");
                Console.WriteLine("0 - Povratak na glavni meni");

                if (!ValidateInput(ref userChoice, 2))
                {
                    ErrorMessage(0);
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
            var naziv = "";
            var kolicina = 0;
            var kraj = "KRAJ";
            //lista racun by ref se spremaju artikli

            Console.WriteLine("Unos novog racuna\nUnesite KRAJ za prekid unosa");
            //IspisSvihArtikala()
            do
            {
                Console.Write("Naziv proizvoda: ");
                naziv = Console.ReadLine();
                if (naziv == kraj)
                {
                    if (Sigurni() == 1)
                    {
                        break;
                    }
                    else continue;
                }
                Console.WriteLine("Kolicina: ");
                kolicina = int.Parse(Console.ReadLine());
                if (naziv == kraj)
                {
                    if (Sigurni() == 1)
                    {
                        break;
                    }
                    else continue;
                }
            } while (true);

            Console.Clear();
            Console.WriteLine("Zelite li nastaviti s ovim racunom");
            //ispis racuna
            //sigurni
            //promjena stanja artikala
            //dodaj datum na racun
            //dodaj id racuna i uvecaj globalnu var
        }
        static void IspisRacuna()
        {

        }

        //statistika
        static void Statistika()
        {
            var userChoice = -1;

            if (UnosLozinke() == 1) GlavniMeni();

            do
            {
                Console.Clear();
                Console.WriteLine("1 - Ukupan broj artikala u trgovini");
                Console.WriteLine("2 - Vrijednost artikala koji nisu jos prodani");
                Console.WriteLine("3 - Vrijednosti svih artikala koji su prodani");
                Console.WriteLine("4 - Stanje po mjesecima");
                Console.WriteLine("0 - Povratak na glavni meni");

                if (!ValidateInput(ref userChoice, 4))
                {
                    ErrorMessage(0);
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
                    ErrorMessage(1);
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