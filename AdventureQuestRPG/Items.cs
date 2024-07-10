using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdventureQuestRPG
{
    [Serializable]
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    [Serializable] 
    public class Weapon : Item
    {
        public int AttackBoost { get; set; }
    }

    [Serializable]
    public class Armor : Item
    {
        public int DefenseBoost { get; set; }
    }

    [Serializable]
    public class Potion : Item
    {
        public int HealthBoost { get; set; }
    }
}