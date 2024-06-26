
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
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        var res = solution.isPerfectNumber(10);

        Console.WriteLine("Ans : " + res);

    }
}