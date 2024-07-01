using System;

namespace AdventureQuestRPG
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }

        public Player(string name)
        {
            Name = name;
            Health = 100;
            AttackPower = 20;
            Defense = 10;
            Level = 1;
            Experience = 0;
        }

        public void GainExperience(int amount)
        {
            Experience += amount;
            if (Experience >= Level * 100)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Level++;
            Experience = 0;
            Health += 20;
            AttackPower += 5;
            Defense += 2;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Player Info:\nName: {Name} Health: {Health} AttackPower: {AttackPower} Defense: {Defense} Level: {Level} Experience: {Experience}");
        }
    }

    public abstract class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }

        public Monster(string name, int health, int attackPower, int defense)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
        }

        public virtual void Attack(Player player)
        {
            int damage = AttackPower - player.Defense;
            damage = damage > 0 ? damage : 0;

            player.Health -= damage;
            player.Health = player.Health < 0 ? 0 : player.Health;

            Console.WriteLine($"{Name} attacks {player.Name} for {damage} damage. {player.Name} now has {player.Health} health.");
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Monster Info:\nName: {Name} Health: {Health} AttackPower: {AttackPower} Defense: {Defense}");
        }
    }

    public class Zombi : Monster
    {
        public Zombi() : base("Zombi", 50, 15, 5) { }

        public override void Attack(Player player)
        {
            int damage = AttackPower - player.Defense;
            damage = damage > 0 ? damage : 0;

            player.Health -= damage;
            player.Health = player.Health < 0 ? 0 : player.Health;

            Console.WriteLine($"{Name} attacks {player.Name} for {damage} damage. {player.Name} now has {player.Health} health.");
        }
    }
}
