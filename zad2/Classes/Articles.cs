namespace zad2
{
    public class Article
    {
        public string Name;
        public int Amount;
        public double Price;
        public DateTime ExpirationDate;

        public Article(string Name, int Amount, double Price, DateTime ExpirationDate)
        {
            this.Name = Name;
            this.Amount = Amount;
            this.Price = Price;
            this.ExpirationDate = ExpirationDate;
        }
    }
    public class Articles
    {
        public static void ArticleMenu(List<Article> articles, List<Receipt> racuni)
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
                    InputArticle(articles);
                    break;

                case 2:
                    DeleteArticle(articles);
                    break;

                case 3:
                    EditArticles(articles);
                    break;

                case 4:
                    PrintArticles(articles, racuni);
                    break;

                default:
                    break;
            }
        }
        public static void InputArticle(List<Article> articles)
        {
            //ako stavim deklaraciju npr kolicine u try parse dio kao u review javlja mi gresku dolje
            string Name;
            int Amount;
            double Price;
            DateTime ExpirationDate;
            bool inputSuccess;

            do
            {
                Console.Clear();

                Console.WriteLine("Unesite podatke o artiklu");

                do
                {
                    Console.Write("Name: ");
                    Name = Console.ReadLine();
                    if (Name == "")
                    {
                        Console.WriteLine("Greska! Polje Name aritkla ne moze biti prazno!");
                        Helper.PressAnything();
                        continue;
                    }
                    break;
                } while (true);

                do
                {
                    Console.Write("Količina: ");
                    inputSuccess = int.TryParse(Console.ReadLine(), out Amount);
                    if (!inputSuccess)
                    {
                        Console.WriteLine("Greska pri unosu kolicine!");
                        Helper.PressAnything();
                        continue;
                    }
                    break;
                } while (true);

                do
                {
                    Console.Write("Cijena: ");
                    inputSuccess = double.TryParse(Console.ReadLine(), out Price);
                    if (!inputSuccess)
                    {
                        Console.WriteLine("Greska pri unosu cijene!");
                        Helper.PressAnything();
                        continue;
                    }
                    break;
                } while (true);

                do
                {
                    Console.Write("Datum isteka [yyyy/mm/dd]: ");
                    inputSuccess = DateTime.TryParse(Console.ReadLine(), out ExpirationDate);
                    if (!inputSuccess)
                    {
                        Console.WriteLine("Greska prilikom unosa datuma");
                        Helper.PressAnything();
                        continue;
                    }
                    break;
                } while (true);
                
                //ovdje javlja gresku da ne postoji u trenutnom kontekstu
                articles.Add(new Article(Name, Amount, Price, ExpirationDate));

                Console.WriteLine($"Uspjesno unesen proizvod pod Nazivom {Name}, " +
                    $"s cijenom {Price} EUR, kolicinom {Amount} i " +
                    $"datum isteka valjanosti od {ExpirationDate.ToString("d/M/yyyy")}");

                Helper.PressAnything();
                break;
            } while (true);
        }
        public static void DeleteArticle(List<Article> articles)
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
                    DeleteArticleName(articles);
                    break;

                case 2:
                    DeleteArticleDate(articles);
                    break;

                default:
                    break;
            }
        }
        public static void DeleteArticleName(List<Article> articles)
        {
            var Name = "";
            var foundArticleFlag = false;

            Console.WriteLine("Brisanje artikla po nazivu");

            Console.WriteLine("Unesite naziv artikla: ");
            Name = Console.ReadLine();

            foundArticleFlag = articles.Any(x => x.Name.ToLower() == Name.ToLower());
            if (foundArticleFlag == false)
            {
                Console.Write($"Artikal s nazivom {Name} nije pronaden");
                Helper.PressAnything();
                return;
            }

            Console.WriteLine($"Artikal {Name} je pronaden i biti ce obrisan");
            if (Helper.AreYouSure() == 0)
            {
                Console.WriteLine("Brisanje artikla otkazano");
                Helper.PressAnything();
                return;
            }

            articles.Remove(articles.Find(x => x.Name == Name));

            Console.WriteLine("Uspjesno izbrisan artikal");
            Helper.PressAnything();
            return;
        }
        public static void DeleteArticleDate(List<Article> articles)
        {
            var today = DateTime.Today;
            var count = articles.Count(x => (today > x.ExpirationDate));

            Console.Clear();

            Console.WriteLine("Brisanje svih artikala kojima je istekao datum");
            if (count == 0)
            {
                Console.WriteLine("Nije pronaden nijedan artikal kojem je istekao rok trajanja");
                Helper.PressAnything();
                return;
            }
            Console.WriteLine($"Za izbrisat {count} artikala");
            if (Helper.AreYouSure() == 0)
            {
                Console.WriteLine("Brisanje artikla otkazano");
                Helper.PressAnything();
                return;
            }

            articles.RemoveAll(x => today > x.ExpirationDate);

            Console.WriteLine("Uspjesno obrisani artikli");
            Helper.PressAnything();
        }
        public static void EditArticles(List<Article> articles)
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
                    EditArticle(articles);
                    break;

                case 2:
                    Discounts(articles);
                    break;

                default:
                    break;
            }
        }
        public static void EditArticle(List<Article> articles)
        {
            var Name = "";
            var articleIndex = 0;
            var userChoice = -1;

            Console.Clear();
            Console.WriteLine("Uredivanje artikla po nazivu");

            Console.Write("Unesite naziv artikla: ");
            Name = Console.ReadLine();

            articleIndex = articles.FindIndex(x => x.Name.ToLower() == Name.ToLower());    
            if (articleIndex == -1)
            {
                Console.Write($"Artikal s nazivom {Name} nije pronaden");
                Helper.PressAnything();
                return;
            }

            if (Helper.AreYouSure() == 0)
            {
                Console.WriteLine("Uredivanje artikla otkazano");
                Helper.PressAnything();
                return;
            }

            var temp = articles[articleIndex];
            bool editing = true;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Odabrani artikal: {articles[articleIndex].Name} x{articles[articleIndex].Amount} " + 
                        $"{articles[articleIndex].Price}EUR {articles[articleIndex].ExpirationDate.ToString("d.M.yyyy")}");
                    Console.WriteLine("Sta zelite promjeniti:");
                    Console.WriteLine("1 - Name");
                    Console.WriteLine("2 - Kolicinu");
                    Console.WriteLine("3 - Cijenu");
                    Console.WriteLine("4 - Rok trajanja");
                    Console.WriteLine("0 - Zavrsetak uredivanja i povratak na glavni meni");
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
                        var newName = "";
                        Console.Write("Unesite novi naziv artikla: ");
                        newName = Console.ReadLine();
                        Console.WriteLine($"Stari Name {articles[articleIndex].Name} novi Name {newName}");
                        temp.Name = newName;
                        Helper.PressAnything();
                        break;

                    case 2:
                        var newAmount = 0;
                        Console.Write("Unesite novu kolicinu: ");
                        newAmount = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Stara Amount {articles[articleIndex].Amount} nova Amount {newAmount}");
                        temp.Amount = newAmount;
                        Helper.PressAnything();
                        break;

                    case 3:
                        var newPrice = 0.0;
                        Console.Write("Unesite novu cijenu: ");
                        newPrice = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Stara Price {articles[articleIndex].Price} nova Price {newPrice}");
                        temp.Price = newPrice;
                        Helper.PressAnything();
                        break;

                    case 4:
                        var newDate = new DateTime();
                        Console.Write("Unesite novi datum valjanosti: ");
                        newDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine($"Stara Price {articles[articleIndex].ExpirationDate.ToString("dd MM yyyy")} novi datum {newDate.ToString("dd MM yyyy")}");
                        temp.ExpirationDate = newDate;
                        Helper.PressAnything();
                        break;

                    default:
                        Console.WriteLine("Prekidanje uredivanja");
                        if (Helper.AreYouSure() == 1) editing = false;
                        else { Console.WriteLine("Prekid otkazan"); Helper.PressAnything(); }
                        break;
                }
            } while (editing);
            articles[articleIndex] = temp;
            Helper.PressAnything();
            return;

        }
        public static void Discounts(List<Article> articles)
        {
            var percentage = 0.0;

            Console.WriteLine("Uredivanje artikla popusti/poskupljenja [za popust od 23% unesite -23, za poskupljenje 23]");
            Console.WriteLine("Unesite iznos popusta/poskupljenja: ");
            percentage = double.Parse(Console.ReadLine());
            if(percentage < 0) percentage = 0 + percentage/100;
            else percentage = 1 + percentage/100;

            if (Helper.AreYouSure() == 0)
            {
                Console.WriteLine("Uredivanje artikla otkazano");
                return;
            }

            foreach (var item in articles)
            {
                item.Price *= percentage;
            }

            Helper.PressAnything();
            return;
        }
        public static void PrintArticles(List<Article> articles, List<Receipt> receipts)
        {
            var userChoice = -1;
            var printing = true;
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

                var temp = new List<Article> (articles);

                switch (userChoice)
                {
                    case 1:
                        PrintArticle(articles);
                        Helper.PressAnything();
                        break;

                    case 2:
                        
                        temp.Sort((x,y) => x.Name.CompareTo(y.Name));
                        PrintArticle(temp);
                        Helper.PressAnything();
                        break;

                    case 4:
                        temp.Sort((x, y) => x.ExpirationDate.CompareTo(y.ExpirationDate));
                        PrintArticle(temp);
                        Helper.PressAnything();
                        break;

                    case 3:
                        temp.Sort((x, y) => x.ExpirationDate.CompareTo(y.ExpirationDate));
                        temp.Reverse();
                        PrintArticle(temp);
                        Helper.PressAnything();
                        break;


                    case 5:
                        temp.Sort((x, y) => x.Amount.CompareTo(y.Amount));
                        PrintArticle(temp);
                        Helper.PressAnything();
                        break;

                    case 6:
                        MostSold(articles, receipts);
                        Helper.PressAnything();
                        break;

                    case 7:
                        LeastSold(articles, receipts);
                        Helper.PressAnything();
                        break;

                    default:
                        if (Helper.AreYouSure()==1)
                            printing = false;
                        break;
                }
                temp.Clear();
            } while (printing);
            Helper.PressAnything();
        }
        public static void PrintArticle(List<Article> articles)
        {
            Console.Clear();
            Console.WriteLine(String.Format("{0,15}{1,10}{2,10}{3,20}", "Naziv", "Cijena", "Kolicina", "Datum valjanosti"));
            foreach (var artikal in articles)
            { 
                Console.WriteLine(String.Format("{0,15}{1,10}{2,10}{3,20}", artikal.Name, artikal.Price, artikal.Amount, artikal.ExpirationDate.ToString("d/M/yyyy")));
            }
        }
        public static void MostSold(List<Article> articles, List<Receipt> receipts)
        {
            var mostSoldCounter = 0;
            var mostSoldName = "";

            Console.Clear();

            foreach (var receipt in receipts)
            {
                foreach (var article in receipts[receipts.IndexOf(receipt)].receiptArticles)
                {
                    if (article.Amount > mostSoldCounter)
                    {
                        mostSoldCounter = article.Amount;
                        mostSoldName = article.Name;
                    }
                }
            }

            Console.WriteLine($"Najprodavaniji proizvod je {mostSoldName} prodan {mostSoldCounter} puta");
        }
        public static void LeastSold(List<Article> articles, List<Receipt> receipts)
        {
            var leastSoldCounter = receipts[0].receiptArticles[0].Amount;
            var leastSoldName = "";

            Console.Clear();
            foreach (var receipt in receipts)
            {
                foreach (var article in receipts[receipts.IndexOf(receipt)].receiptArticles)
                {
                    if (article.Amount < leastSoldCounter)
                    {
                        leastSoldCounter = article.Amount;
                        leastSoldName = article.Name;
                    }
                }
            }

            Console.WriteLine($"Najmanje prodavani proizvod je {leastSoldName} prodan {leastSoldCounter} puta");
        }
    }
}