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
        FLEE
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
            Console.WriteLine("Diablo del texto\n\n[1] Play\n[2] Settings\n[3] Exit\n[ ]");
            Console.SetCursorPosition(1, 5);
            while (!int.TryParse(Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 1 || tempChoice > 3 ))
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
            Console.WriteLine("");
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

                        Console.WriteLine("Choose an enemy to attack:");
                        for (int i = 0; i < myRooms[aRoomIndex].GetSkeletons().Count; i++)
                        {
                            Console.WriteLine("[" + i.ToString() + @"] 'Skeleton'; Health - " + myRooms[aRoomIndex].GetSkeletons()[i].GetHealth() + "; Armour - " + myRooms[aRoomIndex].GetSkeletons()[i].GetArmourRating() + ";");
                        }
                        Console.WriteLine("[ ]");
                        Console.SetCursorPosition(1, myRooms[aRoomIndex].GetSkeletons().Count + 1);
                        int tempChoice = 0;
                        while (!int.TryParse(Utilities.Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 0 || tempChoice > myRooms[aRoomIndex].GetSkeletons().Count))
                        {
                            Console.SetCursorPosition(1, myRooms[aRoomIndex].GetSkeletons().Count + 1);
                            Console.Write(" \b");
                        }
                        myPlayer.DealDamage(myRooms[aRoomIndex].GetSkeletons()[tempChoice - 1]);                 

                        break;
                    case (int)Enums.BattleActions.DEFEND:

                        Console.WriteLine("You have chosen to defend yourself");
                        myPlayer.SetIsDefending(true);
                        System.Threading.Thread.Sleep(1000);

                        break;
                    case (int)Enums.BattleActions.USEITEM:



                        break;
                    case (int)Enums.BattleActions.FLEE:

                        break;
                }
            }
        }

        static void GenerateRooms()
        {
            myRooms.Add(new Room(1));
        }
    }
}
