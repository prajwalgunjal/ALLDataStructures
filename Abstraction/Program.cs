namespace Abstraction_Interface
{
    // what is Abstraction?
    // Abstraction means hiding complex internal details and showing only essential features to the user.
    /*
    ✅ What this demonstrates:
    
    1) Abstraction	    -> BankAccount hides inner logic of deposit, and forces subclasses to implement Withdraw()
    2) Abstract Class	-> Used to define common interface for all account types
    3) Polymorphism	    -> We use BankAccount savings = new SavingsAccount() — base type reference
    */

    /*
    | Feature                 | Role in Abstraction                                                                                          |
    | ----------------------- | ------------------------------------------------------------------------------------------------------------ |
    | `Animal` abstract class | Defines only the **essential contract** (e.g., animals must make sound) without specifying how.              |
    | `makeSound()`           | Forces each subclass to **provide its own behavior**, hiding internal logic from other classes.              |
    | `sleep()`               | Common implementation for all animals — no need to duplicate it in each subclass.                            |
    | Main method usage       | You interact with the **abstract type (`Animal`)**, not the specific ones — that’s the power of abstraction. |
    */
    class Program
    {
        static void Main()
        {
            // simple eg of abstraction encapsulation polymorphism and interface
            Animal dog = new Dog();
            dog.makeSound();
            dog.sleep();

            Animal cat = new Cat();
            cat.makeSound();
            cat.sleep();
            Interface.Interface_();
        }
    }
}
