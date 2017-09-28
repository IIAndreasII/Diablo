using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Enemies
{
    class Enemy
    {
        public float TakeDamage(int aDamageToTake, int anArmourRating, float aHealth)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            float 
                tempDamageDealt = aDamageToTake * (1f - (float)anArmourRating / 100f);          
            aHealth -= tempDamageDealt;
            Console.SetCursorPosition(tempWWD2 - 21, tempWHD2 - 11);
            Console.Write("You swing your sword and strike the enemy!");
            System.Threading.Thread.Sleep(1000);
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 9);
            Console.Write("You dealt ");
            Utilities.Utility.PrintInColour(tempDamageDealt.ToString(), ConsoleColor.Green);
            Console.Write(" damage!");
            System.Threading.Thread.Sleep(2000);           
            return aHealth;
        }

        public void DealDamage(Player.Player aPlayer, int aDamage)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            float 
                tempDamageDealt;
            aPlayer.PrintUI();
            aPlayer.TakeDamage(aDamage, aPlayer.GetIsDefending(), out tempDamageDealt);
            Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 11);
            Console.WriteLine("The enemy swings his sword!");
            Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 9);
            System.Threading.Thread.Sleep(1000);
            Console.Write("You took ");
            Utilities.Utility.PrintInColour(tempDamageDealt.ToString(), ConsoleColor.Red);
            Console.Write(" damage!");
            System.Threading.Thread.Sleep(2000);
        }
    }
}