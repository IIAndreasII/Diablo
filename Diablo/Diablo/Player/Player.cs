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
            myCoin,
            myHPPotionAmount,
            myArmourRating,
            myInventoryCapacity;
        private float
             myHealth;
        private bool
            myIsDefending;

        public Player()
        {
            myHealth = 100;
            myDamage = 15;
            mySpellDamage = 20;
            myCoin = 0;
            myHPPotionAmount = 2;
        }

        public void OpenInventory()
        {
            Console.WriteLine("Inventory:\n");
        }

        #region BattleRelated
        public void DealDamage(Enemies.Skeleton aSkeleton)
            {
                aSkeleton.TakeDamage(myDamage);
            }

        public void TakeDamage(int aDamage, bool isDefending, out float DamageTaken)
            {
                if (isDefending)
                {
                    DamageTaken = aDamage * (float)myArmourRating / 100f;
                    myHealth -= DamageTaken;
                }
                else
                {
                    DamageTaken = aDamage * (float)myArmourRating / 120f;
                    myHealth -= DamageTaken;
                }
            }

        public int ChooseBattleAction()
            {
                int tempChoice = 0;
                Console.WriteLine("What will you do?\n[1] Attack    [2] Defend\n[3] Use item  [4] Flee\n[ ]");
                Console.SetCursorPosition(1, 3);
                while (!int.TryParse(Utilities.Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 1 || tempChoice > 4))
                {
                    Console.SetCursorPosition(1, 3);
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
                    default:
                        myIsDefending = true;
                        return (int)Enums.BattleActions.DEFEND;
                }
            }

        #endregion

        #region Gets
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

        #region Sets
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