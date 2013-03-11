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
        private Bitmap OriginalImage { get; set; }
        private Bitmap Share { get; set; }
       
        private int PrivateKey { get; set; }
        private Random Rand { get; set; }
        private List<int> R { get; set; }

        public Cypher(Bitmap message, Bitmap originalImage, int privateKey)
        {
            this.Message = message;
            this.OriginalImage = originalImage;
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
                    
                    int yi= (int)R[y*Message.Width + x]/OriginalImage.Width;
                    int xi= R[y*Message.Width + x]%OriginalImage.Width;

                    Color imagePixel = OriginalImage.GetPixel(xi, yi);
            

                    if (msgPixel.Equals(Color.FromArgb(255,0,0,0))) //pixel da mensagem é preto
                    {
                        //valido para imagens em tons de cinza (R = G = B)
                        if(imagePixel.R >= 80) //se o bit mais a esquerda da cor do pixel selecionado = 1
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
                    else if (msgPixel.Equals(Color.FromArgb(255,255,255,255))) //pixel da mensagem é branco
                    {
                        if (imagePixel.R >= 80) //se o bit mais a esquerda da cor do pixel selecionado = 1
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
                R.Add(Rand.Next(OriginalImage.Width * OriginalImage.Height));   
            }
        }

    }
}
