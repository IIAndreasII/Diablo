using System;
using System.Collections.Generic;
using System.Linq;
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
            myPrefix = SetPrefix();
            SetSuffix();
            SetArmourAndDamage();
        }

        public Item(Type aType)
        {
            myType = aType;
            myPrefix = SetPrefix();
            SetSuffix();
            SetArmourAndDamage();
        }

        public Item(Type aType, string aSuffix, int anArmourRating, int aDamage)
        {
            myType = aType;
            myPrefix = SetPrefix();
            mySuffix = aSuffix;
            myArmourRating = anArmourRating;
            myDamage = aDamage;
        }
        #endregion

        /// <summary>
        /// Gets a random item-type
        /// </summary>
        /// <returns>A random type</returns>
        private Type GetRandomType()
        {
            switch(Utilities.Utility.myRNG.Next(0, 5))
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
                default:
                    return Type.WEAPON;
            }
        }

        /// <summary>
        /// Gets prefix based on type
        /// </summary>
        /// <returns>String containing a prefix</returns>
        private string SetPrefix()
        {
            switch (myType)
            {
                case Type.HELMET:
                    return "Helmet of";
                case Type.CHESTPLATE:
                    return "Chestplate of";
                case Type.TROUSERS:
                    return "Trousers of";
                case Type.BOOTS:
                    return "Boots of";
                case Type.WEAPON:
                    return "Sword of";
                default:
                    return "Error of";
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
