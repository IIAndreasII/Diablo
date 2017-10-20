using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Managers
{
    static class EnemyManager
    {
        static List<Enemies.Skeleton> mySkeletons;
        static List<Enemies.Archer> myArchers;

        /// <summary>
        /// Initializes the manager
        /// </summary>
        public static void Init()
        {
            mySkeletons = new List<Enemies.Skeleton>();
            myArchers = new List<Enemies.Archer>();
        }

        /// <summary>
        /// Adds a Skeleton to the manager
        /// </summary>
        /// <param name="aSkeleton">Skeleton to add</param>
        public static void AddSkeleton(Enemies.Skeleton aSkeleton)
        {
            mySkeletons.Add(aSkeleton);
        }

        /// <summary>
        /// Adds an Archer to the manager
        /// </summary>
        /// <param name="anArcher">Archer to add</param>
        public static void AddArcher(Enemies.Archer anArcher)
        {
            myArchers.Add(anArcher);
        }
        
        /// <summary>
        /// Sets active enemies
        /// </summary>
        /// <param name="someSkeletons">New active Skeletons</param>
        /// <param name="someArchers">New active Archers</param>
        public static void SetEnemies(List<Enemies.Skeleton> someSkeletons, List<Enemies.Archer> someArchers)
        {
            mySkeletons = someSkeletons;
            myArchers = someArchers;
        }

        /// <summary>
        /// Sets active skeletons
        /// </summary>
        /// <param name="someSkeletons">New active Skeletons</param>
        public static void SetEnemies(List<Enemies.Skeleton> someSkeletons)
        {
            mySkeletons = someSkeletons;
        }

        /// <summary>
        /// Sets active Archers
        /// </summary>
        /// <param name="someArchers">New active Archers</param>
        public static void SetEnemies(List<Enemies.Archer> someArchers)
        {
            myArchers = someArchers;
        }

        /// <summary>
        /// Updates all enemies
        /// </summary>
        /// <param name="aPlayer">Active player</param>
        public static void BattleUpdate(Player.Player aPlayer)
        {
            for (int i = mySkeletons.Count; i > 0; i--)
            {
                if(mySkeletons[i - 1].GetHealth() <= 0)
                {
                    mySkeletons.RemoveAt(i - 1);
                }
                else
                {
                    mySkeletons[i - 1].DealDamage(aPlayer);
                }
            }
            for (int i = myArchers.Count; i > 0; i--)
            {
                if (myArchers[i - 1].GetHealth() <= 0)
                {
                    myArchers.RemoveAt(i - 1);
                }
                else
                {
                    myArchers[i - 1].DealDamage(aPlayer);
                }
            }
        }

        /// <summary>
        /// Checks if enemies are still present
        /// </summary>
        /// <returns>Returns true if enemies are defeated</returns>
        public static bool AreEnemiesDefeated()
        {
            if(myArchers.Count + mySkeletons.Count <= 0)
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
            mySkeletons.Clear();
            myArchers.Clear();
        }
    }
}
