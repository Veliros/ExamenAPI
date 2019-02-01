using examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace examen.Controllers
{
    public class RecetasController : ApiController
    {
        // GET: api/Recetas
        public IEnumerable<Receta> Get()
        {
            // recuperación de todas las recetas:
            var repo = new Recetasrepository();
            List<Receta> recetas = repo.Retrieve();

            return recetas;
        }

        // GET: api/Recetas/5
        public Receta Get(int id)
        {
            // Llamada al método de recuperación por id:
            var repo = new Recetasrepository();

            return repo.RetrieveId(id);
        }

        // POST: api/Recetas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Recetas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Recetas/5
        public void Delete(int id)
        {
        }
    }
}
