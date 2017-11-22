namespace Diablo.Loot
{
    class Weapon : Item
    {
        public Weapon()
        {
            myType = ItemType.WEAPON;
            myRating = Utilities.Utility.GetRNG().Next(1, 51);
            SetName();
        }

        public Weapon(string aSuffix, int aRating)
        {
            myType = ItemType.WEAPON;
            SetName();
            mySuffix = aSuffix;
            myRating = aRating;
        }
    }
}
