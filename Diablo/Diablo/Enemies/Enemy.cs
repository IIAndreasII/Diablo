using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Enemies
{
    class Enemy
    {
        public void TakeDamage(int aDamageToTake, int anArmourRating, float aHealth)
        {
            aHealth -= aDamageToTake * (1f - (float)anArmourRating / 100f);
        }

        public void DealDamage(Player.Player aPlayer, int aDamage)
        {
            float tempDamageDealt = 0;
            aPlayer.TakeDamage(aDamage, aPlayer.GetIsDefending(), out tempDamageDealt);
            Console.WriteLine("You took ");
            Program.PrintInColour(tempDamageDealt.ToString(), ConsoleColor.Red);
            Console.Write(" damage!");
        }
    }
}
