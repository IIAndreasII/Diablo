namespace Diablo.Factories
{
    static class DungeonFactory
    {
        /// <summary>
        /// Generates a new dungeon
        /// </summary>
        public static Dungeon.Dungeon GenerateNewDungeon(Player.Player aPlayer) => new Dungeon.Dungeon(Utilities.Utility.GetRNG().Next(2, 20), aPlayer);

        /// <summary>
        /// Generates a new dungeon with a specified maximum number of rooms
        /// </summary>
        /// <param name="aNumberOfRooms">Maximum number of rooms in the dungeon</param>
        public static Dungeon.Dungeon GenerateNewDungeon(int aNumberOfRooms, Player.Player aPlayer) => new Dungeon.Dungeon(aNumberOfRooms, aPlayer);
    }
}