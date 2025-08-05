namespace LinkedList
{
    public class Program
    {
        /*
            We create nodes and link them to form a list:
            1 → 2 → 3 → 4 → 5 → null (initially)
            Then we manually create a cycle by making node 5's Next point back to node 2:
            5 → 2 which causes the list to loop infinitely.
            We call HasCycle() to check if the list has a cycle.
            It returns true because the cycle exists.
            We print the result.
            Floyd’s algorithm uses two pointers moving at different speeds to detect if they ever meet inside a cycle.
       
            Types of Linked list:- 
            1) Singly Linked List eg: 1 -> 2 -> 3 -> 4 -> 5 -> null
            2) Doubly Linked List eg: 1 <-> 2 <-> 3 <-> 4 <-> 5
            3) Circular Linked List eg: 1 -> 2 -> 3 -> 4 -> 5 -> 1 (last node points to the first node)
            4) Circular Doubly Linked List eg: 1 <-> 2 <-> 3 <-> 4 <-> 5 <-> 1 (last node points to the first node and vice versa)

            Question :- 
            "How would you find the middle element of a linked list?"
            The "Slow and Fast" Pointer Approach (Floyd's Cycle-Finding Algorithm): 
            Use two pointers, one (slow) that moves one step at a time, and another (fast) 
            that moves two steps at a time. When the fast pointer reaches the end of the list, the slow pointer will be at the middle.

            Question :-
            "How do you reverse a singly linked list?"
            Iterate through the list, changing the next pointer of each node to point 
            to the previous node. Keep track of three pointers: previous, current, and next_node.
            
         */
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.WriteLine("Hello, World!");
                    Console.WriteLine("Enter Element of the Linked list");
                    Console.WriteLine("Which linked list do you want to perform ?");
                    Console.WriteLine("1. Singly Linked List");
                    Console.WriteLine("2. Doubly Linked List");
                    Console.WriteLine("3. Circular Linked List");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("You have selected Singly Linked List");
                            SinglyLinkedList.SinglyLinkedlist();
                            break;
                        case 2:
                            Console.WriteLine("You have selected Doubly Linked List");
                            break;
                        case 3:
                            Console.WriteLine("You have selected Circular Linked List");
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            continue;
                    }
                    // Advance Switch Expression
                    /*var message = choice switch
                    {
                        1 => "You have selected Singly Linked List",
                        2 => "You have selected Doubly Linked List",
                        3 => "You have selected Circular Linked List",
                        _ => "Invalid choice, please try again."
                    };*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                Console.WriteLine("Do you want to continue? (y/n)");
            } while (Console.ReadLine().ToLower() == "y");
        }
    }
}
