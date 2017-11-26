﻿using System;
using System.Collections.Generic;

namespace Diablo.Dungeon
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
        #region Variables
        List<Enemies.Enemy>
            myEnemies;
        List<Loot.Item> 
            myLoot;
        List<Loot.Chest>
            myChests;
        List<Doors>
            myDoors;
        Enemies.Boss
            myBoss;
        int
            myGold,
            myHPPotions,
            myManaPotions,
            myChestCount,
            myXPos,
            myYPos,
            myNumberOfEnemies;
        bool 
            myAreHostilesPresent,
            myIsBossRoom;
        #endregion

        public Room(int aNumberOfEnemies, int anAmountOfItems, bool isBossRoom, Player.Player aPlayer)
        {
            myDoors = new List<Doors>();
            myEnemies = new List<Enemies.Enemy>();
            myLoot = new List<Loot.Item>();
            myChests = new List<Loot.Chest>();
            myNumberOfEnemies = aNumberOfEnemies;
            myIsBossRoom = isBossRoom;
            myEnemies = Factories.EnemyFactory.CreateEnemies(myNumberOfEnemies, Utilities.Utility.GetRNG().Next(1, aPlayer.GetLevel() + 1));
            if (Utilities.Utility.GetRNG().Next(0, 100) < aPlayer.GetLuck())
            {
                myChestCount = Utilities.Utility.GetRNG().Next(0, 3);
                for (int i = 0; i < myChestCount; i++)
                {
                    myChests.Add(new Loot.Chest());
                }
            }
            for (int i = 0; i < anAmountOfItems; i++)
            {
                myLoot.Add(Factories.LootFactory.CreateItem());
            }
            if (!myIsBossRoom)
            {
                if (aNumberOfEnemies > 0)
                {
                    myAreHostilesPresent = true;
                    myGold = Utilities.Utility.GetRNG().Next(5, 20 * (aNumberOfEnemies) + 1);
                    myHPPotions = Utilities.Utility.GetRNG().Next(0, (aNumberOfEnemies) / 2 + 1);
                    myManaPotions = Utilities.Utility.GetRNG().Next(0, (aNumberOfEnemies) / 2 + 1);
                }
                else
                {
                    myAreHostilesPresent = false;
                }
            }
            else
            {
                myAreHostilesPresent = true;
                myBoss = Factories.EnemyFactory.CreateBoss(aPlayer.GetLevel());
            }
        }

        /// <summary>
        /// Enters the room
        /// </summary>
        /// <param name="aPlayer">The player which will enter</param>
        public void EnterRoom(Player.Player aPlayer)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            aPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 - 12);
            Console.Write("You enter the room and look around");
            if (myEnemies.Count > 0 && !myIsBossRoom)
            {
                if (myEnemies.Count == 1)
                {
                    Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 10);
                    Console.Write("You have spotted 1 enemy!");
                }
                else
                {
                    Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 10);
                    Console.Write("You have spotted " + myEnemies.Count.ToString() + " enemies!");
                }
                System.Threading.Thread.Sleep(2000);
                BattleSequence(aPlayer);
            }
            else if (myIsBossRoom)
            {
                Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 10);
                Console.Write("You have spotted " + myBoss.GetName() + "!");
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
            Managers.EnemyManager.Reset();
            if (!myIsBossRoom)
            {
                Managers.EnemyManager.SetEnemies(myEnemies);
            }
            else
            {
                Managers.EnemyManager.AddEnemy(myBoss);
            }
            while (!Managers.EnemyManager.AreEnemiesDefeated() && !tempHasFled)
            {
                float
                    tempDamageToDeal = 0;
                int
                    tempAoECount = 0,
                    tempSpellChoice = 0;
                bool
                    tempShouldBeStunned = false;
                switch (aPlayer.ChooseBattleAction())
                {
                    case Player.BattleActions.OFFENSIVE:
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                        Console.Write("Choose method of violence");
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 10);
                        Console.Write("[1] Attacks");
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 9);
                        Console.Write("[2] Spells");
                        switch(Utilities.Utility.GetDigitInput(-12, -7, 2))
                        {
                            case 1:
                                aPlayer.PrintUI();
                                Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                                Console.Write("Choose attack");
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10);
                                Console.Write("[1] Slash (hits chosen enemy)");
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 9);
                                Console.Write("[2] Sweep (hits 2 at random -45% dmg)");
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 8);
                                Console.Write("[3] Pounce (stuns chosen enemy -80% dmg)");
                                switch(Utilities.Utility.GetDigitInput(-19, -6, 3, 1))
                                {
                                    case 1:
                                        tempDamageToDeal = aPlayer.GetDamage();
                                        break;
                                    case 2:
                                        tempDamageToDeal = aPlayer.GetDamage() * 0.55f;
                                        tempAoECount = 2;
                                        break;
                                    case 3:
                                        tempDamageToDeal = aPlayer.GetDamage() * 0.2f;
                                        tempShouldBeStunned = true;
                                        break;
                                }
                                break;
                            case 2:
                                aPlayer.PrintUI();
                                Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                                Console.Write("Choose attack");
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10);
                                Console.Write("[1] Fire Bolt (hits chosen enemy, 20 mp)");
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 9);
                                Console.Write("[2] Flamestrike (hits 3 at random, 60 mp)");
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 8);
                                Console.Write("[3] Fireball (might even kill you, 120 mp)");
                                switch (Utilities.Utility.GetDigitInput(-19, -6, 3, 1))
                                {
                                    case 1:
                                        if (aPlayer.GetMana() - 20 >= 0)
                                        {
                                            tempDamageToDeal = aPlayer.GetSpellDamage();
                                            tempSpellChoice = 1;
                                            aPlayer.SetMana(20);
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 4);
                                            Console.Write("Insufficient mana!");
                                            System.Threading.Thread.Sleep(1500);
                                        }
                                        break;
                                    case 2:
                                        if (aPlayer.GetMana() - 60 >= 0)
                                        {
                                            tempDamageToDeal = aPlayer.GetSpellDamage() * 0.55f;
                                            tempAoECount = 2;
                                            tempSpellChoice = 2;
                                            aPlayer.SetMana(60);
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 4);
                                            Console.Write("Insufficient mana!");
                                            System.Threading.Thread.Sleep(1500);
                                        }
                                        break;
                                    case 3:
                                        if (aPlayer.GetMana() - 120 >= 0)
                                        {
                                            tempDamageToDeal = aPlayer.GetSpellDamage() * 5;
                                            tempShouldBeStunned = true;
                                            tempSpellChoice = 3;
                                            aPlayer.SetMana(120);
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 4);
                                            Console.Write("Insufficient mana!");
                                            System.Threading.Thread.Sleep(1500);
                                        }
                                        break;
                                }
                                break;
                        }

                        if (tempAoECount == 0 && tempDamageToDeal > 0)
                        {
                            aPlayer.PrintUI();
                            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                            Console.WriteLine("Choose an enemy to attack");
                            if (!myIsBossRoom)
                            {
                                for (int i = 0; i < myEnemies.Count; i++)
                                {
                                    string tempTypeString = string.Empty;
                                    if (myEnemies[i].GetEnemyType() == Enemies.EnemyType.ARCHER)
                                    {
                                        tempTypeString = "Archer";
                                    }
                                    else if (myEnemies[i].GetEnemyType() == Enemies.EnemyType.SKELETON)
                                    {
                                        tempTypeString = "Skeleton";
                                    }
                                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10 + i);
                                    Console.Write("[" + (i + 1).ToString() + "] '" + tempTypeString + "'; Health - " + Math.Round(myEnemies[i].GetHealth(), 2).ToString() + "; Armour - " + myEnemies[i].GetArmourRating().ToString());
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10);
                                Console.Write("[1] '" + myBoss.GetName() + "'; Health - " + Math.Round(myBoss.GetHealth(), 2).ToString() + "; Armour - " + myBoss.GetArmourRating().ToString());
                            }
                            if (Utilities.Utility.GetDigitInput(-2, -9 + myEnemies.Count, (myIsBossRoom ? 1 : myEnemies.Count), out int tempInputValue) <= myEnemies.Count && !myIsBossRoom)
                            {
                                aPlayer.PrintUI();
                                aPlayer.DealDamage(myEnemies[tempInputValue - 1], tempDamageToDeal, tempShouldBeStunned, tempSpellChoice);
                            }
                            else
                            {
                                aPlayer.PrintUI();
                                aPlayer.DealDamage(myBoss, tempDamageToDeal, tempShouldBeStunned, tempSpellChoice);
                            }
                        }
                        else
                        {
                            if (!myIsBossRoom && tempDamageToDeal > 0)
                            {
                                List<int> tempHitEnemiesIndex = new List<int>();
                                for (int i = 0; i < tempAoECount; i++)
                                {
                                    int tempRandomIndex = Utilities.Utility.GetRNG().Next(0, myEnemies.Count);
                                    while (tempHitEnemiesIndex.Contains(tempRandomIndex))
                                    {
                                        tempHitEnemiesIndex.Remove(tempRandomIndex);
                                        tempRandomIndex = Utilities.Utility.GetRNG().Next(0, myEnemies.Count);
                                    }
                                    tempHitEnemiesIndex.Add(tempRandomIndex);
                                    aPlayer.PrintUI();
                                    aPlayer.DealDamage(myEnemies[tempRandomIndex], tempDamageToDeal, tempShouldBeStunned, tempSpellChoice);
                                }
                            }
                            else if(tempDamageToDeal > 0)
                            {
                                aPlayer.PrintUI();
                                aPlayer.DealDamage(myBoss, tempDamageToDeal, tempShouldBeStunned, tempSpellChoice);
                            }
                        }
                        if(tempSpellChoice == 3)
                        {
                            aPlayer.PrintUI();
                            aPlayer.TakeDamage(aPlayer.GetMaxHealth() * 0.6f, out float tempDamageTaken);
                            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 12);
                            Console.Write("The massive blast burns your skin!");
                            Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 10);
                            Console.Write("You take ");
                            Utilities.Utility.PrintInColour(tempDamageTaken.ToString(), ConsoleColor.DarkRed);
                            Console.Write(" damage!");
                            System.Threading.Thread.Sleep(2000);
                        }
                        break;
                    case Player.BattleActions.DEFENSIVE:
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                        Console.Write("Choose defence");
                        Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10);
                        Console.Write("[1] Raise shield");
                        Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 9);
                        Console.Write("[2] Healing Touch");
                        Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 8);
                        Console.Write("[3] Super-stun (stuns all enemies)");
                        switch (Utilities.Utility.GetDigitInput(-19, -6, 3, 1))
                        {
                            case 1:
                                aPlayer.PrintUI();
                                Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 11);
                                Console.Write("You raise your defences and");
                                Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 10);
                                Console.Write("brace for a strike!");
                                aPlayer.SetIsDefending(true);
                                break;
                            case 2:
                                aPlayer.PrintUI();
                                if (aPlayer.GetMana() - 30 < aPlayer.GetMana())
                                {
                                    Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 11);
                                    Console.Write("You begin touching yourself...");
                                    System.Threading.Thread.Sleep(2000);
                                    Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 9);
                                    Console.Write("It magically heals you(?)");
                                    float tempHealingAmount = 25 * (1 + aPlayer.GetWisdom() / 100f);
                                    aPlayer.SetHealth(tempHealingAmount);
                                    Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 7);
                                    Console.Write("You re-gain ");
                                    Utilities.Utility.PrintInColour(tempHealingAmount.ToString(), ConsoleColor.Green);
                                    Console.Write(" health!");
                                }
                                else
                                {
                                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 4);
                                    Console.Write("Insufficient mana!");
                                }
                                break;
                            case 3:
                                aPlayer.PrintUI();
                                if (aPlayer.GetMana() - 80 < aPlayer.GetMana())
                                {
                                    Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 11);
                                    Console.Write("You throw some pebbles and somehow");
                                    Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 10);
                                    Console.Write("it stuns every enemy in sight");
                                    foreach (Enemies.Enemy tempEnemy in myEnemies)
                                    {
                                        tempEnemy.SetStunDuration(2);
                                    }
                                }
                                else
                                {
                                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 4);
                                    Console.Write("Insufficient mana!");
                                }
                                break;
                        }
                        System.Threading.Thread.Sleep(2000);
                        break;
                    case Player.BattleActions.USEITEM:
                        aPlayer.OpenInventory();
                        break;
                    case Player.BattleActions.FLEE:
                        if (myIsBossRoom)
                        {
                            aPlayer.PrintUI();
                            Console.SetCursorPosition(tempWWD2 - 17, tempWHD2 - 11);
                            Console.Write("You cannot flee from a boss-fight!");
                            System.Threading.Thread.Sleep(1500);
                        }
                        else
                        {
                            tempHasFled = true;
                        }
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
                Managers.EnemyManager.Update(aPlayer);
                aPlayer.Update();
            }
            if (!tempHasFled)
            {
                aPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                if (myIsBossRoom)
                {
                    Console.Write(myBoss.GetName() + " was defeated!");
                }
                else
                {
                    Console.Write("All enemies were defeated!");
                }
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
                        case Loot.ItemType.SCROLL:
                            Utilities.Utility.PrintInColour(myLoot[i].GetFullName(), ConsoleColor.DarkMagenta);
                            break;
                        case Loot.ItemType.TRINKET:
                            Utilities.Utility.PrintInColour(myLoot[i].GetFullName(), ConsoleColor.Green);
                            break;
                        default:
                            Utilities.Utility.PrintInColour("[" + myLoot[i].GetRating() + "]" + myLoot[i].GetFullName(), ConsoleColor.Gray);
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
                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 1);
                Console.Write("[1] Pick up all    [0] Discard all");
                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 2);
                Console.Write("[2] Pick up all & equip best");

                switch (Utilities.Utility.GetDigitInput(-19, 3, 2))
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
            if (myChests.Count > 0)
            {
                aPlayer.PrintUI();
                if (myChests.Count == 1)
                {
                    Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 12);
                    Console.Write("You have found a chest!");
                }
                else
                {
                    Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 12);
                    Console.Write("You have found some chests!");
                }
                System.Threading.Thread.Sleep(1500);
                for (int i = 0; i < myChestCount; i++)
                {
                    myChests[i].Open(aPlayer);
                    if(myChestCount > 1)
                    {
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 15, tempWHD2 - 12);
                        Console.Write("You have found another chest!");
                        System.Threading.Thread.Sleep(1500);
                    }
                }
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
                tempWHD2 = Console.WindowHeight / 2;
            aPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 12);
            Console.Write("Possible actions");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 10);
            Console.Write("[1] Continue adventure");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 9);
            Console.Write("[2] Open inventory");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 8);
            Console.Write("[3] Rest ");
            Utilities.Utility.PrintInColour("(-10 gold)", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 7);
            Console.Write("[4] View map");
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 6);
            Console.Write("[5] Commit suicide");
            switch (Utilities.Utility.GetDigitInput(-1, -4, 5))
            {
                case 2:
                    aPlayer.OpenInventory();
                    PostActio(aPlayer);
                    break;
                case 3:
                    aPlayer.Rest();
                    break;
                case 4:
                    Managers.DungeonManager.GetActiveDungeon().ShowMap(aPlayer);
                    PostActio(aPlayer);
                    break;
                case 5:
                    aPlayer.DeathSequence();
                    break;
            }
        }

        #region Get
        public List<Doors> GetDoors() => myDoors;

        public int GetXPosition() => myXPos;

        public int GetYPosition() => myYPos;
        #endregion

        #region Set
        public void SetIsHostilesPresent(bool aNewValue) => myAreHostilesPresent = aNewValue;

        public void SetDoors(List<Doors> someDoors) => myDoors = someDoors;

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