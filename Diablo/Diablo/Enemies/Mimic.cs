using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Enemies
{
    class Mimic : Enemy
    {
        public Mimic(int aLvl)
        {
            myDamage = 10 * aLvl;
            myArmourRating = 10 * aLvl;
            myHealth = 20 + 5 * aLvl;

        }
    }
}
