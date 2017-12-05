namespace Diablo.Localisation
{
    public static class Language
    {
        private static bool
            myIsInSwedish;

        #region Active Language

        private static string

            myAbstain,
            myAgility,
            myAllDefeated,
            myApply,
            myApproachChest,
            myArcher,
            myArmour,
            myAttack,
            myAvailableScrolls,

            myBack,
            myBasicness,
            myBeginTouch,
            myBootsOf,
            myBossDefeated,
            myBossFlee,
            myBossWeapon,
            myBurnSkin,

            myCastFlamestrike,
            myCastFireBall,
            myCastFireBolt,
            myChestOf,
            myChooseAttack,
            myChooseDefence,
            myChooseDoor,
            myChooseEnemy,
            myChooseLanguage,
            myChooseSong,
            myChooseSpell,
            myCloseInventory,
            myCommitSuicide,
            myContinueAdventure,
            myCurrentLanguage,
            myCurrentRoom,

            myDealDamage1,
            myDealDamage2,
            myDecapitate,
            myDefensive,
            myDiscard,
            myDrinkHPPotion,
            myDrinkManaPotion,

            myEffectApplied,
            myEnemyCannotAttack,
            myEnemyDefeated,
            myEnemyDrawsBow,
            myEnemyNoStunned,
            myEnemyStunned,
            myEnemySwingSword,
            myEnglish,
            myEnterRoom,
            myEnterDungeon,
            myEnteringDungeon,
            myEquip,
            myEquipped,
            myEscapeFangs,
            myEvadedStrike,
            myExit,
            myExitDungeon,
            myExitingDungeon,
            myExperience,

            myFireball,
            myFireBolt,
            myFlamestrike,
            myFlee,
            myFoundAnotherChest,
            myFoundChest,
            myFoundChests,
            myFoundLoot,
            myFoundNoLoot,
            myFullRecovery,

            myGold,

            myHasFled,
            myHealth,
            myHealthSmall,
            myHealingTouch,
            myHelmetOf,
            myHPPotions,

            myInitialRoom,
            myInsufficientFunds,
            myInsufficientMana,
            myIntelligence,
            myInventory,
            myItIsLocked,

            myLanguageSettings,
            myLevelUp,
            myLightFire,
            myLongRest,
            myLootAdded,
            myLuck,

            myMagicallyHeal,
            myManaPotions,
            myMaxHealth,
            myMaxMana,
            myMaxStamina,
            myMenu,
            myMethodViolence,
            myMissedEnemy,
            myMusicSettings,

            myNo,
            myNoAttack1,
            myNoAttack2,
            myNoOrdinary1,
            myNoOrdinary2,

            myOff,
            myOffensive,
            myOn,
            myOpenInventory,

            myPeekLoot,
            myPeekNoLoot,
            myPickUp,
            myPickUpEquip,
            myPitchTent,
            myPlay,
            myPossibleActions,

            myRegain,
            myRegainStamina,
            myRaiseDefence1,
            myRaiseDefence2,
            myRaiseShield,
            myRest,
            myRoom,

            myScrollDecayed,
            myScrollOf,
            myScrolls,
            myShieldOf,
            mySkeleton,
            mySlap,
            mySlash,
            mySwedish,
            mySpellDmg,
            mySpells,
            mySpottedBoss,
            mySpottedMultiple,
            mySpottedNone,
            mySpottedOne,
            myStamina,
            myStrength,
            mySuperStun,
            mySweep,
            mySwingSword,
            mySwordOf,

            myTakeDamage1,
            myTakeDamage2,
            myTempStrength,
            myTempArmour,
            myTempHealth,
            myThereAreDoors1,
            myThereAreDoors2,
            myToggleMusic,
            myTrousersOf,
            myThrowAway,
            myThrowPebbles1,
            myThrowPebbles2,
            myTrinketOf,
            myTrinkets,

            myUnlockWish,
            myUseItem,

            myViewMap,

            myWhatUDo,
            myWisdom,

            myYes;

        private static string[]
            mySuffixes;

        #endregion Active Language

        #region Swedish

        private static string

            myAbstainSE = "Avstå",
            myAgilitySE = "Smidighet",
            myAllDefeatedSE = "Alla fiender är besegrade!",
            myApproachChestSE = "Du närmar dig kistan och inspekterar den",
            myApplySE = "Applicera",
            myArcherSE = "Bågskytt",
            myArmourSE = "Rustning",
            myAttackSE = "Attacker",
            myAvailableScrollsSE = "Tillgängliga rullar:",

            myBackSE = "Tillbaks",
            myBasicnessSE = "Ordinariehet",
            myBeginTouchSE = "Du börjar röra vid dig själv...",
            myBootsOfSE = "Stövlar av",
            myBossDefeatedSE = "är besegrad",
            myBossFleeSE = "Du kan inte springa från en boss!",
            myBossWeaponSE = " använder sitt vapen!",
            myBurnSkinSE = "Den stora smällen bränner ditt skinn!",

            myCastFireBallSE = "Du använder eldklot!",
            myCastFireBoltSE = "Du använder eldvigg!",
            myCastFlamestrikeSE = "Du använder flammsmisk!",
            myChestOfSE = "Bröstplåt av",
            myChooseAttackSE = "Välj attack:",
            myChooseDefenceSE = "Välj försvar:",
            myChooseDoorSE = "Vilken går du in i?",
            myChooseLanguageSE = "Välj språk:",
            myChooseSongSE = "Välj låt:",
            myChooseSpellSE = "Välj trollformel:",
            myChooseEnemySE = "Välj en fiende att attackera:",
            myCloseInventorySE = "Stäng inventarie",
            myCommitSuicideSE = "Begå självmord",
            myContinueAdventureSE = "Fortsätt äventyr",
            myCurrentLanguageSE = "Nuvarande språk: ",
            myCurrentRoomSE = "Nuvarande rum",

            myDealDamage1SE = "Du gör ",
            myDealDamage2SE = " skada!",
            myDecapitateSE = "Kist-härmapan biter dig och sliter av ditt huvud!",
            myDefensiveSE = "Defensivt",
            myDiscardSE = "Släng allt",
            myDrinkHPPotionSE = "Du dricker en hälsodryck",
            myDrinkManaPotionSE = "Du dricker en manadryck",

            myEffectAppliedSE = "Effekt applicerad!",
            myEnglishSE = "Engelska",
            myEnemyCannotAttackSE = "Fienden är knockad och kan inte attackera",
            myEnemyDefeatedSE = "Fiende besegrad!",
            myEnemyDrawsBowSE = "Fienden spänner sin pilbåge!",
            myEnterDungeonSE = "Gå in i fängelsehåla",
            myEnemyNotStunnedSE = "Fienden kan inte bli knockad!",
            myEnemyStunnedSE = "Fiende knockad!",
            myEnemySwingSwordSE = "Fienden svingar sitt svärd!",
            myEnteringDungeonSE = "Du går ner i den närmaste hålan",
            myEnterRoomSE = "Du går in i rummet och tittar dig omkring",
            myEquippedSE = "Använd:",
            myEquipSE = "Använd",
            myEscapeFangsSE = "Du lyckades fly från dess tänder!",
            myEvadedStrikeSE = "Du undvek smällen!",
            myExitSE = "Avsluta",
            myExitDungeonSE = "Lämna fängelsehåla",
            myExitingDungeonSE = "Säkert, lämnar du fängelsehålan",
            myExperienceSE = "erfarenhet!",

            myFireBoltSE = "Eldvigg (träffar vald fiende, 20mp)",
            myFireballSE = "Eldklot (kanske t.o.m dödar dig, 120mp)",
            myFlamestrikeSE = "Flammsmisk (träffar tre fiender, 60 mp)",
            myFleeSE = "Fly",
            myFoundAnotherChestSE = "Du hittade ytterligare en kista!",
            myFoundChestSE = "Du hittade en kista!",
            myFoundChestsSE = "Du hittade några kistor!",
            myFoundLootSE = "Du har hittat lite krimskrams!",
            myFoundNoLootSE = "Du hittade inget krimskrams i rummet",
            myFullRecoverySE = "Fullständig återhämtning!",

            myGoldSE = "Guld",

            myHasFledSE = "Du flydde striden, jävla mes...",
            myHealthSE = "Hälsa",
            myHealthSmallSE = "hälsa",
            myHealingTouchSE = "Helande beröring",
            myHelmetOfSE = "Hjälm av",
            myHPPotionsSE = "Hälsodrycker",

            myInitialRoomSE = "Utgångsrum och utgång",
            myInsufficientFundsSE = "Otillräckligt med guld!",
            myInsufficientManaSE = "Otillräckligt med mana",
            myIntelligenceSE = "Intelligens",
            myInventorySE = "Inventarie",
            myItIsLockedSE = "Den är låst...",

            myLanguageSettingsSE = "Språkinställningar",
            myLevelUpSE = "Nivå ökad!",
            myLightFireSE = "Du tänder en brasa och vilar",
            myLongRestSE = "Vila länge",
            myLootAddedSE = "Krimskrams tillagt i inventariet!",
            myLuckSE = "Tur",

            myMagicallyHealSE = "Det helar dig på något magiskt sätt(?)",
            myManaPotionsSE = "Manadrycker",
            myMaxHealthSE = "Max hälsa",
            myMaxManaSE = "Max mana",
            myMaxStaminaSE = "Max kondition",
            myMenuSE = "Meny",
            myMethodViolenceSE = "Välj metod av våldsamhet:",
            myMissedEnemySE = "Du missade fienden!",
            myMusicSettingsSE = "Musik-inställningar",

            myNoSE = "Nej",
            myNoAttack1SE = "Du vill inte attackera och sänker",
            myNoAttack2SE = "därför dina vapen",
            myNoOrdinary1SE = "Medan du provar att öppna kistan märker du",
            myNoOrdinary2SE = "att den andas. Detta är inte en vanlig kista",

            myOnSE = "På",
            myOffSE = "Av",
            myOffensiveSE = "Offensivt",
            myOpenInventorySE = "Öppna inventarie",

            myPeekLootSE = "Du tittar ner i kistan, det finns krimskrams!",
            myPeekNoLootSE = "Du tittar ner i kistan, det finns inget krimskrams!",
            myPickUpSE = "Plocka upp",
            myPickUpEquipSE = "Plocka upp och använd bästa",
            myPitchTentSE = "Du sätter upp ett tält och tänder en brasa",
            myPlaySE = "Spela",
            myPossibleActionsSE = "Möjliga val:",

            myRegainSE = "Du får åter",
            myRegainStaminaSE = "kondition",
            myRaiseShieldSE = "Höj skölden",
            myRaiseDefence1SE = "Du höjer din sköld och",
            myRaiseDefence2SE = "förbereder för ett slag!",
            myRestSE = "Vila",
            myRoomSE = "Rum",

            myScrollDecayedSE = "Rull-effekt gick ut!",
            myScrollOfSE = "Rulle av",
            myScrollsSE = "Rullar",
            myShieldOfSE = "Sköld av",
            mySlapSE = "Örfil (knockar 1 fiende)",
            mySlashSE = "Hugg",
            mySkeletonSE = "Skelett",
            mySpellDmgSE = "Trollformelsskada",
            mySpellsSE = "Trollformler",
            mySpottedOneSE = "Du ser en fiende!",
            mySpottedMultipleSE = "Du ser flera fiender!",
            mySpottedBossSE = "Du får syn på ",
            mySpottedNoneSE = "Inga fiender är närvarande",
            myStaminaSE = "Kondition",
            myStrengthSE = "Styrka",
            mySuperStunSE = "Super örfil (knockar alla fiender)",
            mySwedishSE = "Svenska",
            mySweepSE = "Svep (träffar 2 fiender)",
            mySwingSwordSE = "Du svingar ditt svärd",
            mySwordOfSE = "Svärd av",

            myTakeDamage1SE = "Du tar ",
            myTakeDamage2SE = " skada!",
            myTempArmourSE = "temporär rustning!",
            myTempHealthSE = "temporär hälsa!",
            myTempStrengthSE = "temporär styrka!",
            myThereAreDoors1SE = "Det finns ",
            myThereAreDoors2SE = " dörrar i det här rummet",
            myThrowAwaySE = "Kasta",
            myThrowPebbles1SE = "Du kastar lite småsten och på något",
            myThrowPebbles2SE = "sätt knockar det alla fiender",
            myToggleMusicSE = "Sätt musik",
            myTrinketOfSE = "Pryl av",
            myTrinketsSE = "Prylar",
            myTrousersOfSE = "Byxor av",

            myUnlockWishSE = "Vill du öppna den?",
            myUseItemSE = "Använd föremål",

            myViewMapSE = "Titta på kartan",

            myWhatUDoSE = "Vad gör du?",
            myWisdomSE = "Visdom",

            myYesSE = "Ja";

        #endregion Swedish

        #region English

        private static string

            myAbstainEN = "Abstain",
            myAgilityEN = "Agility",
            myAllDefeatedEN = "All enemies defeated!",
            myApplyEN = "Apply",
            myApproachChestEN = "You approach the chest and inspect it",
            myArcherEN = "Archer",
            myArmourEN = "Armour",
            myAttackEN = "Attacks",
            myAvailableScrollsEN = "Available scrolls:",

            myBackEN = "Back",
            myBasicnessEN = "Basicness",
            myBeginTouchEN = "You begin touching yourself...",
            myBootsOfEN = "Boots of",
            myBossDefeatedEN = " has been defeated!",
            myBossFleeEN = "You cannot flee from a bossfight!",
            myBossWeaponEN = " uses his weapon!",
            myBurnSkinEN = "The massive blast burns your skin!",

            myCastFireBallEN = "You cast fireball!",
            myCastFireBoltEN = "You cast firebolt!",
            myCastFlamestrikeEN = "You cast flamestrike!",
            myChestOfEN = "Chestplate of",
            myChooseAttackEN = "Choose attack:",
            myChooseDefenceEN = "Choose defence:",
            myChooseDoorEN = "Which one do you enter?",
            myChooseEnemyEN = "Choose enemy to attack:",
            myChooseLanguageEN = "Choose language:",
            myChooseSongEN = "Choose song:",
            myChooseSpellEN = "Choose spell:",
            myCloseInventoryEN = "Close inventory",
            myCommitSuicideEN = "Commit suicide",
            myContinueAdventureEN = "Continue adventure",
            myCurrentLanguageEN = "Current language: ",
            myCurrentRoomEN = "Current room",

            myDealDamage1EN = "You deal ",
            myDealDamage2EN = " damage!",
            myDecapitateEN = "The chest-mimic bites you and rips your head off!",
            myDefensiveEN = "Defensive",
            myDiscardEN = "Discard all",
            myDrinkHPPotionEN = "You drink a healthpotion",
            myDrinkManaPotionEN = "You drink a manapotion",

            myEffectAppliedEN = "Effect applied!",
            myEnemyDefeatedEN = "Enemy defeated!",
            myEnemyStunnedEN = "Enemy stunned!",
            myEnemyNotStunnedEN = "Enemy cannot be stunned!",
            myEnemyCannotAttackEN = "The enemy is stunned and cannot attack",
            myEnemySwingSwordEN = "The enemy swings his sword!",
            myEnemyDrawsBowEN = "The enemy draws his bow!",
            myEnglishEN = "English",
            myEnterDungeonEN = "Enter dungeon",
            myEnteringDungeonEN = "You delve into the nearest dungeon",
            myEnterRoomEN = "You enter the room and look around",
            myEquipEN = "Equip",
            myEquippedEN = "Equipped:",
            myEscapeFangsEN = "You managed to escape its fangs!",
            myEvadedStrikeEN = "You evaded the strike!",
            myExitEN = "Exit",
            myExitDungeonEN = "Exit dungeon",
            myExitingDungeonEN = "Safely, you exit the dungeon",
            myExperienceEN = " experience!",

            myFireballEN = "Fireball (might even kill you, 120mp)",
            myFireBoltEN = "Firebolt (hits chosen enemy, 20mp)",
            myFlamestrikeEN = "Flamestrike (hits 3 random enemies, 60 mp)",
            myFleeEN = "Flee",
            myFoundAnotherChestEN = "You found another chest!",
            myFoundChestEN = "You have found a chest!",
            myFoundChestsEN = "You have found some chests!",
            myFoundLootEN = "You have found some loot!",
            myFoundNoLootEN = "You found no loot in the room",
            myFullRecoveryEN = "Full recovery",

            myGoldEN = "Gold",

            myHasFledEN = "You have fled the battle, coward...",
            myHealthEN = "Health",
            myHealthSmallEN = "health",
            myHealingTouchEN = "Healing touch",
            myHelmetOfEN = "Helmet of",
            myHPPotionsEN = "Healthpotions",

            myInitialRoomEN = "Initial room and exit",
            myInsufficientFundsEN = "Insufficient gold!",
            myInsufficientManaEN = "Insufficient mana!",
            myIntelligenceEN = "Intelligence",
            myInventoryEN = "Inventory",
            myItIsLockedEN = "It is locked...",

            myLanguageSettingsEN = "Languagesettings",
            myLevelUpEN = "Level up!",
            myLightFireEN = "You light a fire and rest",
            myLongRestEN = "Long rest",
            myLootAddedEN = "Loot added to inventory!",
            myLuckEN = "Luck",

            myMagicallyHealEN = "It magically heals you(?)",
            myManaPotionsEN = "Manapotions",
            myMaxHealthEN = "Max health",
            myMaxManaEN = "Max mana",
            myMaxStaminaEN = "Max stamina",
            myMenuEN = "Menu",
            myMethodViolenceEN = "Choose method of violence:",
            myMissedEnemyEN = "You missed the enemy!",
            myMusicSettingsEN = "Music settings",

            myNoEN = "No",
            myNoAttack1EN = "You do not wish to attack,",
            myNoAttack2EN = "thus lowering your arms",
            myNoOrdinary1EN = "As you try to open the chest, you notice",
            myNoOrdinary2EN = "that it is breathing. This is no ordinary chest",

            myOffEN = "Off",
            myOffensiveEN = "Offensive",
            myOnEN = "On",
            myOpenInventoryEN = "Open inventroy",

            myPeekLootEN = "You peek inside the chest, there is loot!",
            myPeekNoLootEN = "You peek inside the chest, there is no loot",
            myPlayEN = "Play",
            myPickUpEN = "Pick up all",
            myPickUpEquipEN = "Pick up all & equip best",
            myPitchTentEN = "You pitch a tent and light a fire",
            myPossibleActionsEN = "Possible actions:",

            myRegainEN = "You re-gain",
            myRaiseDefence1EN = "You raise your shield and",
            myRaiseDefence2EN = "brace for a strike!",
            myRaiseShieldEN = "Raise shield",
            myRegainStaminaEN = "stamina",
            myRestEN = "Rest",
            myRoomEN = "Room",

            myScrollDecayedEN = "Scroll-effect wore off!",
            myScrollOfEN = "Scroll of",
            myScrollsEN = "Scrolls",
            myShieldOfEN = "Shield of",
            mySkeletonEN = "Skeleton",
            mySlapEN = "Slap (stuns chosen enemy)",
            mySlashEN = "Slash",
            mySpellDmgEN = "Spelldamage",
            mySpottedBossEN = "You have spotted ",
            mySpottedMultipleEN = "You have spotted multiple enemies!",
            mySpottedNoneEN = "There are no enemies present",
            mySpottedOneEN = "You have spotted an enemy!",
            mySpellsEN = "Spells",
            myStaminaEN = "Stamina",
            myStrengthEN = "Strength",
            mySuperStunEN = "Super stun (stuns all enemies)",
            mySwedishEN = "Swedish",
            mySweepEN = "Sweep (hits 2 random enemies)",
            mySwingSwordEN = "Du swing your sword!",
            mySwordOfEN = "Sword of",

            myTakeDamage1EN = "You take ",
            myTakeDamage2EN = " damage!",
            myTempArmourEN = "temporary armour!",
            myTempHealthEN = "temporary health!",
            myTempStrengthEN = "temporary strength!",
            myThereAreDoors1EN = "There are/is ",
            myThereAreDoors2EN = " doors in this room",
            myThrowAwayEN = "Throw away",
            myThrowPebbles1EN = "You throw some pebbles and somehow",
            myThrowPebbles2EN = "it stuns every enemy in sight",
            myTrinketOfEN = "Trinket of",
            myTrinketsEN = "Trinkets",
            myTrousersOfEN = "Trousers of",
            myToggleMusicEN = "Toggle music",

            myUnlockWishEN = "Do wish to unlock it?",
            myUseItemEN = "Use item",

            myViewMapEN = "View map",

            myWhatUDoEN = "What do you do?",
            myWisdomEN = "Wisdom",

            myYesEN = "Yes";

        #endregion English

        /// <summary>
        /// Initializes values
        /// </summary>
        public static void Init() => English();

        /// <summary>
        /// Sets the language to Swedish
        /// </summary>
        public static void Swedish()
        {
            myAbstain = myAbstainSE;
            myAgility = myAgilitySE;
            myAllDefeated = myAllDefeatedSE;
            myApproachChest = myApproachChestSE;
            myApply = myApplySE;
            myArcher = myArcherSE;
            myArmour = myArmourSE;
            myAttack = myAttackSE;
            myAvailableScrolls = myAvailableScrollsSE;

            myBack = myBackSE;
            myBasicness = myBasicnessSE;
            myBeginTouch = myBeginTouchSE;
            myBootsOf = myBootsOfSE;
            myBossDefeated = myBossDefeatedSE;
            myBossFlee = myBossFleeSE;
            myBossWeapon = myBossWeaponSE;
            myBurnSkin = myBurnSkinSE;

            myCastFlamestrike = myCastFlamestrikeSE;
            myCastFireBall = myCastFireBallSE;
            myCastFireBolt = myCastFireBoltSE;
            myChestOf = myChestOfSE;
            myChooseAttack = myChooseAttackSE;
            myChooseDefence = myChooseDefenceSE;
            myChooseDoor = myChooseDoorSE;
            myChooseEnemy = myChooseEnemySE;
            myChooseLanguage = myChooseLanguageSE;
            myChooseSong = myChooseSongSE;
            myChooseSpell = myChooseSpellSE;
            myCurrentLanguage = myCurrentLanguageSE;
            myCloseInventory = myCloseInventorySE;
            myCommitSuicide = myCommitSuicideSE;
            myContinueAdventure = myContinueAdventureSE;
            myCurrentRoom = myCurrentRoomSE;

            myDealDamage1 = myDealDamage1SE;
            myDealDamage2 = myDealDamage2SE;
            myDecapitate = myDecapitateSE;
            myDefensive = myDefensiveSE;
            myDiscard = myDiscardSE;
            myDrinkHPPotion = myDrinkHPPotionSE;
            myDrinkManaPotion = myDrinkManaPotionSE;

            myEffectApplied = myEffectAppliedSE;
            myEnemyCannotAttack = myEnemyCannotAttackSE;
            myEnemyDefeated = myEnemyDefeatedSE;
            myEnemyDrawsBow = myEnemyDrawsBowSE;
            myEnemyNoStunned = myEnemyNotStunnedSE;
            myEnemyStunned = myEnemyStunnedSE;
            myEnemySwingSword = myEnemySwingSwordSE;
            myEnglish = myEnglishSE;
            myEnterDungeon = myEnterDungeonSE;
            myEnteringDungeon = myEnteringDungeonSE;
            myEnterRoom = myEnterRoomSE;
            myEquip = myEquipSE;
            myEquipped = myEquippedSE;
            myEscapeFangs = myEscapeFangsSE;
            myEvadedStrike = myEvadedStrikeSE;
            myExit = myExitSE;
            myExitDungeon = myExitDungeonSE;
            myExitingDungeon = myExitingDungeonSE;
            myExperience = myExperienceSE;

            myFireball = myFireballSE;
            myFireBolt = myFireBoltSE;
            myFlamestrike = myFlamestrikeSE;
            myFlee = myFleeSE;
            myFoundAnotherChest = myFoundAnotherChestSE;
            myFoundChest = myFoundChestSE;
            myFoundChests = myFoundChestsSE;
            myFoundLoot = myFoundLootSE;
            myFoundNoLoot = myFoundNoLootSE;
            myFullRecovery = myFullRecoverySE;

            myGold = myGoldSE;

            myHasFled = myHasFledSE;
            myHealth = myHealthSE;
            myHealthSmall = myHealthSmallSE;
            myHealingTouch = myHealingTouchSE;
            myHelmetOf = myHelmetOfSE;
            myHPPotions = myHPPotionsSE;

            myInitialRoom = myInitialRoomSE;
            myInsufficientFunds = myInsufficientFundsSE;
            myInsufficientMana = myInsufficientManaSE;
            myIntelligence = myIntelligenceSE;
            myInventory = myInventorySE;
            myItIsLocked = myItIsLockedSE;

            myLanguageSettings = myLanguageSettingsSE;
            myLevelUp = myLevelUpSE;
            myLightFire = myLightFireSE;
            myLongRest = myLongRestSE;
            myLootAdded = myLootAddedSE;
            myLuck = myLuckSE;

            myMagicallyHeal = myMagicallyHealSE;
            myManaPotions = myManaPotionsSE;
            myMaxHealth = myMaxHealthSE;
            myMaxMana = myMaxManaSE;
            myMaxStamina = myMaxStaminaSE;
            myMenu = myMenuSE;
            myMethodViolence = myMethodViolenceSE;
            myMissedEnemy = myMissedEnemySE;
            myMusicSettings = myMusicSettingsSE;

            myNo = myNoSE;
            myNoAttack1 = myNoAttack1SE;
            myNoAttack2 = myNoAttack2SE;
            myNoOrdinary1 = myNoOrdinary1SE;
            myNoOrdinary2 = myNoOrdinary2SE;

            myOff = myOffSE;
            myOffensive = myOffensiveSE;
            myOn = myOnSE;
            myOpenInventory = myOpenInventorySE;

            myPeekLoot = myPeekLootSE;
            myPeekNoLoot = myPeekNoLootSE;
            myPickUp = myPickUpSE;
            myPickUpEquip = myPickUpEquipSE;
            myPitchTent = myPitchTentSE;
            myPlay = myPlaySE;
            myPossibleActions = myPossibleActionsSE;

            myRegain = myRegainSE;
            myRegainStamina = myRegainStaminaSE;
            myRaiseShield = myRaiseShieldSE;
            myRaiseDefence1 = myRaiseDefence1SE;
            myRaiseDefence2 = myRaiseDefence2SE;
            myRest = myRestSE;
            myRoom = myRoomSE;

            myScrollDecayed = myScrollDecayedSE;
            myScrollOf = myScrollOfSE;
            myScrolls = myScrollsSE;
            myShieldOf = myShieldOfSE;
            mySkeleton = mySkeletonSE;
            mySlap = mySlapSE;
            mySlash = mySlashSE;
            mySpottedBoss = mySpottedBossSE;
            mySpottedMultiple = mySpottedMultipleSE;
            mySpottedNone = mySpottedNoneSE;
            mySpottedOne = mySpottedOneSE;
            myStamina = myStaminaSE;
            myStrength = myStrengthSE;
            mySpellDmg = mySpellDmgSE;
            mySpells = mySpellsSE;
            mySuperStun = mySuperStunSE;
            mySwedish = mySwedishSE;
            mySweep = mySweepSE;
            mySwordOf = mySwordOfSE;
            mySwingSword = mySwingSwordSE;

            myTakeDamage1 = myTakeDamage1SE;
            myTakeDamage2 = myTakeDamage2SE;
            myTempArmour = myTempArmourSE;
            myTempHealth = myTempHealthSE;
            myTempStrength = myTempStrengthSE;
            myThereAreDoors1 = myThereAreDoors1SE;
            myThereAreDoors2 = myThereAreDoors2SE;
            myThrowAway = myThrowAwaySE;
            myThrowPebbles1 = myThrowPebbles1SE;
            myThrowPebbles2 = myThrowPebbles2SE;
            myToggleMusic = myToggleMusicSE;
            myTrinketOf = myTrinketOfSE;
            myTrinkets = myTrinketsSE;
            myTrousersOf = myTrousersOfSE;

            myUnlockWish = myUnlockWishSE;
            myUseItem = myUseItemSE;

            myViewMap = myViewMapSE;

            myWhatUDo = myWhatUDoSE;
            myWisdom = myWisdomSE;

            myYes = myYesSE;

            myIsInSwedish = true;
            mySuffixes = new string[] { "Gudomlighet", "Korruption", "Fräsighet", "Bedrägeri", "Bonnläppar", "Oden", "Förtvivlan", "Klumpighet", "Dumhet", "Saltighet", "Visdom", "Makt", "Tyranner" };
            Utilities.Utility.SetSuffixes(mySuffixes);
        }

        /// <summary>
        /// Sets the language to English
        /// </summary>
        public static void English()
        {
            myAbstain = myAbstainEN;
            myAgility = myAgilityEN;
            myApproachChest = myApproachChestEN;
            myAllDefeated = myAllDefeatedEN;
            myApply = myApplyEN;
            myArcher = myArcherEN;
            myArmour = myArmourEN;
            myAttack = myAttackEN;
            myAvailableScrolls = myAvailableScrollsEN;

            myBack = myBackEN;
            myBasicness = myBasicnessEN;
            myBeginTouch = myBeginTouchEN;
            myBootsOf = myBootsOfEN;
            myBossDefeated = myBossDefeatedEN;
            myBossFlee = myBossFleeEN;
            myBossWeapon = myBossWeaponEN;
            myBurnSkin = myBurnSkinEN;

            myCastFireBall = myCastFireBallEN;
            myCastFireBolt = myCastFireBoltEN;
            myCastFlamestrike = myCastFlamestrikeEN;
            myChestOf = myChestOfEN;
            myChooseAttack = myChooseAttackEN;
            myChooseDefence = myChooseDefenceEN;
            myChooseDoor = myChooseDoorEN;
            myChooseEnemy = myChooseEnemyEN;
            myChooseLanguage = myChooseLanguageEN;
            myChooseSong = myChooseSongEN;
            myChooseSpell = myChooseSpellEN;
            myCloseInventory = myCloseInventoryEN;
            myCommitSuicide = myCommitSuicideEN;
            myContinueAdventure = myContinueAdventureEN;
            myCurrentLanguage = myCurrentLanguageEN;
            myCurrentRoom = myCurrentRoomEN;

            myDealDamage1 = myDealDamage1EN;
            myDealDamage2 = myDealDamage2EN;
            myDecapitate = myDecapitateEN;
            myDefensive = myDefensiveEN;
            myDiscard = myDiscardEN;
            myDrinkHPPotion = myDrinkHPPotionEN;
            myDrinkManaPotion = myDrinkManaPotionEN;

            myEffectApplied = myEffectAppliedEN;
            myEnglish = myEnglishEN;
            myEnemyCannotAttack = myEnemyCannotAttackEN;
            myEnemyDefeated = myEnemyDefeatedEN;
            myEnemyDrawsBow = myEnemyDrawsBowEN;
            myEnemyNoStunned = myEnemyNotStunnedEN;
            myEnemyStunned = myEnemyStunnedEN;
            myEnemySwingSword = myEnemySwingSwordEN;
            myEnteringDungeon = myEnteringDungeonEN;
            myEnterDungeon = myEnterDungeonEN;
            myEnterRoom = myEnterRoomEN;
            myEquip = myEquipEN;
            myEquipped = myEquippedEN;
            myEscapeFangs = myEscapeFangsEN;
            myEvadedStrike = myEvadedStrikeEN;
            myExit = myExitEN;
            myExitDungeon = myExitDungeonEN;
            myExitingDungeon = myExitingDungeonEN;
            myExperience = myExperienceEN;

            myFireball = myFireballEN;
            myFireBolt = myFireBoltEN;
            myFlamestrike = myFlamestrikeEN;
            myFlee = myFleeEN;
            myFoundAnotherChest = myFoundAnotherChestEN;
            myFoundChest = myFoundChestEN;
            myFoundChests = myFoundChestsEN;
            myFoundLoot = myFoundLootEN;
            myFoundNoLoot = myFoundNoLootEN;
            myFullRecovery = myFullRecoveryEN;

            myGold = myGoldEN;

            myHasFled = myHasFledEN;
            myHealth = myHealthEN;
            myHealthSmall = myHealthSmallEN;
            myHealingTouch = myHealingTouchEN;
            myHelmetOf = myHelmetOfEN;
            myHPPotions = myHPPotionsEN;

            myInitialRoom = myInitialRoomEN;
            myInsufficientFunds = myInsufficientFundsEN;
            myInsufficientMana = myInsufficientManaEN;
            myIntelligence = myIntelligenceEN;
            myInventory = myInventoryEN;
            myItIsLocked = myItIsLockedEN;

            myLanguageSettings = myLanguageSettingsEN;
            myLevelUp = myLevelUpEN;
            myLightFire = myLightFireEN;
            myLongRest = myLongRestEN;
            myLootAdded = myLootAddedEN;
            myLuck = myLuckEN;

            myMagicallyHeal = myMagicallyHealEN;
            myManaPotions = myManaPotionsEN;
            myMaxHealth = myMaxHealthEN;
            myMaxMana = myMaxManaEN;
            myMaxStamina = myMaxStaminaEN;
            myMenu = myMenuEN;
            myMethodViolence = myMethodViolenceEN;
            myMissedEnemy = myMissedEnemyEN;
            myMusicSettings = myMusicSettingsEN;

            myNo = myNoEN;
            myNoAttack1 = myNoAttack1EN;
            myNoAttack2 = myNoAttack2EN;
            myNoOrdinary1 = myNoOrdinary1EN;
            myNoOrdinary2 = myNoOrdinary2EN;

            myOff = myOffEN;
            myOffensive = myOffensiveEN;
            myOn = myOnEN;
            myOpenInventory = myOpenInventoryEN;

            myPeekLoot = myPeekLootEN;
            myPeekNoLoot = myPeekNoLootEN;
            myPickUp = myPickUpEN;
            myPickUpEquip = myPickUpEquipEN;
            myPitchTent = myPitchTentEN;
            myPlay = myPlayEN;
            myPossibleActions = myPossibleActionsEN;

            myRegain = myRegainEN;
            myRegainStamina = myRegainStaminaEN;
            myRaiseShield = myRaiseShieldEN;
            myRaiseDefence1 = myRaiseDefence1EN;
            myRaiseDefence2 = myRaiseDefence2EN;
            myRest = myRestEN;
            myRoom = myRoomEN;

            myScrollDecayed = myScrollDecayedEN;
            myScrollOf = myScrollOfEN;
            myScrolls = myScrollsEN;
            myShieldOf = myShieldOfEN;
            mySkeleton = mySkeletonEN;
            mySlap = mySlapEN;
            mySlash = mySlashEN;
            mySpottedBoss = mySpottedBossEN;
            mySpottedMultiple = mySpottedMultipleEN;
            mySpottedNone = mySpottedNoneEN;
            mySpottedOne = mySpottedOneEN;
            myStrength = myStrengthEN;
            mySpellDmg = mySpellDmgEN;
            mySpells = mySpellsEN;
            myStamina = myStaminaEN;
            mySuperStun = mySuperStunEN;
            mySwedish = mySwedishEN;
            mySweep = mySweepEN;
            mySwingSword = mySwingSwordEN;
            mySwordOf = mySwordOfEN;

            myTakeDamage1 = myTakeDamage1EN;
            myTakeDamage2 = myTakeDamage2EN;
            myTempArmour = myTempArmourEN;
            myTempStrength = myTempStrengthEN;
            myTempHealth = myTempHealthEN;
            myThereAreDoors1 = myThereAreDoors1EN;
            myThereAreDoors2 = myThereAreDoors2EN;
            myThrowAway = myThrowAwayEN;
            myThrowPebbles1 = myThrowPebbles1EN;
            myThrowPebbles2 = myThrowPebbles2EN;
            myToggleMusic = myToggleMusicEN;
            myTrinketOf = myTrinketOfEN;
            myTrinkets = myTrinketsEN;
            myTrousersOf = myTrousersOfEN;

            myUnlockWish = myUnlockWishEN;
            myUseItem = myUseItemEN;

            myViewMap = myViewMapEN;

            myWhatUDo = myWhatUDoEN;
            myWisdom = myWisdomEN;

            myYes = myYesEN;

            myIsInSwedish = false;
            mySuffixes = new string[] { "Divinity", "Corruption", "Fräsighet", "Deceit", "Peasants", "Odin", "Despair", "Clumsiness", "Stupidity", "Saltiness", "Wisdom", "Might", "Tyrants" };
            Utilities.Utility.SetSuffixes(mySuffixes);
        }

        #region Get

        public static bool GetIsInSwedish() => myIsInSwedish;

        public static string[] GetSuffixes() => mySuffixes;

        public static string GetAbstain() => myAbstain;

        public static string GetAgility() => myAgility;

        public static string GetAllDefeated() => myAllDefeated;

        public static string GetApply() => myApply;

        public static string GetApproachChest() => myApproachChest;

        public static string GetArcher() => myArcher;

        public static string GetArmour() => myArmour;

        public static string GetAttack() => myAttack;

        public static string GetAvailableScrolls() => myAvailableScrolls;

        public static string GetBack() => myBack;

        public static string GetBasicness() => myBasicness;

        public static string GetBeginTouch() => myBeginTouch;

        public static string GetBootsOf() => myBootsOf;

        public static string GetBossDefeated() => myBossDefeated;

        public static string GetBossFlee() => myBossFlee;

        public static string GetBossWeapon() => myBossWeapon;

        public static string GetBurnSkin() => myBurnSkin;

        public static string GetCastFireball() => myCastFireBall;

        public static string GetCastFirebolt() => myCastFireBolt;

        public static string GetCastFlamestrike() => myCastFlamestrike;

        public static string GetChestPlateOf() => myChestOf;

        public static string GetChooseAttack() => myChooseAttack;

        public static string GetChooseDefence() => myChooseDefence;

        public static string GetChooseDoor() => myChooseDoor;

        public static string GetChooseEnemy() => myChooseEnemy;

        public static string GetChooseLanguage() => myChooseLanguage;

        public static string GetChooseSong() => myChooseSong;

        public static string GetChooseSpell() => myChooseSpell;

        public static string GetCloseInventory() => myCloseInventory;

        public static string GetCommitSuicide() => myCommitSuicide;

        public static string GetContinueAdventure() => myContinueAdventure;

        public static string GetCurrentLanguage() => myCurrentLanguage;

        public static string GetCurrentRoom() => myCurrentRoom;

        public static string GetDealDamagePt1() => myDealDamage1;

        public static string GetDealDamagePt2() => myDealDamage2;

        public static string GetDecapitate() => myDecapitate;

        public static string GetDefensive() => myDefensive;

        public static string GetDiscard() => myDiscard;

        public static string GetDrinkHPPotion() => myDrinkHPPotion;

        public static string GetDrinkManaPotion() => myDrinkManaPotion;

        public static string GetEffectApplied() => myEffectApplied;

        public static string GetEnemyCannotAttack() => myEnemyCannotAttack;

        public static string GetEnemyDefeated() => myEnemyDefeated;

        public static string GetEnemyDrawsBow() => myEnemyDrawsBow;

        public static string GetEnemyNoStunned() => myEnemyNoStunned;

        public static string GetEnemyStunned() => myEnemyStunned;

        public static string GetEnemySwingSword() => myEnemySwingSword;

        public static string GetEnglish() => myEnglish;

        public static string GetEnterDungeon() => myEnterDungeon;

        public static string GetEnteringDungeon() => myEnteringDungeon;

        public static string GetEnterRoom() => myEnterRoom;

        public static string GetEquip() => myEquip;

        public static string GetEquipped() => myEquipped;

        public static string GetEscapeFangs() => myEscapeFangs;

        public static string GetEvadedStrike() => myEvadedStrike;

        public static string GetExit() => myExit;

        public static string GetExitDungeon() => myExitDungeon;

        public static string GetExitingDungeon() => myExitingDungeon;

        public static string GetExperience() => myExperience;

        public static string GetFireball() => myFireball;

        public static string GetFirebolt() => myFireBolt;

        public static string GetFlamestrike() => myFlamestrike;

        public static string GetFlee() => myFlee;

        public static string GetFoundAnotherChest() => myFoundAnotherChest;

        public static string GetFoundChest() => myFoundChest;

        public static string GetFoundChests() => myFoundChests;

        public static string GetFoundLoot() => myFoundLoot;

        public static string GetFoundNoLoot() => myFoundNoLoot;

        public static string GetFullRecovery() => myFullRecovery;

        public static string GetGold() => myGold;

        public static string GetHasFled() => myHasFled;

        public static string GetHealingTouch() => myHealingTouch;

        public static string GetHealth() => myHealth;

        public static string GetHealthLowerCase() => myHealthSmall;

        public static string GetHelmetOf() => myHelmetOf;

        public static string GetHPPotions() => myHPPotions;

        public static string GetInitialRoom() => myInitialRoom;

        public static string GetInsufficientFunds() => myInsufficientFunds;

        public static string GetInsufficientMana() => myInsufficientMana;

        public static string GetIntelligence() => myIntelligence;

        public static string GetInventory() => myInventory;

        public static string GetItIsLocked() => myItIsLocked;

        public static string GetLanguageSettings() => myLanguageSettings;

        public static string GetLevelUp() => myLevelUp;

        public static string GetLightFire() => myLightFire;

        public static string GetLongRest() => myLongRest;

        public static string GetLootAdded() => myLootAdded;

        public static string GetLuck() => myLuck;

        public static string GetMagicallyHeal() => myMagicallyHeal;

        public static string GetManaPotions() => myManaPotions;

        public static string GetMaxHealth() => myMaxHealth;

        public static string GetMaxMana() => myMaxMana;

        public static string GetMaxStamina() => myMaxStamina;

        public static string GetMenu() => myMenu;

        public static string GetMethodViolence() => myMethodViolence;

        public static string GetMissedEnemy() => myMissedEnemy;

        public static string GetMusicSettings() => myMusicSettings;

        public static string GetNo() => myNo;

        public static string GetNoAttackPt1() => myNoAttack1;

        public static string GetNoAttackPt2() => myNoAttack2;

        public static string GetNoOrdinaryPt1() => myNoOrdinary1;

        public static string GetNoOrdinaryPt2() => myNoOrdinary2;

        public static string GetOff() => myOff;

        public static string GetOffensive() => myOffensive;

        public static string GetOn() => myOn;

        public static string GetOpenInventory() => myOpenInventory;

        public static string GetPeekLoot() => myPeekLoot;

        public static string GetPeekNoLoot() => myPeekNoLoot;

        public static string GetPickup() => myPickUp;

        public static string GetPickUpEquip() => myPickUpEquip;

        public static string GetPitchTent() => myPitchTent;

        public static string GetPlay() => myPlay;

        public static string GetPossibleActions() => myPossibleActions;

        public static string GetRaiseDefencePt1() => myRaiseDefence1;

        public static string GetRaiseDefencePt2() => myRaiseDefence2;

        public static string GetRaiseShield() => myRaiseShield;

        public static string GetRegain() => myRegain;

        public static string GetRegainStamina() => myRegainStamina;

        public static string GetRest() => myRest;

        public static string GetRoom() => myRoom;

        public static string GetScrollOf() => myScrollOf;

        public static string GetScrolls() => myScrolls;

        public static string GetShieldOf() => myShieldOf;

        public static string GetSkeleton() => mySkeleton;

        public static string GetSlap() => mySlap;

        public static string GetSlash() => mySlash;

        public static string GetSpellDamage() => mySpellDmg;

        public static string GetSpells() => mySpells;

        public static string GetSpottedBoss() => mySpottedBoss;

        public static string GetSpottedMultiple() => mySpottedMultiple;

        public static string GetSpottedNone() => mySpottedNone;

        public static string GetSpottedOne() => mySpottedOne;

        public static string GetStamina() => myStamina;

        public static string GetStrength() => myStrength;

        public static string GetSuperStun() => mySuperStun;

        public static string GetSwedish() => mySwedish;

        public static string GetSweep() => mySweep;

        public static string GetSwingSword() => mySwingSword;

        public static string GetSwordOf() => mySwordOf;

        public static string GetTakeDamagePt1() => myTakeDamage1;

        public static string GetTakeDamagePt2() => myTakeDamage2;

        public static string GetTempArmour() => myTempArmour;

        public static string GetTempHealth() => myTempHealth;

        public static string GetTempStrength() => myTempStrength;

        public static string GetThereAreDoorsPt1() => myThereAreDoors1;

        public static string GetThereAreDoorsPt2() => myThereAreDoors2;

        public static string GetThrowAway() => myThrowAway;

        public static string GetThrowPebblesPt1() => myThrowPebbles1;

        public static string GetThrowPebblesPt2() => myThrowPebbles2;

        public static string GetToggleMusic() => myToggleMusic;

        public static string GetTrinketOf() => myTrinketOf;

        public static string GetTrinkets() => myTrinkets;

        public static string GetTrousersOf() => myTrousersOf;

        public static string GetUnlockWish() => myUnlockWish;

        public static string GetUseItem() => myUseItem;

        public static string GetViewMap() => myViewMap;

        public static string GetWhatUDo() => myWhatUDo;

        public static string GetWisdom() => myWisdom;

        public static string GetYes() => myYes;

        #endregion Get
    }
}