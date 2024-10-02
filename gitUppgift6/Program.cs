using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace NameSorter
{
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

    }

    public class Metoder
    {
        public Dictionary<string, Person> persons = new Dictionary<string, Person>(); // I create a dictionary to store my Person objects, in case I want more properties than name in the future.
        public List<string> nameList = new List<string>(); // I create a List of names for sake of using List methods like sort.

        public void AddNewPerson(string name) // A method for adding new names to my list/create new Person objects.
        {
            persons.Add(name, new Person(name)); // I create a new Person object in case I need more properties in the future.
            nameList.Add(name); // I add the name to a List for easy use.
        }
        public void FindName() // A method for finding already existing names.
        {
            Console.WriteLine("\nEnter name to search:");
            string searchName = Console.ReadLine();

            if (nameList.Contains(searchName))
            {
                Console.WriteLine($"{searchName} is in the list.");
            }
            else
            {
                Console.WriteLine($"{searchName} is not in the list.");
            }
        }

        public void SortList() // A method for sorting our list of names.
        {
            nameList.Sort();
        }

        public void DisplayList() // A method for displaying all names from my list.
        {
            foreach (var name in nameList)
            {
                Console.WriteLine(name); // Display name
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var methods = new Metoder(); // We create a var to store all our methods from the class Metoder.
 
            methods.AddNewPerson("Anna"); // Add a new Person.
            methods.AddNewPerson("John"); // Add a new Person.
            methods.AddNewPerson("Alice"); // Add a new Person.

            Console.WriteLine("Original list:");
            methods.DisplayList(); // Display the list of names.

            methods.SortList(); // Sort the list
            Console.WriteLine("\nSorted list:");
            methods.DisplayList(); // Display the list of names after it has been sorted.

            methods.FindName(); // We call for the .FindName method.

            Console.ReadKey();


        }
    }
}