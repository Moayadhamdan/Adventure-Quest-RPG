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
            var battleSystem = new BattleSystem();
            
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
            battleSystem.StartBattle(player, enemy);

            // Assert
            Assert.True(player.Health > 0 || enemy.Health > 0);
        }

    }
}
