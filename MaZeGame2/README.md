
# Maze Game with AI Solver

This project is a console-based maze game implemented in C#. The game includes an **AI solver** that uses a **Depth-First Search (DFS)** algorithm to navigate the maze from the starting point to the exit. The solution is visually animated to demonstrate the AI's pathfinding process.

---

## Features

1. **Maze Layout**:
   - A 10x10 grid where:
     - `🧍` represents the player.
     - ` 🁣 ` represents walls.
     - `🚪` represents the exit.
     - `. ` represents walkable paths.

2. **Player Movement**:
   - The player or AI navigates through the maze step-by-step.

3. **AI Solver**:
   - Implements a **Depth-First Search (DFS)** algorithm to find a path from the start to the exit.
   - Returns a list of coordinates representing the solution path.

4. **Path Animation**:
   - The AI's solution is animated by moving the character along the calculated path.
   - The animation pauses briefly at each step to visually simulate the process.

---

## How It Works

1. **Depth-First Search (DFS)**:
   - The AI explores all valid neighboring cells (up, down, left, right) recursively.
   - If it finds the exit (`'E'`), it stops and returns the path.
   - Avoids revisiting cells by maintaining a `visited` set.

2. **Path Animation**:
   - The AI moves through the maze step-by-step along the returned path.
   - The console updates to show the character's position at each step, pausing briefly to simulate the animation.

3. **Avoiding Cycles**:
   - The algorithm prevents revisiting cells by tracking visited nodes, avoiding infinite loops.

---

## Gameplay Instructions

1. **Run the Program**:
   - Ensure you have a UTF-8 compatible console for proper display of emojis.

2. **AI Animation**:
   - The AI starts at the player's position (`🧍`) and moves step-by-step toward the exit (`🚪`).
   - The game concludes when the AI reaches the exit.

---

## Code Overview

### `SolveMaze()` Function
This function initializes the DFS algorithm and returns the solution path if the exit is found.

### `DFS()` Function
Performs the recursive depth-first search:
- Checks bounds, walls, and visited nodes.
- Explores neighbors until the exit is found.

### `AnimatePath()` Function
Simulates the AI solving the maze:
- Iterates through the solution path.
- Updates the player's position in the maze and redraws it on the console.

### Example DFS Logic
```csharp
if (maze[x, y] == 'E')
    return true;

if (DFS(x - 1, y, visited, path) || // Up
    DFS(x + 1, y, visited, path) || // Down
    DFS(x, y - 1, visited, path) || // Left
    DFS(x, y + 1, visited, path))   // Right
    return true;
```

---

## Future Enhancements

1. **Doors and Keys**:
   - Add locked doors (`'D'`) and keys (`'K'`) to the maze, requiring the AI to find keys to open doors.

2. **Dynamic Maze Generation**:
   - Implement random maze generation to make the game different each time.

3. **Alternative Algorithms**:
   - Compare DFS with Breadth-First Search (BFS) or A* search for optimized solutions.

4. **Handling Cyclical Paths**:
   - Introduce cycles in the maze and update the DFS logic to handle them effectively.

---

## Requirements

- **C# Console Application**
- **UTF-8 Console Support**

---

## How to Run

1. Clone or download the project.
2. Open the project in a C# IDE (e.g., Visual Studio).
3. Run the application and watch the AI solve the maze step-by-step.

---

## Example Output

### Initial Maze
```
🧍 . . 🁣 . . . . . . 
🁣 🁣 . 🁣 . 🁣 🁣 🁣 🁣 . 
. . . . . . . . 🁣 . 
. 🁣 🁣 🁣 🁣 🁣 🁣 . 🁣 . 
. 🁣 . . . . 🁣 . 🁣 . 
. 🁣 . 🁣 🁣 . 🁣 . . . 
. 🁣 . . 🁣 . . . 🁣 . 
. . 🁣 . . . 🁣 . 🁣 . 
. 🁣 🁣 🁣 🁣 🁣 🁣 . . . 
. . . . . . . . 🚪 🁣
```

### Animated Solution
- The AI moves step-by-step through the maze, visually updating the player's position (`🧍`) in the console.

---

## License

This project is for educational purposes. You are free to modify and use the code as you see fit.

---

## Author

Developed as part of a programming assignment to demonstrate depth-first search (DFS) and pathfinding algorithms in C#.
