﻿using System;

namespace Diablo.Enemies
{
    class Skeleton : Enemy 
    { 
        public Skeleton(int aLevel)
        {
            myLevel = aLevel;
            if (aLevel == 1)
            {
                myArmourRating = 0;
            }
            else
            {
                myArmourRating = 5 * myLevel;
            }
            myDamage = 5 * myLevel;
            myAgility = myLevel;
            myStamina = 100 + myLevel * 5;
            myHealth = 25 * myLevel * (float)myStamina / 100;
        }
    }
}