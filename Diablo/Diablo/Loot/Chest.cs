using System;
using System.Collections.Generic;

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
            if (Utilities.Utility.GetRNG().Next(0, 100) < 5)
            {
                myIsMimic = true;
            }
            else
            {
                myItems = new List<Item>();
                myGold = Utilities.Utility.GetRNG().Next(0, 51);
                myHPPotions = Utilities.Utility.GetRNG().Next(0, 3);
                myManaPotions = Utilities.Utility.GetRNG().Next(0, 3);
                int tempNumberOfItems = Utilities.Utility.GetRNG().Next(0, 6);
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
            Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetApproachChest().Length / 2, tempWHD2 - 12);
            Console.Write(Localisation.Language.GetApproachChest());
            System.Threading.Thread.Sleep(1500);
            Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetItIsLocked().Length / 2, tempWHD2 - 10);
            Console.Write(Localisation.Language.GetItIsLocked());
            Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetUnlockWish().Length / 2, tempWHD2 - 8);
            Console.Write(Localisation.Language.GetUnlockWish());
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 6);
            Console.Write("[1] " + Localisation.Language.GetYes());
            Utilities.Utility.PrintInColour("(-25 " + Localisation.Language.GetGold() + ")", ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 5);
            Console.Write("[2] " + Localisation.Language.GetNo());
            if (!myIsMimic && Utilities.Utility.GetDigitInput(-7, -3, 2, 1) == 1)
            {
                aPlayer.PrintUI();
                aPlayer.SetGold(-25);
                if (myItems.Count > 0)
                {
                    Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetPeekLoot().Length / 2, tempWHD2 - 12);
                    Console.Write(Localisation.Language.GetPeekLoot());
                    System.Threading.Thread.Sleep(1500);
                    for (int i = 0; i < myItems.Count; i++)
                    {
                        Console.SetCursorPosition(tempWWD2 - 20, tempTextOffset + i);
                        Console.Write("[" + (i + 3) + "] ");
                        switch (myItems[i].GetItemType())
                        {
                            case ItemType.SCROLL:
                                Utilities.Utility.PrintInColour(myItems[i].GetFullName(), ConsoleColor.DarkMagenta);
                                break;

                            case ItemType.TRINKET:
                                Utilities.Utility.PrintInColour(myItems[i].GetFullName(), ConsoleColor.Green);
                                break;

                            default:
                                Utilities.Utility.PrintInColour("[" + myItems[i].GetRating() + "]" + myItems[i].GetFullName(), ConsoleColor.Gray);
                                break;
                        }
                        if (i == myItems.Count - 1)
                        {
                            Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 1);
                            Utilities.Utility.PrintInColour(Localisation.Language.GetHPPotions() + ": " + myHPPotions.ToString(), ConsoleColor.Red);
                            Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 2);
                            Utilities.Utility.PrintInColour(Localisation.Language.GetManaPotions() + ": " + myManaPotions.ToString(), ConsoleColor.Blue);
                            Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 3);
                            Console.Write(Localisation.Language.GetGold() + ": " + myGold);
                        }
                    }
                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2);
                    Console.Write("[1] " + Localisation.Language.GetPickup() + "    [0] " + Localisation.Language.GetDiscard());
                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 1);
                    Console.Write("[2] " + Localisation.Language.GetPickUpEquip());
                    switch (Utilities.Utility.GetDigitInput(-19, 3, 2))
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
                            Console.Write(Localisation.Language.GetLootAdded());
                            System.Threading.Thread.Sleep(1500);
                            break;

                        case 2:
                            aPlayer.AddItemsToInventory(myItems);
                            aPlayer.EquipBestItems();
                            aPlayer.SetGold(myGold);
                            aPlayer.SetHealthPotions(myHPPotions);
                            aPlayer.SetManaPotions(myManaPotions);
                            aPlayer.PrintUI();
                            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 12);
                            Console.Write(Localisation.Language.GetLootAdded());
                            System.Threading.Thread.Sleep(1500);
                            break;
                    }
                }
                else
                {
                    Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetPeekNoLoot().Length / 2, tempWHD2 - 12);
                    Console.Write(Localisation.Language.GetPeekNoLoot());
                    System.Threading.Thread.Sleep(1500);
                }
            }
            else if (myIsMimic)
            {
                aPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetNoOrdinaryPt1().Length / 2, tempWHD2 - 12);
                Console.Write(Localisation.Language.GetNoOrdinaryPt1());
                Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetNoOrdinaryPt2().Length / 2, tempWHD2 - 11);
                Console.Write(Localisation.Language.GetNoOrdinaryPt2());
                System.Threading.Thread.Sleep(3000);
                if (aPlayer.GetAgility() / 2 > Utilities.Utility.GetRNG().Next(1, 101))
                {
                    aPlayer.PrintUI();
                    Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetEscapeFangs().Length / 2, tempWHD2 - 12);
                    Console.Write(Localisation.Language.GetEscapeFangs());
                    System.Threading.Thread.Sleep(1500);
                }
                else
                {
                    aPlayer.PrintUI();
                    Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetDecapitate().Length / 2, tempWHD2 - 12);
                    Console.Write(Localisation.Language.GetDecapitate());
                    System.Threading.Thread.Sleep(1500);
                    aPlayer.DeathSequence();
                }
            }
        }
    }
}