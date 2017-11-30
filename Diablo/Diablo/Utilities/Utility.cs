using System;
using System.Text;

namespace Diablo.Utilities
{
    internal static class Utility
    {
        private static Random myRNG = new Random();
        private static string[] mySuffixes;

        /// <summary>
        /// Gets the random number generator
        /// </summary>
        /// <returns>An instance of the class 'Random'</returns>
        public static Random GetRNG() => myRNG;

        /// <summary>
        /// Sets the suffixes
        /// </summary>
        /// <param name="someSuffixes">Suffixes to set suffixes to</param>
        public static void SetSuffixes(string[] someSuffixes)
        {
            mySuffixes = someSuffixes;
        }

        /// <summary>
        /// Gets a random suffix from the suffix-array
        /// </summary>
        /// <returns>String containing a random suffix</returns>
        public static string GetRandomSuffix() => mySuffixes[myRNG.Next(0, mySuffixes.Length)];

        /// <summary>
        /// Prints an ASCII-style pentagram at given position in given colour
        /// </summary>
        /// <param name="anXPosition">Position X</param>
        /// <param name="aYPosition">Position Y</param>
        /// <param name="aColour">Colour to print in</param>
        public static void PrintPentagram(int anXPosition, int aYPosition, ConsoleColor aColour)
        {
            string tempPrintValue = string.Empty;
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
        /// <param name="aConsoleColour">The colour to print the string in</param>
        public static void PrintInColour(string aStringToPrint, ConsoleColor aConsoleColour)
        {
            Console.ForegroundColor = aConsoleColour;
            Console.Write(aStringToPrint);
            Console.ForegroundColor = Program.StandardTextColour;
        }

        /// <summary>
        /// Prints the title
        /// </summary>
        public static void PrintTitle()
        {
            Console.Clear();
            string tempPrintValue = string.Empty;
            for (int i = 0; i < 11; i++)
            {
                switch (i)
                {
                    case 0:
                        tempPrintValue = "╔══╗                   ╦══╗                   ╦╗  ╦        ╦";
                        break;

                    case 1:
                        tempPrintValue = "║  ║                   ║  ║                   ║╚╗ ║        ║     ╦";
                        break;

                    case 2:
                        tempPrintValue = "║  ║  ╦══╗  ╔══╦       ╬══╝  ╦══╗  ╔══╗       ║ ╚╗║  ╔══╗  ╠══╗  ╦  ╦═╗";
                        break;

                    case 3:
                        tempPrintValue = "║  ║  ║     ║  ║       ║     ║     ║  ║       ║  ╚╣  ║  ║  ║  ║  ║  ╚═╗";
                        break;

                    case 4:
                        tempPrintValue = "╚══╝  ╩     ╚══╚       ╩     ╩     ╚══╝       ╩   ╩  ╚══╝  ╩══╝  ╩  ╚═╩ ╦";
                        break;

                    case 5:
                        tempPrintValue = "                                                                        ╝";
                        break;

                    case 6:
                        tempPrintValue = "  ╦                      ╔══╗";
                        break;

                    case 7:
                        tempPrintValue = "  ║                   ╦  ║  ╩";
                        break;

                    case 8:
                        tempPrintValue = "  ║      ╦   ╦  ╦══╗  ╦  ╬══  ╦══╗  ╦══╗";
                        break;

                    case 9:
                        tempPrintValue = "  ║      ║   ║  ║     ║  ║    ╬══╝  ║";
                        break;

                    case 10:
                        tempPrintValue = "  ╩═══╝  ╚═══╝  ╩══╝  ╩  ╩    ╩══╝  ╩";
                        break;
                }
                Console.SetCursorPosition(Console.WindowWidth - 100, i + 2);
                PrintInColour(tempPrintValue, ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Reads input in digits at a specified location
        /// </summary>
        /// <param name="anXOffset">X offset relative to the center</param>
        /// <param name="aYOffset">Y offset relative to the center</param>
        /// <param name="aMaxValue">Max value of input digit</param>
        /// <returns>Input</returns>
        public static int GetDigitInput(int anXOffset, int aYOffset, int aMaxValue)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempInput,
                tempMaxLength = aMaxValue > 9 ? 2 : 1;
            Console.SetCursorPosition(tempWWD2 + anXOffset - 1, tempWHD2 + aYOffset);
            if (tempMaxLength >= 2)
            {
                Console.Write("[  ]");
            }
            else
            {
                Console.Write("[ ]");
            }
            Console.SetCursorPosition(tempWWD2 + anXOffset, tempWHD2 + aYOffset);
            while (!int.TryParse(ReadOnlyNumbers(tempMaxLength), out tempInput) || (tempInput < 0 || tempInput > aMaxValue))
            {
                Console.SetCursorPosition(tempWWD2 + anXOffset, tempWHD2 + aYOffset);
                if (tempMaxLength >= 2)
                {
                    Console.Write("  ]\b\b\b");
                }
                else
                {
                    Console.Write(" ]\b\b");
                }
            }
            return tempInput;
        }

        /// <summary>
        /// Reads input in digits at a specified location
        /// </summary>
        /// <param name="anXOffset">X offset relative to the center</param>
        /// <param name="aYOffset">Y offset relative to the center</param>
        /// <param name="aMaxValue">Max value of input digit</param>
        /// <param name="aMinValue">Min value of input digit</param>
        /// <returns>Input</returns>
        public static int GetDigitInput(int anXOffset, int aYOffset, int aMaxValue, int aMinValue)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempInput,
                tempMaxLength = aMaxValue > 9 ? 2 : 1;
            Console.SetCursorPosition(tempWWD2 + anXOffset - 1, tempWHD2 + aYOffset);
            if (tempMaxLength >= 2)
            {
                Console.Write("[  ]");
            }
            else
            {
                Console.Write("[ ]");
            }
            Console.SetCursorPosition(tempWWD2 + anXOffset, tempWHD2 + aYOffset);
            while (!int.TryParse(ReadOnlyNumbers(tempMaxLength), out tempInput) || (tempInput < aMinValue || tempInput > aMaxValue))
            {
                Console.SetCursorPosition(tempWWD2 + anXOffset, tempWHD2 + aYOffset);
                if (tempMaxLength >= 2)
                {
                    Console.Write("  ]\b\b\b");
                }
                else
                {
                    Console.Write(" ]\b\b");
                }
            }
            return tempInput;
        }

        /// <summary>
        /// Reads input in digits at a specified location and spits it out for other uses
        /// </summary>
        /// <param name="anXOffset">X offset relative to the center</param>
        /// <param name="aYOffset">Y offset relative to the center</param>
        /// <param name="aMaxValue">Max value of input digit</param>
        /// <returns>Input</returns>
        public static int GetDigitInput(int anXOffset, int aYOffset, int aMaxValue, out int anInputValue)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempInput,
                tempMaxLength = aMaxValue > 9 ? 2 : 1;
            Console.SetCursorPosition(tempWWD2 + anXOffset - 1, tempWHD2 + aYOffset);
            if (tempMaxLength >= 2)
            {
                Console.Write("[  ]");
            }
            else
            {
                Console.Write("[ ]");
            }
            Console.SetCursorPosition(tempWWD2 + anXOffset, tempWHD2 + aYOffset);
            while (!int.TryParse(ReadOnlyNumbers(tempMaxLength), out tempInput) || (tempInput < 0 || tempInput > aMaxValue))
            {
                Console.SetCursorPosition(tempWWD2 + anXOffset, tempWHD2 + aYOffset);
                if (tempMaxLength >= 2)
                {
                    Console.Write("  ]\b\b\b");
                }
                else
                {
                    Console.Write(" ]\b\b");
                }
            }
            anInputValue = tempInput;
            return tempInput;
        }
    }
}