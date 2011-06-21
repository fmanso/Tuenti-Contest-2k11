using System;

namespace C13_TheOtherClock
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
                var pSecs = -1;
                var pMins = -1;
                var pHours = -1;
                var input = Int32.Parse(line);

                var leds = 0;
                for (var i = 0; i <= input; i++)
                {
                    leds += NumberOfLeds(pHours, hours) + NumberOfLeds(pMins, mins) + NumberOfLeds(pSecs, secs);
                    pHours = hours;
                    pMins = mins;
                    pSecs = secs;
                    secs++;
                    if (secs > 59)
                    {
                        secs = 0;
                        mins++;
                        if (mins > 59)
                        {
                            mins = 0;
                            hours++;
                            if (hours > 24)
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

        static int NumberOfLeds(int previous, int newTime)
        {
            int p0 = previous == -1 ? -1 : previous % 10;
            int p1 = previous == -1 ? -1 : (previous / 10) % 10;

            int n0 = newTime%10;
            int n1 = (newTime/10)%10;


            int leds = GetSegments(p0, n0);
            leds += GetSegments(p1, n1);
            return leds;
        }

        static int GetSegments(int number, int n1)
        {
            if (number == -1)
                return SparseBitcount(GetSegments(n1));
            if (number == n1)
                return 0;
            var t = GetSegments(number);
            t ^= 0x7F;
            return SparseBitcount(t & GetSegments(n1));
        }

        static byte GetSegments(int number)
        {
            switch (number)
            {
                case 0:
                    return 0x7E;
                case 1:
                    return 0x30;
                case 2:
                    return 0x6D;
                case 3:
                    return 0x79;
                case 4:
                    return 0x33;
                case 5:
                    return 0x5B;
                case 6:
                    return 0x5F;
                case 7:
                    return 0x70;
                case 8:
                    return 0x7F;
                case 9:
                    return 0x7B;
            }
            return 0x00;
        }

        static int SparseBitcount(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count++;
                n &= (n - 1);
            }
            return count;
        }
    }
}
