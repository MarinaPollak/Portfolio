
# Search Algorithms MVC Application
<img width="1309" alt="Screenshot 2024-11-29 at 4 30 13 PM" src="https://github.com/user-attachments/assets/0f0daa1e-7c32-4172-9c98-42ae1d5a20dd">


## Description
This is an ASP.NET Core MVC application that demonstrates the implementation of three common search algorithms: Linear Search, Binary Search, and Interpolation Search. Users can input a number, and the application searches for it in a predefined data file (`scores.txt`). The application also displays the results of each algorithm and highlights their efficiency.

## Features
- **Search Algorithms**: Implements Linear Search, Binary Search, and Interpolation Search.
- **Dynamic File Loading**: Reads data from a file (`scores.txt`) stored in the `DataFiles` folder.
- **User-Friendly Interface**: A web interface to input numbers and display search results.
- **Error Handling**: Gracefully handles missing or empty data files.

## Technologies Used
- **Framework**: ASP.NET Core MVC
- **Language**: C#
- **Frontend**: Razor Views (HTML, CSS)
- **File Handling**: File I/O for reading numbers from a text file
- **Hosting**: Localhost (Kestrel server)


## How to Use
1. **Enter a Number**:
   - On the homepage, input a number in the search bar.
2. **View Results**:
   - After submitting, the results for Linear Search, Binary Search, and Interpolation Search will be displayed.
3. **Error Messages**:
   - If the `scores.txt` file is missing or empty, an error message will appear.

## Project Structure

```
YourProject/
├── Controllers/
│   ├── SearchController.cs         # Controller handling search logic
├── DataFiles/
│   ├── scores.txt                  # Data file with numbers for searching
├── Models/
│   ├── SearchAlgorithms.cs         # Search algorithms logic
├── Views/
│   ├── Search/
│   │   ├── Index.cshtml            # Search page view
├── Program.cs                      # Application entry point
├── wwwroot/                        # Static files (CSS, JS, etc.)
```

## Search Algorithms

### 1. Linear Search
- **Description**: Searches each element of the list sequentially until the target is found or the end of the list is reached.
- **Time Complexity**: `O(n)`
- **Best Case**: Target found at the beginning.
- **Worst Case**: Target not found or at the end.

### 2. Binary Search
- **Description**: Divides the sorted list into halves to find the target.
- **Time Complexity**: `O(log n)`
- **Best Case**: Target found in the middle.
- **Worst Case**: Target not found.

### 3. Interpolation Search
- **Description**: Uses mathematical interpolation to estimate the target’s position.
- **Time Complexity**: `O(log log n)` (for uniformly distributed data).
- **Best Case**: Target found in one calculation.
- **Worst Case**: Target not found.

## Error Handling
- **Missing File**: Displays an error message if `scores.txt` is not found.
- **Empty File**: Displays a message indicating the file is empty.
- **Invalid Input**: Ensures the user inputs a valid number.

## Future Improvements
- Implement additional search algorithms (e.g., Ternary Search).
- Display execution time for each algorithm to compare performance.
- Enhance the UI with CSS frameworks like Bootstrap.
- Add unit tests for search algorithms and controller actions.

## License
This project is licensed under the MIT License. See `LICENSE` for more information.

## Acknowledgments
- Thanks to [Microsoft Docs](https://learn.microsoft.com/) for ASP.NET Core MVC guidance.
