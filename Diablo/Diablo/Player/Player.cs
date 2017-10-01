﻿using System;
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

    class Player /// TODO: Add summaries
    {
        #region Variables
        private int
            myMana,
            myMaxMana,
            myDamage,
            mySpellDamage,
            myGold,
            myHPPotionAmount,
            myManaPotionAmount,
            myArmourRating,
            myInventoryCapacity;
        private float
             myHealth,
             myMaxHealth;
        private bool
            myIsDefending;
        private List<Items.Item> 
            myInventory;
        private Items.Item
            myEquippedHelmet,
            myEquippedChestplate,
            myEquippedTrousers,
            myEquippedBoots,
            myEquippedWeapon;
        #endregion

        public Player()
        {
            myArmourRating = 10;
            myMaxHealth = 100;
            myHealth = myMaxHealth;
            myMaxMana = 100;
            myMana = myMaxMana;
            myDamage = 15;
            mySpellDamage = 20;
            myGold = 50;
            myHPPotionAmount = 2;
            myManaPotionAmount = 2;
            myInventoryCapacity = 50;
            myInventory = new List<Items.Item>();
            myEquippedHelmet = new Items.Item(Items.Type.HELMET, "Basicness", 2, 0);
            myEquippedChestplate = new Items.Item(Items.Type.CHESTPLATE, "Basicness", 4, 0);
            myEquippedTrousers = new Items.Item(Items.Type.TROUSERS, "Basicness", 3, 0);
            myEquippedBoots = new Items.Item(Items.Type.BOOTS, "Basicness", 1, 0);
            myEquippedWeapon = new Items.Item(Items.Type.WEAPON, "Basicness", 0, 15);
        }

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
            Utilities.Utility.PrintInColour("  " + myHealth + @"/" + myMaxHealth, ConsoleColor.Red);
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
            Utilities.Utility.PrintInColour(@"  Arm: " + (myEquippedHelmet.GetArmourRating() + myEquippedChestplate.GetArmourRating() + myEquippedTrousers.GetArmourRating() + myEquippedBoots.GetArmourRating()).ToString(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2, tempWHD2 + 7);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 + 5);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 + 6);
            Utilities.Utility.PrintInColour(@"  " + myMana + "/" + myMaxMana.ToString(), ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 + 7);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Blue);
        }

        public void AddItemsToInventory(List<Items.Item> anItemList)
        {
            for (int i = 0; i < anItemList.Count; i++)
            {
                if(myInventory.Count < myInventoryCapacity)
                {
                    myInventory.Add(anItemList[i]);
                }
            }
            anItemList.Clear(); /// Temporary line
        }

        public void OpenInventory()
        {
            int
                tempChoice,
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;

            #region Doodle
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 12);
            Console.Write("Gold: " + myGold.ToString() + "        Inventory        (" + (myHPPotionAmount + myManaPotionAmount + myInventory.Count) + "/" + myInventoryCapacity + ")");
            Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 10);
            Console.Write("[1]");
            Utilities.Utility.PrintInColour(" ▓ HP-Potions: " + myHPPotionAmount.ToString(), ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 9);
            Console.Write("[2]");
            Utilities.Utility.PrintInColour(" ▓ Mana-Potions: " + myManaPotionAmount.ToString(), ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 7);
            Console.Write("[3] ");
            Utilities.Utility.PrintInColour("╔╤╗ [" + myEquippedHelmet.GetArmourRating() + "]" + myEquippedHelmet.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 6);
            Utilities.Utility.PrintInColour("╚═╝ " + myEquippedHelmet.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 4);
            Console.Write("[4]");
            Utilities.Utility.PrintInColour("╔╦═╦╗[" + myEquippedChestplate.GetArmourRating() + "]" + myEquippedChestplate.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 3);
            Utilities.Utility.PrintInColour("╚═╝ " + myEquippedChestplate.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 - 1);
            Console.Write("[5] ");
            Utilities.Utility.PrintInColour("╔═╗ [" + myEquippedTrousers.GetArmourRating() + "]" + myEquippedTrousers.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2);
            Utilities.Utility.PrintInColour("║ ║ " + myEquippedTrousers.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 + 2);
            Console.Write("[6] ");
            Utilities.Utility.PrintInColour("    [" + myEquippedBoots.GetArmourRating() + "]" + myEquippedBoots.GetPrefix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 + 3);
            Utilities.Utility.PrintInColour("╝ ╚ " + myEquippedBoots.GetSuffix(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 1, tempWHD2 - 7);
            Console.Write("[7]");
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
            while(!int.TryParse(Utilities.Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < -1 || tempChoice > 7))
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
                default:
                    break;
            }
            
        } /// TODO: Finish this

        private void DrinkHPPotion()
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;

            if (myHPPotionAmount > 0)
            {
                myHPPotionAmount -= 1;
                myHealth += 25;
                if(myHealth > myMaxHealth)
                {
                    myHealth = myMaxHealth;
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

        public void AddGold(int anAmountToAdd)
        {
            myGold += anAmountToAdd;
        }

        public void SubtractGold(int anAmountToSubtract)
        {
            myGold -= anAmountToSubtract;
        }

        public void DealDamage(Enemies.Skeleton aSkeleton)
        {
            aSkeleton.TakeDamage(myDamage);
        }

        public void DealDamage(Enemies.Skeleton aSkeleton, int aDamage)
        {
            aSkeleton.TakeDamage(aDamage);
        }

        public void TakeDamage(int aDamage, bool isDefending, out float DamageTaken)
            {
                if (!isDefending)
                {
                    DamageTaken = aDamage - aDamage * (float)myArmourRating / 100f;
                    myHealth -= DamageTaken;
                }
                else
                {
                    DamageTaken = aDamage - aDamage * (float)myArmourRating / 100f - aDamage * 0.6f;
                    myHealth -= DamageTaken;
                }
            }

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

        #region Get
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

        #endregion
    }  
}