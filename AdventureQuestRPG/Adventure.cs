﻿using AdventureQuestRPG;
public class Adventure
{
    private Player player;
    public BattleSystem battleSystem;
    public List<Monster> monsters;
    public List<string> locations;
    public string currentLocation;
    public Adventure(Player player)
    {
        this.player = player;
        battleSystem = new BattleSystem();
        monsters = new List<Monster>
        {
        new Zombi(),
        new BossMonster(),
        new Dragon(),
        new Demon(),
        new Vampire(),
        new Ogre(),
        new Ghost()
        };
        locations = new List<string>
        {
            "Forest",
            "Cave",
            "Town",
            "City",
            "Island"
        };
        currentLocation = "Town";
    }
    public void startGame()
    {
        while (true)
        {
            Console.WriteLine($"\n \nYou are currently in {currentLocation} location");
            displayActions();
            Run();
            if (player.Health <= 0)
            {
                Console.WriteLine("Game over!");
                break;
            }
        }
        Console.WriteLine("Adventure complete!");
    }
    public void displayActions()
    {
        Console.WriteLine("Please Choose an action:");
        Console.WriteLine("1. Discover a new location");
        Console.WriteLine("2. Attack the Monster");
        Console.WriteLine("3. View The Inventory");
        Console.WriteLine("4. End The Game");
    }
    public void Run()
    {
        int input = Convert.ToInt16(Console.ReadLine());
        switch (input)
        {
            case 1:
                discoverNewLocation();
                break;
            case 2:
                attackMonster();
                break;
            case 3:
                manageInventory();
                break;
            case 4:
                endtGame();
                break;
            default:
                break;
        }
    }
    public void discoverNewLocation()
    {
        Console.WriteLine("Please Select a location from the following list:");
        for (int i = 0; i < locations.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {locations[i]}");
        }
        if (int.TryParse(Console.ReadLine(), out int locationIndex) && locationIndex > 0 && locationIndex <= locations.Count)
        {
            currentLocation = locations[locationIndex - 1];
            Console.WriteLine($"You have arrived at {currentLocation}");
        }
        else
        {
            Console.WriteLine("Invalid location. Please try again.");
        }
    }
    public void attackMonster()
    {
        Random rand = new Random();
        List<Monster> availableMonsters = monsters.Where(m => !player.DefeatedMonsters.Contains(m.Name)).ToList();
        if (availableMonsters.Count > 0)
        {
            Monster selectedMonster = availableMonsters[rand.Next(availableMonsters.Count)];
            Console.WriteLine($"Randomly selected monster: {selectedMonster.Name}");
            battleSystem.startBattle(player, selectedMonster);
            if (selectedMonster.Health <= 0)
            {
                player.DefeatedMonsters.Add(selectedMonster.Name);
                selectedMonster.ResetHealth();
            }
        }
        else
        {
            Console.WriteLine("Congratulations! You have defeated all the monsters!");
            Environment.Exit(0);
        }
    }
    public void manageInventory()
    {
        player.inventory.displayInventory();
        if (player.inventory.Items.Count != 0)
        {
            if (int.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex > 0 && itemIndex <= player.inventory.Items.Count)
            {
                Item selectedItem = player.inventory.Items[itemIndex - 1];
                Console.WriteLine($"You have chosen to use: {selectedItem.Name}\nDo you want to use it? (Yes / No)");
                string useResponse = Console.ReadLine().ToLower();
                if (useResponse == "yes" || useResponse == "y")
                {
                    player.useItem(selectedItem);
                }
                else if (useResponse == "no" || useResponse == "n")
                {
                    Console.WriteLine("You chose not to use the item.");
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }
    }
    public static void endtGame()
    {
        Console.WriteLine("The End!");
        Environment.Exit(0);
    }
}