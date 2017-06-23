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
    builder.EntitySet<HistorialDiario>("HistorialesDiarios");
    builder.EntitySet<Micro>("Micro"); 
    builder.EntitySet<HistorialIdaVuelta>("HistorialIdaVuelta"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class HistorialesDiariosController : ODataController
    {
        private MicroSystemDBEntities6 db = new MicroSystemDBEntities6();

        // POST: odata/HistorialesDiarios(5)/ObtenerHistorialesIdaVuelta
        [EnableQuery]
        public List<HistorialIdaVuelta> ObtenerHistorialesIdaVuelta([FromODataUri] int key)
        {
            HistorialDiario hDiario = db.HistorialDiario.Where(h => h.Id == key).FirstOrDefault();

            List<HistorialIdaVuelta> hiv = hDiario.HistorialIdaVuelta.OrderBy(h => h.Id).ToList();

            return hiv;
        }


        // GET: odata/HistorialesDiarios
        [EnableQuery]
        public IQueryable<HistorialDiario> GetHistorialesDiarios()
        {
            return db.HistorialDiario;
        }

        // GET: odata/HistorialesDiarios(5)
        [EnableQuery]
        public SingleResult<HistorialDiario> GetHistorialDiario([FromODataUri] int key)
        {
            return SingleResult.Create(db.HistorialDiario.Where(historialDiario => historialDiario.Id == key));
        }

        // GET: odata/HistorialesDiarios(5)/Micro
        [EnableQuery]
        public SingleResult<Micro> GetMicro([FromODataUri] int key)
        {
            return SingleResult.Create(db.HistorialDiario.Where(m => m.Id == key).Select(m => m.Micro));
        }

        // GET: odata/HistorialesDiarios(5)/HistorialIdaVuelta
        [EnableQuery]
        public IQueryable<HistorialIdaVuelta> GetHistorialIdaVuelta([FromODataUri] int key)
        {
            return db.HistorialDiario.Where(m => m.Id == key).SelectMany(m => m.HistorialIdaVuelta);
        }



        // PUT: odata/HistorialesDiarios(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<HistorialDiario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HistorialDiario historialDiario = db.HistorialDiario.Find(key);
            if (historialDiario == null)
            {
                return NotFound();
            }

            patch.Put(historialDiario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialDiarioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(historialDiario);
        }

        // POST: odata/HistorialesDiarios
        public IHttpActionResult Post(HistorialDiario historialDiario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HistorialDiario.Add(historialDiario);
            db.SaveChanges();

            return Created(historialDiario);
        }

        // PATCH: odata/HistorialesDiarios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<HistorialDiario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HistorialDiario historialDiario = db.HistorialDiario.Find(key);
            if (historialDiario == null)
            {
                return NotFound();
            }

            patch.Patch(historialDiario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialDiarioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(historialDiario);
        }

        // DELETE: odata/HistorialesDiarios(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            HistorialDiario historialDiario = db.HistorialDiario.Find(key);
            if (historialDiario == null)
            {
                return NotFound();
            }

            db.HistorialDiario.Remove(historialDiario);
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

        private bool HistorialDiarioExists(int key)
        {
            return db.HistorialDiario.Count(e => e.Id == key) > 0;
        }
    }
}
