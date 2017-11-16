using System;

namespace Diablo
{
    class Program
    {
        public static ConsoleColor StandardTextColour = ConsoleColor.Yellow;
        static Player.Player myPlayer;

        static void Main(string[] args)
        {
            Initialize();
            MainMenu();
        }

        /// <summary>
        /// Initializes important values
        /// </summary>
        static void Initialize()
        {
            Console.ForegroundColor = StandardTextColour;
            Utilities.Utility.SetSuffixes();
            myPlayer = new Player.Player();
            Managers.DungeonManager.Init(myPlayer);
            Managers.EnemyManager.Init();
        }

        /// <summary>
        /// Play menu when outside a dungeon
        /// </summary>
        static void Play()
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            myPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 12);
            Console.Write("Possible actions");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 10);
            Console.Write("[1] Enter dungeon");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 9);
            Console.Write("[2] Open inventory");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 8);
            Console.Write("[3] Rest ");
            Utilities.Utility.PrintInColour("(-10 gold)", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 7);
            Console.Write("[4] Long rest");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 6);
            Console.Write("[5] Commit suicide");
            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 3);

            switch (Utilities.Utility.GetDigitInput(-2, -3, 5))
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
                case 4:
                    myPlayer.LongRest();
                    break;
                case 5:
                    myPlayer.DeathSequence();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            Play();
        }

        /// <summary>
        /// Main menu
        /// </summary>
        public static void MainMenu()
        {
            Utilities.Utility.PrintTitle();
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
            Utilities.Utility.PrintPentagram(Console.WindowWidth / 2 , 9, ConsoleColor.DarkRed);
            switch (Utilities.Utility.GetDigitInput(-29, 5, 3))
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

        /// <summary>
        /// Restarts the game with reset values
        /// </summary>
        public static void Reboot()
        {
            Initialize();
            MainMenu();
        }
    }
}