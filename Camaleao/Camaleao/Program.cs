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
        public static string AbsolutePath =  Path.GetDirectoryName (Assembly.GetExecutingAssembly().Location);
        static void Main(string[] args)
        {
            Image camaleao = Image.FromFile(Path.Combine (AbsolutePath, "../../Images/camaleao.bmp"));
            //Image camaleao2 = (Image)camaleao.Clone();
            //camaleao2.Save(Path.Combine (AbsolutePath,"../../Images/camaleao2.bmp"));



        }
    }
}
