namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            CustomQueue<string> queue = new CustomQueue<string>();
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");
            Console.WriteLine("Front of queue: " + queue.Peek()); // A
            Console.WriteLine("Dequeued: " + queue.Dequeue()); // A
            Console.WriteLine("Dequeued: " + queue.Dequeue()); // B
            queue.Enqueue("D");
            Console.WriteLine("Front of queue: " + queue.Peek()); // C

            /*
             * Types of queue
             * 1) Linear Queue
             * 2) Circular Queue
             * 3) Priority Queue
             * 4) Deque (Double Ended Queue)
             * 5) Blocking Queue
             * 6) Concurrent Queue
             * 7) Circular Buffer Queue
             * 8) Circular Linked List Queue
                        
                        ✅ Step 1: Enqueue("A")
                        rear = (rear + 1) % capacity = (−1 + 1) % 4 = 0
                        Put "A" at index 0
                        rear = 0, front = 0, count = 1
                        [ A, -, -, - ]
                          ↑
                         front & rear

                        ✅ Step 2: Enqueue("B")
                        rear = (rear + 1) % capacity = (0 + 1) % 4 = 1
                        Put "B" at index 1
                        rear = 1, front = 0, count = 2
                        [ 0, 1, 2, 3 ]
                        [ A, B, -, - ]
                          ↑  ↑
                          f   r

                        ✅ Step 3: Enqueue("C")
                        rear = (rear + 1) % capacity = (1 + 1) % 4 = 2
                        Put "C" at index 2
                        rear = 2, front = 0, count = 3
                        [ 0, 1, 2, 3 ]
                        [ A, B, C, - ]
                          ↑     ↑
                          f     r

                        ✅ Step 4: Dequeue()
                        front = (0 + 1) % 4 = 1
                        Removes "A" from index 0
                        front = 1, count = 2
                        [ 0, 1, 2, 3 ]
                        [ -, B, C, - ]
                             ↑     ↑
                             f     r

                        ✅ Step 5: Dequeue()
                        front = (1 + 1) % 4 = 2
                        Removes "B" from index 1
                        front = 2, count = 1
                        [ -, B, C, D ]
                             ↑     ↑
                             f     r

                        ✅ Step 6: Enqueue("D")
                        rear = (3 + 1) % 4 = 0
                        Put "E" at index 0 (wraps around)
                        rear = 0, count = 4
                        [ E, B, C, D ]
                             ↑  ↑
                             f  r

                        🧠 Why This Is Smart
                        Instead of shifting every time, we just update indices with %.
                        This makes the queue efficient in both space and time.

            */
        }
    }
}
