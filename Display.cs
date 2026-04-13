using System;
using System.Media;
using System.Drawing;
namespace POE_part1
{//start of namespace
    public class Display
    {//start of class

        //get the base directory path
        string path_logo = AppDomain.CurrentDomain.BaseDirectory;

        public Display()
        {//start of constructor

            //get the base directory and remove bin\Debug\ to get project folder
            string base_directory = AppDomain.CurrentDomain.BaseDirectory;

           // build the full path to the audio file with wav.
            string audio_path = base_directory.Replace(@"bin\Debug\", "") + "Display.wav";

            //calling the play audio method
            playaudio(audio_path);

            //calling the logo ascii method
            asci();

            //calling the ascii art title method
            asciiart();

        }//end of constructor

        public void playaudio(string path)
        {//start of method
            try
            {
                //creating a new instance of the SoundPlayer class
                using (SoundPlayer player = new SoundPlayer(path))
                {
                    //play the audio till the end
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                //display error message if audio fails
                Console.WriteLine($"Error playing audio: {ex.Message}");
            }
        }//end of method

        private void asci()
        {//start of method

            //replace bin\Debug\ with Display.jpg to get the logo path
            string full_path = path_logo.Replace(@"\bin\Debug\", @"\Display.jpg").ToString();

            //path of the logo and bitmap settings
            string path = full_path;
            Bitmap image = new Bitmap(path);

            //resize for better console fit
            int width = 150;
            int height = 70;
            Bitmap resized = new Bitmap(image, new Size(width, height));

            //ascii characters used to represent pixel brightness
            string asciiChars = "@#S%?*+;:,. ";

            //start by the height settings
            for (int y = 0; y < resized.Height; y++)
            {
                //then width
                for (int x = 0; x < resized.Width; x++)
                {
                    //get the color of the pixel on x and y
                    Color pixel = resized.GetPixel(x, y);

                    //convert to grayscale
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;

                    //map grayscale value to ascii character
                    int index = (gray * (asciiChars.Length - 1)) / 255;
                    Console.Write(asciiChars[index]);
                }
                Console.WriteLine();
            }

        }//end of method

        public void asciiart()
        {//start of method

            //set color for the cyber text
            Console.ForegroundColor = ConsoleColor.Green;

            //set color for the bot title border
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  +-*--#--*--#--*--#--*--#--*--#--*--#--*--#--*--#--*--#--*--#--*");
            Console.WriteLine("                                                                 |");
            Console.WriteLine("                                                                 |");
            Console.WriteLine("                                                                 |");
            Console.WriteLine("                                                                 |");
            Console.WriteLine("" + "                                                              |");
            Console.WriteLine("                                                                 |");
            Console.WriteLine("========CYBERSECURITY AWARENESS BOT[MAX] ========================|");
            Console.WriteLine("" + "=====Your personal security guide ===========================|");
            Console.WriteLine("                                                                 |");
            Console.WriteLine("                                                                 |");
            Console.WriteLine("                                                                 |");
            Console.WriteLine("                                                                 |");
            Console.WriteLine("                                                                 |");
            Console.WriteLine("                                                                 |");
            Console.WriteLine("  *--#--*--#--*--#--*--#--*--#--*--#--*--#--*--#--*--#--*--#--*-#");

            //reset color back to default
            Console.ResetColor();

        }//end of method

    }//end of class
}//end of namespace