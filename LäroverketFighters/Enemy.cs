using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LäroverketFighters
{
    class Enemy
    {
        protected Random randomness = new Random();

        protected int hp;
        public int dmg;
        public string name;
        public bool isAlive = true;

        //Klassens konstruktor
        public Enemy()
        {

            Setup();
        }

        private void Setup()
        {

            hp = randomness.Next(10, 20);
            dmg = randomness.Next(2, 6);

            string[] namesToPick =
            {
                "Danne", //0
                "Gunnar", //1
                "Kristina", //2
                "Branko", //3
                "Hero",  //4
                "Nicke", //5
                "Nehmet", //6
                "G4" //7
            };
            name = namesToPick[randomness.Next(0, namesToPick.Length)];
         }//end of void setup


        public virtual void DecideAction()
        {

            if (randomness.Next(0, 10) >= 7) //Enemy heals if number is greater than X
            {
                int healAmount = randomness.Next(2, 6);
               Heal(healAmount);
                Console.WriteLine(name + " healed for " + healAmount);
            }
            else
            {
                //Enemy attacks
               dmg = randomness.Next(2, 4);
                Program.playerHP -=dmg; //TODO Remove this Program.PlayerHP, make system

                Console.WriteLine(name + " attacked for " +dmg);
            }
        }

        public virtual void TakeDamage(int _damage)
        {
            hp -= _damage;

            if (hp < 0)
            {
                isAlive = false;
            }
        }



        public void Heal(int _healAmount)
        {
            hp += _healAmount;
        }

        public void DisplayInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(name + "'s HP:" + hp);
        }

    }//End of class
}
