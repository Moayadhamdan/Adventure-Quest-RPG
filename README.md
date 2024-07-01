# Adventure Quest RPG

## Overview
Adventure Quest RPG is a console-based adventure game where players can go on an epic journey, battle monsters, and explore dungeons. The game is developed using C# in Visual Studio 2022.

## Collaboration
This lab was made in collaboration with my colleague [Aya Alwahidi](https://github.com/AyaAl-wahidi).

## Lab Specifications

### Main Method (Program.cs)
- **Logic**:
  - Create instances of the Player and a Monster.
  - Call the `StartBattle()` method.
  - Display "Adventure complete!" if you successfully complete the game (defeating the monsters).

### Character Classes
- **Player Class**:
  - Represents the player-controlled character.
  - Properties: `Name`, `Health`, `AttackPower`, `Defense`, `Level`, and `Experience`.
  - Methods: `GainExperience(int amount)`, `LevelUp()`, and `DisplayInfo()`.

- **Monster Class**:
  - Abstract base class representing monsters in the game.
  - Properties: `Name`, `Health`, `AttackPower`, and `Defense`.
  - Abstract method: `Attack(Player player)` (optional for extending monster types with unique attacks).
  - Method: `DisplayInfo()`.

- **Zombi Class**:
  - Inherits from `Monster`.
  - Implements the `Attack(Player player)` method.

### Attack Method (BattleSystem.cs)
- **Attack Method**:
  - Simulates an attack between two battle classes.
  - Parameters: attacker and target.
  - Calculates and applies damage, ensuring it is never negative.
  - Reduces the target's health by the calculated damage amount.
  - Displays attack details including names, damage dealt, and updated health.

### StartBattle Method (BattleSystem.cs)
- **StartBattle Method**:
  - Initiates a battle between a player character and an enemy monster.
  - Parameters: player character (player) and enemy monster (enemy).
  - Displays player and monster information before the start of the fight.
  - Enters a loop that continues as long as the player or the enemy has health greater than zero.
  - Handles player and enemy turns by calling the `Attack` method.
  - Displays victory or defeat messages and ends the battle accordingly.

### Leveling System
- **GainExperience Method**:
  - Player gains experience points from defeating monsters.
  - Experience threshold for leveling up: `Level * 100`.
  - Calls `LevelUp()` when the experience threshold is reached.

- **LevelUp Method**:
  - Increases player's level.
  - Resets experience to 0.
  - Increases player's health, attack power, and defense.
  - Displays level-up message.

### Multi-Round Battles
- The game allows multiple rounds of battles.
- After each victory, the player is prompted to continue fighting or quit.
- The player's health is restored based on their current level at the start of each new round.

### Error Handling
- Handles exceptions during the game.
- Ensures input validation to prevent unexpected behavior.

### XUnit Tests
- Tests for `Attack` method to ensure it correctly reduces the target's health (for both player and enemy).
- Asserts that the winner's health is greater than zero after winning the battle.