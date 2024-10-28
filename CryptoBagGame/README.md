# CryptoBagGame
<br>

<img width="384" alt="Screenshot 2024-10-28 at 11 33 21 AM" src="https://github.com/user-attachments/assets/01ccf6e7-6336-4c3e-9474-1cdfc6721178">
<br>
<br>

The code step-by-step, focusing on why we need nodes, how we're creating a linked list from them, and how the iterator works to go through the linked list.

## 1. Node Class
The Node class is the basic building block of a linked list. Each node holds:

- A value: This is the data stored in the node (in this case, a CryptoCoin object).
- A reference (or pointer) to the next node: This points to the next node in the linked list.
Here’s how the Node class looks:

```bash
public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }

    public Node(T value)
    {
        Value = value;
        Next = null;
    }
}
```
In this code:

Value holds the data (like a cryptocurrency coin).
Next holds a reference to the next node in the list.
When we create a new Node, it’s initialized with a Value but no Next node yet (so Next is null).
__Why we need nodes:__ In a linked list, each item needs to "link" to the next item. The Node class allows us to store both the data (the coin) and the link (the reference to the next coin).

## 2. LinkedList Class
The LinkedList class is a __collection of nodes__ connected in sequence. It manages these nodes and provides operations to add and retrieve data. It keeps track of the head node, which is the start of the list, and the size, which is the number of nodes in the list.

Here's how the LinkedList class is set up:
```bash
public class LinkedList<T>
{
    private Node<T> head;
    public int Size { get; private set; }

    public LinkedList()
    {
        head = null;
        Size = 0;
    }

    public void Add(T value)
    {
        Node<T> newNode = new Node<T>(value);
        newNode.Next = head;
        head = newNode;
        Size++;
    }

    public List<T> ToList()
    {
        List<T> items = new List<T>();
        Node<T> current = head;
        while (current != null)
        {
            items.Add(current.Value);
            current = current.Next;
        }
        return items;
    }
}
```
In this code:

- head is a reference to the first node in the linked list.
- Size keeps track of how many nodes are in the list.
- The constructor initializes an empty list (head = null and Size = 0).
  
Adding a node:

- The Add method adds a new node to the beginning of the list.
- A new Node is created with the specified value.
- The new node’s Next property is set to the current head (linking it to the previous start of the list).
- head is updated to be the new node, and Size is incremented.
ToList method:

- ToList converts the linked list to a standard List<T> by iterating through each node, collecting its Value, and adding it to a List<T> object.
- This is helpful for the iterator, which needs a collection to randomly access elements.
__Why we need__ LinkedList: The LinkedList class organizes and manages a collection of nodes. It's more flexible than an array since nodes can be added easily without resizing a fixed array.

## 3. Bag Class
The Bag class represents a collection where items can only be added, and retrieval is random. 
The Bag uses the LinkedList to store items.

 ```bash
public class Bag<T>
{
    private LinkedList<T> items;

    public Bag()
    {
        items = new LinkedList<T>();
    }

    public void Add(T element)
    {
        items.Add(element);
    }

    public int Size()
    {
        return items.Size;
    }

    public Iterator<T> GetIterator()
    {
        return new Iterator<T>(items);
    }
}
```

In this code:

- items is a linked list that holds all the coins in the bag.
- Add method adds an item to the linked list.
- Size returns the number of items in the bag.
- GetIterator returns an iterator to traverse the linked list randomly.
__Why we need Bag:__ It provides an interface to store and access elements in a random manner (using the iterator), without worrying about how they’re stored internally.

## 4. Iterator Class
The Iterator class is responsible for providing random access to elements in the bag. 
It allows us to "draw" items in random order without changing the order of elements in the linked list itself.

```bash
public class Iterator<T>
{
    private List<T> elements;
    private Random random;

    public Iterator(LinkedList<T> linkedList)
    {
        elements = linkedList.ToList();
        random = new Random();
    }

    public bool IsEmpty()
    {
        return elements.Count == 0;
    }

    public T Next()
    {
        if (IsEmpty()) throw new InvalidOperationException("No more elements in the bag.");
        
        int randomIndex = random.Next(elements.Count);
        T item = elements[randomIndex];
        
        // Remove the item from the list to avoid repetition in this iteration session
        elements.RemoveAt(randomIndex);

        return item;
    }
}
```
In this code:

- elements is a List<T> that holds all items from the linked list, allowing for random access.
- The constructor initializes elements by calling ToList on the linked list, converting it to a List<T>.
- IsEmpty checks if there are any elements left to draw.
- Next retrieves a random element from elements:
- It picks a random index, retrieves the element at that index, and then removes it from elements so it’s not picked again in this session.
- The method ensures that each item in the bag is only drawn once.
- Why we need Iterator: It allows us to randomly access elements from the linked list. Converting the linked list to a List<T> in elements makes it easy to randomly access items, since lists support indexed access (unlike linked lists).

### Summary
__Node:__ Represents each element in the list, holding data and a link to the next node.
__LinkedList:__ Manages the nodes, allowing us to add elements and traverse the list.
__Bag:__ Stores coins and allows us to get an iterator for random access.
__Iterator:__ Retrieves elements in a random order by converting the linked list to a List<T> and randomly picking items.
This structure ensures that each item is only picked once per iteration, giving a "random draw" effect.






