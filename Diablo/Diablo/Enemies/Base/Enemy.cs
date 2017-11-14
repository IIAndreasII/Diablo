using System;

namespace Diablo.Enemies
{
    public enum Type
    {
        SKELETON,
        ARCHER,
        MIMIC
    }

    public class Enemy
    {
        protected int
            myLevel,
            myArmourRating,
            myAgility,
            myStamina,
            myEXPToGive;
        protected float
            myDamage,
            myHealth;
        protected bool
            myIsAlive = true;
        protected Type
            myType;

        /// <summary>
        /// As the name suggests, it makes the enemy take damage
        /// </summary>
        /// <param name="aDamageToTake">The damage that will be taken</param>
        /// <param name="aStrength">A strength modifier, increasing the damage a bit</param>
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
            if (Utilities.Utility.GetRNG().Next(1, 101) > myAgility)
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
                    Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 5);
                    Utilities.Utility.PrintInColour("+" + myEXPToGive.ToString(), ConsoleColor.Green);
                    Console.Write(" experience!");
                    
                    myIsAlive = false;
                }
            }
            else
            {
                Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 9);
                Console.Write("You missed the enemy!");
            }
            System.Threading.Thread.Sleep(2000);
        }

        /// <summary>
        /// Deals dmage to given player
        /// </summary>
        /// <param name="aPlayer">The player the damage will be dealt upon</param>
        public void DealDamage(Player.Player aPlayer)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            aPlayer.PrintUI();

            switch (myType)
            {
                case Type.SKELETON:
                    Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 11);
                    Console.WriteLine("The enemy swings his sword!");
                    break;
                case Type.ARCHER:
                    Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 11);
                    Console.WriteLine("The enemy draws his bow");
                    break;
                case Type.MIMIC:

                    break;
            }
            System.Threading.Thread.Sleep(1000);
            if (aPlayer.TakeDamage(myDamage, out float tempDamageDealt))
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
            if (aPlayer.GetHealth() <= 0)
            {
                aPlayer.DeathSequence();
            }
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

        public int GetEXPToGive()
        {
            return myEXPToGive;
        }

        public Type GetEnemyType()
        {
            return myType;
        }
        #endregion
    }
}