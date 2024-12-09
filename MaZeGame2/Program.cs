namespace MaZeGame;

internal class MazeGame
{
    private static readonly char[,] Maze = new char[10, 10]
    {
        { 'C', '.', '.', 'W', '.', '.', '.', '.', '.', '.' },
        { 'W', 'W', '.', 'W', '.', 'W', 'W', 'W', 'W', '.' },
        { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
        { '.', 'W', 'W', 'W', 'W', 'W', 'W', '.', 'W', '.' },
        { '.', 'W', '.', '.', '.', '.', 'W', '.', 'W', '.' },
        { '.', 'W', '.', 'W', 'W', '.', 'W', '.', '.', '.' },
        { '.', 'W', '.', '.', 'W', '.', '.', '.', 'W', '.' },
        { '.', '.', 'W', '.', '.', '.', 'W', '.', 'W', '.' },
        { '.', 'W', 'W', 'W', 'W', 'W', 'W', '.', '.', '.' },
        { '.', '.', '.', '.', '.', '.', '.', '.', '.', 'E' },
    };

    private static int _playerX = 0;
    private static int _playerY = 0;
    protected static bool GameOver = false;

    private static void Main(string[] args)
    {
        // Set the console to use UTF-8 encoding
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Solve the maze using DFS
        var pathToExit = SolveMaze(_playerX, _playerY);

        // Animate the AI solving the maze
        AnimatePath(pathToExit);
        Console.WriteLine("🎉 AI has successfully solved the maze!");
    }

    private static List<(int x, int y)>? SolveMaze(int startX, int startY)
    {
        var visited = new HashSet<(int x, int y)>();
        var path = new List<(int x, int y)>();

        var found = Dfs(startX, startY, visited, path);

        return found ? path : null;
    }

    private static bool Dfs(int x, int y, HashSet<(int x, int y)> visited, List<(int x, int y)>? path)
    {
        // Check bounds and if the cell is walkable
        if (x < 0 || x >= 10 || y < 0 || y >= 10 || Maze[x, y] == 'W' || visited.Contains((x, y)))
            return false;

        // Add current cell to the path and mark it as visited
        path?.Add((x, y));
        visited.Add((x, y));

        // Check if the exit is found
        if (Maze[x, y] == 'E')
            return true;

        // Explore neighbors (up, down, left, right)
        if (Dfs(x - 1, y, visited, path) || // Up
            Dfs(x + 1, y, visited, path) || // Down
            Dfs(x, y - 1, visited, path) || // Left
            Dfs(x, y + 1, visited, path))   // Right
            return true;

        // Backtrack: remove the cell from the path if no solution found
        path?.RemoveAt(path.Count - 1); //conditional ? access to path for null check
        return false;
    }

    private static void AnimatePath(List<(int x, int y)>? path)
    {
        foreach (var (x, y) in path)
        {
            Console.Clear();

            // Update the maze to show the AI's current position
            Maze[_playerX, _playerY] = '.'; // Clear the previous position
            _playerX = x;
            _playerY = y;
            Maze[_playerX, _playerY] = 'C'; // Update to the current position

            PrintMaze();
            Thread.Sleep(500); // Pause for animation

            // Stop animation when the exit is reached
            if (Maze[_playerX, _playerY] != 'E') continue;
            Console.Clear();
            PrintMaze();
            return; // Stop further animation
        }
    }

    private static void PrintMaze()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (Maze[i, j] == 'C')
                    Console.Write("🧍");
                else if (Maze[i, j] == 'W')
                    Console.Write("🁣 ");
                else if (Maze[i, j] == 'E')
                    Console.Write("🚪 ");
                else
                    Console.Write(". ");
            }
            Console.WriteLine();
        }
    }
}