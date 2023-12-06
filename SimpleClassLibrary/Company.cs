namespace SimpleClassLibrary
{
    public class Company
    {
        public string Name { get; set; }
        public string MainOfficeCity { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public bool IsFullTimeEmployee { get; set; }

        public Company(string name, string mainOfficeCity, string position, double salary, bool isFullTimeEmployee)
        {
            Name = name;
            MainOfficeCity = mainOfficeCity;
            Position = position;
            Salary = salary;
            IsFullTimeEmployee = isFullTimeEmployee;
        }

        public override string ToString()
        {
            return $"Компанія: {Name}\nГоловний офіс: {MainOfficeCity}\nПосада: {Position}\nЗарплата: {Salary}\nПовний робочий день: {IsFullTimeEmployee}";
        }
    }
}
