using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Camaleao
{
    public class Decypher
    {
        public Image Camaleao { get; set; }
        public Image Share { get; set; }
        public Image Message { get; set; }

        public Decypher(Image camaleao, Image share)
        {
            this.Camaleao = camaleao;
            this.Share = share;
                      
        }

        public Image GetMessage()
        {
            return Message;
        }

    }
}
