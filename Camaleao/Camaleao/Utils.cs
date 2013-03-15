using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Camaleao
{
    public static class Utils
    {
        public static Bitmap TransposeImage(Bitmap image)
        {
            Bitmap imageT = new Bitmap(image.Height, image.Width);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    imageT.SetPixel(y, x, image.GetPixel(x, y));
                }
            }
            return imageT;

        }

        public static List<int> CreatePrivateKey(Random random, int maxValue,int keyLength)
        {
            List<int> r = new List<int>();
            for (int i = 0; i < keyLength; i++)
            {
                r.Add(random.Next(maxValue));
            }
            return r;
        }

    }
}
