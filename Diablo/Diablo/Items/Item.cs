using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Items
{
    public enum Type
    {
        HELMET,
        CHESTPLATE,
        TROUSERS,
        BOOTS,
        WEAPON,
        SCROLL,
        ERROR
    }

    public enum ScrollEffect
    {
        DMGBUFF,
        HPBUFF,
        ARMBUFF,
        ERROR
    }
   
    class Item
    {
        Type 
            myType;
        ScrollEffect
            myScrollEffect;
        string 
            myPrefix,
            mySuffix;
        int
            myArmourRating,
            myDamage,
            myDamageBuff,
            myArmourBuff;
        float
            myHealthBuff;

        #region Constructors
        public Item()
        {
            myType = GetRandomType();
            SetPrefix();
            SetSuffix();
            SetRatings();
        }

        public Item(bool isScroll)
        {
            if (isScroll)
            {
                myType = Type.SCROLL;
            }
            else
            {
                myType = GetRandomType();
            }
            SetRatings();
        }

        public Item(Type aType)
        {
            myType = aType;
            SetPrefix();
            SetSuffix();
            SetRatings();
        }

        public Item(Type aType, string aSuffix, int anArmourRating)
        {
            myType = aType;
            SetPrefix();
            mySuffix = aSuffix;
            myArmourRating = anArmourRating;
        }

        public Item(Type aType, int aDamage, string aSuffix)
        {
            myType = aType;
            SetPrefix();
            mySuffix = aSuffix;
            myDamage = aDamage;
        }
        #endregion

        /// <summary>
        /// Gets a random item-type
        /// </summary>
        /// <returns>A random type</returns>
        private Type GetRandomType()
        {
            switch(Utilities.Utility.GetRNG().Next(0, 6))
            {
                case 0:
                    return Type.HELMET;
                case 1:
                    return Type.CHESTPLATE;
                case 2:
                    return Type.TROUSERS;
                case 3:
                    return Type.BOOTS;
                case 4:
                    return Type.WEAPON;
                case 5:
                    return Type.SCROLL;
                default:
                    return Type.ERROR;
            }
        }

        /// <summary>
        /// Gets a random Scrolleffect
        /// </summary>
        /// <returns>A random scrolleffect</returns>
        private ScrollEffect GetRandomEffect()
        {
            switch (Utilities.Utility.GetRNG().Next(0, 3))
            {
                case 0:
                    return ScrollEffect.ARMBUFF;
                case 1:
                    return ScrollEffect.HPBUFF;
                case 2:
                    return ScrollEffect.DMGBUFF;
                default:
                    return ScrollEffect.ERROR;
            }
        }

        /// <summary>
        /// Gets prefix based on type
        /// </summary>
        /// <returns>String containing a prefix</returns>
        private void SetPrefix()
        {
            switch (myType)
            {
                case Type.HELMET:
                    myPrefix = "Helmet of";
                    break;
                case Type.CHESTPLATE:
                    myPrefix = "Chestplate of";
                    break;
                case Type.TROUSERS:
                    myPrefix = "Trousers of";
                    break;
                case Type.BOOTS:
                    myPrefix = "Boots of";
                    break;
                case Type.WEAPON:
                    myPrefix = "Sword of";
                    break;
                case Type.SCROLL:
                    myPrefix = "Scroll of";
                    break;
                default:
                    myPrefix = "Error of";
                    break;
            }
        }

        /// <summary>
        /// Sets the suffix of the item
        /// </summary>
        private void SetSuffix()
        {
            mySuffix = Utilities.Utility.GetRandomSuffix();
        }

        /// <summary>
        /// Sets armour/damage based on type
        /// </summary>
        private void SetRatings()
        {
            switch (myType)
            {
                case Type.HELMET:
                    myArmourRating = Utilities.Utility.GetRNG().Next(1, 21);
                    break;
                case Type.CHESTPLATE:
                    myArmourRating = Utilities.Utility.GetRNG().Next(1, 31);
                    break;
                case Type.TROUSERS:
                    myArmourRating = Utilities.Utility.GetRNG().Next(1, 26);
                    break;
                case Type.BOOTS:
                    myArmourRating = Utilities.Utility.GetRNG().Next(1, 16);
                    break;
                case Type.WEAPON:
                    myDamage = Utilities.Utility.GetRNG().Next(1, 51);
                    break;
                case Type.SCROLL:
                    myScrollEffect = GetRandomEffect();
                    switch (myScrollEffect)
                    {
                        case ScrollEffect.ARMBUFF:
                            myArmourBuff = 25;
                            break;
                        case ScrollEffect.HPBUFF:
                            myHealthBuff = 50;
                            break;
                        case ScrollEffect.DMGBUFF:
                            myDamageBuff = 20;
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        #region Get
        public Type GetItemType()
        {
            return myType;
        }

        /// <summary>
        /// Gets the full name of the item
        /// </summary>
        /// <returns>String containing the full name of the item</returns>
        public string GetFullName()
        {
            return myPrefix + " " + mySuffix;
        }

        /// <summary>
        /// Gets the item's prefix
        /// </summary>
        /// <returns>String containing the item's prefix</returns>
        public string GetPrefix()
        {
            return myPrefix;
        }

        /// <summary>
        /// Gets the item's suffix
        /// </summary>
        /// <returns>String containing the item's suffix</returns>
        public string GetSuffix()
        {
            return mySuffix;
        }

        /// <summary>
        /// Gets the item's aromur-rating
        /// </summary>
        /// <returns>Int containing the item's armour-rating</returns>
        public int GetArmourRating()
        {
            return myArmourRating;
        }

        /// <summary>
        /// Gets the item's damage
        /// </summary>
        /// <returns>Int containing the item's damage-value</returns>
        public int GetDamage()
        {
            return myDamage;
        }

        public int GetDamageBuff()
        {
            return myDamageBuff;
        }

        public int GetArmourBuff()
        {
            return myArmourBuff;
        }

        public float GetHealthBuff()
        {
            return myHealthBuff;
        }
        #endregion
    }
}