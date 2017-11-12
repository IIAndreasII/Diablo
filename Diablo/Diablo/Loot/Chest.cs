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
            myItems = new List<Item>();
            myGold = Utilities.Utility.GetRNG().Next(0, 51);
            myHPPotions = Utilities.Utility.GetRNG().Next(0, 3);
            myManaPotions = Utilities.Utility.GetRNG().Next(0, 3);
            int tempNumberOfItems = Utilities.Utility.GetRNG().Next(0, 6);
            for (int i = 0; i < tempNumberOfItems; i++)
            {
                myItems.Add(new Item());
            }
            if (Utilities.Utility.GetRNG().Next(0, 100) < 10)
            {
                myIsMimic = true;
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
                tempChoice = 0,
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
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 3);
            Console.Write("[ ]");
            Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 - 3);
            while (!int.TryParse(Console.ReadLine(), out tempChoice) || (tempChoice < 1 || tempChoice > 2))
            {
                Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 - 3);
                Console.Write(" ]\b\b");
            }
            if (!myIsMimic && tempChoice == 1)
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
                            case Type.SCROLL:
                                Utilities.Utility.PrintInColour(myItems[i].GetFullName(), ConsoleColor.DarkMagenta);
                                break;
                            case Type.WEAPON:
                                Utilities.Utility.PrintInColour(myItems[i].GetFullName() + " [" + myItems[i].GetDamage() + "]", ConsoleColor.Gray);
                                break;
                            default:
                                Utilities.Utility.PrintInColour(myItems[i].GetFullName() + " [" + myItems[i].GetArmourRating() + "]", ConsoleColor.Gray);
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
                    Console.Write("[" + 1.ToString() + "] Pick up all    [0] Discard all");
                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 1);
                    Console.Write("[" + 2.ToString() + "] Pick up all and equip best");
                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 3);
                    Console.Write("[ ]");
                    Console.SetCursorPosition(tempWWD2 - 19, tempWHD2 + 3);
                    tempChoice = -1;
                    while (!int.TryParse(Utilities.Utility.ReadOnlyNumbers(myItems.Count / 2 + 1), out tempChoice) || (tempChoice < 0 || tempChoice > myItems.Count + 1))
                    {
                        Console.SetCursorPosition(tempWWD2 - 19, tempWHD2 + 3);
                        Console.Write(" \b");
                    }
                    switch (tempChoice)
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
                Console.SetCursorPosition(tempWWD2 - 25, tempWHD2 - 9);
                Console.Write("The mimic immediately tries to bite your neck off!");
                System.Threading.Thread.Sleep(1500);
                if((float)aPlayer.GetAgility() / 2 > Utilities.Utility.GetRNG().Next(1, 100))
                {
                    aPlayer.PrintUI();
                    Console.SetCursorPosition(tempWWD2 - 16, tempWHD2 - 12);
                    Console.Write("You managed to escape its fangs!");
                }
                else
                {
                    aPlayer.PrintUI();
                    Console.SetCursorPosition(tempWWD2 - 21, tempWHD2 - 12);
                    Console.Write("The mimic bites you and rips your head off!");
                    aPlayer.DeathSequence();
                }
                System.Threading.Thread.Sleep(1500);
            }
        }
    }
}