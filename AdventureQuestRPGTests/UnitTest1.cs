using Xunit;
using AdventureQuestRPG;

namespace AdventureQuestRPGTests
{
    public class UnitTest1
    {
        [Fact]
        public void PlayerAttackReducesEnemyHealth()
        {
            // Arrange
            var player = new Player("Moayad");
            var enemy = new Zombi();
            var battleSystem = new BattleSystem();
            
            // Act
            battleSystem.Attack(player, enemy);
            
            // Assert
            Assert.True(enemy.Health < 50);  
        }

        [Fact]
        public void EnemyAttackReducesPlayerHealth()
        {
            // Arrange
            var player = new Player("Moayad");
            var enemy = new Zombi();
            
            // Act
            enemy.Attack(player);
            
            // Assert
            Assert.True(player.Health < 100);  
        }

        [Fact]
        public void WinnerHasHealthGreaterThanZero()
        {
            // Arrange
            var player = new Player("Moayad");
            var enemy = new Zombi();
            var battleSystem = new BattleSystem();
            
            // Act
            battleSystem.startBattle(player, enemy);

            // Assert
            Assert.True(player.Health > 0 || enemy.Health > 0);
        }

        [Fact]
        public void CheckPlayerFindBossMonster()
        {
            // Arrange
            var player = new Player("Moayad");
            var bossMonster = new BossMonster();
            var battleSystem = new BattleSystem();
            // Act
            battleSystem.startBattle(player, bossMonster);
            // Assert
            Assert.True(player.Health == 0);
        }

        [Fact]
        public void CheckMoveToNewLocation()
        {
            // Arrange
            var player = new Player("Moayad");
            var adventure = new Adventure(player);
            var input = new StringReader("2");
            var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);
            
            // Act
            var result = adventure.discoverNewLocation();

            // Assert
            Assert.Equal("Cave", result);
            Assert.Contains("You have arrived at Cave", output.ToString());
            
            //// Cleanup
            //Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            //Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

    }
}
