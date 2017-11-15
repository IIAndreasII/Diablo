using System;

namespace Diablo.Loot
{
    public enum ScrollEffect
    {
        STRBUFF,
        HPBUFF,
        ARMBUFF,
        ERROR
    }

    public class Scroll : Item
    {
        ScrollEffect
            myScrollEffect;
        int
            myStrengthBuff,
            myArmourBuff,
            myHealthBuff,
            myScrollDuration = 2;

        public Scroll()
        {
            myType = ItemType.SCROLL;
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
            SetName();
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
        /// Sets scroll's duration
        /// </summary>
        /// <param name="aDuration">Duration of the scroll represented in number of combat-rounds</param>
        public void SetScrollDuration(int aDuration)
        {
            myScrollDuration = aDuration;
        }

        /// <summary>
        /// Sets the item's name
        /// </summary>
        private void SetName()
        {
            myPrefix = "Scroll of";
            mySuffix = Utilities.Utility.GetRandomSuffix();
        }
        #endregion

        #region Get
        /// <summary>
        /// Gets the scrolls duration
        /// </summary>
        /// <returns></returns>
        public int GetScrollDuration()
        {
            return myScrollDuration;
        }

        /// <summary>
        /// Gets the items scroll-effect
        /// </summary>
        /// <returns></returns>
        public ScrollEffect GetScrollEffect()
        {
            return myScrollEffect;
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