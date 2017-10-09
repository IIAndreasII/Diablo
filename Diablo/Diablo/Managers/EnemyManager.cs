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

        public static void Init()
        {
            mySkeletons = new List<Enemies.Skeleton>();
            myArchers = new List<Enemies.Archer>();
        }

        public static void AddSkeleton(Enemies.Skeleton aSkeleton)
        {
            mySkeletons.Add(aSkeleton);
        }

        public static void AddArcher(Enemies.Archer anArcher)
        {
            myArchers.Add(anArcher);
        }
        
        public static void SetEnemies(List<Enemies.Skeleton> someSkeletons, List<Enemies.Archer> someArchers)
        {
            mySkeletons = someSkeletons;
            myArchers = someArchers;
        }

        public static void SetEnemies(List<Enemies.Skeleton> someSkeletons)
        {
            mySkeletons = someSkeletons;
        }

        public static void SetEnemies(List<Enemies.Archer> someArchers)
        {
            myArchers = someArchers;
        }

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
    }
}
