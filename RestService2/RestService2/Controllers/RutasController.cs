using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using RestService2.Models;

namespace RestService2.Controllers
{
    /*
    Puede que la clase WebApiConfig requiera cambios adicionales para agregar una ruta para este controlador. Combine estas instrucciones en el método Register de la clase WebApiConfig según corresponda. Tenga en cuenta que las direcciones URL de OData distinguen mayúsculas de minúsculas.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using RestService2.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Ruta>("Rutas");
    builder.EntitySet<Coordenada>("Coordenada"); 
    builder.EntitySet<Linea>("Linea"); 
    builder.EntitySet<Paradero>("Paradero"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class RutasController : ODataController
    {
        private MicroSystemDBEntities4 db = new MicroSystemDBEntities4();

        //entregar lista de coordenadas completa

        // POST: odata/Rutas(5)/ListaCoordenadas
        [HttpPost]
        public List<Coordenada> ListaCoordenadas([FromODataUri] int key)
        {
            Coordenada inicio = db.Ruta.Where(r => r.Id == key).FirstOrDefault().Coordenada;

            List<Coordenada> vertices = new List<Coordenada>();
            vertices.Add(inicio);

            Coordenada siguiente = inicio.Coordenada2;
            while(siguiente != null)
            {
                vertices.Add(siguiente);
                siguiente = siguiente.Coordenada2;
            }

            return vertices;
        }



        // GET: odata/Rutas
        [EnableQuery]
        public IQueryable<Ruta> GetRutas()
        {
            return db.Ruta;
        }

        // GET: odata/Rutas(5)
        [EnableQuery]
        public SingleResult<Ruta> GetRuta([FromODataUri] int key)
        {
            return SingleResult.Create(db.Ruta.Where(ruta => ruta.Id == key));
        }

        // PUT: odata/Rutas(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Ruta> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ruta ruta = db.Ruta.Find(key);
            if (ruta == null)
            {
                return NotFound();
            }

            patch.Put(ruta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(ruta);
        }

        // POST: odata/Rutas
        public IHttpActionResult Post(Ruta ruta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ruta.Add(ruta);
            db.SaveChanges();

            return Created(ruta);
        }

        // PATCH: odata/Rutas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Ruta> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ruta ruta = db.Ruta.Find(key);
            if (ruta == null)
            {
                return NotFound();
            }

            patch.Patch(ruta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(ruta);
        }

        // DELETE: odata/Rutas(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Ruta ruta = db.Ruta.Find(key);
            if (ruta == null)
            {
                return NotFound();
            }

            db.Ruta.Remove(ruta);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Rutas(5)/Coordenada
        [EnableQuery]
        public SingleResult<Coordenada> GetCoordenada([FromODataUri] int key)
        {
            //Coordenada de inicio
            return SingleResult.Create(db.Ruta.Where(m => m.Id == key).Select(m => m.Coordenada));
        }

        // GET: odata/Rutas(5)/Linea
        [EnableQuery]
        public SingleResult<Linea> GetLinea([FromODataUri] int key)
        {
            //Linea a la que pertenece
            return SingleResult.Create(db.Ruta.Where(m => m.Id == key).Select(m => m.Linea2));
        }

        // GET: odata/Rutas(5)/Paradero
        [EnableQuery]
        public IQueryable<Paradero> GetParadero([FromODataUri] int key)
        {
            //Todos los paraderos
            return db.Ruta.Where(m => m.Id == key).SelectMany(m => m.Paradero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RutaExists(int key)
        {
            return db.Ruta.Count(e => e.Id == key) > 0;
        }
    }
}
