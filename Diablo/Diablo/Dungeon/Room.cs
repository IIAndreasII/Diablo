using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo
{
    public enum Doors
    {
        RIGHT,
        LEFT,
        UP,
        DOWN,
        FAULTYDOOR
    }

    class Room
    {
        List<Enemies.Skeleton> 
            mySkeletons;
        List<Items.Item> 
            myLoot;
        List<Doors>
            myDoors= new List<Doors>();
        Room
            myRoomToLeft,
            myRoomToRight,
            myRoomUpward,
            myRoomDownward;
        int
            myGold,
            myHPPotions,
            myManaPotions,
            myXPos, /// Used for positions in a dungeon
            myYPos;
        bool 
            myAreHostilesPresent;

        public Room(int aNumberOfSkeletons, int anAmountOfItems)
        {
            mySkeletons = new List<Enemies.Skeleton>();   /// Change all this!!!!!
            myLoot = new List<Items.Item>();
            if (aNumberOfSkeletons > 0)
            {
                myAreHostilesPresent = true;
                for (int i = 0; i < aNumberOfSkeletons; i++)
                {
                    mySkeletons.Add(new Enemies.Skeleton(1));
                }
                myGold = Utilities.Utility.GetRNG().Next(5, 20 * aNumberOfSkeletons + 1);
                myHPPotions = Utilities.Utility.GetRNG().Next(0, aNumberOfSkeletons / 2);
                myManaPotions = Utilities.Utility.GetRNG().Next(0, aNumberOfSkeletons / 2);
            }
            else
            {
                myAreHostilesPresent = false;
            }
            for (int i = 0; i < anAmountOfItems; i++)
            {
                myLoot.Add(new Items.Item());
            }
        }

        /// <summary>
        /// The sequence where the player will receive loot
        /// </summary>
        /// <param name="aPlayer">Active player</param>
        public void LootSequence(Player.Player aPlayer)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempTextOffset = tempWHD2 - 10;
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
            if(myLoot.Count > 0)
            {
                Console.Write("You have found some loot!");
                System.Threading.Thread.Sleep(1500);
                for (int i = 0; i < myLoot.Count; i++)
                {
                    Console.SetCursorPosition(tempWWD2 - 20, tempTextOffset + i);
                    Console.Write("[" + (i + 3) + "] ");
                    switch (myLoot[i].GetItemType())
                    {
                        case Items.Type.SCROLL:
                            Utilities.Utility.PrintInColour(myLoot[i].GetFullName(), ConsoleColor.DarkMagenta);
                            break;
                        case Items.Type.WEAPON:
                            Utilities.Utility.PrintInColour(myLoot[i].GetFullName() + " [" + myLoot[i].GetDamage() + "]", ConsoleColor.Gray);
                            break;
                        default:
                            Utilities.Utility.PrintInColour(myLoot[i].GetFullName() + " [" + myLoot[i].GetArmourRating() + "]", ConsoleColor.Gray);
                            break;
                    }

                    if(i == myLoot.Count - 1)
                    {
                        Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 1);
                        Utilities.Utility.PrintInColour("Health potions: " + myHPPotions.ToString(), ConsoleColor.Red);
                        Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 2);
                        Utilities.Utility.PrintInColour("Mana potions: " + myManaPotions.ToString(), ConsoleColor.Blue);
                        Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 3);
                        Console.Write("Gold: " + myGold);                      
                    }
                }
                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2);
                Console.Write("[" + 1.ToString() + "] Pick up all    [0] Discard all");
                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 1);
                Console.Write("[" + 2.ToString() + "] Pick up all and equip best");
                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 3);
                Console.Write("[ ]");
                Console.SetCursorPosition(tempWWD2 - 19, tempWHD2 + 3);
                int tempChoice = -1;
                while (!int.TryParse(Utilities.Utility.ReadOnlyNumbers(myLoot.Count / 2 + 1), out tempChoice) || (tempChoice < 0 || tempChoice > myLoot.Count + 1))
                {
                    Console.SetCursorPosition(tempWWD2 - 19, tempWHD2 + 3);
                    Console.Write(" \b");
                }

                switch (tempChoice)
                {
                    case 0:
                        myLoot.Clear();
                        break;
                    case 1:
                        aPlayer.AddItemsToInventory(myLoot);
                        aPlayer.AddGold(myGold);
                        aPlayer.AddHealthPotions(myHPPotions);
                        aPlayer.AddManaPotions(myManaPotions);
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 12);
                        Console.Write("Loot added to inventory!");
                        System.Threading.Thread.Sleep(1500);
                        break;
                    case 2:
                        aPlayer.AddItemsToInventory(myLoot);
                        aPlayer.EquipBestItems();
                        aPlayer.AddGold(myGold);
                        aPlayer.AddHealthPotions(myHPPotions);
                        aPlayer.AddManaPotions(myManaPotions);
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 12);
                        Console.Write("Loot added to inventory!");
                        break;
                }
            }
            else
            {
                Console.SetCursorPosition(tempWWD2 - 21, tempWHD2 - 12);
                Console.Write("Looking around the room, you found no loot");
                System.Threading.Thread.Sleep(1500);
            }
        }

        #region Get
        public List<Enemies.Skeleton> GetSkeletons()
        {
            return mySkeletons;
        }

        public int GetSkeletonCount()
        {
            return mySkeletons.Count;
        }

        public bool IsHostilesPresent()
        {
            return myAreHostilesPresent;
        }

        public List<Doors> GetDoors()
        {
            return myDoors;
        }

        public int GetXPosition()
        {
            return myXPos;
        }

        public int GetYPosition()
        {
            return myYPos;
        }

        #endregion

        #region Set
        public void SetIsHostilesPresent(bool aNewValue)
        {
            myAreHostilesPresent = aNewValue;
        }

        public void SetDoors(List<Doors> someDoors)
        {
            myDoors = someDoors;
        }

        public void AddDoor(Doors aDoor)
        {
            if (!myDoors.Contains(aDoor))
            {
                myDoors.Add(aDoor);
            }
        }

        public void SetPosition(int anXValue, int aYValue)
        {
            myXPos = anXValue;
            myYPos = aYValue;
        }

        #endregion
    }
}