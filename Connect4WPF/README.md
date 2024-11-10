# Connect 4 WPF Game

## Overview

This is a WPF (Windows Presentation Foundation) implementation of the classic Connect 4 game. In Connect 4, two players (Player 1 and Player 2) take turns dropping their pieces into a 6x7 grid. The goal is to connect four pieces in a row, column, or diagonal before the other player does. This project serves as both a functional game and a demonstration of key programming concepts, including grid manipulation, event handling, and match-checking algorithms.

## Features

- **Two-Player Turn-Based Gameplay**: Players take turns dropping their pieces into the grid.
- **Match Detection**: The game detects winning matches for four or more consecutive pieces horizontally, vertically, or diagonally.
- **Piece Dropping Mechanic**: Pieces "drop" to the lowest available position within a column.
- **Match Clearing**: When a winning match is found, the pieces are cleared, and the pieces above "drop" down to fill the space.
- **Graphical Interface**: The game uses WPF for a visually interactive experience, with colored cells representing each player's pieces.
- **Reset and Game Over Conditions**: If the board fills up without a winner, the game ends in a draw.

## How to Play

1. **Start the Game**: Run the WPF application to open the game window.
2. **Taking Turns**: Click on a column to drop a piece. The piece will automatically drop to the lowest available position in that column.
3. **Win Condition**: Get four consecutive pieces in any direction (horizontal, vertical, or diagonal) to win.
4. **Draw Condition**: If the board is full and no player has four consecutive pieces, the game ends in a draw.

## Game Components

### Board
- The board is represented by a 6x7 grid of buttons.
- Each cell can hold a value of 0 (empty), 1 (Player 1), or 2 (Player 2).

### Players
- Player 1 is represented by red pieces (`P1`).
- Player 2 is represented by yellow pieces (`P2`).
  
### Piece Dropping Mechanism
- When a player selects a column, the game finds the lowest available row in that column and places the player's piece there.

### Match Detection
- After each piece drop, the game checks for any matches in four directions:
  - Horizontal
  - Vertical
  - Diagonal (bottom-left to top-right)
  - Diagonal (top-left to bottom-right)
- If four or more consecutive pieces of the same player are detected, a match is registered.

### Match Clearing
- When a match is found, the matched pieces are highlighted with a distinct border color.
- After acknowledgment, the matched pieces are cleared, and the pieces above them drop down to fill the empty cells.

## Code Structure

### Main Components

- **MainWindow.xaml.cs**: Contains the game logic and event handling for piece placement, match checking, and grid updates.
- **GameGrid**: A WPF `Grid` element used to represent the 6x7 board. Each cell is a button representing a game cell.

### Key Methods

- `InitializeBoard()`: Sets up the game board to an empty state.
- `DropPiece()`: Handles the dropping of a piece into the selected column.
- `CheckForWin()`: Checks if a player has achieved four consecutive pieces after each move.
- `UpdateGridUI()`: Updates the UI to reflect the current board state.
- `HighlightWinningLine()`: Highlights the winning line when a match is found.
- `RemoveMatchedPieces()`: Removes matched pieces from the board and drops remaining pieces.
- `RecheckBoardForMatches()`: Rechecks the board after each match to detect new potential matches from dropped pieces.

## Installation and Setup

1. **Clone the Repository**:
   
2. **Open in Visual Studio**:
    Open the solution file (.sln) in Visual Studio.

3. **Run the Game**:
    - Set the WPF project as the startup project.
    - Click "Start" to run the game.

## Future Improvements

- **Improved UI**: Add animations for piece drops and match highlights.
- **Difficulty Levels**: Introduce various grid sizes and connect requirements.
  

## License

This project is open-source and available under the MIT License.

---

## Credits

This project was developed as a demonstration of C# algorithms and WPF skills in a grid-based game environment.
