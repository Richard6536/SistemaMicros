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
    builder.EntitySet<Coordenada>("Coordenadas");
    builder.EntitySet<Ruta>("Ruta"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CoordenadasController : ODataController
    {
        private MicroSystemDBEntities1 db = new MicroSystemDBEntities1();

        // GET: odata/Coordenadas
        [EnableQuery]
        public IQueryable<Coordenada> GetCoordenadas()
        {
            return db.Coordenada;
        }

        // GET: odata/Coordenadas(5)
        [EnableQuery]
        public SingleResult<Coordenada> GetCoordenada([FromODataUri] int key)
        {
            return SingleResult.Create(db.Coordenada.Where(coordenada => coordenada.Id == key));
        }

        // PUT: odata/Coordenadas(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Coordenada> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Coordenada coordenada = db.Coordenada.Find(key);
            if (coordenada == null)
            {
                return NotFound();
            }

            patch.Put(coordenada);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordenadaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(coordenada);
        }

        // POST: odata/Coordenadas
        public IHttpActionResult Post(Coordenada coordenada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coordenada.Add(coordenada);
            db.SaveChanges();

            return Created(coordenada);
        }

        // PATCH: odata/Coordenadas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Coordenada> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Coordenada coordenada = db.Coordenada.Find(key);
            if (coordenada == null)
            {
                return NotFound();
            }

            patch.Patch(coordenada);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordenadaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(coordenada);
        }

        // DELETE: odata/Coordenadas(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Coordenada coordenada = db.Coordenada.Find(key);
            if (coordenada == null)
            {
                return NotFound();
            }

            db.Coordenada.Remove(coordenada);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Coordenadas(5)/Coordenada1
        [EnableQuery]
        public IQueryable<Coordenada> GetCoordenada1([FromODataUri] int key)
        {
            return db.Coordenada.Where(m => m.Id == key).SelectMany(m => m.Coordenada1);
        }

        // GET: odata/Coordenadas(5)/Coordenada2
        [EnableQuery]
        public SingleResult<Coordenada> GetCoordenada2([FromODataUri] int key)
        {
            return SingleResult.Create(db.Coordenada.Where(m => m.Id == key).Select(m => m.Coordenada2));
        }

        // GET: odata/Coordenadas(5)/Ruta
        [EnableQuery]
        public IQueryable<Ruta> GetRuta([FromODataUri] int key)
        {
            return db.Coordenada.Where(m => m.Id == key).SelectMany(m => m.Ruta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoordenadaExists(int key)
        {
            return db.Coordenada.Count(e => e.Id == key) > 0;
        }
    }
}
