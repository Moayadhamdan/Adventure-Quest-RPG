using System;
namespace AdventureQuestRPG
{
    public class Player : IBattleStates
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public Inventory inventory { get; set; }
        public List<string> DefeatedMonsters { get; set; }
        public Player(string name)
        {
            Name = name;
            Health = 100;
            //20
            AttackPower = 80;
            //10
            Defense = 50;
            Level = 1;
            Experience = 0;
            inventory = new Inventory();
            DefeatedMonsters = new List<string>();
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
            DefeatedMonsters.Clear();
            Console.WriteLine($"Congratulations! {Name} has reached level {Level}.");
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Player Info:\nName: {Name} Health: {Health} AttackPower: {AttackPower} Defense: {Defense} Level: {Level} Experience: {Experience}");
        }
        public void useItem(Item item)
        {
            if (item != null)
            {
                if (item is Weapon weapon)
                {
                    AttackPower += weapon.AttackBoost;
                    Console.WriteLine($"You equipped a {item.Name}, and your AttackPower increased by {weapon.AttackBoost} points.");
                }
                else if (item is Potion potion)
                {
                    Health += potion.HealthBoost;
                    Console.WriteLine($"You used a {item.Name}, and your Health increased by {potion.HealthBoost} points.");
                }
                else if (item is Armor armor)
                {
                    Defense += armor.DefenseBoost;
                    Console.WriteLine($"You equipped a {item.Name}, and your Defense increased by {armor.DefenseBoost} points.");
                }
                inventory.removeItem(item);
                Console.WriteLine($"{item.Name} has been removed from your inventory.");
            }
            else
            {
                Console.WriteLine("You didn't have any item.");
            }
        }
    }
    public abstract class Monster : IBattleStates
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public int InitialHealth { get; private set; }
        public Monster(string name, int health, int attackPower, int defense)
        {
            Name = name;
            Health = health;
            InitialHealth = health;
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
        public void ResetHealth()
        {
            Health = InitialHealth;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Monster Info:\nName: {Name}, Health: {Health}, AttackPower: {AttackPower}, Defense: {Defense}");
        }
    }
    public class Zombi : Monster
    {
        public Zombi() : base("Zombi", 50, 15, 5) { }
    }
    public class BossMonster : Monster
    {
        public BossMonster() : base("BossMonster", 1, 5, 2) { }
    }
    public class Dragon : Monster
    {
        public Dragon() : base("Dragon", 60, 15, 10) { }
    }
    public class Demon : Monster
    {
        public Demon() : base("Demon", 50, 25, 5) { }
    }
    public class Vampire : Monster
    {
        public Vampire() : base("Vampire", 50, 25, 5) { }
    }
    public class Ghost : Monster
    {
        public Ghost() : base("Ghost", 50, 25, 5) { }
    }
    public class Ogre : Monster
    {
        public Ogre() : base("Ogre", 50, 25, 5) { }
    }
}