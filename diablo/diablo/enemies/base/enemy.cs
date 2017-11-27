using System;

namespace Diablo.Enemies
{
    public enum EnemyType
    {
        SKELETON,
        ARCHER,
        BOSS
    }

    public class Enemy
    {
        protected int
            myLevel,
            myArmourRating,
            myAgility,
            myStamina,
            myEXPToGive,
            myStunDuration;

        protected float
            myDamage,
            myHealth;

        protected EnemyType
            myType;

        protected string
            myName;

        protected bool
            myCanBeStunned;

        /// <summary>
        /// As the name suggests, it makes the enemy take damage
        /// </summary>
        /// <param name="aDamageToTake">The damage that will be taken</param>
        /// <param name="aStrength">A strength modifier, increasing the damage a bit</param>
        public void TakeDamage(float aDamageToTake, int aStrength, bool shouldBeStunned, int aSpellIndex = 0)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            float
                tempDamageDealt = aDamageToTake * (1 + (float)aStrength / 100) * (1f - myArmourRating / 100f);
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 11);
            switch (aSpellIndex)
            {
                case 0:
                    Console.Write("You swing your sword!");
                    break;

                case 1:
                    Console.Write("You cast Fire Bolt!");
                    break;

                case 2:
                    Console.Write("You cast Flamestrike");
                    break;

                case 3:
                    Console.Write("You cast Fireball!");
                    break;
            }

            System.Threading.Thread.Sleep(1000);
            if (Utilities.Utility.GetRNG().Next(1, 101) > myAgility)
            {
                myHealth -= tempDamageDealt;
                Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 9);
                Console.Write("You dealt ");
                Utilities.Utility.PrintInColour(Math.Round(tempDamageDealt, 2).ToString(), ConsoleColor.Green);
                Console.Write(" damage!");
                if (myHealth <= 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 7);
                    Console.Write("Enemy defeated!");
                    Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 5);
                    Utilities.Utility.PrintInColour("+" + myEXPToGive.ToString(), ConsoleColor.Green);
                    Console.Write(" experience!");
                }
                else if (shouldBeStunned && myCanBeStunned)
                {
                    myStunDuration = 2;
                    Console.SetCursorPosition(tempWWD2 - 7, tempWHD2 - 7);
                    Console.Write("Enemy stunned!");
                }
                else if (shouldBeStunned && !myCanBeStunned)
                {
                    Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 7);
                    Console.Write("Enemy cannot be stunned!");
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
            if (myStunDuration > 0)
            {
                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 11);
                Console.Write("The enemy is stunned and cannot attack");
                myStunDuration--;
            }
            else
            {
                switch (myType)
                {
                    case EnemyType.SKELETON:
                        Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 11);
                        Console.Write("The enemy swings his sword!");
                        break;

                    case EnemyType.ARCHER:
                        Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 11);
                        Console.Write("The enemy draws his bow!");
                        break;

                    case EnemyType.BOSS:
                        Console.SetCursorPosition(tempWWD2 - 10 - (myName.Length / 2), tempWHD2 - 11);
                        Console.Write(myName + " swings his weapon!");
                        break;
                }
                System.Threading.Thread.Sleep(1000);
                if (aPlayer.TakeDamage(myDamage, out float tempDamageDealt))
                {
                    Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 9);
                    Console.Write("You took ");
                    Utilities.Utility.PrintInColour(Math.Round(tempDamageDealt, 2).ToString(), ConsoleColor.Red);
                    Console.Write(" damage!");
                }
                else
                {
                    Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 9);
                    Console.Write("You evaded the strike!");
                }
                if (aPlayer.GetHealth() <= 0)
                {
                    aPlayer.DeathSequence();
                }
            }
            System.Threading.Thread.Sleep(1500);
        }

        #region Get

        public float GetHealth() => myHealth;

        public float GetDamage() => myDamage;

        public int GetArmourRating() => myArmourRating;

        public int GetLevel() => myLevel;

        public int GetEXPToGive() => myEXPToGive;

        public EnemyType GetEnemyType() => myType;

        #endregion Get

        #region Set

        public void SetStunDuration(int aDuration) => myStunDuration = aDuration;

        #endregion Set
    }
}