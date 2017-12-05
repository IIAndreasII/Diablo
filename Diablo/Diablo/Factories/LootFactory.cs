namespace Diablo.Factories
{
    internal static class LootFactory
    {
        /// <summary>
        /// Creates a chest
        /// </summary>
        /// <returns>A chest</returns>
        public static Loot.Chest CreateChest() => new Loot.Chest();

        /// <summary>
        /// Creates an armour-item
        /// </summary>
        /// <returns>An armour-item</returns>
        public static Loot.Armour CreateArmour() => new Loot.Armour();

        /// <summary>
        /// Creates a weapon-item
        /// </summary>
        /// <returns>A weaponn-item</returns>
        public static Loot.Weapon CreateWeapon() => new Loot.Weapon();

        /// <summary>
        /// Creates a scroll
        /// </summary>
        /// <returns>A scroll</returns>
        public static Loot.Scroll CreateScroll() => new Loot.Scroll();

        /// <summary>
        /// Creates a trinket
        /// </summary>
        /// <returns>A trinket</returns>
        public static Loot.Trinket CreateTrinket() => new Loot.Trinket();

        /// <summary>
        /// Creates a random item
        /// </summary>
        /// <returns>An item</returns>
        public static Loot.Item CreateItem()
        {
            switch (Utilities.Utility.GetRNG().Next(0, 4))
            {
                case 0:
                    return new Loot.Armour();

                case 1:
                    return new Loot.Weapon();

                case 2:
                    return new Loot.Trinket();

                case 3:
                    return new Loot.Scroll();

                default:
                    return new Loot.Armour();
            }
        }
    }
}