using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Camaleao
{
    public class Cypher
    {
        public Image Message {get; set;}
        public Image Camaleao { get; set; }
        public Image Share { get; set; }

        public Cypher(Image message, Image camaleao)
        {
            this.Message = message;
            this.Camaleao = camaleao;
        }   

        public Image GenerateShare()
        {
            return Share;
        }

    }
}
