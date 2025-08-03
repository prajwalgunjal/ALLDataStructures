using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SinglyLinkedList
    {
        public static Node head = null;
        public static void SinglyLinkedlist()
        {
            do
            {
                Console.WriteLine("Enter Element of the Linked list");
                int value = Convert.ToInt32(Console.ReadLine());
                AddToEndoftheSinglyLinkedList(value);
                Console.WriteLine("Do you want to add another node? (y/n)");
            } while (Console.ReadLine().ToLower() == "y");
            PrintLinkedList();
        }
        public static void AddToEndoftheSinglyLinkedList(int value)
        {
            Node newNode = new Node { Value = value, Nextnode = null };
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node Temp = head;
                while (Temp.Nextnode != null)
                {
                    Temp = Temp.Nextnode;
                }
                Temp.Nextnode = newNode;
            }
            Console.WriteLine($"Node with value {value} added to the linked list.");
        }
        public static void addToStartOfSinglyLinkedList(int Val)
        {
            Node newNode = new Node { Value = Val, Nextnode = null };
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Nextnode = head;
            }
        }
        public static void searchInSignlyLinkedList(int number)
        {
            Node temp = head;
            while (temp.Nextnode != null)
            {
                if (temp.Value == number)
                {
                    Console.WriteLine($"Desired Number found in the linked list {number}");
                }
                else
                    temp = temp.Nextnode;
            }
            Console.WriteLine($"Desired number is not found in the linked list {number}");
        }
        public static void AddInBetweenOfLinkedList(int number, int pos)
        {
            Node newNode = new Node { Value = number, Nextnode = null };
            int count = 0;
            Node current = head;
            if (pos == 0)
            {
                newNode.Nextnode = head;
                head = newNode;
                return;
            }
            while (current != null && count < pos - 1)
            {
                current = current.Nextnode;
                count++;
            }
            if (current == null)
            {
                Console.WriteLine("Position out of range.");
                return;
            }
            newNode.Nextnode = current.Nextnode;
            current.Nextnode = newNode;

            Console.WriteLine($"Node with value {number} added at position {pos}.");
        }
        public static void DeleteByPosition(int Pos)
        {
            Node Temp = head;
            if (head == null)
            {
                Console.WriteLine("The linked list is empty.");
                return;
            }
            if (Pos == 0)
            {
                head = head.Nextnode;
                return;
            }
            int count = 0;
            while (Temp != null && count < Pos - 1)
            {
                Temp = Temp.Nextnode;
                count++;
            }
            if (Temp == null || Temp.Nextnode == null)
            {
                Console.WriteLine("Position out of range.");
                return;
            }
            Node NodeToDelete = Temp.Nextnode;
            Temp.Nextnode = NodeToDelete.Nextnode;
        }
        public static void DeleteByValue(int Value)
        {
            if (head == null)
            {
                Console.WriteLine("LinkedList is empty");
                return;
            }
            // If head is the node to delete
            if (head.Value == Value)
            {
                Console.WriteLine($"Node with value {Value} deleted from the linked list.");
                head = head.Nextnode;
                return;
            }
            Node Temp = head;
            while (Temp.Value != Value)
            {
                if (Temp.Nextnode == null)
                {
                    Console.WriteLine("Value not found in the linked list.");
                    return;
                }
                Temp = Temp.Nextnode;
            }
            if (Temp == head)
            {
                head = head.Nextnode;
            }
            else
            {
                Node Prevoius = head;
                while (Prevoius.Nextnode != Temp)
                {
                    Prevoius = Prevoius.Nextnode;
                }
                Prevoius.Nextnode = Temp.Nextnode;
            }
        }
        public static void PrintLinkedList()
        {
            Node current = head;
            if (current == null)
            {
                Console.WriteLine("The linked list is empty.");
                return;
            }
            Console.Write("Linked List: ");
            while (current != null)
            {
                Console.Write(current.Value + " -> ");
                current = current.Nextnode;
            }
            Console.WriteLine("null");
        }
    }
}
