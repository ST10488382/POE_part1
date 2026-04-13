using System;
using System.Text.RegularExpressions;
namespace POE_part1
{//start of namespace
    public class Greeting
    {//start of class
        //global variable to store the username
        public string username = string.Empty;
        public void getname()
        {//start of method
            Console.WriteLine("\n--- security verification ---");
            Console.Write("Enter your name: ");
            username = Console.ReadLine();
            //loop to keep asking until a valid name is entered
            while (true)
            {
                //check if the name is empty
                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("This field cannot be empty. Please enter a name.");
                    username = Console.ReadLine();
                    continue;
                }
                //check if the name is less than 3 characters
                if (username.Length < 3)
                {
                    Console.WriteLine("Name must be at least 3 characters long. Please enter a valid name.");
                    username = Console.ReadLine();
                    continue;
                }
                //check if the name contains only letters
                if (!Regex.IsMatch(username, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("Name must contain only letters. Please enter a valid name.");
                    username = Console.ReadLine();
                    continue;
                }
                //if all checks pass break out of the loop
                break;
            }
            //get the current hour to display correct greeting
            int currenthour = DateTime.Now.Hour;
            string salutation = currenthour < 12 ? "Good morning" : currenthour < 18 ? "Good afternoon" : "Good evening";
            //display welcome message with the username
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n{salutation}, {username}! Welcome to the Cybersecurity Awareness Bot.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"I am MAX your cybersecurity assistant. How can i help you today?");
            Console.ResetColor();
        }//end of method
    }//end of class
}//end of namespace