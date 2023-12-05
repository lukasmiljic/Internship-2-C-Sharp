using System;
using System.Collections.Generic;
using System.Linq;

namespace DUMP___zad2._4
{
    public class Artikal
    {
        public string Naziv;
        public int Kolicina;
        public double Cijena;
        public DateTime RokTrajanja;

        public Artikal(string Naziv, int Kolicina, double Cijena, DateTime RokTrajanja)
        {
            this.Naziv = Naziv;
            this.Kolicina = Kolicina;
            this.Cijena = Cijena;
            this.RokTrajanja = RokTrajanja;
        }
    }
    public class Artikli
    {
        public static void ArtikliMeni(List<Artikal> artikli, List<Racun> racuni)
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
                    UnosArtikla(artikli);
                    break;

                case 2:
                    BrisanjeArtikla(artikli);
                    break;

                case 3:
                    UredivanjeArtikala(artikli);
                    break;

                case 4:
                    IspisiArtikala(artikli, racuni);
                    break;

                default:
                    break;
            }
        }
        public static void UnosArtikla(List<Artikal> artikli)
        {
            var naziv = "";
            var kolicina = 0;
            var cijena = 0.0;
            DateTime datumIsteka = new DateTime(1, 1, 1);
            var inputSuccess = false;

            do
            {
                Console.Clear();

                Console.WriteLine("Unesite podatke o artiklu");

                Console.Write("Naziv: ");
                naziv = Console.ReadLine();

                Console.Write("Količina: ");
                inputSuccess = int.TryParse(Console.ReadLine(), out kolicina);
                if (!inputSuccess)
                {
                    Console.WriteLine("Greska pri unosu kolicine!");
                    Helper.PressAnything();
                    continue;
                }

                Console.Write("Cijena: ");
                inputSuccess = double.TryParse(Console.ReadLine(), out cijena);
                if (!inputSuccess)
                {
                    Console.WriteLine("Greska pri unosu cijene!");
                    Helper.PressAnything();
                    continue;
                }

                Console.Write("Datum isteka [yyyy/mm/dd]: ");
                inputSuccess = DateTime.TryParse(Console.ReadLine(), out datumIsteka);
                if (!inputSuccess)
                {
                    Console.WriteLine("Greska prilikom unosa datuma");
                    Helper.PressAnything();
                    continue;
                }

                artikli.Add(new Artikal(naziv, kolicina, cijena, datumIsteka));

                Console.WriteLine($"Uspjesno unesen proizvod pod nazivom {naziv}, " +
                    $"s cijenom {cijena} EUR, kolicinom {kolicina} i " +
                    $"datum isteka valjanosti od {datumIsteka.ToString("d/M/yyyy")}");

                Helper.PressAnything();
                break;
            } while (true);
        }
        public static void BrisanjeArtikla(List<Artikal> artikli)
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Brisanje artikala");
                Console.WriteLine("1 - Po imenu");
                Console.WriteLine("2 - Kojima je istekao rok trajanja");
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
                    BrisanjeArtiklaNaziv(artikli);
                    break;

                case 2:
                    BrisanjeArtiklaDatum(artikli);
                    break;

                default:
                    break;
            }
        }
        public static void BrisanjeArtiklaNaziv(List<Artikal> artikli)
        {
            var naziv = "";
            var foundArticleFlag = false;
            Console.WriteLine("Brisanje artikla po nazivu");
            Console.WriteLine("Unesite naziv artikla: ");
            naziv = Console.ReadLine();
            foundArticleFlag = artikli.Any(x => x.Naziv == naziv);
            if (foundArticleFlag == false)
            {
                Console.Write($"Artikal s nazivom {naziv} nije pronaden");
                Helper.PressAnything();
                return;
            }
            Console.WriteLine($"Arikal {naziv} je pronaden i biti ce obrisan");
            if (Helper.Sigurni() == 0)
            {
                Console.WriteLine("Brisanje artikla otkazano");
                Helper.PressAnything();
                return;
            }

            artikli.Remove(artikli.Find(x => x.Naziv == naziv));

            Console.WriteLine("Uspjesno izbrisan artikal");
            Helper.PressAnything();
            return;
        }
        public static void BrisanjeArtiklaDatum(List<Artikal> artikli)
        {
            var today = DateTime.Today;
            var count = artikli.Count(x => (today > x.RokTrajanja));
            Console.WriteLine("Brisanje svih artikala kojima je istekao datum");
            if (count == 0)
            {
                Console.WriteLine("Nije pronaden nijedan artikal kojem je istekao rok trajanja\nPritisnite bilo sto za nastavak...");
                Console.ReadLine();
                return;
            }
            Console.WriteLine($"Za izbrisat {count} artikala");
            if (Helper.Sigurni() == 0)
            {
                Console.WriteLine("Brisanje artikla otkazan");
                Helper.PressAnything();
                return;
            }

            artikli.RemoveAll(x => today > x.RokTrajanja);

            Console.WriteLine("Uspjesno obrisani artikli");
            Helper.PressAnything();
        }
        public static void UredivanjeArtikala(List<Artikal> artikli)
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Uredivanje artikala");
                Console.WriteLine("1 - Zasebno");
                Console.WriteLine("2 - Popusti/poskupljenja");
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
                    UrediArtikal(artikli);
                    break;

                case 2:
                    Popusti(artikli);
                    break;

                default:
                    break;
            }
        }
        public static void UrediArtikal(List<Artikal> artikli)
        {
            var naziv = "";
            var articleIndex = 0;
            var userChoice = -1;

            Console.WriteLine("Uredivanje artikla po nazivu");

            Console.WriteLine("Unesite naziv artikla: ");
            naziv = Console.ReadLine();

            articleIndex = artikli.FindIndex(x => x.Naziv == naziv);
            if (articleIndex == -1)
            {
                Console.Write($"Artikal s nazivom {naziv} nije pronaden");
                Helper.PressAnything();
                return;
            }

            if (Helper.Sigurni() == 0)
            {
                Console.WriteLine("Uredivanje artikla otkazano");
                Helper.PressAnything();
                return;
            }

            var temp = artikli[articleIndex];

            do
            {
                Console.Clear();
                Console.WriteLine("Sta zelite promjeniti:");
                Console.WriteLine("1 - Naziv");
                Console.WriteLine("2 - Kolicinu");
                Console.WriteLine("3 - Cijenu");
                Console.WriteLine("4 - Rok trajanja");
                Console.WriteLine("0 - Povratak na glavni meni");
                if (!Helper.ValidateInput(ref userChoice, 4))
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
                        var noviNaziv = "";
                        Console.WriteLine("Unesite novi naziv artikla: ");
                        noviNaziv = Console.ReadLine();
                        Console.WriteLine($"Stari naziv {artikli[articleIndex].Naziv} novi naziv {noviNaziv}");
                        Helper.PressAnything();
                        temp.Naziv = noviNaziv;
                        break;

                    case 2:
                        var novaKolicina = 0;
                        Console.WriteLine("Unesite novu kolicinu: ");
                        novaKolicina = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Stara kolicina {artikli[articleIndex].Kolicina} nova kolicina {novaKolicina}");
                        temp.Kolicina = novaKolicina;
                        Helper.PressAnything();
                        break;

                    case 3:
                        var novaCijena = 0.0;
                        Console.WriteLine("Unesite novu cijenu: ");
                        novaCijena = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Stara cijena {artikli[articleIndex].Cijena} nova cijena {novaCijena}");
                        temp.Cijena = novaCijena;
                        Helper.PressAnything();
                        break;

                    case 4:
                        var noviDatum = new DateTime();
                        Console.WriteLine("Unesite novi datum valjanosti: ");
                        noviDatum = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine($"Stara cijena {artikli[articleIndex].RokTrajanja.ToString("dd MM yyyy")} novi datum {noviDatum.ToString("dd MM yyyy")}");
                        temp.RokTrajanja = noviDatum;
                        Helper.PressAnything();
                        break;

                    default:
                        break;
                }
                break;
            } while (true);

            artikli[articleIndex] = temp;
            Helper.PressAnything();
            return;

        }
        public static void Popusti(List<Artikal> artikli)
        {
            var postotak = 0.0;

            Console.WriteLine("Uredivanje artikla popusti/poskupljenja");
            Console.WriteLine("Unesite iznos popusta/poskupljenja: ");
            postotak = double.Parse(Console.ReadLine());

            if (Helper.Sigurni() == 0)
            {
                Console.WriteLine("Uredivanje artikla otkazano");
                return;
            }

            foreach (var item in artikli)
            {
                item.Cijena *= postotak;
            }

            Helper.PressAnything();
            return;
        }
        public static void IspisiArtikala(List<Artikal> artikli, List<Racun> racuni)
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

                if (!Helper.ValidateInput(ref userChoice, 7))
                {
                    Helper.ErrorMessage(0);
                    continue;
                }

                Console.Clear();
                var temp = artikli;
                Console.WriteLine(String.Format("{0,15}{1,10}{2,10}{3,20}", "Naziv", "Cijena", "Kolicina", "Datum valjanosti"));

                switch (userChoice)
                {
                    case 1:
                        IspisArtikala(artikli);
                        break;

                    case 2:
                        
                        temp.Sort((x,y) => x.Naziv.CompareTo(y.Naziv));
                        IspisArtikala(temp);
                        break;

                    case 3:
                        temp.Sort((x, y) => x.RokTrajanja.CompareTo(y.RokTrajanja));
                        IspisArtikala(temp);
                        break;

                    case 4:
                        temp.Sort((x, y) => x.RokTrajanja.CompareTo(y.RokTrajanja));
                        temp.Reverse();
                        IspisArtikala(temp);
                        break;


                    case 5:
                        temp.Sort((x, y) => x.Kolicina.CompareTo(y.Kolicina));
                        IspisArtikala(temp);
                        break;

                    case 6:
                        Najprodavaniji(artikli, racuni);
                        break;

                    case 7:
                        fuj(artikli, racuni);
                        break;

                    case 0:
                        Console.Clear();
                        break;

                    default:
                        break;
                }
                temp.Clear();
                break;
            } while (true);
            Helper.PressAnything();
        }
        public static void IspisArtikala(List<Artikal> artikli)
        {
            foreach (var artikal in artikli)
            { 
                Console.WriteLine(String.Format("{0,15}{1,10}{2,10}{3,20}", artikal.Naziv, artikal.Cijena, artikal.Kolicina, artikal.RokTrajanja.ToString("d/M/yyyy")));
            }
        }
        public static void Najprodavaniji(List<Artikal> artikli, List<Racun> racuni)
        {
            var najprodavanijiCounter = 0;
            var najprodavanijiNaziv = "";

            Console.Clear();

            foreach (var racun in racuni)
            {
                foreach (var proizvod in racuni[racuni.IndexOf(racun)].proizvodi)
                {
                    if (proizvod.Kolicina > najprodavanijiCounter)
                    {
                        najprodavanijiCounter = proizvod.Kolicina;
                        najprodavanijiNaziv = proizvod.Naziv;
                    }
                }
            }

            Console.WriteLine($"Najprodavaniji proizvod je {najprodavanijiNaziv} prodan {najprodavanijiCounter} puta");
        }
        public static void fuj(List<Artikal> artikli, List<Racun> racuni)
        {
            var najprodavanijiCounter = racuni[0].proizvodi[0].Kolicina;
            var najprodavanijiNaziv = "";

            Console.Clear();
            foreach (var racun in racuni)
            {
                foreach (var proizvod in racuni[racuni.IndexOf(racun)].proizvodi)
                {
                    if (proizvod.Kolicina < najprodavanijiCounter)
                    {
                        najprodavanijiCounter = proizvod.Kolicina;
                        najprodavanijiNaziv = proizvod.Naziv;
                    }
                }
            }

            Console.WriteLine($"Najmanje prodavani proizvod je {najprodavanijiNaziv} prodan {najprodavanijiCounter} puta");
        }
    }
}