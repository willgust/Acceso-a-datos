using placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace placemybet.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<MercadosDTO> Get()
        {
            var repo = new mercadosRepository();
            //List<mercados> mercado = repo.retrieve();
            List<MercadosDTO> mercado = repo.retrieveDTO();
            return mercado;
        }

        // GET: api/Mercados/5
        public mercados Get(int id)
        {
            /*var repo = new mercadosRepository();
            mercados d = repo.retrieve();*/
            return null;
        }

        // POST: api/Mercados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
