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

            myRaiseDefence1,
            myRaiseDefence2,
            myRaiseShield,
            myRegain,
            myRegainStamina,
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

            myRaiseShieldSE = "Höj skölden",
            myRaiseDefence1SE = "Du höjer din sköld och",
            myRaiseDefence2SE = "förbereder för ett slag!",
            myRegainSE = "Du får åter",
            myRegainStaminaSE = "kondition",
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
            mySwedishEN = "Swedish",
            myEnglishEN = "English",

            myApproachChestEN = "You approach the chest and inspect it",
            myItIsLockedEN = "It is locked...",
            myUnlockWishEN = "Do wish to unlock it?",
            myYesEN = "Yes",
            myNoEN = "No",
            myPeekLootEN = "You peek inside the chest, there is loot!",
            myPeekNoLootEN = "You peek inside the chest, there is no loot",
            myNoOrdinary1EN = "As you try to open the chest, you notice",
            myNoOrdinary2EN = "that it is breathing. This is no ordinary chest",
            myEscapeFangsEN = "You managed to escape its fangs!",
            myDecapitateEN = "The chest-mimic bites you and rips your head off!",

            myLanguageSettingsEN = "Languagesettings",
            myBasicnessEN = "Basicness",
            myStaminaEN = "Stamina",
            myTrinketOfEN = "Trinket of",
            myScrollOfEN = "Scroll of",
            myHelmetOfEN = "Helmet of",
            myChestOfEN = "Chestplate of",
            myTrousersOfEN = "Trousers of",
            myBootsOfEN = "Boots of",
            myShieldOfEN = "Shield of",
            mySwordOfEN = "Sword of",

            myChooseLanguageEN = "Choose language:",
            myCurrentLanguageEN = "Current language: ",

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
            mySpellDmgEN = "Spelldamage",

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
            myTakeDamage2EN = " damage!",
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

        /// <summary>
        /// Initializes values
        /// </summary>
        public static void Init() => English();

        /// <summary>
        /// Sets the language to Swedish
        /// </summary>
        public static void Swedish()
        {
            myIsInSwedish = true;
            mySuffixes = new string[] { "Gudomlighet", "Korruption", "Fräsighet", "Bedrägeri", "Bonnläppar", "Oden", "Förtvivlan", "Klumpighet", "Dumhet", "Saltighet", "Visdom", "Makt", "Tyranner" };
            Utilities.Utility.SetSuffixes(mySuffixes);
            myLanguageSettings = myLanguageSettingsSE;
            mySwedish = mySwedishSE;
            myEnglish = myEnglishSE;
            myApproachChest = myApproachChestSE;
            myItIsLocked = myItIsLockedSE;
            myUnlockWish = myUnlockWishSE;
            myYes = myYesSE;
            myNo = myNoSE;
            myPeekLoot = myPeekLootSE;
            myPeekNoLoot = myPeekNoLootSE;
            myNoOrdinary1 = myNoOrdinary1SE;
            myNoOrdinary2 = myNoOrdinary2SE;
            myEscapeFangs = myEscapeFangsSE;
            myDecapitate = myDecapitateSE;
            myBasicness = myBasicnessSE;
            myStamina = myStaminaSE;
            myTrinketOf = myTrinketOfSE;
            myScrollOf = myScrollOfSE;
            myHelmetOf = myHelmetOfSE;
            myChestOf = myChestOfSE;
            myTrousersOf = myTrousersOfSE;
            myBootsOf = myBootsOfSE;
            myShieldOf = myShieldOfSE;
            mySwordOf = mySwordOfSE;
            myChooseLanguage = myChooseLanguageSE;
            myCurrentLanguage = myCurrentLanguageSE;
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
            myIsInSwedish = false;
            mySuffixes = new string[] { "Divinity", "Corruption", "Fräsighet", "Deceit", "Peasants", "Odin", "Despair", "Clumsiness", "Stupidity", "Saltiness", "Wisdom", "Might", "Tyrants" };
            Utilities.Utility.SetSuffixes(mySuffixes);
            myApproachChest = myApproachChestEN;
            myItIsLocked = myItIsLockedEN;
            myUnlockWish = myUnlockWishEN;
            myYes = myYesEN;
            myNo = myNoEN;
            myPeekLoot = myPeekLootEN;
            myPeekNoLoot = myPeekNoLootEN;
            myNoOrdinary1 = myNoOrdinary1EN;
            myNoOrdinary2 = myNoOrdinary2EN;
            myEscapeFangs = myEscapeFangsEN;
            myDecapitate = myDecapitateEN;
            mySwedish = mySwedishEN;
            myEnglish = myEnglishEN;
            myLanguageSettings = myLanguageSettingsEN;
            myChooseLanguage = myChooseLanguageEN;
            myCurrentLanguage = myCurrentLanguageEN;
            myBasicness = myBasicnessEN;
            myStamina = myStaminaEN;
            myTrinketOf = myTrinketOfEN;
            myScrollOf = myScrollOfEN;
            myHelmetOf = myHelmetOfEN;
            myChestOf = myChestOfEN;
            myTrousersOf = myTrousersOfEN;
            myBootsOf = myBootsOfEN;
            myShieldOf = myShieldOfEN;
            mySwordOf = mySwordOfEN;
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
            myFireBolt = myFireBoltEN;
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

        #region Get

        public static bool GetIsInSwedish() => myIsInSwedish;

        public static string[] GetSuffixes() => mySuffixes;

        public static string GetLanguageSettings() => myLanguageSettings;

        public static string GetApproachChest() => myApproachChest;

        public static string GetItIsLocked() => myItIsLocked;

        public static string GetUnlockWish() => myUnlockWish;

        public static string GetYes() => myYes;

        public static string GetNo() => myNo;

        public static string GetNoOrdinaryPt1() => myNoOrdinary1;

        public static string GetNoOrdinaryPt2() => myNoOrdinary2;

        public static string GetEscapeFangs() => myEscapeFangs;

        public static string GetDecapitate() => myDecapitate;

        public static string GetPeekLoot() => myPeekLoot;

        public static string GetPeekNoLoot() => myPeekNoLoot;

        public static string GetBasicness() => myBasicness;

        public static string GetChooseLanguage() => myChooseLanguage;

        public static string GetCurrentLanguage() => myCurrentLanguage;

        public static string GetSwedish() => mySwedish;

        public static string GetEnglish() => myEnglish;

        public static string GetStamina() => myStamina;

        public static string GetScrollOf() => myScrollOf;

        public static string GetTrinketOf() => myTrinketOf;

        public static string GetHelmetOf() => myHelmetOf;

        public static string GetChestPlateOf() => myChestOf;

        public static string GetTrousersOf() => myTrousersOf;

        public static string GetBootsOf() => myBootsOf;

        public static string GetShieldOf() => myShieldOf;

        public static string GetSwordOf() => mySwordOf;

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
    }
}