namespace Dependency_Injection
{
    internal class Program
    {
        /*
         *  Dependency Injection (DI) is a design pattern where an object’s dependencies 
            (other classes it needs) are provided from outside, rather than the object creating them itself.
            This promotes:
                Loose coupling
                Easier testing (mocking)
                Better maintainability
         🎯 Real-Life Analogy:
                Think of a car that needs an engine to run.
                Tightly coupled: The car creates the engine inside itself.
                Loosely coupled (DI): The engine is injected from outside — the car doesn't care which engine it is, as long as it works.
         */

        static void Main()
        {
            // Constructor injection
            ILogger logger = new ConsoleLogger();// CREATE dependency
            UserService userService = new UserService(logger); // INJECT dependency

            // Create user
            userService.CreateUser("john_doe");

            // Method injection
            INotifier notifier = new EmailNotifier();
            userService.NotifyUser("john@example.com", "Welcome, John!", notifier); // INJECT dependency throught method param only when needed

            Console.ReadLine();
        }
    }
    public interface ILogger
    {
        void Log(string message);
    }
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("[ConsoleLogger] " + message);
        }
    }
    public class UserService
    {
        private readonly ILogger _logger; // Dependency

        // 🔧 Inject dependency via constructor
        public UserService(ILogger logger)
        {
            _logger = logger;
        }

        public void CreateUser(string username)
        {
            // Simulate user creation
            _logger.Log($"User '{username}' created successfully.");
        }

        // ✅ Method Injection (INotifier is passed only when needed)
        public void NotifyUser(string email, string message, INotifier notifier)
        {
            notifier.Send(email, message);
        }
    }


    // (For method injection)
    public interface INotifier
    {
        void Send(string to, string message);
    }

    public class EmailNotifier : INotifier
    {
        public void Send(string to, string message)
        {
            Console.WriteLine($"Email sent to {to}: {message}");
        }
    }
}
