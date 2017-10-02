using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Enemies
{
    class Skeleton : Enemy /// TODO: Add summaries
    {
        private int
            myLevel,
            myArmourRating,
            myAgility,
            myStamina;
        private float
            myDamage,
            myHealth;
        private bool
            myIsAlive;
        Type 
            myType;

        public Skeleton(int aLevel, Type aType)
        {
            myType = aType;
            myIsAlive = true;
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

        public void DealDamage(Player.Player aPlayer)
        {
            DealDamage(aPlayer, myDamage);
        }

        public void TakeDamage(int aDamage, int aStrength)
        {
            myHealth = TakeDamage(aDamage, myArmourRating, myHealth, aStrength, myAgility);
            if(myHealth <= 0)
            {
                myIsAlive = false;
            }
        }

        #region Gets
        public float GetHealth()
        {
            return myHealth;
        }

        public float GetDamage()
        {
            return myDamage;
        }

        public int GetArmourRating()
        {
            return myArmourRating;
        }

        public int GetLevel()
        {
            return myLevel;
        }

        public bool GetIsAlive()
        {
            return myIsAlive;
        }
        #endregion
    }
}