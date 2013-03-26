using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Camaleao
{
    class NaorShamirCypher
    {
     private Bitmap Image { get; set; }
        public Bitmap Share1 { get; set; }
        public Bitmap Share2 { get; set; }
        private Random Rand { get; set; }

        public NaorShamirCypher(Bitmap image)
        {
            this.Image = image;
            this.Share1 = new Bitmap(image.Width * 2, image.Height * 2);
            this.Share2 = new Bitmap(image.Width * 2, image.Height * 2);
            Rand = new Random();
            GenerateShares();
        }
  

        private void GenerateShares()
        {
            for (int y = 0; y < Image.Height; y++)
            {
                for (int x = 0; x < Image.Width; x++)
                {
                    Color imagePixel = Image.GetPixel(x, y);
                    int randomInt = Rand.Next() % 2;

                    if(imagePixel.R == 255)// Branco
                    {
                        if (randomInt == 0)
                        {
                            Share1.SetPixel(2*x, 2*y, Color.Black);
                            Share1.SetPixel(2 * x + 1, 2 * y, Color.Transparent);
                            Share1.SetPixel(2 * x, 2 * y + 1, Color.Transparent);
                            Share1.SetPixel(2*x+1, 2*y+1, Color.Black);

                            Share2.SetPixel(2*x, 2*y, Color.Black);
                            Share2.SetPixel(2 * x + 1, 2 * y, Color.Transparent);
                            Share2.SetPixel(2 * x, 2 * y + 1, Color.Transparent);
                            Share2.SetPixel(2*x+1, 2*y+1, Color.Black);

                        }
                        else 
                        {
                            Share1.SetPixel(2 * x, 2 * y, Color.Transparent);
                            Share1.SetPixel(2*x+1, 2*y, Color.Black);
                            Share1.SetPixel(2*x, 2*y+1, Color.Black);
                            Share1.SetPixel(2 * x + 1, 2 * y + 1, Color.Transparent);

                            Share2.SetPixel(2 * x, 2 * y, Color.Transparent);
                            Share2.SetPixel(2*x+1, 2*y, Color.Black);
                            Share2.SetPixel(2*x, 2*y+1, Color.Black);
                            Share2.SetPixel(2 * x + 1, 2 * y + 1, Color.Transparent);
                        }

                    }

                    else //Preto
                    {
                        if (randomInt == 0)
                        {
                            Share1.SetPixel(2 * x, 2 * y, Color.Black);
                            Share1.SetPixel(2 * x + 1, 2 * y, Color.Transparent);
                            Share1.SetPixel(2 * x, 2 * y + 1, Color.Transparent);
                            Share1.SetPixel(2 * x + 1, 2 * y + 1, Color.Black);

                            Share2.SetPixel(2 * x, 2 * y, Color.Transparent);
                            Share2.SetPixel(2 * x + 1, 2 * y, Color.Black);
                            Share2.SetPixel(2 * x, 2 * y + 1, Color.Black);
                            Share2.SetPixel(2 * x + 1, 2 * y + 1, Color.Transparent);
                        }
                        else
                        {
                            Share1.SetPixel(2 * x, 2 * y, Color.Transparent);
                            Share1.SetPixel(2 * x + 1, 2 * y, Color.Black);
                            Share1.SetPixel(2 * x, 2 * y + 1, Color.Black);
                            Share1.SetPixel(2 * x + 1, 2 * y + 1, Color.Transparent);


                            Share2.SetPixel(2 * x, 2 * y, Color.Black);
                            Share2.SetPixel(2 * x + 1, 2 * y, Color.Transparent);
                            Share2.SetPixel(2 * x, 2 * y + 1, Color.Transparent);
                            Share2.SetPixel(2 * x + 1, 2 * y + 1, Color.Black);
                        }
                    }
                }
            }
        }
    }
}
