using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo
{
    class Room
    {
        List<Enemies.Skeleton> mySkeletons;
        bool myAreHostilesPresent;

        public Room(int aNumberOfSkeletons)
        {
            mySkeletons = new List<Enemies.Skeleton>();
            for (int i = 0; i < aNumberOfSkeletons; i++)
            {
                mySkeletons.Add(new Enemies.Skeleton(1));
            }
            myAreHostilesPresent = true;
        }

        public List<Enemies.Skeleton> GetSkeletons()
        {
            return mySkeletons;
        }

        public int GetSkeletonCount()
        {
            return mySkeletons.Count;
        }

        public bool IsHostilesPresent()
        {
            return myAreHostilesPresent;
        }

        public void SetIsHostilesPresent(bool aNewValue)
        {
            myAreHostilesPresent = aNewValue;
        }
    }
}
