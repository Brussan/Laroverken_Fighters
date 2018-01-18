using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LäroverketFighters
{
    class Enemy
    {
        int hp;
        public int dmg;
        public string name;
        public bool isAlive = true;

        public void Setup()
        {
            Random randomness = new Random();

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

        public void TakeDamage(int _damage)
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
