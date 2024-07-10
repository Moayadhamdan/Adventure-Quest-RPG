using System;
using System.Numerics;
using System.Threading;
namespace AdventureQuestRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Player player = new Player("Moayad");
                Adventure adventure = new Adventure(player);
                adventure.startGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}