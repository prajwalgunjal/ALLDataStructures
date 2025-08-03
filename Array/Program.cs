using System.Threading.Tasks;

namespace Array
{
    internal class Program
    {
        public static int[] numbers;
        public static bool isContinue = false;
        static async Task Main(string[] args)
        {
            try
            {
                do
                {
                    // Declare and initialize an array
                    Console.WriteLine("Enter Size of the Array");
                    int size = Convert.ToInt32(Console.ReadLine());
                    numbers = new int[size];
                    Console.WriteLine($"Array of legth {size} is initlized");
                    fillData();
                    PrintArray();
                    Console.WriteLine("Do you want to continue ? then press y");
                    isContinue = Console.ReadLine().ToLower() == "y" ? true : false;
                } while (Console.ReadLine() != "exit" && !isContinue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void fillData()
        {
            Console.WriteLine("Enter elements for the array:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Element {i + 1}: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public static void PrintArray()
        {
            Console.WriteLine("Array Elements:");
            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }
        }
        public static void bubblesort()
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        // Swap
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Array sorted using bubble sort.");
        }
        public static int LinearSearch(int element)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == element)
                {
                    return i; // Return the index of the found element
                }
            }
            return -1; // Return -1 if the element is not found
        }
        public static bool deleteaNumber(int element)
        {
            int index = LinearSearch(element);
            if (index != -1)
            {
                for (int i = index; i < numbers.Length - 1; i++)
                {
                    numbers[i] = numbers[i + 1];
                }
                Resize(ref numbers, numbers.Length - 1);
                Console.WriteLine($"Element {element} deleted successfully.");
                return true;
            }
            else
            {
                Console.WriteLine($"Element {element} not found in the array.");
                return false;
            }
        }
        public static void Resize(ref int[] array, int newSize)
        {
            if (newSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(newSize), "New size must be non-negative.");
            }
            int[] newArray = new int[newSize];
            for (int i = 0; i < Math.Min(array.Length, newSize); i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }
        public static void ReverseArray()
        {
            int start = 0;
            int end = numbers.Length - 1;
            while (start < end)
            {
                // Swap elements
                int temp = numbers[start];
                numbers[start] = numbers[end];
                numbers[end] = temp;
                start++;
                end--;
            }
            Console.WriteLine("Array reversed successfully.");
        }
        public static void ClearArray()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = 0; // Set each element to zero
            }
            Console.WriteLine("Array cleared successfully.");
        }
        public static bool addNumber(int number)
        {
            if (numbers.Length < 100) // Assuming a maximum size of 100 for simplicity
            {
                Resize(ref numbers, numbers.Length + 1); // Resize the array to add a new element
                numbers[numbers.Length - 1] = number; // Add the new number at the end
                Console.WriteLine($"Number {number} added successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Array is full. Cannot add more elements.");
                return false;
            }
        }
    }
}
