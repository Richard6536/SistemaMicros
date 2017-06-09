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

using System.Device.Location;

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
        private MicroSystemDBEntities6 db = new MicroSystemDBEntities6();

        //Validar
        //Editar
        //existe mail
        //actualizar posicion
        //detener actualizacion de posicion
        //Obtener micro de chofer
        //Seleccionar paradero (id paradero)
        //Deseleccionar paradero (sin id)

        //POST: odata/Usuarios/EsValido
        //Parametros: Email,Password
        [HttpPost]
        public Usuario EsValido(ODataActionParameters parameters)
        {
            Usuario userFallido = new Usuario() { Id = -1 };

            if (parameters == null)
                return userFallido;

            string mail = (string)parameters["Email"];
            string pass = (string)parameters["Password"];

            Usuario user = db.Usuario.Where(u => u.Email == mail).FirstOrDefault();

            if (user == null)
                return userFallido;

            bool valido = PasswordHash.ValidatePassword(pass, user.Password);

            if (valido)
                return user;
            else
                return userFallido;
        }


        //POST: odata/Usuarios(5)/EditarDatos
        //Parametros: ???
        [HttpPost]
        public IHttpActionResult EditarDatos([FromODataUri]int key, ODataActionParameters parameters)
        {
            string nombre = (string)parameters["Nombre"];
            string pass = (string)parameters["Password"];

            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();
            user.Nombre = nombre;
            db.SaveChanges();
            return Ok();
        }

        //POST: odata/Usuarios/ExisteMail
        //Parametros: Email
        [HttpPost]
        public bool ExisteMail(ODataActionParameters parameters)
        {
            string mail = (string)parameters["Email"];

            Usuario user = db.Usuario.Where(u => u.Email == mail).FirstOrDefault();

            if (user == null)
                return false;
            else
                return true;
        }

        //POST: odata/Usuarios(5)/ActualizarPosicion
        //Parametros: Latitud, Longitud
        [HttpPost]
        public IHttpActionResult ActualizarPosicion([FromODataUri] int key, ODataActionParameters parameters)
        {
            double latitud = (double)parameters["Latitud"];
            double longitud = (double)parameters["Longitud"]; 

            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();

            user.TransmitiendoPosicion = true;
            user.Latitud = latitud;
            user.Longitud = longitud;

            //Si es chofer y si esta asociado a un paradero 
            //ir actualizando siguientes paraderos y siguientes vertices
            if (user.Rol == 1 && user.MicroChoferId != null)
            {
                Micro micro = user.MicroChofer1.Micro1;
                if (micro.MicroParaderoId != null && micro.LineaId != null)
                {
                    Linea lineaAsociada = micro.Linea;         
                    Paradero sigParadero = micro.MicroParadero.Paradero;
                    Coordenada sigCoor = micro.Coordenada;

                    //Distancia desde chofer al siguiente vertice/paradero
                    var choferCoordenada = new GeoCoordinate(user.Latitud, user.Longitud);
                    var sigVerticeCoordenada = new GeoCoordinate(sigCoor.Latitud, sigCoor.Longitud);
                    var sigParaderoCoordenada = new GeoCoordinate(sigParadero.Latitud, sigParadero.Longitud);

                    double distSigCoor = choferCoordenada.GetDistanceTo(sigVerticeCoordenada);
                    double distSigParadero = choferCoordenada.GetDistanceTo(sigParaderoCoordenada);

                    //Obtener distancia hasta paraderoACtual y coorACtual
                    //si esta dentro del rango hay que actualizar a los siguientes
                    if (distSigCoor <= 30)
                    {
                        List<Coordenada> coordenadasLinea = ObtenerCoordenadasLinea(lineaAsociada.Id);
                        for (int i = 0; i < coordenadasLinea.Count; i++)
                        {
                            if(coordenadasLinea[i].Id == sigCoor.Id)
                            {
                                int c = 1;
                                Coordenada posibleSig = coordenadasLinea[i + c];
                                double distPosibleSig = choferCoordenada.GetDistanceTo(new GeoCoordinate(posibleSig.Latitud,posibleSig.Longitud));

                                while(distPosibleSig <= 30)
                                {
                                    c++;
                                    posibleSig = coordenadasLinea[i + c];
                                    distPosibleSig = choferCoordenada.GetDistanceTo(new GeoCoordinate(posibleSig.Latitud, posibleSig.Longitud));
                                }
                                micro.Coordenada = posibleSig;
                            }
                        }

                        //Identificar siguiente coordendada 
                        //si la siguiente coordenada sigue dentro del rango pasar al siguiente
                        //el primero fuera del rango se actualiza
                    }

                    if(distSigParadero <= 30)
                    {
                        List<Paradero> paraderosLinea = new List<Paradero>();
                        List<Paradero> paraderosIda = lineaAsociada.Ruta.Paradero.ToList();
                        List<Paradero> paraderosVuelta = lineaAsociada.Ruta1.Paradero.ToList();

                        for (int i = 0; i < paraderosIda.Count; i++) //ida
                        {
                            paraderosLinea.Add(paraderosIda[i]);
                        }

                        for (int i = 0; i < paraderosVuelta.Count; i++)//ida
                        {
                            paraderosLinea.Add(paraderosVuelta[i]);
                        }

                        for (int i = 0; i < paraderosLinea.Count; i++)
                        {
                            if(sigParadero.Id == paraderosLinea[i].Id)
                            {
                                int c = 1;
                                Paradero posibleSig = paraderosLinea[i + c];
                                double distPosibleSig = choferCoordenada.GetDistanceTo(new GeoCoordinate(posibleSig.Latitud, posibleSig.Longitud));

                                while (distPosibleSig <= 30)
                                {
                                    c++;
                                    posibleSig = paraderosLinea[i + c];
                                    distPosibleSig = choferCoordenada.GetDistanceTo(new GeoCoordinate(posibleSig.Latitud, posibleSig.Longitud));
                                }

                                micro.MicroParadero.Paradero.MicroParadero = null;
                                micro.MicroParadero.Paradero = posibleSig;
                            }
                        }
                    }

                }
            }

            db.SaveChanges();

            return Ok();
        }

        //POST: odata/Usuarios(5)/DetenerPosicionUpdate
        [HttpPost]
        public IHttpActionResult DetenerPosicionUpdate([FromODataUri] int key)
        {
            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();

            user.TransmitiendoPosicion = false;
            db.SaveChanges();

            return Ok();
        }

        //POST: odata/Usuarios(5)/ObtenerMicro
        //Parametros: nope
        [HttpPost]
        public Micro ObtenerMicro([FromODataUri] int key)
        {
            Micro microFallida = new Micro() { Id = -1 };
            try
            {           
                Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();
                return user.MicroChofer1.Micro1;
            }
            catch
            {
                return microFallida;
            }
            
        }

        //POST: odata/Usuarios(5)/SeleccionarParadero
        //Parametros: IdParadero
        [HttpPost]
        public IHttpActionResult SeleccionarParadero([FromODataUri] int key, ODataActionParameters parameters)
        {
            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();
            int idParadero = (int)parameters["IdParadero"];
            Paradero paradero = db.Paradero.Where(p => p.Id == idParadero).FirstOrDefault();

            if(user.UsuarioParaderoId != null)
            {
                UsuarioParadero up = user.UsuarioParadero;
                db.UsuarioParadero.Remove(up);
            }

            UsuarioParadero upNuevo = new UsuarioParadero();
            upNuevo.Usuario1 = user;
            upNuevo.Paradero = paradero;

            user.UsuarioParadero = upNuevo;

            db.UsuarioParadero.Add(upNuevo);
            db.SaveChanges();
            return Ok();
        }

        //POST: odata/Usuarios(5)/DeseleccionarParadero
        //Parametros: nope
        [HttpPost]
        public IHttpActionResult DeseleccionarParadero([FromODataUri] int key)
        {
            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();

            if (user.UsuarioParaderoId != null)
            {
                UsuarioParadero up = user.UsuarioParadero;
                db.UsuarioParadero.Remove(up);
                db.SaveChanges();
            }
            return Ok();

            
        }


        #region Originales
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
            string passEncriptada = PasswordHash.CreateHash(usuario.Password);
            usuario.Password = passEncriptada;


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
        public SingleResult<MicroChofer> GetMicroChofer([FromODataUri] int key)
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
            string mensaje =  "Mi nombre es " + nombre + " y tengo " + edad + " años";

            return mensaje;
        }


        // GET: odata/Usuarios(5)/UsuarioParadero
        [EnableQuery]
        public SingleResult<UsuarioParadero> GetUsuarioParadero([FromODataUri] int key)
        {
            return SingleResult.Create(db.Usuario.Where(m => m.Id == key).Select(m => m.UsuarioParadero));
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
        #endregion

        #region Metodos Extra
        public List<Coordenada> ObtenerCoordenadasLinea(int _idLinea)
        {
            Linea linea = db.Linea.Where(l => l.Id == _idLinea).FirstOrDefault();
            List<Coordenada> coordenadas = new List<Coordenada>();
            Ruta rutaIda = linea.Ruta;
            Ruta rutaVuelta = linea.Ruta1;

            Coordenada siguiente = rutaIda.Coordenada;

            while (siguiente != null)
            {
                coordenadas.Add(siguiente);
                siguiente = siguiente.Coordenada2;
            }

            siguiente = rutaVuelta.Coordenada;

            while (siguiente != null)
            {
                coordenadas.Add(siguiente);
                siguiente = siguiente.Coordenada2;
            }

            return coordenadas;
        }
        #endregion
    }
}
