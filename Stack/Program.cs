namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            Console.WriteLine("Top of stack: " + stack.Peek()); // C
            Console.WriteLine("Popped: " + stack.Pop()); // C
            Console.WriteLine("Popped: " + stack.Pop()); // B
            stack.Push("D");
            Console.WriteLine("Top of stack: " + stack.Peek()); // D
            /*
             🔹 A. Stack<T> (Generic Stack)
                Type-safe (generic)
                Backed by an array (dynamic resizing)
                ➡️ Most commonly used stack type in C#

            B. Stack (Non-generic)
                Stores objects, not type-safe (boxing/unboxing happens)
                ❌ Not recommended — replaced by Stack<T>

             C. ConcurrentStack<T>
                Thread-safe stack — can be safely used in multi-threaded apps
                Supports atomic Push() and TryPop()
                ✅ Use this when you’re working with parallel tasks or threads


             */
        }
    }
}
