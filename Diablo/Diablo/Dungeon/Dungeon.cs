using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Dungeon
{
    class Dungeon
    {
        Room[,] myRooms = new Room[10, 10];
        Room myCurrentRoom;

        public Dungeon(int aNumberOfRooms)
        {
            int 
                tempX = 4,
                tempY = 4;
            myRooms[tempX, tempY] = new Room(2, 2, 2);
            myRooms[tempX, tempY].SetPosition(tempX, tempY);
            myCurrentRoom = myRooms[tempX, tempY];

            switch (Utilities.Utility.GetRNG().Next(0, 3))
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
                        break;
                    case Doors.DOWN:
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + 1] = new Room(2, 2, 3);
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + 1].AddDoor(Doors.UP);
                        break;
                    case Doors.RIGHT:
                        myRooms[prevRoom.GetXPosition() + 1, prevRoom.GetYPosition()] = new Room(2, 2, 3);
                        myRooms[prevRoom.GetXPosition() + 1, prevRoom.GetYPosition()].AddDoor(Doors.LEFT);
                        break;
                    case Doors.LEFT:
                        myRooms[prevRoom.GetXPosition() - 1, prevRoom.GetYPosition()] = new Room(2, 2, 3);
                        myRooms[prevRoom.GetXPosition() - 1, prevRoom.GetYPosition()].AddDoor(Doors.RIGHT);
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

        public Room[,] GetRooms()
        {
            return myRooms;
        }

        public Room GetCurrentRoom()
        {
            return myCurrentRoom;
        }
    }
}
