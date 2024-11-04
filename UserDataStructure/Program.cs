using System;
using System.Collections.Generic;
using System.IO;

namespace UserDataStructure
{
    public class Program
    {
        public static void Main()
        {
            string filePath = "users.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("User data file not found. Attempting to load file from: " + Path.GetFullPath(filePath));
                return;
            }

            // Using Dictionary as a hash table to store users
            Dictionary<int, User> userHashTable = LoadUsersFromFile(filePath);




            // Display a sample user by retrieving using hash code (UserId)
            Console.WriteLine("\nEnter User ID to retrieve information:");
            if (int.TryParse(Console.ReadLine(), out int userId))
            {
                if (userHashTable.TryGetValue(userId, out User user))
                {
                    Console.WriteLine("User Found:");
                    Console.WriteLine(user);
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid User ID.");
            }
        }

        private static Dictionary<int, User> LoadUsersFromFile(string filePath)
        {
            Dictionary<int, User> users = new Dictionary<int, User>();

            // Ensure the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("User data file not found.");
                return users;
            }

            foreach (var line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(',');

                // Parse UserId correctly as an integer
                if (parts.Length == 5 && int.TryParse(parts[0], out int userId))
                {
                    User user = new User
                    {
                        UserId = userId,                    // Store as integer
                        UserName = parts[1],
                        Email = parts[2],
                        Company = parts[3],
                        Location = parts[4]
                    };
                    users[userId] = user; // Add to dictionary with integer key
                }
            }

            Console.WriteLine($"{users.Count} users loaded from file.");
            return users;
        }

    }
}