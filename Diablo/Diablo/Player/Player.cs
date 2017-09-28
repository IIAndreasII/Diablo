using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Player
{ 
    class Player
    {
        private int
            myMana,
            myDamage,
            mySpellDamage,
            myGold,
            myHPPotionAmount,
            myManaPotionAmount,
            myArmourRating,
            myInventoryCapacity;
        private float
             myHealth;
        private bool
            myIsDefending;

        public Player()
        {
            myArmourRating = 10;
            myHealth = 100;
            myMana = 100;
            myDamage = 15;
            mySpellDamage = 20;
            myGold = 50;
            myHPPotionAmount = 2;
            myManaPotionAmount = 2;
        }

        public void PrintUI()
        {
            int 
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            Console.Clear();
            Utilities.Utility.PrintPentagram(3, 3, ConsoleColor.Red);
            Utilities.Utility.PrintPentagram(Console.WindowWidth - 38, 3, ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 + 2);
            Utilities.Utility.PrintInColour(@"■ Gold: " + myGold.ToString(), ConsoleColor.Yellow);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 + 4);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 + 5);
            Utilities.Utility.PrintInColour(@"  HP: " + myHealth, ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 22, tempWHD2 + 6);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Red);            
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 + 4);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 +  5 );
            Utilities.Utility.PrintInColour(@"  Dmg: " + myDamage.ToString(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 + 6);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2, tempWHD2 + 4);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2, tempWHD2 + 5);
            Utilities.Utility.PrintInColour(@"  Arm: " + myArmourRating.ToString(), ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2, tempWHD2 + 6);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Gray);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 + 4);
            Utilities.Utility.PrintInColour(@"/■■■■■■■■■\", ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 + 5);
            Utilities.Utility.PrintInColour(@" Mana: " + myMana.ToString(), ConsoleColor.Blue);
            Console.SetCursorPosition(tempWWD2 + 11, tempWHD2 + 6);
            Utilities.Utility.PrintInColour(@"\■■■■■■■■■/", ConsoleColor.Blue);

        }

        public void OpenInventory()
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 5, tempWHD2 - 11);
            Console.Write("Inventory:");
            Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 9);
            Console.Write("[1]");
            Utilities.Utility.PrintInColour(" ■ HP-Potions: " + myHPPotionAmount.ToString(), ConsoleColor.Red);
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 8);
            Console.Write("[2]");
            Utilities.Utility.PrintInColour(" ■ Mana-Potions: " + myManaPotionAmount.ToString(), ConsoleColor.Blue);



            Console.ReadKey();
        } /// TODO: Finish this

        #region BattleRelated
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

        public int ChooseBattleAction()
        {
            int 
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempChoice = 0;
            PrintUI();
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 11);
            Console.Write("What will you do?");
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 9);
            Console.Write("[1] Attack    [2] Defend");
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 8);
            Console.Write("[3] Use item  [4] Flee");
            Console.SetCursorPosition(tempWWD2 - 6, tempWHD2 - 7);
            Console.Write("[5] Abstain");
            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 5);
            Console.Write("[ ]");
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 5);
            while (!int.TryParse(Utilities.Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 1 || tempChoice > 5))
            {
                Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 5);
                Console.Write(" \b");
            }
            switch (tempChoice)
            {
                case 1:
                    myIsDefending = false;
                    return (int)Enums.BattleActions.ATTACK;
                case 2:
                    myIsDefending = true;
                    return (int)Enums.BattleActions.DEFEND;
                case 3:
                    myIsDefending = false;
                    return (int)Enums.BattleActions.USEITEM;
                case 4:
                    myIsDefending = false;
                    return (int)Enums.BattleActions.FLEE;
                case 5:
                    myIsDefending = false;
                    return (int)Enums.BattleActions.ABSTAIN;
                default:
                    myIsDefending = true;
                    return (int)Enums.BattleActions.ABSTAIN;
                }
            }

        #endregion

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