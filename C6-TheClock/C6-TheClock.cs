using System;

namespace C6_TheClock
{
    class Program
    {
        static void Main()
        {
            var stream = Console.In;
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                var secs = 0;
                var mins = 0;
                var hours = 0;
                var input = Int32.Parse(line);

                var leds = 0;
                for (var i = 0; i <= input; i++)
                {
                    leds += NumberOfLeds(hours) + NumberOfLeds(mins) + NumberOfLeds(secs);
                    secs++;
                    if (secs > 59)
                    {
                        secs = 0;
                        mins++;
                        if (mins > 59)
                        {
                            mins = 0;
                            hours++;
                            if (hours > 12)
                            {                                
                                hours = 0;
                            }
                        }
                    }                                    
                }
                Console.WriteLine(leds);
                // CHECK EOF));
                if (stream.Peek() == -1) break;
            }
        }

        static int NumberOfLeds(int number)
        {
            int p0 = number % 10;
            int p1 = (number / 10) % 10;

            int leds = GetSegments(p0);
            leds += GetSegments(p1);

            return leds;
        }

        static int GetSegments(int number)
        {
            var leds = 0;
            switch (number)
            {
                case 0:
                    leds += 6;
                    break;
                case 1:
                    leds += 2;
                    break;
                case 2:
                    leds += 5;
                    break;
                case 3:
                    leds += 5;
                    break;
                case 4:
                    leds += 4;
                    break;
                case 5:
                    leds += 5;
                    break;
                case 6:
                    leds += 6;
                    break;
                case 7:
                    leds += 3;
                    break;
                case 8:
                    leds += 7;
                    break;
                case 9:
                    leds += 6;
                    break;
            }
            return leds;
        }
    }
}
