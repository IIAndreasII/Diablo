using System;
using System.Collections.Generic;

namespace Diablo.Loot
{
    class Chest
    {
        int
            myGold,
            myHPPotions,
            myManaPotions;
        bool
            myIsMimic;
        List<Item>
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
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 12);
            Console.Write("You approach the chest and inspect it.");
            System.Threading.Thread.Sleep(1500);
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 10);
            Console.Write("It is locked...");
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 8);
            Console.Write("Do wish to unlock it?");
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 6);
            Console.Write("[1] Yes ");
            Utilities.Utility.PrintInColour("(-25 gold)", ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 5);
            Console.Write("[2] No");
            if (!myIsMimic && Utilities.Utility.GetDigitInput(-7, -3, 2, 1) == 1)
            {                
                aPlayer.PrintUI();
                aPlayer.SubtractGold(25);
                if (myItems.Count > 0)
                {
                    Console.SetCursorPosition(tempWWD2 - 21, tempWHD2 - 12);
                    Console.Write("You peek inside the chest, there is loot!");
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
                            Utilities.Utility.PrintInColour("Health potions: " + myHPPotions.ToString(), ConsoleColor.Red);
                            Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 2);
                            Utilities.Utility.PrintInColour("Mana potions: " + myManaPotions.ToString(), ConsoleColor.Blue);
                            Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 3);
                            Console.Write("Gold: " + myGold);
                        }
                    }
                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2);
                    Console.Write("[1] Pick up all    [0] Discard all");
                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 1);
                    Console.Write("[2] Pick up all & equip best");
                    switch (Utilities.Utility.GetDigitInput(-19, 3, 2))
                    {
                        case 0:
                            myItems.Clear();
                            break;
                        case 1:
                            aPlayer.AddItemsToInventory(myItems);
                            aPlayer.AddGold(myGold);
                            aPlayer.AddHealthPotions(myHPPotions);
                            aPlayer.AddManaPotions(myManaPotions);
                            aPlayer.PrintUI();
                            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 12);
                            Console.Write("Loot added to inventory!");
                            System.Threading.Thread.Sleep(1500);
                            break;
                        case 2:
                            aPlayer.AddItemsToInventory(myItems);
                            aPlayer.EquipBestItems();
                            aPlayer.AddGold(myGold);
                            aPlayer.AddHealthPotions(myHPPotions);
                            aPlayer.AddManaPotions(myManaPotions);
                            aPlayer.PrintUI();
                            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 12);
                            Console.Write("Loot added to inventory!");
                            System.Threading.Thread.Sleep(1500);
                            break;
                    }
                }
                else
                {
                    Console.SetCursorPosition(tempWWD2 - 21, tempWHD2 - 12);
                    Console.Write("You peek inside the chest, there is no loot");
                    System.Threading.Thread.Sleep(1500);
                }
            }
            else if (myIsMimic)
            {
                aPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - 21, tempWHD2 - 12);
                Console.Write("As you try to open the chest, you notice");
                Console.SetCursorPosition(tempWWD2 - 21, tempWHD2 - 11);
                Console.Write("that it is breathing. This is no ordinary chest");
                System.Threading.Thread.Sleep(3000);
                if(aPlayer.GetAgility() / 2 > Utilities.Utility.GetRNG().Next(1, 101))
                {
                    aPlayer.PrintUI();
                    Console.SetCursorPosition(tempWWD2 - 16, tempWHD2 - 12);
                    Console.Write("You managed to escape its fangs!");
                    System.Threading.Thread.Sleep(1500);
                }
                else
                {
                    aPlayer.PrintUI();
                    Console.SetCursorPosition(tempWWD2 - 23, tempWHD2 - 12);
                    Console.Write("The chest-mimic bites you and rips your head off!");
                    System.Threading.Thread.Sleep(1500);
                    aPlayer.DeathSequence();
                }
            }
        }
    }
}