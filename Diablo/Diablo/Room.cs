using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo
{
    class Room
    {
        List<Enemies.Skeleton> 
            mySkeletons;
        List<Items.Item> 
            myLoot;
        int
            myGold,
            myHPPotions,
            myManaPotions;
        bool 
            myAreHostilesPresent;

        public Room(int aNumberOfSkeletons, int anAmountOfItems)
        {
            mySkeletons = new List<Enemies.Skeleton>();
            myLoot = new List<Items.Item>();
            if (aNumberOfSkeletons > 0)
            {
                myAreHostilesPresent = true;
                for (int i = 0; i < aNumberOfSkeletons; i++)
                {
                    mySkeletons.Add(new Enemies.Skeleton(1));
                }
                myGold = Utilities.Utility.myRNG.Next(5, 20 * aNumberOfSkeletons + 1);
                myHPPotions = Utilities.Utility.myRNG.Next(0, aNumberOfSkeletons / 2);
                myManaPotions = Utilities.Utility.myRNG.Next(0, aNumberOfSkeletons / 2);
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
                    if (myLoot[i].GetArmourRating() > 0)
                    {
                        Utilities.Utility.PrintInColour(myLoot[i].GetFullName() + " [" + myLoot[i].GetArmourRating() + "]", ConsoleColor.Gray);
                    }
                    else
                    {
                        Utilities.Utility.PrintInColour(myLoot[i].GetFullName() + " [" + myLoot[i].GetDamage() + "]", ConsoleColor.Gray);
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
                        aPlayer.EquipBestItems(myLoot);
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

        public void SetIsHostilesPresent(bool aNewValue)
        {
            myAreHostilesPresent = aNewValue;
        }
        #endregion
    }
}