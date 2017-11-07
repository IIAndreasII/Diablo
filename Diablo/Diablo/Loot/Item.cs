using System;

namespace Diablo.Loot
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
        STRBUFF,
        HPBUFF,
        ARMBUFF,
        ERROR
    }
   
    public class Item
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
            myStrengthBuff,
            myArmourBuff,
            myHealthBuff,
            myScrollDuration = 2;

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
                myScrollEffect = GetRandomEffect();
            }
            else
            {
                myType = GetRandomType();
            }
            SetRatings();
            SetPrefix();
            SetSuffix();
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
                    return ScrollEffect.STRBUFF;
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
        /// Decays the scroll-effect, returns true if the effect has decayed
        /// </summary>
        /// <param name="aPlayer">The player to affect</param>
        /// <returns>Returns true if the scroll-effect has decayed</returns>
        public bool Decay(Player.Player aPlayer)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;

            myScrollDuration -= 1;
            if (myScrollDuration <= 0)
            {
                switch (myScrollEffect)
                {
                    case ScrollEffect.ARMBUFF:
                        aPlayer.SetTempArmourRating(-myArmourBuff);
                        break;
                    case ScrollEffect.HPBUFF:
                        aPlayer.SetTempHealth(-myHealthBuff);
                        break;
                    case ScrollEffect.STRBUFF:
                        aPlayer.SetTempStrength(-myStrengthBuff);
                        break;
                    case ScrollEffect.ERROR:
                        Console.WriteLine("Errors wore off");
                        break;
                }
                aPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 12);
                Console.Write("Scroll-effect wore off!");
                System.Threading.Thread.Sleep(1500);
                return true;
            }
            return false;
        }

        #region Set
        /// <summary>
        /// Sets armour/damage/effect based on type
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
                        case ScrollEffect.STRBUFF:
                            myStrengthBuff = 20;
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        public void SetScrollDuration(int aDuration)
        {
            myScrollDuration = aDuration;
        }
        #endregion

        #region Get
        public int GetScrollDuration()
        {
            return myScrollDuration;
        }

        public ScrollEffect GetScrollEffect()
        {
            return myScrollEffect;
        }

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

        public int GetStrengthBuff()
        {
            return myStrengthBuff;
        }

        public int GetArmourBuff()
        {
            return myArmourBuff;
        }

        public int GetHealthBuff()
        {
            return myHealthBuff;
        }
        #endregion
    }
}