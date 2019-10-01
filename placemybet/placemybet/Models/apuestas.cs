using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class apuestas
    {
        
            public apuestas(int iD, string tipo, decimal cuota, decimal apostado)
            {
                ID = iD;
                this.tipo = tipo;
                this.cuota = cuota;
                this.apostado = apostado;
            }

            public int ID { get; set; }
            public string tipo { get; set; }
            public decimal cuota { get; set; }
            public decimal apostado { get; set; }

        
    }
}