

# Maze Game Assignment

This is a simple console-based maze game implemented in C#. The goal of the game is to navigate a character through a 10x10 maze from a starting point to an exit point, avoiding walls along the way. The maze features walls that block movement, and the player must find a path to the exit.

<img width="415" alt="Screenshot 2024-10-20 at 3 54 07 PM" src="https://github.com/user-attachments/assets/d564c361-03b5-46ce-b8e2-caea823f00b1">


## Game Features

- **Maze Layout**: A 10x10 grid representing the maze with walls, an exit, and a player starting position.
- **Player Movement**: Use arrow keys to navigate through the maze.
- **Collision Detection**: Walls block the player’s movement.
- **Exit Detection**: When the player reaches the exit, a congratulatory message is displayed, and the game ends.

## How to Play

1. Run the game in a console that supports UTF-8 encoding.
2. Use the arrow keys (⬆️ ⬇️ ⬅️ ➡️) to move your character in the maze.
3. Avoid hitting walls (🟫).
4. Reach the exit (🚪) to win the game.

## Game Symbols

- `🧍`: Player's current position
- `🟫`: Wall, blocking movement
- `🚪`: Exit, the goal of the maze
- `. `: Open space where the player can move

## Code Structure

### Main Game Loop

The main loop runs until the player reaches the exit, continuously rendering the maze and capturing player input to move the character.

### `MovePlayer` Function

The `MovePlayer` function handles:
- Processing arrow key input.
- Checking boundaries to ensure the player does not move outside the maze.
- Detecting collisions with walls and displaying a message if the player tries to move into a wall.
- Detecting if the player has reached the exit, ending the game with a congratulatory message.

## Example Code Snippet

```csharp
if (maze[newX, newY] == 'E')
{
    Console.Clear();
    maze[playerX, playerY] = '.';
    playerX = newX;
    playerY = newY;
    maze[playerX, playerY] = 'C';
    PrintMaze();
    Console.WriteLine("🎉 Congratulations! You've reached the exit!");
    Thread.Sleep(1500);
    gameOver = true;
}
```

## Requirements

- C# Console Application
- UTF-8 Console Support (for emojis)

## Installation and Setup

1. Clone or download this repository.
2. Open the project in a C# IDE (e.g., Visual Studio).
3. Run the application in a console that supports UTF-8 encoding.

## Notes

- Ensure your console supports UTF-8 encoding for proper display of emoji characters.
- The game pauses briefly when hitting a wall or reaching the exit for better user experience.

Enjoy navigating the maze!

## License

This project is for educational purposes. You are free to modify and use the code as you see fit.
