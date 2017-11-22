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
        public ItemType GetItemType() => myType;

        /// <summary>
        /// Gets the full name of the item
        /// </summary>
        /// <returns>String containing the full name of the item</returns>
        public string GetFullName() => myPrefix + " " + mySuffix;

        /// <summary>
        /// Gets the item's prefix
        /// </summary>
        /// <returns>String containing the item's prefix</returns>
        public string GetPrefix() => myPrefix;

        /// <summary>
        /// Gets the item's suffix
        /// </summary>
        /// <returns>String containing the item's suffix</returns>
        public string GetSuffix() => mySuffix;

        /// <summary>
        /// Gets the item's rating (damage/armour)
        /// </summary>
        /// <returns>Item rating</returns>
        public int GetRating() => myRating;
        #endregion

        #region Set
        /// <summary>
        /// Sets the item's name
        /// </summary>
        protected void SetName()
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
                case ItemType.WEAPON:
                    myPrefix = "Sword of";
                    break;
                case ItemType.TRINKET:
                    myPrefix = "Trinket of";
                    break;
                case ItemType.SCROLL:
                    myPrefix = "Scroll of";
                    break;
            }
            mySuffix = Utilities.Utility.GetRandomSuffix();
        }
        #endregion
    }
}