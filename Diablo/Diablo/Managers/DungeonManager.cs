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
            myDungeon = Factories.DungeonFactory.GenerateNewDungeon(aPlayer);
            if (myDungeon != null)
            {
                myDungeon.EnterDungeon(aPlayer);
            }
            else
            {
                myDungeon = Factories.DungeonFactory.GenerateNewDungeon(aPlayer);
                myDungeon.EnterDungeon(aPlayer);
            }
        }
    }
}
