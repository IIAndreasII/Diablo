using System;

namespace Diablo.Utilities
{
    class Program
    {
        public static ConsoleColor StandardTextColour = ConsoleColor.Yellow;
        static Player.Player myPlayer;

        static void Initialize()
        {
            Console.ForegroundColor = StandardTextColour;
            myPlayer = new Player.Player();
            Managers.DungeonManager.Init(myPlayer);
            Managers.EnemyManager.Init();
        }

        static void Main(string[] args)
        {
            Initialize();
            MainMenu();
        }

        public static void MainMenu()
        {
            Utility.PrintTitle();
            int tempChoice = 0;
            string tempPrintValue;
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        tempPrintValue = "[1] Play";
                        break;
                    case 1:
                        tempPrintValue = "[2] Settings";
                        break;
                    case 2:
                        tempPrintValue = "[3] Exit";
                        break;
                    case 3:
                        tempPrintValue = "";
                        break;
                    case 4:
                        tempPrintValue = "[ ]";
                        break;      
                    default:
                        tempPrintValue = "Error";
                        break;
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - 30, i + 16);
                Console.Write(tempPrintValue);
            }
            Utility.PrintPentagram(Console.WindowWidth / 2 , 9, ConsoleColor.DarkRed);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 29, 20);
            while (!int.TryParse(Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 1 || tempChoice > 3 ))
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 29, 20);
                Console.Write(" ]\b\b");
            }
            switch (tempChoice)
            {
                case 1:
                    Initialize();
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
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempChoice = 0;
            myPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 12);
            Console.Write("Possible actions");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 10);
            Console.Write("[1] Enter dungeon");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 9);
            Console.Write("[2] Open inventory");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 8);
            Console.Write("[3] Rest (-10 gold)");
            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 6);
            Console.Write("[ ]");
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 6);
            while(!int.TryParse(Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 1 || tempChoice > 3))
            {
                Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 6);
                Console.Write(" ]\b\b");
            }
            switch (tempChoice)
            {
                case 1:
                    Managers.DungeonManager.EnterDungeon(myPlayer);                
                    break;
                case 2:
                    myPlayer.OpenInventory();
                    break;
                case 3:
                    myPlayer.Rest();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            Play();
        }
    }
}