﻿using System;
using System.Media;

namespace Diablo
{
    internal class Program
    {
        public static ConsoleColor StandardTextColour = ConsoleColor.Yellow;
        private static Player.Player myPlayer;

        private static void Main(string[] args)
        {
            Audio.Audio.Init();
            Localisation.Language.Init();
            Initialize();
            MainMenu();
        }

        /// <summary>
        /// Initializes important values
        /// </summary>
        private static void Initialize()
        {
            Console.ForegroundColor = StandardTextColour;
            Utilities.Utility.GenerateSuffixes();
            myPlayer = new Player.Player();
            Managers.DungeonManager.Init(myPlayer);
            Managers.EnemyManager.Init();
        }

        /// <summary>
        /// Play menu when outside a dungeon
        /// </summary>
        private static void Play()
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
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 5);
            Console.Write("[6] Music settings");
            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 3);

            switch (Utilities.Utility.GetDigitInput(-2, -3, 6))
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

                case 6:
                    MusicSettings();
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
            string tempPrintValue = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        tempPrintValue = "[1] Play";
                        break;

                    case 1:
                        tempPrintValue = "[2] Exit";
                        break;

                    case 2:
                        tempPrintValue = string.Empty;
                        break;
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - 30, i + 16);
                Console.Write(tempPrintValue);
            }
            Utilities.Utility.PrintPentagram(Console.WindowWidth / 2, 9, ConsoleColor.DarkRed);
            switch (Utilities.Utility.GetDigitInput(-29, 4, 3))
            {
                case 1:
                    Initialize();
                    Play();
                    break;

                case 2:
                    Environment.Exit(0);
                    break;

                default:
                    MainMenu();
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


        public static void MusicSettings()
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            myPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 12);
            Console.Write("Choose song:");
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10);
            Console.Write("[1] 'Cirice' - Ghost B.C");
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 9);
            Console.Write("[2] 'At doom's gate' - R. Prince");
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 8);
            Console.Write("[3] 'Ora Pro Nobis Lucifer' - Behemoth");
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 6);
            Console.Write("[4] Toggle music: " + (Audio.Audio.GetIsMusicPlaying() == true ? "On" : "Off"));
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 4);
            Console.Write("[0] Back");

            switch (Utilities.Utility.GetDigitInput(-19, -3, 4))
            {
                case 0:
                    Play();
                    break;
                
                case 1:
                    Audio.Audio.PlayCirice();
                    break;

                case 2:
                    Audio.Audio.PlayDoomTheme();
                    break;

                case 3:
                    Audio.Audio.PlayOraProNobisLucifer();
                    break;

                case 4:
                    Audio.Audio.ToggleMusic();
                    break;
            }
            MusicSettings();
        }
    }
}