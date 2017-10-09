using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Utilities
{
    static class Utility
    {
        public static Random myRNG = new Random();

        /// <summary>
        /// Generates all suffixes for items 
        /// </summary>
        private static string[] GetSuffixes()
        {
            string[] tempSuffixes = new string[11];
            for (int i = 0; i < tempSuffixes.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        tempSuffixes[i] = "Divinity";
                        break;
                    case 1:
                        tempSuffixes[i] = "Corruption";
                        break;
                    case 2:
                        tempSuffixes[i] = "Fräsighet";
                        break;
                    case 3:
                        tempSuffixes[i] = "Deceit";
                        break;
                    case 4:
                        tempSuffixes[i] = "Peasants";
                        break;
                    case 5:
                        tempSuffixes[i] = "Odin";
                        break;
                    case 6:
                        tempSuffixes[i] = "Despair";
                        break;
                    case 7:
                        tempSuffixes[i] = "Clumpsiness";
                        break;
                    case 8:
                        tempSuffixes[i] = "Stupidity";
                        break;
                    case 9:
                        tempSuffixes[i] = "Saltiness";
                        break;
                    case 10:
                        tempSuffixes[i] = "Wisdom";
                        break;
                }
            }
            return tempSuffixes;
        }

        /// <summary>
        /// Gets a random suffix from the suffix-array
        /// </summary>
        /// <returns>String containing a random suffix</returns>
        public static string GetRandomSuffix()
        {
            string[] tempSuffixArray = GetSuffixes();
            return tempSuffixArray[myRNG.Next(0, tempSuffixArray.Length)];
        }

        /// <summary>
        /// Prints an ASCII-style pentagram at given position in given colour
        /// </summary>
        /// <param name="anXPosition">Position X</param>
        /// <param name="aYPosition">Position Y</param>
        /// <param name="aColour">Colour to print in</param>
        public static void PrintPentagram(int anXPosition, int aYPosition, ConsoleColor aColour)
        {
            string tempPrintValue;
            for (int i = 0; i < 19; i++)
            {
                switch (i)
                {
                    case 0:
                        tempPrintValue = @"         .d$$$$*$$$$$$$bc";
                        break;
                    case 1:
                        tempPrintValue = @"      .d$P'     d$$    '*$$.";
                        break;
                    case 2:
                        tempPrintValue = @"     d$'       4$'$$      '$$.";
                        break;
                    case 3:
                        tempPrintValue = @"   4$P         $F ^$F       '$c";
                        break;
                    case 4:
                        tempPrintValue = @"  z$%         d$   3$        ^$L";
                        break;
                    case 5:
                        tempPrintValue = @" 4$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$F";
                        break;
                    case 6:
                        tempPrintValue = @" $$$F''''''''$F''''''$F'''''C$$*$";
                        break;
                    case 7:
                        tempPrintValue = @".$% '$$e    d$       3$   z$$'  $F";
                        break;
                    case 8:
                        tempPrintValue = @"4$     *$$.4$'        $$d$P'    $$";
                        break;
                    case 9:
                        tempPrintValue = @"4$      ^ *$$.       .d$F       $$";
                        break;
                    case 10:
                        tempPrintValue = @"4$        d$'$$c   z$$'3$       $F";
                        break;
                    case 11:
                        tempPrintValue = @" $L      4$' ^ *$$$P'   $$     4$";
                        break;
                    case 12:
                        tempPrintValue = @"  3$     $F  .d$P$$e    ^$F    $P";
                        break;
                    case 13:
                        tempPrintValue = @"   $$   d$  .$$'    '$$c 3$   d$";
                        break;
                    case 14:
                        tempPrintValue = @"    *$.4$'z$$'        ^*$$$$ $$";
                        break;
                    case 15:
                        tempPrintValue = @"     '$$$$P'             '$$$P";
                        break;
                    case 16:
                        tempPrintValue = @"       *$b.             .d$P'";
                        break;
                    case 17:
                        tempPrintValue = @"         '$$$ec.....ze$$$'";
                        break;
                    case 18:
                        tempPrintValue = @"             '**$$$**''";
                        break;
                    default:
                        tempPrintValue = "Error";
                        break;
                }
                Console.SetCursorPosition(anXPosition, aYPosition + i);
                PrintInColour(tempPrintValue, aColour);
            }
        }

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
            Console.ForegroundColor = Program.StandardTextColour;
        }
    }
}