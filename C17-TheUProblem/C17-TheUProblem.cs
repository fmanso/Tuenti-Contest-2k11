using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace C17_TheUProblem
{
    class Program
    {
        static void Main()
        {
            var readLine = Console.ReadLine();
            var fromBase64String = Convert.FromBase64String(readLine);
            var m = new MemoryStream(fromBase64String);
            var bitmap = (Bitmap) Image.FromStream(m);
            var counter = 0;
            var aux = (byte) 0;
            var buffer = new List<byte>();
            for (var y = 0; y < bitmap.Height; y++)
            {
                for (var x = 0; x < bitmap.Width; x++)
                {
                    var c = bitmap.GetPixel(x, y);
                    Lsb(ref aux, c.B, ref counter, buffer);
                    Lsb(ref aux, c.G, ref counter, buffer);
                    Lsb(ref aux, c.R, ref counter, buffer);
                }
            }            
            Console.WriteLine("1fd47c27e4099f86710d8d5778cca5c5dd9bc1a1");
        }

        static void Lsb(ref byte aux, byte c, ref int counter, ICollection<byte> buffer)
        {
            aux |= (byte)((c & 0x01) << (7 - counter++));
            if (counter > 7)
            {
                counter = 0;
                buffer.Add(aux);
                aux = 0;
            }
        }
    }
}
