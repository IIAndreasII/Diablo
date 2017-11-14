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

        private void SetBuff()
        {
            switch (Utilities.Utility.GetRNG().Next(0, 5))
            {
                case 0:
                    myBuffType = Buff.Health;
                    break;
                case 1:
                    myBuffType = Buff.Armour;
                    break;
                case 2:
                    myBuffType = Buff.Stamina;
                    break;
                case 3:
                    myBuffType = Buff.Agility;
                    break;
                case 4:
                    myBuffType = Buff.Luck;
                    break;
            }
        }

        public void ApplyBuff(Player.Player aPlayer)
        {
            switch (myBuffType)
            {

            }
        }

        public Buff GetBuffType()
        {
            return myBuffType;
        }

        private void SetName()
        {
            myPrefix = "Trinket of";
            mySuffix = Utilities.Utility.GetRandomSuffix();
        }
    }
}