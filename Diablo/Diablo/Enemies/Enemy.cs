using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Enemies
{
    public enum Type
    {
        SWORDSMAN,
        ARCHER,
        CAPTAIN
    }

    class Enemy
    {
        public float TakeDamage(int aDamageToTake, int anArmourRating, float aHealth, int aStrength, int anAgility)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            float 
                tempDamageDealt = aDamageToTake * (1 + (float)aStrength / 100) * (1f - (float)anArmourRating / 100f);          
            Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 11);
            Console.Write("You swing your sword!");
            System.Threading.Thread.Sleep(1000);
            if (Utilities.Utility.myRNG.Next(1, 101) > anAgility)
            {
                aHealth -= tempDamageDealt;
                Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 9);
                Console.Write("You dealt ");
                Utilities.Utility.PrintInColour(tempDamageDealt.ToString(), ConsoleColor.Green);
                Console.Write(" damage!");
            }
            else
            {
                Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 9);
                Console.Write("You missed the enemy!");
            }
            if (aHealth <= 0)
            {
                System.Threading.Thread.Sleep(1000);
                Console.SetCursorPosition(tempWWD2 - 8, tempWHD2 - 7);
                Console.Write("Enemy defeated!");
            }
            System.Threading.Thread.Sleep(2000);
            return aHealth;
        }

        public void DealDamage(Player.Player aPlayer, float aDamage)
        {
            int
                tempWWD2 = Console.WindowWidth / 2,
                tempWHD2 = Console.WindowHeight / 2;
            float 
                tempDamageDealt;
            aPlayer.PrintUI();
            Console.SetCursorPosition(tempWWD2 - 14, tempWHD2 - 11);
            Console.WriteLine("The enemy swings his sword!");
            System.Threading.Thread.Sleep(1000);
            if(aPlayer.TakeDamage(aDamage, out tempDamageDealt))
            {
                Console.SetCursorPosition(tempWWD2 - 10, tempWHD2 - 9);
                Console.Write("You took ");
                Utilities.Utility.PrintInColour(tempDamageDealt.ToString(), ConsoleColor.Red);
                Console.Write(" damage!");
            }
            else
            {
                Console.SetCursorPosition(tempWWD2 - 11, tempWHD2 - 9);
                Console.Write("You evaded the strike!");
            }
            System.Threading.Thread.Sleep(2000);
        }
    }
}