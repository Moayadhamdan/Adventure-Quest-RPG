using System;
namespace AdventureQuestRPG
{
    public class BattleSystem
    {
        public void Attack(IBattleStates attacker, IBattleStates target)
        {
            int damage = attacker.AttackPower - target.Defense;
            damage = damage > 0 ? damage : 0;
            target.Health -= damage;
            target.Health = target.Health < 0 ? 0 : target.Health;
            Console.WriteLine($"{attacker.Name} attacks {target.Name} for {damage} damage. {target.Name} now has {target.Health} health.");
        }
        public void startBattle(Player player, Monster enemy)
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
                        Console.WriteLine($"{player.Name},You are in level : {player.Level}");
                        handleDroppedItems(player);
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
        public void handleDroppedItems(Player player)
        {
            Random rand = new Random();
            int chance = rand.Next(0, 100);
            if (chance < 30)
            {
                Console.WriteLine(" ** You have 1 item added to your inventory");
                var item = randomPickItem();
                player.inventory.addItem(item);
            }
            else
            {
                Console.WriteLine(" ** No item dropped this time.");
            }
        }
        public Item randomPickItem()
        {
            Random rand = new Random();
            int res = rand.Next(0, 2);
            switch (res)
            {
                case 0:
                    return new Weapon { Name = "Gun", Description = "Contains lethal lead", AttackBoost = 10 };
                    break;
                case 1:
                    return new Armor { Name = "Shield", Description = "Provide safety", DefenseBoost = 5 };
                    break;
                case 2:
                    return new Potion { Name = "Health Dose", Description = "Increases health", HealthBoost = 20 };
                    break;
                default:
                    return null;
            }
        }
    }
}