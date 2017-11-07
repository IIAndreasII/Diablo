using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Dungeon
{
    public class Dungeon
    {
        Room[,] 
            myRooms = new Room[10, 10];
        Room 
            myCurrentRoom,
            myInitialRoom;

        public Dungeon(int aNumberOfRooms)
        {
            int 
                tempX = 4,
                tempY = 4;
            myRooms[tempX, tempY] = new Room(2, 2, 2);
            myRooms[tempX, tempY].SetPosition(tempX, tempY);
            myCurrentRoom = myRooms[tempX, tempY];
            myInitialRoom = myRooms[tempX, tempY];

            switch (Utilities.Utility.GetRNG().Next(0, 4))
            {
                case 0:
                    myRooms[tempX, tempY].AddDoor(Doors.LEFT);
                    myRooms[tempX, tempY].AddDoor(Doors.RIGHT);
                    break;
                case 1:
                    myRooms[tempX, tempY].AddDoor(Doors.LEFT);
                    myRooms[tempX, tempY].AddDoor(Doors.DOWN);
                    break;
                case 2:
                    myRooms[tempX, tempY].AddDoor(Doors.DOWN);
                    myRooms[tempX, tempY].AddDoor(Doors.RIGHT);
                    break;
                case 3:
                    myRooms[tempX, tempY].AddDoor(Doors.UP);
                    myRooms[tempX, tempY].AddDoor(Doors.RIGHT);
                    break;

            }
            foreach (Doors item in myRooms[tempX, tempY].GetDoors())
            {
                Generate(myRooms[tempX, tempY], item, aNumberOfRooms - 1);
            }
        }

        /// <summary>
        /// Recursively generates a dungeon
        /// </summary>
        /// <param name="prevRoom">The previous room of the dungeon</param>
        /// <param name="prevDoor">the previous door</param>
        /// <param name="aNumberOfRooms">How many rooms there will be in the dungeon</param>
        private void Generate(Room prevRoom, Doors prevDoor, int aNumberOfRooms)
        {
            int
                tempNumberOfDoors = Utilities.Utility.GetRNG().Next(0, (aNumberOfRooms > 2 ? 2 : aNumberOfRooms));

            if (aNumberOfRooms <= 0)
            {
                return;
            }
            if((prevRoom.GetYPosition() - 1 < 0 || prevRoom.GetYPosition() + 1 > 9) || (prevRoom.GetXPosition() + 1 > 9 || prevRoom.GetXPosition() - 1 < 0))
            {
                return;
            }
            if (tempNumberOfDoors <= 0)
            {
                switch (prevDoor)
                {
                    case Doors.UP:
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() - 1] = new Room(2, 2, 3);
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() - 1].AddDoor(Doors.DOWN);
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() - 1].SetPosition(prevRoom.GetXPosition(), prevRoom.GetYPosition() - 1);
                        break;
                    case Doors.DOWN:
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + 1] = new Room(2, 2, 3);
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + 1].AddDoor(Doors.UP);
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + 1].SetPosition(prevRoom.GetXPosition(), prevRoom.GetYPosition() + 1);
                        break;
                    case Doors.RIGHT:
                        myRooms[prevRoom.GetXPosition() + 1, prevRoom.GetYPosition()] = new Room(2, 2, 3);
                        myRooms[prevRoom.GetXPosition() + 1, prevRoom.GetYPosition()].AddDoor(Doors.LEFT);
                        myRooms[prevRoom.GetXPosition() + 1, prevRoom.GetYPosition()].SetPosition(prevRoom.GetXPosition() + 1, prevRoom.GetYPosition());
                        break;
                    case Doors.LEFT:
                        myRooms[prevRoom.GetXPosition() - 1, prevRoom.GetYPosition()] = new Room(2, 2, 3);
                        myRooms[prevRoom.GetXPosition() - 1, prevRoom.GetYPosition()].AddDoor(Doors.RIGHT);
                        myRooms[prevRoom.GetXPosition() - 1, prevRoom.GetYPosition()].SetPosition(prevRoom.GetXPosition() - 1, prevRoom.GetYPosition());
                        break;
                }
                return;
            }
            else
            {
                int
                    tempX = 0,
                    tempY = 0;
                Doors
                    tempPrevDoor = Doors.FAULTYDOOR;
                switch (prevDoor)
                {
                    case Doors.UP:

                        tempY = -1;
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + tempY] = new Room(2, 2, 3);
                        tempPrevDoor = Doors.DOWN;
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + tempY].AddDoor(tempPrevDoor);

                        break;
                    case Doors.DOWN:

                        tempY = 1;
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + tempY] = new Room(2, 2, 3);
                        tempPrevDoor = Doors.UP;
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + tempY].AddDoor(tempPrevDoor);

                        break;
                    case Doors.RIGHT:

                        tempX = 1;
                        myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition()] = new Room(2, 2, 3);
                        tempPrevDoor = Doors.LEFT;
                        myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition()].AddDoor(tempPrevDoor);

                        break;
                    case Doors.LEFT:

                        tempX = -1;
                        myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition()] = new Room(2, 2, 3);
                        tempPrevDoor = Doors.RIGHT;
                        myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition()].AddDoor(tempPrevDoor);

                        break;
                }

                myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition() + tempY].SetPosition(prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition() + tempY);

                for (int i = 0; i < tempNumberOfDoors; i++)
                {
                    Doors tempDoor = GetRandomDoor();
                    while(myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition() + tempY].GetDoors().Contains(tempDoor))
                    {
                        tempDoor = GetRandomDoor();
                    }
                    myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition() + tempY].AddDoor(tempDoor);
                }

                foreach (Doors door in myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition() + tempY].GetDoors())
                {
                    if (tempPrevDoor != door)
                    {
                        Generate(myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition() + tempY], door, aNumberOfRooms - 1);
                    }
                }
            }

            
        }

        /// <summary>
        /// Debug feature
        /// </summary>
        public void DrawMatrix()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(i, j);
                    if (myRooms[i, j] != null)
                    {
                        if (i == 4 && j == 4)
                        {
                            Console.Write("O");
                        }
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
            }
            Console.WriteLine("\n\nDungeon generation debug");
            Console.ReadLine();
        }

        /// <summary>
        /// Gets a random door
        /// </summary>
        /// <returns>A random Door</returns>
        private Doors GetRandomDoor()
        {
            switch (Utilities.Utility.GetRNG().Next(0, 4))
            {
                case 0:
                    return Doors.UP;
                case 1:
                    return Doors.DOWN;
                case 2:
                    return Doors.LEFT;
                case 3:
                    return Doors.RIGHT;
                default:
                    return Doors.FAULTYDOOR;
            }
        }

        /// <summary>
        /// Gets the rooms within the dungeon
        /// </summary>
        /// <returns>A two-dimensional array</returns>
        public Room[,] GetRooms()
        {
            return myRooms;
        }

        /// <summary>
        /// Gets the room of which the player is currently in
        /// </summary>
        /// <returns>A room</returns>
        public Room GetCurrentRoom()
        {
            return myCurrentRoom;
        }

        /// <summary>
        /// Gets the first room of the dungeon
        /// </summary>
        /// <returns>A room</returns>
        public Room GetInitialRoom()
        {
            return myInitialRoom;
        }

        /// <summary>
        /// Enters a dungeon
        /// </summary>
        /// <param name="aPlayer">The player who enters</param>
        public void EnterDungeon(Player.Player aPlayer)
        {
            myInitialRoom.EnterRoom(aPlayer);
            EnterNewRoom(aPlayer);
        }

        /// <summary>
        /// Lets the player choose what room to enter based on the current room's doors
        /// </summary>
        /// <param name="aPlayer">Active player</param>
        public void EnterNewRoom(Player.Player aPlayer)
        {
            aPlayer.PrintUI();
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 - 12);
            Console.Write("There are/is " + myCurrentRoom.GetDoors().Count + " doors in this room.");
            Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 - 11);
            Console.Write("Which one do you enter?");
            if (myCurrentRoom.GetDoors().Contains(Doors.UP))
            {
                Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 8);
                Console.Write("[U]");
            }
            if (myCurrentRoom.GetDoors().Contains(Doors.DOWN))
            {
                Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 4);
                Console.Write("[D]");
            }
            if (myCurrentRoom.GetDoors().Contains(Doors.RIGHT))
            {
                Console.SetCursorPosition(tempWWD2 + 3, tempWHD2 - 6);
                Console.Write("[R]");
            }
            if (myCurrentRoom.GetDoors().Contains(Doors.LEFT))
            {
                Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 - 6);
                Console.Write("[L]");
            }
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 6);
            Console.Write("?");

            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 2);
            Console.Write("[ ]");
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 2);
            string tempChoice = Console.ReadLine();
            
            while(tempChoice != "R" && tempChoice != "r" && tempChoice != "U" && tempChoice != "u" && tempChoice != "D" && tempChoice != "d" && tempChoice != "L" && tempChoice != "l")
            {
                Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 2);
                Console.Write(" ]\b\b");
                tempChoice = Console.ReadLine();
            }
            
            if((tempChoice == "U" || tempChoice == "u") && myRooms[myCurrentRoom.GetXPosition(), myCurrentRoom.GetYPosition() - 1] != null)
            {
                myCurrentRoom = myRooms[myCurrentRoom.GetXPosition(), myCurrentRoom.GetYPosition() - 1];
                myRooms[myCurrentRoom.GetXPosition(), myCurrentRoom.GetYPosition()].EnterRoom(aPlayer);
                EnterNewRoom(aPlayer);
            }
            else if ((tempChoice == "D" || tempChoice == "d") && myRooms[myCurrentRoom.GetXPosition(), myCurrentRoom.GetYPosition() + 1] != null)
            {
                myCurrentRoom = myRooms[myCurrentRoom.GetXPosition(), myCurrentRoom.GetYPosition() + 1];
                myRooms[myCurrentRoom.GetXPosition(), myCurrentRoom.GetYPosition()].EnterRoom(aPlayer);
                EnterNewRoom(aPlayer);
            }
            else if ((tempChoice == "R" || tempChoice == "r") && myRooms[myCurrentRoom.GetXPosition() + 1, myCurrentRoom.GetYPosition()] != null)
            {
                myCurrentRoom = myRooms[myCurrentRoom.GetXPosition() + 1, myCurrentRoom.GetYPosition()];
                myRooms[myCurrentRoom.GetXPosition(), myCurrentRoom.GetYPosition()].EnterRoom(aPlayer);
                EnterNewRoom(aPlayer);
            }
            else if ((tempChoice == "L" || tempChoice == "l") && myRooms[myCurrentRoom.GetXPosition() - 1, myCurrentRoom.GetYPosition()] != null)
            {
                myCurrentRoom = myRooms[myCurrentRoom.GetXPosition() - 1, myCurrentRoom.GetYPosition()];
                myRooms[myCurrentRoom.GetXPosition(), myCurrentRoom.GetYPosition()].EnterRoom(aPlayer);
                EnterNewRoom(aPlayer);
            }
            else
            {
                aPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 - 12);
                Console.Write("You open the door and see only emptiness");
                Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 - 10);
                Console.Write("You cannot risk going there");
                EnterNewRoom(aPlayer);
            }
        }
    }
}