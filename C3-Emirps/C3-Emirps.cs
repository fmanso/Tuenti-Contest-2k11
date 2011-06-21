using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C3_Emirps
{
    class Emirps
    {
        static void Main(string[] args)
        {
            var stream = Console.In;
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                var upTo = Int32.Parse(line);                
                var sum = SumEmirps(upTo);
                Console.WriteLine(sum);
                // Check EOF
                if (stream.Peek() == -1) break;
            }
        }

        static int SumEmirps(int upTo)
        {
            int sum = 0;
            for (var i = 0; i <= upTo; i++)
            {
                if (isPrime(i) && isPrime(Reverse(i)) && i != Reverse(i))
                    sum += i;
            }
            return sum;
        }


        static int Reverse(int number)
        {
            int r = 0;
            while (number != 0)
            {
                r = r*10;
                r = r + (number%10);
                number = number/10;
            }
            return r;
        }

        static bool isPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            var m = (int) Math.Sqrt(n);

            for (var i = 3; i <= m; i += 2)
                if (n % i == 0)
                    return false;
            return true;
        }
    }
}
