using System;
using System.Collections.Concurrent;

namespace AllThreadingConcpets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🚀 Main started\n");

            // 1️⃣ Multithreading with Thread
            Console.WriteLine("🔹 MultiThreading Example:");
            MultiThreadingExample();

            // 2️⃣ Parallel Processing
            Console.WriteLine("\n🔹 Parallel Processing Example:");
            ParallelProcessingExample();

            // 3️⃣ ThreadPool
            Console.WriteLine("\n🔹 ThreadPool Example:");
            ThreadPoolExample();

            // 4️⃣ Semaphore
            Console.WriteLine("\n🔹 Semaphore Example:");
            SemaphoreExample();

            // 5️⃣ Async/Await
            AsyncAwaitExample();
            // 6️⃣ Locking
            LockExample();
            // 7️⃣ Concurrent Collections
            ConcurrentCollectionExample();
            // 8️⃣ CancellationToken
            CancellationExample();
            // 9️⃣ Exception Handling in Tasks
            ExceptionHandlingExample();
            // 🔟 ThreadLocal Storage
            ThreadLocalStorageExample();


            // Prevent console from closing immediately
            Console.WriteLine("\n⏳ Press any key to exit...");
            Console.ReadKey();
        }

        // ──────────────────────────────
        // 1️⃣ MultiThreading using Thread
        // ──────────────────────────────
        static void MultiThreadingExample()
        {
            void Task1() => Console.WriteLine($"Task1 running on Thread {Thread.CurrentThread.ManagedThreadId}");
            void Task2() => Console.WriteLine($"Task2 running on Thread {Thread.CurrentThread.ManagedThreadId}");

            Thread t1 = new Thread(new ThreadStart(Task1));
            Thread t2 = new Thread(new ThreadStart(Task2));

            t1.Start();
            t2.Start();

            t1.Join(); // Wait for completion
            t2.Join();
        }

        // ──────────────────────────────
        // 2️⃣ Parallel Processing (Parallel.For)
        // ──────────────────────────────
        static void ParallelProcessingExample()
        {
            Parallel.For(1, 6, i =>
            {
                Console.WriteLine($"Parallel Task {i} running on Thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(200); // Simulate some work
            });
        }

        // ──────────────────────────────
        // 3️⃣ ThreadPool Example
        // ──────────────────────────────
        static void ThreadPoolExample()
        {
            WaitCallback task = state =>
            {
                Console.WriteLine($"ThreadPool Task running on Thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(300);
            };

            for (int i = 0; i < 3; i++)
            {
                ThreadPool.QueueUserWorkItem(task);
            }

            // Let the thread pool complete its work
            Thread.Sleep(1000);
        }
        // 4️⃣ Semaphore Example
        static void SemaphoreExample()
        {
            // Allow only 2 threads at a time
            SemaphoreSlim semaphore = new SemaphoreSlim(2);

            void Task(int id)
            {
                Console.WriteLine($"Thread {id} is waiting to enter the semaphore...");
                semaphore.Wait(); // Wait to enter
                Console.WriteLine($"✅ Thread {id} entered the semaphore.");

                Thread.Sleep(1000); // Simulate work

                Console.WriteLine($"❌ Thread {id} is leaving the semaphore.");
                semaphore.Release(); // Exit and allow another thread
            }

            for (int i = 1; i <= 5; i++)
            {
                int localId = i; // capture variable
                new Thread(() => Task(localId)).Start();
            }

            // Allow time for all threads to finish
            Thread.Sleep(4000);
        }
        //AsyncAwaitExample()
        static async void AsyncAwaitExample()
        {
            async Task<int> SlowOperation()
            {
                await Task.Delay(1000);
                Console.WriteLine($"✅ Completed on Thread {Thread.CurrentThread.ManagedThreadId}");
                return 42;
            }

            Console.WriteLine("🔹 Async/Await Example:");
            int result = await SlowOperation();
            Console.WriteLine($"Result: {result}");
        }
        // 2. LockExample()
        static object _lockObj = new object();
        static int sharedCounter = 0;

        static void LockExample()
        {
            Console.WriteLine("🔹 Lock Example:");
            void Increment()
            {
                for (int i = 0; i < 1000; i++)
                {
                    lock (_lockObj)
                    {
                        sharedCounter++;
                    }
                }
            }

            Thread t1 = new Thread(Increment);
            Thread t2 = new Thread(Increment);

            t1.Start(); t2.Start();
            t1.Join(); t2.Join();

            Console.WriteLine($"Final counter: {sharedCounter}"); // Should be 2000
        }

        // 3. ConcurrentCollectionExample()

        static void ConcurrentCollectionExample()
        {
            Console.WriteLine("🔹 ConcurrentDictionary Example:");
            ConcurrentDictionary<int, string> dict = new ConcurrentDictionary<int, string>();

            Parallel.For(0, 5, i =>
            {
                dict.TryAdd(i, $"Value {i}");
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} added Key: {i}");
            });

            foreach (var kv in dict)
                Console.WriteLine($"Key: {kv.Key}, Value: {kv.Value}");
        }
        // 4. CancellationExample()
        static void CancellationExample()
        {
            Console.WriteLine("🔹 CancellationToken Example:");

            CancellationTokenSource cts = new CancellationTokenSource();

            Task task = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("❌ Task cancelled");
                        return;
                    }
                    Console.WriteLine($"Working... {i}");
                    Thread.Sleep(300);
                }
            }, cts.Token);

            Thread.Sleep(1000); // Let it work a bit
            cts.Cancel();       // Cancel after 1 sec
            task.Wait();
        }
        // 5. ExceptionHandlingExample()
        static void ExceptionHandlingExample()
        {
            Console.WriteLine("🔹 Exception Handling in Task:");

            Task task = Task.Run(() =>
            {
                throw new InvalidOperationException("💥 Something went wrong!");
            });

            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Handled exception: {ex.InnerException.Message}");
            }
        }

        // 6. ThreadLocalStorageExample()
        static void ThreadLocalStorageExample()
        {
            Console.WriteLine("🔹 ThreadLocal<T> Example:");

            ThreadLocal<int> localData = new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });

            void ShowThreadId()
            {
                Console.WriteLine($"Thread ID stored: {localData.Value}");
            }

            Thread t1 = new Thread(ShowThreadId);
            Thread t2 = new Thread(ShowThreadId);
            t1.Start(); t2.Start();
            t1.Join(); t2.Join();
        }
    }
}
