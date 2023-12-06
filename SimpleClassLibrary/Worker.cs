using System;

namespace SimpleClassLibrary
{
    public class Worker
    {
        public string FullName { get; set; }
        public string HomeCity { get; set; }
        public DateTime StartDate { get; set; }
        public Company WorkPlace { get; set; }
        private double bonus;

        public double Bonus
        {
            get { return bonus; }
            private set { bonus = value; }
        }

        public int GetWorkExperience()
        {
            DateTime currentDate = DateTime.Now;
            int monthsOfWork = (currentDate.Year - StartDate.Year) * 12 + currentDate.Month - StartDate.Month;
            return monthsOfWork;
        }

        public bool LivesNotFarFromTheMainOffice()
        {
            return HomeCity.Equals(WorkPlace.MainOfficeCity, StringComparison.OrdinalIgnoreCase);
        }

        public void SetBonus()
        {
            Console.WriteLine("Введіть розмір премії:");

            while (!double.TryParse(Console.ReadLine(), out bonus) || bonus < 0)
            {
                Console.WriteLine("Будь ласка, введіть коректний розмір премії більше нуля.");
            }
        }

        public (double inUAH, double inUSD, double inEUR) GetBonusInfo()
        {
            return (Bonus, Bonus * 0.02727, Bonus * 0.025);
        }

        public string GetBonusInfoInCurrency(string currency)
        {
            var bonusInfo = GetBonusInfo();
            switch (currency.ToLower())
            {
                case "грн":
                    return $"{bonusInfo.inUAH} грн";
                case "долари":
                    return $"{bonusInfo.inUSD} USD";
                case "євро":
                    return $"{bonusInfo.inEUR} EUR";
                default:
                    return "невідома валюта";
            }
        }


        public void DisplayBonusInfo()
        {
            var bonusInfo = GetBonusInfo();
            Console.WriteLine($"Розмір премії в гривнях: {bonusInfo.inUAH}");
            Console.WriteLine($"Розмір премії в доларах: {bonusInfo.inUSD}");
            Console.WriteLine($"Розмір премії в євро: {bonusInfo.inEUR}");
        }

        public override string ToString()
        {
            return $"Працівник: {FullName}\nМісто проживання: {HomeCity}\nДата початку роботи: {StartDate}\n{WorkPlace}";
        }

        public static Worker CreateWorkerFromConsole()
        {
            Console.Write("Прізвище та ініціали: ");
            string fullName = Console.ReadLine();

            Console.Write("Місто проживання: ");
            string homeCity = Console.ReadLine();

            DateTime startDate;

            Console.Write("Дата початку роботи (рік-місяць-день): ");

            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Будь ласка, введіть коректну дату у форматі (рік-місяць-день):");
            }

            Console.Write("Інформація про компанію:\nНазва компанії: ");
            string companyName = Console.ReadLine();

            Console.Write("Місто головного офісу компанії: ");
            string mainOfficeCity = Console.ReadLine();

            Console.Write("Посада працівника: ");
            string position = Console.ReadLine();

            double salary;

            Console.Write("Зарплата: ");

            while (!double.TryParse(Console.ReadLine(), out salary) || salary <= 0)
            {
                Console.WriteLine("Будь ласка, введіть коректну зарплатню більше нуля.");
            }

            bool isFullTime;

            Console.Write("Працює на повний робочий день (true/false): ");

            while (!bool.TryParse(Console.ReadLine(), out isFullTime))
            {
                Console.WriteLine("Будь ласка, введіть коректне значення (true або false):");
            }

            Company company = new Company(companyName, mainOfficeCity, position, salary, isFullTime);

            Worker newWorker = new Worker { FullName = fullName, HomeCity = homeCity, StartDate = startDate, WorkPlace = company };
            newWorker.SetBonus(); // Доданий виклик методу для встановлення розміру премії

            return newWorker;
        }

    }
}
