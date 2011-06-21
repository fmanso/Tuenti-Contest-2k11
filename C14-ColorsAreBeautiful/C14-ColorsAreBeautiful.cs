using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace C14_ColorsAreBeautiful
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap fromFile = (Bitmap)Bitmap.FromFile("trabaja.bmp");
            var stream = Console.In;
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                var component = line[0];
                var numberOfLine = Int32.Parse(line.Remove(0, 1));
                var sum = 0d;
                for (int i = 0; i < fromFile.Width; i++)
                {
                    Color color = fromFile.GetPixel(i,numberOfLine);
                    switch (component)
                    {
                        case 'R':
                            sum += color.R;
                            break;
                        case 'G':
                            sum += color.G;
                            break;
                        case 'B':
                            sum += color.B;
                            break;
                    }
                }
                Console.WriteLine(sum+1);
                // CHECK EOF));
                if (stream.Peek() == -1) break;
            }
        }
    }
}
