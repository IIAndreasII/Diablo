using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Enemies
{
    class Enemy
    {
        public void TakeDamage(int aDamageToTake, int anArmourRating, float aHealth)
        {
            float tempDamageDealt = aDamageToTake * (1f - (float)anArmourRating / 100f);
            aHealth -= tempDamageDealt;
            Console.WriteLine("You swing your sword and strike the enemy!");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("You dealt ");
        }

        public void DealDamage(Player.Player aPlayer, int aDamage)
        {
            float tempDamageDealt;
            aPlayer.TakeDamage(aDamage, aPlayer.GetIsDefending(), out tempDamageDealt);
            Console.WriteLine("You took ");
            Utilities.Utility.PrintInColour(tempDamageDealt.ToString(), ConsoleColor.Red);
            Console.Write(" damage!");
            System.Threading.Thread.Sleep(1000);
        }
    }
}