using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_Romanenko
{
    class Adress
    {
        private string index;

        private string country;

        private string city;

        private string street;

        private string house;

        private string apartment;


        public string Index
        {
            get { return index; }
            set { index = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public string House
        {
            get { return house; }
            set { house = value; }
        }

        public string Apartment
        {
            get { return apartment; }
            set { apartment = value; }
        }

        public void InfAdress()
        {
            Console.WriteLine("Index: " + Index);
            Console.WriteLine("Country: " + Country);
            Console.WriteLine("City: " + City);
            Console.WriteLine("Street: " + Street);
            Console.WriteLine("House: " + House);
            Console.WriteLine("Apartment: " + Apartment);



        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adress myadress = new Adress();

            myadress.Index = "123";
            myadress.Country = "Україна";
            myadress.City = "Київ";
            myadress.Street = "Кургузова";
            myadress.House = "1А";
            myadress.Apartment = "112";


            myadress.InfAdress();

            Console.ReadLine();


        }
    }
}






c


