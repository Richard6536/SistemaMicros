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
    builder.EntitySet<HistorialIdaVuelta>("HistorialesIdaVuelta");
    builder.EntitySet<HistorialDiario>("HistorialDiario"); 
    builder.EntitySet<HistorialParadero>("HistorialParadero"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class HistorialesIdaVueltaController : ODataController
    {
        private MicroSystemDBEntities10 db = new MicroSystemDBEntities10();

        // POST: odata/HistorialesIdaVuelta(5)/ObtenerHistorialesParaderos
        [EnableQuery]
        public List<HistorialParadero> ObtenerHistorialesParaderos([FromODataUri] int key)
        {
            HistorialIdaVuelta hiv = db.HistorialIdaVuelta.Where(h => h.Id == key).FirstOrDefault();

            List<HistorialParadero> hParaderos = hiv.HistorialParadero.OrderBy(h => h.Id).ToList();

            return hParaderos;
        }



        // GET: odata/HistorialesIdaVuelta
        [EnableQuery]
        public IQueryable<HistorialIdaVuelta> GetHistorialesIdaVuelta()
        {
            return db.HistorialIdaVuelta;
        }

        // GET: odata/HistorialesIdaVuelta(5)
        [EnableQuery]
        public SingleResult<HistorialIdaVuelta> GetHistorialIdaVuelta([FromODataUri] int key)
        {
            return SingleResult.Create(db.HistorialIdaVuelta.Where(historialIdaVuelta => historialIdaVuelta.Id == key));
        }

        // GET: odata/HistorialesIdaVuelta(5)/HistorialDiario
        [EnableQuery]
        public SingleResult<HistorialDiario> GetHistorialDiario([FromODataUri] int key)
        {
            return SingleResult.Create(db.HistorialIdaVuelta.Where(m => m.Id == key).Select(m => m.HistorialDiario));
        }

        // GET: odata/HistorialesIdaVuelta(5)/HistorialParadero
        [EnableQuery]
        public IQueryable<HistorialParadero> GetHistorialParadero([FromODataUri] int key)
        {
            return db.HistorialIdaVuelta.Where(m => m.Id == key).SelectMany(m => m.HistorialParadero);
        }



        // PUT: odata/HistorialesIdaVuelta(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<HistorialIdaVuelta> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HistorialIdaVuelta historialIdaVuelta = db.HistorialIdaVuelta.Find(key);
            if (historialIdaVuelta == null)
            {
                return NotFound();
            }

            patch.Put(historialIdaVuelta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialIdaVueltaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(historialIdaVuelta);
        }

        // POST: odata/HistorialesIdaVuelta
        public IHttpActionResult Post(HistorialIdaVuelta historialIdaVuelta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HistorialIdaVuelta.Add(historialIdaVuelta);
            db.SaveChanges();

            return Created(historialIdaVuelta);
        }

        // PATCH: odata/HistorialesIdaVuelta(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<HistorialIdaVuelta> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HistorialIdaVuelta historialIdaVuelta = db.HistorialIdaVuelta.Find(key);
            if (historialIdaVuelta == null)
            {
                return NotFound();
            }

            patch.Patch(historialIdaVuelta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialIdaVueltaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(historialIdaVuelta);
        }

        // DELETE: odata/HistorialesIdaVuelta(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            HistorialIdaVuelta historialIdaVuelta = db.HistorialIdaVuelta.Find(key);
            if (historialIdaVuelta == null)
            {
                return NotFound();
            }

            db.HistorialIdaVuelta.Remove(historialIdaVuelta);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistorialIdaVueltaExists(int key)
        {
            return db.HistorialIdaVuelta.Count(e => e.Id == key) > 0;
        }
    }
}
