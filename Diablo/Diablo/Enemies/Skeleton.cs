using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Enemies
{
    class Skeleton : Enemy
    {
        private int
            myLevel,
            myDamage,
            myArmourRating;
        private float
            myHealth;
        private bool
            myIsAlive;

        public Skeleton(int aLevel)
        {
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
            myHealth = 25 * myLevel;
            myDamage = 5 * myLevel;
        }

        public void DealDamage(Player.Player aPlayer)
        {
            base.DealDamage(aPlayer, myDamage);
        }

        public void TakeDamage(int aDamage)
        {
            myHealth = base.TakeDamage(aDamage, myArmourRating, myHealth);
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

        public int GetDamage()
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