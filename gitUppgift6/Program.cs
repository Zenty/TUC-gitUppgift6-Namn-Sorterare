using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace NameSorter
{
    // Our Startup class where we store our methods that should run without being called at the start of the program.
    public class Startup
    {
        public int Initiate() // Our initiate method where we display all available program options.
        {
            Console.ForegroundColor = ConsoleColor.DarkGray; // Adding some color to the console text.
            Console.WriteLine("Choose an option:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("1. ");
            Console.ResetColor();
            Console.Write("Add new name to list.\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("2. ");
            Console.ResetColor();
            Console.Write("Search for a name in the list.\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("3. ");
            Console.ResetColor();
            Console.Write("Display list of names.\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("4. ");
            Console.ResetColor();
            Console.Write("Sort list of names.\n");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("5. ");
            Console.ResetColor();
            Console.Write("Exit program.\n");

            Console.ForegroundColor = ConsoleColor.DarkGreen; // Make all console input + method output green.
            string userInput = Console.ReadLine();
            if (Int32.TryParse(userInput, out int j)) // Try and parse the string into an int we can use in our switch.
            {
                return j;
            } else
            {
                return 0;
            }
        }
    }

    // Our Metoder class that includes all methods that the user can choose between.
    public class Methods
    {
        public List<string> nameList = new List<string>(); // I create a List of names for sake of using List methods like sort.

        public void AddNewPerson(string name) // A method for adding new names to my list/create new Person objects.
        {
            nameList.Add(name); // I add the name to a List for easy use.
        }
        public void FindName(string searchName) // A method for finding already existing names.
        {
            if (nameList.Contains(searchName))
            {
                Console.WriteLine($"{searchName} is in the list.\n");
            }
            else
            {
                Console.WriteLine($"{searchName} is not in the list.\n");
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
                Console.WriteLine($"{name}"); // Display name
            }
            Console.WriteLine(""); // Adding line break to the console.
        }
    }

    // Our Program Class where we run the whole program from. It's here that we call on our other classes and methods.
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup(); // We create a var to store all our methods from the class Startup.
            var methods = new Methods(); // We create a var to store all our methods from the class Metoder.

            int isFinished = 0; // Variable to keep track of when the user chooses to stop the program.
            bool isSorted = false; // Variable to keep track of if we have sorted the list.
            while (isFinished != 5)
            {
                switch (new Startup().Initiate()) // Switch to choose which method to run based on user input. 
                {
                    case 1:
                        Console.WriteLine($"\n[Option 1] Add new name:");
                        methods.AddNewPerson(Console.ReadLine());
                        Console.WriteLine(); // Adding line-break.
                        isSorted = false; // Since the list is no longer sorted if we add a new name.
                        break;
                    case 2:
                        Console.WriteLine("\n[Option 2] Enter name to search:");
                        methods.FindName(Console.ReadLine());
                        break;
                    case 3:
                        if (isSorted)
                        {
                            Console.WriteLine("\n[Option 3] Sorted list:");
                        } else
                        {
                            Console.WriteLine("\n[Option 3] Display list:");
                        }
                        methods.DisplayList();
                        break;
                    case 4:
                        methods.SortList();
                        isSorted = true;
                        Console.WriteLine($"\n[Option 4] The list has been sorted.\n");
                        break;
                    case 5:
                        isFinished = 5;
                        Console.ResetColor(); // Reset all console text color.
                        break;
                    default:
                        Console.WriteLine($"\nInvalid Option, try again.\n");
                        break;
                }
            }
        }
    }
}