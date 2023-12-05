using System;
using System.Collections.Generic;

namespace DUMP___zad2._4
{
    public class Statistics
    {
        public static string adminPassword = "1234";
        public static void StatisticsMenu(List<Receipt> receipts, List<Article> articles)
        {
            var userChoice = -1;

            if (InputPassword() == 1) return;

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
                    ArticleCount(articles);
                    break;

                case 2:
                    UnsoldValue(articles);
                    break;

                case 3:
                    SoldValue(receipts);
                    break;

                case 4:
                    MonthlyProfits(receipts);
                    break;

                default:
                    break;
            }
        }
        public static int InputPassword()
        {
            string inputPassword = "";
            do
            {
                Console.Clear();
                Console.Write("Unesite 0 za povratak na glavni meni\nLozinka: ");
                inputPassword = Console.ReadLine();
                if (inputPassword == "0") return 1;

                if (!ValidatePassword(inputPassword))
                {
                    Helper.ErrorMessage(1);
                    continue;
                }
                break;
            } while (true);
            return 0;
        }
        public static bool ValidatePassword(string inputPassword)
        {
            if (inputPassword == adminPassword) return true;
            return false;
        }
        public static void ArticleCount(List<Article> articles)
        {
            int sum = 0;
            Console.Clear();
            foreach (var article in articles)
            {
                sum += article.Amount;
            }
            Console.WriteLine($"U trgovini je ukupno {sum} artikala");
            Helper.PressAnything();
        }
        public static void UnsoldValue(List<Article> articles)
        {
            double sum = 0;
            Console.Clear();
            foreach (var article in articles)
            {
                sum += article.Price;
            }
            Console.WriteLine($"Vrijednost svih ne prodanih artikala je {sum}");
            Helper.PressAnything();
        }
        public static void SoldValue(List<Receipt> receipts)
        {
            double sum = 0;
            Console.Clear();
            
            foreach (var receipt in receipts)
            {
                
                foreach (var article in receipts[receipts.IndexOf(receipt)].receiptArticles)
                {
                    sum += article.Price;
                }
            }
            Console.WriteLine($"Vrijednost svih prodanih artikala je {sum}");
            Helper.PressAnything();
        }
        public static void MonthlyProfits(List<Receipt> receipts)
        {
            var year = 0;
            var month = 0;
            var pay = 0;
            var otherExpenses = 0;
            var sum = 0.0;
            Console.Clear();
            Console.WriteLine("Stanje po mjescima");
            Console.Write("Godina:");
            year = int.Parse(Console.ReadLine());
            Console.Write("Mjesec:");
            month = int.Parse(Console.ReadLine());
            Console.WriteLine("Placa: ");
            pay = int.Parse(Console.ReadLine());
            Console.WriteLine("Ostali troskovi: ");
            otherExpenses=int.Parse(Console.ReadLine());
            foreach (var receipt in receipts)
            {
                if (receipt.IssuingDate.Year == year && receipt.IssuingDate.Month == month)
                {
                    foreach (var proizvod in receipts[receipts.IndexOf(receipt)].receiptArticles)
                    {
                        sum += proizvod.Price;
                    }
                }
            }

            Console.WriteLine($"Ukupna zarada je {sum*1/3-pay-otherExpenses}");
            Helper.PressAnything();
        }
    }
}
