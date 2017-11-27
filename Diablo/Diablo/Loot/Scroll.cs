using System;

namespace Diablo.Loot
{
    public enum ScrollEffect
    {
        STRBUFF,
        HPBUFF,
        ARMBUFF,
    }

    public class Scroll : Item
    {
        private ScrollEffect
            myScrollEffect;

        private int
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
                }
                aPlayer.PrintUI();
                Console.SetCursorPosition(tempWWD2 - 12, tempWHD2 - 12);
                Console.Write("Scroll-effect wore off!");
                System.Threading.Thread.Sleep(1500);
                return true;
            }
            return false;
        }

        #region Get

        /// <summary>
        /// Gets the scrolls duration
        /// </summary>
        /// <returns></returns>
        public int GetScrollDuration() => myScrollDuration;

        /// <summary>
        /// Gets the items scroll-effect
        /// </summary>
        /// <returns></returns>
        public ScrollEffect GetScrollEffect() => myScrollEffect;

        public int GetStrengthBuff() => myStrengthBuff;

        public int GetArmourBuff() => myArmourBuff;

        public int GetHealthBuff() => myHealthBuff;

        #endregion Get

        #region Set

        /// <summary>
        /// Sets scroll's duration
        /// </summary>
        /// <param name="aDuration">Duration of the scroll represented in number of combat-rounds</param>
        public void SetScrollDuration(int aDuration) => myScrollDuration = aDuration;

        #endregion Set
    }
}