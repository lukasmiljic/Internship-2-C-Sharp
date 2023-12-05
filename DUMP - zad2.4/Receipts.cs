using System;
using System.Collections.Generic;

namespace DUMP___zad2._4
{
    public class Receipt
    {
        public int id;
        public DateTime IssuingDate;
        public List<(string Name, int Amount, double Price)> receiptArticles;

        public Receipt(int id, DateTime issuingDate, List<(string Name, int Amount, double Price)> receiptArticles)
        {
            this.id = id;
            IssuingDate = issuingDate;
            this.receiptArticles = receiptArticles;
        }
    }
    public class Receipts
    {
        public static int ReceiptID = 0;
        public static void ReceiptMenu(List<Receipt> receipts, List<Article> articles)
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
                    InputReceipt(receipts,articles);
                    break;

                case 2:
                    PrintAllReceipts(receipts);
                    break;

                default:
                    break;
            }
        }
        public static void InputReceipt(List<Receipt> receipts, List<Article> articles)
        {
            var Name = "";
            var Amount = 0;
            var kraj = "KRAJ";
            var articleIndex = 0;
            List<(string Name, int Amount, double Price)> proizvodi = new List<(string Name, int Amount, double Price)>();

            Console.Clear();
            Console.WriteLine("Unos novog racuna\nUnesite KRAJ kao Name proizvoda za prekid unosa");
            Articles.PrintArticle(articles);
            do
            {
                Console.Write("Name proizvoda: ");
                Name = Console.ReadLine();
                if (Name == kraj)
                {
                    if (Helper.AreYouSure() == 1)
                    {
                        break;
                    }
                    else continue;
                }
                articleIndex = articles.FindIndex(x => x.Name == Name);
                if (articleIndex == -1)
                {
                    Console.Write($"Artikal s Nameom {Name} nije pronaden");
                    Helper.PressAnything();
                    return;
                }
                Console.Write("Amount: ");
                Amount = int.Parse(Console.ReadLine());
                if (Amount > articles[articleIndex].Amount)
                {
                    Console.WriteLine("Greska pri unosu kolicine.");
                    Helper.PressAnything();
                    return;
                }
                proizvodi.Add((Name, Amount, articles[articleIndex].Price));
            } while (true);

            Console.WriteLine("Zelite li nastaviti s ovim racunom");

            var tempRacun = new Receipt(++ReceiptID, DateTime.Today, proizvodi);
            PrintReceipt(tempRacun);

            if(Helper.AreYouSure() == 1)
            {
                articles[articleIndex].Amount -= Amount;
                receipts.Add(tempRacun);
                Console.WriteLine("Uspjesno upisan racun");
                Helper.PressAnything();
            }
        }
        public static void PrintReceipt(Receipt receipt)
        {
            Console.WriteLine("Id racuna: " + receipt.id + " Datum izdavanja: " + receipt.IssuingDate.ToString("d M yyyy"));
            foreach (var proizvod in receipt.receiptArticles)
            {
                Console.WriteLine("\tName: " + proizvod.Name + " Amount: " + proizvod.Amount);
            }
        }
        public static void PrintAllReceipts(List<Receipt> receipt)
        {
            Console.Clear();
            var articleIndex = 0;
            int userChoice = -1;
            Console.WriteLine("Ispis svih racuna");
            foreach (var racun in receipt)
            {
                Console.WriteLine("Id " + racun.id + " Datum i vrijeme " + racun.IssuingDate.ToString("d MM yyyy") + " Ukupni iznos: " + ReceiptPrice(racun));
            }

            do
            {
                Console.WriteLine("Za vise informacija unesite id racuna. 0 za izlaz");
                userChoice = int.Parse(Console.ReadLine());
                Console.Clear();
                articleIndex = receipt.FindIndex(x => x.id == userChoice);
                if (userChoice == 0) return;
                if (articleIndex == -1)
                {
                    Console.Write($"Racun s id {userChoice} nije pronaden");
                    Helper.PressAnything();
                    return;
                }
                Console.Clear();
                PrintReceipt(receipt[articleIndex]);
                ReceiptPrice(receipt[articleIndex]);
                Helper.PressAnything();
                break;
            } while (true);
        }
        public static double ReceiptPrice(Receipt receipt)
        {
            double sum = 0;
            foreach (var proizvod in receipt.receiptArticles)
            {
                sum += proizvod.Amount * proizvod.Price;
            }

            return sum;
        }
    }
}
