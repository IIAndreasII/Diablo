namespace Diablo.Loot
{
    class Armour : Item
    {
        public Armour()
        {
            SetType();
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
        private void SetType()
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
                default:
                    myType = ItemType.ERROR;
                    break;
            }
        }

        /// <summary>
        /// Sets the item's name
        /// </summary>
        private void SetName()
        {
            switch (myType)
            {
                case ItemType.HELMET:
                    myPrefix = "Helmet of";
                    break;
                case ItemType.CHESTPLATE:
                    myPrefix = "Chestplate of";
                    break;
                case ItemType.TROUSERS:
                    myPrefix = "Trousers of";
                    break;
                case ItemType.BOOTS:
                    myPrefix = "Boots of";
                    break;
                case ItemType.SHIELD:
                    myPrefix = "Shield of";
                    break;
                default:
                    myPrefix = "Error of";
                    break;
            }
            mySuffix = Utilities.Utility.GetRandomSuffix();
        }

        public ItemType GetArmourType()
        {
            return myType;
        }
    }
}
