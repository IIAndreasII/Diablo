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
                    Console.Write(Localisation.Language.GetSwingSword());
                    break;

                case 1:
                    Console.Write(Localisation.Language.GetCastFirebolt());
                    break;

                case 2:
                    Console.Write(Localisation.Language.GetCastFlamestrike());
                    break;

                case 3:
                    Console.Write(Localisation.Language.GetCastFireball());
                    break;
            }

            System.Threading.Thread.Sleep(1000);
            if (Utilities.Utility.GetRNG().Next(1, 101) > myAgility)
            {
                myHealth -= tempDamageDealt;
                Console.SetCursorPosition(tempWWD2 - (Localisation.Language.GetDealDamagePt1().Length + Localisation.Language.GetDealDamagePt2().Length + 5) / 2, tempWHD2 - 9);
                Console.Write(Localisation.Language.GetDealDamagePt1());
                Utilities.Utility.PrintInColour(Math.Round(tempDamageDealt, 2).ToString(), ConsoleColor.Green);
                Console.Write(Localisation.Language.GetDealDamagePt2());
                if (myHealth <= 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetEnemyDefeated().Length / 2, tempWHD2 - 7);
                    Console.Write(Localisation.Language.GetEnemyDefeated());
                    Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetEnemyDefeated().Length / 2, tempWHD2 - 5);
                    Utilities.Utility.PrintInColour("+" + myEXPToGive.ToString(), ConsoleColor.Green);
                    Console.Write(" " + Localisation.Language.GetExperience());
                }
                else if (shouldBeStunned && myCanBeStunned)
                {
                    myStunDuration = 2;
                    Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetEnemyStunned().Length / 2, tempWHD2 - 7);
                    Console.Write(Localisation.Language.GetEnemyStunned());
                }
                else if (shouldBeStunned && !myCanBeStunned)
                {
                    Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetEnemyNoStunned().Length / 2, tempWHD2 - 7);
                    Console.Write(Localisation.Language.GetEnemyNoStunned());
                }
            }
            else
            {
                Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetMissedEnemy().Length / 2, tempWHD2 - 9);
                Console.Write(Localisation.Language.GetMissedEnemy());
            }
            System.Threading.Thread.Sleep(2000);
        }

        /// <summary>
        /// Deals damage to given player
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
                Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetEnemyCannotAttack().Length / 2, tempWHD2 - 11);
                Console.Write(Localisation.Language.GetEnemyCannotAttack());
                myStunDuration--;
            }
            else
            {
                switch (myType)
                {
                    case EnemyType.SKELETON:
                        Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetEnemySwingSword().Length / 2, tempWHD2 - 11);
                        Console.Write(Localisation.Language.GetEnemySwingSword());
                        break;

                    case EnemyType.ARCHER:
                        Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetEnemyDrawsBow().Length / 2, tempWHD2 - 11);
                        Console.Write(Localisation.Language.GetEnemyDrawsBow());
                        break;

                    case EnemyType.BOSS:
                        Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetBossWeapon().Length / 2 - (myName.Length / 2), tempWHD2 - 11);
                        Console.Write(myName + Localisation.Language.GetBossWeapon());
                        break;
                }
                System.Threading.Thread.Sleep(1000);
                if (aPlayer.TakeDamage(myDamage, out float tempDamageDealt))
                {
                    Console.SetCursorPosition(tempWWD2 - (Localisation.Language.GetTakeDamagePt1().Length + Localisation.Language.GetTakeDamagePt2().Length + 5) / 2, tempWHD2 - 9);
                    Console.Write(Localisation.Language.GetTakeDamagePt1());
                    Utilities.Utility.PrintInColour(Math.Round(tempDamageDealt, 2).ToString(), ConsoleColor.Red);
                    Console.Write(Localisation.Language.GetTakeDamagePt2());
                }
                else
                {
                    Console.SetCursorPosition(tempWWD2 - Localisation.Language.GetEvadedStrike().Length / 2, tempWHD2 - 9);
                    Console.Write(Localisation.Language.GetEvadedStrike());
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