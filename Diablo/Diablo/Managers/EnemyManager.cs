using System.Collections.Generic;

namespace Diablo.Managers
{
    static class EnemyManager
    {
        static List<Enemies.Enemy> myEnemies;

        /// <summary>
        /// Initializes the manager
        /// </summary>
        public static void Init()
        {
            myEnemies = new List<Enemies.Enemy>();
        }
        
        /// <summary>
        /// Sets enemies
        /// </summary>
        /// <param name="someEnemies"></param>
        public static void SetEnemies(List<Enemies.Enemy> someEnemies)
        {
            myEnemies = someEnemies;
        }

        /// <summary>
        /// Adds an enemy
        /// </summary>
        /// <param name="anEnemy">Enemy to add</param>
        public static void AddEnemy(Enemies.Enemy anEnemy)
        {
            myEnemies.Add(anEnemy);
        }

        /// <summary>
        /// Updates all enemies
        /// </summary>
        /// <param name="aPlayer">Active player</param>
        public static void BattleUpdate(Player.Player aPlayer)
        {
            for (int i = myEnemies.Count; i > 0; i--)
            {
                if(myEnemies[i - 1].GetHealth() <= 0)
                {
                    aPlayer.AddEXP(myEnemies[i - 1].GetEXPToGive());
                    myEnemies.RemoveAt(i - 1);
                }
                else
                {
                    myEnemies[i - 1].DealDamage(aPlayer);
                }
            }
        }

        /// <summary>
        /// Checks if enemies are still present
        /// </summary>
        /// <returns>Returns true if enemies are defeated</returns>
        public static bool AreEnemiesDefeated()
        {
            if(myEnemies.Count <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Resets the manager's enemies
        /// </summary>
        public static void Reset()
        {
            myEnemies.Clear();
        }
    }
}
