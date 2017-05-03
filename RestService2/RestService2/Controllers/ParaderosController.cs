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
    builder.EntitySet<Paradero>("Paraderos");
    builder.EntitySet<MicroParadero>("MicroParadero"); 
    builder.EntitySet<Ruta>("Ruta"); 
    builder.EntitySet<UsuarioParadero>("UsuarioParadero"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ParaderosController : ODataController
    {
        private MicroSystemDBEntities2 db = new MicroSystemDBEntities2();


        //Entregar usuarios que seleccionaron tal paradero
        //Obtener micros dirigiendose a tal paradero


        // POST: odata/Paraderos(5)/UsuariosQueSeleccionaron
        [HttpPost]
        public List<Usuario> UsuariosQueSeleccionaron([FromODataUri] int key)
        {
            List<Usuario> usuarios = new List<Usuario>();
            Paradero paradero = db.Paradero.Where(p => p.Id == key).FirstOrDefault();

            List<UsuarioParadero> usuarioParaderos = paradero.UsuarioParadero.ToList();

            foreach(UsuarioParadero up in usuarioParaderos)
            {
                usuarios.Add(up.Usuario1);
            }

            return usuarios;
        }

        // POST: odata/Paraderos(5)/MicrosQueSeleecionaron
        [HttpPost]
        public List<Micro> MicrosQueSeleecionaron([FromODataUri] int key)
        {
            List<Micro> micros = new List<Micro>();
            Paradero paradero = db.Paradero.Where(p => p.Id == key).FirstOrDefault();

            List<MicroParadero> microParaderos = paradero.MicroParadero.ToList();

            foreach (MicroParadero mp in microParaderos)
            {
                micros.Add(mp.Micro1);
            }

            return micros;
        }


        // GET: odata/Paraderos
        [EnableQuery]
        public IQueryable<Paradero> GetParaderos()
        {
            return db.Paradero;
        }

        // GET: odata/Paraderos(5)
        [EnableQuery]
        public SingleResult<Paradero> GetParadero([FromODataUri] int key)
        {
            return SingleResult.Create(db.Paradero.Where(paradero => paradero.Id == key));
        }

        // PUT: odata/Paraderos(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Paradero> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Paradero paradero = db.Paradero.Find(key);
            if (paradero == null)
            {
                return NotFound();
            }

            patch.Put(paradero);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParaderoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(paradero);
        }

        // POST: odata/Paraderos
        public IHttpActionResult Post(Paradero paradero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Paradero.Add(paradero);
            db.SaveChanges();

            return Created(paradero);
        }

        // PATCH: odata/Paraderos(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Paradero> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Paradero paradero = db.Paradero.Find(key);
            if (paradero == null)
            {
                return NotFound();
            }

            patch.Patch(paradero);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParaderoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(paradero);
        }

        // DELETE: odata/Paraderos(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Paradero paradero = db.Paradero.Find(key);
            if (paradero == null)
            {
                return NotFound();
            }

            db.Paradero.Remove(paradero);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Paraderos(5)/MicroParadero
        [EnableQuery]
        public IQueryable<MicroParadero> GetMicroParadero([FromODataUri] int key)
        {
            //Todos los microParaderos asociados
            return db.Paradero.Where(m => m.Id == key).SelectMany(m => m.MicroParadero);
        }

        // GET: odata/Paraderos(5)/Ruta
        [EnableQuery]
        public SingleResult<Ruta> GetRuta([FromODataUri] int key)
        {
            //Todos los usuarios paraderos asociados
            return SingleResult.Create(db.Paradero.Where(m => m.Id == key).Select(m => m.Ruta));
        }

        // GET: odata/Paraderos(5)/UsuarioParadero
        [EnableQuery]
        public IQueryable<UsuarioParadero> GetUsuarioParadero([FromODataUri] int key)
        {
            return db.Paradero.Where(m => m.Id == key).SelectMany(m => m.UsuarioParadero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParaderoExists(int key)
        {
            return db.Paradero.Count(e => e.Id == key) > 0;
        }
    }
}
