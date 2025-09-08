using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /*
    Decorator Pattern is a structural design pattern that 
    lets you add new behavior (functionality) to an object 
    at runtime without changing its original code.
    Eg: 
    Imagine a coffee shop ☕:
    Base coffee → Just black coffee.
    You can decorate it with milk 🥛, sugar 🍬, whipped cream 🍦, caramel 🍯.
    Each "topping" adds new behavior/cost without changing the original coffee class. 
    You don’t rewrite the coffee class every time → you just "wrap" it with decorators.
    */
    /*
    📐 Structure (in Simple Steps)
    Component (Interface/Abstract class) → common contract.
    Example: ICoffee with method GetCost() and GetDescription().

    Concrete Component → the base object.
    Example: SimpleCoffee.

    Decorator (Abstract Class) → wraps a component, implements the same interface.
    Example: CoffeeDecorator.

    Concrete Decorators → extend the base behavior.
    Example: MilkDecorator, SugarDecorator. 
    */
    class DecoratorDesignPattern
    {
        public static void DecoratorDesignPatternEx()
        {
            ICoffee coffee = new SimpleCoffee();  // Base coffee
            Console.WriteLine($"{coffee.GetDescription()} : {coffee.GetCost()}");

            coffee = new MilkDecorator(coffee);   // Add milk
            coffee = new SugarDecorator(coffee);  // Add sugar

            Console.WriteLine($"{coffee.GetDescription()} : {coffee.GetCost()}");
        }
    }
    // Step 1: Component
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    // Step 2: Concrete Component
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription() => "Simple Coffee";
        public double GetCost() => 5.0;
    }

    // Step 3: Base Decorator
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual string GetDescription() => _coffee.GetDescription();
        public virtual double GetCost() => _coffee.GetCost();
    }

    // Step 4: Concrete Decorators
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => base.GetDescription() + ", Milk";
        public override double GetCost() => base.GetCost() + 2.0;
    }

    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => base.GetDescription() + ", Sugar";
        public override double GetCost() => base.GetCost() + 1.0;
    }
}
