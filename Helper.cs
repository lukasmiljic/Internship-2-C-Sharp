﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DUMP___zad2._4
{
    public class Helper
    {
        public static int GlavniMeni()
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

            return userChoice;
        }
        public static void ErrorMessage(int errorCode)
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
        public static bool ValidateInput(ref int userChoice, int maxValue)
        {
            var inputSuccess = false;
            inputSuccess = int.TryParse(Console.ReadLine(), out userChoice);
            if (inputSuccess == false || userChoice > maxValue || userChoice < 0) return false;
            else return true;
        }
        public static int Izlaz()
        {
            Console.Clear();
            if (Sigurni() == 1)
            {
                Console.WriteLine("Zbogom...");
                Thread.Sleep(1000);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public static int Sigurni()
        {
            do
            {
                //Console.Clear();
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
    }
}
