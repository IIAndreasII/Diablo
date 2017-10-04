using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Diablo.Utilities
{
    class Program
    {
        public static ConsoleColor StandardTextColour = ConsoleColor.Yellow;
        static Player.Player myPlayer;
        static List<Room> myRooms;

        static void Initialize()
        {
            Console.ForegroundColor = StandardTextColour;
            myPlayer = new Player.Player();
            myRooms = new List<Room>();

        }

        static void Main(string[] args)
        {
            Initialize();
            MainMenu();
        }

        static void MainMenu()
        {
            Console.Clear();
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
            Console.Clear();
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
                Console.Write(" \b");
            }
            switch (tempChoice)
            {
                case 1:
                    GenerateRooms();
                    EnterRoom(0);                 
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

        static void EnterRoom(int aRoomIndex)
        {
            Console.Clear();
            myPlayer.PrintUI();
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 - 12);
            Console.Write("You enter the room and look around");
            if (myRooms[aRoomIndex].GetSkeletonCount() > 0)
            {
                if(myRooms[aRoomIndex].GetSkeletonCount() == 1)
                {
                    Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 10);
                    Console.Write("You have spotted " + myRooms[aRoomIndex].GetSkeletonCount().ToString() + " enemy!");
                }
                else
                {
                    Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 10);
                    Console.Write("You have spotted " + myRooms[aRoomIndex].GetSkeletonCount().ToString() + " enemies!");
                }
                System.Threading.Thread.Sleep(2000);
                BattleSequence(aRoomIndex);
            }
            else
            {
                Console.Write("The room is empty");
            }
            
            
        }

        static void BattleSequence(int aRoomIndex)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            bool
                tempHasFled = false;
            while (myRooms[aRoomIndex].GetSkeletonCount() > 0 && !tempHasFled)
            {
                Console.Clear();
                switch (myPlayer.ChooseBattleAction())
                {
                    case Player.BattleActions.ATTACK:

                        Console.Clear();
                        myPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                        Console.WriteLine("Choose an enemy to attack");
                        for (int i = 0; i < myRooms[aRoomIndex].GetSkeletons().Count; i++)
                        {
                            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10 + i);
                            Console.Write("[" + (i + 1).ToString() + @"] 'Skeleton'; Health - " + myRooms[aRoomIndex].GetSkeletons()[i].GetHealth() + "; Armour - " + myRooms[aRoomIndex].GetSkeletons()[i].GetArmourRating().ToString());
                        }
                        Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 9 + myRooms[aRoomIndex].GetSkeletons().Count);
                        Console.Write("[ ]");
                        Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 9 + myRooms[aRoomIndex].GetSkeletons().Count);
                        int tempChoice = 0;
                        while (!int.TryParse(Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 0 || tempChoice > myRooms[aRoomIndex].GetSkeletons().Count))
                        {
                            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 9 + myRooms[aRoomIndex].GetSkeletons().Count);
                            Console.Write(" \b");
                        }
                        Console.Clear();
                        myPlayer.PrintUI();
                        myPlayer.DealDamage(myRooms[aRoomIndex].GetSkeletons()[tempChoice - 1]);

                        break;
                    case Player.BattleActions.DEFEND:

                        myPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 10);
                        Console.Write("You raise your defences and");
                        Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 9);
                        Console.Write("brace for a strike!");
                        myPlayer.SetIsDefending(true);
                        System.Threading.Thread.Sleep(2000);

                        break;
                    case Player.BattleActions.USEITEM:

                        myPlayer.OpenInventory();
                        BattleSequence(aRoomIndex);

                        break;
                    case Player.BattleActions.FLEE:

                        tempHasFled = true;

                        break;
                    case Player.BattleActions.ABSTAIN:

                        myPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 10);
                        Console.Write("You do not wish to attack");
                        Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 9);
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
            if(myPlayer.GetHealth() <= 0)
            {
                myPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - 5, tempWHD2 - 12);
                Console.Write("YOU DIED!");
                Console.ReadKey();
                MainMenu();
            }
            else if (!tempHasFled)
            {
                myPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                Console.Write("All enemies were defeated!");
                myPlayer.SubtractStamina(20);
                System.Threading.Thread.Sleep(2000);
                myPlayer.PrintUI();
                myRooms[aRoomIndex].LootSequence(myPlayer);
            }
            else
            {
                myPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 12);
                Console.Write("You have fled the battle, coward...");
                myPlayer.SubtractStamina(30);
                System.Threading.Thread.Sleep(2000);
            }
        }

        static void GenerateRooms()
        {
            myRooms.Clear();
            myRooms.Add(new Room(Utility.myRNG.Next(1, myPlayer.GetLevel() + 2), 2));
        } // Far from finished
    }
}
