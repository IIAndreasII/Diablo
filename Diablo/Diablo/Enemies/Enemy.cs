using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Enemies
{
    public enum Type
    {
        SWORDSMAN,
        ARCHER,
        CAPTAIN
    }

    class Enemy
    {
        protected int
            myLevel,
            myArmourRating,
            myAgility,
            myStamina;
        protected float
            myDamage,
            myHealth;
        protected bool
            myIsAlive;
        protected Type
            myType;


        public void TakeDamage(int aDamageToTake, int aStrength)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            float 
                tempDamageDealt = aDamageToTake * (1 + (float)aStrength / 100) * (1f - (float)myArmourRating / 100f);          
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 11);
            Console.Write("You swing your sword!");
            System.Threading.Thread.Sleep(1000);
            if (Utilities.Utility.myRNG.Next(1, 101) > myAgility)
            {
                myHealth -= tempDamageDealt;
                Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 9);
                Console.Write("You dealt ");
                Utilities.Utility.PrintInColour(tempDamageDealt.ToString(), ConsoleColor.Green);
                Console.Write(" damage!");
                if (myHealth <= 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 7);
                    Console.Write("Enemy defeated!");
                }
            }
            else
            {
                Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 9);
                Console.Write("You missed the enemy!");
            }           
            System.Threading.Thread.Sleep(2000);
        }

        public void DealDamage(Player.Player aPlayer)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            float 
                tempDamageDealt;
            aPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 11);
            Console.WriteLine("The enemy swings his sword!");
            System.Threading.Thread.Sleep(1000);
            if(aPlayer.TakeDamage(myDamage, out tempDamageDealt))
            {
                Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 9);
                Console.Write("You took ");
                Utilities.Utility.PrintInColour(tempDamageDealt.ToString(), ConsoleColor.Red);
                Console.Write(" damage!");
            }
            else
            {
                Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 9);
                Console.Write("You evaded the strike!");
            }
            System.Threading.Thread.Sleep(2000);
        }

        #region Gets
        public float GetHealth()
        {
            return myHealth;
        }

        public float GetDamage()
        {
            return myDamage;
        }

        public int GetArmourRating()
        {
            return myArmourRating;
        }

        public int GetLevel()
        {
            return myLevel;
        }

        public bool GetIsAlive()
        {
            return myIsAlive;
        }
        #endregion
    }
}