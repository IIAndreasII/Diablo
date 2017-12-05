using Diablo.Localisation;

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

        #endregion Get

        #region Set

        /// <summary>
        /// Sets the item's name
        /// </summary>
        protected void SetName()
        {
            switch (myType)
            {
                case ItemType.HELMET:
                    myPrefix = Language.GetHelmetOf();
                    break;

                case ItemType.CHESTPLATE:
                    myPrefix = Localisation.Language.GetChestPlateOf();
                    break;

                case ItemType.TROUSERS:
                    myPrefix = Localisation.Language.GetTrousersOf();
                    break;

                case ItemType.BOOTS:
                    myPrefix = Localisation.Language.GetBootsOf();
                    break;

                case ItemType.SHIELD:
                    myPrefix = Localisation.Language.GetShieldOf();
                    break;

                case ItemType.WEAPON:
                    myPrefix = Localisation.Language.GetSwordOf();
                    break;

                case ItemType.TRINKET:
                    myPrefix = Localisation.Language.GetTrinketOf();
                    break;

                case ItemType.SCROLL:
                    myPrefix = Localisation.Language.GetScrollOf();
                    break;
            }
            mySuffix = Utilities.Utility.GetRandomSuffix();
        }

        #endregion Set
    }
}