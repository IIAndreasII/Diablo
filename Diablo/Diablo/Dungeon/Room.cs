using System;
using System.Collections.Generic;

namespace Diablo
{
    public enum Doors
    {
        RIGHT,
        LEFT,
        UP,
        DOWN,
        FAULTYDOOR
    }

    public class Room
    {
        List<Enemies.Skeleton> 
            mySkeletons;
        List<Enemies.Archer>
            myArchers;
        List<Loot.Item> 
            myLoot;
        List<Doors>
            myDoors= new List<Doors>();
        int
            myGold,
            myHPPotions,
            myManaPotions,
            myXPos,
            myYPos;
        bool 
            myAreHostilesPresent;

        public Room(int aNumberOfSkeletons, int aNumberOfArchers, int anAmountOfItems)
        {
            mySkeletons = new List<Enemies.Skeleton>();
            myArchers = new List<Enemies.Archer>();
            myLoot = new List<Loot.Item>();
            if (aNumberOfSkeletons + aNumberOfArchers > 0)
            {
                myAreHostilesPresent = true;
                if (aNumberOfSkeletons > 0)
                {
                    for (int i = 0; i < aNumberOfSkeletons; i++)
                    {
                        mySkeletons.Add(new Enemies.Skeleton(1));
                    }
                }
                if(aNumberOfArchers > 0)
                {
                    for (int i = 0; i < aNumberOfArchers; i++)
                    {
                        myArchers.Add(new Enemies.Archer(1));
                    }
                }
                myGold = Utilities.Utility.GetRNG().Next(5, 20 * (aNumberOfSkeletons + aNumberOfArchers) + 1);
                myHPPotions = Utilities.Utility.GetRNG().Next(0, (aNumberOfSkeletons + aNumberOfArchers) / 2);
                myManaPotions = Utilities.Utility.GetRNG().Next(0, (aNumberOfSkeletons + aNumberOfArchers) / 2);
            }
            else
            {
                myAreHostilesPresent = false;
            }
            for (int i = 0; i < anAmountOfItems; i++)
            {
                myLoot.Add(new Loot.Item());
            }
        }

        /// <summary>
        /// Enters the room
        /// </summary>
        /// <param name="aPlayer">The player which will enter</param>
        public void EnterRoom(Player.Player aPlayer)
        {
            aPlayer.PrintUI();
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 - 12);
            Console.Write("You enter the room and look around");
            if (mySkeletons.Count + myArchers.Count > 0)
            {
                if (mySkeletons.Count + myArchers.Count == 1)
                {
                    Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 10);
                    Console.Write("You have spotted 1 enemy!");
                }
                else
                {
                    Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 10);
                    Console.Write("You have spotted " + (mySkeletons.Count + myArchers.Count) + " enemies!");
                }
                System.Threading.Thread.Sleep(2000);
                BattleSequence(aPlayer);
            }
            else
            {
                Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 10);
                Console.Write("The are no enemies present");
                System.Threading.Thread.Sleep(2000);
                LootSequence(aPlayer);
            }
        }

        /// <summary>
        /// Battlesequence
        /// </summary>
        /// <param name="aPlayer">The player which will enter the sequence</param>
        public void BattleSequence(Player.Player aPlayer)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            bool
                tempHasFled = false;
            Managers.EnemyManager.SetEnemies(mySkeletons, myArchers);
            while (!Managers.EnemyManager.AreEnemiesDefeated() && !tempHasFled && aPlayer.GetHealth() > 0)
            {
                Console.Clear();
                switch (aPlayer.ChooseBattleAction())
                {
                    case Player.BattleActions.ATTACK:

                        Console.Clear();
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                        Console.WriteLine("Choose an enemy to attack");
                        for (int i = 0; i < mySkeletons.Count; i++)
                        {
                            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10 + i);
                            Console.Write("[" + (i + 1).ToString() + @"] 'Skeleton'; Health - " + mySkeletons[i].GetHealth() + "; Armour - " + mySkeletons[i].GetArmourRating().ToString());
                        }
                        for (int i = 0; i < myArchers.Count; i++)
                        {
                            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10 + i + mySkeletons.Count);
                            Console.Write("[" + (i + 1 + mySkeletons.Count).ToString() + @"] 'Archer'; Health - " + myArchers[i].GetHealth() + "; Armour - " + myArchers[i].GetArmourRating().ToString());
                        }
                        Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 9 + mySkeletons.Count + myArchers.Count);
                        Console.Write("[ ]");
                        Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 9 + mySkeletons.Count + myArchers.Count);
                        int tempChoice = 0;
                        while (!int.TryParse(Utilities.Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 0 || tempChoice > mySkeletons.Count + myArchers.Count))
                        {
                            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 9 + mySkeletons.Count + myArchers.Count);
                            Console.Write(" \b");
                        }
                        Console.Clear();
                        aPlayer.PrintUI();
                        if (tempChoice <= mySkeletons.Count)
                        {
                            aPlayer.DealDamage(mySkeletons[tempChoice - 1]);
                        }
                        else if(tempChoice > mySkeletons.Count)
                        {
                            aPlayer.DealDamage(myArchers[tempChoice - mySkeletons.Count - 1]);
                        }
                        break;
                    case Player.BattleActions.DEFEND:
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 11);
                        Console.Write("You raise your defences and");
                        Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 10);
                        Console.Write("brace for a strike!");
                        aPlayer.SetIsDefending(true);
                        System.Threading.Thread.Sleep(2000);
                        break;
                    case Player.BattleActions.USEITEM:
                        aPlayer.OpenInventory();
                        BattleSequence(aPlayer);
                        break;
                    case Player.BattleActions.FLEE:
                        tempHasFled = true;
                        break;
                    case Player.BattleActions.ABSTAIN:
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 11);
                        Console.Write("You do not wish to attack,");
                        Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 10);
                        Console.Write("thus lowering your arms.");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
                Managers.EnemyManager.BattleUpdate(aPlayer);
                aPlayer.UpdateScrollEffects();
            }
            if (!tempHasFled)
            {
                aPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                Console.Write("All enemies were defeated!");
                aPlayer.SubtractStamina(10);
                System.Threading.Thread.Sleep(2000);
                aPlayer.PrintUI();
                LootSequence(aPlayer);
            }
            else
            {
                aPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 12);
                Console.Write("You have fled the battle, coward...");
                aPlayer.SubtractStamina(30);
                System.Threading.Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// The sequence where the player will receive loot
        /// </summary>
        /// <param name="aPlayer">The player which will receive loot</param>
        public void LootSequence(Player.Player aPlayer)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempTextOffset = tempWHD2 - 10;
            aPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
            if(myLoot.Count > 0)
            {
                Console.Write("You have found some loot!");
                System.Threading.Thread.Sleep(1500);
                for (int i = 0; i < myLoot.Count; i++)
                {
                    Console.SetCursorPosition(tempWWD2 - 20, tempTextOffset + i);
                    Console.Write("[" + (i + 3) + "] ");
                    switch (myLoot[i].GetItemType())
                    {
                        case Loot.Type.SCROLL:
                            Utilities.Utility.PrintInColour(myLoot[i].GetFullName(), ConsoleColor.DarkMagenta);
                            break;
                        case Loot.Type.WEAPON:
                            Utilities.Utility.PrintInColour(myLoot[i].GetFullName() + " [" + myLoot[i].GetDamage() + "]", ConsoleColor.Gray);
                            break;
                        default:
                            Utilities.Utility.PrintInColour(myLoot[i].GetFullName() + " [" + myLoot[i].GetArmourRating() + "]", ConsoleColor.Gray);
                            break;
                    }

                    if(i == myLoot.Count - 1)
                    {
                        Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 1);
                        Utilities.Utility.PrintInColour("Health potions: " + myHPPotions.ToString(), ConsoleColor.Red);
                        Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 2);
                        Utilities.Utility.PrintInColour("Mana potions: " + myManaPotions.ToString(), ConsoleColor.Blue);
                        Console.SetCursorPosition(tempWWD2 - 4, tempTextOffset + i * 2 + 3);
                        Console.Write("Gold: " + myGold);                      
                    }
                }
                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2);
                Console.Write("[" + 1.ToString() + "] Pick up all    [0] Discard all");
                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 1);
                Console.Write("[" + 2.ToString() + "] Pick up all and equip best");
                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 3);
                Console.Write("[ ]");
                Console.SetCursorPosition(tempWWD2 - 19, tempWHD2 + 3);
                int tempChoice = -1;
                while (!int.TryParse(Utilities.Utility.ReadOnlyNumbers(myLoot.Count / 2 + 1), out tempChoice) || (tempChoice < 0 || tempChoice > myLoot.Count + 1))
                {
                    Console.SetCursorPosition(tempWWD2 - 19, tempWHD2 + 3);
                    Console.Write(" \b");
                }

                switch (tempChoice)
                {
                    case 0:
                        myLoot.Clear();
                        break;
                    case 1:
                        aPlayer.AddItemsToInventory(myLoot);
                        aPlayer.AddGold(myGold);
                        aPlayer.AddHealthPotions(myHPPotions);
                        aPlayer.AddManaPotions(myManaPotions);
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 12);
                        Console.Write("Loot added to inventory!");
                        System.Threading.Thread.Sleep(1500);
                        break;
                    case 2:
                        aPlayer.AddItemsToInventory(myLoot);
                        aPlayer.EquipBestItems();
                        aPlayer.AddGold(myGold);
                        aPlayer.AddHealthPotions(myHPPotions);
                        aPlayer.AddManaPotions(myManaPotions);
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 12);
                        Console.Write("Loot added to inventory!");
                        break;
                }
            }
            else
            {
                Console.SetCursorPosition(tempWWD2 - 21, tempWHD2 - 12);
                Console.Write("Looking around the room, you found no loot");
                System.Threading.Thread.Sleep(1500);
            }
            PostActio(aPlayer);
        }

        /// <summary>
        /// Lets the player choose what to do after clearing a room from loot and/or enemies
        /// </summary>
        /// <param name="aPlayer">Active player</param>
        public void PostActio(Player.Player aPlayer)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2,
                tempChoice = 0;
            aPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 12);
            Console.Write("Possible actions");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 10);
            Console.Write("[1] Continue adventure");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 9);
            Console.Write("[2] Open inventory");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 8);
            Console.Write("[3] Rest (-10 gold)");
            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 7);
            Console.Write("[4] Commit suicide");
            Console.SetCursorPosition(tempWWD2 - 2, tempWHD2 - 5);
            Console.Write("[ ]");
            Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 5);
            while (!int.TryParse(Utilities.Utility.ReadOnlyNumbers(1), out tempChoice) || (tempChoice < 1 || tempChoice > 3))
            {
                Console.SetCursorPosition(tempWWD2 - 1, tempWHD2 - 5);
                Console.Write(" ]\b\b");
            }
            switch (tempChoice)
            {
                case 2:
                    aPlayer.OpenInventory();
                    PostActio(aPlayer);
                    break;
                case 3:
                    aPlayer.Rest();
                    break;
                case 4:
                    aPlayer.DeathSequence();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        #region Get
        public List<Enemies.Skeleton> GetSkeletons()
        {
            return mySkeletons;
        }

        public int GetSkeletonCount()
        {
            return mySkeletons.Count;
        }

        public bool IsHostilesPresent()
        {
            return myAreHostilesPresent;
        }

        public List<Doors> GetDoors()
        {
            return myDoors;
        }

        public int GetXPosition()
        {
            return myXPos;
        }

        public int GetYPosition()
        {
            return myYPos;
        }

        #endregion

        #region Set
        public void SetIsHostilesPresent(bool aNewValue)
        {
            myAreHostilesPresent = aNewValue;
        }

        public void SetDoors(List<Doors> someDoors)
        {
            myDoors = someDoors;
        }

        public void AddDoor(Doors aDoor)
        {
            if (!myDoors.Contains(aDoor))
            {
                myDoors.Add(aDoor);
            }
        }

        public void SetPosition(int anXValue, int aYValue)
        {
            myXPos = anXValue;
            myYPos = aYValue;
        }

        #endregion
    }
}