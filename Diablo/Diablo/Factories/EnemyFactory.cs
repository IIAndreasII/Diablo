using System.Collections.Generic;

namespace Diablo.Factories
{
    internal static class EnemyFactory
    {
        /// <summary>
        /// Creates a random enemy
        /// </summary>
        /// <param name="aLvl">Level of the enemy</param>
        /// <returns>An enemy</returns>
        public static Enemies.Enemy CreateEnemy(int aLvl)
        {
            switch (Utilities.Utility.GetRNG().Next(0, 2))
            {
                case 0:
                    return new Enemies.Archer(aLvl);

                default:
                    return new Enemies.Skeleton(aLvl);
            }
        }

        /// <summary>
        /// Creates a list of random enemies
        /// </summary>
        /// <param name="aNumberOfEnemies">Number of enemies in the list</param>
        /// <param name="aLvl">Level of the enemies</param>
        /// <returns>a list of enemies</returns>
        public static List<Enemies.Enemy> CreateEnemies(int aNumberOfEnemies, int aLvl)
        {
            List<Enemies.Enemy> tempListToReturn = new List<Enemies.Enemy>();
            for (int i = 0; i < aNumberOfEnemies; i++)
            {
                tempListToReturn.Add(CreateEnemy(aLvl));
            }
            return tempListToReturn;
        }

        /// <summary>
        /// Creates a boss
        /// </summary>
        /// <param name="aLvl">The boss' level</param>
        /// <returns>A boss</returns>
        public static Enemies.Boss CreateBoss(int aLvl) => new Enemies.Boss(aLvl);
    }
}