using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class mercados
    {
        public mercados(int iD, decimal tipo, decimal cuotaOver, decimal cuotaUnder, decimal apostadoOver, decimal apostadoUnder, int iD_eventos)
        {
            ID = iD;
            this.tipo = tipo;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.apostadoOver = apostadoOver;
            this.apostadoUnder = apostadoUnder;
            ID_eventos = iD_eventos;
        }

        public int ID { get; set; }
        public decimal tipo { get; set; }
        public decimal cuotaOver { get; set; }
        public decimal cuotaUnder { get; set; }
        public decimal apostadoOver { get; set; }
        public decimal apostadoUnder { get; set; }
        public int ID_eventos { get; set; }

    }

    public class MercadosDTO
    {
        public MercadosDTO(decimal tipo, decimal cuotaOver, decimal cuotaUnder)
        {
            
            this.tipo = tipo;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            
        }

        
        public decimal tipo { get; set; }
        public decimal cuotaOver { get; set; }
        public decimal cuotaUnder { get; set; }
       
    }
}
