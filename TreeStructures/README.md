
# Tree Structures Project - Detailed Documentation

This project demonstrates the implementation of a **Binary Search Tree (BST)** using C#. 
The application loads a dataset of scores from a text file, sorts the scores, inserts them 
into a BST, and performs various tree traversals (in-order, pre-order, and post-order).

<img width="1166" alt="Screenshot 2024-11-29 at 7 49 05 PM" src="https://github.com/user-attachments/assets/3c9b38b1-d9aa-4ce9-9663-260515bd602a">


---

## Features

- **Data Loading**: Reads data from a text file (`scores.txt`) located in a designated `Data` folder.
- **Sorting**: Sorts the scores using the built-in sorting functionality of C#.
- **Binary Search Tree Implementation**: 
  - Efficiently inserts nodes using a recursive insertion method.
  - Supports generic types for flexibility with any comparable data type.
  - Performs tree traversals:
    - **In-Order Traversal**: Produces sorted order for the BST.
    - **Pre-Order Traversal**: Visits nodes in root-left-right order.
    - **Post-Order Traversal**: Visits nodes in left-right-root order.

---

## Project Structure

```
TreeStructures/
├── Data/
│   └── scores.txt                # Input file with a list of scores
├── Node.cs                       # Defines the Node class for the BST
├── BinarySearchTree.cs           # Implements the Binary Search Tree
├── Program.cs                    # Main application logic
└── README.md                     # Documentation for the project
```

---

## How It Works

### Node Class

The `Node<T>` class represents each node in the tree. It stores a value and references to left and right children.

### Binary Search Tree Class

The `BinarySearchTree<T>` class implements the binary search tree. It supports:
- **Generic Design**: Works with any data type that implements `IComparable<T>`.
- **Recursive Insertion**: Determines the correct position for each node by comparing values.
- **Tree Traversals**:
  - **In-Order Traversal**: Visits nodes in ascending order (left, root, right).
  - **Pre-Order Traversal**: Visits nodes in hierarchical order (root, left, right).
  - **Post-Order Traversal**: Processes child nodes first (left, right, root).

### Main Program

The main program:
1. **Loads Data**: Reads `scores.txt` from the `Data` folder.
2. **Sorts Data**: Sorts the scores for insertion.
3. **Builds the BST**: Inserts the sorted scores into the tree.
4. **Displays Traversals**: Outputs the results of all three traversal methods.

---

## Requirements

- **.NET 6.0 or higher**.
- A valid `scores.txt` file in the `Data` folder.

---

## How to Run

1. Clone the repository:
   ```bash
   git clone <repository_url>
   cd <repository_name>
   ```

2. Ensure the `Data` folder exists in the project directory and contains the `scores.txt` file.

3. Build and run the project:
   ```bash
   dotnet build
   dotnet run
   ```

4. Observe the tree traversal outputs in the console.

---

## Example Output

Sample output for the scores dataset:
```
In-Order Traversal:
0 18 22 24 26 ... 100

Pre-Order Traversal:
50 25 12 ... 100

Post-Order Traversal:
0 12 ... 100
```

---

## Notes

- If the `scores.txt` file is missing, the program will prompt you to ensure it exists.
- The `Data` folder and file path are handled using relative paths for portability.
- You can replace `scores.txt` with any other dataset to test the program with different values.

---

## License

This project is for educational purposes and demonstrates understanding of tree structures and traversal algorithms.

---

## References

- Binary Search Trees: [Wikipedia](https://en.wikipedia.org/wiki/Binary_search_tree)
- Tree Traversals: [GeeksforGeeks](https://www.geeksforgeeks.org/tree-traversals-inorder-preorder-and-postorder/)
