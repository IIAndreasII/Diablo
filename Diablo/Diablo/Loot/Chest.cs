using Diablo.Localisation;
using Diablo.Utilities;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Diablo.Loot
{
    internal class Chest
    {
        private int
            myGold,
            myHPPotions,
            myManaPotions;

        private bool
            myIsMimic;

        private List<Item>
            myItems;

        public Chest()
        {
            if (Utility.GetRNG().Next(0, 100) < 5)
            {
                myIsMimic = true;
            }
            else
            {
                myItems = new List<Item>();
                myGold = Utility.GetRNG().Next(0, 51);
                myHPPotions = Utility.GetRNG().Next(0, 3);
                myManaPotions = Utility.GetRNG().Next(0, 3);
                int tempNumberOfItems = Utility.GetRNG().Next(0, 6);
                for (int i = 0; i < tempNumberOfItems; i++)
                {
                    myItems.Add(Factories.LootFactory.CreateItem());
                }
            }
        }

        /// <summary>
        /// Opens the chest
        /// </summary>
        /// <param name="aPlayer">Active player</param>
        public void Open(Player.Player aPlayer)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempTextOffset = tempWHD2 - 10;
            aPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - Language.GetApproachChest().Length / 2, tempWHD2 - 12);
            Console.Write(Language.GetApproachChest());
            Thread.Sleep(1500);
            Console.SetCursorPosition(tempWWD2 - Language.GetItIsLocked().Length / 2, tempWHD2 - 10);
            Console.Write(Language.GetItIsLocked());
            Console.SetCursorPosition(tempWWD2 - Language.GetUnlockWish().Length / 2, tempWHD2 - 8);
            Console.Write(Language.GetUnlockWish());
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 6);
            Console.Write("[1] " + Language.GetYes());
            Utility.PrintInColour("(-25 " + Language.GetGold() + ")", ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 5);
            Console.Write("[2] " + Language.GetNo());
            if (!myIsMimic && Utility.GetDigitInput(-7, -3, 2, 1) == 1)
            {
                aPlayer.PrintUI();
                aPlayer.SetGold(-25);
                if (myItems.Count > 0)
                {
                    Console.SetCursorPosition(tempWWD2 - Language.GetPeekLoot().Length / 2, tempWHD2 - 12);
                    Console.Write(Language.GetPeekLoot());
                    Thread.Sleep(1500);
                    for (int i = 0; i < myItems.Count; i++)
                    {
                        Console.SetCursorPosition(tempWWD2 - 20, tempTextOffset + i);
                        Console.Write("[" + (i + 3) + "] ");
                        switch (myItems[i].GetItemType())
                        {
                            case ItemType.SCROLL:
                                Utility.PrintInColour(myItems[i].GetFullName(), ConsoleColor.DarkMagenta);
                                break;

                            case ItemType.TRINKET:
                                Utility.PrintInColour(myItems[i].GetFullName(), ConsoleColor.Green);
                                break;

                            default:
                                Utility.PrintInColour("[" + myItems[i].GetRating() + "]" + myItems[i].GetFullName(), ConsoleColor.Gray);
                                break;
                        }
                        if (i == myItems.Count - 1)
                        {
                            Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 1);
                            Utility.PrintInColour(Language.GetHPPotions() + ": " + myHPPotions.ToString(), ConsoleColor.Red);
                            Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 2);
                            Utility.PrintInColour(Language.GetManaPotions() + ": " + myManaPotions.ToString(), ConsoleColor.Blue);
                            Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 3);
                            Console.Write(Language.GetGold() + ": " + myGold);
                        }
                    }
                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2);
                    Console.Write("[1] " + Language.GetPickup() + "    [0] " + Language.GetDiscard());
                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 1);
                    Console.Write("[2] " + Language.GetPickUpEquip());
                    switch (Utility.GetDigitInput(-19, 3, 2))
                    {
                        case 0:
                            myItems.Clear();
                            break;

                        case 1:
                            aPlayer.AddItemsToInventory(myItems);
                            aPlayer.SetGold(myGold);
                            aPlayer.SetHealthPotions(myHPPotions);
                            aPlayer.SetManaPotions(myManaPotions);
                            aPlayer.PrintUI();
                            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 12);
                            Console.Write(Language.GetLootAdded());
                            Thread.Sleep(1500);
                            break;

                        case 2:
                            aPlayer.AddItemsToInventory(myItems);
                            aPlayer.EquipBestItems();
                            aPlayer.SetGold(myGold);
                            aPlayer.SetHealthPotions(myHPPotions);
                            aPlayer.SetManaPotions(myManaPotions);
                            aPlayer.PrintUI();
                            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 12);
                            Console.Write(Language.GetLootAdded());
                            Thread.Sleep(1500);
                            break;
                    }
                }
                else
                {
                    Console.SetCursorPosition(tempWWD2 - Language.GetPeekNoLoot().Length / 2, tempWHD2 - 12);
                    Console.Write(Language.GetPeekNoLoot());
                    Thread.Sleep(1500);
                }
            }
            else if (myIsMimic)
            {
                aPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - Language.GetNoOrdinaryPt1().Length / 2, tempWHD2 - 12);
                Console.Write(Language.GetNoOrdinaryPt1());
                Console.SetCursorPosition(tempWWD2 - Language.GetNoOrdinaryPt2().Length / 2, tempWHD2 - 11);
                Console.Write(Language.GetNoOrdinaryPt2());
                Thread.Sleep(3000);
                if (aPlayer.GetAgility() / 2 > Utility.GetRNG().Next(1, 101))
                {
                    aPlayer.PrintUI();
                    Console.SetCursorPosition(tempWWD2 - Language.GetEscapeFangs().Length / 2, tempWHD2 - 12);
                    Console.Write(Language.GetEscapeFangs());
                    Thread.Sleep(1500);
                }
                else
                {
                    aPlayer.PrintUI();
                    Console.SetCursorPosition(tempWWD2 - Language.GetDecapitate().Length / 2, tempWHD2 - 12);
                    Console.Write(Language.GetDecapitate());
                    Thread.Sleep(1500);
                    aPlayer.DeathSequence();
                }
            }
        }
    }
}