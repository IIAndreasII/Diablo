﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    public enum BattleActions
    {
        ATTACK,
        DEFEND,
        USEITEM,
        FLEE,
        ABSTAIN
    }

    public enum EnemyTypes
    {
        SKELETON,
        SKELETONARCHER,
        SKELETONCAPTAIN
    }

}
namespace Diablo.Utilities
{
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
                Console.SetCursorPosition(Console.WindowWidth / 2 - tempPrintValue.Length / 2, i + 2);
                Utility.PrintInColour(tempPrintValue, ConsoleColor.Yellow);
            }
            Utility.PrintPentagram(Console.WindowWidth / 2 - 17, 8, ConsoleColor.Red);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Console.WindowWidth / 2, 6);
            while (!int.TryParse(Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 1 || tempChoice > 3 ))
            {
                Console.SetCursorPosition(Console.WindowWidth / 2, 6);
                Console.Write(" \b");
            }
            switch (tempChoice)
            {
                case 1:
                    GenerateRooms();
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
            Console.Clear();
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempChoice = 0;
            myPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 11);
            Console.Write("Possible actions");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 9);
            Console.Write("[1] Enter dungeon");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 8);
            Console.Write("[2] Open inventory");
            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 6);
            Console.Write("[ ]");
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 6);
            while(!int.TryParse(Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 1 || tempChoice > 2))
            {
                Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 6);
                Console.Write(" \b");
            }
            switch (tempChoice)
            {
                case 1:
                    EnterRoom(0);
                    break;
                case 2:
                    myPlayer.OpenInventory();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            Play();
        }

        static void EnterRoom(int aRoomIndex)
        {
            Console.Clear();
            myPlayer.PrintUI();
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 - 11);
            Console.Write("You enter the room and look around");
            if (myRooms[aRoomIndex].GetSkeletonCount() > 0)
            {
                if(myRooms[aRoomIndex].GetSkeletonCount() == 1)
                {
                    Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 9);
                    Console.Write("You have spotted " + myRooms[aRoomIndex].GetSkeletonCount().ToString() + " enemy!");
                }
                else
                {
                    Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 9);
                    Console.Write("You have spotted " + myRooms[aRoomIndex].GetSkeletonCount().ToString() + " enemies!");
                }
                Console.ReadKey();
                BattleSequence(aRoomIndex);
            }
            else
            {
                Console.Write("The room is empty");
            }
            
            
        }

        static void BattleSequence(int aRoomIndex)
        {
            while (myRooms[aRoomIndex].GetSkeletonCount() > 0)
            {
                int
                    tempWWD2 = Console.WindowWidth / 2,
                    tempWHD2 = Console.WindowHeight / 2;
                Console.Clear();
                switch (myPlayer.ChooseBattleAction())
                {
                    case (int)Enums.BattleActions.ATTACK:

                        Console.Clear();
                        myPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 11);
                        Console.WriteLine("Choose an enemy to attack");
                        for (int i = 0; i < myRooms[aRoomIndex].GetSkeletons().Count; i++)
                        {
                            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 9 + i);
                            Console.Write("[" + (i + 1).ToString() + @"] 'Skeleton'; Health - " + myRooms[aRoomIndex].GetSkeletons()[i].GetHealth() + "; Armour - " + myRooms[aRoomIndex].GetSkeletons()[i].GetArmourRating().ToString());
                        }
                        Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 8 + myRooms[aRoomIndex].GetSkeletons().Count);
                        Console.Write("[ ]");
                        Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 8 + myRooms[aRoomIndex].GetSkeletons().Count);
                        int tempChoice = 0;
                        while (!int.TryParse(Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 0 || tempChoice > myRooms[aRoomIndex].GetSkeletons().Count))
                        {
                            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 8 + myRooms[aRoomIndex].GetSkeletons().Count);
                            Console.Write(" \b");
                        }
                        Console.Clear();
                        myPlayer.PrintUI();
                        myPlayer.DealDamage(myRooms[aRoomIndex].GetSkeletons()[tempChoice - 1]);

                        break;
                    case (int)Enums.BattleActions.DEFEND:

                        myPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 9);
                        Console.Write("You raise your defences and");
                        Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 8);
                        Console.Write("brace for a strike!");
                        myPlayer.SetIsDefending(true);
                        System.Threading.Thread.Sleep(2000);

                        break;
                    case (int)Enums.BattleActions.USEITEM:

                        myPlayer.OpenInventory();

                        break;
                    case (int)Enums.BattleActions.FLEE:

                        break;
                    case (int)Enums.BattleActions.ABSTAIN:

                        myPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 9);
                        Console.Write("You do not wish to attack");
                        Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 8);
                        Console.Write("and lower your arms.");
                        System.Threading.Thread.Sleep(2000);

                        break;
                }
                for (int i = myRooms[aRoomIndex].GetSkeletons().Count; i > 0; i--)
                {
                    if (!myRooms[aRoomIndex].GetSkeletons()[i - 1].GetIsAlive())
                    {
                        myRooms[aRoomIndex].GetSkeletons().Remove(myRooms[aRoomIndex].GetSkeletons()[i - 1]);
                    }
                    else
                    {
                        myRooms[aRoomIndex].GetSkeletons()[i - 1].DealDamage(myPlayer);
                    }
                }
            }
            Console.WriteLine("All enemies defeated!");
            Console.ReadKey();
        }

        static void GenerateRooms()
        {
            myRooms.Clear();
            myRooms.Add(new Room(1));
        }
    }
}
