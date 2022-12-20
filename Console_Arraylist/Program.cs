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

            MyArrayList personA = new MyArrayList();

            personA.Add("Sasha");
            personA.Add("Raul");
            personA.Add("Vitya");
            personA.Add("Lanik");
            personA.Add("Pasha");

            Console.WriteLine("\n MyArrayList \n");
            Print(personA);

            string myString = "Sasha";
            int myIndex = personA.IndexOf(myString);
            Console.WriteLine("\n The first occurrence of \"{0}\" is at index {1}.", myString, myIndex);

            personA.Remove("Lanik");

            Console.WriteLine("\n MyArrayList without Lanik \n");
            Print(personA);

            string[] personNEW =
            {
            "Sofia",
            "Marta",
            "Olga",
            "Sveta",
            "Dasha"
            };

            personA.CopyTo(personNEW, 0);

            Console.WriteLine("\n Array personNEW, where MyArrayList copy to personNEW \n");

            Print(personNEW);

            Console.WriteLine("\n -------------------------------------------------------------- \n");


            //////////////////////////////////////////////////////////////////////////////////


            MyList<string> employeesList = new MyList<string>() { "Alpha" };

            employeesList.Add("Slava");
            employeesList.Add("Anton");
            employeesList.Add("!#424");
            employeesList.Add("B404");
            employeesList.Add("4JC");
            employeesList.Add("OG");

            Console.WriteLine("\n MyList \n");

            Print(employeesList);


            string myNewString = "Anton";
            int myNewIndex = employeesList.IndexOf(myNewString);
            Console.WriteLine("\n The first occurrence of \"{0}\" is at index {1}. \n", myNewString, myNewIndex);


            employeesList.Remove("B404");

            Console.WriteLine("\n MyList without B404_Employee \n");

            Print(employeesList);


            string[] personNEW_2 =
            {
            "Sofia",
            "Marta",
            "Olga",
            "Sveta",
            "Dasha",
            "Sofia",
            "Sofia",
            "Sofia",
            "Sofia",
            "Sofia",
            };

            Console.WriteLine("\n PersonNEW_2, where MyList employeesList copy to personNEW_2  \n ");

            employeesList.CopyTo(personNEW_2, 0);

            Print(personNEW_2);


            Console.WriteLine("\n MyList insert index_3 ZZZorikkk \n");

            employeesList.Insert(3, "ZZZorikkk");

            Print(employeesList);


            string myStringContains = "Anton";
            string element = " ";

            for (int i = 0; i < employeesList.Count; i++)
            {
                if (employeesList[i].Contains(myStringContains))
                    element = employeesList[i];
            }

            Console.WriteLine("\n MyList contains {0} \n", element);

            Console.WriteLine("\n -------------------------------------------------------------- \n");


            ////////////////////////////////////////////////////////////////////////////////////////



            List<Person> personsList = new List<Person>();

            personsList.Add(new Person { Name = "Sam", PasportId = 18 });
            personsList.Add(new Person { Name = "Vlad", PasportId = 22 });
            personsList.Add(new Person { Name = "Yarik", PasportId = 99 });

            Console.WriteLine("\n List<Person>, IndexOf Yarik \n");
            Console.WriteLine( personsList.IndexOf(new Person() { Name = "Yarik", PasportId = 99 }));

            Console.WriteLine("\n -------------------------------------------------------------- \n");


            ////////////////////////////////////////////////////////////////////////////////////////


            ArrayList Person = new ArrayList();

            Person.Add(new Person { Name = "Nikita", PasportId = 30 });
            Person.Add(new Person { Name = "Volodya", PasportId = 40 });
            Person.Add(new Person { Name = "Zeka", PasportId = 50 });

            Console.WriteLine("\n ArrayList<Person>, IndexOf Zeka \n");
            Console.WriteLine(Person.IndexOf(new Person() { Name = "Zeka", PasportId = 50 }));


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