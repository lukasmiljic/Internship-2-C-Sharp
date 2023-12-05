namespace zad2
{

    public class Worker
    {
        public string FullName;
        public DateTime DateOfBirth;

        public Worker(string fullName, DateTime dateOfBirth)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
        }
    }
    public class Workers
    {
        public static void WorkersMenu(List<Worker> workers)
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
                    InputWorkers(workers);
                    break;

                case 2:
                    DeleteWorkers(workers);
                    break;

                case 3:
                    EditWorker(workers);
                    break;

                case 4:
                    PrintWorkers(workers);
                    break;

                default:
                    break;
            }
        }
        public static void InputWorkers(List<Worker> workers)
        {
            string fullName ;
            DateTime dateOfBirth;
            bool inputSuccess;

            do
            {
                Console.Clear();

                Console.WriteLine("Unesite podatke o radniku");

                Console.Write("Ime Prezime: ");
                fullName = Console.ReadLine();

                Console.Write("Datum rodenja [yyyy/mm/dd]: ");
                inputSuccess = DateTime.TryParse(Console.ReadLine(), out dateOfBirth);
                if (!inputSuccess)
                {
                    Console.WriteLine("Greska prilikom unosa datuma");
                    Helper.PressAnything();
                    continue;
                }

                workers.Add(new Worker(fullName, dateOfBirth));
                Console.WriteLine($"Uspjesno unesen radnik {fullName} roden {dateOfBirth}");

                Helper.PressAnything();
                break;
            } while (true);
        }
        public static void DeleteWorkers(List<Worker> workers)
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Brisanje radnika");
                Console.WriteLine("1 - Po imenu");
                Console.WriteLine("2 - Koji imaju vise od 65 godina");
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
                    DeleteWorkerName(workers);
                    break;

                case 2:
                    DeleteWorkerAge(workers);
                    break;

                default:
                    break;
            }
        }
        public static void DeleteWorkerName(List<Worker> workers)
        {
            var fullName = "";
            var foundPersonFlag = false;
            Console.WriteLine("Brisanje radnika po imenu");
            Console.WriteLine("Unesite ime i prezime radnika: ");
            fullName = Console.ReadLine();
            foundPersonFlag = workers.Any(x => x.FullName.ToLower() == fullName.ToLower());
            if (foundPersonFlag == false)
            {
                Console.Write($"Radnik s imenom {fullName} nije pronaden");
                Helper.PressAnything();
                return;
            }
            Console.WriteLine($"Radnik {fullName} je pronaden i biti ce obrisan");
            if (Helper.AreYouSure() == 0)
            {
                Console.WriteLine("Brisanje radnika otkazano");
                Helper.PressAnything();
                return;
            }

            workers.Remove(workers.Find(x => x.FullName.ToLower() == fullName.ToLower()));

            Helper.PressAnything();
            return;
        }
        public static void DeleteWorkerAge(List<Worker> workers)
        {
            var today = DateTime.Today;
            var count = workers.Count(x => (today.Year - x.DateOfBirth.Year) >= 65);
            Console.WriteLine("Brisanje svih radnika starijih od 65 godina");
            if (count == 0)
            {
                Console.WriteLine("Nije pronaden nijedan radnik stariji od 65 godina");
                Helper.PressAnything();
                return;
            }
            Console.WriteLine($"Za izbrisat {count} radnika starijih od 65");
            if (Helper.AreYouSure() == 0)
            {
                Console.WriteLine("Brisanje radnika otkazano");
                Helper.PressAnything();
                return;
            }

            workers.RemoveAll(x => (today.Year - x.DateOfBirth.Year) >= 65);

            Console.WriteLine("Uspjesno obrisani radnici");
            Helper.PressAnything();
        }
        public static void EditWorker(List<Worker> workers)
        {
            var fullName = "";
            var workerIndex = 0;
            var userChoice = -1;
            Console.WriteLine("Uredivanje radnika po imenu");
            Console.WriteLine("Unesite ime i prezime radnika: ");
            fullName = Console.ReadLine();

            workerIndex = workers.FindIndex(x => x.FullName.ToLower() == fullName.ToLower());
            if (workerIndex == -1)
            {
                Console.Write($"Radnik s imenom {fullName} nije pronaden");
                Helper.PressAnything();
                return;
            }

            if (Helper.AreYouSure() == 0)
            {
                Console.WriteLine("Uredivanje radnika otkazano");
                Helper.PressAnything();
                return;
            }

            do
            {
                Console.Clear();
                Console.WriteLine("Sta zelite promjeniti:");
                Console.WriteLine("1 - Ime i prezime");
                Console.WriteLine("2 - Datum rodenja");
                Console.WriteLine("0 - Povratak na glavni meni");
                if (!Helper.ValidateInput(ref userChoice, 2))
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
                        var novoImePrezime = "";
                        Console.WriteLine("Unesite novo ime radnika: ");
                        novoImePrezime = Console.ReadLine();
                        workers[workerIndex].FullName = novoImePrezime;
                        break;

                    case 2:
                        var noviDatum = new DateTime();
                        Console.WriteLine("Unesite novi datum rodenja: ");
                        noviDatum = DateTime.Parse(Console.ReadLine());
                        workers[workerIndex].DateOfBirth = noviDatum;
                        break;

                    default:
                        break;
                }
                break;
            } while (true);
            Console.WriteLine("Uspjesno spremljene promjene");
            Helper.PressAnything();
        }
        public static void PrintWorkers(List<Worker> workers)
        {
            var userChoice = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("Ispis radnika");
                Console.WriteLine("1 - Ispis");
                Console.WriteLine("2 - Ispis(rodendan ovaj mjesec)");
                Console.WriteLine("0 - Nazad na glavni izbornik");

                if (!Helper.ValidateInput(ref userChoice, 7))
                {
                    Helper.ErrorMessage(0);
                    continue;
                }

                Console.Clear();

                switch (userChoice)
                {
                    case 1:
                        foreach (var worker in workers)
                        {
                            Console.WriteLine(worker.FullName + " " + worker.DateOfBirth.ToString("d.M.yyyy"));
                        }
                        break;

                    case 2:
                        DateTime today = DateTime.Now;
                        foreach (var radnik in workers)
                        {
                            if (radnik.DateOfBirth.Month == today.Month)
                            {
                                Console.WriteLine(radnik.FullName + " " + radnik.DateOfBirth.ToString("d.M.yyyy"));
                            }
                        }
                        Helper.PressAnything();
                        break;

                    default:
                        break;
                }

            } while (true);
        }
    }
}
