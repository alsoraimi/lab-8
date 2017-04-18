using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        { bool loop = true;                 //added for loop
            do
            { 
            Console.WriteLine("Welcome to Batting Average Calculator!");
            Console.Write("Enter number of times at bat: ");
            int[] TimesBatting = new int[GetValidInteger(1, 25)];
            GetBattingResults(TimesBatting);

            if (!ContinueLoop())
            {
                loop = false;
            }

        } while (loop);
        }

        public static int GetValidInteger(int Min, int Max)
        {
            int IntegerInput;
            while (true)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out IntegerInput)) //Validates if user input is an integer
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input not a number."); //Prompts error if input is not a number
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Try again: ");
                    continue;
                }
                if (IntegerInput < Min || IntegerInput > Max) //Validates if user input is between Min and Max
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: Input not between {Min} and {Max}."); //Prompts error if input is not between Min and Max
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Try again: ");
                    continue;
                }
                return IntegerInput;
            }
        }
        public static void GetBattingResults(int[] TimesBatting)
        {
            int[] BattingResults = new int[TimesBatting.Length];
            int AtBatsNotZero = 0;
            int sum = 0;
            for (int i = 0; i < TimesBatting.Length; i++)
            {
                Console.Write($"Result for at-bat {i + 1}: ");
                BattingResults[i] = GetValidInteger(0, 4);
                if (BattingResults[i] != 0)
                {
                    AtBatsNotZero++;
                }
                sum += BattingResults[i];
            }
            double BattingAverage = (double)AtBatsNotZero / (double)BattingResults.Length;
            double SluggingPercent = (double)sum / (double)BattingResults.Length;
            Console.WriteLine($"Batting Average: {BattingAverage}");
            Console.WriteLine($"Slugging Percentage: {SluggingPercent}");
        }
        public static bool ContinueLoop()
        {
            while (true)
            {
                Console.WriteLine("Would you like to try again, ? (Y/N)"); // add user input if they want to try again
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    Console.WriteLine();
                    return true;
                }

                else if (input == "N")
                {
                    Console.WriteLine("thanks for trying!");
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;            // changes color of text for error
                    Console.WriteLine("ERROR, ENTER Y OR N");
                    Console.ForegroundColor = ConsoleColor.Black;         //changes color of text back to original

                }
            }
        }
    }
}