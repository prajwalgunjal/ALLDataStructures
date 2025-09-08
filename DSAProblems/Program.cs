namespace DSAProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Substring();
            PairWithGivenSum([1, 2, 3, 4, 5],6);
            Console.WriteLine("Hello, World!");
        }

        public static void ReverseString(string Msg)
        {
            char[] charArray = Msg.ToCharArray();
            string reversedString = string.Empty;
            for (var i = charArray.Length - 1; i >= 0; i--)
            {
                reversedString += charArray[i];
            }
            Console.WriteLine(reversedString);
        }
        // Check if given string is Palimdrom or not
        // eg  1) madam => palimdrom
        //     2) hello => not palimdrom
        public static void Palimdrome(string Msg)
        {
            int left = 0;
            int right = Msg.Length - 1;
            while (left < right)
            {
                if (Msg[left] != Msg[right])
                {
                    Console.WriteLine("Not Palimdorm");
                    return;
                }
                left++;
                right--;
            }
            Console.WriteLine("given string is Palimdorm");
            return;
        }
        public static void checkAnagram(string str1, string str2)
        {
            // if length of both string is not same then they are not anagram
            // eg:- listen and silent => anagram
            // else if:- hello and hey => not anagram
            if (str1.Length != str2.Length)
            {
                Console.WriteLine("Given strings are not Anagram");
                return;
            }
            // count frequency of each char in first string
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in str1)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }
            // subtract count using second string
            foreach (char i in str2)
            {
                char C = str2.ToLower()[i];
                if (!charCount.ContainsKey(C))
                {
                    Console.WriteLine("Not Anagram");
                }
                else
                    charCount[C]--; // decrement count of that specific char
                if (charCount[C] < 0)
                {
                    Console.WriteLine("Not Anagram");
                }
            }
            Console.WriteLine("Given strings are Anagram");
        }
        public static void FindVowels(string Msg)
        {
            int count = 0;
            string vowels = "aeiouAEIOU";
            foreach (char c in Msg)
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }
            Console.WriteLine("Total Vowels in given string are : " + count);
        }
        // Find Substring of given string
        public static void Substring()
        {
            // eg:- ABCD
            // A, AB, ABC, ABCD
            string ip = "ABCD";
            for (int i = 0; i < ip.Length; i++)
            {
                for (int j = i + 1; j <= ip.Length - i; j++)
                {
                    string subString = ip.Substring(i, j - i); // this method Substring() will give you the string between the start and end index
                    Console.WriteLine(subString);
                }
            }
        }
        public static void MostFrequestChar(string MSG)
        {
            char[] charArray = MSG.ToCharArray();
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in charArray)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }
            char MostFrequentChar = charCount.OrderByDescending(x => x.Value).First().Key;
            Console.WriteLine(MostFrequentChar);
        }

        public static void PairWithGivenSum(int[] arr, int targetSum)
        {
            HashSet<int> seenNumbers = new HashSet<int>(); 
            // removing duplicate values
            // sort full array 
            // no need to sort array if we use hashset
            // No Duplicate values
            // find pair with given sum in array
            // eg :- arr = [1,2,3,4,5] , targetSum = 6
            var low = 0;
            var high = arr.Length - 1;
            while (low <= high)
            {
                if (arr[low] + arr[high] >targetSum)
                {
                    high--;
                }
                else if (arr[low] + arr[high] < targetSum)
                {
                    low++;
                }
                else
                {
                    Console.WriteLine($"Pair with given sum {targetSum} is ({arr[low]},{arr[high]})");
                    low++;
                    high--;
                }
            }
        }
        public static void FindSquareRootOfNumber()
        {
            int number = 16;
            int low = 1;
            int high = number;
            int ans = 0;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (mid * mid == number)
                {
                    ans = mid;
                    break;
                }
                else if (mid * mid < number)
                {
                    ans = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
        }
        public static void CheckprimeNumber(int number)
        {
            Console.WriteLine(number);
            if (number <= 1)
            {
                Console.WriteLine("Not Prime Number");
                return;
            }
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    Console.WriteLine("Not Prime Number");
                    return;
                }
            }
            Console.WriteLine("Given number is Prime Number");
        }
        public static void CheckOddNumber(int number)
        {
            if (number % 2 != 0)
            {
                Console.WriteLine("Given number is Odd Number");
            }
            else
            {
                Console.WriteLine("Given number is Even Number");
            }
        }
        public static void FindFactorial(int number)
        {
            // 5! = 5*4*3*2*1 = 120
            int fact = 1;
            for (int i = 1; i <= number; i++)
            {
                fact = fact * i;
            }
            Console.WriteLine("Factorial of given number is : " + fact);
        }
        public static void FibonacciSeries(int n)
        {
            // 0 1 1 2 3 5 8 13 21 ...
            int a = 0, b = 1, c;
            Console.Write(a + " " + b + " ");
            for (int i = 2; i < n; i++)
            {
                c = a + b;
                Console.Write(c + " ");
                a = b;
                b = c;
            }
        }
        public static void FindLargestElementInArray(int[] arr)
        {
            int largest = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > largest)
                {
                    largest = arr[i];
                }
            }
            Console.WriteLine("Largest element in given array is : " + largest);
        }
        public static void FindSmallestElementInArray(int[] arr)
        {
            int smallest = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < smallest)
                {
                    smallest = arr[i];
                }
            }
            Console.WriteLine("Smallest element in given array is : " + smallest);
        }
        public static void ReverseArray(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;
            while (start < end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
            Console.WriteLine("Reversed array is : " + string.Join(", ", arr));
        }
    }
}
