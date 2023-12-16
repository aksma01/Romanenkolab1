using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Converter
    {
        private double usdRate;
        private double eurRate;
        private double plnRate;

        public Converter(double usd, double eur, double pln)
        {
            usdRate = usd;
            eurRate = eur;
            plnRate = pln;
        }

        public double ConvertToUSD(double uahAmount)
        {
            return uahAmount / usdRate;
        }

        public double ConvertToEUR(double uahAmount)
        {
            return uahAmount / eurRate;
        }

        public double ConvertToPLN(double uahAmount)
        {
            return uahAmount / plnRate;
        }

        public double ConvertFromUSD(double usdAmount)
        {
            return usdAmount * usdRate;
        }

        public double ConvertFromEUR(double eurAmount)
        {
            return eurAmount * eurRate;
        }

        public double ConvertFromPLN(double plnAmount)
        {
            return plnAmount * plnRate;
        }
    }

    class Program
    {
        static void Main()
        {

            Converter converter = new Converter(20, 30, 10);

            Console.WriteLine("Оберіть тип операції:");
            Console.WriteLine("1 - Конвертація з гривні в іноземну валюту");
            Console.WriteLine("2 - Конвертація з іноземної валюти в гривню");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Введіть суму в гривнях: ");
                double uahAmount = double.Parse(Console.ReadLine());

                Console.WriteLine("Оберіть валюту для конвертації:");
                Console.WriteLine("1 - USD");
                Console.WriteLine("2 - EUR");
                Console.WriteLine("3 - PLN");
                int currencyChoice = int.Parse(Console.ReadLine());

                double result = 0;
                switch (currencyChoice)
                {
                    case 1:
                        result = converter.ConvertToUSD(uahAmount);
                        Console.WriteLine($"Результат конвертації: {result} USD");
                        break;
                    case 2:
                        result = converter.ConvertToEUR(uahAmount);
                        Console.WriteLine($"Результат конвертації: {result} EUR");
                        break;
                    case 3:
                        result = converter.ConvertToPLN(uahAmount);
                        Console.WriteLine($"Результат конвертації: {result} PLN");
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір валюти.");
                        break;
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Оберіть валюту для конвертації:");
                Console.WriteLine("1 - USD");
                Console.WriteLine("2 - EUR");
                Console.WriteLine("3 - PLN");
                int currencyChoice = int.Parse(Console.ReadLine());

                Console.Write("Введіть суму в обраній валюті: ");
                double foreignAmount = double.Parse(Console.ReadLine());

                double result = 0;
                switch (currencyChoice)
                {
                    case 1:
                        result = converter.ConvertFromUSD(foreignAmount);
                        Console.WriteLine($"Результат конвертації: {result} UAH");
                        break;
                    case 2:
                        result = converter.ConvertFromEUR(foreignAmount);
                        Console.WriteLine($"Результат конвертації: {result} UAH");
                        break;
                    case 3:
                        result = converter.ConvertFromPLN(foreignAmount);
                        Console.WriteLine($"Результат конвертації: {result} UAH");
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір валюти.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неправильний вибір операції.");
            }
        }
    }

}
