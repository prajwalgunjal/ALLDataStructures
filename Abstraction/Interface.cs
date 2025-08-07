using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Interface
{// 1️⃣ Interface declaration
    interface IVehicle
    {
        void Start();   // Method without body
        void Stop();
    }

    // 2️⃣ Class implementing the interface
    class Car : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Car started.");
        }

        public void Stop()
        {
            Console.WriteLine("Car stopped.");
        }
    }

    // 3️⃣ Another class implementing the same interface
    class Bike : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Bike started.");
        }

        public void Stop()
        {
            Console.WriteLine("Bike stopped.");
        }
    }

    // 4️⃣ Main program
    class Interface
    {
        public static void Interface_()
        {
            IVehicle vehicle1 = new Car();   // Using interface reference
            vehicle1.Start();
            vehicle1.Stop();

            Console.WriteLine();

            IVehicle vehicle2 = new Bike();  // Polymorphism via interface
            vehicle2.Start();
            vehicle2.Stop();
        }
    }
}
