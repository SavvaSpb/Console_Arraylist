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

            //MyArrayList personA = new MyArrayList();
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


            //////////////////////////////////////////////////////////////////////////////////


            //MyList<string> employeesList = new MyList<string>() { "Alpha" };

            //employeesList.Add("Slava");
            //employeesList.Add("Anton");
            //employeesList.Add("!#424");
            //employeesList.Add("B404");
            //employeesList.Add("4JC");
            //employeesList.Add("OG");

            //Console.WriteLine("\n MyList \n");

            //Print(employeesList);



            //string myString = "Anton";
            //int myIndex = employeesList.IndexOf(myString);
            //Console.WriteLine("\n The first occurrence of \"{0}\" is at index {1}. \n", myString, myIndex);




            //employeesList.Remove("B1");

            //Console.WriteLine("\n MyList without B1_Employee \n");

            //Print(employeesList);




            //string[] personNEW =
            //{
            //"Sofia",
            //"Marta",
            //"Olga",
            //"Sveta",
            //"Dasha",
            //"Sofia",
            //"Sofia",
            //"Sofia",
            //"Sofia",
            //"Sofia",
            //};

            //Console.WriteLine("\n MyListPersonNEW employeesList_copy_to_personNEW  \n ");

            //employeesList.CopyTo(personNEW, 0);

            //Print(personNEW);




            //Console.WriteLine("\n MyList insert_index3_Zorikkk \n");

            //employeesList.Insert(3, "ZZZorikkk");

            //Print(employeesList);




            //string myStringContains = "Anton";
            //string element = " ";

            //for (int i = 0; i < employeesList.Count; i++)
            //{
            //    if (employeesList[i].Contains(myStringContains))
            //        element = employeesList[i];
            //}

            //Console.WriteLine("\n MyList contains {0} \n", element);

            ////////////////////////////////////////////////////////////////////////////////////////



            List<Person> test = new List<Person>();

            test.Add(new Person { Name = "Sam", PasportId = 18 });
            test.Add(new Person { Name = "Vlad", PasportId = 22 });
            test.Add(new Person { Name = "Yarik", PasportId = 99 });


            //test.IndexOf(new Person() { Name = "Sam", PasportId = 18 });

            Console.WriteLine(test.IndexOf(new Person() { Name = "Yarik", PasportId = 99 }));


            //ArrayList Person = new ArrayList();

            //Person.Add(new Person { Name = "Nikita", PasportId = 30 });
            //Person.Add(new Person { Name = "Volodya", PasportId = 40 });
            //Person.Add(new Person { Name = "Zeka", PasportId = 50 });

            //Console.WriteLine(Person.IndexOf(new Person() { Name = "Zeka", PasportId = 50 }));






            ///////////////////////////////////////////////////////////////////////////////////////////


            //List<string> dinosaurs = new List<string>();

            //dinosaurs.Add("Tyrannosaurus");
            //dinosaurs.Add("Amargasaurus");
            //dinosaurs.Add("Mamenchisaurus");
            //dinosaurs.Add("Brachiosaurus");
            //dinosaurs.Add("Deinonychus");
            //dinosaurs.Add("Tyrannosaurus");
            //dinosaurs.Add("Compsognathus");

            //Console.WriteLine();
            //foreach (string dinosaur in dinosaurs)
            //{
            //    Console.WriteLine(dinosaur);
            //}

            //Console.WriteLine("\nIndexOf(\"Tyrannosaurus\"): {0}",
            //    dinosaurs.IndexOf("Tyrannosaurus"));

            //Console.WriteLine("\nIndexOf(\"Tyrannosaurus\", 3): {0}",
            //    dinosaurs.IndexOf("Tyrannosaurus", 3));

            //Console.WriteLine("\nIndexOf(\"Tyrannosaurus\", 2, 2): {0}",
            //    dinosaurs.IndexOf("Tyrannosaurus", 2, 2));





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