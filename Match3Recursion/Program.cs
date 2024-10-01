    namespace Match3Recursion
{
    using System;

    class CandyCrushGame
    {
        static int[,] grid = new int[4, 5]
        {
        { 1, 2, 3, 2, 1 },
        { 2, 2, 1, 2, 2 },
        { 1, 3, 3, 1, 1 },
        { 1, 2, 3, 3, 1 }
        };

        static bool[,] newDigits = new bool[4, 5]; // Track where new digits are added
        static int matchCount = 0;
        static Random random = new Random();

        static void Main(string[] args)
        {
            Intialize();
        }

        private static void Intialize()
        {
            while (true)
            {
                // Display the grid
                DisplayGrid();

                // Reset the newDigits array to false
                ResetNewDigits();

                // Get user input for row and column
                Console.Write("Enter row (1-based): ");
                int row = int.Parse(Console.ReadLine())-1; 
                Console.Write("Enter column (1-based): ");
                int col = int.Parse(Console.ReadLine()) - 1; // Subtract 1 to convert to 0-indexed

                // Check if the input is within bounds
                if (row < 0 || row >= 4 || col < 0 || col >= 5)
                {
                    // row++; // Convert back to 1-indexed for error message
                    Console.WriteLine("Invalid input, please try again.");
                    continue;
                }

                // Remove the number at the user's coordinate
                RemoveNumber(row, col);

                // Handle the "falling" logic
                DropValues();

                // Check for matches and clear them
                while (CheckAndClearMatches())
                {
                    // Apply drop values again after clearing
                    DropValues();
                }

                // Display the total matches found
                Console.WriteLine($"\nTotal matches found: {matchCount}\n");
                matchCount = 0; // Reset match count for the next iteration
            }
        }

        static void DisplayGrid()
        {
            Console.WriteLine("Current Grid:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (newDigits[i, j])
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // New digits in green
                    }
                    Console.Write(grid[i, j] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static void ResetNewDigits()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    newDigits[i, j] = false;
                }
            }
        }

        static void RemoveNumber(int row, int col)
        {
            // Mark the cell as empty by setting it to 0
            grid[row, col] = 0;
        }

        static void DropValues()
        {
            // Loop through each column and apply the drop logic
            for (int col = 0; col < 5; col++)
            {
                for (int i = 3; i > 0; i--)
                {
                    // If the current cell is empty (i.e., 0), shift everything above it down
                    if (grid[i, col] == 0)
                    {
                        for (int j = i; j > 0; j--)
                        {
                            grid[j, col] = grid[j - 1, col]; // Shift the number down
                        }
                        grid[0, col] = random.Next(1, 4); // Fill the topmost cell with a new random number (1, 2, or 3)
                        newDigits[0, col] = true; // Mark this as a new digit
                    }
                }

                // Handle the case where there are multiple zeros in the same column
                // Continue checking from the bottom up until all cells in the column are filled
                for (int i = 3; i >= 0; i--)
                {
                    if (grid[i, col] == 0)
                    {
                        grid[i, col] = random.Next(1, 4); // Fill any empty cells left in the column
                        newDigits[i, col] = true; // Mark this as a new digit
                    }
                }
            }
        }


        static bool CheckAndClearMatches()
        {
            bool[,] markedForClear = new bool[4, 5];
            bool hasMatches = false;

            // Check horizontal matches (for more than 3 consecutive numbers)
            for (int i = 0; i < 4; i++)
            {
                int j = 0;
                while (j < 3)
                {
                    if (grid[i, j] != 0 && grid[i, j] == grid[i, j + 1] && grid[i, j + 1] == grid[i, j + 2])
                    {
                        hasMatches = true;
                        matchCount++; // Increment match count

                        // Mark all consecutive numbers in this row for clearing
                        int k = j;
                        while (k < 5 && grid[i, k] == grid[i, j])
                        {
                            markedForClear[i, k] = true;
                            k++;
                        }

                        // Move j forward to avoid rechecking already marked matches
                        j = k;
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            // Check vertical matches (for more than 3 consecutive numbers)
            for (int j = 0; j < 5; j++)
            {
                int i = 0;
                while (i < 2)
                {
                    if (grid[i, j] != 0 && grid[i, j] == grid[i + 1, j] && grid[i + 1, j] == grid[i + 2, j])
                    {
                        hasMatches = true;
                        matchCount++; // Increment match count

                        // Mark all consecutive numbers in this column for clearing
                        int k = i;
                        while (k < 4 && grid[k, j] == grid[i, j])
                        {
                            markedForClear[k, j] = true;
                            k++;
                        }

                        // Move i forward to avoid rechecking already marked matches
                        i = k;
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            // Now clear all the cells that are marked
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (markedForClear[i, j])
                    {
                        grid[i, j] = 0; // Clear the cell
                    }
                }
            }

            return hasMatches;
        }

    }



}
