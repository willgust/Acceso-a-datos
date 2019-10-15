using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class eventos
    {
        public eventos(int iD, DateTime fecha, string equipoLocal, string equipoVisitante)
        {
            ID = iD;
            this.fecha = fecha;
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
        }

        public int ID { get; set; }
        public DateTime fecha { get; set; }
        public string equipoLocal { get; set; }
        public string equipoVisitante { get; set; }
    }

    public class EventosDTO
    {
        public EventosDTO( string equipoLocal, string equipoVisitante)
        {
            
            this.equipoLocal = equipoLocal;
            this.equipoVisitante = equipoVisitante;
        }

        
        public string equipoLocal { get; set; }
        public string equipoVisitante { get; set; }
    }

}