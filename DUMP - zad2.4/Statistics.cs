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
            string unesenaLozinka = "";
            do
            {
                Console.Clear();
                Console.Write("Unesite 0 za povratak na glavni meni\nLozinka: ");
                unesenaLozinka = Console.ReadLine();
                if (unesenaLozinka == "0") return 1;

                if (!ValidatePassword(unesenaLozinka))
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
            foreach (var artikal in articles)
            {
                sum += artikal.Amount;
            }
            Console.WriteLine($"U trgovini je ukupno {sum} artikala");
            Helper.PressAnything();
        }
        public static void UnsoldValue(List<Article> articles)
        {
            double sum = 0;
            Console.Clear();
            foreach (var artikal in articles)
            {
                sum += artikal.Price;
            }
            Console.WriteLine($"Vrijednost svih ne prodanih artikala je {sum}");
            Helper.PressAnything();
        }
        public static void SoldValue(List<Receipt> articles)
        {
            double sum = 0;
            Console.Clear();
            
            foreach (var racun in articles)
            {
                
                foreach (var proizvod in articles[articles.IndexOf(racun)].receiptArticles)
                {
                    sum += proizvod.Price;
                }
            }
            Console.WriteLine($"Vrijednost svih prodanih artikala je {sum}");
            Helper.PressAnything();
        }
        public static void MonthlyProfits(List<Receipt> articles)
        {
            var godina = 0;
            var mjesec = 0;
            var placa = 0;
            var ostaliTroskovi = 0;
            var ukupno = 0.0;
            Console.Clear();
            Console.WriteLine("Stanje po mjescima");
            Console.Write("Godina:");
            godina = int.Parse(Console.ReadLine());
            Console.Write("Mjesec:");
            mjesec = int.Parse(Console.ReadLine());
            Console.WriteLine("Placa: ");
            placa = int.Parse(Console.ReadLine());
            Console.WriteLine("Ostali troskovi: ");
            ostaliTroskovi=int.Parse(Console.ReadLine());
            foreach (var racun in articles)
            {
                if (racun.IssuingDate.Year == godina && racun.IssuingDate.Month == mjesec)
                {
                    foreach (var proizvod in articles[articles.IndexOf(racun)].receiptArticles)
                    {
                        ukupno += proizvod.Price;
                    }
                }
            }

            Console.WriteLine($"Ukupna zarada je {ukupno*1/3-placa-ostaliTroskovi}");
            Helper.PressAnything();
        }
    }
}
