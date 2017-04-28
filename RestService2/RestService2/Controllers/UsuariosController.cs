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
    builder.EntitySet<Usuario>("Usuarios");
    builder.EntitySet<MicroChofer>("MicroChofer"); 
    builder.EntitySet<UsuarioParadero>("UsuarioParadero"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class UsuariosController : ODataController
    {
        private MicroSystemDBEntities1 db = new MicroSystemDBEntities1();

        // GET: odata/Usuarios
        [EnableQuery]
        public IQueryable<Usuario> GetUsuarios()
        {
            return db.Usuario;
        }

        // GET: odata/Usuarios(5)
        [EnableQuery]
        public SingleResult<Usuario> GetUsuario([FromODataUri] int key)
        {
            return SingleResult.Create(db.Usuario.Where(usuario => usuario.Id == key));
        }

        // PUT: odata/Usuarios(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Usuario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = db.Usuario.Find(key);
            if (usuario == null)
            {
                return NotFound();
            }

            patch.Put(usuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(usuario);
        }

        // POST: odata/Usuarios
        public IHttpActionResult Post(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuario.Add(usuario);
            db.SaveChanges();

            return Created(usuario);
        }

        // PATCH: odata/Usuarios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Usuario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = db.Usuario.Find(key);
            if (usuario == null)
            {
                return NotFound();
            }

            patch.Patch(usuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(usuario);
        }

        // DELETE: odata/Usuarios(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Usuario usuario = db.Usuario.Find(key);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuario.Remove(usuario);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Usuarios(5)/MicroChofer
        [EnableQuery]
        public IQueryable<MicroChofer> GetMicroChofer([FromODataUri] int key)
        {
            return db.Usuario.Where(m => m.Id == key).SelectMany(m => m.MicroChofer);
        }

        // GET: odata/Usuarios(5)/MicroChofer1
        [EnableQuery]
        public SingleResult<MicroChofer> GetMicroChofer1([FromODataUri] int key)
        {
            return SingleResult.Create(db.Usuario.Where(m => m.Id == key).Select(m => m.MicroChofer1));
        }
        //[EnableQuery]
        [HttpGet]
        public IQueryable<Coordenada> GetRutaCompleta()
        {
            List<Coordenada> devolver = new List<Coordenada>();
            var primera = db.Coordenada.Find(326);
            devolver.Add(primera); 
            var siguiente = primera.Coordenada2;
            while(siguiente != null)
            {
                devolver.Add(siguiente);
                siguiente = siguiente.Coordenada2;
            }
            return devolver.AsQueryable<Coordenada>();
        }


        [HttpPost]
        public string Mensaje()
        {

            return "Hola";
        }

        //Link:  localhost:8433/odata/Usuarios/MensajeParametros

        /*BODY
        {
          "Nombre":'asdf',
          "Edad":7 
        }
        */
        [HttpPost]
        public string MensajeParametros(ODataActionParameters parameters)
        {
            if (parameters == null)
                return "error";

            int edad = (int)parameters["Edad"];
            string nombre = (string)parameters["Nombre"];
            return "Mi nombre es " + nombre + " y tengo " + edad + " años";
        }


        // GET: odata/Usuarios(5)/UsuarioParadero
        [EnableQuery]
        public SingleResult<UsuarioParadero> GetUsuarioParadero([FromODataUri] int key)
        {
            return SingleResult.Create(db.Usuario.Where(m => m.Id == key).Select(m => m.UsuarioParadero));
        }

        // GET: odata/Usuarios(5)/UsuarioParadero1
        [EnableQuery]
        public IQueryable<UsuarioParadero> GetUsuarioParadero1([FromODataUri] int key)
        {
            return db.Usuario.Where(m => m.Id == key).SelectMany(m => m.UsuarioParadero1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int key)
        {
            return db.Usuario.Count(e => e.Id == key) > 0;
        }
    }
}
