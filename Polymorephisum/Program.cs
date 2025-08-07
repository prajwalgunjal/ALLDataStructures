namespace Polymorephisum
{
    /*
     what is polymorphism?
        Polymorphism means "many forms" and allows methods to do different things based on the object that it is acting upon.
        In C#, polymorphism is achieved through method overriding and interfaces.
        For example, we can have a method called `Withdraw` that behaves differently for `SavingsAccount` and `CurrentAccount`.
    */
    /*
    | Type             | Also Called | Achieved Using         |
    | ---------------- | ----------- | ---------------------- |
    | **Compile-time** | Static      | **Method Overloading** |
    | **Runtime**      | Dynamic     | **Method Overriding**  |


    | Concept                     | Code Example            | Type         | Behavior                                                     |
    | --------------------------- | ----------------------- | ------------ | ------------------------------------------------------------ |
    | `Speak()` method overridden | `Dog` and `Cat` classes | Runtime      | Different outputs at runtime depending on object type        |
    | `Add()` method overloaded   | `Calculator` class      | Compile-time | Different method selected at compile time based on arguments |
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Polymorphism.Polymorphism_();
        }
    }
    /*
         * 🟢 What it shows:
        The same method Speak() behaves differently depending on the object — that’s polymorphism.
     */

    // ✅ Runtime Polymorphism using method overriding
    class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("Animal speaks.");
        }
    }

    class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Dog barks.");
        }
    }
    // ✅ Compile-Time Polymorphism using method overloading
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }

        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
    }

    class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Cat meows.");
        }
    }

    class Polymorphism
    {
        public static void Polymorphism_()
        {
            Console.WriteLine("🔸 Runtime Polymorphism:");

            Animal a1 = new Dog();
            Animal a2 = new Cat();

            a1.Speak();  // Output: Dog barks.
            a2.Speak();  // Output: Cat meows.

            Console.WriteLine("\n🔸 Compile-Time Polymorphism:");

            Calculator calc = new Calculator();
            Console.WriteLine("Add(int, int): " + calc.Add(2, 3));           // 5
            Console.WriteLine("Add(double, double): " + calc.Add(2.5, 3.5)); // 6.0
            Console.WriteLine("Add(int, int, int): " + calc.Add(1, 2, 3));   // 6
        }
    }
}
