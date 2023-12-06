using System;
using SimpleClassLibrary;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть кількість працівників:");
        int n;

        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Будь ласка, введіть коректне число більше нуля.");
        }

        Worker[] workers = CreateWorkersArray(n);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Оберіть завдання:");
            Console.WriteLine("1. Вивести інформацію про одного працівника");
            Console.WriteLine("2. Вивести інформацію про всіх працівників");
            Console.WriteLine("3. Показати стаж роботи працівника");
            Console.WriteLine("4. Перевірити, чи працівник проживає близько до головного офісу");
            Console.WriteLine("5. Вивести розмір премії кожного співробітника у всіх вказаних валютах");
            Console.WriteLine("6. Вихід");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 6))
            {
                Console.WriteLine("Будь ласка, введіть коректне число від 1 до 6.");
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Введіть прізвище працівника: ");
                    string lastName = Console.ReadLine();

                    Worker foundWorker = FindWorkerByLastName(workers, lastName);

                    if (foundWorker != null)
                    {
                        DisplayWorkerInfo(foundWorker);
                    }
                    else
                    {
                        Console.WriteLine($"Працівник із прізвищем {lastName} не знайдений.");
                    }
                    break;

                case 2:
                    DisplayAllWorkersInfo(workers);
                    break;

                case 3:
                    Console.Write("Введіть прізвище працівника:");
                    string lastNameForExperience = Console.ReadLine();

                    Worker workerForExperience = FindWorkerByLastName(workers, lastNameForExperience);

                    if (workerForExperience != null)
                    {
                        DisplayWorkExperience(workerForExperience);
                    }
                    else
                    {
                        Console.WriteLine($"Працівник із прізвищем {lastNameForExperience} не знайдений.");
                    }
                    break;

                case 4:
                    Console.Write("Введіть прізвище працівника:");
                    string lastNameForLiving = Console.ReadLine();

                    Worker workerForLiving = FindWorkerByLastName(workers, lastNameForLiving);

                    if (workerForLiving != null)
                    {
                        DisplayLivingInfo(workerForLiving);
                    }
                    else
                    {
                        Console.WriteLine($"Працівник із прізвищем {lastNameForLiving} не знайдений.");
                    }
                    break;

                case 5:
                    DisplayBonusInfo(workers);
                    break;

                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static Worker[] CreateWorkersArray(int n)
    {
        Worker[] workers = new Worker[n];

        for (int i = 0; i < n; i++)
        {
            Console.Clear();
            Console.WriteLine($"Введіть інформацію для працівника #{i + 1}:");
            workers[i] = Worker.CreateWorkerFromConsole();
        }

        return workers;
    }

    static void DisplayWorkerInfo(Worker worker)
    {
        Console.Clear();
        Console.WriteLine(worker.ToString());
        Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
        Console.ReadLine();
    }

    static void DisplayAllWorkersInfo(Worker[] workers)
    {
        Console.Clear();
        foreach (var worker in workers)
        {
            Console.WriteLine(worker.ToString());
            Console.WriteLine("------------------------------");
        }

        Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
        Console.ReadLine();
    }

    static void DisplayWorkExperience(Worker worker)
    {
        Console.Clear();
        int monthsOfWork = worker.GetWorkExperience();
        Console.WriteLine($"Стаж роботи працівника: {monthsOfWork} місяців");
        Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
        Console.ReadLine();
    }

    static void DisplayLivingInfo(Worker worker)
    {
        Console.Clear();
        bool livesNearMainOffice = worker.LivesNotFarFromTheMainOffice();
        Console.WriteLine($"Проживає близько до головного офісу: {livesNearMainOffice}");
        Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
        Console.ReadLine();
    }

    static void DisplayBonusInfo(Worker[] workers)
    {
        Console.Clear();
        Console.WriteLine("Виберіть одиниці вимірювання (грн, долари, євро):");
        string currency = Console.ReadLine();

        foreach (var worker in workers)
        {
            Console.WriteLine($"Розмір премії для працівника {worker.FullName} у {currency}: {worker.GetBonusInfoInCurrency(currency)}");
            Console.WriteLine("------------------------------");
        }

        Console.WriteLine("\nНатисніть Enter, щоб продовжити...");
        Console.ReadLine();
    }

    static Worker FindWorkerByLastName(Worker[] workers, string lastName)
    {
        return Array.Find(workers, worker => worker.FullName.Split(' ').Last().Equals(lastName, StringComparison.OrdinalIgnoreCase));
    }
}
