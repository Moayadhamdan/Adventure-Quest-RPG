using System;
namespace AdventureQuestRPG
{
    public class BattleSystem
    {
        public void Attack(Player attacker,Monster target)
        {
            int damage = attacker.AttackPower - target.Defense;
            damage = damage > 0 ? damage : 0;

            target.Health -= damage;
            target.Health = target.Health < 0 ? 0 : target.Health;

            Console.WriteLine($"{attacker.Name} attacks {target.Name} for {damage} damage. {target.Name} now has {target.Health} health.");
        }

        public void StartBattle(Player player, Monster enemy)
        {
            try
            {
                player.DisplayInfo();
                enemy.DisplayInfo();
                while (player.Health > 0 && enemy.Health > 0)
                {
                    Console.WriteLine("Player's turn:");
                    Attack(player, enemy);
                    if (enemy.Health <= 0)
                    {
                        Console.WriteLine("You have defeated the monster!");
                        player.GainExperience(50);
                        Console.WriteLine($"{player.Name} leveled up to level {player.Level}!");
                        break;
                    }
                    Console.WriteLine("Enemy's turn:");
                    enemy.Attack(player);
                    if (player.Health <= 0)
                    {
                        Console.WriteLine("You have been defeated by the monster!");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
