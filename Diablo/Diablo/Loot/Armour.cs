namespace Diablo.Loot
{
    class Armour : Item
    {
        public Armour()
        {
            SetType();
            switch (myType)
            {
                case Type.HELMET:
                    myRating = Utilities.Utility.GetRNG().Next(1, 16);
                    break;
                case Type.CHESTPLATE:
                    myRating = Utilities.Utility.GetRNG().Next(1, 26);
                    break;
                case Type.TROUSERS:
                    myRating = Utilities.Utility.GetRNG().Next(1, 16);
                    break;
                case Type.BOOTS:
                    myRating = Utilities.Utility.GetRNG().Next(1, 11);
                    break;
                case Type.SHIELD:
                    myRating = Utilities.Utility.GetRNG().Next(1, 36);
                    break;
            }
            SetName();
        }

        public Armour(Type aType, string aSuffix, int aRating)
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
                    myType = Type.HELMET;
                    break;
                case 1:
                    myType = Type.CHESTPLATE;
                    break;
                case 2:
                    myType = Type.TROUSERS;
                    break;
                case 3:
                    myType = Type.BOOTS;
                    break;
                case 4:
                    myType = Type.SHIELD;
                    break;
                default:
                    myType = Type.ERROR;
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
                case Type.HELMET:
                    myPrefix = "Helmet of";
                    break;
                case Type.CHESTPLATE:
                    myPrefix = "Chestplate of";
                    break;
                case Type.TROUSERS:
                    myPrefix = "Trousers of";
                    break;
                case Type.BOOTS:
                    myPrefix = "Boots of";
                    break;
                case Type.SHIELD:
                    myPrefix = "Shield of";
                    break;
                default:
                    myPrefix = "Error of";
                    break;
            }
            mySuffix = Utilities.Utility.GetRandomSuffix();
        }

        public Type GetArmourType()
        {
            return myType;
        }
    }
}
