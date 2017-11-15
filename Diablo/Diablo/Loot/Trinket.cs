using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Loot
{
    public enum Buff
    {
        Health,
        Armour,
        Stamina,
        Agility,
        Strength,
        Luck
    }

    class Trinket : Item
    {
        int
            myEffectAmount;
        Buff
            myBuffType;

        public Trinket()
        {
            myType = Type.TRINKET;
            SetBuff();
            SetName();
        }

        public Trinket(string aSuffix)
        {
            myType = Type.TRINKET;
            SetBuff();
            SetName();
            mySuffix = "Basicness";
        }

        private void SetBuff()
        {
            switch (Utilities.Utility.GetRNG().Next(0, 6))
            {
                case 0:
                    myBuffType = Buff.Health;
                    myEffectAmount = Utilities.Utility.GetRNG().Next(10, 31);
                    break;
                case 1:
                    myBuffType = Buff.Armour;
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 11);
                    break;
                case 2:
                    myBuffType = Buff.Stamina;
                    myEffectAmount = Utilities.Utility.GetRNG().Next(10, 21);
                    break;
                case 3:
                    myBuffType = Buff.Agility;
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 16);
                    break;
                case 4:
                    myBuffType = Buff.Luck;
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 11);
                    break;
                case 5:
                    myBuffType = Buff.Strength;
                    myEffectAmount = Utilities.Utility.GetRNG().Next(5, 16);
                    break;
            }
        }

        public void ApplyBuff(Player.Player aPlayer)
        {
            switch (myBuffType)
            {
                case Buff.Agility:
                    aPlayer.SetAgilityBuff(myEffectAmount);
                    break;
                case Buff.Armour:
                    aPlayer.SetArmourBuff(myEffectAmount);
                    break;
                case Buff.Health:
                    aPlayer.SetHealthBuff(myEffectAmount);
                    break;
                case Buff.Luck:
                    aPlayer.SetLuckBuff(myEffectAmount);
                    break;
                case Buff.Stamina:
                    aPlayer.SetStaminaBuff(myEffectAmount);
                    break;
                case Buff.Strength:
                    aPlayer.SetStrengthBuff(myEffectAmount);
                    break;
            }
        }

        public Buff GetBuffType()
        {
            return myBuffType;
        }

        public int GetEffectAmount()
        {
            return myEffectAmount;
        }

        private void SetName()
        {
            myPrefix = "Trinket of";
            mySuffix = Utilities.Utility.GetRandomSuffix();
        }
    }
}