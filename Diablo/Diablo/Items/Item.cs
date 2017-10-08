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
        SCROLL
    }

    public enum ScrollEffect
    {
        DMGBUFF,
        HPBOOST,
        ARMBUFF
    }
   
    class Item
    {
        Type 
            myType;
        string 
            myPrefix,
            mySuffix;
        int
            myArmourRating,
            myDamage;

        #region Constructors
        public Item()
        {
            myType = GetRandomType();
            SetPrefix();
            SetSuffix();
            SetArmourAndDamage();
        }

        public Item(Type aType)
        {
            myType = aType;
            SetPrefix();
            SetSuffix();
            SetArmourAndDamage();
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
            switch(Utilities.Utility.myRNG.Next(0, 6))
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
                    return Type.WEAPON;
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
        private void SetArmourAndDamage()
        {
            switch (myType)
            {
                case Type.HELMET:
                    myArmourRating = Utilities.Utility.myRNG.Next(1, 21);
                    myDamage = 0;
                    break;
                case Type.CHESTPLATE:
                    myArmourRating = Utilities.Utility.myRNG.Next(1, 31);
                    myDamage = 0;
                    break;
                case Type.TROUSERS:
                    myArmourRating = Utilities.Utility.myRNG.Next(1, 26);
                    myDamage = 0;
                    break;
                case Type.BOOTS:
                    myArmourRating = Utilities.Utility.myRNG.Next(1, 16);
                    myDamage = 0;
                    break;
                case Type.WEAPON:
                    myDamage = Utilities.Utility.myRNG.Next(1, 51);
                    myArmourRating = 0;
                    break;
                default:
                    myDamage = 0;
                    myArmourRating = 0;
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
        #endregion
    }
}