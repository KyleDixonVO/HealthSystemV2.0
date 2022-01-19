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
        public int defaultHealth = 100;
        public int defaultShield = 100;
        public int defaultLives = 3;
        public bool dead = false;

        private int remainder;

        public void TakeDamage(int damage)
        {
            Console.WriteLine("Incoming damage: " + damage);
            if (damage >= 0)
            {
                remainder = 0;
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
                        health = 0;
                        Die();
                    }
                }
               
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Damage must be a positive integer, or zero.");
                Console.ResetColor();
            }
           
            
        }

        public void ShowHud()
        {
            Console.WriteLine("");
            //Console.WriteLine("Player: " + name.ToString());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Shield: " + shield);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Lives: " + lives);
            Console.ResetColor();
            Console.WriteLine("");
        }

        public void Reset()
        {
            health = defaultHealth;
            shield = defaultShield;
            lives = defaultLives;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Reset.");
            Console.ResetColor();
        }

        public void Respawn()
        {
            health = defaultHealth;
            shield = defaultShield;
            Console.WriteLine("Player respawned!");
        }

        public void Die()
        {
            ShowHud();
            Console.WriteLine("Player lost a life!");
            if (lives > 0)
            {
                Respawn();
            }
            else
            {
                Console.WriteLine("Out Of lives!");
                lives = 0;
                dead = true;
                return;
            }
            lives--;
        }

        public void Heal(int HP)
        {
            if (HP >= 0 )
            {
                Console.WriteLine("Incoming healing: " + HP);
                health = health + HP;
                if (health > 100)
                {
                    int excess;
                    excess = health - 100;
                    int amountHealed;
                    amountHealed = HP - excess;
                    Console.WriteLine("Healed for: " + amountHealed);
                    health = 100;
                    Console.WriteLine("Cannot be healed further.");
                }
                else
                {
                    Console.WriteLine("Healed for: " + HP);
                    if (health == 100)
                    {
                        Console.WriteLine("Cannot be healed further.");
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("HP must be a positive integer or zero.");
                Console.ResetColor();
            }
                
        }

        public void RegenShield(int SP)
        {
            if (SP >= 0)
            {
                Console.WriteLine("Regenerating shield: " + SP);
                shield = shield + SP;
                if (shield > 100)
                {
                    int excess;
                    excess = shield - 100;
                    int amountRegen;
                    amountRegen = SP - excess;
                    Console.WriteLine("Regenerated shield by: " + amountRegen);
                    shield = 100;
                    Console.WriteLine("Cannot be reinforced further.");
                }
                else
                {
                    Console.WriteLine("Regenerated shield by: " + SP);
                    if (shield == 100)
                    {
                        Console.WriteLine("Cannot be reinforced further.");
                    }
                }
            }
            else
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SP must be a positive integer or zero.");
                Console.ResetColor();
            }
        }
    }

    class Program
    {

        public bool gameOver = false;
        static void Main(string[] args)
        {
            Player player = new Player();
            damageTest(player, 35);
            damageTest(player, 120);
            damageTest(player, 200);
            damageTest(player, -10);
            respawnTest(player);
            healTest(player, 50, 30);
            healTest(player, 30, 50);
            healTest(player, 0, -10);
            regenTest(player, 50, 30);
            regenTest(player, 30, 50);
            regenTest(player, 0, -10);
            Console.ReadKey(true);
        }

        static void damageTest(Player name, int damage)
        {
            Console.WriteLine("Damage test.");
            name.ShowHud();
            name.TakeDamage(damage);
            name.ShowHud();
            name.Reset();
            Console.ReadKey(true);
            Console.Clear();
        }

        static void healTest(Player name, int damage, int HP)
        {
            Console.WriteLine("Healing test.");
            name.shield = 0;
            name.ShowHud();
            name.TakeDamage(damage);
            name.ShowHud();
            name.Heal(HP);
            name.ShowHud();
            name.Reset();
            Console.ReadKey(true);
            Console.Clear();
        }

        static void regenTest(Player name, int damage, int SP)
        {
            Console.WriteLine("Shield regen test.");
            name.ShowHud();
            name.TakeDamage(damage);
            name.ShowHud();
            name.RegenShield(SP);
            name.ShowHud();
            name.Reset();
            Console.ReadKey(true);
            Console.Clear();
        }

        static void respawnTest(Player name)
        {
            Console.WriteLine("Respawn test.");
            name.ShowHud();
            name.TakeDamage(200);
            name.ShowHud();
            name.TakeDamage(200);
            name.ShowHud();
            name.TakeDamage(200);
            name.ShowHud();
            name.TakeDamage(200);
            name.ShowHud();
            name.Reset();
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
