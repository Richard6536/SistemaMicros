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
    builder.EntitySet<Linea>("Lineas");
    builder.EntitySet<Ruta>("Ruta"); 
    builder.EntitySet<Micro>("Micro"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class LineasController : ODataController
    {
        private MicroSystemDBEntities1 db = new MicroSystemDBEntities1();

        // GET: odata/Lineas
        [EnableQuery]
        public IQueryable<Linea> GetLineas()
        {
            return db.Linea;
        }

        // GET: odata/Lineas(5)
        [EnableQuery]
        public SingleResult<Linea> GetLinea([FromODataUri] int key)
        {
            return SingleResult.Create(db.Linea.Where(linea => linea.Id == key));
        }

        // PUT: odata/Lineas(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Linea> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Linea linea = db.Linea.Find(key);
            if (linea == null)
            {
                return NotFound();
            }

            patch.Put(linea);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(linea);
        }

        // POST: odata/Lineas
        public IHttpActionResult Post(Linea linea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Linea.Add(linea);
            db.SaveChanges();

            return Created(linea);
        }

        // PATCH: odata/Lineas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Linea> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Linea linea = db.Linea.Find(key);
            if (linea == null)
            {
                return NotFound();
            }

            patch.Patch(linea);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(linea);
        }

        // DELETE: odata/Lineas(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Linea linea = db.Linea.Find(key);
            if (linea == null)
            {
                return NotFound();
            }

            db.Linea.Remove(linea);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Lineas(5)/Ruta
        [EnableQuery]
        public SingleResult<Ruta> GetRuta([FromODataUri] int key)
        {
            return SingleResult.Create(db.Linea.Where(m => m.Id == key).Select(m => m.Ruta));
        }

        // GET: odata/Lineas(5)/Ruta1
        [EnableQuery]
        public SingleResult<Ruta> GetRuta1([FromODataUri] int key)
        {
            return SingleResult.Create(db.Linea.Where(m => m.Id == key).Select(m => m.Ruta1));
        }

        // GET: odata/Lineas(5)/Micro
        [EnableQuery]
        public IQueryable<Micro> GetMicro([FromODataUri] int key)
        {
            return db.Linea.Where(m => m.Id == key).SelectMany(m => m.Micro);
        }

        // GET: odata/Lineas(5)/Ruta2
        [EnableQuery]
        public IQueryable<Ruta> GetRuta2([FromODataUri] int key)
        {
            return db.Linea.Where(m => m.Id == key).SelectMany(m => m.Ruta2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineaExists(int key)
        {
            return db.Linea.Count(e => e.Id == key) > 0;
        }
    }
}
