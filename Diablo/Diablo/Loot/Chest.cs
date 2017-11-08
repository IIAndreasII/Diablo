using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            myGold = Utilities.Utility.GetRNG().Next(0, 51);
            myHPPotions = Utilities.Utility.GetRNG().Next(0, 3);
            myManaPotions = Utilities.Utility.GetRNG().Next(0, 3);
            int tempNumberOfItems = Utilities.Utility.GetRNG().Next(0, 6);
            for (int i = 0; i < tempNumberOfItems; i++)
            {
                myItems.Add(new Item());
            }
        }

        public void Open(Player.Player aPlayer)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempChoice = 0,
                tempTextOffset = tempWHD2 - 10;
            aPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 12);
            Console.Write("You approach the chest and try to open it.");
            System.Threading.Thread.Sleep(1500);
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 10);
            Console.Write("It is locked...");

            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 8);
            Console.Write("Do wish to unlock it?");
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 6);
            Console.Write("[1] Yes ");
            Utilities.Utility.PrintInColour("(-25 gold)", ConsoleColor.DarkRed);
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
            if (!myIsMimic)
            {
                switch (tempChoice)
                {
                    case 1:
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

                        break;
                    case 2:

                        break;
                }
            }
            else
            {
                Console.SetCursorPosition(tempWWD2 - 21, tempWHD2 - 12);
                Console.Write("Oh no, it's a mimic. What a shame...");
            }
        }
    }
}