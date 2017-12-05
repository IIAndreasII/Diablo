namespace Diablo.Loot
{
    internal class Armour : Item
    {
        public Armour()
        {
            SetArmourType();
            switch (myType)
            {
                case ItemType.HELMET:
                    myRating = Utilities.Utility.GetRNG().Next(1, 16);
                    break;

                case ItemType.CHESTPLATE:
                    myRating = Utilities.Utility.GetRNG().Next(1, 26);
                    break;

                case ItemType.TROUSERS:
                    myRating = Utilities.Utility.GetRNG().Next(1, 16);
                    break;

                case ItemType.BOOTS:
                    myRating = Utilities.Utility.GetRNG().Next(1, 11);
                    break;

                case ItemType.SHIELD:
                    myRating = Utilities.Utility.GetRNG().Next(1, 36);
                    break;
            }
            SetName();
        }

        public Armour(ItemType aType, string aSuffix, int aRating)
        {
            myType = aType;
            SetName();
            mySuffix = aSuffix;
            myRating = aRating;
        }

        /// <summary>
        /// Sets the item's item-type
        /// </summary>
        private void SetArmourType()
        {
            switch (Utilities.Utility.GetRNG().Next(0, 5))
            {
                case 0:
                    myType = ItemType.HELMET;
                    break;

                case 1:
                    myType = ItemType.CHESTPLATE;
                    break;

                case 2:
                    myType = ItemType.TROUSERS;
                    break;

                case 3:
                    myType = ItemType.BOOTS;
                    break;

                case 4:
                    myType = ItemType.SHIELD;
                    break;
            }
        }
    }
}