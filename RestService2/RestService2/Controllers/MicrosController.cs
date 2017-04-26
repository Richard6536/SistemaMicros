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
    builder.EntitySet<Micro>("Micros");
    builder.EntitySet<Linea>("Linea"); 
    builder.EntitySet<MicroChofer>("MicroChofer"); 
    builder.EntitySet<MicroParadero>("MicroParadero"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class MicrosController : ODataController
    {
        private MicroSystemDBEntities1 db = new MicroSystemDBEntities1();

        // GET: odata/Micros
        [EnableQuery]
        public IQueryable<Micro> GetMicros()
        {
            return db.Micro;
        }

        // GET: odata/Micros(5)
        [EnableQuery]
        public SingleResult<Micro> GetMicro([FromODataUri] int key)
        {
            return SingleResult.Create(db.Micro.Where(micro => micro.Id == key));
        }

        // PUT: odata/Micros(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Micro> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Micro micro = db.Micro.Find(key);
            if (micro == null)
            {
                return NotFound();
            }

            patch.Put(micro);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MicroExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(micro);
        }

        // POST: odata/Micros
        public IHttpActionResult Post(Micro micro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Micro.Add(micro);
            db.SaveChanges();

            return Created(micro);
        }

        // PATCH: odata/Micros(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Micro> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Micro micro = db.Micro.Find(key);
            if (micro == null)
            {
                return NotFound();
            }

            patch.Patch(micro);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MicroExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(micro);
        }

        // DELETE: odata/Micros(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Micro micro = db.Micro.Find(key);
            if (micro == null)
            {
                return NotFound();
            }

            db.Micro.Remove(micro);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Micros(5)/Linea
        [EnableQuery]
        public SingleResult<Linea> GetLinea([FromODataUri] int key)
        {
            return SingleResult.Create(db.Micro.Where(m => m.Id == key).Select(m => m.Linea));
        }

        // GET: odata/Micros(5)/MicroChofer
        [EnableQuery]
        public SingleResult<MicroChofer> GetMicroChofer([FromODataUri] int key)
        {
            return SingleResult.Create(db.Micro.Where(m => m.Id == key).Select(m => m.MicroChofer));
        }

        // GET: odata/Micros(5)/MicroParadero
        [EnableQuery]
        public SingleResult<MicroParadero> GetMicroParadero([FromODataUri] int key)
        {
            return SingleResult.Create(db.Micro.Where(m => m.Id == key).Select(m => m.MicroParadero));
        }

        // GET: odata/Micros(5)/MicroChofer1
        [EnableQuery]
        public IQueryable<MicroChofer> GetMicroChofer1([FromODataUri] int key)
        {
            return db.Micro.Where(m => m.Id == key).SelectMany(m => m.MicroChofer1);
        }

        // GET: odata/Micros(5)/MicroParadero1
        [EnableQuery]
        public IQueryable<MicroParadero> GetMicroParadero1([FromODataUri] int key)
        {
            return db.Micro.Where(m => m.Id == key).SelectMany(m => m.MicroParadero1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MicroExists(int key)
        {
            return db.Micro.Count(e => e.Id == key) > 0;
        }
    }
}
