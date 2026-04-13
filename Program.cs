namespace POE_part1
{//start of namespace
    public class Program
    {//start of class
        static void Main(string[] args)
        {//start of main
            //creating an instance of the display class
            //the constructor will play audio and show ascii art
            new Display();
            //creating an instance of the greeting class
            Greeting greeting = new Greeting();
            //calling the getname method to ask for user name
            greeting.getname();
            //creating an instance of the chatbot class and passing the username
            Chatbot chatbot = new Chatbot(greeting.username);
            //calling the start method to begin the chat
            chatbot.start();
        }//end of main
    }//end of class
}//end of namespace