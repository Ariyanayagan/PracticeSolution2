
class Solution
{
    public long Powerrecusive(int n, int r)
    {
        if (r == 0)
        {
            return 1;
        }

        var answer = Powerrecusive(n, r / 2) % 1000000007;

        if (r % 2 == 0)
        {
            return (answer * answer) % 1000000007;
        }
        else
        {
            return ((answer * answer) % 1000000007 * n) % 1000000007;
        }

    }
    //Complete this function
    public long power(int n, int r)
    {
        //Your code here
        return Powerrecusive(n, r);

    }
    public int isPerfectNumber(long N)
    {
        // Base case: 1 is not a perfect number
        if (N <= 1)
        {
            return 0;
        }

        long sumOfDivisors = 1; // 1 is a proper divisor of all numbers > 1
        double SQRT = Math.Sqrt(N);
        // Iterate from 2 to sqrt(N)    
        for (long i = 2; i <= SQRT; i++)
        {
            if (N % i == 0)
            {
                sumOfDivisors += i;

                // Add the corresponding divisor N / i
                long correspondingDivisor = N / i;
                if (i != correspondingDivisor && correspondingDivisor != N)
                {
                    sumOfDivisors += correspondingDivisor;
                }
            }
        }

        // Check if the sum of divisors equals the number itself
        return sumOfDivisors == N ? 1 : 0;
    }
    public long PowerBinaryExpo(long N, long R)
    {
        long ans = 1;
        long mod = 1000000007;

        while (R > 0)
        {
            //ans = ans * N;
            //R--;
            if ((R & 1) != 0)
            {
                ans = (ans * N) % mod;
            }

            N = (N * N) % mod;
            R >>= 1;
        }

        return ans;
    }
    public string is_palindrome(int n)
    {
        // Convert the number to a string
        string str = n.ToString();

        // Get the reversed string
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        string reversedStr = new string(charArray);

        // Compare the original string with the reversed string
        if (str == reversedStr)
        {
            return "Yes";
        }
        else
        {
            return "No";
        }
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        Array.Sort(candidates);
        IList<IList<int>> result = new List<IList<int>>();

        Helper(candidates, 0, 0, new List<int>(), result, target);
        return result;
    }


    private void Helper(int[] candidates, int index, int sum, IList<int> nums, IList<IList<int>> result, int target)
    {
        if (index < candidates.Length)
        {
            int temp = candidates[index] + sum;
            if (temp > target)
            {
                // sum greater than target
                // break the loop as we all the remaining candidates will also be higher
            }
            else if (temp == target)
            {
                // Combination found
                // Add to result
                nums.Add(candidates[index]);
                result.Add(nums.ToList());
                nums.RemoveAt(nums.Count - 1);
                // break the loop as all numbers after this will be higher
            }
            else
            {
                // split the flow
                // Flow 1: add the current number 
                nums.Add(candidates[index]);
                Helper(candidates, index, temp, nums, result, target);
                nums.RemoveAt(nums.Count - 1);

                // Flow 2: Do not add the current number, skip to next number
                Helper(candidates, index + 1, sum, nums, result, target);
            }
        }
    }

    public bool CheckInclusion(string s1, string s2)
    {
        bool returnValue = false;

        if (s1.Length <= s2.Length)
        {
            var d1 = _MapStringToDictionary(s1);
            var d2 = _MapStringToDictionary(s2.Substring(0, s1.Length));

            returnValue = _Compare(d1, d2);

            int prev = 0;
            for (int i = s1.Length; i < s2.Length; i++)
            {
                if (!returnValue)
                {
                    // remove prev char
                    if (d2[s2[prev]] == 1)
                    {
                        d2.Remove(s2[prev]);
                    }
                    else
                    {
                        d2[s2[prev]]--;
                    }

                    // add next char
                    d2.TryAdd(s2[i], 0);
                    d2[s2[i]]++;

                    returnValue = _Compare(d1, d2);
                }
                else
                {
                    break;
                }

                prev++;
            }
        }

        return returnValue;
    }

    private bool _Compare(IDictionary<char, int> d1, IDictionary<char, int> d2)
    {
        bool returnValue = true;
        foreach (var item in d1)
        {
            returnValue &= d2.ContainsKey(item.Key) && d2[item.Key] == item.Value;
            if (!returnValue)
            {
                break;
            }
        }

        return returnValue;
    }

    private IDictionary<char, int> _MapStringToDictionary(string str)
    {
        IDictionary<char, int> dictionary = new Dictionary<char, int>();
        foreach (var c in str)
        {
            dictionary.TryAdd(c, 0);
            dictionary[c]++;
        }

        return dictionary;
    }
    static List<string> GetPermutations(string input)
    {
        var results = new List<string>();
        if (input.Length == 1)
        {
            results.Add(input);
            return results;
        }

        for (int i = 0; i < input.Length; i++)
        { 
            char currentChar = input[i];

            var a = input.Substring(0, i);
            var b = input.Substring(i + 1);


            string remainingChars = input.Substring(0, i) + input.Substring(i + 1);
            foreach (var permutation in GetPermutations(remainingChars))
            {
                results.Add(currentChar + permutation);
            }
        }

        return results;
    }

    int ans = 1;
    public int fun(int n)
    {
        if (n == 1)
            return n;

        fun(n - 1);
        return ans = ans * n;
    }

    static string Skip(string up)
    {
        if (string.IsNullOrEmpty(up))
        {
            return "";
        }

        char ch = up[0];

        if (ch == 'a')
        {
            return Skip(up.Substring(1));
        }
        else
        {
            return ch + Skip(up.Substring(1));
        }
    }
    public static void Main(string[] args)
    {
        Solution solution = new Solution();

        //int[] candidates = { 10, 1, 2, 7, 6, 5 };
        //int target = 8;
        //var res = solution.CombinationSum(candidates, target);

        //string input = "abc";
        //var permutations = GetPermutations(input);
        //foreach (var permutation in permutations)
        //{
        //    Console.WriteLine(permutation);
        //}

        ////Console.WriteLine("Ans :");
        ////foreach (var list in res)
        ////{
        ////    Console.Write("[ ");
        ////    foreach (var num in list)
        ////    {
        ////        Console.Write(num + " ");
        ////    }
        ////    Console.WriteLine("]");
        ////}
        string input = "aabbcca";
        string result = Skip(input);
        Console.WriteLine(result);
        //Console.WriteLine( solution.fun(5));

    }
}