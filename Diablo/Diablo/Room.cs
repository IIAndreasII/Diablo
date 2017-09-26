using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo
{
    class Room
    {
        List<Enemies.Skeleton> mySkeletons;

        public Room(int aNumberOfSkeletons)
        {
            mySkeletons = new List<Enemies.Skeleton>();
        }

        public void Encounter()
        {
            Console.WriteLine("You have encountered hostiles!!!");
            Console.ReadKey();
        }
    }
}
