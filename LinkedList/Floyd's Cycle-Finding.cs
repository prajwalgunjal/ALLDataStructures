using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node_
    {
        public int Data;
        public Node_ Next;

        public Node_(int data)
        {
            Data = data;
            Next = null;
        }
    }

    class LinkedList
    {
        public Node_ Head;

        // Floyd's Cycle-Finding Algorithm
        public bool HasCycle()
        {
            Node_ slow = Head;
            Node_ fast = Head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                    return true; // Cycle detected
            }

            return false; // No cycle
        }
    }
    class Floyd_s_Cycle_Finding
    {
        static void Main()
        {
            LinkedList list = new LinkedList();
            list.Head = new Node_(1);
            list.Head.Next = new Node_(2);
            list.Head.Next.Next = new Node_(3);
            list.Head.Next.Next.Next = new Node_(4);
            list.Head.Next.Next.Next.Next = new Node_(5);
            // Creating a cycle: node 5 points back to node 2
            list.Head.Next.Next.Next.Next.Next = list.Head.Next;

            bool hasCycle = list.HasCycle();
            Console.WriteLine("Cycle detected? " + hasCycle); // Output: true
        }
    }
}
