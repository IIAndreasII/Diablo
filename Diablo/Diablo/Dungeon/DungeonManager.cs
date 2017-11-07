using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Dungeon
{
    public static class DungeonManager
    {
        private static Dungeon myDungeon;

        public static void Initialize()
        {
            myDungeon = new Dungeon(Utilities.Utility.GetRNG().Next(2, 15));
        }

        public static void GenerateNewDungeon()
        {
            myDungeon = new Dungeon(Utilities.Utility.GetRNG().Next(2, 15));
        }

        public static void GenerateNewDungeon(int aNumberOfRooms)
        {
            myDungeon = new Dungeon(aNumberOfRooms);
        }

        public static Dungeon GetActiveDungeon()
        {
            return myDungeon;
        }

        public static void EnterDungeon(Player.Player aPlayer)
        {
            myDungeon.EnterDungeon(aPlayer);
        }
    }
}
