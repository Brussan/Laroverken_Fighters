using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Läroverketfigthers

{
    class Program
    {
        static Random randomness = new Random();
        static int playerHP = randomness.Next(10, 20);
        static int enemyHP = randomness.Next(8, 18);

        static int playerDmg = randomness.Next(2, 5);
        static int enemyDmg = randomness.Next(2, 4);

        static string userInput;
        static void Main(string[] args)
        {
            Console.Title = "Lennart Bladh";
            Console.SetWindowSize(35, 10);





            //Game loop. As long as both lives, do this
            while (playerHP > 0 && enemyHP > 0 )
            {
                Console.Clear();

                DisplayStats();

                

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("1: Attack \n2: Heal\n\nUser input:");
                userInput = Console.ReadLine();
                
                //User Choice
                if (userInput == "1") //attack
                {
                    playerDmg = randomness.Next(2, 5);
                    enemyHP -= playerDmg;


                    Console.WriteLine("Player attacked for " + playerDmg);


                }
                    else if (userInput == "2")//heal
                {
                    int healAmount = randomness.Next(1, 2);
                    playerHP += healAmount;
                    Console.WriteLine("Player healed for " + healAmount);
                }
                else //Invalid menu input
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid input!");
                    Console.ReadKey();//pause until user presses key

                    continue;
                }

                EnemyTurn();

                Console.ReadKey();//pause until user presses key
            }  //End of while loop

            //When we are here someone is dead
            if (enemyHP < 1 )
            {
                //if enemy died
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nEnemy Diededed");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nYou dieded! git gud");

            }
            
            
            Console.Read();
        }

        static void EnemyTurn()
        {
            if(randomness.Next(0, 10) >= 7) //enemy heals if number is greater than X
            {
                int healAmount = randomness.Next(1, 2);
                enemyHP += healAmount;
                Console.WriteLine("Enemy healed for " + healAmount);
            }
            else
            {
                //Enemy Attacks
                enemyDmg = randomness.Next(2, 4);
                playerHP -= enemyDmg;


                Console.WriteLine("Enemy attacked for " + enemyDmg);
            }
            
         
        }

        static void DisplayStats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player HP:" + playerHP);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enemy HP:" + enemyHP);
        }
    }
}
