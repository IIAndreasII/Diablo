using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Loot
{
    class Chest
    {
        int
            myGold,
            myHPPotions,
            myManaPotions;
        List<Item>
            myItems;

        public Chest()
        {
            myGold = Utilities.Utility.GetRNG().Next(0, 50);
            myHPPotions = Utilities.Utility.GetRNG().Next(0, 2);
            myManaPotions = Utilities.Utility.GetRNG().Next(0, 2);
        }
    }
}