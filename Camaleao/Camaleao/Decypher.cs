using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Camaleao
{
    public class Decypher
    {
        private Bitmap OriginalImage { get; set; }
        private Bitmap Share { get; set; }
        private Bitmap Message { get; set; }
        private int PrivateKey { get; set; }
        private Random Rand { get; set; }
        private List<int> R { get; set; }


        public Decypher(Bitmap originalImage, Bitmap share, int privateKey)
        {
            this.OriginalImage = originalImage;
            this.Share = share;
            this.Message = new Bitmap(Share.Width/2, Share.Height);

            this.PrivateKey = privateKey;
            this.Rand = new Random(PrivateKey);
            R = new List<int>();
                      
        }

        public Bitmap GetMessage()
        {
            R = Utils.CreatePrivateKey(Rand, OriginalImage.Width * OriginalImage.Height, Message.Width * Message.Height);

            TransformShareBack();

            for (int y = 0; y < Message.Height; y++)
            {
                for (int x = 0; x < Message.Width; x++)
                {
                    Color sharePixel1 = Share.GetPixel(2*x, y);
                    Color sharePixel2 = Share.GetPixel(2*x+1, y);

                    Color f1;
                    Color f2;

                    int yi = (int)R[y * Message.Width + x] / OriginalImage.Width;
                    int xi = R[y * Message.Width + x] % OriginalImage.Width;
                    Color imagePixel = OriginalImage.GetPixel(xi, yi);


                    if (imagePixel.Name.StartsWith("ff8") ||
                    imagePixel.Name.StartsWith("ff9") ||
                    imagePixel.Name.StartsWith("ffa") ||
                    imagePixel.Name.StartsWith("ffb") ||
                    imagePixel.Name.StartsWith("ffc") ||
                    imagePixel.Name.StartsWith("ffd") ||
                    imagePixel.Name.StartsWith("ffe") ||
                    imagePixel.Name.StartsWith("fff"))
                    {
                        f1 = Color.FromArgb(255,0,0,0);
                        f2 = Color.FromArgb(255,255,255);
                    }
                    else
                    {
                        f1 = Color.FromArgb(255, 255, 255);
                        f2 = Color.FromArgb(255, 0, 0, 0);
                    }

                    if ((f1.Name == sharePixel1.Name) && (f2.Name == sharePixel2.Name))
                    {
                        Message.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        Message.SetPixel(x, y, Color.Black);
                    }
                    
                }
            }
            return Message;
           // return Share;
        }

        

        private void TransformShareBack()
        {
            Share = Utils.TransposeImage(Share);
            PermuteColumnsBack();
            Share = Utils.TransposeImage(Share);
        }


        private void PermuteColumnsBack()
        {
            Random random = new Random(PrivateKey);
            List<int> r = Utils.CreatePrivateKey(random, Share.Width, 2*Share.Width);

            List<int> rInverso = new List<int>();

            for (int a = 1; a <= r.Count; a++)
            {
                rInverso.Add(r[r.Count - a]);
            }


            for (int i = 0; i < Share.Width; i++)
            {
                int column1 = rInverso[2*i];
                int column2 = rInverso[2*i+1];
                
                for (int j = 0; j < Share.Height; j++)
                {
                    Color Aux = Share.GetPixel(column1, j);
                    Share.SetPixel(column1, j, Share.GetPixel(column2, j));
                    Share.SetPixel(column2, j, Aux);
                }

            }
           
        }

    }
}
