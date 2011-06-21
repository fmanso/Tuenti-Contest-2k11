using System;
using System.Collections.Generic;
using System.Linq;

namespace C5_Milkman
{
    class Program
    {       
        struct Cow
        {
            public int Weight;
            public int MilkProd;
            public float MilkProdPerKg;
        }

        static void Main()
        {
            var stream = Console.In;
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                int weightLimit;
                var cows = GetCows(line, out weightLimit);
                var milkProduction = 0;
                var accWeight = 0;
                foreach (var cow in cows.OrderBy(x => x.MilkProdPerKg).Reverse())
                {            
                    // If cow fits on truck...
                    if (cow.Weight + accWeight < weightLimit)
                    {
                        milkProduction += cow.MilkProd;
                        accWeight += cow.Weight;
                    }                    
                }
                Console.WriteLine(milkProduction);
                // CHECK EOF
                if (stream.Peek() == -1) break;
            }
        }

        private static IEnumerable<Cow> GetCows(string line, out int weightLimit)
        {
            string[] args = line.Split(' ');
            int numberOfCows = Int32.Parse(args[0]);
            weightLimit = Int32.Parse(args[1]);
            string[] weightStrs = args[2].Split(',');
            string[] milkProdStr = args[3].Split(',');
            Cow[] cows = new Cow[numberOfCows];
            for (int i = 0; i < numberOfCows; i++)
            {                    
                cows[i].Weight = Int32.Parse(weightStrs[i]);
                cows[i].MilkProd = Int32.Parse(milkProdStr[i]);
                cows[i].MilkProdPerKg = cows[i].MilkProd/(float)cows[i].Weight;
            }
            return cows;
        }
    }
}
