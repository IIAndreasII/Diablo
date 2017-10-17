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

        public Dungeon()
        {
            int 
                tempX = 4,
                tempY = 0;
            myRooms[tempX, tempY] = new Room(2, 2);
            myRooms[tempX, tempY].SetPosition(tempX, tempY);

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
            Generate(myRooms[tempX, tempY]);
        }

        private void Generate(Room prevRoom)
        {
            /// Recursive motherfucker

           



        }

        private List<Doors> GetRandomDoors(Room aPreviousRoom)
        {
            List<Doors>
                tempListToReturn = new List<Doors>();
            int
                tempAmountOfDoors = Utilities.Utility.GetRNG().Next(1, 5);




            for (int i = 0; i < tempAmountOfDoors; i++)
            {
                bool
                    tempIsDoorAssigned = false;

                while (!tempIsDoorAssigned)
                {





                }



            }

            return null;
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
    }
}
