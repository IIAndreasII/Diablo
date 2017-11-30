namespace Diablo.Loot
{
    public enum Buff
    {
        HEALTH,
        ARMOUR,
        STAMINA,
        AGILITY,
        STRENGTH,
        LUCK,
        WISDOM,
        INTELLIGENCE
    }

    internal class Trinket : Item
    {
        private int
            myEffectAmount;

        private Buff
            myBuffType;

        private string
            myEffectString;

        public Trinket()
        {
            myType = ItemType.TRINKET;
            SetBuff();
            SetName();
        }

        public Trinket(string aSuffix)
        {
            myType = ItemType.TRINKET;
            SetBuff();
            SetName();
            mySuffix = aSuffix;
        }

        /// <summary>
        /// Sets the trinket's bufftype
        /// </summary>
        private void SetBuff()
        {
            switch (Utilities.Utility.GetRNG().Next(0, 8))
            {
                case 0:
                    myBuffType = Buff.HEALTH;
                    myEffectString = Localisation.Language.GetHealth();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(10, 31);
                    break;

                case 1:
                    myBuffType = Buff.ARMOUR;
                    myEffectString = Localisation.Language.GetArmour();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 11);
                    break;

                case 2:
                    myBuffType = Buff.STAMINA;
                    myEffectString = Localisation.Language.GetStamina();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(10, 21);
                    break;

                case 3:
                    myBuffType = Buff.AGILITY;
                    myEffectString = Localisation.Language.GetAgility();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 16);
                    break;

                case 4:
                    myBuffType = Buff.LUCK;
                    myEffectString = Localisation.Language.GetLuck();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 11);
                    break;

                case 5:
                    myBuffType = Buff.STRENGTH;
                    myEffectString = Localisation.Language.GetStrength();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 16);
                    break;

                case 6:
                    myBuffType = Buff.WISDOM;
                    myEffectString = Localisation.Language.GetWisdom();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 11);
                    break;

                case 7:
                    myBuffType = Buff.INTELLIGENCE;
                    myEffectString = Localisation.Language.GetIntelligence();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 11);
                    break;
            }
        }

        /// <summary>
        /// Applies buff to given player
        /// </summary>
        /// <param name="aPlayer">Active player</param>
        public void ApplyBuff(Player.Player aPlayer)
        {
            switch (myBuffType)
            {
                case Buff.AGILITY:
                    aPlayer.SetAgilityBuff(myEffectAmount);
                    break;

                case Buff.ARMOUR:
                    aPlayer.SetArmourBuff(myEffectAmount);
                    break;

                case Buff.HEALTH:
                    aPlayer.SetHealthBuff(myEffectAmount);
                    break;

                case Buff.LUCK:
                    aPlayer.SetLuckBuff(myEffectAmount);
                    break;

                case Buff.STAMINA:
                    aPlayer.SetStaminaBuff(myEffectAmount);
                    break;

                case Buff.STRENGTH:
                    aPlayer.SetStrengthBuff(myEffectAmount);
                    break;

                case Buff.WISDOM:
                    aPlayer.SetWisdomBuff(myEffectAmount);
                    break;

                case Buff.INTELLIGENCE:
                    aPlayer.SetIntelligenceBuff(myEffectAmount);
                    break;
            }
        }

        /// <summary>
        /// Gets buff type
        /// </summary>
        /// <returns>Trinkets bufftype</returns>
        public string GetEffectType()
        {
            return myEffectString;
        }

        /// <summary>
        /// Gets effect amount
        /// </summary>
        /// <returns>Effectamount</returns>
        public int GetEffectAmount()
        {
            return myEffectAmount;
        }
    }
}