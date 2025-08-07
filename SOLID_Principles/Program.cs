namespace SOLID_Principles
{
    using System;

    namespace SOLID_Demo
    {
        // ──────────────────────────────
        // 1️⃣ S - Single Responsibility -
        // A class should have one reason to change
        // A Class should have only one responsibility, meaning it should only have one job or task.
        // ──────────────────────────────
        class Report
        {
            public string Title { get; set; } = "Monthly Report";
            public string Content { get; set; } = "Report data...";

            public string Generate()
            {
                return $"Title: {Title}\nContent: {Content}";
            }
        }

        class ReportPrinter
        {
            public void Print(string report)
            {
                Console.WriteLine("🖨️ Printing Report:");
                Console.WriteLine(report);
            }
        }

        // ──────────────────────────────
        // 2️⃣ O - Open/Closed Principle - open for extension, closed for modification
        // ──────────────────────────────
        abstract class Discount
        {
            public abstract double Apply(double amount);
        }

        class NoDiscount : Discount
        {
            public override double Apply(double amount) => amount;
        }

        class SeasonalDiscount : Discount
        {
            public override double Apply(double amount) => amount * 0.9;
        }

        class Invoice
        {
            private readonly Discount _discount;
            private readonly double _amount;

            public Invoice(double amount, Discount discount)
            {
                _amount = amount;
                _discount = discount;
            }

            public double GetFinalAmount()
            {
                return _discount.Apply(_amount);
            }
        }

        // ──────────────────────────────
        // 3️⃣ L - Liskov Substitution Principle - objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program
        // ──────────────────────────────

        class Bird
        {
            public virtual void Eat() => Console.WriteLine("Bird is eating");
        }

        interface IFlyable
        {
            void Fly();
        }

        class Sparrow : Bird, IFlyable
        {
            public void Fly() => Console.WriteLine("Sparrow is flying");
        }

        class Penguin : Bird
        {
            // Penguins don't implement IFlyable — correct use of LSP
        }

        // ──────────────────────────────
        // 4️⃣ I - Interface Segregation Principle - Clients should not implement unused functions they do not need
        // ──────────────────────────────

        interface IPrinter
        {
            void Print();
        }

        interface IScanner
        {
            void Scan();
        }

        class MultiFunctionPrinter : IPrinter, IScanner
        {
            public void Print() => Console.WriteLine("Printing document...");
            public void Scan() => Console.WriteLine("Scanning document...");
        }

        class SimplePrinter : IPrinter
        {
            public void Print() => Console.WriteLine("Printing only...");
        }

        // ──────────────────────────────
        // 5️⃣ D - Dependency Inversion - Classes should depend on interfaces, not on concrete classes
        // ──────────────────────────────

        interface ILogger
        {
            void Log(string message);
        }

        class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine("📘 Log: " + message);
            }
        }

        class App
        {
            private readonly ILogger _logger;

            public App(ILogger logger)
            {
                _logger = logger;
            }

            public void Run()
            {
                _logger.Log("Application started.");
            }
        }
        // ──────────────────────────────
        // 🚀 Main Program
        // ──────────────────────────────
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("====== SOLID Principles Demo ======\n");

                // 1️⃣ Single Responsibility
                var report = new Report();
                var printer = new ReportPrinter();
                printer.Print(report.Generate());

                // 2️⃣ Open/Closed
                Console.WriteLine("\n🧾 Applying Discount (OCP):");
                var invoice = new Invoice(1000, new SeasonalDiscount());
                Console.WriteLine("Final Invoice Amount: " + invoice.GetFinalAmount());

                // 3️⃣ Liskov Substitution
                Console.WriteLine("\n🐦 Bird Behavior (LSP):");
                Bird sparrow = new Sparrow();
                sparrow.Eat();
                ((IFlyable)sparrow).Fly();

                Bird penguin = new Penguin();
                penguin.Eat();
                // penguin doesn't fly — no error, no violation

                // 4️⃣ Interface Segregation
                Console.WriteLine("\n📄 Printer Devices (ISP):");
                IPrinter simplePrinter = new SimplePrinter();
                simplePrinter.Print();

                MultiFunctionPrinter mfp = new MultiFunctionPrinter();
                mfp.Print();
                mfp.Scan();

                // 5️⃣ Dependency Inversion
                Console.WriteLine("\n🧩 Logger Dependency (DIP):");
                ILogger logger = new ConsoleLogger();
                var app = new App(logger);
                app.Run();

                Console.WriteLine("\n====== End of Demo ======");
            }
        }
    }

}
