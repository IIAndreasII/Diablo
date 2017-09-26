using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo
{
    class Room
    {
        List<Enemies.Skeleton> mySkeletons;
        bool myHostilesPresent;

        public Room(int aNumberOfSkeletons)
        {
            mySkeletons = new List<Enemies.Skeleton>();
            for (int i = 0; i < aNumberOfSkeletons; i++)
            {
                mySkeletons.Add(new Enemies.Skeleton(1));
            }
            myHostilesPresent = true;
        }

        public List<Enemies.Skeleton> GetSkeletons()
        {
            return mySkeletons;
        }

        public int GetSkeletonCount()
        {
            return mySkeletons.Count;
        }
    }
}
