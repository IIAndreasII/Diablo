using System.Collections.Generic;

namespace Diablo.Factories
{
    static class EnemyFactory
    {
        /// <summary>
        /// Generates a Skeleton
        /// </summary>
        /// <param name="aLvl">The level of the Skeleton</param>
        /// <returns>A Skeleton</returns>
        public static Enemies.Skeleton GenerateSkeleton(int aLvl)
        {
            return new Enemies.Skeleton(aLvl);
        }

        /// <summary>
        /// Generates an Archer
        /// </summary>
        /// <param name="aLvl">The level of the Archer</param>
        /// <returns>an Archer</returns>
        public static Enemies.Archer GenerateArcher(int aLvl)
        {
            return new Enemies.Archer(aLvl);
        }

        /// <summary>
        /// Generates a list of Skeletons
        /// </summary>
        /// <param name="aNumberOfSkeletons">How many Skeletons the list will contain</param>
        /// <param name="aLvl">The level of the Skeletons</param>
        /// <returns>A Skeleton list</returns>
        public static List<Enemies.Skeleton> GenerateSkeletons(int aNumberOfSkeletons, int aLvl)
        {
            List<Enemies.Skeleton> tempListToReturn = new List<Enemies.Skeleton>();
            for (int i = 0; i < aNumberOfSkeletons; i++)
            {
                tempListToReturn.Add(new Enemies.Skeleton(aLvl));
            }
            return tempListToReturn;
        }

        /// <summary>
        /// Generates a list of Archers
        /// </summary>
        /// <param name="aNumberOfArchers">How many Archers the list will contain</param>
        /// <param name="aLvl">The level of the Archers</param>
        /// <returns>An Archer list</returns>
        public static List<Enemies.Archer> GenerateArchers(int aNumberOfArchers, int aLvl)
        {
            List<Enemies.Archer> tempListToReturn = new List<Enemies.Archer>();
            for (int i = 0; i < aNumberOfArchers; i++)
            {
                tempListToReturn.Add(new Enemies.Archer(aLvl));
            }
            return tempListToReturn;
        }

        /// <summary>
        /// Generates a Mimic
        /// </summary>
        /// <returns>A Mimic</returns>
        public static Enemies.Mimic GenerateMimic(int aLvl)
        {
            return new Enemies.Mimic(aLvl);
        }
    }
}
