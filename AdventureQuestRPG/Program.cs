using System;

namespace AdventureQuestRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Player player = new Player("Moayad");
                BattleSystem battleSystem = new BattleSystem();

                while (true)
                {
                    Monster enemy = new Zombi();
                    battleSystem.StartBattle(player, enemy);

                    if (player.Health <= 0)
                    {
                        Console.WriteLine("Game over!");
                        break;
                    }



                    Console.WriteLine("Do you want to fight another round? (yes/no)");
                    string response = Console.ReadLine().ToLower();
                    if (response != "yes")
                    {
                        break;
                    }

                    // Restore player's health for the next round
                    player.Health = 100 + (player.Level - 1) * 20;
                }

                Console.WriteLine("Adventure complete!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
