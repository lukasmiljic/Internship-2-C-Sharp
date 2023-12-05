using System;
using System.Collections.Generic;

namespace DUMP___zad2._4
{
    public class Receipt
    {
        private int ReceiptID = 0;
        public int id;
        public DateTime IssuingDate;
        public List<(string Name, int Amount, double Price)> receiptArticles;

        public Receipt(DateTime issuingDate, List<(string Name, int Amount, double Price)> receiptArticles)
        {
            id = ++ReceiptID;
            IssuingDate = issuingDate;
            this.receiptArticles = receiptArticles;
        }
    }
    public class Receipts
    {
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
            var endFlag = "KRAJ";
            var articleIndex = 0;
            List<(string Name, int Amount, double Price)> receiptArticles = new List<(string Name, int Amount, double Price)>();

            Console.Clear();
            Console.WriteLine("Unos novog racuna\nUnesite KRAJ kao Name proizvoda za prekid unosa");
            Articles.PrintArticle(articles);
            do
            {
                Console.Write("Name proizvoda: ");
                Name = Console.ReadLine();
                if (Name == endFlag)
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
                receiptArticles.Add((Name, Amount, articles[articleIndex].Price));
            } while (true);

            Console.WriteLine("Zelite li nastaviti s ovim racunom");

            var tempReceipt = new Receipt(DateTime.Today, receiptArticles);
            PrintReceipt(tempReceipt);

            if(Helper.AreYouSure() == 1)
            {
                articles[articleIndex].Amount -= Amount;
                receipts.Add(tempReceipt);
                Console.WriteLine("Uspjesno upisan racun");
                Helper.PressAnything();
            }
        }
        public static void PrintReceipt(Receipt receipt)
        {
            Console.WriteLine("Id racuna: " + receipt.id + " Datum izdavanja: " + receipt.IssuingDate.ToString("d M yyyy"));
            foreach (var article in receipt.receiptArticles)
            {
                Console.WriteLine("\tName: " + article.Name + " Amount: " + article.Amount);
            }
        }
        public static void PrintAllReceipts(List<Receipt> receipts)
        {
            Console.Clear();
            var articleIndex = 0;
            int userChoice = -1;
            Console.WriteLine("Ispis svih racuna");
            foreach (var receipt in receipts)
            {
                Console.WriteLine("Id " + receipt.id + " Datum i vrijeme " + receipt.IssuingDate.ToString("d MM yyyy") + " Ukupni iznos: " + ReceiptPrice(receipt));
            }

            do
            {
                Console.WriteLine("Za vise informacija unesite id racuna. 0 za izlaz");
                userChoice = int.Parse(Console.ReadLine());
                Console.Clear();
                articleIndex = receipts.FindIndex(x => x.id == userChoice);
                if (userChoice == 0) return;
                if (articleIndex == -1)
                {
                    Console.Write($"Racun s id {userChoice} nije pronaden");
                    Helper.PressAnything();
                    return;
                }
                Console.Clear();
                PrintReceipt(receipts[articleIndex]);
                ReceiptPrice(receipts[articleIndex]);
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
