using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace NameSorter
{
    class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>(); // I create a list holding only names for the sake of String & List methods that doesn't work when the List contains objects.
            List<Person> persons = new List<Person>(); // I create a list containing all our person objects.
            persons.Add(new Person("Anna")); // Add a new Person object.
            persons.Add(new Person("John")); // Add a new Person object.
            persons.Add(new Person("Alice")); // Add a new Person object.
            foreach (Person person in persons) // For each Person object we have, we add each Person's name to the list.
            {
                names.Add(person.Name);
            }

            Console.WriteLine("Original list:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            names.Sort();
            Console.WriteLine("\nSorted list:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nEnter name to search:");
            string searchName = Console.ReadLine();
            if (names.Contains(searchName))
            {
                Console.WriteLine($"{searchName} is in the list.");
            }
            else
            {
                Console.WriteLine($"{searchName} is not in the list.");
            }
            Console.ReadKey();

        }
    }
}