using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LäroverketFighters
{
    class Boss : Enemy 
    {
        int armor = 2, critChance = 10; //10%, critChance is procentage
        int critMultiplier = 2;
        public override void TakeDamage(int _damage)
        {
            int actualDamage = _damage - armor;
            hp -= actualDamage;

            Console.WriteLine(actualDamage);

            if (hp < 0)
            {
                isAlive = false;
            }

        }

        public override void DecideAction()
        {
            //if the number is lower than the crit chance, then crit
            if (randomness.Next(1, 100) <= critChance)
            {
                AttackCrit();
            }
            else
            {
                base.DecideAction();
            }
        }


        void AttackCrit()
        {
            Console.WriteLine("BOSS CRIT ATTACK");
        }
        
    }
}
