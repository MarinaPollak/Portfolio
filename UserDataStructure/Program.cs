using System;
using System.Collections.Generic;
using System.IO;

namespace UserDataStructure
{
    public class Program
    {
        public static void Main()
        {
            // Load user data into dictionary (hash table)
            Dictionary<int, User> userDictionary = LoadUsersFromFile("users.txt");

            // Load user data into stack
            Stack<User> userStack = new Stack<User>();
            foreach (var user in userDictionary.Values)
            {
                userStack.Push(user);
            }

            // Load user data into queue
            Queue<User> userQueue = new Queue<User>();
            foreach (var user in userDictionary.Values)
            {
                userQueue.Enqueue(user);
            }

            Console.WriteLine("Enter User ID to retrieve information:");
            if (int.TryParse(Console.ReadLine(), out int userId))
            {
                if (userDictionary.TryGetValue(userId, out User user))
                {
                    Console.WriteLine("User Found in Dictionary:");
                    Console.WriteLine(user);
                }
                else
                {
                    Console.WriteLine("User not found in Dictionary.");
                }
            }

            Console.WriteLine("\nStack - Last In First Out (LIFO):");
            Console.WriteLine("Top User in Stack:");
            Console.WriteLine(userStack.Pop()); // Display and remove the top user

            Console.WriteLine("\nQueue - First In First Out (FIFO):");
            Console.WriteLine("First User in Queue:");
            Console.WriteLine(userQueue.Dequeue()); // Display and remove the first user
        }

        private static Dictionary<int, User> LoadUsersFromFile(string filePath)
        {
            Dictionary<int, User> users = new Dictionary<int, User>();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("User data file not found.");
                return users;
            }

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

            Console.WriteLine($"{users.Count} users loaded from file.");
            return users;
        }
    }
}
