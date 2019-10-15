using placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace placemybet.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<ApuestasDTO> Get()
        {
            var repo = new apuestasRepository();
            //List<apuestas> apuesta = repo.retrieve();
            List<ApuestasDTO> apuesta = repo.retrieveDTO();
            return apuesta;
        }

        // GET: api/Apuestas/5
        public apuestas Get(int id)
        {
            /*var repo = new apuestasRepository();
            apuestas d = repo.retrieve();*/
            return null;
        }

        // POST: api/Apuestas
        public void Post([FromBody]apuestas apuesta)
        {
            var repo = new apuestasRepository();
            repo.save(apuesta);
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
