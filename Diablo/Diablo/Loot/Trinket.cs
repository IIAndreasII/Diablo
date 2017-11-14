using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Loot
{
    public enum Buff
    {
        HEALTH,
        ARMOUR,
        STAMINA,
        AGILITY,
        LUCK
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
        }

        private void SetBuff()
        {
            switch (Utilities.Utility.GetRNG().Next(0, 5))
            {
                case 0:
                    myBuffType = Buff.HEALTH;
                    break;
                case 1:
                    myBuffType = Buff.ARMOUR;
                    break;
                case 2:
                    myBuffType = Buff.STAMINA;
                    break;
                case 3:
                    myBuffType = Buff.AGILITY;
                    break;
                case 4:
                    myBuffType = Buff.LUCK;
                    break;
            }
        }
    }
}