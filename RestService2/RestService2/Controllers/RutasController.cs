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
        private MicroSystemDBEntities1 db = new MicroSystemDBEntities1();

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
            return SingleResult.Create(db.Ruta.Where(m => m.Id == key).Select(m => m.Coordenada));
        }

        // GET: odata/Rutas(5)/Linea
        [EnableQuery]
        public IQueryable<Linea> GetLinea([FromODataUri] int key)
        {
            return db.Ruta.Where(m => m.Id == key).SelectMany(m => m.Linea);
        }

        // GET: odata/Rutas(5)/Linea1
        [EnableQuery]
        public IQueryable<Linea> GetLinea1([FromODataUri] int key)
        {
            return db.Ruta.Where(m => m.Id == key).SelectMany(m => m.Linea1);
        }

        // GET: odata/Rutas(5)/Linea2
        [EnableQuery]
        public SingleResult<Linea> GetLinea2([FromODataUri] int key)
        {
            return SingleResult.Create(db.Ruta.Where(m => m.Id == key).Select(m => m.Linea2));
        }

        // GET: odata/Rutas(5)/Paradero
        [EnableQuery]
        public IQueryable<Paradero> GetParadero([FromODataUri] int key)
        {
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
