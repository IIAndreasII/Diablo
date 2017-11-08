namespace Diablo.Managers
{
    public static class DungeonManager
    {
        private static Dungeon.Dungeon myDungeon;
        private static Player.Player myPlayer;

        /// <summary>
        /// Initializes the manager
        /// </summary>
        /// <param name="aPlayer">Active player</param>
        public static void Init(Player.Player aPlayer)
        {
            myPlayer = aPlayer;
            myDungeon = new Dungeon.Dungeon(Utilities.Utility.GetRNG().Next(2, 15), myPlayer);
        }

        /// <summary>
        /// Generates a new dungeon
        /// </summary>
        public static void GenerateNewDungeon()
        {
            myDungeon = new Dungeon.Dungeon(Utilities.Utility.GetRNG().Next(2, 20), myPlayer);
        }

        /// <summary>
        /// Generates a new dungeon with a specified maximum number of rooms
        /// </summary>
        /// <param name="aNumberOfRooms">Maximum number of rooms in the dungeon</param>
        public static void GenerateNewDungeon(int aNumberOfRooms)
        {
            myDungeon = new Dungeon.Dungeon(aNumberOfRooms, myPlayer);
        }

        /// <summary>
        /// Gets the active dungeon
        /// </summary>
        /// <returns>The active dungeon</returns>
        public static Dungeon.Dungeon GetActiveDungeon()
        {
            return myDungeon;
        }

        /// <summary>
        /// Lets the player enter the dungeon
        /// </summary>
        /// <param name="aPlayer">Active player</param>
        public static void EnterDungeon(Player.Player aPlayer)
        {
            if (myDungeon != null)
            {
                myDungeon.EnterDungeon(aPlayer);
            }
            else
            {
                GenerateNewDungeon();
                myDungeon.EnterDungeon(aPlayer);
            }
        }
    }
}
