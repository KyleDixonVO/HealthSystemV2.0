using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemV2._0
{
    class Player
    {
        public int health = 100;
        public int lives = 3;
        public int shield = 100;
        private int remainder;

        public void TakeDamage(int damage)
        {
            Console.WriteLine("Incoming damage: " + damage);
            if (damage >= 0)
            {
                shield = shield - damage;
                if (shield < 0 )
                {
                    remainder = shield;
                    shield = 0;
                }

                if (shield == 0)
                {
                    health = health + remainder;
                    if (health <= 0)
                    {
                        lives--;
                        Console.WriteLine("Player lost a life!");
                    }
                }
               
            }
            else
            {
                Console.WriteLine("Damage must be a positive integer, or zero.");
            }
           
            
        }

        public void ShowHud()
        {
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Shield: " + shield);
            Console.WriteLine("Lives: " + lives);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.TakeDamage(35);
        }

    }
}
