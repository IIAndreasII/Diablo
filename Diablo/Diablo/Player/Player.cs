using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Player
{ 
    public enum BattleActions
    {
        ATTACK,
        DEFEND,
        USEITEM,
        FLEE,
        ABSTAIN
    }

    class Player
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

            myGold,
            myHPPotionAmount,
            myManaPotionAmount,
            myInventoryCapacity,

            myLevel,
            myEXP,

            myStrength,
            myAgility,
            myIntelligence,
            myWisdom,
            myLuck;

        private float
            myStamina,
            myMaxStamina,

            myHealth,
            myTempHealth = 0,
            myMaxHealth;
        
        private bool
            myIsDefending;

        private List<Items.Item> 
            myInventory,
            myScrollList,
            myAppliedScrolls;

        private Items.Item
            myEquippedHelmet,
            myEquippedChestplate,
            myEquippedTrousers,
            myEquippedBoots,

            myEquippedWeapon;
        #endregion

        public Player()
        {
            myLevel = 1;
            myStrength = 5; //Antal procent mer skada
            myAgility = 5; // Antal procent chans det är att undvika en attack
            myMaxStamina = 120; // Antal procent av maxHP
            myStamina = myMaxStamina;
            myLuck = 10; // Antal procent chans för att hitta extra loot
            /// TODO: Set base Intelligence and Wisdom

            myArmourRating = 10;
            myMaxHealth = 100;
            myHealth = myMaxHealth * myStamina / 100;
            myMaxMana = 100;
            myMana = myMaxMana;
            myDamage = 15;
            mySpellDamage = 20;
            myGold = 50;
            myHPPotionAmount = 1;
            myManaPotionAmount = 1;
            myInventoryCapacity = 50;
            myInventory = new List<Items.Item>();
            myScrollList = new List<Items.Item>();
            myAppliedScrolls = new List<Items.Item>();
            myEquippedHelmet = new Items.Item(Items.Type.HELMET, "Basicness", 2); // Equip:ad gear är på en och inte i ens väska, därav läggs dem inte in i inventory:t
            myEquippedChestplate = new Items.Item(Items.Type.CHESTPLATE, "Basicness", 4);
            myEquippedTrousers = new Items.Item(Items.Type.TROUSERS, "Basicness", 3);
            myEquippedBoots = new Items.Item(Items.Type.BOOTS, "Basicness", 1);
            myEquippedWeapon = new Items.Item(Items.Type.WEAPON, 15, "Basicness");

            myScrollList.Add(new Items.Item(true));
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
                AddStamina(20);
                SubtractGold(10);
            }
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
            Utilities.Utility.PrintPentagram(3, 3, ConsoleColor.Red);
            Utilities.Utility.PrintPentagram(Console.WindowWidth - 38, 3, ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 + 5);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 + 6);
            Utilities.Utility.PrintInColour(" " + (myHealth + myTempHealth) + @"/" + myMaxHealth, ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 + 7);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Red);            
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 + 5);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 +  6);
            Utilities.Utility.PrintInColour(@"  Dmg: " + myDamage.ToString(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 + 7);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2, tempWHD2 + 5);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2, tempWHD2 + 6);
            Utilities.Utility.PrintInColour(@"  Arm: " + (myEquippedHelmet.GetArmourRating() + myEquippedChestplate.GetArmourRating() + myEquippedTrousers.GetArmourRating() + myEquippedBoots.GetArmourRating() + myTempArmourRating).ToString(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2, tempWHD2 + 7);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 + 5);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 + 6);
            Utilities.Utility.PrintInColour(@"  " + myMana + "/" + myMaxMana.ToString(), ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 + 7);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 + 8);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 + 9);
            Utilities.Utility.PrintInColour(@"  Str: " + (myStrength + myTempStrength), ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 + 10);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 + 8);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.DarkBlue);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 + 9);
            Utilities.Utility.PrintInColour(@"  Agi: " + myAgility.ToString(), ConsoleColor.DarkBlue);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 + 10);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.DarkBlue);
            Console.SetCursorPosition(tempWWD2 + 5, tempWHD2 + 8);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Cyan);
            Console.SetCursorPosition(tempWWD2 + 5, tempWHD2 + 9);
            Utilities.Utility.PrintInColour(@"  Int: " + myIntelligence.ToString(), ConsoleColor.Cyan);
            Console.SetCursorPosition(tempWWD2 + 5, tempWHD2 + 10);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Cyan);
            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 + 11);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 + 12);
            Utilities.Utility.PrintInColour(@"Sta:" + myStamina.ToString() + "/" + myMaxStamina.ToString(), ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 + 13);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Green);
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 + 11);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.DarkMagenta);
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 + 12);
            Utilities.Utility.PrintInColour(@"  Wis: " + myWisdom.ToString(), ConsoleColor.DarkMagenta);
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 + 13);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.DarkMagenta);
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
            if(myHealth > myStamina)
            {
                myHealth = myMaxHealth;
            }
        }

        #region Inventory     
        
        /// <summary>
        /// Equips the player with given item
        /// </summary>
        /// <param name="anItem">Item to equip</param>      
        public void Equip(Items.Item anItem)
        {
            Items.Item tempItem;
            switch (anItem.GetItemType())
            {
                case Items.Type.HELMET:
                    tempItem = myEquippedHelmet;
                    myEquippedHelmet = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;
                case Items.Type.CHESTPLATE:
                    tempItem = myEquippedChestplate;
                    myEquippedChestplate = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;
                case Items.Type.TROUSERS:
                    tempItem = myEquippedTrousers;
                    myEquippedTrousers = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;
                case Items.Type.BOOTS:
                    tempItem = myEquippedBoots;
                    myEquippedBoots = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;
                case Items.Type.WEAPON:
                    tempItem = myEquippedWeapon;
                    myEquippedWeapon = anItem;
                    if (myInventory.Contains(anItem))
                    {
                        myInventory.Remove(anItem);
                    }
                    myInventory.Add(tempItem);
                    break;
            }
            myDamage = myEquippedWeapon.GetDamage();
            myArmourRating = myEquippedBoots.GetArmourRating() + myEquippedTrousers.GetArmourRating() + myEquippedChestplate.GetArmourRating() + myEquippedHelmet.GetArmourRating();
        }

        /// <summary>
        /// Equips all the best items in the list
        /// </summary>
        /// <param name="anItemList">List with items to equip</param>
        public void EquipBestItems(List<Items.Item> anItemList)
        {
            for (int i = 0; i < anItemList.Count; i++)
            {
                switch (anItemList[i].GetItemType())
                {
                    case Items.Type.HELMET:
                        if(anItemList[i].GetArmourRating() > myEquippedHelmet.GetArmourRating())
                        {
                            Equip(anItemList[i]);
                        }
                        break;
                    case Items.Type.CHESTPLATE:
                        if(anItemList[i].GetArmourRating() > myEquippedChestplate.GetArmourRating())
                        {
                            Equip(anItemList[i]);
                        }
                        break;
                    case Items.Type.TROUSERS:
                        if (anItemList[i].GetArmourRating() > myEquippedTrousers.GetArmourRating())
                        {
                            Equip(anItemList[i]);
                        }
                        break;
                    case Items.Type.BOOTS:
                        if(anItemList[i].GetArmourRating() > myEquippedBoots.GetArmourRating())
                        {
                            Equip(anItemList[i]);
                        }
                        break;
                    case Items.Type.WEAPON:
                        if (anItemList[i].GetDamage() > myEquippedWeapon.GetDamage())
                        {
                            Equip(anItemList[i]);
                        }
                        break;
                    default:
                        Console.WriteLine("ERROR!");
                        break;
                }
            }
        }

        /// <summary>
        /// Opens the inventory and let's the player equip or use items
        /// </summary>
        public void OpenInventory()
        {
            int
                tempChoice,
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;

            #region Doodle Sequence
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 12);
            Console.Write("Gold: " + myGold.ToString() + "        Inventory        (" + (myHPPotionAmount + myManaPotionAmount + myInventory.Count) + "/" + myInventoryCapacity + ")");
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 10);
            Console.Write("[1]");
            Utilities.Utility.PrintInColour(" ▓ HP-Potions: " + myHPPotionAmount.ToString(), ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 - 10);
            Console.Write("[3]");
            Utilities.Utility.PrintInColour(" ▓ Scrolls", ConsoleColor.DarkMagenta);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 9);
            Console.Write("[2]");
            Utilities.Utility.PrintInColour(" ▓ Mana-Potions: " + myManaPotionAmount.ToString(), ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 7);
            Console.Write("[4] ");
            Utilities.Utility.PrintInColour("╔╤╗ [" + myEquippedHelmet.GetArmourRating() + "]" + myEquippedHelmet.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 6);
            Utilities.Utility.PrintInColour("╚═╝ " + myEquippedHelmet.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 4);
            Console.Write("[5]");
            Utilities.Utility.PrintInColour("╔╦═╦╗[" + myEquippedChestplate.GetArmourRating() + "]" + myEquippedChestplate.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 3);
            Utilities.Utility.PrintInColour("╚═╝ " + myEquippedChestplate.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 1);
            Console.Write("[6] ");
            Utilities.Utility.PrintInColour("╔═╗ [" + myEquippedTrousers.GetArmourRating() + "]" + myEquippedTrousers.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2);
            Utilities.Utility.PrintInColour("║ ║ " + myEquippedTrousers.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 + 2);
            Console.Write("[7] ");
            Utilities.Utility.PrintInColour("    [" + myEquippedBoots.GetArmourRating() + "]" + myEquippedBoots.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 + 3);
            Utilities.Utility.PrintInColour("╝ ╚ " + myEquippedBoots.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 - 7);
            Console.Write("[8]");
            Utilities.Utility.PrintInColour(@"/\  [" + myEquippedWeapon.GetDamage() + "]" + myEquippedWeapon.GetPrefix(), ConsoleColor.Gray);
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
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 + 2);
            Console.Write("[0] Close inventory");
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 + 3);
            Console.Write("[ ]");
            #endregion

            Console.SetCursorPosition(tempWWD2 + 2, tempWHD2 + 3);
            while(!int.TryParse(Utilities.Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < -1 || tempChoice > 8))
            {
                Console.SetCursorPosition(tempWWD2 + 2, tempWHD2 + 3);
                Console.Write(" \b");
            }
            switch (tempChoice)
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
                    ViewScrolls();
                    break;
                default:
                    break;
            }
            
        }

        /// <summary>
        /// Adds items in the parameter-list to the inventory and clears the parameter-list
        /// </summary>
        /// <param name="anItemList">Items to add</param>
        public void AddItemsToInventory(List<Items.Item> anItemList)
        {
            for (int i = 0; i < anItemList.Count; i++)
            {
                if (myInventory.Count < myInventoryCapacity)
                {
                    if (anItemList[i].GetItemType() != Items.Type.SCROLL)
                    {
                        myInventory.Add(anItemList[i]);
                    }
                    else
                    {
                        myScrollList.Add(anItemList[i]);
                    }
                }
            }
            anItemList.Clear();
        }

        /// <summary>
        /// Displays all available scrolls
        /// </summary>
        private void ViewScrolls()
        {
            int
               tempChoice,
               tempWWD2 = Console.WindowWidth / 2,
               tempWHD2 = Console.WindowHeight / 2,
               tempTextOffset = tempWHD2 - 10;
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 12);
            Console.Write("Available scrolls:");
            for (int i = 0; i < myScrollList.Count; i++)
            {              
                Console.SetCursorPosition(tempWWD2 - 20, tempTextOffset + i);
                Console.Write("[" + (i + 1) + "] ");
                Utilities.Utility.PrintInColour(myScrollList[i].GetFullName(), ConsoleColor.DarkMagenta);
            }
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 2);
            Console.Write("[0] Back");
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 3);
            Console.Write("[ ]");
            Console.SetCursorPosition(tempWWD2 - 19, tempWHD2 + 3);
            while (!int.TryParse(Utilities.Utility.ReadOnlyNumbers(2), out tempChoice) || (tempChoice < 0 || tempChoice > myScrollList.Count))
            {
                Console.SetCursorPosition(tempWWD2 - 19, tempWHD2 + 3);
                Console.Write(" \b");
            }
            if(tempChoice != 0)
            {
                string tempEffect;
                int tempEffectAmount;
                ApplyScrollEffect(myScrollList[tempChoice - 1], out tempEffect, out tempEffectAmount);
                PrintUI();
                Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 12);
                Console.Write("Effect applied!");
                myScrollList.RemoveAt(tempChoice - 1);
                Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 10);
                Utilities.Utility.PrintInColour("+" + tempEffectAmount.ToString() + " ", ConsoleColor.Green);
                Console.Write(tempEffect);
                System.Threading.Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Applies the scrolleffect to the player
        /// </summary>
        /// <param name="aScroll">A scroll which's effect shall be applied</param>
        private void ApplyScrollEffect(Items.Item aScroll, out string anEffect, out int anEffectAmount)
        {
            myAppliedScrolls.Add(aScroll);
            anEffectAmount = 0;
            anEffect = string.Empty;
            switch (aScroll.GetScrollEffect())
            {
                case Items.ScrollEffect.ARMBUFF:
                    myTempArmourRating = aScroll.GetArmourBuff();
                    anEffectAmount = aScroll.GetArmourBuff();
                    anEffect = "temporary armour!";
                    break;
                case Items.ScrollEffect.STRBUFF:
                    myTempStrength = aScroll.GetStrengthBuff();
                    anEffectAmount = aScroll.GetStrengthBuff();
                    anEffect = "temporary strength!";
                    break;
                case Items.ScrollEffect.HPBUFF:
                    myTempHealth = aScroll.GetHealthBuff();
                    anEffectAmount = aScroll.GetHealthBuff();
                    anEffect = "temporary health!";
                    break;
                case Items.ScrollEffect.ERROR:
                    Console.WriteLine("ERROR!");
                    break;
            }
        }

        /// <summary>
        /// Updates the applied scrolleffects
        /// </summary>
        public void UpdateScrollEffects()
        {
            foreach (Items.Item aScroll in myAppliedScrolls)
            {
                if (aScroll.Decay(this))
                {
                    myAppliedScrolls.Remove(aScroll);
                }        
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
        /// Deals damage to given enemy
        /// </summary>
        /// <param name="aSkeleton">A skeleton to damage</param>
        public void DealDamage(Enemies.Skeleton aSkeleton)
        {
            aSkeleton.TakeDamage(myDamage, myStrength + myTempStrength);
        }

        /// <summary>
        /// Deals damage to given enemy
        /// </summary>
        /// <param name="aSkeleton">A skeleton to damage</param>
        public void DealDamage(Enemies.Skeleton aSkeleton, int aDamage)
        {
            aSkeleton.TakeDamage(aDamage, myStrength + myTempStrength);     
        }

        /// <summary>
        /// Deals damage to given enemy
        /// </summary>
        /// <param name="anArcher">A skeleton to damage</param>
        public void DealDamage(Enemies.Archer anArcher)
        {
            anArcher.TakeDamage(myDamage, myStrength + myTempStrength);
        }

        /// <summary>
        /// Deals damage to given enemy
        /// </summary>
        /// <param name="anArcher">A skeleton to damage</param>
        public void DealDamage(Enemies.Archer anArcher, int aDamage)
        {
            anArcher.TakeDamage(aDamage, myStrength + myTempStrength);
        }

        /// <summary>
        /// Makes the player take damage
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
                return true;
            }
            else
            {
                DamageTaken = 0;
                return false;
            }
        }

        /// <summary>
        /// Let's the player choose what to do during a battle
        /// </summary>
        /// <returns>Returns chosen action</returns>
        public BattleActions ChooseBattleAction()
        {
            int 
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempChoice = 0;
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 12);
            Console.Write("What will you do?");
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 10);
            Console.Write("[1] Attack    [2] Defend");
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 9);
            Console.Write("[3] Use item  [4] Flee");
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 8);
            Console.Write("[5] Abstain");
            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 6);
            Console.Write("[ ]");
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 6);
            while (!int.TryParse(Utilities.Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 1 || tempChoice > 5))
            {
                Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 6);
                Console.Write(" \b");
            }
            switch (tempChoice)
            {
                case 1:
                    myIsDefending = false;
                    return BattleActions.ATTACK;
                case 2:
                    myIsDefending = true;
                    return BattleActions.DEFEND;
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
                    myIsDefending = true;
                    return BattleActions.ABSTAIN;
                }
            }
        #endregion

        #region Get
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

        public float GetStamina()
        {
            return myStamina;
        }

        public int GetHPPotionAmount()
        {
            return myHPPotionAmount;
        }

        public int GetManaPotionAmount()
        {
            return myManaPotionAmount;
        }

        public float GetHealth()
        {
            return myHealth;
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

        public int GetInventoryCapacity()
        {
            return myInventoryCapacity;
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
            myTempHealth = aHealth;
        }

        public void SetTempStrength(int aDamage)
        {
            myTempStrength = aDamage;
        }

        public void SetTempArmourRating(int anArmourRating)
        {
            myTempArmourRating = anArmourRating;
        }

        #endregion
    }  
}