using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DoublyLinkedList
    {
        public static DoublyNode head= new DoublyNode();
        public static void DoublyLinkedlist()
        {
            do
            {
                Console.WriteLine("Enter Element of the Linked list");
                int value = Convert.ToInt32(Console.ReadLine());
                AddToEnd(value);
                Console.WriteLine("Do you want to add another node? (y/n)");
            } while (Console.ReadLine().ToLower() == "y");
            Print();
        }
        public static void AddToEnd(int value)
        {
            DoublyNode NewNode = new DoublyNode { Value = value, Nextnode = null, Previousnode = null };
            if (head == null)
            {
                head = NewNode;
            }
            DoublyNode Temp = head;
            while (Temp.Nextnode != null)
            {
                Temp = Temp.Nextnode;
            }
            Temp.Nextnode = NewNode;
            NewNode.Previousnode = Temp;
        }
        public static void AddToStart(int value)
        {
            DoublyNode doublyNode = new DoublyNode { Value = value, Nextnode = null, Previousnode = null };
            if (head == null)
            {
                head = doublyNode;
            }
            else
            {
                doublyNode.Nextnode = head;
                head.Previousnode = doublyNode;
                head = doublyNode;// head is now pointing to the new node
            }
        }
        public static void AddAfterPosition(int position, int value)
        {
            DoublyNode newNode = new DoublyNode { Value = value, Nextnode = null, Previousnode = null };

            if (head == null)
            {
                Console.WriteLine("List is empty. Adding as head node.");
                head = newNode;
                return;
            }
            DoublyNode temp = head;
            int count = 0;
            // Traverse to the node at the given position
            while (temp != null && count < position)
            {
                temp = temp.Nextnode;
                count++;
            }
            if (temp == null)
            {
                Console.WriteLine("Position out of range.");
                return;
            }
            newNode.Nextnode = temp.Nextnode;
            newNode.Previousnode = temp;
            if (temp.Nextnode != null)
            {
                temp.Nextnode.Previousnode = newNode;
            }
            temp.Nextnode = newNode;
        }
        public static void AddBeforePosition(int Postion, int value)
        {
            DoublyNode NewNode = new DoublyNode { Value = value, Nextnode = null, Previousnode = null };
            if(head == null)
            {
                Console.WriteLine("List is empty. Adding as head node.");
                head = NewNode;
                return;
            }
            if (Postion == 0)
            {
                NewNode.Nextnode = head;
                head.Previousnode = NewNode;
                head = NewNode; // head is now pointing to the new node
                return;
            }
            DoublyNode temp = head;
            int count = 0;  
            while (temp != null && count <= Postion)
            {
                temp = temp.Nextnode;
                count++;
            }
            if (temp == null)
            {
                Console.WriteLine("Position out of range.");
                return;
            }
            NewNode.Previousnode = temp.Previousnode;
            NewNode.Nextnode = temp;
            if(temp.Nextnode != null)
            {
                temp.Previousnode.Nextnode= NewNode;
            }
            temp.Previousnode = NewNode;
        }
        public static void searchbyvalue(int value)
        {
            DoublyNode temp = head;
            while (temp != null)
            {
                if (temp.Value == value)
                {
                    Console.WriteLine($"Desired Number found in the linked list: {value}");
                    return;
                }
                temp = temp.Nextnode;
            }
            Console.WriteLine($"Desired Number not found in the linked list: {value}");
        }
        public static void DeleteFirstNode(int value)
        {
            DoublyNode temp = head;
            if (temp == null)
            {
                Console.WriteLine("List is empty. Cannot delete.");
                return;
            }
            if (temp.Value == value)
            {
                head = temp.Nextnode;
                if (head != null)
                {
                    head.Previousnode = null;
                }
                Console.WriteLine($"Node with value {value} deleted from the start of the linked list.");
                return;
            }
            while (temp != null && temp.Value != value)
            {
                temp = temp.Nextnode;
            }
            if (temp == null)
            {
                Console.WriteLine($"Node with value {value} not found in the linked list.");
                return;
            }
            if (temp.Previousnode != null)
            {
                temp.Previousnode.Nextnode = temp.Nextnode;
            }
            if (temp.Nextnode != null)
            {
                temp.Nextnode.Previousnode = temp.Previousnode;
            }
            Console.WriteLine($"Node with value {value} deleted from the linked list.");
        }

        public static void DeleteLastNode()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty. Cannot delete.");
                return;
            }

            // Case: only one node
            if (head.Nextnode == null)
            {
                Console.WriteLine($"Node with value {head.Value} deleted. List is now empty.");
                head = null;
                return;
            }

            // Traverse to the last node
            DoublyNode temp = head;
            while (temp.Nextnode != null)
            {
                temp = temp.Nextnode;
            }

            // Remove last node
            Console.WriteLine($"Node with value {temp.Value} deleted from the end of the list.");
            temp.Previousnode.Nextnode = null;
        }
        public static void DeleteByValue(int value)
        {
            DoublyNode temp = head;
            while (temp != null && temp.Value != value)
            {
                temp = temp.Nextnode;
            }

            if (temp == null)
            {
                Console.WriteLine($"Value {value} not found in the list.");
                return;
            }
            // If the node to delete is the head
            if (temp == head)
            {
                head = temp.Nextnode;
                if (head != null)
                {
                    head.Previousnode = null;
                }
            }
            else
            {
                if (temp.Previousnode != null)
                {
                    temp.Previousnode.Nextnode = temp.Nextnode;
                }

                if (temp.Nextnode != null)
                {
                    temp.Nextnode.Previousnode = temp.Previousnode;
                }
            }
            Console.WriteLine($"Node with value {value} deleted.");
        }
        public static void DeleteByPosition(int position)
        {
            DoublyNode temp = head;
            int count = 0;
            while(temp!= null && count< position)
            {
                temp = temp.Nextnode;
                count++;
            }
            if(temp == null)
            {
                return;
            }
            if (temp == head) 
            { 
                head = temp.Nextnode;
                if(head != null)
                {
                    head.Previousnode = null;
                }
            }
            else
            {
                if(temp.Previousnode != null)
                {
                    temp.Previousnode.Nextnode = temp.Nextnode;
                }
                if (temp.Nextnode != null)
                {
                    temp.Nextnode.Previousnode = temp.Previousnode;
                }
            }
        }
        public static void Print()
        {
            DoublyNode current = head;
            if (current == null)
            {
                Console.WriteLine("The linked list is empty.");
                return;
            }
            Console.Write("Linked List: ");
            while (current != null)
            {
                Console.Write(" <- "+current.Value + " -> ");
                current = current.Nextnode;
            }
            Console.WriteLine("null");
        }
    }
}
