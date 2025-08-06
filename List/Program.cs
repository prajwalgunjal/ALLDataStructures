namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Custom List Example!");
            Console.WriteLine("Please enter the initial size of the list (number of elements):");
            int size = Convert.ToInt16(Console.ReadLine());
            if (size <= 0)
            {
                Console.WriteLine("Size must be a positive integer. Setting size to 10.");
                size = 10; // Default size
            }
            CustomList<string> myList = new CustomList<string>(size);
            myList.Add("Dog");
            myList.Add("Cat");
            myList.Add("Rabbit");

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList.Get(i));
            }

        }
    }
}
