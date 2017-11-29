using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Localisation
{
    public static class Language
    {
        #region Swedish
        private static string
            myPlaySE = "Spela",
            myExitSE = "Avsluta",
            myBackSE = "Tillbaks",
            myInsufficientFundsSE = "Otillräckligt med guld!",

            myLevelUpSE = "Nivå ökad!",
            myMaxHealthSE = "Max hälsa",
            myMaxManaSE = "Max mana",
            myMaxStaminaSE = "Max kondition",
            myStrengthSE = "Styrka",
            myAgilitySE = "Smidighet",
            myWisdomSE = "Visdom",
            myIntelligenceSE = "Intelligens",
            myLuckSE = "Tur",
            mySpellDmgSE = "Trollformelsskada",

            myPossibleActionsSE = "Möjliga val:",
            myEnterDungeonSE = "Gå in i fängelsehåla",

            myOpenInventorySE = "Öppna inventarie",
            myInventorySE = "Inventarie",
            myGoldSE = "Guld",
            myHPPotionsSE = "Hälsodrycker",
            myManaPotionsSE = "Manadrycker",
            myTrinketsSE = "Prylar",
            myScrollsSE = "Rullar",
            myEquippedSE = "Använd:",
            myApplySE = "Applicera",
            myEquipSE = "Använd",
            myThrowAwaySE = "Kasta",



            myRestSE = "Vila",
            myLightFireSE = "Du tänder en brasa och vilar.",
            myRegainSE = "Du får åter",
            myRegainStaminaSE = "kondition",

            myLongRestSE = "Vila länge",
            myPitchTentSE = "Du sätter upp ett tält och tänder en brasa",
            myFullRecoverySE = "Fullständig återhämtning!",

            myCommitSuicideSE = "Begå självmord",

            myMusicSettingsSE = "Musik-inställningar",
            myChooseSongSE = "Välj låt:",

            myWhatUDoSE = "Vad gör du?",
            myOffensiveSE = "Offensivt",
            myMethodViolenceSE = "Välj metod av våldsamhet:",
            myAttackSE = "Attacker",
            myChooseAttackSE = "Välj attack:",
            mySlashSE = "Hugg",
            mySweepSE = "Svep (träffar 2 fiender)",
            mySlapSE = "Örfil (knockar 1 fiende)",
            mySwingSwordSE = "Du svingar ditt svärd",
            mySpellsSE = "Trollformler",
            myChooseSpellSE = "Välj trollformel:",
            myFireBoltSE = "Eldvigg (träffar vald fiende, 20mp)",
            myCastFireBoltSE = "Du använder eldvigg!",
            myFlamestrikeSE = "Flammsmisk (träffar tre fiender, 60 mp)",
            myCastFlamestrikeSE = "Du använder flammsmisk!",
            myFireballSE = "Eldklot (kanske t.o.m dödar dig, 120mp)",
            myCastFireBallSE = "Du använder eldklot!",
            myBurnSkinSE = "Den stora smällen bränner ditt skinn!",
            myTakeDamage1SE = "Du tar ",
            myTakeDamage2SE = "skada!",
            myInsufficientManaSE = "Otillräckligt med mana",
            myChooseEnemySE = "Välj en fiende att attackera:",
            myArcherSE = "Bågskytt",
            mySkeletonSE = "Skelett",
            myHealthSE = "Hälsa",
            myHealthSmallSE = "hälsa",
            myArmourSE = "Rustning",
            myEnemyDefeatedSE = "Fiende besgrad!",
            myExperienceSE = "erfarenhet!",
            myEnemyStunnedSE = "Fiende knockad!",
            myEnemyNotStunnedSE = "Fienden kan inte bli knockad!",
            myMissedEnemySE = "Du missade fienden!",

            myEnemyCannotAttackSE = "Fienden är knockad och kan inte attackera",
            myEnemySwingSwordSE = "Fienden svingar sitt svärd!",
            myEnemyDrawsBowSE = "Fienden spänner sin pilbåge!",
            myBossWeaponSE = " använder sitt vapen!",
            myEvadedStrikeSE = "Du undvek smällen!",

            myDefensiveSE = "Defensivt",
            myChooseDefenceSE = "Välj försvar:",
            myRaiseShieldSE = "Höj skölden",
            myRaiseDefence1SE = "Du höjer din sköld och",
            myRaiseDefence2SE = "förbereder för ett slag!",
            myHealingTouchSE = "Helande beröring",
            myBeginTouchSE = "Du börjar röra vid dig själv...",
            myMagicallyHealSE = "Det helar dig på något magiskt sätt(?)",
            mySuperStunSE = "Super örfil (knockar alla fiender)",
            myThrowPebbles1SE = "Du kastar lite småsten och på något",
            myThrowPebbles2SE = "sätt knockar det alla fiender",

            myUseItemSE = "Använd föremål",
            myFleeSE = "Fly",
            myHasFledSE = "Du flydde striden, jävla mes...",
            myBossFleeSE = "Du kan inte springa från en boss!",

            myAbstainSE = "Avstå",
            myNoAttack1SE = "Du vill inte attackera och sänker",
            myNoAttack2SE = "därför dina vapen",

            myAllDefeatedSE = "Alla fiender är besegrade!",
            myBossDefeatedSE = "är besegrad",

            myFoundLootSE = "Du har hittat lite krimskrams!",
            myPickUpSE = "Plocka upp",
            myPickUpEquipSE = "Plocka upp och använd bästa",
            myDiscardSE = "Släng allt",
            myLootAddedSE = "Krimskrams tillagt i inventariet!",

            myFoundNoLootSE = "Du hittade inget krimskrams i rummet",
            myFoundChestSE = "Du hittade en kista!",
            myFoundChestsSE = "Du hittade några kistor!",
            myFoundAnotherChestSE = "Du hittade ytterligare en kista!",

            myContinueAdventureSE = "Fortsätt äventyr",
            myThereAreDoors1SE = "Det finns ",
            myThereAreDoors2SE = " dörrar i det här rummet",
            myChooseDoorSE = "Vilken går du in i?",
            myExitDungeonSE = "Lämna fängelsehåla",
            myExitingDungeonSE = "Säkert, lämnar du fängelsehålan",
            myViewMapSE = "Titta på kartan",
            myInitialRoomSE = "Utgångsrum och utgång",
            myCurrentRoomSE = "Nuvarande rum",
            myRoomSE = "Rum";


        #endregion Swedish

        #region English
        private static string
            myPlayEN = "Play",
            myExitEN = "Exit",
            myBackEN = "Back",
            myInsufficientFundsEN = "Insufficient gold!",

            myLevelUpEN = "Level up!",
            myMaxHealthEN = "Max health",
            myMaxManaEN = "Max mana",
            myMaxStaminaEN = "Max stamina",
            myStrengthEN = "Strength",
            myAgilityEN = "Agility",
            myWisdomEN = "Wisdom",
            myIntelligenceEN = "Intelligence",
            myLuckEN = "Luck",
            mySpellDmgEN = "Spell damage",

            myPossibleActionsEN = "Possible actions:",
            myEnterDungeonEN = "Enter dungeon",

            myOpenInventoryEN = "Open inventroy",
            myInventoryEN = "Inventory",
            myGoldEN = "Gold",
            myHPPotionsEN = "Healthpotions",
            myManaPotionsEN = "Manapotions",
            myTrinketsEN = "Trinkets",
            myScrollsEN = "Scrolls",
            myEquippedEN = "Equipped:",
            myApplyEN = "Apply",
            myEquipEN = "Equip",
            myThrowAwayEN = "Throw away",



            myRestEN = "Rest",
            myLightFireEN = "You light a fire and rest",
            myRegainEN = "You re-gain",
            myRegainStaminaEN = "stamina",

            myLongRestEN = "Long rest",
            myPitchTentEN = "You pitch a tent and light a fire",
            myFullRecoveryEN = "Full recovery",

            myCommitSuicideEN = "Commit suicide",

            myMusicSettingsEN = "Music settings",
            myChooseSongEN = "Choose song:",

            myWhatUDoEN = "What do you do?",
            myOffensiveEN = "Offensive",
            myMethodViolenceEN = "Choose method of violence:",
            myAttackEN = "Attacks",
            myChooseAttackEN = "Choose attack:",
            mySlashEN = "Slash",
            mySweepEN = "Sweep (hits 2 random enemies)",
            mySlapEN = "Slap (stuns chosen enemy)",
            mySwingSwordEN = "Du swing your sword!",
            mySpellsEN = "Spells",
            myChooseSpellEN = "Choose spell:",
            myFireBoltEN = "Firebolt (hits chosen enemy, 20mp)",
            myCastFireBoltEN = "You cast firebolt!",
            myFlamestrikeEN = "Flamestrike (hits 3 random enemies, 60 mp)",
            myCastFlamestrikeEN = "You cast flamestrike!",
            myFireballEN = "Fireball (might even kill you, 120mp)",
            myCastFireBallEN = "You cast fireball!",
            myBurnSkinEN = "The massive blast burns your skin!",
            myTakeDamage1EN = "You take ",
            myTakeDamage2EN = " damgae!",
            myInsufficientManaEN = "Insufficient mana!",
            myChooseEnemyEN = "Choose enemy to attack:",
            myArcherEN = "Archer",
            mySkeletonEN = "Skeleton",
            myHealthEN = "Health",
            myHealthSmallEN = "health",
            myArmourEN = "Armour",
            myEnemyDefeatedEN = "Enemy defeated!",
            myExperienceEN = " experience!",
            myEnemyStunnedEN = "Enemy stunned!",
            myEnemyNotStunnedEN = "Enemy cannot be stunned!",
            myMissedEnemyEN = "You missed the enemy!",

            myEnemyCannotAttackEN = "The enemy is stunned and cannot attack",
            myEnemySwingSwordEN = "The enemy swings his sword!",
            myEnemyDrawsBowEN = "The enemy draws his bow!",
            myBossWeaponEN = " uses his weapon!",
            myEvadedStrikeEN = "You evaded the strike!",

            myDefensiveEN = "Defensive",
            myChooseDefenceEN = "Choose defence:",
            myRaiseShieldEN = "Raise shield",
            myRaiseDefence1EN = "You raise your shield and",
            myRaiseDefence2EN = "brace for a strike!",
            myHealingTouchEN = "Healing touch",
            myBeginTouchEN = "You begin touching yourself...",
            myMagicallyHealEN = "It magically heals you(?)",
            mySuperStunEN = "Super stun (stuns all enemies)",
            myThrowPebbles1EN = "You throw some pebbles and somehow",
            myThrowPebbles2EN = "it stuns every enemy in sight",

            myUseItemEN = "Use item",
            myFleeEN = "Flee",
            myHasFledEN = "You have fled the battle, coward...",
            myBossFleeEN = "You cannot flee from a bossfight!",

            myAbstainEN = "Abstain",
            myNoAttack1EN = "You do not wish to attack,",
            myNoAttack2EN = "thus lowering your arms",

            myAllDefeatedEN = "All enemies defeated!",
            myBossDefeatedEN = " has been defeated!",

            myFoundLootEN = "You have found some loot!",
            myPickUpEN = "Pick up all",
            myPickUpEquipEN = "Pick up all & equip best",
            myDiscardEN = "Discard all",
            myLootAddedEN = "Loot added to inventory!",

            myFoundNoLootEN = "You found no loot in the room",
            myFoundChestEN = "You have found a chest!",
            myFoundChestsEN = "You have found some chests!",
            myFoundAnotherChestEN = "You found another chest!",

            myContinueAdventureEN = "Continue adventure",
            myThereAreDoors1EN = "There are/is ",
            myThereAreDoors2EN = " doors in this room",
            myChooseDoorEN = "Which one do you enter?",
            myExitDungeonEN = "Exit dungeon",
            myExitingDungeonEN = "Safely, you exit the dungeon",
            myViewMapEN = "View map",
            myInitialRoomEN = "Initial room and exit",
            myCurrentRoomEN = "Current room",
            myRoomEN = "Room";
        #endregion English

        #region Active
        private static string
            myPlay,
            myExit,
            myBack,
            myInsufficientFunds,

            myLevelUp,
            myMaxHealth,
            myMaxMana,
            myMaxStamina,
            myStrength,
            myAgility ,
            myWisdom,
            myIntelligence,
            myLuck,
            mySpellDmg,

            myPossibleActions,
            myEnterDungeon,

            myOpenInventory,
            myInventory,
            myGold ,
            myHPPotions ,
            myManaPotions,
            myTrinkets ,
            myScrolls,
            myEquipped,
            myApply,
            myEquip ,
            myThrowAway,



            myRest ,
            myLightFire,
            myRegain ,
            myRegainStamina ,

            myLongRest,
            myPitchTent,
            myFullRecovery,

            myCommitSuicide,

            myMusicSettings,
            myChooseSong,

            myWhatUDo,
            myOffensive,
            myMethodViolence ,
            myAttack,
            myChooseAttack,
            mySlash ,
            mySweep,
            mySlap ,
            mySwingSword,
            mySpells,
            myChooseSpell ,
            myFireBolt ,
            myCastFireBolt,
            myFlamestrike,
            myCastFlamestrike,
            myFireball,
            myCastFireBall,
            myBurnSkin,
            myTakeDamage1,
            myTakeDamage2,
            myInsufficientMana ,
            myChooseEnemy,
            myArcher,
            mySkeleton ,
            myHealth,
            myHealthSmall,
            myArmour,
            myEnemyDefeated,
            myExperience ,
            myEnemyStunned,
            myEnemyNoStunned,
            myMissedEnemy,

            myEnemyCannotAttack,
            myEnemySwingSword,
            myEnemyDrawsBow,
            myBossWeapon ,
            myEvadedStrike,

            myDefensive,
            myChooseDefence ,
            myRaiseShield,
            myRaiseDefence1,
            myRaiseDefence2,
            myHealingTouch,
            myBeginTouch,
            myMagicallyHeal,
            mySuperStun ,
            myThrowPebbles1,
            myThrowPebbles2 ,

            myUseItem,
            myFlee,
            myHasFled ,
            myBossFlee ,

            myAbstain,
            myNoAttack1,
            myNoAttack2,

            myAllDefeated,
            myBossDefeated ,

            myFoundLoot ,
            myPickUp,
            myPickUpEquip,
            myDiscard,
            myLootAdded ,

            myFoundNoLoot,
            myFoundChest ,
            myFoundChests,
            myFoundAnotherChest,

            myContinueAdventure,
            myThereAreDoors1,
            myThereAreDoors2,
            myChooseDoor,
            myExitDungeon,
            myExitingDungeon ,
            myViewMap ,
            myInitialRoom ,
            myCurrentRoom ,
            myRoom;
        #endregion Active

        /// <summary>
        /// Initializes values
        /// </summary>
        public static void Init() => English();

        /// <summary>
        /// Sets the language to Swedish
        /// </summary>
        public static void Swedish()
        {
            myPlay = myPlaySE;
            myExit = myExitSE;
            myBack = myBackSE;
            myInsufficientFunds = myInsufficientFundsSE;

            myLevelUp = myLevelUpSE;
            myMaxHealth = myMaxHealthSE;
            myMaxMana = myMaxManaSE;
            myMaxStamina = myMaxStaminaSE;
            myStrength = myStrengthSE;
            myAgility = myAgilitySE;
            myWisdom = myWisdomSE;
            myIntelligence = myWisdomSE;
            myLuck = myLuckSE;
            mySpellDmg = mySpellDmgSE;

            myPossibleActions = myPossibleActionsSE;
            myEnterDungeon = myEnterDungeonSE;

            myOpenInventory = myOpenInventorySE;
            myInventory = myInventorySE;
            myGold = myGoldSE;
            myHPPotions = myHPPotionsSE;
            myManaPotions = myManaPotionsSE;
            myTrinkets = myTrinketsSE;
            myScrolls = myScrollsSE;
            myEquipped = myEquippedSE;
            myApply = myApplySE;
            myEquip = myEquipSE;
            myThrowAway = myThrowAwaySE;

            myRest = myRestSE;
            myLightFire = myLightFireSE;
            myRegain = myRegainSE;
            myRegainStamina = myRegainStaminaSE;

            myLongRest = myLongRestSE;
            myPitchTent = myPitchTentSE;
            myFullRecovery = myFullRecoverySE;

            myCommitSuicide = myCommitSuicideSE;

            myMusicSettings = myMusicSettingsSE;
            myChooseSong = myChooseSongSE;

            myWhatUDo = myWhatUDoSE;
            myOffensive = myOffensiveSE;
            myMethodViolence = myMethodViolenceSE;
            myAttack = myAttackSE;
            myChooseAttack = myChooseAttackSE;
            mySlash = mySlashSE;
            mySweep = mySweepSE;
            mySlap = mySlapSE;
            mySwingSword = mySwingSwordSE;
            mySpells = mySpellsSE;
            myChooseSpell = myChooseSpellSE;
            myFireBolt = myFireBoltSE;
            myCastFireBolt = myCastFireBoltSE;
            myFlamestrike = myFlamestrikeSE;
            myCastFlamestrike = myCastFlamestrikeSE;
            myFireball = myFireballSE;
            myCastFireBall = myCastFireBallSE;
            myBurnSkin = myBurnSkinSE;
            myTakeDamage1 = myTakeDamage1SE;
            myTakeDamage2 = myTakeDamage2SE;
            myInsufficientMana = myInsufficientManaSE;
            myChooseEnemy = myChooseEnemySE;
            myArcher = myArcherSE;
            mySkeleton = mySkeletonSE;
            myHealth = myHealthSE;
            myHealthSmall = myHealthSmallSE;
            myArmour = myArmourSE;
            myEnemyDefeated = myEnemyDefeatedSE;
            myExperience = myExperienceSE;
            myEnemyStunned = myEnemyStunnedSE;
            myEnemyNoStunned = myEnemyNotStunnedSE;
            myMissedEnemy = myMissedEnemySE;

            myEnemyCannotAttack = myEnemyCannotAttackSE;
            myEnemySwingSword = myEnemySwingSwordSE;
            myEnemyDrawsBow = myEnemyDrawsBowSE;
            myBossWeapon = myBossWeaponSE;
            myEvadedStrike = myEvadedStrikeSE;

            myDefensive = myDefensiveSE;
            myChooseDefence = myChooseDefenceSE;
            myRaiseShield = myRaiseShieldSE;
            myRaiseDefence1 = myRaiseDefence1SE;
            myRaiseDefence2 = myRaiseDefence2SE;
            myHealingTouch = myHealingTouchSE;
            myBeginTouch = myBeginTouchSE;
            myMagicallyHeal = myMagicallyHealSE;
            mySuperStun = mySuperStunSE;
            myThrowPebbles1 = myThrowPebbles1SE;
            myThrowPebbles2 = myThrowPebbles2SE;

            myUseItem = myUseItemSE;
            myFlee = myFleeSE;
            myHasFled = myHasFledSE;
            myBossFlee = myBossFleeSE;

            myAbstain = myAbstainSE;
            myNoAttack1 = myNoAttack1SE;
            myNoAttack2 = myNoAttack2SE;

            myAllDefeated = myAllDefeatedSE;
            myBossDefeated = myBossDefeatedSE;

            myFoundLoot = myFoundLootSE;
            myPickUp = myPickUpSE;
            myPickUpEquip = myPickUpEquipSE;
            myDiscard = myDiscardSE;
            myLootAdded = myLootAddedSE;

            myFoundNoLoot = myFoundNoLootSE;
            myFoundChest = myFoundChestSE;
            myFoundChests = myFoundChestsSE;
            myFoundAnotherChest = myFoundAnotherChestSE;

            myContinueAdventure = myContinueAdventureSE;
            myThereAreDoors1 = myThereAreDoors1SE;
            myThereAreDoors2 = myThereAreDoors2SE;
            myChooseDoor = myChooseDoorSE;
            myExitDungeon = myExitDungeonSE;
            myExitingDungeon = myExitingDungeonSE;
            myViewMap = myViewMapSE;
            myInitialRoom = myInitialRoomSE;
            myCurrentRoom = myCurrentRoomSE;
            myRoom = myRoomSE;
        }

        /// <summary>
        /// Sets the language to English
        /// </summary>
        public static void English()
        {
            myPlay = myPlayEN;
            myExit = myExitEN;
            myBack = myBackEN;
            myInsufficientFunds = myInsufficientFundsEN;

            myLevelUp = myLevelUpEN;
            myMaxHealth = myMaxHealthEN;
            myMaxMana = myMaxManaEN;
            myMaxStamina = myMaxStaminaEN;
            myStrength = myStrengthEN;
            myAgility = myAgilityEN;
            myWisdom = myWisdomEN;
            myIntelligence = myWisdomEN;
            myLuck = myLuckEN;
            mySpellDmg = mySpellDmgEN;

            myPossibleActions = myPossibleActionsEN;
            myEnterDungeon = myEnterDungeonEN;

            myOpenInventory = myOpenInventoryEN;
            myInventory = myInventoryEN;
            myGold = myGoldEN;
            myHPPotions = myHPPotionsEN;
            myManaPotions = myManaPotionsEN;
            myTrinkets = myTrinketsEN;
            myScrolls = myScrollsEN;
            myEquipped = myEquippedEN;
            myApply = myApplyEN;
            myEquip = myEquipEN;
            myThrowAway = myThrowAwayEN;

            myRest = myRestEN;
            myLightFire = myLightFireEN;
            myRegain = myRegainEN;
            myRegainStamina = myRegainStaminaEN;

            myLongRest = myLongRestEN;
            myPitchTent = myPitchTentEN;
            myFullRecovery = myFullRecoveryEN;

            myCommitSuicide = myCommitSuicideEN;

            myMusicSettings = myMusicSettingsEN;
            myChooseSong = myChooseSongEN;

            myWhatUDo = myWhatUDoEN;
            myOffensive = myOffensiveEN;
            myMethodViolence = myMethodViolenceEN;
            myAttack = myAttackEN;
            myChooseAttack = myChooseAttackEN;
            mySlash = mySlashEN;
            mySweep = mySweepEN;
            mySlap = mySlapEN;
            mySwingSword = mySwingSwordEN;
            mySpells = mySpellsEN;
            myChooseSpell = myChooseSpellEN;
            myFireBolt = myFireBoltSE;
            myCastFireBolt = myCastFireBoltEN;
            myFlamestrike = myFlamestrikeEN;
            myCastFlamestrike = myCastFlamestrikeEN;
            myFireball = myFireballEN;
            myCastFireBall = myCastFireBallEN;
            myBurnSkin = myBurnSkinEN;
            myTakeDamage1 = myTakeDamage1EN;
            myTakeDamage2 = myTakeDamage2EN;
            myInsufficientMana = myInsufficientManaEN;
            myChooseEnemy = myChooseEnemyEN;
            myArcher = myArcherEN;
            mySkeleton = mySkeletonEN;
            myHealth = myHealthEN;
            myHealthSmall = myHealthSmallEN;
            myArmour = myArmourEN;
            myEnemyDefeated = myEnemyDefeatedEN;
            myExperience = myExperienceEN;
            myEnemyStunned = myEnemyStunnedEN;
            myEnemyNoStunned = myEnemyNotStunnedEN;
            myMissedEnemy = myMissedEnemyEN;

            myEnemyCannotAttack = myEnemyCannotAttackEN;
            myEnemySwingSword = myEnemySwingSwordEN;
            myEnemyDrawsBow = myEnemyDrawsBowEN;
            myBossWeapon = myBossWeaponEN;
            myEvadedStrike = myEvadedStrikeEN;

            myDefensive = myDefensiveEN;
            myChooseDefence = myChooseDefenceEN;
            myRaiseShield = myRaiseShieldEN;
            myRaiseDefence1 = myRaiseDefence1EN;
            myRaiseDefence2 = myRaiseDefence2EN;
            myHealingTouch = myHealingTouchEN;
            myBeginTouch = myBeginTouchEN;
            myMagicallyHeal = myMagicallyHealEN;
            mySuperStun = mySuperStunEN;
            myThrowPebbles1 = myThrowPebbles1EN;
            myThrowPebbles2 = myThrowPebbles2EN;

            myUseItem = myUseItemEN;
            myFlee = myFleeEN;
            myHasFled = myHasFledEN;
            myBossFlee = myBossFleeEN;

            myAbstain = myAbstainEN;
            myNoAttack1 = myNoAttack1EN;
            myNoAttack2 = myNoAttack2EN;

            myAllDefeated = myAllDefeatedEN;
            myBossDefeated = myBossDefeatedEN;

            myFoundLoot = myFoundLootEN;
            myPickUp = myPickUpEN;
            myPickUpEquip = myPickUpEquipEN;
            myDiscard = myDiscardEN;
            myLootAdded = myLootAddedEN;

            myFoundNoLoot = myFoundNoLootEN;
            myFoundChest = myFoundChestEN;
            myFoundChests = myFoundChestsEN;
            myFoundAnotherChest = myFoundAnotherChestEN;

            myContinueAdventure = myContinueAdventureEN;
            myThereAreDoors1 = myThereAreDoors1EN;
            myThereAreDoors2 = myThereAreDoors2EN;
            myChooseDoor = myChooseDoorEN;
            myExitDungeon = myExitDungeonEN;
            myExitingDungeon = myExitingDungeonEN;
            myViewMap = myViewMapEN;
            myInitialRoom = myInitialRoomEN;
            myCurrentRoom = myCurrentRoomEN;
            myRoom = myRoomEN;
        }
    }
}
