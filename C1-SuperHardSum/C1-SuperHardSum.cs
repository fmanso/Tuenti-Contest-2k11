using System;

namespace C1_SuperHardSum
{
    class TestToken
    {
        static void Main()
        {
            var stream = Console.In;
            string line;

            while ((line = stream.ReadLine()) != null)
            {                
                var strInts = line.Split(' ');
                var sum = 0;
                foreach (var i in strInts)
                {
                    int aux;
                    if (Int32.TryParse(i, out aux))
                    {
                        sum += aux;
                    }
                }
                Console.WriteLine(sum);
                // Check EOF
                if (stream.Peek() == -1) break;
            }
        }
    }
}
