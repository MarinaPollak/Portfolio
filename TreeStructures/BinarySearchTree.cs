using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TreeStructures
{
    /// <summary>
    /// The class uses generics to allow the tree to store any type of data, not just integers.
    ///The type T must implement the IComparable T interface to support comparisons.
    /// This ensures that we can determine the order of elements for insertion and traversal.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Represents the root node of the tree.Node T is a separate class (assumed to have Value, Left, and Right properties).
        /// private set ensures that the Root can only be modified within the BinarySearchTree class.
        /// </summary>
        public Node<T>?  Root { get; private set; }

        /// <summary>
        /// Purpose: Adds a new value to the tree.
        /// Logic:Calls the private recursive helper method InsertRec to determine the correct position for the new value.
        /// Updates the Root if the tree is empty(when Root == null).
        /// </summary>
        /// <param name="value"></param>
        
        public void Insert(T value)
        {
            Root = InsertRec(Root, value);
        }


        /// <summary>
        /// Base Case:If the current node(root) is null, it creates a new node with the given value.
        /// Recursive Case:Compares the new value with the current node’s value using CompareTo:
        ///   value.CompareTo(root.Value) < 0: The new value is smaller; recursively insert into the left subtree.
        ///   value.CompareTo(root.Value) > 0: The new value is larger; recursively insert into the right subtree.
        /// Returns the updated root node.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Node<T> InsertRec(Node<T> root, T value)
        {
            if (root == null) return new Node<T>(value); // Create a new node if the position is empty

            if (value.CompareTo(root.Value) < 0)   // If value is less, go left
                root.Left = InsertRec(root.Left, value); // Recursively insert into the left subtree
            else if (value.CompareTo(root.Value) > 0) // If value is greater, go right
                root.Right = InsertRec(root.Right, value);

            return root;  // Return the unchanged root
        }

        /// <summary>
        /// Order: Left, Root, Right.
        /// Use Case: Produces a sorted order of elements for BSTs.
        /// Example: For a tree with values[50, 30, 70], the output is 30 50 70.
        /// </summary>
        /// <param name="node"></param>

        public void InOrderTraversal(Node<T> node)
        {
            if (node == null) return;

            InOrderTraversal(node.Left); // Visit the left subtree
            Console.Write($"{node.Value} "); // Process the current node
            InOrderTraversal(node.Right);  // Visit the right subtree
        }

        /// <summary>
        /// Order: Root, Left, Right.
        /// Use Case: Useful for creating a prefix notation (e.g., in expressions).
        /// Example: For the same tree, the output is 50 30 70.
        /// </summary>
        /// <param name="node"></param>

        public void PreOrderTraversal(Node<T> node)
        {
            if (node == null) return;

            Console.Write($"{node.Value} "); // Process the current node
            PreOrderTraversal(node.Left); // Visit the left subtree
            PreOrderTraversal(node.Right); // Visit the right subtree
        }

        /// <summary>
        /// Order: Left, Right, Root.
        /// Use Case: Useful for deleting or freeing nodes in memory safely(child nodes are processed first).
        /// Example: For the same tree, the output is 30 70 50.
        /// </summary>
        /// <param name="node"></param>

        public void PostOrderTraversal(Node<T> node)
        {
            if (node == null) return;

            PostOrderTraversal(node.Left); // Visit the left subtree
            PostOrderTraversal(node.Right); // Visit the right subtree
            Console.Write($"{node.Value} "); // Process the current node
        }
    }

}
