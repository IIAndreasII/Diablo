using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Enemies
{
    class Archer : Enemy
    {
        public Archer(int aLevel)
        {
            myLevel = aLevel;
            if (myLevel == 1)
            {
                myArmourRating = 0;
            }
            else
            {
                myArmourRating = 3 * myLevel;
            }
            myDamage = 5 * myLevel;
            myAgility = 3 * myLevel;
            myStamina = 100 + myLevel * 5;
            myHealth = 20 * myLevel * (float)myStamina / 100;
        }
    }
}