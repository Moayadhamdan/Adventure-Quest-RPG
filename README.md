# Adventure Quest RPG

## Overview
Adventure Quest RPG is a console-based adventure game developed in C# using Visual Studio 2022. In this game, players embark on a thrilling journey, battle various monsters, and explore dungeons to complete their quest.

## Collaboration
This lab was made in collaboration with my colleague [Aya Alwahidi](https://github.com/AyaAl-wahidi).

## Project Components

### Main Method (Program.cs)
- **Initialization**:
  - Creates a new instance of the Player and initializes the adventure.

### Character Classes

#### Player Class
- Represents the player-controlled character with attributes such as `Name`, `Health`, `AttackPower`, `Defense`, `Level`, and `Experience`.
- Methods include `GainExperience(int amount)`, `LevelUp()`, and `DisplayInfo()`.

#### Monster Classes
- **Monster (Abstract Base Class)**:
  - Base class for all monsters with properties `Name`, `Health`, `AttackPower`, and `Defense`.
  - Implements `DisplayInfo()` method.

- **Individual Monsters**:
  - Subclasses like `Zombi`, `BossMonster`, `Dragon`, `Demon`, `Vampire`, `Ghost`, and `Ogre` inherit from `Monster` with specific attributes and behaviors.

### Battle System (BattleSystem.cs)

#### Attack Method
- **Attack(IBattleStates attacker, IBattleStates target)**:
  - Simulates an attack between two battle participants.
  - Calculates damage and updates the target's health based on the attacker's attack power and target's defense.

#### StartBattle Method
- **startBattle(Player player, Monster enemy)**:
  - Initiates a battle sequence between the player and a specified enemy monster.
  - Displays combat information and alternates turns between player and enemy until one is defeated.

### Leveling and Experience System

#### GainExperience Method
- **GainExperience(int amount)**:
  - Adds experience points to the player and triggers a level up when the experience threshold (`Level * 100`) is reached.

#### LevelUp Method
- **LevelUp()**:
  - Increases player's level and enhances attributes such as health, attack power, and defense.
  - Clears the list of defeated monsters and displays a level-up message.

### Game Features

- **Inventory Management**:
  - Allows the player to manage collected items including weapons, armor, and potions.
  - Provides options to use items from the inventory during gameplay.

- **Exploration and Location**
  - Players can explore different locations such as "Forest", "Cave", "Town", "City", and "Island".
  - The game dynamically updates the current location and offers choices for exploration.

### Error Handling and Input Validation

- Ensures robust error handling throughout the game to manage unexpected inputs and exceptions.
- Validates user inputs to prevent unintended behavior and maintain game stability.

### Testing

- Includes unit tests using XUnit to verify the functionality of critical methods such as attacking, leveling up, and inventory management.
- Ensures that expected game behaviors are consistent and reliable across different scenarios.

### Conclusion

Adventure Quest RPG provides an engaging gameplay experience with strategic battles, character progression, and exploration of diverse locations. Immerse yourself in this epic adventure and conquer the challenges that await!

