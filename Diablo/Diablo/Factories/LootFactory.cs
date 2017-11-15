namespace Diablo.Factories
{
    static class LootFactory
    {
        /// <summary>
        /// Creates an armour-item
        /// </summary>
        /// <returns>An armour-item</returns>
        public static Loot.Armour CreateArmour()
        {
            return new Loot.Armour();
        }

        /// <summary>
        /// Creates a weapon-item
        /// </summary>
        /// <returns>A weaponn-item</returns>
        public static Loot.Weapon CreateWeapon()
        {
            return new Loot.Weapon();
        }

        /// <summary>
        /// Creates a scroll
        /// </summary>
        /// <returns>A scroll</returns>
        public static Loot.Scroll CreateScroll()
        {
            return new Loot.Scroll();
        }


        public static Loot.Trinket CreateTrinket()
        {
            return new Loot.Trinket();
        }

        /// <summary>
        /// Returns a random item (excluding scrolls)
        /// </summary>
        /// <returns>An item</returns>
        public static Loot.Item CreateItem()
        {
            switch (Utilities.Utility.GetRNG().Next(0, 3))
            {
                case 0:
                    return new Loot.Armour();
                case 1:
                    return new Loot.Weapon();
                case 2:
                    return new Loot.Trinket();
                default:
                    return new Loot.Armour();
            }
        }
    }
}
