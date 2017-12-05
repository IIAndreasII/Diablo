using Diablo.Localisation;
using Diablo.Utilities;

namespace Diablo.Loot
{
    public enum BuffType
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

        private BuffType
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
            switch (Utility.GetRNG().Next(0, 8))
            {
                case 0:
                    myBuffType = BuffType.HEALTH;
                    myEffectString = Language.GetHealth();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(10, 31);
                    break;

                case 1:
                    myBuffType = BuffType.ARMOUR;
                    myEffectString = Localisation.Language.GetArmour();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 11);
                    break;

                case 2:
                    myBuffType = BuffType.STAMINA;
                    myEffectString = Localisation.Language.GetStamina();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(10, 21);
                    break;

                case 3:
                    myBuffType = BuffType.AGILITY;
                    myEffectString = Localisation.Language.GetAgility();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 16);
                    break;

                case 4:
                    myBuffType = BuffType.LUCK;
                    myEffectString = Localisation.Language.GetLuck();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 11);
                    break;

                case 5:
                    myBuffType = BuffType.STRENGTH;
                    myEffectString = Localisation.Language.GetStrength();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 16);
                    break;

                case 6:
                    myBuffType = BuffType.WISDOM;
                    myEffectString = Localisation.Language.GetWisdom();
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 11);
                    break;

                case 7:
                    myBuffType = BuffType.INTELLIGENCE;
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
                case BuffType.AGILITY:
                    aPlayer.SetAgilityBuff(myEffectAmount);
                    break;

                case BuffType.ARMOUR:
                    aPlayer.SetArmourBuff(myEffectAmount);
                    break;

                case BuffType.HEALTH:
                    aPlayer.SetHealthBuff(myEffectAmount);
                    break;

                case BuffType.LUCK:
                    aPlayer.SetLuckBuff(myEffectAmount);
                    break;

                case BuffType.STAMINA:
                    aPlayer.SetStaminaBuff(myEffectAmount);
                    break;

                case BuffType.STRENGTH:
                    aPlayer.SetStrengthBuff(myEffectAmount);
                    break;

                case BuffType.WISDOM:
                    aPlayer.SetWisdomBuff(myEffectAmount);
                    break;

                case BuffType.INTELLIGENCE:
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