using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace C18_TheRiddle
{
    class Program
    {
        static void Main()
        {
            //var readLine = Console.ReadLine();
            //var fromBase64String = Convert.FromBase64String(readLine);
            //var m = new MemoryStream(fromBase64String);
            var bitmap = (Bitmap) Image.FromFile("output0.png");
            StringBuilder stringBuilder = new StringBuilder();
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    var c = bitmap.GetPixel(x, y);
                    if (c.R == 255 || c.G == 255) continue;
                    stringBuilder.Append((char)c.R);
                    stringBuilder.Append((char)c.G);
                    stringBuilder.Append((char)c.B);
                }
            }
            Console.WriteLine(stringBuilder);

        }      
    }
}
