using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class CircularLinkedList
    {
        public static Node Head = null;
        public static Node Tail = null;

        public static void AddNode(int value)
        {
            Node newNode = new Node { Value = value ,Nextnode = null};
            if(Head == null)
            {
                Head = newNode;
                Tail = newNode;
                newNode.Nextnode = Head;
            }
            else
            {
                Tail.Nextnode = newNode;
                Tail = newNode;
                Tail.Nextnode = Head;
            }
        }
        public static void PrintList()
        {
            if (Head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }
            Node current = Head;
            do
            {
                Console.Write(current.Value + " ");
                current = current.Nextnode;
            } while (current != Head);
            Console.WriteLine();
        }
        public static void AddNodeAtStart(int value)
        {
            Node newNode = new Node { Value = value, Nextnode = null };
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                newNode.Nextnode = newNode; // Pointing to itself
            }
            else
            {
                Tail.Nextnode = newNode;
                newNode.Nextnode = Head;
                Head = newNode;
            }
        }
        public static void AddNodeAtEnd(int value)
        {
            Node newNode = new Node { Value = value, Nextnode = null };
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                newNode.Nextnode = Head; // Pointing to itself
            }
            else
            {
                Tail.Nextnode = newNode;
                Tail = newNode;
                Tail.Nextnode = Head; // Circular link
            }
        }
        public static void AddNodeAtPosition(int value, int position)
        {
            Node node = new Node { Value = value, Nextnode = null };
            if (position < 0)
            {
                Console.WriteLine("Invalid position.");
                return;
            }
            if (position == 0)
            {
                AddNodeAtStart(value);
                return;
            }
            if (Head == null)
            {
                Console.WriteLine("List is empty. Adding at the start.");
                AddNodeAtStart(value);
                return;
            }
            Node current = Head;
            Node previous = null;
            int count = 0;
            while (current != null && count<= position)
            {
                current = current.Nextnode;
                count++;
            }
        }
        public static void RemoveNode(int value)
        {
            // Case 1: Empty list
            if (Head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }
            // Case 2: Only one node
            if (Head == Tail && Head.Value == value)
            {
                Head = null;
                Tail = null;
                Console.WriteLine($"Node with value {value} removed.");
                return;
            }
            // Case 3: Deleting head
            if (Head.Value == value)
            {
                Head = Head.Nextnode;
                Tail.Nextnode = Head;
                Console.WriteLine($"Node with value {value} removed from head.");
                return;
            }
            // Case 4: Deleting from middle or end
            Node current = Head;
            Node previous = null;
            do
            {
                // 10 20 30 40 50 60 
                // want to delete 40 
                // first iteration : current = 10, previous = null
                // second iteration : current = 20, previous = 10
                // third iteration : current = 30, previous = 20
                // fourth iteration : current = 40, previous = 30
                // fifth iteration : current = 50, previous = 40
                previous = current;
                current = current.Nextnode;

                if (current.Value == value)
                {
                    previous.Nextnode = current.Nextnode; // 30 -> 50

                    if (current == Tail)
                    {
                        Tail = previous;
                        Tail.Nextnode = Head;
                    }
                    Console.WriteLine($"Node with value {value} removed.");
                    return;
                }

            } while (current != Head);

            Console.WriteLine($"Value {value} not found in the list.");
        }
    }
}
