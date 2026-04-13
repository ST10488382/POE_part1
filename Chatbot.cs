using System;
using System.Threading;

namespace POE_part1
{//start of namespace
    public class Chatbot
    {//start of class

        //global variable to store the username
        private string username;

        //array of keywords the chatbot can recognise
        private string[] keywords = { "how are you", "purpose", "what can i ask", "password", "phishing", "safe browsing" };

        //array of cybersecurity responses matching the keywords 
        private string[] responses =
        {
            "I am doing great thank you for asking! I am always ready to help you stay safe online.",
            "My purpose is to help you learn about cybersecurity and how to stay safe online.",
            "You can ask me about: password safety, phishing, and safe browsing.",
            "Use strong passwords with letters numbers and symbols. Never reuse the same password. Consider using a password manager.",
            "Phishing is when attackers trick you into giving your personal info. Always check the senders email and never click on suspicious links.",
            "Always check for https in the website address. Avoid clicking on pop up ads. Keep your browser updated."
        };

        public Chatbot(string username)
        {//start of constructor

            //assign the username passed in to the global variable
            this.username = username;

        }//end of constructor

        public void start()
        {//start of method
            //New keyword

            //display chatbot instructions
            Console.WriteLine("\n--- chatbot started ---");
            Console.WriteLine("Type your question below. Type 'exit' to quit.");
            Console.WriteLine(new string('-', 40));

            //loop to keep the chatbot running
            while (true)
            {
                //display user prompt
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"\n{username}: ");
                Console.ResetColor();

                //read user input and convert to lowercase
                string question = Console.ReadLine();

                //check if the input is empty
                if (string.IsNullOrWhiteSpace(question))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("MAX: I didn't quite understand that. Could you rephrase?");
                    Console.ResetColor();
                    continue;
                }

                //convert to lowercase for comparison
                question = question.ToLower();

                //check if user wants to exit
                if (question == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("MAX: Goodbye! Stay safe online.");
                    Console.ResetColor();
                    break;
                }

                //add a small delay to simulate thinking
                Thread.Sleep(500);

                //check each keyword against the user input
                bool found = false;

                for (int i = 0; i < keywords.Length; i++)
                {
                    if (question.Contains(keywords[i]))
                    {
                        //display matching response
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"MAX: {responses[i]}");
                        Console.ResetColor();
                        found = true;
                        break;
                    }
                }

                //if no keyword matched display default response
                if (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("MAX: I didn't quite understand that. Could you rephrase?");
                    Console.WriteLine("Try asking about: password, phishing, or safe browsing.");
                    Console.ResetColor();
                }

            }//end of while loop

        }//end of method

    }//end of class
}//end of namespace