using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class mercados
    {
        public mercados(int iD, string tipo, decimal cuotaOver, decimal cuotaUnder, decimal apostadoOver, decimal apostadoUnder)
        {
            ID = iD;
            this.tipo = tipo;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.apostadoOver = apostadoOver;
            this.apostadoUnder = apostadoUnder;
        }

        public int ID { get; set; }
        public string tipo { get; set; }
        public decimal cuotaOver { get; set; }
        public decimal cuotaUnder { get; set; }
        public decimal apostadoOver { get; set; }
        public decimal apostadoUnder { get; set; }
    }
}
