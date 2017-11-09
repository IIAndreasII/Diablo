namespace Diablo.Enemies
{
    public class Archer : Enemy
    {
        public Archer(int aLevel)
        {
            myType = Type.ARCHER;
            myLevel = aLevel;
            if (myLevel == 1)
            {
                myArmourRating = 0;
            }
            else
            {
                myArmourRating = 3 * myLevel;
            }
            myDamage = 7 * myLevel;
            myAgility = 3 * myLevel;
            myStamina = 100 + myLevel * 5;
            myHealth = 17 * myLevel * (float)myStamina / 100;
            myEXPToGive = myLevel * 10;
        }
    }
}