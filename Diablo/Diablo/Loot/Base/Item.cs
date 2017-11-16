namespace Diablo.Loot
{
    public enum ItemType
    {
        HELMET,
        CHESTPLATE,
        TROUSERS,
        BOOTS,
        WEAPON,
        SHIELD,
        TRINKET,
        SCROLL
    }

    public class Item
    {
        protected ItemType
            myType;
        protected string 
            myPrefix,
            mySuffix;
        protected int
            myRating;

        #region Get
        /// <summary>
        /// Gets a random Scrolleffect
        /// </summary>
        /// <returns>A random scrolleffect</returns>
        protected ScrollEffect GetRandomEffect()
        {
            switch (Utilities.Utility.GetRNG().Next(0, 3))
            {
                case 0:
                    return ScrollEffect.ARMBUFF;
                case 1:
                    return ScrollEffect.HPBUFF;
                case 2:
                    return ScrollEffect.STRBUFF;
                default:
                    return ScrollEffect.ARMBUFF;
            }
        }
       
        /// <summary>
        /// Gets the type of the item
        /// </summary>
        /// <returns>an Item type</returns>
        public ItemType GetItemType()
        {
            return myType;
        }

        /// <summary>
        /// Gets the full name of the item
        /// </summary>
        /// <returns>String containing the full name of the item</returns>
        public string GetFullName()
        {
            return myPrefix + " " + mySuffix;
        }

        /// <summary>
        /// Gets the item's prefix
        /// </summary>
        /// <returns>String containing the item's prefix</returns>
        public string GetPrefix()
        {
            return myPrefix;
        }

        /// <summary>
        /// Gets the item's suffix
        /// </summary>
        /// <returns>String containing the item's suffix</returns>
        public string GetSuffix()
        {
            return mySuffix;
        }

        /// <summary>
        /// Gets the item's rating (damage/armour)
        /// </summary>
        /// <returns>Item rating</returns>
        public int GetRating()
        {
            return myRating;
        }
        #endregion
    }
}