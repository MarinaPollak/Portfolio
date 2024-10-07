using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Connect4WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] board = new int[6, 7]; // 6x7 grid for Connect 4
        private int currentPlayer = 1; // 1 for player 1, 2 for player 2
        private bool gameOver = false;

        private List<(int row, int col)>
            winningPositions = new List<(int row, int col)>(); // Store the winning line positions

        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    board[row, col] = 0;
                }
            }
        }

        private void DropPiece(object sender, RoutedEventArgs e)
        {
            if (gameOver) return; // Don't allow moves if the game is over

            Button clickedButton = sender as Button;
            string[] tag = clickedButton.Tag.ToString().Split(',');
            int col = int.Parse(tag[1]);

            // Drop the piece into the lowest available row
            for (int row = 5; row >= 0; row--)
            {
                if (board[row, col] == 0)
                {
                    board[row, col] = currentPlayer;
                    UpdateGridUI(); // Update the UI after the piece is dropped

                    bool matchFound;
                    do
                    {
                        matchFound = false;

                        // Check for matches for the current player
                        if (CheckForWin(row, col))
                        {
                            HighlightWinningLine(currentPlayer); // Highlight the winning line for the current player
                            MessageBox.Show($"Player {currentPlayer} got a match!");

                            RemoveMatchedPieces(currentPlayer); // Remove the matched pieces for the current player
                            DropRemainingPieces(); // Drop the pieces after removing matched pieces

                            // Recheck for any new matches that may have occurred after the drop
                            matchFound = RecheckBoardForMatches();
                        }

                    } while (matchFound); // Keep clearing and dropping until no more matches

                    // Check if the board is full after all matches are processed
                    if (IsBoardFull())
                    {
                        gameOver = true;
                        MessageBox.Show("Game over! It's a draw!");
                        return; // End the game
                    }

                    // Switch players only after all matches have been processed
                    currentPlayer = (currentPlayer == 1) ? 2 : 1;
                    break;
                }
            }
        }





        //private void UpdateUI(int row, int col)
        //{
        //    Button button = (Button)GameGrid.Children
        //        .Cast<UIElement>()
        //        .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);
        //    button.Content = currentPlayer == 1 ? "P1" : "P2";
        //    button.Background = currentPlayer == 1 ? Brushes.Red : Brushes.Yellow;
        //}

        // Make the pieces above the cleared ones fall
        // Make the pieces above the cleared ones fall
        // Drop remaining pieces after clearing the matched ones and update the UI
        private void DropRemainingPieces()
        {
            for (int col = 0; col < 7; col++)
            {
                for (int row = 5; row > 0; row--)
                {
                    if (board[row, col] == 0) // If there's an empty space, drop the piece from above
                    {
                        for (int r = row; r > 0; r--)
                        {
                            board[r, col] = board[r - 1, col]; // Shift everything down
                        }
                        board[0, col] = 0; // Clear the topmost row after the drop
                    }
                }
            }
            UpdateGridUI(); // Update the UI after dropping pieces
        }


        private void UpdateGridUI()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Button button = (Button)GameGrid.Children
                        .Cast<UIElement>()
                        .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);

                    // Update the content and color based on the board state
                    if (board[row, col] == 1) // Player 1's piece
                    {
                        button.Content = "P1";
                        button.Background = Brushes.Red;
                    }
                    else if (board[row, col] == 2) // Player 2's piece
                    {
                        button.Content = "P2";
                        button.Background = Brushes.Yellow;
                    }
                    else
                    {
                        button.Content = ""; // Clear empty spots
                        button.Background = Brushes.LightGray; // Reset the background color
                    }

                    // Reset the border highlighting in case it was previously highlighted
                    button.BorderBrush = Brushes.Gray; // Reset border color to default
                    button.BorderThickness = new Thickness(1); // Reset border thickness
                }
            }
        }


        private bool CheckForWin(int row, int col)
        {
            winningPositions.Clear(); // Clear previous winning positions before each check
            bool horizontalMatch = false;
            bool verticalMatch = false;
            bool diagonalMatch1 = false;
            bool diagonalMatch2 = false;

            // Check for matches for the current player only, and ensure it is at least 4 in a row
            horizontalMatch = (CheckDirection(row, col, 1, 0, currentPlayer) >= 4); // Horizontal
            verticalMatch = (CheckDirection(row, col, 0, 1, currentPlayer) >= 4); // Vertical
            diagonalMatch1 = (CheckDirection(row, col, 1, 1, currentPlayer) >= 4); // Diagonal \
            diagonalMatch2 = (CheckDirection(row, col, 1, -1, currentPlayer) >= 4); // Diagonal /

            bool matchFound = horizontalMatch || verticalMatch || diagonalMatch1 || diagonalMatch2;

            // Remove pieces and highlight only if a match is found
            if (matchFound)
            {
                if (horizontalMatch)
                {
                    HighlightWinningLine(currentPlayer); // Highlight the horizontal match
                    RemoveMatchedPieces(currentPlayer);  // Remove horizontal match
                }
                if (verticalMatch)
                {
                    HighlightWinningLine(currentPlayer); // Highlight the vertical match
                    RemoveMatchedPieces(currentPlayer);  // Remove vertical match
                }
                if (diagonalMatch1)
                {
                    HighlightWinningLine(currentPlayer); // Highlight the diagonal match
                    RemoveMatchedPieces(currentPlayer);  // Remove diagonal match
                }
                if (diagonalMatch2)
                {
                    HighlightWinningLine(currentPlayer); // Highlight the diagonal match
                    RemoveMatchedPieces(currentPlayer);  // Remove diagonal match
                }
            }

            return matchFound;
        }



        // Check in both directions (dx, dy), ensuring only the specified player's pieces are counted
        private int CheckDirection(int row, int col, int dx, int dy, int player)
        {
            int count = 1; // Start with the current piece
            winningPositions.Add((row, col)); // Add the starting position to the winning positions

            // Count in one direction (forward)
            count += CountInDirection(row, col, dx, dy, player);
            // Count in the opposite direction (backward)
            count += CountInDirection(row, col, -dx, -dy, player);

            // Return count only if it's 4 or more, meaning exactly 4, 5, or 6 pieces in a row
            return (count >= 4) ? count : 0; // Only return if the count is valid (at least 4 in a row)
        }


        // Count consecutive pieces in the specified direction (dx, dy) for the given player
        private int CountInDirection(int row, int col, int dx, int dy, int player)
        {
            int count = 0;
            int r = row + dx;
            int c = col + dy;

            // Stop counting if an empty cell (0) or opponent's piece is encountered
            while (r >= 0 && r < 6 && c >= 0 && c < 7 && board[r, c] == player)
            {
                winningPositions.Add((r, c)); // Add the matching position to the winning list
                count++;
                r += dx;
                c += dy;
            }

            return count; // Return the number of consecutive matching pieces in that direction
        }





        private bool RecheckBoardForMatches()
        {
            bool matchFound = false; // Track whether any matches were found

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (board[row, col] != 0) // Only check non-empty cells
                    {
                        if (CheckForWin(row, col)) // Check for matches
                        {
                            HighlightWinningLine(currentPlayer); // Highlight the winning line for the current player
                            RemoveMatchedPieces(currentPlayer);  // Remove the matched pieces
                            DropRemainingPieces();               // Drop pieces after removal
                            matchFound = true;                   // Indicate a match was found
                        }
                    }
                }
            }
            return matchFound; // Return true if any matches were found
        }



        private void RemoveMatchedPieces(int player)
        {
            foreach (var (row, col) in winningPositions)
            {
                if (board[row, col] == player)
                {
                    board[row, col] = 0; // Clear the matched pieces

                    // Reset the visual highlight (reset the border of the button)
                    Button button = (Button)GameGrid.Children
                        .Cast<UIElement>()
                        .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);

                    button.BorderBrush = Brushes.Gray; // Reset the border color to default
                    button.BorderThickness = new Thickness(0.5); // Reset the border thickness
                }
            }
            winningPositions.Clear(); // Clear the list after removing the matched pieces
        }


        // Highlight the winning line for the specified player
        // Highlight the winning line for the specified player
        private void HighlightWinningLine(int player)
        {
            foreach (var (row, col) in winningPositions)
            {
                if (board[row, col] == player) // Only highlight the current player's pieces
                {
                    Button button = (Button)GameGrid.Children
                        .Cast<UIElement>()
                        .First(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col);

                    button.BorderBrush = Brushes.BlueViolet; // Highlight the winning line with a unique color
                    button.BorderThickness = new Thickness(3); // Thicker border to highlight the match
                }
            }
        }


        private bool IsBoardFull()
        {
        for (int col = 0; col < 7; col++)
        {
            if (board[0, col] == 0) return false; // If the top row has an empty cell, it's not full
        }
        return true; // The board is full
        }
    }
}
