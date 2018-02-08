using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LäroverketFighters
{
    class Program
    {
        //Skapar ett objekt från Enemy byggritningen (klass)
        static Boss enemy = new Boss();
        

        static Random randomness = new Random();
        public static int playerHP = randomness.Next(10, 20);

        static int playerDmg = randomness.Next(2, 6);

        static string userInput;

        static void Main(string[] args)
        {
            Console.Title = "Läroverket Fighters";
            Console.SetWindowSize(35, 10);



            //Game loop. As long as both lives, do this
            while (playerHP > 0 && enemy.isAlive == true)
            {
                Console.Clear();

                DisplayStats();



                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("1: Attack \n2: Heal\n\nUser input:");
                userInput = Console.ReadLine();

                //User choice
                if (userInput == "1") //Player attack
                {
                    playerDmg = randomness.Next(2, 6);
                   enemy.TakeDamage(playerDmg);

                    Console.WriteLine("Player attacked for " + playerDmg);
                }
                else if (userInput == "2") //Player heal 
                {
                    int healAmount = randomness.Next(2, 6);
                    playerHP += healAmount;
                    Console.WriteLine("Player healed for " + healAmount);

                }
                else //invalid menu input
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write("Invalid Input!");

                    Console.ReadKey(); //pause until user presses key
                    continue;
                }

                enemy.DecideAction();

                Console.ReadKey(); //pause until user presses key
            } //end of while loop

            //When we are here someone died.
            if (enemy.isAlive == false)
            {
                //If enemy died
                Console.Write("\n" + enemy.name + " died!");
            }
            else
            {
                Console.Write("\nYou died!");
            }


            Console.Read();
        }

    

        static void DisplayStats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player HP:" + playerHP);

           enemy.DisplayInfo();
        }
    }
}