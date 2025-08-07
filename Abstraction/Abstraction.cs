using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Interface
{
    public abstract class Animal {
        public abstract void makeSound();
        public void sleep()
        {
            Console.WriteLine("Animal is sleeping");
        }
    }
    public class Dog : Animal
    {
        public override void makeSound() {
            Console.WriteLine("Barkkkk!!!!");
        }
    }
    public class Cat : Animal
    {
        public override void makeSound()
        {
            Console.WriteLine("Meow!!!!!");
        }
    }
}
