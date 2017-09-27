using System;
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
            Battle(0);
        }

        static void Battle(int aRoomIndex)
        {
            Console.WriteLine("You have encountered " + myRooms[aRoomIndex].GetSkeletonCount().ToString() + " enemies!");
            System.Threading.Thread.Sleep(1000);
            while(myRooms[aRoomIndex].GetSkeletonCount() > 0)
            {
                Console.Clear();
                switch (myPlayer.ChooseBattleAction())
                {
                    case (int)Enums.BattleActions.ATTACK:

                        Console.Clear();
                        Console.WriteLine("Choose an enemy to attack:");
                        for (int i = 0; i < myRooms[aRoomIndex].GetSkeletons().Count; i++)
                        {
                            Console.WriteLine("[" + (i + 1).ToString() + @"] 'Skeleton'; Health - " + myRooms[aRoomIndex].GetSkeletons()[i].GetHealth() + "; Armour - " + myRooms[aRoomIndex].GetSkeletons()[i].GetArmourRating() + ";" + (!myRooms[aRoomIndex].GetSkeletons()[i].GetIsAlive() ? " *dead*" : ""));
                        }
                        Console.WriteLine("[ ]");
                        Console.SetCursorPosition(1, myRooms[aRoomIndex].GetSkeletons().Count + 1);
                        int tempChoice = 0;
                        while (!int.TryParse(Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 0 || tempChoice > myRooms[aRoomIndex].GetSkeletons().Count))
                        {
                            Console.SetCursorPosition(1, myRooms[aRoomIndex].GetSkeletons().Count + 2);
                            Console.Write(" \b");
                        }
                        myPlayer.DealDamage(myRooms[aRoomIndex].GetSkeletons()[tempChoice - 1]);                 

                        break;
                    case (int)Enums.BattleActions.DEFEND:

                        Console.Clear();
                        Console.WriteLine("You have chosen to defend yourself");
                        myPlayer.SetIsDefending(true);
                        System.Threading.Thread.Sleep(1000);

                        break;
                    case (int)Enums.BattleActions.USEITEM:

                        Console.Clear();
                        myPlayer.OpenInventory();

                        break;
                    case (int)Enums.BattleActions.FLEE:

                        break;
                }
                for (int i = myRooms[aRoomIndex].GetSkeletons().Count; i > 0; i--)
                {
                    if(!myRooms[aRoomIndex].GetSkeletons()[i - 1].GetIsAlive())
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
            myRooms.Add(new Room(1));
        }
    }
}
