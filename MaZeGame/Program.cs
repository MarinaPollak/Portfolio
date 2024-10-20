using System.Threading; // To use Thread.Sleep

namespace MaZeGame
{
    internal class Program
    {

        class MazeGame
        {
            static char[,] maze = new char[10, 10]
            {
                { 'C', '.', '.', 'W', '.', '.', '.', '.', '.', '.' },
                { 'W', 'W', '.', 'W', '.', 'W', 'W', 'W', 'W', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.', 'W', '.' },
                { '.', 'W', 'W', 'W', 'W', 'W', 'W', '.', 'W', '.' },
                { '.', 'W', '.', '.', '.', '.', 'W', '.', 'W', '.' },
                { '.', 'W', '.', 'W', 'W', '.', 'W', '.', '.', '.' },
                { '.', 'W', '.', '.', 'W', '.', '.', '.', 'W', '.' },
                { '.', '.', 'W', '.', '.', '.', 'W', '.', 'W', '.' },
                { '.', 'W', 'W', 'W', 'W', 'W', 'W', '.', '.', '.' },
                { '.', '.', '.', '.', '.', '.', '.', '.', 'E', 'W' },
            };

            static int playerX = 0;
            static int playerY = 0;
            static bool gameOver = false;

            static void Main(string[] args)
            {
                // Set the console to use UTF-8 encoding
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                while (!gameOver)
                {
                    // Clear the console to avoid clutter
                    Console.Clear();

                    PrintMaze();
                    Console.WriteLine("Move using arrow keys: 👆🏼 👇🏼 👈🏼 👉🏼");

                    // Capture arrow key input
                    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                    MovePlayer(keyInfo);
                }
            }

            static void PrintMaze()
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (maze[i, j] == 'C')
                            Console.Write("🧍 ");
                        else if (maze[i, j] == 'W')
                            Console.Write("🧱 ");
                        else if (maze[i, j] == 'E')
                            Console.Write("🚪 ");
                        else
                            Console.Write(". ");
                    }

                    Console.WriteLine();
                }
            }

            static void MovePlayer(ConsoleKeyInfo keyInfo)
            {
                int newX = playerX;
                int newY = playerY;

                // Handle arrow key input
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: // ⬆️
                        newX--;
                        break;
                    case ConsoleKey.DownArrow: // ⬇️
                        newX++;
                        break;
                    case ConsoleKey.LeftArrow: // ⬅️
                        newY--;
                        break;
                    case ConsoleKey.RightArrow: // ➡️
                        newY++;
                        break;
                    default:
                        Console.WriteLine("Invalid move. Use arrow keys.");
                        return;
                }

                // Ensure the new position is within bounds
                if (newX >= 0 && newX < 10 && newY >= 0 && newY < 10)
                {
                    // Check if the player reached the exit
                    if (maze[newX, newY] == 'E')
                    {
                        // Print the maze one last time after reaching the exit
                        Console.Clear();
                        maze[playerX, playerY] = '.';
                        playerX = newX;
                        playerY = newY;
                        maze[playerX, playerY] = 'C';
                        PrintMaze();
                        Console.WriteLine("🎉 Congratulations! You've reached the exit!");
                        Thread.Sleep(1500); // Delay for 1.5 seconds
                        gameOver = true;
                    }
                    // Check if it's a wall
                    else if (maze[newX, newY] != 'W')
                    {
                        // Update player position
                        maze[playerX, playerY] = '.';
                        playerX = newX;
                        playerY = newY;
                        maze[playerX, playerY] = 'C';
                    }
                    else
                    {
                        Console.WriteLine("You hit a wall! Try again.");
                        Thread.Sleep(1500); // Delay for 1.5 seconds
                    }
                }
            }
        }
    }

}


