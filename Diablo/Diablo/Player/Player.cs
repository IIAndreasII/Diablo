using System;
using System.Collections.Generic;

namespace Diablo.Player
{
    public enum BattleActions
    {
        OFFENSIVE,
        DEFENSIVE,
        USEITEM,
        FLEE,
        ABSTAIN
    }

    public class Player
    {
        #region Variables
        private int
            myMana,
            myMaxMana,

            myDamage,
            myTempStrength = 0,
            mySpellDamage,
            myArmourRating,
            myTempArmourRating = 0,
            myArmourBuff = 0,

            myGold,
            myHPPotionAmount,
            myManaPotionAmount,
            myInventoryCapacity,

            myLevel,
            myEXP,
            myRequiredEXP,

            myStrength,
            myAgility,
            myIntelligence,
            myWisdom,
            myLuck,
            
            myStrBuff = 0,
            myAgilityBuff = 0,
            myLuckBuff = 0,
            myStaminaBuff = 0;

        private float
            myStamina,
            myMaxStamina,

            myHealth,
            myTempHealth = 0,
            myHealthBuff,
            myMaxHealth;

        private bool
            myIsDefending;

        private List<Loot.Item>
            myInventory;
        private List<Loot.Scroll>
            myAppliedScrolls;

        private Loot.Item
            myEquippedHelmet,
            myEquippedChestplate,
            myEquippedTrousers,
            myEquippedBoots,
            myEquippedShield,
            myEquippedWeapon;
        private Loot.Trinket
            myEquippedTrinket;
        #endregion

        public Player()
        {
            myLevel = 1;
            myEXP = 0;
            myRequiredEXP = 50;
            myStrength = Utilities.Utility.GetRNG().Next(5, 11);                  // Antal procent mer skada
            myAgility = Utilities.Utility.GetRNG().Next(5, 11);                   // Antal procent chans det är att undvika en attack
            myMaxStamina = Utilities.Utility.GetRNG().Next(100, 121);             // Antal procent av maxHP
            myIntelligence = Utilities.Utility.GetRNG().Next(5, 11);
            myWisdom = Utilities.Utility.GetRNG().Next(5, 11);
            myLuck = Utilities.Utility.GetRNG().Next(5, 11);                      // Antal procent chans för att hitta extra loot                                                           

            myMaxHealth = 100;
            myMaxMana = 100;
            myMana = myMaxMana;
            myDamage = 15;
            mySpellDamage = 20;
            myGold = 50;
            myHPPotionAmount = 1;
            myManaPotionAmount = 1;
            myInventoryCapacity = 50;

            myInventory = new List<Loot.Item>();
            myAppliedScrolls = new List<Loot.Scroll>();
            myEquippedTrinket = new Loot.Trinket("Basicness");
            myEquippedTrinket.ApplyBuff(this);
            myEquippedHelmet = new Loot.Armour(Loot.ItemType.HELMET, "Basicness", 2); // Equip:ad gear är på en och inte i ens väska, därför läggs dem inte in i inventory:t
            myEquippedChestplate = new Loot.Armour(Loot.ItemType.CHESTPLATE, "Basicness", 4);
            myEquippedTrousers = new Loot.Armour(Loot.ItemType.TROUSERS, "Basicness", 3);
            myEquippedBoots = new Loot.Armour(Loot.ItemType.BOOTS, "Basicness", 1);
            myEquippedWeapon = new Loot.Weapon("Basicness", 15);
            myEquippedShield = new Loot.Armour(Loot.ItemType.SHIELD, "Basicness", 5);
            myArmourRating = myEquippedBoots.GetRating() + myEquippedTrousers.GetRating() + myEquippedChestplate.GetRating() + myEquippedHelmet.GetRating() + myEquippedShield.GetRating() + myArmourBuff;
            myInventory.Add(Factories.LootFactory.CreateScroll());
            myStamina = myMaxStamina;
            myHealth = myMaxHealth * myStamina / 100;
        }

        /// <summary>
        /// Prints UI
        /// </summary>
        public void PrintUI()
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            Console.Clear();
            Utilities.Utility.PrintPentagram(tempWWD2 - 57, tempWHD2 - 12, ConsoleColor.DarkRed);
            Utilities.Utility.PrintPentagram(tempWWD2 + 22, tempWHD2 - 12, ConsoleColor.DarkRed);

            Console.SetCursorPosition(tempWWD2 - 23, tempWHD2 + 5);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 23, tempWHD2 + 6);
            Utilities.Utility.PrintInColour(" " + (myHealth + myTempHealth) + @"/" + myMaxHealth, ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 23, tempWHD2 + 7);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Red);   
                     
            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 + 5);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 +  6);
            Utilities.Utility.PrintInColour(@"  Dmg: " + myDamage.ToString(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 + 7);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Gray);

            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 + 5);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 + 6);
            Utilities.Utility.PrintInColour(@"  Arm: " + myArmourRating.ToString(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 + 7);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Gray);

            Console.SetCursorPosition(tempWWD2 + 10, tempWHD2 + 5);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 + 10, tempWHD2 + 6);
            Utilities.Utility.PrintInColour(@"  " + myMana + "/" + myMaxMana.ToString(), ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 + 10, tempWHD2 + 7);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Blue);

            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 + 8);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 + 9);
            Utilities.Utility.PrintInColour(@"  Str: " + (myStrength + myTempStrength), ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 + 10);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.DarkRed);

            Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 + 8);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Magenta);
            Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 + 9);
            Utilities.Utility.PrintInColour(@"  Agi: " + myAgility.ToString(), ConsoleColor.Magenta);
            Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 + 10);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Magenta);

            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 + 8);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Cyan);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 + 9);
            Utilities.Utility.PrintInColour(@"  Int: " + myIntelligence.ToString(), ConsoleColor.Cyan);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 + 10);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Cyan);

            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 + 11);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 + 12);
            Utilities.Utility.PrintInColour(@"Sta:" + myStamina.ToString() + "/" + myMaxStamina.ToString(), ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 + 13);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Green);

            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 + 11);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.DarkMagenta);
            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 + 12);
            Utilities.Utility.PrintInColour(@"  Wis: " + myWisdom.ToString(), ConsoleColor.DarkMagenta);
            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 + 13);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.DarkMagenta);
        }

        #region Stats
        /// TODO: Add visual stuff
        /// <summary>
        /// Levels up the player
        /// </summary>
        private void LevelUp()
        {
            int
               tempWWD2 = Console.WindowWidth / 2,
               tempWHD2 = Console.WindowHeight / 2;
            myLevel++;
            myEXP -= myRequiredEXP;
            myRequiredEXP *= 2;
            myMaxHealth *= 1.2f;
            myHealth = myMaxHealth;
            myMaxMana += 20;
            myMana = myMaxMana;
            myStrength++;
            myAgility += 2;
            myMaxStamina *= 1.2f;
            myLuck++;
            myWisdom++;
            myIntelligence++;
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 5, tempWHD2 - 12);
            Console.Write("Level up!");
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 10);
            Console.Write("Max health");
            Utilities.Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 9);
            Console.Write("Max mana");
            Utilities.Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 8);
            Console.Write("Max stamina");
            Utilities.Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 7);
            Console.Write("Strength");
            Utilities.Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 6);
            Console.Write("Agility");
            Utilities.Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 5);
            Console.Write("Wisdom");
            Utilities.Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 4);
            Console.Write("Intelligence");
            Utilities.Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 3);
            Console.Write("Luck");
            Utilities.Utility.PrintInColour("+", ConsoleColor.Green);
            System.Threading.Thread.Sleep(3000);
        }

        /// <summary>
        /// Recharges stamina
        /// </summary>
        public void Rest()
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            if (myGold - 10 < 0)
            {
                Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 3);
                Console.Write("Insufficient funds!");
                System.Threading.Thread.Sleep(750);
            }
            else
            {
                PrintUI();
                Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                Console.Write("You light a fire and rest.");
                System.Threading.Thread.Sleep(2000);
                Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 10);
                Console.Write("You re-gained ");
                Utilities.Utility.PrintInColour("20", ConsoleColor.Green);
                Console.Write(" stamina!");
                System.Threading.Thread.Sleep(1500);
                Console.SetCursorPosition(tempWWD2 - 5, tempWHD2 - 8);
                Utilities.Utility.PrintInColour("-10 ", ConsoleColor.Red);
                Console.Write("gold!");
                System.Threading.Thread.Sleep(1000);
                AddStamina(20);
                SubtractGold(10);
            }
        }

        /// <summary>
        /// Resets all stats to their default value (damage and armour is not affected)
        /// </summary>
        public void LongRest()
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            myStamina = myMaxStamina;
            myHealth = myMaxHealth * (myStamina / 100);
            myMana = myMaxMana;
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 - 12);
            Console.Write("You pitch a tent and light a fire");
            System.Threading.Thread.Sleep(2000);
            Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 - 10);
            Console.Write("Full recovery!");
            System.Threading.Thread.Sleep(1500);
        }

        /// <summary>
        /// Adds given amount of stamina
        /// </summary>
        /// <param name="anAmountToAdd">The amount to add</param>
        public void AddStamina(int anAmountToAdd)
        {
            myStamina += anAmountToAdd;
            if (myStamina > myMaxStamina)
            {
                myStamina = myMaxStamina;
            }
            myHealth += anAmountToAdd * 0.2f;
            if(myHealth > ((float)myMaxStamina / 100) * myMaxHealth)
            {
                myHealth = myMaxHealth * (float)myMaxStamina / 100;
            }
        }

        /// <summary>
        /// Subtracts stamina with a lower threshold of 10
        /// </summary>
        /// <param name="anAmountToSubtract">The amount to subtract</param>
        public void SubtractStamina(int anAmountToSubtract)
        {
            myStamina -= anAmountToSubtract;
            if(myStamina < 10)
            {
                myStamina = 10;
            }
            if(myHealth > (float)myStamina / 100 * myMaxHealth)
            {
                myHealth = (float)myStamina / 100 * myMaxHealth;
            }
        }

        /// <summary>
        /// Adds given amount of exp to the player and checks if the player levels up
        /// </summary>
        /// <param name="anAmountToAdd">EXP to add</param>
        public void AddEXP(int anAmountToAdd)
        {
            myEXP += anAmountToAdd;
            UpdateEXP();
        }
        #endregion

        #region Updates
        /// <summary>
        /// Updates the player in all ways
        /// </summary>
        public void Update()
        {
            UpdateEXP();
            UpdateScrollEffects();   
        }

        /// <summary>
        /// Updates the applied scrolleffects
        /// </summary>
        private void UpdateScrollEffects()
        {
            for (int i = myAppliedScrolls.Count; i > 0; i--)
            {
                if (myAppliedScrolls[i - 1].Decay(this))
                {
                    myAppliedScrolls.Remove(myAppliedScrolls[i - 1]);
                }        
            }        
        }

        /// <summary>
        /// Checks whether the player levels up
        /// </summary>
        private void UpdateEXP()
        {
            if (myRequiredEXP <= myEXP)
            {
                LevelUp();
            }
        }
        #endregion

        #region Inventory     
        /// <summary>
        /// Equips the player with given item
        /// </summary>
        /// <param name="anItem">Item to equip</param>      
        public void Equip(Loot.Item anItem)
        {
            Loot.Item tempItem;
            switch (anItem.GetItemType())
            {
                case Loot.ItemType.HELMET:
                    tempItem = myEquippedHelmet;
                    myEquippedHelmet = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;
                case Loot.ItemType.CHESTPLATE:
                    tempItem = myEquippedChestplate;
                    myEquippedChestplate = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;
                case Loot.ItemType.TROUSERS:
                    tempItem = myEquippedTrousers;
                    myEquippedTrousers = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;
                case Loot.ItemType.BOOTS:
                    tempItem = myEquippedBoots;
                    myEquippedBoots = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;
                case Loot.ItemType.WEAPON:
                    tempItem = myEquippedWeapon;
                    myEquippedWeapon = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;
                case Loot.ItemType.SHIELD:
                    tempItem = myEquippedShield;
                    myEquippedShield = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;
                case Loot.ItemType.TRINKET:
                    tempItem = myEquippedTrinket;
                    myEquippedTrinket = (Loot.Trinket)anItem;
                    ResetBuffs();
                    myEquippedTrinket.ApplyBuff(this);
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;
            }
            myDamage = myEquippedWeapon.GetRating();
            myArmourRating = myEquippedBoots.GetRating() + myEquippedTrousers.GetRating() + myEquippedChestplate.GetRating() + myEquippedHelmet.GetRating() + myEquippedShield.GetRating() + myArmourBuff;
        }

        /// <summary>
        /// Equips all the best items in the list
        /// </summary>
        public void EquipBestItems()
        {
            for (int i = 0; i < myInventory.Count; i++)
            {
                switch (myInventory[i].GetItemType())
                {
                    case Loot.ItemType.HELMET:
                        if(myInventory[i].GetRating() > myEquippedHelmet.GetRating())
                        {
                            Equip(myInventory[i]);
                        }
                        break;
                    case Loot.ItemType.CHESTPLATE:
                        if(myInventory[i].GetRating() > myEquippedChestplate.GetRating())
                        {
                            Equip(myInventory[i]);
                        }
                        break;
                    case Loot.ItemType.TROUSERS:
                        if (myInventory[i].GetRating() > myEquippedTrousers.GetRating())
                        {
                            Equip(myInventory[i]);
                        }
                        break;
                    case Loot.ItemType.BOOTS:
                        if(myInventory[i].GetRating() > myEquippedBoots.GetRating())
                        {
                            Equip(myInventory[i]);
                        }
                        break;
                    case Loot.ItemType.WEAPON:
                        if (myInventory[i].GetRating() > myEquippedWeapon.GetRating())
                        {
                            Equip(myInventory[i]);
                        }
                        break;
                    case Loot.ItemType.SHIELD:
                        if (myInventory[i].GetRating() > myEquippedShield.GetRating())
                        {
                            Equip(myInventory[i]);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Let's the player browse the given type of items in his inventory
        /// </summary>
        /// <param name="aType">Item type to browse</param>
        public void BrowseItems(Loot.ItemType aType)
        {
            int tempOffset = -10,
                tempItemCount = 0,
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            ConsoleColor
                tempPrintColour = ConsoleColor.Gray;
            List<int>
                tempIndexes = new List<int>();
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 12);
            switch (aType)
            {
                case Loot.ItemType.HELMET:
                    Console.Write("Equipped: ");
                    Utilities.Utility.PrintInColour("[" + myEquippedHelmet.GetRating() + "]" + myEquippedHelmet.GetFullName(), ConsoleColor.Gray);
                    break;
                case Loot.ItemType.CHESTPLATE:
                    Console.Write("Equipped: ");
                    Utilities.Utility.PrintInColour("[" + myEquippedChestplate.GetRating() + "]" + myEquippedChestplate.GetFullName(), ConsoleColor.Gray);
                    break;
                case Loot.ItemType.TROUSERS:
                    Console.Write("Equipped: ");
                    Utilities.Utility.PrintInColour("[" + myEquippedTrousers.GetRating() + "]" + myEquippedTrousers.GetFullName(), ConsoleColor.Gray);
                    break;
                case Loot.ItemType.BOOTS:
                    Console.Write("Equipped: ");
                    Utilities.Utility.PrintInColour("[" + myEquippedBoots.GetRating() + "]" + myEquippedBoots.GetFullName(), ConsoleColor.Gray);
                    break;
                case Loot.ItemType.WEAPON:
                    Console.Write("Equipped: ");
                    Utilities.Utility.PrintInColour("[" + myEquippedWeapon.GetRating() + "]" + myEquippedWeapon.GetFullName(), ConsoleColor.Gray);
                    break;
                case Loot.ItemType.SHIELD:
                    Console.Write("Equipped: ");
                    Utilities.Utility.PrintInColour("[" + myEquippedShield.GetRating() + "]" + myEquippedShield.GetFullName(), ConsoleColor.Gray);
                    break;
                case Loot.ItemType.SCROLL:
                    Console.Write("Available scrolls:");
                    tempPrintColour = ConsoleColor.DarkMagenta;
                    break;
                case Loot.ItemType.TRINKET:
                    Console.Write("Equipped: ");
                    Utilities.Utility.PrintInColour(myEquippedTrinket.GetFullName() + " [+" + myEquippedTrinket.GetBuffType().ToString() + "]", ConsoleColor.Green);
                    tempPrintColour = ConsoleColor.Green;
                    break;
            }

            for (int i = 0; i < myInventory.Count; i++)
            {
                if (myInventory[i].GetItemType() == aType)
                {
                    tempItemCount++;
                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + tempOffset);
                    Console.Write(" [" + (tempItemCount) + "]");
                    Utilities.Utility.PrintInColour((myInventory[i].GetItemType() == Loot.ItemType.SCROLL || myInventory[i].GetItemType() == Loot.ItemType.TRINKET ? " " : ("[" + (myInventory[i].GetItemType() == Loot.ItemType.WEAPON ? myInventory[i].GetRating().ToString() : myInventory[i].GetRating().ToString()) + "]")) + myInventory[i].GetFullName(), tempPrintColour);
                    tempIndexes.Add(i);
                    tempOffset++;
                }
            }         
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2);
            Console.Write("[0] Back");
            switch (Utilities.Utility.GetDigitInput(-19, 1, tempItemCount, out int tempChoice))
            {
                case 0:
                    OpenInventory();
                    break;
                default:
                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 2);
                    Console.Write("[1] " + (aType == Loot.ItemType.SCROLL ? "Apply" : "Equip") + " [2] Throw away [0] Back");
                    switch (Utilities.Utility.GetDigitInput(-19, 3, 2, out int tempSecondChoice))
                    {
                        case 0:
                            OpenInventory();
                            break;
                        case 1:
                            if (aType == Loot.ItemType.SCROLL)
                            {
                                ApplyScrollEffect((Loot.Scroll)myInventory[tempIndexes[tempChoice - 1]], out string tempEffect, out int tempEffectAmount);
                                PrintUI();
                                Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 12);
                                Console.Write("Effect applied!");
                                myInventory.RemoveAt(tempIndexes[tempChoice - 1]);
                                Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 10);
                                Utilities.Utility.PrintInColour("+" + tempEffectAmount.ToString() + " ", ConsoleColor.Green);
                                Console.Write(tempEffect);
                                System.Threading.Thread.Sleep(2000);
                            }
                            else
                            {
                                Equip(myInventory[tempIndexes[tempChoice - 1]]);
                            }
                            break;
                        case 2:
                            myInventory.RemoveAt(tempIndexes[tempChoice - 1]);
                            break;
                        default:
                            BrowseItems(aType);
                            break;
                    }
                    OpenInventory();
                    break;
            }    
        }
     
        /// <summary>
        /// Opens the inventory and let's the player equip or use items
        /// </summary>
        public void OpenInventory()
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            #region Doodle Sequence
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 12);
            Console.Write("Gold: " + myGold.ToString() + "■       Inventory        (" + (myHPPotionAmount + myManaPotionAmount + myInventory.Count) + "/" + myInventoryCapacity + ")");
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 10);
            Console.Write("[1]");
            Utilities.Utility.PrintInColour(" ■ HP-Potions: " + myHPPotionAmount.ToString(), ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 - 10);
            Console.Write("[3]");
            Utilities.Utility.PrintInColour(" ■ Scrolls", ConsoleColor.DarkMagenta);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 - 9);
            Console.Write("[4]");
            Utilities.Utility.PrintInColour(" ■ Trinkets", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 + 7, tempWHD2 - 8);
            Utilities.Utility.PrintInColour("[+" + myEquippedTrinket.GetBuffType().ToString() + "]", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 9);
            Console.Write("[2]");
            Utilities.Utility.PrintInColour(" ■ Mana-Potions: " + myManaPotionAmount.ToString(), ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 7);
            Console.Write("[5] ");
            Utilities.Utility.PrintInColour("╔╤╗ [" + myEquippedHelmet.GetRating() + "]" + myEquippedHelmet.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 6);
            Utilities.Utility.PrintInColour("╚═╝ " + myEquippedHelmet.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 4);
            Console.Write("[6]");
            Utilities.Utility.PrintInColour("╔╦═╦╗[" + myEquippedChestplate.GetRating() + "]" + myEquippedChestplate.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 3);
            Utilities.Utility.PrintInColour("╚═╝ " + myEquippedChestplate.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 1);
            Console.Write("[7] ");
            Utilities.Utility.PrintInColour("╔═╗ [" + myEquippedTrousers.GetRating() + "]" + myEquippedTrousers.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2);
            Utilities.Utility.PrintInColour("║ ║ " + myEquippedTrousers.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 + 2);
            Console.Write("[8] ");
            Utilities.Utility.PrintInColour("    [" + myEquippedBoots.GetRating() + "]" + myEquippedBoots.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 + 3);
            Utilities.Utility.PrintInColour("╝ ╚ " + myEquippedBoots.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 - 7);
            Console.Write("[9]");
            Utilities.Utility.PrintInColour(@"/\  [" + myEquippedWeapon.GetRating() + "]" + myEquippedWeapon.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 - 6);
            Utilities.Utility.PrintInColour(@"||  " + myEquippedWeapon.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 - 5);
            Utilities.Utility.PrintInColour(@"||", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 - 4);
            Utilities.Utility.PrintInColour(@"||", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 - 3);
            Utilities.Utility.PrintInColour("||", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 - 2);
            Utilities.Utility.PrintInColour(@"O==\/==O", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 - 1);
            Utilities.Utility.PrintInColour("][", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2);
            Utilities.Utility.PrintInColour("()", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 7, tempWHD2 - 4);
            Console.Write("[10]");
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 - 4);
            Utilities.Utility.PrintInColour(@"/---\", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 - 3);
            Utilities.Utility.PrintInColour(@"| o |", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 - 2);
            Utilities.Utility.PrintInColour(@"\---/", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 8, tempWHD2);
            Utilities.Utility.PrintInColour("[" + myEquippedShield.GetRating().ToString() + "]Shield of", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 8, tempWHD2 + 1);
            Utilities.Utility.PrintInColour(myEquippedShield.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 + 2);
            Console.Write("[0] Close inventory");
            #endregion
            switch (Utilities.Utility.GetDigitInput(2, 3, 10))
            {
                case 1:
                    DrinkHPPotion();
                    OpenInventory();
                    break;
                case 2:
                    DrinkManaPotion();
                    OpenInventory();
                    break;
                case 3:
                    BrowseItems(Loot.ItemType.SCROLL);
                    break;
                case 4:
                    BrowseItems(Loot.ItemType.TRINKET);
                    break;
                case 5:
                    BrowseItems(Loot.ItemType.HELMET);
                    break;
                case 6:
                    BrowseItems(Loot.ItemType.CHESTPLATE);
                    break;
                case 7:
                    BrowseItems(Loot.ItemType.TROUSERS);
                    break;
                case 8:
                    BrowseItems(Loot.ItemType.BOOTS);
                    break;
                case 9:
                    BrowseItems(Loot.ItemType.WEAPON);
                    break;
                case 10:
                    BrowseItems(Loot.ItemType.SHIELD);
                    break;
                default:
                    break;
            }
            
        }

        /// <summary>
        /// Adds items in the parameter-list to the inventory and clears the parameter-list
        /// </summary>
        /// <param name="anItemList">Items to add</param>
        public void AddItemsToInventory(List<Loot.Item> anItemList)
        {
            foreach (Loot.Item tempItem in anItemList)
            {
                if (myInventory.Count + myManaPotionAmount + myHPPotionAmount < myInventoryCapacity)
                {
                    myInventory.Add(tempItem);
                }
            }
            anItemList.Clear();
        }

        /// <summary>
        /// Applies the scrolleffect to the player
        /// </summary>
        /// <param name="aScroll">A scroll which's effect shall be applied</param>
        private void ApplyScrollEffect(Loot.Scroll aScroll, out string anEffect, out int anEffectAmount)
        {
            myAppliedScrolls.Add(aScroll);
            anEffectAmount = 0;
            anEffect = string.Empty;
            switch (aScroll.GetScrollEffect())
            {
                case Loot.ScrollEffect.ARMBUFF:
                    myTempArmourRating = aScroll.GetArmourBuff();
                    anEffectAmount = aScroll.GetArmourBuff();
                    anEffect = "temporary armour!";
                    break;
                case Loot.ScrollEffect.STRBUFF:
                    myTempStrength = aScroll.GetStrengthBuff();
                    anEffectAmount = aScroll.GetStrengthBuff();
                    anEffect = "temporary strength!";
                    break;
                case Loot.ScrollEffect.HPBUFF:
                    myTempHealth = aScroll.GetHealthBuff();
                    anEffectAmount = aScroll.GetHealthBuff();
                    anEffect = "temporary health!";
                    break;
            }
        }

        /// <summary>
        /// Consumes 1 hp-potion if the player has one or more
        /// </summary>
        private void DrinkHPPotion()
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            if (myHPPotionAmount > 0)
            {
                myHPPotionAmount -= 1;
                myHealth += 25;
                if(myHealth > myMaxHealth * myStamina / 100)
                {
                    myHealth = myMaxHealth * myStamina / 100;
                }
            }
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 16, tempWHD2 - 12);
            Console.Write("You have drunk a health-potion.");
            System.Threading.Thread.Sleep(1000);
            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 10);
            Console.Write("You re-gained ");
            Utilities.Utility.PrintInColour("25", ConsoleColor.Green);
            Console.Write(" health!");
            System.Threading.Thread.Sleep(1500);
        }

        /// <summary>
        /// Consumes 1 mana-potion if the player has one or more
        /// </summary>
        private void DrinkManaPotion()
        {
            int
               tempWWD2 = Console.WindowWidth / 2,
               tempWHD2 = Console.WindowHeight / 2;
            if (myManaPotionAmount > 0)
            {
                myManaPotionAmount -= 1;
                myMaxMana += 25;
                if(myMana > myMaxMana)
                {
                    myMana = myMaxMana;
                }
            }
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 16, tempWHD2 - 12);
            Console.Write("You have drunk a mana-potion.");
            System.Threading.Thread.Sleep(1000);
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 10);
            Console.Write("You re-gained ");
            Utilities.Utility.PrintInColour("25", ConsoleColor.Blue);
            Console.Write(" mana!");
            System.Threading.Thread.Sleep(1500);
        }

        /// <summary>
        /// Adds the given amount of hp-potions
        /// </summary>
        /// <param name="anAmountToAdd">The amount to add</param>
        public void AddHealthPotions(int anAmountToAdd)
        {
            if (myInventory.Count + myHPPotionAmount + myManaPotionAmount < myInventoryCapacity)
            {
                myHPPotionAmount += anAmountToAdd;
            }
        }

        /// <summary>
        /// Adds the given amount of mana-potions
        /// </summary>
        /// <param name="anAmountToAdd">The amount to add</param>
        public void AddManaPotions(int anAmountToAdd)
        {
            if (myInventory.Count + myHPPotionAmount + myManaPotionAmount < myInventoryCapacity)
            {
                myManaPotionAmount += anAmountToAdd;
            }
        }

        /// <summary>
        /// Adds the given amount of gold
        /// </summary>
        /// <param name="anAmountToAdd">The amount to add</param>
        public void AddGold(int anAmountToAdd)
        {
            myGold += anAmountToAdd;
        }

        /// <summary>
        /// Subtracts the given amount of gold if the player has at least that amount
        /// </summary>
        /// <param name="anAmountToSubtract">The amount to subtract</param>
        /// <returns>Returns true if the operation was successful</returns>
        public bool SubtractGold(int anAmountToSubtract)
        {
            if (myGold >= anAmountToSubtract)
            {
                myGold -= anAmountToSubtract;
                return true;
            }
            return false;
        }
        #endregion

        #region Battle
        /// <summary>
        /// Deathsequence
        /// </summary>
        public void DeathSequence()
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempTextOffset = 31;
            Console.Clear();
            Utilities.Utility.PrintPentagram(tempWWD2 - 58, tempWHD2 - 5, ConsoleColor.DarkRed);
            Utilities.Utility.PrintPentagram(tempWWD2 +23, tempWHD2 - 5, ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 14);
            Utilities.Utility.PrintInColour("╦   ╦   ╔════╗   ╦    ╦      ╦════╗    ═╦═   ╦═════╗   ╦════╗", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 13);
            Utilities.Utility.PrintInColour("║   ║   ║    ║   ║    ║      ║     ║    ║    ║         ║     ║", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 12);
            Utilities.Utility.PrintInColour("║   ║   ║    ║   ║    ║      ║     ║    ║    ║         ║     ║", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 11);
            Utilities.Utility.PrintInColour("╚═╦═╝   ║    ║   ║    ║      ║     ║    ║    ╬════     ║     ║", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 10);
            Utilities.Utility.PrintInColour("  ║     ║    ║   ║    ║      ║     ║    ║    ║         ║     ║", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 9);
            Utilities.Utility.PrintInColour("  ║     ║    ║   ║    ║      ║     ║    ║    ║         ║     ║", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 8);
            Utilities.Utility.PrintInColour("  ║     ║    ║   ║    ║      ║     ║    ║    ║         ║     ║", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 7);
            Utilities.Utility.PrintInColour("  ╩     ╚════╝   ╚════╝      ╩════╝    ═╩═   ╩═════╝   ╩════╝", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - 4, tempWHD2 - 1);
            Console.Write("[1] Menu");
            Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 + 1);
            Console.Write("[2] Exit game");
            switch (Utilities.Utility.GetDigitInput(-2, 3, 2))
            {
                case 1:
                    Program.Reboot();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
            Program.Reboot();
        }

        /// <summary>
        /// Deals damage to given enemy
        /// </summary>
        /// <param name="anEnemy"></param>
        public void DealDamage(Enemies.Enemy anEnemy, bool shouldBeStunned)
        {
            anEnemy.TakeDamage(myDamage, myStrength + myTempStrength, shouldBeStunned);
        }

        /// <summary>
        /// Deals given damage to given enemy
        /// </summary>
        /// <param name="anEnemy"></param>
        public void DealDamage(Enemies.Enemy anEnemy, float aDamage, bool ShouldBeStunned, int aSpellIndex = 0)
        {
            anEnemy.TakeDamage(aDamage, myStrength + myTempStrength, ShouldBeStunned, aSpellIndex);
        }

        /// <summary>
        /// Makes the player take damage. Returns false if no damage was taken
        /// </summary>
        /// <param name="aDamage">A damage to take</param>
        /// <param name="DamageTaken">When the method returns, a value on given parameter is set and spat out</param>
        /// <returns>Returns false if no damage was taken</returns>
        public bool TakeDamage(float aDamage, out float DamageTaken)
        {
            int tempAgility = myAgility;
            if (myIsDefending)
            {
                tempAgility += 20;
            }
            if (Utilities.Utility.GetRNG().Next(1, 101) > tempAgility)
            {
                if (!myIsDefending)
                {
                    DamageTaken = aDamage - aDamage * ((float)myArmourRating + (float)myTempArmourRating) / 100f;       
                }
                else
                {
                    DamageTaken = aDamage - aDamage * ((float)myArmourRating + (float)myTempArmourRating) / 100f - aDamage * 0.6f;
                }
                if(myTempHealth > 0)
                {
                    myTempHealth -= DamageTaken;
                    if(myTempHealth < 0)
                    {
                        myHealth += myTempHealth;
                    }
                }
                else
                {
                    myHealth -= DamageTaken;
                }
                myHealth = (float)Math.Round(myHealth, 2);
                return true;
            }
            else
            {
                DamageTaken = 0;
                return false;
            }
        }

        /// <summary>
        /// Let's the player choose what to do during a battle. Returns chosen action
        /// </summary>
        /// <returns>Returns chosen action</returns>
        public BattleActions ChooseBattleAction()
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 12);
            Console.Write("What will you do?");
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 10);
            Console.Write("[1] Offensive [2] Defensive");
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 9);
            Console.Write("[3] Use item  [4] Flee");
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 8);
            Console.Write("[5] Abstain");
            switch (Utilities.Utility.GetDigitInput(-1, -6, 5))
            {
                case 1:
                    myIsDefending = false;
                    return BattleActions.OFFENSIVE;
                case 2:
                    myIsDefending = true;
                    return BattleActions.DEFENSIVE;
                case 3:
                    myIsDefending = false;
                    return BattleActions.USEITEM;
                case 4:
                    myIsDefending = false;
                    return BattleActions.FLEE;
                case 5:
                    myIsDefending = false;
                    return BattleActions.ABSTAIN;
                default:
                    myIsDefending = false;
                    return BattleActions.ABSTAIN;
                }
            }
        #endregion

        #region Get
        public int GetLuck()
        {
            return myLuck;
        }

        public int GetLevel()
        {
            return myLevel;
        }

        public int GetStrength()
        {
            return myStrength;
        }

        public int GetAgility()
        {
            return myAgility;
        }

        public int GetHPPotionAmount()
        {
            return myHPPotionAmount;
        }

        public int GetManaPotionAmount()
        {
            return myManaPotionAmount;
        }

        public int GetMana()
        {
            return myMana;
        }

        public int GetDamage()
        {
            return myDamage;
        }

        public int GetSpellDamage()
        {
            return mySpellDamage;
        }

        public int GetArmourRating()
        {
            return myArmourRating;
        }

        public float GetStamina()
        {
            return myStamina;
        }

        public float GetHealth()
        {
            return myHealth;
        }

        public bool GetIsDefending()
        {
            return myIsDefending;
        }
        #endregion

        #region Set
        public void SetInventoryCapacity(int aNewCapacity)
        {
            myInventoryCapacity = aNewCapacity;
        }

        public void SetIsDefending(bool aNewValue)
        {
            myIsDefending = aNewValue;
        }

        public void SetTempHealth(float aHealth)
        {
            myTempHealth += aHealth;
            if (myTempHealth < 0)
            {
                myTempHealth = 0;
            }
        }

        public void SetTempStrength(int aDamage)
        {
            myTempStrength += aDamage;
            if(myTempStrength < 0)
            {
                myTempStrength = 0;
            }
        }

        public void SetTempArmourRating(int anArmourRating)
        {
            myTempArmourRating += anArmourRating;
            if(myTempArmourRating < 0)
            {
                myTempArmourRating = 0;
            }
        }

        public void SetStrengthBuff(int aStrengthBuff)
        {
            myStrBuff = aStrengthBuff;
            myStrength += aStrengthBuff;
        }

        public void SetArmourBuff(int anArmourBuff)
        {
            myArmourBuff = anArmourBuff;
            myArmourRating += myArmourBuff;
        }

        public void SetHealthBuff(float aHealthBuff)
        {
            myHealthBuff = myMaxHealth * (aHealthBuff / 100);
            myMaxHealth += myHealthBuff;
        }

        public void SetAgilityBuff(int anAgilityBuff)
        {
            myAgilityBuff = anAgilityBuff;
            myAgility += myAgilityBuff;
        }

        public void SetLuckBuff(int aLuckBuff)
        {
            myLuckBuff = aLuckBuff;
            myLuck += myLuckBuff;
        }

        public void SetStaminaBuff(int aStaminabuff)
        {
            myStaminaBuff = aStaminabuff;
            myMaxStamina += myStaminaBuff;
        }

        public void SetMana(int aValueToSubtract)
        {
            myMana -= aValueToSubtract;
        }

        public void ResetBuffs()
        {
            if (myHealthBuff > 0)
            {
                myMaxHealth -= myHealthBuff;
                myHealthBuff = 0;
            }
            if (myStrBuff > 0)
            {
                myStrength -= myStrBuff;
                myStrBuff = 0;
            }
            if(myArmourBuff > 0)
            {
                myArmourRating -= myArmourBuff;
                myArmourBuff = 0;
            }
            if(myLuckBuff > 0)
            {
                myLuck -= myLuckBuff;
                myLuckBuff = 0;
            }
            if (myAgilityBuff > 0)
            {
                myAgility -= myAgilityBuff;
                myAgilityBuff = 0;
            }
            if(myStaminaBuff > 0)
            {
                myMaxStamina -= myStaminaBuff;
                myStaminaBuff = 0;
            }
        }
        #endregion
    }  
}