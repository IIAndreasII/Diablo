using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Utilities
{
    class Utility
    {
        /// <summary>
        /// Makes the user unable to type anything but letters while entering information
        /// </summary>
        /// <param name="aMaxLength">The max length of what the user is entering</param>
        /// <returns>Whatever the user types</returns>
        public static string ReadOnlyLetters(int aMaxLength)
        {
            StringBuilder tempInput = new StringBuilder();
            ConsoleKeyInfo tempConsoleKey;
            while ((tempConsoleKey = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                if (Char.IsLetter(tempConsoleKey.KeyChar) && !Char.IsSymbol(tempConsoleKey.KeyChar))
                {
                    Console.Write(tempConsoleKey.KeyChar);
                    tempInput.Append(tempConsoleKey.KeyChar);
                }
                if ((tempInput.Length != 0 && tempConsoleKey.Key == ConsoleKey.Backspace) || tempInput.Length > aMaxLength)
                {
                    tempInput.Length--;
                    Console.Write("\b \b");
                }
            }
            Console.Write(Environment.NewLine);
            return tempInput.ToString();
        }

        /// <summary>
        /// Makes the user unable to type anything but numbers while entering information
        /// </summary>
        /// <param name="aMaxLength">The max length of what the user is entering</param>
        /// <returns>Whatever the user types</returns>
        public static string ReadOnlyNumbers(int aMaxLength)
        {
            StringBuilder tempInput = new StringBuilder();
            ConsoleKeyInfo tempConsoleKey;
            while ((tempConsoleKey = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                if (Char.IsDigit(tempConsoleKey.KeyChar) && !Char.IsSymbol(tempConsoleKey.KeyChar))
                {
                    Console.Write(tempConsoleKey.KeyChar);
                    tempInput.Append(tempConsoleKey.KeyChar);
                }
                if ((tempInput.Length != 0 && tempConsoleKey.Key == ConsoleKey.Backspace) || tempInput.Length > aMaxLength)
                {
                    tempInput.Length--;
                    Console.Write("\b \b");
                }
            }
            Console.Write(Environment.NewLine);
            return tempInput.ToString();
        }

        /// <summary>
        /// Prints the given string in the given colour using Console.Write()
        /// </summary>
        /// <param name="aStringToPrint">The string to print</param>
        /// <param name="aConsoleColour">The colour to print in</param>
        public static void PrintInColour(string aStringToPrint, ConsoleColor aConsoleColour)
        {
            Console.ForegroundColor = aConsoleColour;
            Console.Write(aStringToPrint);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
