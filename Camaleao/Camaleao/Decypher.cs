using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Camaleao
{
    public class Decypher
    {
        private Bitmap Camaleao { get; set; }
        private Bitmap Share { get; set; }
        private Bitmap Message { get; set; }
        private int PrivateKey { get; set; }
        private Random Rand { get; set; }
        private List<int> R { get; set; }


        public Decypher(Bitmap camaleao, Bitmap share, int privateKey)
        {
            this.Camaleao = camaleao;
            this.Share = share;
            this.Message = new Bitmap(Share.Width/2, Share.Height);

            this.PrivateKey = privateKey;
            this.Rand = new Random(PrivateKey);
            this.Rand = new Random(PrivateKey);
            R = new List<int>();
                      
        }

        public Bitmap GetMessage()
        {
            CreatePrivateKey();

            for (int y = 0; y < Message.Height; y++)
            {
                for (int x = 0; x < Message.Width; x++)
                {
                    Color sharePixel1 = Share.GetPixel(2*x, y);
                    Color sharePixel2 = Share.GetPixel(2*x+1, y);

                    Color f1;
                    Color f2;

                    int xi = (int)R[y * Message.Width + x] / Camaleao.Width;
                    int yi = R[y * Message.Width + x] % Camaleao.Height;
                    Color imagePixel = Camaleao.GetPixel(xi, yi);


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
        }

        private void CreatePrivateKey()
        {
            for (int i = 0; i < Message.Width * Message.Height; i++)
            {
                R.Add(Rand.Next(Camaleao.Width * Camaleao.Height));
            }
        }

    }
}
