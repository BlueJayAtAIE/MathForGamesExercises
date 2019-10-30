using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConversion
{
    class BinaryConvert
    {
        static void Main(string[] args)
        {
            // Variables.
            char userInputChar = '?';
            float userInput = 0;
            string userInputS = "";
            bool okToGo = false;
            Random rng = new Random();

            // Main Loop
            while (userInputChar != '!')
            {
                Console.Clear();
                okToGo = false;
                Console.Write("Enter a letter for the cooresponding exercise. Enter \"?\" for help. Enter \"!\" to quit. > ");
                userInputChar = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();
                switch (userInputChar)
                {
                    case '!':
                        Console.WriteLine("\nNow closing...");
                        break;
                    case '?':
                        Console.WriteLine("\nProblem directory:");
                        Console.WriteLine("\"A\" - Convert from Decimal to Binary (Number Input by User)");
                        Console.WriteLine("\"B\" - Convert from Binary to Decimal (Number Input by User)");
                        break;
                    case 'a':
                        while (!okToGo)
                        {
                            Console.Write("Enter a number greater than 0. > ");
                            float.TryParse(Console.ReadLine(), out userInput);

                            if (userInput < 0)
                            {
                                Console.WriteLine("Please enter a valid number!");
                            }
                            else
                            {
                                okToGo = true;
                            }
                        }

                        Console.WriteLine($"\n{userInput} in decimal is {DeciToBi((int)userInput)} in binary.");
                        break;
                    case 'b':
                        while (!okToGo)
                        {
                            okToGo = true;
                            Console.Write("Enter a binary string. > ");
                            userInputS = Console.ReadLine();

                            if (userInputS.Length <= 0)
                            {
                                Console.WriteLine("Please enter a valid binary sequence!");
                                okToGo = false;
                            }
                            else
                            {
                                okToGo = true;
                            }

                            if (okToGo)
                            {
                                foreach (char c in userInputS)
                                {
                                    if (!(c == '1') && !(c == '0'))
                                    {
                                        Console.WriteLine("Please enter a valid binary sequence!");
                                        okToGo = false;
                                        break;
                                    }
                                }
                            }
                        }

                        Console.WriteLine($"\n{userInputS} in binary is {BiToDeci(userInputS)} in decimal.");
                        break;
                    default:
                        Console.WriteLine("\nInvalid command!");
                        break;
                }
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey(true);
            }

            string DeciToBi(int userinputDecimal)
            {
                string result = Convert.ToString(userinputDecimal, 2);
                return result;
            }

            string BiToDeci(string userinputBinary)
            {
                string result = Convert.ToInt32(userinputBinary, 2).ToString();
                return result;
            }
        }
    }
}
