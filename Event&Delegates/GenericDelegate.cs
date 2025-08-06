using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Delegates
{
    public delegate T MyGenericDelegate<T>(T value); // ✅ Generic delegate
    class GenericDelegate
    {
        // Normal Method that matches the delegate for int
        public static int Square(int x)
        {
            return x * x;
        }
        // Generic method that matches the delegate for any type T
        public static T Square<T>(T x)
        {
            return (dynamic)x * (dynamic)x;
        }

        // Method that matches the delegate for string
        public static string Repeat(string s)
        {
            return s + s;
        }

        public static void GeneriDelegateExample()
        {
            // Using the generic delegate with int
            MyGenericDelegate<int> intDel = Square;
            MyGenericDelegate<int> intdel1 = Square<int>;
            Console.WriteLine(intDel(5));  // Output: 25

            // Using the generic delegate with string
            MyGenericDelegate<string> stringDel = Repeat;
            Console.WriteLine(stringDel("Hi"));  // Output: HiHi
        }
        // we can use generic delegates to create methods that can work with any data type,
    }
}
