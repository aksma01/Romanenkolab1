using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Employee
    {
        private string lastName;
        private string firstName;
        private string position;
        private int experience;

        public Employee(string lastName, string firstName)
        {
            this.lastName = lastName;
            this.firstName = firstName;
        }

        public void SetPosition(string position)
        {
            this.position = position;
        }

        public void SetExperience(int experience)
        {
            this.experience = experience;
        }

        public double CalculateSalary()
        {

            double baseSalary = 0;
            switch (position.ToLower())
            {
                case "менеджер":
                    baseSalary = 30000;
                    break;
                case "розробник":
                    baseSalary = 40000;
                    break;

                default:
                    baseSalary = 25000;
                    break;
            }

            double experienceBonus = experience * 1000;
            double salary = baseSalary + experienceBonus;

            return salary;
        }

        public double CalculateTax()
        {

            double salary = CalculateSalary();
            double tax = 0.2 * salary;
            return tax;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Інформація про співробітника:");
            Console.WriteLine($"Прізвище: {lastName}");
            Console.WriteLine($"Ім'я: {firstName}");
            Console.WriteLine($"Посада: {position}");
            Console.WriteLine($"Оклад: {CalculateSalary()} грн");
            Console.WriteLine($"Податковий збір: {CalculateTax()} грн");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введіть прізвище співробітника:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введіть ім'я співробітника:");
            string firstName = Console.ReadLine();

            Employee employee = new Employee(lastName, firstName);

            Console.WriteLine("Введіть посаду співробітника:");
            string position = Console.ReadLine();
            employee.SetPosition(position);

            Console.WriteLine("Введіть стаж співробітника (в роках):");
            int experience = int.Parse(Console.ReadLine());
            employee.SetExperience(experience);

            employee.PrintInfo();

            Console.ReadLine();
        }
    }
}

