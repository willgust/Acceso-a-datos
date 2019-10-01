using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class eventos
    {
        public eventos(int iD, DateTime fecha, DateTime hora, string equipoLocal, string equipoVisitante)
        {
            ID = iD;
            this.fecha = fecha;
            this.hora = hora;
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
        }

        public int ID { get; set; }
        public DateTime fecha { get; set; }
        public DateTime hora { get; set; }
        public string equipoLocal { get; set; }
        public string equipoVisitante { get; set; }
    }
}