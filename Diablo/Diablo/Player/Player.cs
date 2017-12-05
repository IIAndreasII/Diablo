using Diablo.Localisation;
using Diablo.Loot;
using Diablo.Utilities;
using System;
using System.Collections.Generic;
using System.Threading;

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
        #region Values

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
            myStaminaBuff = 0,
            myIntelligenceBuff = 0,
            myWisdomBuff = 0;

        private float
            myStamina,
            myMaxStamina,

            myHealth,
            myTempHealth = 0,
            myHealthBuff,
            myMaxHealth;

        private bool
            myIsDefending;

        private List<Item>
            myInventory;

        private List<Scroll>
            myAppliedScrolls;

        private Item
            myEquippedHelmet,
            myEquippedChestplate,
            myEquippedTrousers,
            myEquippedBoots,
            myEquippedShield,
            myEquippedWeapon;

        private Trinket
            myEquippedTrinket;

        #endregion Values

        public Player()
        {
            myLevel = 1;
            myEXP = 0;
            myRequiredEXP = 50;
            myStrength = Utilities.Utility.GetRNG().Next(5, 11);
            myAgility = Utilities.Utility.GetRNG().Next(5, 11);
            myMaxStamina = Utilities.Utility.GetRNG().Next(100, 121);
            myIntelligence = Utilities.Utility.GetRNG().Next(5, 11);
            myWisdom = Utilities.Utility.GetRNG().Next(5, 11);
            myLuck = Utilities.Utility.GetRNG().Next(5, 11);

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
            myEquippedTrinket = new Loot.Trinket(Localisation.Language.GetBasicness());
            myEquippedTrinket.ApplyBuff(this);
            myEquippedHelmet = new Loot.Armour(Loot.ItemType.HELMET, Localisation.Language.GetBasicness(), 2);
            myEquippedChestplate = new Loot.Armour(Loot.ItemType.CHESTPLATE, Localisation.Language.GetBasicness(), 4);
            myEquippedTrousers = new Loot.Armour(Loot.ItemType.TROUSERS, Localisation.Language.GetBasicness(), 3);
            myEquippedBoots = new Loot.Armour(Loot.ItemType.BOOTS, Localisation.Language.GetBasicness(), 1);
            myEquippedWeapon = new Loot.Weapon(Localisation.Language.GetBasicness(), 15);
            myEquippedShield = new Loot.Armour(Loot.ItemType.SHIELD, Localisation.Language.GetBasicness(), 5);
            myArmourRating = myEquippedBoots.GetRating() + myEquippedTrousers.GetRating() + myEquippedChestplate.GetRating() + myEquippedHelmet.GetRating() + myEquippedShield.GetRating() + myArmourBuff;
            myInventory.Add(Factories.LootFactory.CreateScroll());
            myStamina = myMaxStamina;
            myHealth = myMaxHealth * myStamina / 100;
            myIsDefending = false;
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
            Utility.PrintPentagram(tempWWD2 - 57, tempWHD2 - 12, ConsoleColor.DarkRed);
            Utility.PrintPentagram(tempWWD2 + 22, tempWHD2 - 12, ConsoleColor.DarkRed);

            Console.SetCursorPosition(tempWWD2 - 23, tempWHD2 + 5);
            Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 23, tempWHD2 + 6);
            Utility.PrintInColour(" " + (myHealth + myTempHealth) + @"/" + myMaxHealth, ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 23, tempWHD2 + 7);
            Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Red);

            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 + 5);
            Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 + 6);
            Utility.PrintInColour(@"  Dmg: " + myDamage.ToString(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 + 7);
            Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Gray);

            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 + 5);
            Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 + 6);
            Utility.PrintInColour(@"  Arm: " + myArmourRating.ToString(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 + 7);
            Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Gray);

            Console.SetCursorPosition(tempWWD2 + 10, tempWHD2 + 5);
            Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 + 10, tempWHD2 + 6);
            Utility.PrintInColour(@"  " + myMana + "/" + myMaxMana.ToString(), ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 + 10, tempWHD2 + 7);
            Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Blue);

            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 + 8);
            Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 + 9);
            Utility.PrintInColour(@"  Str: " + (myStrength + myTempStrength), ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 + 10);
            Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.DarkRed);

            Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 + 8);
            Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Magenta);
            Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 + 9);
            Utility.PrintInColour(@"  Agi: " + myAgility.ToString(), ConsoleColor.Magenta);
            Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 + 10);
            Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Magenta);

            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 + 8);
            Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Cyan);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 + 9);
            Utility.PrintInColour(@"  Int: " + myIntelligence.ToString(), ConsoleColor.Cyan);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 + 10);
            Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Cyan);

            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 + 11);
            Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 + 12);
            Utility.PrintInColour(@"Sta:" + myStamina.ToString() + "/" + myMaxStamina.ToString(), ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 + 13);
            Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Green);

            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 + 11);
            Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.DarkMagenta);
            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 + 12);
            Utility.PrintInColour(@"  Wis: " + myWisdom.ToString(), ConsoleColor.DarkMagenta);
            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 + 13);
            Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.DarkMagenta);
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
            Math.Round(myMaxHealth, 2);
            myHealth = myMaxHealth;
            myMaxMana += 20;
            myMana = myMaxMana;
            myStrength++;
            myAgility += 2;
            myMaxStamina *= 1.2f;
            Math.Round(myMaxStamina, 2);
            myStamina = myMaxStamina;
            myLuck++;
            myWisdom++;
            myIntelligence++;
            mySpellDamage += 10;
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 5, tempWHD2 - 12);
            Console.Write(Language.GetLevelUp());
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 10);
            Console.Write(Language.GetMaxHealth());
            Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 9);
            Console.Write(Language.GetMaxMana());
            Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 8);
            Console.Write(Language.GetMaxStamina());
            Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 7);
            Console.Write(Language.GetStrength());
            Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 6);
            Console.Write(Language.GetAgility());
            Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 5);
            Console.Write(Language.GetWisdom());
            Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 4);
            Console.Write(Language.GetIntelligence());
            Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 3);
            Console.Write(Language.GetLuck());
            Utility.PrintInColour("+", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 2);
            Console.Write(Language.GetSpellDamage());
            Utility.PrintInColour("+", ConsoleColor.Green);
            Thread.Sleep(3000);
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
                Console.Write(Language.GetInsufficientFunds());
                Thread.Sleep(750);
            }
            else
            {
                PrintUI();
                Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                Console.Write(Language.GetLightFire());
                Thread.Sleep(2000);
                Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 10);
                Console.Write(Language.GetRegain());
                Utility.PrintInColour("20", ConsoleColor.Green);
                Console.Write(Language.GetRegainStamina());
                Thread.Sleep(1500);
                Console.SetCursorPosition(tempWWD2 - 5, tempWHD2 - 8);
                Utility.PrintInColour("-10 ", ConsoleColor.Red);
                Console.Write(Language.GetGold() + "!");
                Thread.Sleep(1000);
                AddStamina(20);
                SetGold(-10);
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
            Console.Write(Language.GetPitchTent());
            Thread.Sleep(2000);
            Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 - 10);
            Console.Write(Language.GetFullRecovery());
            Thread.Sleep(1500);
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
            if (myHealth > myMaxStamina / 100 * myMaxHealth)
            {
                myHealth = myMaxHealth * myMaxStamina / 100;
            }
        }

        /// <summary>
        /// Subtracts stamina with a lower threshold of 10
        /// </summary>
        /// <param name="anAmountToSubtract">The amount to subtract</param>
        public void SubtractStamina(int anAmountToSubtract)
        {
            myStamina -= anAmountToSubtract;
            if (myStamina < 10)
            {
                myStamina = 10;
            }
            if (myHealth > myStamina / 100 * myMaxHealth)
            {
                myHealth = myStamina / 100 * myMaxHealth;
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

        #endregion Stats

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

        #endregion Updates

        #region Inventory

        /// <summary>
        /// Equips the player with given item
        /// </summary>
        /// <param name="anItem">Item to equip</param>
        public void Equip(Item anItem)
        {
            Item tempItem;
            switch (anItem.GetItemType())
            {
                case ItemType.HELMET:
                    tempItem = myEquippedHelmet;
                    myEquippedHelmet = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;

                case ItemType.CHESTPLATE:
                    tempItem = myEquippedChestplate;
                    myEquippedChestplate = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;

                case ItemType.TROUSERS:
                    tempItem = myEquippedTrousers;
                    myEquippedTrousers = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;

                case ItemType.BOOTS:
                    tempItem = myEquippedBoots;
                    myEquippedBoots = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;

                case ItemType.WEAPON:
                    tempItem = myEquippedWeapon;
                    myEquippedWeapon = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;

                case ItemType.SHIELD:
                    tempItem = myEquippedShield;
                    myEquippedShield = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;

                case ItemType.TRINKET:
                    tempItem = myEquippedTrinket;
                    myEquippedTrinket = (Trinket)anItem;
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
                    case ItemType.HELMET:
                        if (myInventory[i].GetRating() > myEquippedHelmet.GetRating())
                        {
                            Equip(myInventory[i]);
                        }
                        break;

                    case ItemType.CHESTPLATE:
                        if (myInventory[i].GetRating() > myEquippedChestplate.GetRating())
                        {
                            Equip(myInventory[i]);
                        }
                        break;

                    case ItemType.TROUSERS:
                        if (myInventory[i].GetRating() > myEquippedTrousers.GetRating())
                        {
                            Equip(myInventory[i]);
                        }
                        break;

                    case ItemType.BOOTS:
                        if (myInventory[i].GetRating() > myEquippedBoots.GetRating())
                        {
                            Equip(myInventory[i]);
                        }
                        break;

                    case ItemType.WEAPON:
                        if (myInventory[i].GetRating() > myEquippedWeapon.GetRating())
                        {
                            Equip(myInventory[i]);
                        }
                        break;

                    case ItemType.SHIELD:
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
        public void BrowseItems(ItemType aType)
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
                case ItemType.HELMET:
                    Console.Write(Language.GetEquipped());
                    Utility.PrintInColour("[" + myEquippedHelmet.GetRating() + "]" + myEquippedHelmet.GetFullName(), ConsoleColor.Gray);
                    break;

                case ItemType.CHESTPLATE:
                    Console.Write(Language.GetEquipped());
                    Utility.PrintInColour("[" + myEquippedChestplate.GetRating() + "]" + myEquippedChestplate.GetFullName(), ConsoleColor.Gray);
                    break;

                case ItemType.TROUSERS:
                    Console.Write(Language.GetEquipped());
                    Utility.PrintInColour("[" + myEquippedTrousers.GetRating() + "]" + myEquippedTrousers.GetFullName(), ConsoleColor.Gray);
                    break;

                case ItemType.BOOTS:
                    Console.Write(Language.GetEquipped());
                    Utility.PrintInColour("[" + myEquippedBoots.GetRating() + "]" + myEquippedBoots.GetFullName(), ConsoleColor.Gray);
                    break;

                case ItemType.WEAPON:
                    Console.Write(Language.GetEquipped());
                    Utility.PrintInColour("[" + myEquippedWeapon.GetRating() + "]" + myEquippedWeapon.GetFullName(), ConsoleColor.Gray);
                    break;

                case ItemType.SHIELD:
                    Console.Write(Language.GetEquipped());
                    Utility.PrintInColour("[" + myEquippedShield.GetRating() + "]" + myEquippedShield.GetFullName(), ConsoleColor.Gray);
                    break;

                case ItemType.SCROLL:
                    Console.Write(Language.GetAvailableScrolls());
                    tempPrintColour = ConsoleColor.DarkMagenta;
                    break;

                case ItemType.TRINKET:
                    Console.Write(Language.GetEquipped());
                    Utility.PrintInColour(myEquippedTrinket.GetFullName() + " [+" + myEquippedTrinket.GetEffectType() + "]", ConsoleColor.Green);
                    tempPrintColour = ConsoleColor.Green;
                    break;
            }

            for (int i = 0; i < myInventory.Count; i++)
            {
                if (myInventory[i].GetItemType() == aType)
                {
                    tempItemCount++;
                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + tempOffset);
                    Console.Write(" [" + tempItemCount.ToString() + "]");
                    Utility.PrintInColour((myInventory[i].GetItemType() == ItemType.SCROLL || myInventory[i].GetItemType() == ItemType.TRINKET ? " " : ("[" + (myInventory[i].GetItemType() == ItemType.WEAPON ? myInventory[i].GetRating().ToString() : myInventory[i].GetRating().ToString()) + "]")) + myInventory[i].GetFullName(), tempPrintColour);
                    tempIndexes.Add(i);
                    tempOffset++;
                }
            }
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2);
            Console.Write("[0] " + Language.GetBack());
            switch (Utility.GetDigitInput(-19, 1, tempItemCount, out int tempChoice))
            {
                case 0:
                    OpenInventory();
                    break;

                default:
                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 2);
                    Console.Write("[1] " + (aType == ItemType.SCROLL ? Language.GetApply() : Language.GetEquip()) + " [2] " + Language.GetThrowAway() + " [0] " + Language.GetBack());
                    switch (Utility.GetDigitInput(-19, 3, 2, out int tempSecondChoice))
                    {
                        case 0:
                            OpenInventory();
                            break;

                        case 1:
                            if (aType == ItemType.SCROLL)
                            {
                                ApplyScrollEffect((Scroll)myInventory[tempIndexes[tempChoice - 1]], out string tempEffect, out int tempEffectAmount);
                                PrintUI();
                                Console.SetCursorPosition(tempWWD2 - Language.GetEffectApplied().Length / 2, tempWHD2 - 12);
                                Console.Write(Language.GetEffectApplied());
                                myInventory.RemoveAt(tempIndexes[tempChoice - 1]);
                                Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 10);
                                Utility.PrintInColour("+" + tempEffectAmount.ToString() + " ", ConsoleColor.Green);
                                Console.Write(tempEffect);
                                Thread.Sleep(2000);
                            }
                            else
                            {
                                Equip(myInventory[tempIndexes[tempChoice - 1]]);
                            }
                            BrowseItems(aType);
                            break;

                        case 2:
                            myInventory.RemoveAt(tempIndexes[tempChoice - 1]);
                            BrowseItems(aType);
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
            Console.Write(Language.GetGold() + ": " + myGold.ToString() + "■       " + Language.GetInventory() + "        (" + (myHPPotionAmount + myManaPotionAmount + myInventory.Count) + "/" + myInventoryCapacity + ")");
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 10);
            Console.Write("[1]");
            Utility.PrintInColour(" ■ " + Language.GetHPPotions() + ": " + myHPPotionAmount.ToString(), ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 - 10);
            Console.Write("[3]");
            Utility.PrintInColour(" ■ " + Language.GetScrolls(), ConsoleColor.DarkMagenta);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 - 9);
            Console.Write("[4]");
            Utility.PrintInColour(" ■ " + Language.GetTrinkets(), ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 + 7, tempWHD2 - 8);
            Utility.PrintInColour("[+" + myEquippedTrinket.GetEffectType() + "]", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 9);
            Console.Write("[2]");
            Utility.PrintInColour(" ■ " + Language.GetManaPotions() + ": " + myManaPotionAmount.ToString(), ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 7);
            Console.Write("[5] ");
            Utility.PrintInColour("╔╤╗ [" + myEquippedHelmet.GetRating() + "]" + myEquippedHelmet.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 6);
            Utility.PrintInColour("╚═╝ " + myEquippedHelmet.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 4);
            Console.Write("[6]");
            Utility.PrintInColour("╔╦═╦╗[" + myEquippedChestplate.GetRating() + "]" + myEquippedChestplate.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 3);
            Utility.PrintInColour("╚═╝ " + myEquippedChestplate.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 1);
            Console.Write("[7] ");
            Utility.PrintInColour("╔═╗ [" + myEquippedTrousers.GetRating() + "]" + myEquippedTrousers.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2);
            Utility.PrintInColour("║ ║ " + myEquippedTrousers.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 + 2);
            Console.Write("[8] ");
            Utility.PrintInColour("    [" + myEquippedBoots.GetRating() + "]" + myEquippedBoots.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 + 3);
            Utility.PrintInColour("╝ ╚ " + myEquippedBoots.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 - 7);
            Console.Write("[9]");
            Utility.PrintInColour(@"/\  [" + myEquippedWeapon.GetRating() + "]" + myEquippedWeapon.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 - 6);
            Utility.PrintInColour(@"||  " + myEquippedWeapon.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 - 5);
            Utility.PrintInColour(@"||", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 - 4);
            Utility.PrintInColour(@"||", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 - 3);
            Utility.PrintInColour("||", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 - 2);
            Utility.PrintInColour(@"O==\/==O", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2 - 1);
            Utility.PrintInColour("][", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 4, tempWHD2);
            Utility.PrintInColour("()", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 7, tempWHD2 - 4);
            Console.Write("[10]");
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 - 4);
            Utility.PrintInColour(@"/---\", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 - 3);
            Utility.PrintInColour(@"| o |", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 - 2);
            Utility.PrintInColour(@"\---/", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 8, tempWHD2);
            Utility.PrintInColour("[" + myEquippedShield.GetRating().ToString() + "]" + Language.GetShieldOf(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 8, tempWHD2 + 1);
            Utility.PrintInColour(myEquippedShield.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 + 2);
            Console.Write("[0] " + Language.GetCloseInventory());

            #endregion Doodle Sequence

            switch (Utility.GetDigitInput(2, 3, 10))
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
                    BrowseItems(ItemType.SCROLL);
                    break;

                case 4:
                    BrowseItems(ItemType.TRINKET);
                    break;

                case 5:
                    BrowseItems(ItemType.HELMET);
                    break;

                case 6:
                    BrowseItems(ItemType.CHESTPLATE);
                    break;

                case 7:
                    BrowseItems(ItemType.TROUSERS);
                    break;

                case 8:
                    BrowseItems(ItemType.BOOTS);
                    break;

                case 9:
                    BrowseItems(ItemType.WEAPON);
                    break;

                case 10:
                    BrowseItems(ItemType.SHIELD);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Adds items in the parameter-list to the inventory and clears the parameter-list
        /// </summary>
        /// <param name="anItemList">Items to add</param>
        public void AddItemsToInventory(List<Item> anItemList)
        {
            foreach (Item tempItem in anItemList)
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
        private void ApplyScrollEffect(Scroll aScroll, out string anEffect, out int anEffectAmount)
        {
            myAppliedScrolls.Add(aScroll);
            anEffectAmount = 0;
            anEffect = string.Empty;
            switch (aScroll.GetScrollEffect())
            {
                case ScrollEffect.ARMBUFF:
                    myTempArmourRating = aScroll.GetArmourBuff();
                    anEffectAmount = aScroll.GetArmourBuff();
                    anEffect = Language.GetTempArmour();
                    break;

                case ScrollEffect.STRBUFF:
                    myTempStrength = aScroll.GetStrengthBuff();
                    anEffectAmount = aScroll.GetStrengthBuff();
                    anEffect = Language.GetTempStrength();
                    break;

                case ScrollEffect.HPBUFF:
                    myTempHealth = aScroll.GetHealthBuff();
                    anEffectAmount = aScroll.GetHealthBuff();
                    anEffect = Language.GetTempHealth();
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
                myHealth += 40;
                if (myHealth > myMaxHealth * myStamina / 100)
                {
                    myHealth = myMaxHealth * myStamina / 100;
                }
            }
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - Language.GetDrinkHPPotion().Length / 2, tempWHD2 - 12);
            Console.Write(Language.GetDrinkHPPotion());
            Thread.Sleep(1000);
            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 10);
            Console.Write(Language.GetRegain());
            Utility.PrintInColour(" 40", ConsoleColor.Green);
            Console.Write(" " + Language.GetHealthLowerCase() + "!");
            Thread.Sleep(1500);
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
                myMana += 50;
                if (myMana > myMaxMana)
                {
                    myMana = myMaxMana;
                }
            }
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 16, tempWHD2 - 12);
            Console.Write(Language.GetDrinkManaPotion());
            Thread.Sleep(1000);
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 10);
            Console.Write(Language.GetRegain());
            Utility.PrintInColour(" 50", ConsoleColor.Blue);
            Console.Write(" mana!");
            Thread.Sleep(1500);
        }

        #endregion Inventory

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
            Utility.PrintPentagram(tempWWD2 - 58, tempWHD2 - 5, ConsoleColor.DarkRed);
            Utility.PrintPentagram(tempWWD2 + 23, tempWHD2 - 5, ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 14);
            Utility.PrintInColour("╦   ╦   ╔════╗   ╦    ╦      ╦════╗    ═╦═   ╦═════╗   ╦════╗", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 13);
            Utility.PrintInColour("║   ║   ║    ║   ║    ║      ║     ║    ║    ║         ║     ║", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 12);
            Utility.PrintInColour("║   ║   ║    ║   ║    ║      ║     ║    ║    ║         ║     ║", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 11);
            Utility.PrintInColour("╚═╦═╝   ║    ║   ║    ║      ║     ║    ║    ╬════     ║     ║", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 10);
            Utility.PrintInColour("  ║     ║    ║   ║    ║      ║     ║    ║    ║         ║     ║", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 9);
            Utility.PrintInColour("  ║     ║    ║   ║    ║      ║     ║    ║    ║         ║     ║", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 8);
            Utility.PrintInColour("  ║     ║    ║   ║    ║      ║     ║    ║    ║         ║     ║", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - tempTextOffset, tempWHD2 - 7);
            Utility.PrintInColour("  ╩     ╚════╝   ╚════╝      ╩════╝    ═╩═   ╩═════╝   ╩════╝", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - 4, tempWHD2 - 1);
            Console.Write("[1] " + Language.GetMenu());
            Console.SetCursorPosition(tempWWD2 - (Language.GetExit().Length + 4) / 2, tempWHD2 + 1);
            Console.Write("[2] " + Language.GetExit());
            switch (Utility.GetDigitInput(-2, 3, 2))
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
        /// Deals given damage to given enemy
        /// </summary>
        /// <param name="anEnemy"></param>
        public void DealDamage(Enemies.Enemy anEnemy, float aDamage, bool ShouldBeStunned, int aSpellIndex = 0) => anEnemy.TakeDamage(aDamage, aSpellIndex > 0 ? myIntelligence : myStrength + myTempStrength, ShouldBeStunned, aSpellIndex);

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
            if (Utility.GetRNG().Next(1, 101) > tempAgility)
            {
                if (!myIsDefending)
                {
                    DamageTaken = aDamage - aDamage * (myArmourRating + myTempArmourRating) / 100f;
                }
                else
                {
                    DamageTaken = aDamage - aDamage * (myArmourRating + myTempArmourRating) / 100f - aDamage * 0.6f;
                }
                if (myTempHealth > 0)
                {
                    myTempHealth -= DamageTaken;
                    if (myTempHealth < 0)
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
            myIsDefending = false;
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 12);
            Console.Write(Language.GetWhatUDo());
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 10);
            Console.Write("[1] " + Language.GetOffensive() + " [2] " + Language.GetDefensive());
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 9);
            Console.Write("[3] " + Language.GetUseItem() + "  [4] " + Language.GetFlee());
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 8);
            Console.Write("[5] " + Language.GetAbstain());
            switch (Utility.GetDigitInput(-1, -6, 5))
            {
                case 1:
                    return BattleActions.OFFENSIVE;

                case 2:
                    return BattleActions.DEFENSIVE;

                case 3:
                    return BattleActions.USEITEM;

                case 4:
                    return BattleActions.FLEE;

                case 5:
                    return BattleActions.ABSTAIN;

                default:
                    return BattleActions.ABSTAIN;
            }
        }

        #endregion Battle

        #region Get

        public int GetLuck() => myLuck;

        public int GetLevel() => myLevel;

        public int GetStrength() => myStrength;

        public int GetAgility() => myAgility;

        public int GetMana() => myMana;

        public int GetDamage() => myDamage;

        public int GetSpellDamage() => mySpellDamage * (int)(1 + myIntelligence / 100f);

        public int GetArmourRating() => myArmourRating;

        public float GetStamina() => myStamina;

        public float GetHealth() => myHealth;

        public float GetMaxHealth() => myMaxHealth;

        public bool GetIsDefending() => myIsDefending;

        public int GetWisdom() => myWisdom;

        #endregion Get

        #region Set

        /// <summary>
        /// Adds the given amount of gold
        /// </summary>
        /// <param name="anAmountToAdd">The amount to add</param>
        public bool SetGold(int aValueToAdd)
        {
            if ((aValueToAdd < 0 && myGold > -aValueToAdd) || aValueToAdd > 0)
            {
                myGold += aValueToAdd;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds the given amount of hp-potions
        /// </summary>
        /// <param name="anAmountToAdd">The amount to add</param>
        public void SetHealthPotions(int aValueToAdd)
        {
            if (myInventory.Count + myHPPotionAmount + myManaPotionAmount < myInventoryCapacity)
            {
                myHPPotionAmount += aValueToAdd;
            }
        }

        /// <summary>
        /// Adds the given amount of mana-potions
        /// </summary>
        /// <param name="anAmountToAdd">The amount to add</param>
        public void SetManaPotions(int aValueToAdd)
        {
            if (myInventory.Count + myHPPotionAmount + myManaPotionAmount < myInventoryCapacity)
            {
                myManaPotionAmount += aValueToAdd;
            }
        }

        public void SetInventoryCapacity(int aNewCapacity) => myInventoryCapacity = aNewCapacity;

        public void SetIsDefending(bool aNewValue) => myIsDefending = aNewValue;

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
            if (myTempStrength < 0)
            {
                myTempStrength = 0;
            }
        }

        public void SetTempArmourRating(int anArmourRating)
        {
            myTempArmourRating += anArmourRating;
            if (myTempArmourRating < 0)
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

        public void SetStaminaBuff(int aStaminaBuff)
        {
            myStaminaBuff = aStaminaBuff;
            myMaxStamina += myStaminaBuff;
            myStamina += myStaminaBuff;
            myHealth = myMaxHealth * myStamina / 100;
        }

        public void SetIntelligenceBuff(int anIntelligenceBuff)
        {
            myIntelligenceBuff = anIntelligenceBuff;
            myIntelligence += myIntelligenceBuff;
        }

        public void SetWisdomBuff(int aWisdomBuff)
        {
            myWisdomBuff = aWisdomBuff;
            myWisdom += myWisdomBuff;
        }

        public void SetMana(int aValueToSubtract) => myMana -= aValueToSubtract;

        public void SetHealth(float aValueToAdd)
        {
            myHealth += aValueToAdd;
            if (myMaxHealth < myHealth)
            {
                myHealth = myMaxHealth * myStamina / 100;
            }
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
            if (myArmourBuff > 0)
            {
                myArmourRating -= myArmourBuff;
                myArmourBuff = 0;
            }
            if (myLuckBuff > 0)
            {
                myLuck -= myLuckBuff;
                myLuckBuff = 0;
            }
            if (myAgilityBuff > 0)
            {
                myAgility -= myAgilityBuff;
                myAgilityBuff = 0;
            }
            if (myStaminaBuff > 0)
            {
                myMaxStamina -= myStaminaBuff;
                myStaminaBuff = 0;
            }
            if (myWisdomBuff > 0)
            {
                myWisdom -= myWisdomBuff;
                myWisdomBuff = 0;
            }
            if (myIntelligenceBuff > 0)
            {
                myIntelligence -= myIntelligenceBuff;
                myIntelligenceBuff = 0;
            }
        }

        #endregion Set
    }
}