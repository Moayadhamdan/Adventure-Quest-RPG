using AdventureQuestRPG;
using System.Text.Json;

public class Adventure
{
    private Player player;
    public BattleSystem battleSystem;
    public List<Monster> monsters;
    public List<string> locations;
    public string currentLocation;
    private bool gameLoaded = false;

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
        if (gameLoaded)
        {
            gameLoaded = false;
            Console.WriteLine($"Resuming game from {currentLocation}...");
            Run();
        }
        else
        {
            while (true)
            {
                Console.WriteLine($"\n\nYou are currently in {currentLocation} location");
                displayActions();
                Run();
                if (player.Health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game over!");
                    Console.ResetColor();
                    break;
                }
            }
            Console.WriteLine("Adventure complete!");
        }
    }

    public void displayActions()
    {
        Console.WriteLine("Please Choose an action:");
        Console.WriteLine("1. Discover a new location");
        Console.WriteLine("2. Attack the Monster");
        Console.WriteLine("3. View The Inventory");
        Console.WriteLine("4. Save Game");
        Console.WriteLine("5. Load Game");
        Console.WriteLine("6. End The Game");
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
                SaveGame();
                break;
            case 5:
                LoadGame();
                break;
            case 6:
                endtGame();
                break;
            default:
                Console.WriteLine("Invalid Input!");
                break;
        }
    }

    public string discoverNewLocation()
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
        return currentLocation;
    }

    public void attackMonster()
    {
        Random rand = new Random();
        List<Monster> availableMonsters = monsters.Where(m => !player.DefeatedMonsters.Contains(m.Name)).ToList();
        if (availableMonsters.Count > 0)
        {
            Monster selectedMonster = availableMonsters[rand.Next(availableMonsters.Count)];
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Randomly selected monster: {selectedMonster.Name}");
            Console.ResetColor();
            battleSystem.startBattle(player, selectedMonster);
            if (selectedMonster.Health <= 0)
            {
                player.DefeatedMonsters.Add(selectedMonster.Name);
                selectedMonster.ResetHealth();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congratulations! You have defeated all the monsters!");
            Console.ResetColor();
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

    public void SaveGame()
    {
        GameState gameState = new GameState
        {
            Player = this.player,
            CurrentLocation = this.currentLocation
        };

        string json = JsonSerializer.Serialize(gameState);
        File.WriteAllText("gameFile.json", json);
        Console.WriteLine("Game saved successfully!");
    }

    public void LoadGame()
    {
        try
        {
            if (File.Exists("gameFile.json"))
            {
                string json = File.ReadAllText("gameFile.json");
                GameState gameState = JsonSerializer.Deserialize<GameState>(json);
                this.player = gameState.Player;
                this.currentLocation = gameState.CurrentLocation;
                Console.WriteLine("Game loaded successfully!");
                gameLoaded = true;
            }
            else
            {
                Console.WriteLine("You don't have game saved yet, \nYou should select save game from the actions list!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load game: {ex.Message}");
        }
    }

    public static void endtGame()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The End!");
        Console.ResetColor();
        Environment.Exit(0);
    }
}