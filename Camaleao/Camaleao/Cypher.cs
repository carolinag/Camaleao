using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Camaleao
{
    public class Cypher
    {
        private Bitmap Message {get; set;}
        private Bitmap Camaleao { get; set; }
        private Bitmap Share { get; set; }
       
        private int PrivateKey { get; set; }
        private Random Rand { get; set; }
        private List<int> R { get; set; }

        public Cypher(Bitmap message, Bitmap camaleao, int privateKey)
        {
            this.Message = message; 
            this.Camaleao = camaleao;
            this.Share = new Bitmap(Message.Width * 2, Message.Height);

            this.PrivateKey = privateKey;
            this.Rand = new Random(PrivateKey);
            R = new List<int>();
        }   

        public Bitmap GenerateShare()
        {
            CreatePrivateKey();

            for (int y = 0; y < Message.Height; y++)
            {
                for (int x = 0; x < Message.Width; x++)
                {
                    Color msgPixel = Message.GetPixel(x, y);
                    
                    int xi= (int)R[y*Message.Width + x]/Camaleao.Width;
                    int yi= R[y*Message.Width + x]%Camaleao.Height;
                    Color imagePixel = Camaleao.GetPixel(xi, yi);
            

                    if (msgPixel.Equals(Color.FromArgb(255,0,0,0)))
                    {
                        if (imagePixel.Name.StartsWith("ff8") || 
                            imagePixel.Name.StartsWith("ff9") || 
                            imagePixel.Name.StartsWith("ffa") ||
                            imagePixel.Name.StartsWith("ffb") ||
                            imagePixel.Name.StartsWith("ffc") ||
                            imagePixel.Name.StartsWith("ffd") ||
                            imagePixel.Name.StartsWith("ffe") ||
                            imagePixel.Name.StartsWith("fff") )

                        {
                            Share.SetPixel(2 * x, y, Color.White);
                            Share.SetPixel(2 * x + 1, y, Color.Black);
                        }
                        else 
                        {
                            Share.SetPixel(2 * x, y, Color.Black);
                            Share.SetPixel(2 * x + 1, y, Color.White);
                        }
                    }
                    else if (msgPixel.Equals(Color.FromArgb(255,255,255,255)))
                    {
                        if (imagePixel.Name.StartsWith("ff8") ||
                           imagePixel.Name.StartsWith("ff9") ||
                           imagePixel.Name.StartsWith("ffa") ||
                           imagePixel.Name.StartsWith("ffb") ||
                           imagePixel.Name.StartsWith("ffc") ||
                           imagePixel.Name.StartsWith("ffd") ||
                           imagePixel.Name.StartsWith("ffe") ||
                           imagePixel.Name.StartsWith("fff"))
                        {
                            Share.SetPixel(2 * x, y, Color.Black);
                            Share.SetPixel(2 * x + 1, y, Color.White);
                        }
                        else
                        {
                            Share.SetPixel(2 * x, y, Color.White);
                            Share.SetPixel(2 * x + 1, y, Color.Black);
                        }
                    }

                }
            }
            return Share;
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
