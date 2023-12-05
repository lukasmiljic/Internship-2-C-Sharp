using DUMP___zad2._4;
using System;
using System.Collections.Generic;

namespace DUMP___zad2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>
            {
                new Article("Cokolada", 5, 1.0, new DateTime(2023, 2, 2)),
                new Article("Bonbone", 10, 2.0, new DateTime(2023, 2, 2)),
                new Article("Kruh", 15, 4.0, new DateTime(2024, 2, 2)),
                new Article("Piletina", 20, 8.0, new DateTime(2024, 2, 2)),
                new Article("Mlijeko", 25, 16.0, new DateTime(2024, 2, 2))
            };
            var workers = new List<Worker>
            {
                new Worker("Ante Antic", new DateTime(2000, 1, 1)),
                new Worker("Bante Bantic", new DateTime(1950, 1, 1))
            };
            var receipts = new List<Receipt>()
            {
                new Receipt(++Receipts.ReceiptID, new DateTime(2023, 10, 1), new List<(string Name, int Amount, double Price)>{("Keks", 2, 3.0), ("Voda", 1, 2.0) })
            };


            int userChoice = -1;
            while (userChoice != 0)
            {
                userChoice = Helper.MainMenu();
                switch (userChoice)
                {
                    case 1:
                        Articles.ArticleMenu(articles, receipts);
                        break;

                    case 2:
                        Workers.WorkersMenu(workers);
                        break;

                    case 3:
                        Receipts.ReceiptMenu(receipts, articles);
                        break;

                    case 4:
                        Statistics.StatisticsMenu(receipts, articles);
                        break;

                    case 0:
                        if (Helper.QuitApplication() == 0) userChoice = -1;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}