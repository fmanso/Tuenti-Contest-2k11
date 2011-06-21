using System;

namespace C8_BiologistProblem
{
    class Program
    {
        static void Main()
        {
            var stream = Console.In;
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                string[] strings = line.Split(' ');

                Console.WriteLine(LongestCommonSubstring(strings[0], strings[1]));

                // CHECK EOF));));
                if (stream.Peek() == -1) break;
            }
        }

        private static string LongestCommonSubstring(string S1, string S2)
        {
            int Start = 0;
            int Max = 0;
            for (int i = 0; i < S1.Length; i++)
            {
                for (int j = 0; j < S2.Length; j++)
                {
                    int x = 0;
                    while (S1[i + x] == S2[j + x])
                    {
                        x++;
                        if ((i + x >= S1.Length) || (j + x >= S2.Length)) break;
                    }
                    if (x > Max)
                    {
                        Max = x;
                        Start = i;
                    }

                }
            }
            return S1.Substring(Start, Max);
        }
    }
}
