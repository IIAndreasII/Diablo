using Diablo.Loot;

namespace Diablo.Factories
{
    internal static class LootFactory
    {
        /// <summary>
        /// Creates a chest
        /// </summary>
        /// <returns>A chest</returns>
        public static Chest CreateChest() => new Chest();

        /// <summary>
        /// Creates an armour-item
        /// </summary>
        /// <returns>An armour-item</returns>
        public static Armour CreateArmour() => new Armour();

        /// <summary>
        /// Creates a weapon-item
        /// </summary>
        /// <returns>A weaponn-item</returns>
        public static Weapon CreateWeapon() => new Weapon();

        /// <summary>
        /// Creates a scroll
        /// </summary>
        /// <returns>A scroll</returns>
        public static Scroll CreateScroll() => new Scroll();

        /// <summary>
        /// Creates a trinket
        /// </summary>
        /// <returns>A trinket</returns>
        public static Trinket CreateTrinket() => new Trinket();

        /// <summary>
        /// Creates a random item
        /// </summary>
        /// <returns>An item</returns>
        public static Item CreateItem()
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