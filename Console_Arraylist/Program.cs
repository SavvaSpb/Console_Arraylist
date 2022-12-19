using System;  
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Console_Arraylist
{
    
    class Program
    {
        static void Main(string[] args)
        {

            //IList personA = new MyArrayList(3);
            //personA.Add("Sasha");
            //personA.Add("Raul");
            //personA.Add("Vitya");
            //personA.Add("Lanik");
            //personA.Add("Pasha");

            //Console.WriteLine(" List ");
            //Print(personA);

            //string myString = "Sasha";
            //int myIndex = personA.IndexOf(myString);
            //Console.WriteLine("\n The first occurrence of \"{0}\" is at index {1}.", myString, myIndex);

            //personA.Remove("Lanik");

            //Console.WriteLine("\n List_2 ");
            //Print(personA);

            //string[] personNEW =
            //{
            //"Sofia",
            //"Marta",
            //"Olga",
            //"Sveta",
            //"Dasha"
            //};

            //personA.CopyTo(personNEW, 0);

            //Console.WriteLine("\n List_NEW ");

            //Print(personNEW);


            //personA.Clear();

            //personA.Sort();

            MyArrayList EmployeesList = new MyArrayList(3);

            EmployeesList.Add("Slava");
            EmployeesList.Add("Anton");
            EmployeesList.Add("Anton");

            Console.WriteLine("\n MyList ");

            Print(EmployeesList);

            Console.Read();

        }
        private static void Print(IEnumerable myList)
        {
            foreach (Object o in myList)
            {
                Console.WriteLine($"Name is: {o}");
            }
        }
    }
}