
# Data Structure Console Application

## Overview

This console application demonstrates the use of common data structures in C#, including arrays, stacks, queues, and dictionaries. The purpose of this project is to store, retrieve, and manage user data using different data structures and to understand the strengths and ideal use cases for each.

## Project Structure

The project includes the following core components:
- **User Class**: Defines the structure of user data with properties like `UserId`, `UserName`, `Email`, `Company`, and `Location`.
- **Data Loading Functionality**: Reads user data from a `users.txt` file, populating each data structure with the same set of users.
- **Data Structures**: Implements an array, stack, queue, and dictionary to store and manage user data.

## Data Structures Used

### 1. Array
**Description**: An array is a fixed-size, sequential collection of elements, allowing efficient access by index.

**Implementation**:
```csharp
User[] userArray = users.ToArray(); // Convert list of users to an array
```

**Use Case**: Arrays are ideal for scenarios where fast, indexed access is required, and the size of the collection is known in advance.

---

### 2. Stack
**Description**: A stack is a Last-In-First-Out (LIFO) data structure. Elements are added and removed from the top of the stack.

**Implementation**:
```csharp
Stack<User> userStack = new Stack<User>();
foreach (User user in users)
{
    userStack.Push(user); // Add each user to the stack
}
```

**Example Operation**:
```csharp
Console.WriteLine("Top User in Stack:");
Console.WriteLine(userStack.Pop()); // Display and remove the top user
```

**Use Case**: Stacks are ideal for scenarios like undo operations, function call management, and reversing data.

---

### 3. Queue
**Description**: A queue is a First-In-First-Out (FIFO) data structure. Elements are added to the back and removed from the front.

**Implementation**:
```csharp
Queue<User> userQueue = new Queue<User>();
foreach (User user in users)
{
    userQueue.Enqueue(user); // Add each user to the queue
}
```

**Example Operation**:
```csharp
Console.WriteLine("First User in Queue:");
Console.WriteLine(userQueue.Dequeue()); // Display and remove the first user
```

**Use Case**: Queues are used in scheduling systems, order processing, and scenarios where data should be processed in the order it was received.

---

### 4. Dictionary (Hash Table)
**Description**: A dictionary is a collection of key-value pairs, providing fast lookups by key. In this project, a dictionary is used as a hash table, with `UserId` as the key and `User` as the value.

**Implementation**:
```csharp
Dictionary<int, User> userDictionary = new Dictionary<int, User>();
foreach (User user in users)
{
    userDictionary[user.UserId] = user; // Add each user to the dictionary with UserId as the key
}
```

**Use Case**: Dictionaries are perfect for scenarios where fast lookups by unique identifiers are needed, such as retrieving user information by ID.

## Key Classes and Methods

### User Class
The `User` class defines the structure of user data and includes the following properties:
- **UserId**: A unique identifier for the user.
- **UserName**: The user's name.
- **Email**: The user's email address.
- **Company**: The company the user is associated with.
- **Location**: The user’s location.

### Data Loading Function
The `LoadUsersFromFile` method loads user data from an external text file (`users.txt`) and populates each data structure with the same set of users.

```csharp
private static Dictionary<int, User> LoadUsersFromFile(string filePath)
{
    Dictionary<int, User> users = new Dictionary<int, User>();

    foreach (var line in File.ReadLines(filePath))
    {
        string[] parts = line.Split(',');

        if (parts.Length == 5 && int.TryParse(parts[0], out int userId))
        {
            User user = new User
            {
                UserId = userId,
                UserName = parts[1],
                Email = parts[2],
                Company = parts[3],
                Location = parts[4]
            };
            users[userId] = user;
        }
    }

    return users;
}
```

## How to Run the Application

1. Ensure that `users.txt` is in the project directory, with data formatted as `UserId,UserName,Email,Company,Location`.
2. Run the console application.
3. Enter a `UserId` to retrieve user information using the dictionary.
4. The stack and queue examples will display the first user in each data structure following LIFO (stack) and FIFO (queue) principles.

## Conclusion

This project demonstrates the use of four fundamental data structures: arrays, stacks, queues, and dictionaries. Each data structure is used to store the same set of user data, allowing for comparison of access patterns, performance, and ideal use cases for each structure. This application provides a foundational understanding of data structures and their applications in C#.
