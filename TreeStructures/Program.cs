using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TreeStructures
{
    internal class Program
    {
        static void Main()
        {
            // Get the base project directory
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));

            // Define folder and file paths relative to the project directory
            string folderPath = Path.Combine(projectDirectory, "Data");
            string filePath = Path.Combine(folderPath, "scores.txt");

            // Ensure the folder exists
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"Folder not found: {folderPath}");
                Directory.CreateDirectory(folderPath);
                Console.WriteLine($"Created folder: {folderPath}");
            }

            // Ensure the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found at {filePath}. Please ensure 'scores.txt' is present in the 'Data' folder.");
                return;
            }

            // Load data from the file
            var scores = File.ReadAllLines(filePath).Select(int.Parse).ToList();

            // Sort data
            scores.Sort();

            // Build the binary search tree
            var bst = new BinarySearchTree<int>();
            foreach (var score in scores)
            {
                bst.Insert(score);
            }



            // Display traversals
            Console.WriteLine("In-Order Traversal:");
            bst.InOrderTraversal(bst.Root);
            Console.WriteLine();

            Console.WriteLine("Pre-Order Traversal:");
            bst.PreOrderTraversal(bst.Root);
            Console.WriteLine();

            Console.WriteLine("Post-Order Traversal:");
            bst.PostOrderTraversal(bst.Root);
            Console.WriteLine();
        }
    }
}
