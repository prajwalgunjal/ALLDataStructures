using System.Linq;

namespace DSAProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //[7,1,5,3,6,4]
            var ele = new int[] { 7, 1, 5, 3, 6, 4 };
            var aaaa = MaxProfit_II(ele);
            int[] nums = new int[] { 2, 1, 3, 1, 4 };
            int ab = MajorityElement_mySol(nums);

            int[] arr = { 7, 1, 5, 3, 6, 4};
            _ = MaxProfit(arr);
            Substring();
            _ = PairWithGivenSum([1, 2, 3, 4, 5],6);
            Console.WriteLine("Hello, World!");
        }
        public static IList<int> MajorityElement_II(int[] nums)
        {
            Dictionary<int, int> Counter = new Dictionary<int, int>();
            foreach (var i in nums)
            {
                if (Counter.ContainsKey(i))
                {
                    Counter[i]++;
                }
                else
                {
                    Counter[i] = 1;
                }
            }
            int ThreshHold = nums.Length / 3;
            // Filter only elements with count > n/3 and return the keys
            return Counter.Where(pair => pair.Value > ThreshHold)
                          .Select(pair => pair.Key)
                          .ToList();

        }
        // Best time to buy and sell stock
        public static int MaxProfit(int[] prices)
        {

            int minPrice = int.MaxValue;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i]; // Update buy price
                }
                else if (prices[i] - minPrice > maxProfit)
                {
                    maxProfit = prices[i] - minPrice; // Update profit
                }
            }
            return maxProfit;
        }
        // Best time to buy and Sell Stock Problem II
        public static int MaxProfit_II(int[] prices)
        {
            //7,1,5,3,6,4
            int totalProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                // here sell is prices[i - 1] 
                // and buy is prices[i]
                if (prices[i] > prices[i - 1]) // sell price is getting compared with buy price 
                {
                    totalProfit += prices[i] - prices[i - 1];
                }
            }
            return totalProfit;
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

            public bool IsPalindrome(string s)
            {
            /*
            Example 1:
                Input: s = "A man, a plan, a canal: Panama"
                Output: true
                Explanation: "amanaplanacanalpanama" is a palindrome.
                
            Example 2:
                Input: s = "race a car"
                Output: false
                Explanation: "raceacar" is not a palindrome.
            */
            int start = 0;
                int end = s.Length - 1;

                while (start < end)
                {
                    // Skip non-alphanumeric characters
                    while (start < end && !Char.IsLetterOrDigit(s[start])) start++;
                    while (start < end && !Char.IsLetterOrDigit(s[end])) end--;

                    // Compare characters (case-insensitive)
                    if (Char.ToLower(s[start]) != Char.ToLower(s[end]))
                    {
                        return false;
                    }

                    start++;
                    end--;
                }
                return true;
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
        public static int MajorityElement_mySol(int[] nums)
        {
            Dictionary<int, int> IntCounter = new Dictionary<int, int>();
            foreach (int c in nums)
            {
                if (IntCounter.ContainsKey(c))
                    IntCounter[c]++;
                else
                    IntCounter[c] = 1;
            }
            int MostFrequentInt = IntCounter.OrderByDescending(x => x.Value).First().Key;
            return MostFrequentInt;
    }
        public void MoveZeroes(int[] nums)
        {
            /*
            Input: [0, 1, 0, 3, 12]
            i = 0, j = 0: nums[0] == 0, do nothing
            j = 1: nums[j] != 0 -> true -> nums[1] == 1 → swap with nums[0] → [1, 0, 0, 3, 12], i = 1
            j = 2: nums[j] != 0 -> false -> nums[2] == 0, do nothing
            j = 3: nums[j] != 0 -> true -> nums[3] == 3 → swap with nums[1] → [1, 3, 0, 0, 12], i = 2
            j = 4: nums[j] != 0 -> false -> nums[4] == 12 → swap with nums[2] → [1, 3, 12, 0, 0], i = 3
            */
            int i = 0; // Pointer to place next non-zero
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != 0)
                {// Swap nums[i] and nums[j] only if i != j to avoid unnecessary swaps
                    if (i != j)
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                    i++;
                }
            }
        }
        public static int[] PairWithGivenSum(int[] arr, int targetSum)
        {
            // sort the array but dont loose index
            var indexedArr = arr
                .Select((value, index) => new { Value = value, Index = index })
                .OrderBy(x => x.Value)
                .ToArray();

            int low = 0;
            int high = indexedArr.Length - 1;
            // traverse array
            while (low < high)
            {
                int sum = indexedArr[low].Value + indexedArr[high].Value;

                if (sum == targetSum)
                {
                    return new int[] { indexedArr[low].Index, indexedArr[high].Index };
                }
                else if (sum < targetSum)
                {
                    low++;// low ++ Because it is in sorted order 
                }
                else
                {
                    high--; // 
                }
            }
            throw new ArgumentException("No two sum solution");
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
