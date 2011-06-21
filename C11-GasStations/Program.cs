using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C11_GasStations
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCases = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                var distanceWithFullTank = Int32.Parse(Console.ReadLine());
                var distanceToTravel = Int32.Parse(Console.ReadLine());
                var nOfGasStations = Int32.Parse(Console.ReadLine());
                var gasStations = new Int32[nOfGasStations];
                var stationStr = Console.ReadLine().Split(' ');
                for (int z = 0; z < nOfGasStations; z++)
                {
                    gasStations[z] = Int32.Parse(stationStr[z]);
                }

                int accumulatedDistance = 0;
                if (gasStations.OrderBy(x => x).Last() < distanceWithFullTank)
                    Console.WriteLine("No stops");
                else
                {
                    bool first = false;
                    while (accumulatedDistance + distanceWithFullTank < distanceToTravel)
                    {
                        foreach (var gasStation in gasStations.OrderBy(x => x).Reverse())
                        {
                            if (gasStation - accumulatedDistance <= distanceWithFullTank)
                            {
                                Console.Write(first ? " " + gasStation : gasStation+"");
                                first = true;
                                accumulatedDistance += gasStation - accumulatedDistance;
                                break;
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
