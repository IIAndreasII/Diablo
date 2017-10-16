using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Factories
{
    static class EnemyFactory
    {
        public static Enemies.Skeleton GenerateSkeleton(int aLvl)
        {
            return new Enemies.Skeleton(aLvl);
        }

        public static Enemies.Archer GenerateArcher(int aLvl)
        {
            return new Enemies.Archer(aLvl);
        }

        public static List<Enemies.Skeleton> GenerateSkeletons(int aNumberOfSkeletons, int aLvl)
        {
            List<Enemies.Skeleton> tempListToReturn = new List<Enemies.Skeleton>();
            for (int i = 0; i < aNumberOfSkeletons; i++)
            {
                tempListToReturn.Add(new Enemies.Skeleton(aLvl));
            }
            return tempListToReturn;
        }

        public static List<Enemies.Archer> GenerateArchers(int aNumberOfArchers, int aLvl)
        {
            List<Enemies.Archer> tempListToReturn = new List<Enemies.Archer>();
            for (int i = 0; i < aNumberOfArchers; i++)
            {
                tempListToReturn.Add(new Enemies.Archer(aLvl));
            }
            return tempListToReturn;
        }
    }
}
