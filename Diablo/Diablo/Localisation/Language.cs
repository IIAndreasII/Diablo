namespace Diablo.Localisation
{
    public static class Language
    {
        #region Swedish

        private static string
            myToggleMusicSE = "Sätt musik",
            myOnSE = "På",
            myOffSE = "Av",
            myEnteringDungeonSE = "Du går ner i den närmaste hålan",
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
            myTakeDamage2SE = " skada!",
            myInsufficientManaSE = "Otillräckligt med mana",
            myChooseEnemySE = "Välj en fiende att attackera:",
            myArcherSE = "Bågskytt",
            mySkeletonSE = "Skelett",
            myHealthSE = "Hälsa",
            myHealthSmallSE = "hälsa",
            myArmourSE = "Rustning",
            myEnemyDefeatedSE = "Fiende besegrad!",
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
            myRoomSE = "Rum",

            myEffectAppliedSE = "Effekt applicerad!",
            myAvailableScrollsSE = "Tillgängliga rullar:",
            myCloseInventorySE = "Stäng inventarie",
            myTempStrengthSE = "temporär styrka!",
            myTempArmourSE = "temporär rustning!",
            myTempHealthSE = "temporär hälsa!",
            myDrinkHPPotionSE = "Du dricker en hälsodryck",
            myDrinkManaPotionSE = "Du dricker en manadryck",
            myMenuSE = "Meny",
            myEnterRoomSE = "Du går in i rummet och tittar dig omkring",
            myDealDamage1SE = "Du gör ",
            myDealDamage2SE = " skada!",
            mySpottedOneSE = "Du ser en fiende!",
            mySpottedMultipleSE = "Du ser flera fiender!",
            mySpottedBossSE = "Du får syn på ",
            mySpottedNoneSE = "Inga fiender är närvarande",

            myScrollDecayedSE = "Rull-effekt gick ut!";

        #endregion Swedish

        #region English

        private static string
            myScrollDecayedEN = "Scroll-effect wore off!",
            myEnteringDungeonEN = "You delve into the nearest dungeon",
            myToggleMusicEN = "Toggle music",
            myOnEN = "On",
            myOffEN = "Off",

            myEffectAppliedEN = "Effect applied!",
            myAvailableScrollsEN = "Available scrolls:",
            myCloseInventoryEN = "Close inventory",
            myTempStrengthEN = "temporary strength!",
            myTempArmourEN = "temporary armour!",
            myTempHealthEN = "temporary health!",
            myDrinkHPPotionEN = "You drink a healthpotion",
            myDrinkManaPotionEN = "You drink a manapotion",
            myMenuEN = "Menu",
            myEnterRoomEN = "You enter the room and look around",
            myDealDamage1EN = "You deal ",
            myDealDamage2EN = " damage!",
            mySpottedOneEN = "You have spotted an enemy!",
            mySpottedMultipleEN = "You have spotted multiple enemies!",
            mySpottedBossEN = "You have spotted ",
            mySpottedNoneEN = "There are no enemies present",

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

        #region Get

        public static string GetToggleMusic() => myToggleMusic;

        public static string GetOn() => myOn;

        public static string GetOff() => myOff;

        public static string GetPlay() => myPlay;

        public static string GetExit() => myExit;

        public static string GetBack() => myBack;

        public static string GetInsufficientFunds() => myInsufficientFunds;

        public static string GetLevelUp() => myLevelUp;

        public static string GetMaxHealth() => myMaxHealth;

        public static string GetMaxMana() => myMaxMana;

        public static string GetMaxStamina() => myMaxStamina;

        public static string GetStrength() => myStrength;

        public static string GetAgility() => myAgility;

        public static string GetWisdom() => myWisdom;

        public static string GetIntelligence() => myIntelligence;

        public static string GetLuck() => myLuck;

        public static string GetSpellDamage() => mySpellDmg;

        public static string GetPossibleActions() => myPossibleActions;

        public static string GetEnterDungeon() => myEnterDungeon;

        public static string GetOpenInventory() => myOpenInventory;

        public static string GetInventory() => myInventory;

        public static string GetGold() => myGold;

        public static string GetHPPotions() => myHPPotions;

        public static string GetManaPotions() => myManaPotions;

        public static string GetTrinkets() => myTrinkets;

        public static string GetScrolls() => myScrolls;

        public static string GetEquipped() => myEquipped;

        public static string GetApply() => myApply;

        public static string GetEquip() => myEquip;

        public static string GetThrowAway() => myThrowAway;

        public static string GetRest() => myRest;

        public static string GetLightFire() => myLightFire;

        public static string GetRegain() => myRegain;

        public static string GetRegainStamina() => myRegainStamina;

        public static string GetLongRest() => myLongRest;

        public static string GetPitchTent() => myPitchTent;

        public static string GetFullRecovery() => myFullRecovery;

        public static string GetCommitSuicide() => myCommitSuicide;

        public static string GetMusicSettings() => myMusicSettings;

        public static string GetChooseSong() => myChooseSong;

        public static string GetWhatUDo() => myWhatUDo;

        public static string GetOffensive() => myOffensive;

        public static string GetMethodViolence() => myMethodViolence;

        public static string GetAttack() => myAttack;

        public static string GetChooseAttack() => myChooseAttack;

        public static string GetSlash() => mySlash;

        public static string GetSweep() => mySweep;

        public static string GetSlap() => mySlap;

        public static string GetSwingSword() => mySwingSword;

        public static string GetSpells() => mySpells;

        public static string GetChooseSpell() => myChooseSpell;

        public static string GetFirebolt() => myFireBolt;

        public static string GetFlamestrike() => myFlamestrike;

        public static string GetFireball() => myFireball;

        public static string GetCastFirebolt() => myCastFireBolt;

        public static string GetCastFlamestrike() => myCastFlamestrike;

        public static string GetCastFireball() => myCastFireBall;

        public static string GetBurnSkin() => myBurnSkin;

        public static string GetTakeDamagePt1() => myTakeDamage1;

        public static string GetTakeDamagePt2() => myTakeDamage2;

        public static string GetInsufficientMana() => myInsufficientMana;

        public static string GetChooseEnemy() => myChooseEnemy;

        public static string GetArcher() => myArcher;

        public static string GetSkeleton() => mySkeleton;

        public static string GetHealth() => myHealth;

        public static string GetHealthLowerCase() => myHealthSmall;

        public static string GetArmour() => myArmour;

        public static string GetEnemyDefeated() => myEnemyDefeated;

        public static string GetExperience() => myExperience;

        public static string GetEnemyStunned() => myEnemyStunned;

        public static string GetEnemyNoStunned() => myEnemyNoStunned;

        public static string GetMissedEnemy() => myMissedEnemy;

        public static string GetEnemyCannotAttack() => myEnemyCannotAttack;

        public static string GetEnemySwingSword() => myEnemySwingSword;

        public static string GetEnemyDrawsBow() => myEnemyDrawsBow;

        public static string GetBossWeapon() => myBossWeapon;

        public static string GetEvadedStrike() => myEvadedStrike;

        public static string GetDefensive() => myDefensive;

        public static string GetChooseDefence() => myChooseDefence;

        public static string GetRaiseShield() => myRaiseShield;

        public static string GetRaiseDefencePt1() => myRaiseDefence1;

        public static string GetRaiseDefencePt2() => myRaiseDefence2;

        public static string GetHealingTouch() => myHealingTouch;

        public static string GetBeginTouch() => myBeginTouch;

        public static string GetMagicallyHeal() => myMagicallyHeal;

        public static string GetSuperStun() => mySuperStun;

        public static string GetThrowPebblesPt1() => myThrowPebbles1;

        public static string GetThrowPebblesPt2() => myThrowPebbles2;

        public static string GetUseItem() => myUseItem;

        public static string GetFlee() => myFlee;

        public static string GetHasFled() => myHasFled;

        public static string GetBossFlee() => myBossFlee;

        public static string GetAbstain() => myAbstain;

        public static string GetNoAttackPt1() => myNoAttack1;

        public static string GetNoAttackPt2() => myNoAttack2;

        public static string GetAllDefeated() => myAllDefeated;

        public static string GetBossDefeated() => myBossDefeated;

        public static string GetFoundLoot() => myFoundLoot;

        public static string GetPickup() => myPickUp;

        public static string GetPickUpEquip() => myPickUpEquip;

        public static string GetDiscard() => myDiscard;

        public static string GetLootAdded() => myLootAdded;

        public static string GetFoundNoLoot() => myFoundNoLoot;

        public static string GetFoundChest() => myFoundChest;

        public static string GetFoundChests() => myFoundChests;

        public static string GetFoundAnotherChest() => myFoundAnotherChest;

        public static string GetContinueAdventure() => myContinueAdventure;

        public static string GetThereAreDoorsPt1() => myThereAreDoors1;

        public static string GetThereAreDoorsPt2() => myThereAreDoors2;

        public static string GetChooseDoor() => myChooseDoor;

        public static string GetExitDungeon() => myExitDungeon;

        public static string GetExitingDungeon() => myExitingDungeon;

        public static string GetViewMap() => myViewMap;

        public static string GetInitialRoom() => myInitialRoom;

        public static string GetCurrentRoom() => myCurrentRoom;

        public static string GetRoom() => myRoom;

        public static string GetEffectApplied() => myEffectApplied;

        public static string GetAvailableScrolls() => myAvailableScrolls;

        public static string GetCloseInventory() => myCloseInventory;

        public static string GetTempStrength() => myTempStrength;

        public static string GetTempArmour() => myTempArmour;

        public static string GetTempHealth() => myTempHealth;

        public static string GetDrinkHPPotion() => myDrinkHPPotion;

        public static string GetDrinkManaPotion() => myDrinkManaPotion;

        public static string GetMenu() => myMenu;

        public static string GetEnterRoom() => myEnterRoom;

        public static string GetDealDamagePt1() => myDealDamage1;

        public static string GetDealDamagePt2() => myDealDamage2;

        public static string GetSpottedOne() => mySpottedOne;

        public static string GetSpottedMultiple() => mySpottedMultiple;

        public static string GetSpottedBoss() => mySpottedBoss;

        public static string GetSpottedNone() => mySpottedNone;

        public static string GetEnteringDungeon() => myEnteringDungeon;

        #endregion Get

        #region Active Language

        private static string
            myScrollDecayed,
            myToggleMusic,
            myOn,
            myOff,
            myEffectApplied,
            myAvailableScrolls,
            myCloseInventory,
            myTempStrength,
            myTempArmour,
            myTempHealth,
            myDrinkHPPotion,
            myDrinkManaPotion,
            myMenu,
            myEnterRoom,
            myDealDamage1,
            myDealDamage2,
            mySpottedOne,
            mySpottedMultiple,
            mySpottedBoss,
            mySpottedNone,

            myPlay,
            myExit,
            myBack,
            myInsufficientFunds,

            myLevelUp,
            myMaxHealth,
            myMaxMana,
            myMaxStamina,
            myStrength,
            myAgility,
            myWisdom,
            myIntelligence,
            myLuck,
            mySpellDmg,

            myPossibleActions,
            myEnterDungeon,
            myEnteringDungeon,

            myOpenInventory,
            myInventory,
            myGold,
            myHPPotions,
            myManaPotions,
            myTrinkets,
            myScrolls,
            myEquipped,
            myApply,
            myEquip,
            myThrowAway,

            myRest,
            myLightFire,
            myRegain,
            myRegainStamina,

            myLongRest,
            myPitchTent,
            myFullRecovery,

            myCommitSuicide,

            myMusicSettings,
            myChooseSong,

            myWhatUDo,
            myOffensive,
            myMethodViolence,
            myAttack,
            myChooseAttack,
            mySlash,
            mySweep,
            mySlap,
            mySwingSword,
            mySpells,
            myChooseSpell,
            myFireBolt,
            myCastFireBolt,
            myFlamestrike,
            myCastFlamestrike,
            myFireball,
            myCastFireBall,
            myBurnSkin,
            myTakeDamage1,
            myTakeDamage2,
            myInsufficientMana,
            myChooseEnemy,
            myArcher,
            mySkeleton,
            myHealth,
            myHealthSmall,
            myArmour,
            myEnemyDefeated,
            myExperience,
            myEnemyStunned,
            myEnemyNoStunned,
            myMissedEnemy,

            myEnemyCannotAttack,
            myEnemySwingSword,
            myEnemyDrawsBow,
            myBossWeapon,
            myEvadedStrike,

            myDefensive,
            myChooseDefence,
            myRaiseShield,
            myRaiseDefence1,
            myRaiseDefence2,
            myHealingTouch,
            myBeginTouch,
            myMagicallyHeal,

            mySuperStun,
            myThrowPebbles1,
            myThrowPebbles2,

            myUseItem,
            myFlee,
            myHasFled,
            myBossFlee,

            myAbstain,
            myNoAttack1,
            myNoAttack2,

            myAllDefeated,
            myBossDefeated,

            myFoundLoot,
            myPickUp,
            myPickUpEquip,
            myDiscard,
            myLootAdded,

            myFoundNoLoot,
            myFoundChest,
            myFoundChests,
            myFoundAnotherChest,

            myContinueAdventure,
            myThereAreDoors1,
            myThereAreDoors2,
            myChooseDoor,
            myExitDungeon,
            myExitingDungeon,
            myViewMap,
            myInitialRoom,
            myCurrentRoom,
            myRoom;

        #endregion Active Language

        /// <summary>
        /// Initializes values
        /// </summary>
        public static void Init() => Swedish();

        /// <summary>
        /// Sets the language to Swedish
        /// </summary>
        public static void Swedish()
        {
            myScrollDecayed = myScrollDecayedSE;
            myToggleMusic = myToggleMusicSE;
            myOn = myOnSE;
            myOff = myOffSE;
            myEffectApplied = myEffectAppliedSE;
            myAvailableScrolls = myAvailableScrollsSE;
            myCloseInventory = myCloseInventorySE;
            myTempStrength = myTempStrengthSE;
            myTempArmour = myTempArmourSE;
            myTempHealth = myTempHealthSE;
            myDrinkHPPotion = myDrinkHPPotionSE;
            myDrinkManaPotion = myDrinkManaPotionSE;
            myMenu = myMenuSE;
            myEnterRoom = myEnterRoomSE;
            myDealDamage1 = myDealDamage1SE;
            myDealDamage2 = myDealDamage2SE;
            mySpottedOne = mySpottedOneSE;
            mySpottedMultiple = mySpottedMultipleSE;
            mySpottedBoss = mySpottedBossSE;
            mySpottedNone = mySpottedNoneSE;

            myEnteringDungeon = myEnteringDungeonSE;

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
            myIntelligence = myIntelligenceSE;
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
            myScrollDecayed = myScrollDecayedEN;
            myToggleMusic = myToggleMusicEN;
            myOn = myOnEN;
            myOff = myOffEN;

            myEffectApplied = myEffectAppliedEN;
            myAvailableScrolls = myAvailableScrollsEN;
            myCloseInventory = myCloseInventoryEN;
            myTempStrength = myTempStrengthEN;
            myTempArmour = myTempArmourEN;
            myTempHealth = myTempHealthEN;
            myDrinkHPPotion = myDrinkHPPotionEN;
            myDrinkManaPotion = myDrinkManaPotionEN;
            myMenu = myMenuEN;
            myEnterRoom = myEnterRoomEN;
            myDealDamage1 = myDealDamage1EN;
            myDealDamage2 = myDealDamage2EN;
            mySpottedOne = mySpottedOneEN;
            mySpottedMultiple = mySpottedMultipleEN;
            mySpottedBoss = mySpottedBossEN;
            mySpottedNone = mySpottedNoneEN;

            myEnteringDungeon = myEnteringDungeonEN;

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
            myIntelligence = myIntelligenceEN;
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