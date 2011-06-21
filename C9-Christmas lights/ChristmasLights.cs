using System;

namespace C9_Christmas_lights
{
    class ChristmasLights
    {
        static void Main()
        {
            var testCases = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                var numberOfLights = Int32.Parse(Console.ReadLine());
                var time = Int32.Parse(Console.ReadLine());
                if (numberOfLights == 0 || (numberOfLights == 1 && time % 2 == 0))
                {
                    Console.WriteLine("All lights are off :(");
                }
                else
                {
                    bool first = false;
                    for (int z = 0; z < numberOfLights - 1; z++)
                    {
                        if (time % 2 != z % 2)
                        {
                            if (!first)
                            {
                                first = true;
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                            Console.Write(z);
                        }
                    }                    
                    Console.WriteLine();
                }
            }
        }
    }
}
