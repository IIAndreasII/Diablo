using Diablo.Localisation;
using Diablo.Utilities;
using System;

namespace Diablo.Dungeon
{
    public class Dungeon
    {
        private Room[,]
            myRooms;

        private Room
            myCurrentRoom,
            myInitialRoom;

        public Dungeon(int aNumberOfRooms, Player.Player aPlayer)
        {
            int
                tempX = 7,
                tempY = 7;
            myRooms = new Room[16, 16];
            myRooms[tempX, tempY] = new Room(Utility.GetRNG().Next(0, aPlayer.GetLevel() * 3 + 1), Utility.GetRNG().Next(0, 4), false, aPlayer);
            myRooms[tempX, tempY].SetPosition(tempX, tempY);
            myCurrentRoom = myRooms[tempX, tempY];
            myInitialRoom = myRooms[tempX, tempY];

            switch (Utility.GetRNG().Next(0, 4))
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
                Generate(myRooms[tempX, tempY], item, aNumberOfRooms - 1, aPlayer);
            }
        }

        /// <summary>
        /// Recursively generates a dungeon
        /// </summary>
        /// <param name="prevRoom">The previous room of the dungeon</param>
        /// <param name="prevDoor">the previous door</param>
        /// <param name="aNumberOfRooms">How many rooms there will be in the dungeon</param>
        /// <param name="aPlayer">Active player</param>
        private void Generate(Room prevRoom, Doors prevDoor, int aNumberOfRooms, Player.Player aPlayer)
        {
            int
                tempNumberOfDoors = Utility.GetRNG().Next(0, (aNumberOfRooms > 2 ? 2 : aNumberOfRooms));
            if (aNumberOfRooms <= 0)
            {
                return;
            }
            if ((prevRoom.GetYPosition() - 1 < 0 || prevRoom.GetYPosition() + 1 > 9) || (prevRoom.GetXPosition() + 1 > 9 || prevRoom.GetXPosition() - 1 < 0))
            {
                return;
            }
            if (tempNumberOfDoors <= 0)
            {
                bool tempIsBossRoom = false;
                switch (Utility.GetRNG().Next(0, 2))
                {
                    case 0:
                        tempIsBossRoom = true;
                        break;
                }
                switch (prevDoor)
                {
                    case Doors.UP:
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() - 1] = new Room(Utility.GetRNG().Next(0, aPlayer.GetLevel() * 3 + 1), Utility.GetRNG().Next(0, 3), tempIsBossRoom, aPlayer);
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() - 1].AddDoor(Doors.DOWN);
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() - 1].SetPosition(prevRoom.GetXPosition(), prevRoom.GetYPosition() - 1);
                        break;

                    case Doors.DOWN:
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + 1] = new Room(Utility.GetRNG().Next(0, aPlayer.GetLevel() * 3 + 1), Utility.GetRNG().Next(0, 3), tempIsBossRoom, aPlayer);
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + 1].AddDoor(Doors.UP);
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + 1].SetPosition(prevRoom.GetXPosition(), prevRoom.GetYPosition() + 1);
                        break;

                    case Doors.RIGHT:
                        myRooms[prevRoom.GetXPosition() + 1, prevRoom.GetYPosition()] = new Room(Utility.GetRNG().Next(0, aPlayer.GetLevel() * 3 + 1), Utility.GetRNG().Next(0, 3), tempIsBossRoom, aPlayer);
                        myRooms[prevRoom.GetXPosition() + 1, prevRoom.GetYPosition()].AddDoor(Doors.LEFT);
                        myRooms[prevRoom.GetXPosition() + 1, prevRoom.GetYPosition()].SetPosition(prevRoom.GetXPosition() + 1, prevRoom.GetYPosition());
                        break;

                    case Doors.LEFT:
                        myRooms[prevRoom.GetXPosition() - 1, prevRoom.GetYPosition()] = new Room(Utility.GetRNG().Next(0, aPlayer.GetLevel() * 3 + 1), Utility.GetRNG().Next(0, 3), tempIsBossRoom, aPlayer);
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
                        tempPrevDoor = Doors.DOWN;
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + tempY] = new Room(Utilities.Utility.GetRNG().Next(0, aPlayer.GetLevel() * 3 + 1), Utilities.Utility.GetRNG().Next(0, 3), false, aPlayer);
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + tempY].AddDoor(tempPrevDoor);
                        break;

                    case Doors.DOWN:
                        tempY = 1;
                        tempPrevDoor = Doors.UP;
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + tempY] = new Room(Utilities.Utility.GetRNG().Next(0, aPlayer.GetLevel() * 3 + 1), Utilities.Utility.GetRNG().Next(0, 3), false, aPlayer);
                        myRooms[prevRoom.GetXPosition(), prevRoom.GetYPosition() + tempY].AddDoor(tempPrevDoor);
                        break;

                    case Doors.RIGHT:
                        tempX = 1;
                        tempPrevDoor = Doors.LEFT;
                        myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition()] = new Room(Utilities.Utility.GetRNG().Next(0, aPlayer.GetLevel() * 3 + 1), Utilities.Utility.GetRNG().Next(0, 3), false, aPlayer);
                        myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition()].AddDoor(tempPrevDoor);
                        break;

                    case Doors.LEFT:
                        tempX = -1;
                        tempPrevDoor = Doors.RIGHT;
                        myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition()] = new Room(Utilities.Utility.GetRNG().Next(0, aPlayer.GetLevel() * 3 + 1), Utilities.Utility.GetRNG().Next(0, 3), false, aPlayer);
                        myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition()].AddDoor(tempPrevDoor);
                        break;
                }
                myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition() + tempY].SetPosition(prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition() + tempY);

                for (int i = 0; i < tempNumberOfDoors; i++)
                {
                    Doors tempDoor = GetRandomDoor();
                    while (myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition() + tempY].GetDoors().Contains(tempDoor))
                    {
                        tempDoor = GetRandomDoor();
                    }
                    myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition() + tempY].AddDoor(tempDoor);
                }
                foreach (Doors door in myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition() + tempY].GetDoors())
                {
                    if (tempPrevDoor != door)
                    {
                        Generate(myRooms[prevRoom.GetXPosition() + tempX, prevRoom.GetYPosition() + tempY], door, aNumberOfRooms - 1, aPlayer);
                    }
                }
            }
        }

        /// <summary>
        /// Gets a random door
        /// </summary>
        /// <returns>A random Door</returns>
        private Doors GetRandomDoor()
        {
            switch (Utility.GetRNG().Next(0, 4))
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
        /// Enters a dungeon
        /// </summary>
        /// <param name="aPlayer">The player who enters</param>
        public void EnterDungeon(Player.Player aPlayer)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            aPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - Language.GetEnteringDungeon().Length / 2, tempWHD2 - 12);
            Console.Write(Language.GetEnteringDungeon());
            System.Threading.Thread.Sleep(1500);
            myInitialRoom.EnterRoom(aPlayer);
            EnterNewRoom(aPlayer);
        }

        /// <summary>
        /// Lets the player choose what room to enter based on the current room's doors
        /// </summary>
        /// <param name="aPlayer">Active player</param>
        private void EnterNewRoom(Player.Player aPlayer)
        {
            aPlayer.PrintUI();
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            Console.SetCursorPosition(tempWWD2 - (Language.GetThereAreDoorsPt1().Length + Language.GetThereAreDoorsPt2().Length + 4) / 2, tempWHD2 - 12);
            Console.Write(Language.GetThereAreDoorsPt1() + myCurrentRoom.GetDoors().Count + Language.GetThereAreDoorsPt2());
            Console.SetCursorPosition(tempWWD2 - Language.GetChooseDoor().Length / 2, tempWHD2 - 11);
            Console.Write(Language.GetChooseDoor());
            if (myCurrentRoom.GetDoors().Contains(Doors.UP))
            {
                Console.SetCursorPosition(tempWWD2 - 3, tempWHD2 - 9);
                Console.Write("╔═══╗");
                Console.SetCursorPosition(tempWWD2 - 3, tempWHD2 - 8);
                Console.Write("║[U]║");
                Console.SetCursorPosition(tempWWD2 - 3, tempWHD2 - 7);
                Console.Write("║   ║");
            }
            if (myCurrentRoom.GetDoors().Contains(Doors.DOWN))
            {
                Console.SetCursorPosition(tempWWD2 - 3, tempWHD2 - 3);
                Console.Write("╔═══╗");
                Console.SetCursorPosition(tempWWD2 - 3, tempWHD2 - 2);
                Console.Write("║[D]║");
                Console.SetCursorPosition(tempWWD2 - 3, tempWHD2 - 1);
                Console.Write("║   ║");
            }
            if (myCurrentRoom.GetDoors().Contains(Doors.RIGHT))
            {
                Console.SetCursorPosition(tempWWD2 + 2, tempWHD2 - 6);
                Console.Write("╔═══╗");
                Console.SetCursorPosition(tempWWD2 + 2, tempWHD2 - 5);
                Console.Write("║[R]║");
                Console.SetCursorPosition(tempWWD2 + 2, tempWHD2 - 4);
                Console.Write("║   ║");
            }
            if (myCurrentRoom.GetDoors().Contains(Doors.LEFT))
            {
                Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 6);
                Console.Write("╔═══╗");
                Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 5);
                Console.Write("║[L]║");
                Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 4);
                Console.Write("║   ║");
            }
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 5);
            Console.Write("?");
            if (myCurrentRoom == myInitialRoom)
            {
                Console.SetCursorPosition(tempWWD2 - (Language.GetExitDungeon().Length + 4) / 2, tempWHD2 + 2);
                Console.Write("[E] " + Language.GetExitDungeon());
            }
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 + 3);
            Console.Write("[ ]");
            Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 + 3);
            string tempChoice = Utility.ReadOnlyLetters(1);
            while (tempChoice != "R" && tempChoice != "r" && tempChoice != "U" && tempChoice != "u" && tempChoice != "D" && tempChoice != "d" && tempChoice != "L" && tempChoice != "l" && tempChoice != "E" && tempChoice != "e")
            {
                Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 + 3);
                Console.Write(" ]\b\b");
                tempChoice = Utility.ReadOnlyLetters(1);
            }
            if (tempChoice != "E" && tempChoice != "e")
            {
                if ((tempChoice == "U" || tempChoice == "u") && myRooms[myCurrentRoom.GetXPosition(), myCurrentRoom.GetYPosition() - 1] != null)
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
            else if (myCurrentRoom == myInitialRoom)
            {
                aPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - Language.GetExitingDungeon().Length / 2, tempWHD2 - 12);
                Console.Write(Language.GetExitingDungeon());
                System.Threading.Thread.Sleep(1500);
            }
            else
            {
                EnterNewRoom(aPlayer);
            }
        }

        /// <summary>
        /// Let's the player view a map of the current dungeon
        /// </summary>
        /// <param name="aPlayer">Active player</param>
        public void ShowMap(Player.Player aPlayer)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempXOffset = 8,
                tempYOffset = 12;
            aPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - tempXOffset, tempWHD2 - tempYOffset);
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.SetCursorPosition(tempWWD2 - tempXOffset + i, tempWHD2 - tempYOffset + j);
                    if (myRooms[i, j] != null)
                    {
                        if (myRooms[i, j] == myCurrentRoom)
                        {
                            Console.Write("X");
                        }
                        else if (myRooms[i, j] == myInitialRoom && myRooms[i, j] != myCurrentRoom)
                        {
                            Console.Write("S");
                        }
                        else
                        {
                            Console.Write("■");
                        }
                    }
                }
            }
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 12);
            Console.Write("[S]: " + Language.GetInitialRoom());
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 11);
            Console.Write("[X]: " + Language.GetCurrentRoom());
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10);
            Console.Write("[■]: " + Language.GetRoom());
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 2);
            Console.Write("[0] " + Language.GetBack());
            Utility.GetDigitInput(-19, 3, 0);
        }
    }
}