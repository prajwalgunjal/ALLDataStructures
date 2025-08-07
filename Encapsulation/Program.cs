namespace Encapsulation
{
    /*
     what is encapsulation?
        Encapsulation is the bundling of data (attributes) and methods (functions) that operate on that data into a single unit, or class.
            1) We'll make the internal Balance and AccountNumber fields private.
            2) We'll expose them using public properties with custom logic or get-only access.
            3) We'll ensure that direct manipulation is not possible from outside the class.
    */

    /*
    | Concept            | In Your Code                                                                                              |
    | ------------------ | --------------------------------------------------------------------------------------------------------- |
    | **Encapsulation**  | The `Person` class hides its `age` field and only allows access through `SetAge()` and `GetAge()` methods |
    | **Access Control** | Ensures age can't be modified inappropriately                                                             |
    | **Data Safety**    | Protects object integrity from invalid data                                                               |
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Encapsulation.Encapsulation_();
            Console.WriteLine("Hello, World!");
        }
    }
    /*
         * 🟢 What it shows:
        The field age is private and accessed only via public methods with validation — that’s encapsulation.
     */
    class Person
    {
        private int age; // 🔒 Private data

        public void SetAge(int value)
        {
            if (value >= 0 && value <= 120)
                age = value;
            else
                Console.WriteLine("Invalid age!");
        }

        public int GetAge()
        {
            return age;
        }
    }

    class Encapsulation
    {
        public static void Encapsulation_()
        {
            Person p = new Person();
            p.SetAge(25);               // ✅ Safe access
            Console.WriteLine(p.GetAge());

            p.SetAge(-5);               // ❌ Invalid access (rejected)
        }
    }
}
