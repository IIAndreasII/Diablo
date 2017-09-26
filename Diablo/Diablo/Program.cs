using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo
{
    public enum BattleActions
    {
        ATTACK = 1,
        DEFEND = 2,
        USEITEM = 3,
        FLEE = 4
    }

    public enum EnemyTypes
    {
        SKELETON,
        SKELETONARCHER,
        SKELETONCAPTAIN
    }

    class Program
    { 
        static Player.Player myPlayer;
        static List<Room> myRooms;

        static void Initialize()
        {
            Console.ForegroundColor = ConsoleColor.White;
            myPlayer = new Player.Player();
            myRooms = new List<Room>();
        }

        static void Main(string[] args)
        {
            Initialize();
            Menu();
        }

        static void Menu()
        {
            int tempChoice = 0;
            Console.WriteLine("Diablo del texto\n\n[1] Play\n[2] Settings\n[3] Exit\n[ ]");
            Console.SetCursorPosition(1, 5);
            while (!int.TryParse(ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 1 || tempChoice > 3 ))
            {
                Console.SetCursorPosition(1, 5);
                Console.Write(" \b");
            }
            switch (tempChoice)
            {
                case 1:
                    Play();
                    break;
                case 2:
                    /// TODO: Add Settings-method stuff
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:

                    break;
            }
        }

        static void Play()
        {

        }

        static void EngageBattle()
        {

        }

        static void GenerateRooms()
        {

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
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
