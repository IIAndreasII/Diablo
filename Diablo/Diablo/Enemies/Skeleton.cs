namespace Diablo.Enemies
{
    public class Skeleton : Enemy
    {
        public Skeleton(int aLevel = 1)
        {
            myType = EnemyType.SKELETON;
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
            myEXPToGive = myLevel * 8;
            myCanBeStunned = true;
        }
    }
}