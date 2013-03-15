using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Camaleao
{
    class Program
    {
        public static Cypher cypher;
        public static Decypher decypher;

        public static NaorShamirCypher NScypher;
        public static NaorShamirDecypher NSDecypher;

        
        public static string AbsolutePath =  Path.GetDirectoryName (Assembly.GetExecutingAssembly().Location);

        static void Main(string[] args)
        {
            Bitmap originalImage = new Bitmap(Path.Combine (AbsolutePath, "../../Images/chameleon2.bmp"));
            Bitmap message = new Bitmap(Path.Combine(AbsolutePath, "../../Images/messageNarrow.bmp"));

            cypher = new Cypher(message, originalImage, 7);
            Bitmap share = cypher.GenerateShare();
            share.Save(Path.Combine(AbsolutePath, "../../Images/shareNarrowChameleon2.bmp"));


            Bitmap receivedShare = new Bitmap(Path.Combine(AbsolutePath, "../../Images/shareNarrowChameleon2.bmp"));
            decypher = new Decypher(originalImage, share, 7);
            Bitmap retrivedMessage = decypher.GetMessage();
            retrivedMessage.Save(Path.Combine(AbsolutePath, "../../Images/retrivedMessage.bmp"));

            NScypher = new NaorShamirCypher(originalImage);
            NScypher.Share1.Save(Path.Combine(AbsolutePath, "../../Images/NSshare1.bmp"));
            NScypher.Share2.Save(Path.Combine(AbsolutePath, "../../Images/NSshare2.bmp"));

            NSDecypher = new NaorShamirDecypher(NScypher.Share1, NScypher.Share2);
            NSDecypher.RetrievedImage.Save(Path.Combine(AbsolutePath, "../../Images/NSretrievedImage.bmp"));
        }
    }
}
