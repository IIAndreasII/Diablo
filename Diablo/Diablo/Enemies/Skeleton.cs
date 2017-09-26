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
            myHealth = 25 * myLevel;
            myDamage = 5 * myLevel;
        }

        public void DealDamage(Player.Player aPlayer)
        {
            base.DealDamage(aPlayer, myDamage);
        }

        public void TakeDamage(int aDamage)
        {
            base.TakeDamage(aDamage, myArmourRating, myHealth);
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
        #endregion
    }
}