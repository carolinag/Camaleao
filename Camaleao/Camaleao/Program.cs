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
        
        public static string AbsolutePath =  Path.GetDirectoryName (Assembly.GetExecutingAssembly().Location);
        static void Main(string[] args)
        {
            Bitmap camaleao = new Bitmap(Path.Combine (AbsolutePath, "../../Images/chameleon2.bmp"));
            Bitmap message = new Bitmap(Path.Combine(AbsolutePath, "../../Images/messageNarrow.bmp"));
            
            cypher = new Cypher(message, camaleao, 1);
            Bitmap share = cypher.GenerateShare();
            share.Save(Path.Combine(AbsolutePath, "../../Images/shareNarrowChameleon2.bmp"));

            decypher = new Decypher(camaleao, share, 1);
            Bitmap retrivedMessage = decypher.GetMessage();
            retrivedMessage.Save(Path.Combine(AbsolutePath, "../../Images/retrivedMessage.bmp"));

            //Image camaleao2 = (Image)camaleao.Clone();
            //camaleao2.Save(Path.Combine (AbsolutePath,"../../Images/camaleao2.bmp"));



        }
    }
}
