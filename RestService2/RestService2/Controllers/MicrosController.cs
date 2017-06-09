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
using RestService2.Classes;

namespace RestService2.Controllers
{
    /*
    Puede que la clase WebApiConfig requiera cambios adicionales para agregar una ruta para este controlador. Combine estas instrucciones en el método Register de la clase WebApiConfig según corresponda. Tenga en cuenta que las direcciones URL de OData distinguen mayúsculas de minúsculas.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using RestService2.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Micro>("Micros");
    builder.EntitySet<HistorialDiario>("HistorialDiario"); 
    builder.EntitySet<Linea>("Linea"); 
    builder.EntitySet<MicroChofer>("MicroChofer"); 
    builder.EntitySet<MicroParadero>("MicroParadero"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class MicrosController : ODataController
    {
        private MicroSystemDBEntities6 db = new MicroSystemDBEntities6();

        //Obtener posicion
        //Seleccionar paradero
        //Deseleccionar paradero
        //NuevaCalificacion

        // POST: odata/Micros(5)/ObtenerPosicion
        [HttpPost]
        public Posicion ObtenerPosicion([FromODataUri] int key)
        {
            Micro micro = db.Micro.Where(m => m.Id == key).FirstOrDefault();

            Posicion pos = null;

            if (micro.MicroChoferId != null)
            {
                Usuario chofer = micro.MicroChofer.Usuario;
                pos = new Posicion(chofer.Latitud, chofer.Longitud);
            }

            return pos;
        }

        //POST: odata/Micros(5)/SeleccionarParadero
        //Parametros: IdParadero
        [HttpPost]
        public IHttpActionResult SeleccionarParadero([FromODataUri] int key, ODataActionParameters parameters)
        {
            Micro micro = db.Micro.Where(m => m.Id == key).FirstOrDefault();
            int idParadero = (int)parameters["IdParadero"];
            Paradero paradero = db.Paradero.Where(p => p.Id == idParadero).FirstOrDefault();
            Coordenada coor = db.Coordenada.Where(c => c.Latitud == paradero.Latitud && c.Longitud == paradero.Longitud).FirstOrDefault();
            if (micro.MicroParaderoId != null)
            {
                MicroParadero mp = micro.MicroParadero;
                db.MicroParadero.Remove(mp);
            }

            MicroParadero mpNuevo = new MicroParadero();
            mpNuevo.Micro1 = micro;
            mpNuevo.Paradero = paradero;

            micro.MicroParadero = mpNuevo;
            micro.Coordenada = coor;

            db.MicroParadero.Add(mpNuevo);
            db.SaveChanges();
            return Ok();
        }

        //POST: odata/Micros(5)/DeseleccionarParadero
        //Parametros: nope
        [HttpPost]
        public IHttpActionResult DeseleccionarParadero([FromODataUri] int key)
        {
            Micro micro = db.Micro.Where(m => m.Id == key).FirstOrDefault();

            if (micro.MicroParaderoId != null)
            {
                MicroParadero mp = micro.MicroParadero;
                db.MicroParadero.Remove(mp);
                db.SaveChanges();
            }
            return Ok();
        }


        //POST: odata/Micros(5)/NuevaCalificacion
        //Parametros: Calificacion
        [HttpPost]
        public float NuevaCalificacion([FromODataUri] int key, ODataActionParameters parameters)
        {
            Micro micro = db.Micro.Where(m => m.Id == key).FirstOrDefault();
            float cal = (float)parameters["Calificacion"];

            float calificacionActual = micro.Calificacion;
            int numCalActual = micro.NumeroCalificaciones;

            if(numCalActual == 0)
            {
                micro.Calificacion = cal;
            }
            else
            {
                micro.Calificacion = (calificacionActual + cal) / (numCalActual + 1);
            }

            micro.NumeroCalificaciones++;
            db.SaveChanges();

            return micro.Calificacion;
        }




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

        // GET: odata/Micros(5)/HistorialDiario
        [EnableQuery]
        public IQueryable<HistorialDiario> GetHistorialDiario([FromODataUri] int key)
        {
            return db.Micro.Where(m => m.Id == key).SelectMany(m => m.HistorialDiario);
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
