using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Enemies
{
    class Boss : Enemy
    {
        public Boss(int aLvl = 1)
        {
            myType = Type.BOSS;
            myLevel = aLvl;
            myHealth = 100 * aLvl;
            myDamage = 15 * aLvl;
            myArmourRating = 10 * aLvl;
            myEXPToGive = 50 * aLvl;
            myStamina = 150;
            myAgility = 15;
            SetName();
        }

        public void SetName()
        {
            switch (Utilities.Utility.GetRNG().Next(0, 5))
            {
                case 0:
                    myName = "Zendurr";
                    break;
                case 1:
                    myName = "Apollyon";
                    break;
                case 2:
                    myName = "Månegarm";
                    break;
                case 3:
                    myName = "Calcifer";
                    break;
                case 4:
                    myName = "Apocalypsis";
                    break;
            }
        }

        public string GetName()
        {
            return myName;
        }
    }
}
