using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Enemies
{
    class Boss : Enemy
    {
        protected string
            myName;

        public Boss(int aLvl)
        {
            myType = Type.BOSS;
            myLevel = aLvl;
            myHealth = 100 * aLvl;
            myDamage = 15 * aLvl;
            myArmourRating = 10 * aLvl;
            myEXPToGive = 50 * aLvl;
            myStamina = 150;
            myAgility = 15;
        }
    }
}
