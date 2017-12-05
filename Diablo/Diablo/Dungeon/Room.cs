using Diablo.Enemies;
using Diablo.Factories;
using Diablo.Localisation;
using Diablo.Loot;
using Diablo.Managers;
using Diablo.Utilities;
using System;
using System.Collections.Generic;
using System.Threading;

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

        private List<Enemy>
            myEnemies;

        private List<Item>
            myLoot;

        private List<Chest>
            myChests;

        private List<Doors>
            myDoors;

        private Boss
            myBoss;

        private int
            myGold,
            myHPPotions,
            myManaPotions,
            myChestCount,
            myXPos,
            myYPos,
            myNumberOfEnemies;

        private bool
            myAreHostilesPresent,
            myIsBossRoom;

        #endregion Variables

        public Room(int aNumberOfEnemies, int anAmountOfItems, bool isBossRoom, Player.Player aPlayer)
        {
            myDoors = new List<Doors>();
            myEnemies = new List<Enemy>();
            myLoot = new List<Item>();
            myChests = new List<Loot.Chest>();
            myNumberOfEnemies = aNumberOfEnemies;
            myIsBossRoom = isBossRoom;
            myEnemies = Factories.EnemyFactory.CreateEnemies(myNumberOfEnemies, Utility.GetRNG().Next(1, aPlayer.GetLevel() + 1));
            if (Utilities.Utility.GetRNG().Next(0, 100) < aPlayer.GetLuck())
            {
                myChestCount = Utilities.Utility.GetRNG().Next(0, 3);
                for (int i = 0; i < myChestCount; i++)
                {
                    myChests.Add(LootFactory.CreateChest());
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
            Console.SetCursorPosition(tempWWD2 - Language.GetEnterRoom().Length / 2, tempWHD2 - 12);
            Console.Write(Language.GetEnterRoom());
            if (myEnemies.Count > 0 && !myIsBossRoom)
            {
                if (myEnemies.Count == 1)
                {
                    Console.SetCursorPosition(tempWWD2 - Language.GetSpottedOne().Length / 2, tempWHD2 - 10);
                    Console.Write(Language.GetSpottedOne());
                }
                else
                {
                    Console.SetCursorPosition(tempWWD2 - Language.GetSpottedMultiple().Length / 2, tempWHD2 - 10);
                    Console.Write(Language.GetSpottedMultiple());
                }
                Thread.Sleep(2000);
                BattleSequence(aPlayer);
            }
            else if (myIsBossRoom)
            {
                Console.SetCursorPosition(tempWWD2 - (Language.GetSpottedBoss().Length + 7) / 2, tempWHD2 - 10);
                Console.Write(Language.GetSpottedBoss() + myBoss.GetName() + "!");
                Thread.Sleep(2000);
                BattleSequence(aPlayer);
            }
            else
            {
                Console.SetCursorPosition(tempWWD2 - Language.GetSpottedNone().Length / 2, tempWHD2 - 10);
                Console.Write(Language.GetSpottedNone());
                Thread.Sleep(2000);
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
            EnemyManager.Reset();
            if (!myIsBossRoom)
            {
                EnemyManager.SetEnemies(myEnemies);
            }
            else
            {
                EnemyManager.AddEnemy(myBoss);
            }
            while (!EnemyManager.AreEnemiesDefeated() && !tempHasFled)
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
                        Console.Write(Language.GetMethodViolence());
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 10);
                        Console.Write("[1] " + Language.GetAttack());
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 9);
                        Console.Write("[2] " + Language.GetSpells());
                        switch (Utility.GetDigitInput(-12, -7, 2))
                        {
                            case 1:
                                aPlayer.PrintUI();
                                Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                                Console.Write(Language.GetChooseAttack());
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10);
                                Console.Write("[1] " + Language.GetSlash());
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 9);
                                Console.Write("[2] " + Language.GetSweep());
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 8);
                                Console.Write("[3] " + Language.GetSlap());
                                switch (Utility.GetDigitInput(-19, -6, 3, 1))
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
                                Console.Write(Language.GetChooseSpell());
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10);
                                Console.Write("[1] " + Language.GetFirebolt());
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 9);
                                Console.Write("[2] " + Language.GetFlamestrike());
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 8);
                                Console.Write("[3] " + Language.GetFireball());
                                switch (Utility.GetDigitInput(-19, -6, 3, 1))
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
                                            Console.Write(Language.GetInsufficientMana());
                                            Thread.Sleep(1500);
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
                                            Console.Write(Language.GetInsufficientMana());
                                            Thread.Sleep(1500);
                                        }
                                        break;

                                    case 3:
                                        if (aPlayer.GetMana() - 120 >= 0)
                                        {
                                            tempDamageToDeal = aPlayer.GetSpellDamage() * 5;
                                            tempShouldBeStunned = true;
                                            tempSpellChoice = 3;
                                            tempAoECount = myEnemies.Count;
                                            aPlayer.SetMana(120);
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 4);
                                            Console.Write(Language.GetInsufficientMana());
                                            Thread.Sleep(1500);
                                        }
                                        break;
                                }
                                break;
                        }

                        if (tempAoECount == 0 && tempDamageToDeal > 0)
                        {
                            aPlayer.PrintUI();
                            Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                            Console.WriteLine(Language.GetChooseEnemy());
                            if (!myIsBossRoom)
                            {
                                for (int i = 0; i < myEnemies.Count; i++)
                                {
                                    string tempTypeString = string.Empty;
                                    if (myEnemies[i].GetEnemyType() == EnemyType.ARCHER)
                                    {
                                        tempTypeString = Language.GetArcher();
                                    }
                                    else if (myEnemies[i].GetEnemyType() == EnemyType.SKELETON)
                                    {
                                        tempTypeString = Language.GetSkeleton();
                                    }
                                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10 + i);
                                    Console.Write("[" + (i + 1).ToString() + "] '" + tempTypeString + "'; " + Language.GetHealth() + " - " + Math.Round(myEnemies[i].GetHealth(), 2).ToString() + "; " + Language.GetArmour() + " - " + myEnemies[i].GetArmourRating().ToString());
                                }
                            }
                            else
                            {
                                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10);
                                Console.Write("[1] '" + myBoss.GetName() + "'; " + Language.GetHealth() + " - " + Math.Round(myBoss.GetHealth(), 2).ToString() + "; " + Language.GetArmour() + " - " + myBoss.GetArmourRating().ToString());
                            }
                            if (Utility.GetDigitInput(-2, -9 + myEnemies.Count, (myIsBossRoom ? 1 : myEnemies.Count), out int tempInputValue) <= myEnemies.Count && !myIsBossRoom)
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
                                    int tempRandomIndex = Utility.GetRNG().Next(0, myEnemies.Count);
                                    while (tempHitEnemiesIndex.Contains(tempRandomIndex))
                                    {
                                        tempHitEnemiesIndex.Remove(tempRandomIndex);
                                        tempRandomIndex = Utility.GetRNG().Next(0, myEnemies.Count);
                                    }
                                    tempHitEnemiesIndex.Add(tempRandomIndex);
                                    aPlayer.PrintUI();
                                    aPlayer.DealDamage(myEnemies[tempRandomIndex], tempDamageToDeal, tempShouldBeStunned, tempSpellChoice);
                                }
                            }
                            else if (tempDamageToDeal > 0)
                            {
                                aPlayer.PrintUI();
                                aPlayer.DealDamage(myBoss, tempDamageToDeal, tempShouldBeStunned, tempSpellChoice);
                            }
                        }
                        if (tempSpellChoice == 3)
                        {
                            aPlayer.PrintUI();
                            aPlayer.TakeDamage(aPlayer.GetMaxHealth() * 0.6f, out float tempDamageTaken);
                            Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 12);
                            Console.Write(Language.GetBurnSkin());
                            Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 10);
                            Console.Write(Language.GetTakeDamagePt1());
                            Utility.PrintInColour(tempDamageTaken.ToString(), ConsoleColor.DarkRed);
                            Console.Write(Language.GetTakeDamagePt2());
                            Thread.Sleep(2000);
                        }
                        break;

                    case Player.BattleActions.DEFENSIVE:
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - 13, tempWHD2 - 12);
                        Console.Write(Language.GetChooseDefence());
                        Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 10);
                        Console.Write("[1] " + Language.GetRaiseShield());
                        Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 9);
                        Console.Write("[2] " + Language.GetHealingTouch());
                        Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 8);
                        Console.Write("[3] " + Language.GetSuperStun());
                        switch (Utility.GetDigitInput(-19, -6, 3, 1))
                        {
                            case 1:
                                aPlayer.PrintUI();
                                Console.SetCursorPosition(tempWWD2 - Language.GetRaiseDefencePt1().Length / 2, tempWHD2 - 11);
                                Console.Write(Language.GetRaiseDefencePt1());
                                Console.SetCursorPosition(tempWWD2 - Language.GetRaiseDefencePt2().Length / 2, tempWHD2 - 10);
                                Console.Write(Language.GetRaiseDefencePt2());
                                aPlayer.SetIsDefending(true);
                                break;

                            case 2:
                                aPlayer.PrintUI();
                                if (aPlayer.GetMana() - 30 < aPlayer.GetMana())
                                {
                                    Console.SetCursorPosition(tempWWD2 - Language.GetBeginTouch().Length / 2, tempWHD2 - 11);
                                    Console.Write(Language.GetBeginTouch());
                                    Thread.Sleep(2000);
                                    Console.SetCursorPosition(tempWWD2 - Language.GetMagicallyHeal().Length / 2, tempWHD2 - 9);
                                    Console.Write(Language.GetMagicallyHeal());
                                    float tempHealingAmount = 25 * (1 + aPlayer.GetWisdom() / 100f);
                                    aPlayer.SetHealth(tempHealingAmount);
                                    Console.SetCursorPosition(tempWWD2 - Language.GetRegain().Length / 2, tempWHD2 - 7);
                                    Console.Write(Language.GetRegain());
                                    Utility.PrintInColour(tempHealingAmount.ToString(), ConsoleColor.Green);
                                    Console.Write(" " + Language.GetHealthLowerCase() + "!");
                                    aPlayer.SetMana(20);
                                }
                                else
                                {
                                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 4);
                                    Console.Write(Language.GetInsufficientMana());
                                }
                                break;

                            case 3:
                                aPlayer.PrintUI();
                                if (aPlayer.GetMana() - 80 < aPlayer.GetMana())
                                {
                                    Console.SetCursorPosition(tempWWD2 - Language.GetThrowPebblesPt1().Length / 2, tempWHD2 - 11);
                                    Console.Write(Language.GetThrowPebblesPt1());
                                    Console.SetCursorPosition(tempWWD2 - Language.GetThrowPebblesPt2().Length / 2, tempWHD2 - 10);
                                    Console.Write(Language.GetThrowPebblesPt2());
                                    if (myIsBossRoom)
                                    {
                                        myBoss.SetStunDuration(2);
                                    }
                                    else
                                    {
                                        foreach (Enemy tempEnemy in myEnemies)
                                        {
                                            tempEnemy.SetStunDuration(2);
                                        }
                                    }
                                    aPlayer.SetMana(80);
                                }
                                else
                                {
                                    Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 - 4);
                                    Console.Write(Language.GetInsufficientMana());
                                }
                                break;
                        }
                        Thread.Sleep(2000);
                        break;

                    case Player.BattleActions.USEITEM:
                        aPlayer.OpenInventory();
                        break;

                    case Player.BattleActions.FLEE:
                        if (myIsBossRoom)
                        {
                            aPlayer.PrintUI();
                            Console.SetCursorPosition(tempWWD2 - Language.GetBossFlee().Length / 2, tempWHD2 - 11);
                            Console.Write(Language.GetBossFlee());
                            Thread.Sleep(1500);
                        }
                        else
                        {
                            tempHasFled = true;
                        }
                        break;

                    case Player.BattleActions.ABSTAIN:
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - Language.GetNoAttackPt1().Length / 2, tempWHD2 - 11);
                        Console.Write(Language.GetNoAttackPt1());
                        Console.SetCursorPosition(tempWWD2 - Language.GetNoAttackPt2().Length / 2, tempWHD2 - 10);
                        Console.Write(Language.GetNoAttackPt2());
                        Thread.Sleep(2000);
                        break;
                }
                EnemyManager.Update(aPlayer);
                aPlayer.Update();
            }
            if (!tempHasFled)
            {
                aPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - Language.GetAllDefeated().Length / 2, tempWHD2 - 12);
                if (myIsBossRoom)
                {
                    Console.Write(myBoss.GetName() + Language.GetBossDefeated());
                }
                else
                {
                    Console.Write(Language.GetAllDefeated());
                }
                aPlayer.SubtractStamina(10);
                Thread.Sleep(2000);
                aPlayer.PrintUI();
                LootSequence(aPlayer);
            }
            else
            {
                aPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - 18, tempWHD2 - 12);
                Console.Write(Language.GetFlee());
                aPlayer.SubtractStamina(30);
                Thread.Sleep(2000);
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
            if (myLoot.Count > 0)
            {
                Console.Write(Language.GetFoundLoot());
                Thread.Sleep(1500);
                for (int i = 0; i < myLoot.Count; i++)
                {
                    Console.SetCursorPosition(tempWWD2 - 20, tempTextOffset + i);
                    Console.Write("[" + (i + 3) + "] ");
                    switch (myLoot[i].GetItemType())
                    {
                        case ItemType.SCROLL:
                            Utility.PrintInColour(myLoot[i].GetFullName(), ConsoleColor.DarkMagenta);
                            break;

                        case ItemType.TRINKET:
                            Utility.PrintInColour(myLoot[i].GetFullName(), ConsoleColor.Green);
                            break;

                        default:
                            Utility.PrintInColour("[" + myLoot[i].GetRating() + "]" + myLoot[i].GetFullName(), ConsoleColor.Gray);
                            break;
                    }

                    if (i == myLoot.Count - 1)
                    {
                        Console.SetCursorPosition(tempWWD2 - 20, tempTextOffset + i * 2 + 1);
                        Utility.PrintInColour(Language.GetHPPotions() + ": " + myHPPotions.ToString(), ConsoleColor.Red);
                        Console.SetCursorPosition(tempWWD2 - 20, tempTextOffset + i * 2 + 2);
                        Utility.PrintInColour(Language.GetManaPotions() + ": " + myManaPotions.ToString(), ConsoleColor.Blue);
                        Console.SetCursorPosition(tempWWD2 - 20, tempTextOffset + i * 2 + 3);
                        Console.Write(Language.GetGold() + ": " + myGold);
                    }
                }
                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 1);
                Console.Write("[1] " + Language.GetPickup() + "    [0] " + Language.GetDiscard());
                Console.SetCursorPosition(tempWWD2 - 20, tempWHD2 + 2);
                Console.Write("[2] " + Language.GetPickUpEquip());

                switch (Utility.GetDigitInput(-19, 3, 2))
                {
                    case 0:
                        myLoot.Clear();
                        break;

                    case 1:
                        aPlayer.AddItemsToInventory(myLoot);
                        aPlayer.SetGold(myGold);
                        aPlayer.SetHealthPotions(myHPPotions);
                        aPlayer.SetManaPotions(myManaPotions);
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - Language.GetLootAdded().Length / 2, tempWHD2 - 12);
                        Console.Write(Language.GetLootAdded());
                        Thread.Sleep(1500);
                        break;

                    case 2:
                        aPlayer.AddItemsToInventory(myLoot);
                        aPlayer.EquipBestItems();
                        aPlayer.SetGold(myGold);
                        aPlayer.SetHealthPotions(myHPPotions);
                        aPlayer.SetManaPotions(myManaPotions);
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - Language.GetLootAdded().Length / 2, tempWHD2 - 12);
                        Console.Write(Language.GetLootAdded());
                        break;
                }
            }
            else
            {
                Console.SetCursorPosition(tempWWD2 - Language.GetFoundNoLoot().Length / 2, tempWHD2 - 12);
                Console.Write(Language.GetFoundNoLoot());
                Thread.Sleep(1500);
            }
            if (myChests.Count > 0)
            {
                aPlayer.PrintUI();
                if (myChests.Count == 1)
                {
                    Console.SetCursorPosition(tempWWD2 - Language.GetFoundChest().Length / 2, tempWHD2 - 12);
                    Console.Write(Language.GetFoundChest());
                }
                else
                {
                    Console.SetCursorPosition(tempWWD2 - Language.GetFoundChests().Length / 2, tempWHD2 - 12);
                    Console.Write(Language.GetFoundChests());
                }
                Thread.Sleep(1500);
                for (int i = 0; i < myChestCount; i++)
                {
                    myChests[i].Open(aPlayer);
                    if (myChestCount > 1)
                    {
                        aPlayer.PrintUI();
                        Console.SetCursorPosition(tempWWD2 - Language.GetFoundAnotherChest().Length / 2, tempWHD2 - 12);
                        Console.Write(Language.GetFoundAnotherChest());
                        Thread.Sleep(1500);
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
            Console.SetCursorPosition(tempWWD2 - Language.GetPossibleActions().Length / 2, tempWHD2 - 12);
            Console.Write(Language.GetPossibleActions());
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 10);
            Console.Write("[1] " + Language.GetContinueAdventure());
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 9);
            Console.Write("[2] " + Language.GetOpenInventory());
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 8);
            Console.Write("[3] " + Language.GetRest());
            Utility.PrintInColour("(-10 " + Language.GetGold() + ")", ConsoleColor.DarkRed);
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 7);
            Console.Write("[4] " + Language.GetViewMap());
            Console.SetCursorPosition(tempWWD2 - 9, tempWHD2 - 6);
            Console.Write("[5] " + Language.GetCommitSuicide());
            switch (Utility.GetDigitInput(-1, -4, 5))
            {
                case 2:
                    aPlayer.OpenInventory();
                    PostActio(aPlayer);
                    break;

                case 3:
                    aPlayer.Rest();
                    break;

                case 4:
                    DungeonManager.GetActiveDungeon().ShowMap(aPlayer);
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

        #endregion Get

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

        #endregion Set
    }
}