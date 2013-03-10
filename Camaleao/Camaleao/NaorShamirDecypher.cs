using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Camaleao
{
    public class NaorShamirDecypher
    {
        public Bitmap RetrievedImage {get; set;}
        private Bitmap Share1 {get; set;}
        private Bitmap Share2 {get; set;}

        public NaorShamirDecypher(Bitmap share1, Bitmap share2)
        {
            this.Share1 = share1;
            this.Share2 = share2;
            this.RetrievedImage = new Bitmap(Share1.Width, Share1.Height);
            RetrieveImage();
        }

        private void RetrieveImage()
        {
             for (int y = 0; y <  RetrievedImage.Height; y++)
            {
                for (int x = 0; x < RetrievedImage.Width; x++)
                {
                    Color pixel1 = Share1.GetPixel(x,y);
                    Color pixel2 = Share2.GetPixel(x,y);
                    int R = (pixel1.R + pixel2.R) > 255 ? 255 : (pixel1.R + pixel2.R);
                    int G = (pixel1.G + pixel2.G) > 255 ? 255 : (pixel1.G + pixel2.G);
                    int B = (pixel1.B + pixel2.B) > 255 ? 255 : (pixel1.B + pixel2.G);

                    RetrievedImage.SetPixel(x, y, Color.FromArgb(255, R, G, B));
                }
            }
        }
    }      
}
