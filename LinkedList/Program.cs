namespace LinkedList
{
    public class Program
    {
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
