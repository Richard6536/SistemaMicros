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
        private TimeSpan timeSpanCero = new TimeSpan(0, 0, 0);

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

            //Si es chofer y si esta asociado a una siguiente coordenada
            //no se usa paradero o no se podria saber cuando termina le recorrido (llegar a la ultima coordenada)
            //ir actualizando siguientes paraderos y siguientes vertices
            if (user.Rol == 1 && user.MicroChoferId != null)
            {
                Micro micro = user.MicroChofer1.Micro1;
                if (micro.SiguienteVerticeId != null && micro.LineaId != null)
                {
                    Linea lineaAsociada = micro.Linea;
                    var choferCoordenada = new GeoCoordinate(user.Latitud, user.Longitud);

                    ActualizarParaderos(micro, choferCoordenada, lineaAsociada);

                    ActualizarVertices(micro, user, choferCoordenada, lineaAsociada);
                }
            }

            db.SaveChanges();

            return Ok();
        }

        // POST: odata/Usuarios(5)/ObtenerPosicion
        [HttpPost]
        public Posicion ObtenerPosicion([FromODataUri] int key)
        {

            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();
            Posicion pos = new Posicion(user.Latitud, user.Longitud);

            user.TransmitiendoPosicion = true;

            //Si es chofer y si esta asociado a una siguiente coordenada
            //no se usa paradero o no se podria saber cuando termina le recorrido (llegar a la ultima coordenada)
            //ir actualizando siguientes paraderos y siguientes vertices
            if (user.Rol == 1 && user.MicroChoferId != null)
            {
                Micro micro = user.MicroChofer1.Micro1;
                if (micro.SiguienteVerticeId != null && micro.LineaId != null)
                {
                    Linea lineaAsociada = micro.Linea;
                    var choferCoordenada = new GeoCoordinate(user.Latitud, user.Longitud);

                    ActualizarParaderos(micro,choferCoordenada,lineaAsociada);
                    ActualizarVertices(micro,user,choferCoordenada,lineaAsociada);
                }
            }
            db.SaveChanges();

            return pos;
        }

        void ActualizarParaderos(Micro _micro, GeoCoordinate _choferCoordenada, Linea _lineaAsociada)
        {
            if (_micro.MicroParaderoId != null)
            {
                double DistanciaLimiteParadero = 50;
                Paradero sigParadero = _micro.MicroParadero.Paradero;

                double distAntigua = _micro.MicroParadero.DistanciaEntre;

                var sigParaderoCoordenada = new GeoCoordinate(sigParadero.Latitud, sigParadero.Longitud);
                double distSigParadero = _choferCoordenada.GetDistanceTo(sigParaderoCoordenada);

                if(distSigParadero <= DistanciaLimiteParadero)
                {
                    IniciarParaderoHistorial(_micro);
                }

                //si salio del radio determinado del paradero, se actualiza el siguiente paradero
                if (distSigParadero >= DistanciaLimiteParadero && distAntigua <= DistanciaLimiteParadero)
                {
                    TerminarParaderoHistorial(_micro);

                    List<Paradero> paraderosLinea = new List<Paradero>();

                    #region LLenar los paraderos de la linea
                    List<Paradero> paraderosIda = _lineaAsociada.Ruta.Paradero.ToList();
                    List<Paradero> paraderosVuelta = _lineaAsociada.Ruta1.Paradero.ToList();

                    for (int i = 0; i < paraderosIda.Count; i++) //ida
                    {
                        paraderosLinea.Add(paraderosIda[i]);
                    }

                    for (int i = 0; i < paraderosVuelta.Count; i++)//ida
                    {
                        paraderosLinea.Add(paraderosVuelta[i]);
                    }

                    paraderosLinea = paraderosLinea.OrderBy(p => p.Id).ToList();
                    #endregion

                    for (int i = 0; i < paraderosLinea.Count; i++)
                    {
                        if (sigParadero.Id == paraderosLinea[i].Id)
                        {
                            //if para ver si se llego al paradero final
                            if (i + 1 == paraderosLinea.Count)
                            {
                                //Se llego al paradero final
                                MicroParadero mp = _micro.MicroParadero;
                                _micro.MicroParadero = null;
                                db.MicroParadero.Remove(mp);
                                break;
                            }

                            Paradero siguiente = paraderosLinea[i + 1];
                            double distPosibleSig = _choferCoordenada.GetDistanceTo(new GeoCoordinate(siguiente.Latitud, siguiente.Longitud));

                            _micro.MicroParadero.Paradero = siguiente;
                            _micro.MicroParadero.DistanciaEntre = distPosibleSig;
                        }
                    }
                }


                else
                {
                    //caso contrario se actualiza la distancia del microparadero
                    _micro.MicroParadero.DistanciaEntre = distSigParadero;
                }

            }
        }

        void ActualizarVertices(Micro _micro, Usuario _user, GeoCoordinate _choferCoordenada, Linea _lineaAsociada)
        {

            double distLimiteVertices = 100;

            Coordenada sigCoor = _micro.Coordenada;
            var sigVerticeCoordenada = new GeoCoordinate(sigCoor.Latitud, sigCoor.Longitud);
            double distSigCoor = _choferCoordenada.GetDistanceTo(sigVerticeCoordenada);

            if (distSigCoor <= distLimiteVertices)
            {
                List<Coordenada> coordenadasLinea = ObtenerCoordenadasLinea(_lineaAsociada.Id);
                for (int i = 0; i < coordenadasLinea.Count; i++)
                {
                    if (coordenadasLinea[i].Id == sigCoor.Id)
                    {
                        int c = 1;
                        int indexSiguiente = Clamp(i + c, 0, coordenadasLinea.Count - 1);

                        if (indexSiguiente == coordenadasLinea.Count - 1)
                        {
                            //termina recorrido
                            _user.MicroChofer1.Micro1.Coordenada = null;
                            _user.MicroChofer1.Micro1.SiguienteVerticeId = null;
                            TerminarRecorridoHistorial(_micro);
                            break;
                        }

                        Coordenada posibleSig = coordenadasLinea[i + c];
                        double distPosibleSig = _choferCoordenada.GetDistanceTo(new GeoCoordinate(posibleSig.Latitud, posibleSig.Longitud));

                        while (distPosibleSig <= distLimiteVertices)
                        {
                            c++;
                            indexSiguiente = Clamp(i + c, 0, coordenadasLinea.Count - 1);
                            if (indexSiguiente == coordenadasLinea.Count - 1)
                            {
                                i = int.MaxValue; //sale del for
                                _user.MicroChofer1.Micro1.Coordenada = null;
                                _user.MicroChofer1.Micro1.SiguienteVerticeId = null;
                                TerminarRecorridoHistorial(_micro);
                                //termina recorrido
                                break;
                            }

                            posibleSig = coordenadasLinea[i + c];
                            distPosibleSig = _choferCoordenada.GetDistanceTo(new GeoCoordinate(posibleSig.Latitud, posibleSig.Longitud));
                        }
                        _micro.Coordenada = posibleSig;

                    }
                }
            }
        }

        private void TerminarRecorridoHistorial(Micro _micro)
        {
            List<HistorialDiario> hDiarios = _micro.HistorialDiario.ToList();

            HistorialDiario hDiario = null;
            //se busca el historial diario con la fecha de hoy (siempre deberia haber uno)
            //se editan los tiempos finales del historial diario y del ultimo historial idavuelta
            for (int i = 0; i < hDiarios.Count; i++)
            {
                hDiario = hDiarios[i];

                if (hDiario.Fecha == DateTime.Today)
                {
                    hDiario.HoraFinal = DateTime.Now;
                    hDiario.NumeroIdaVueltas = hDiario.NumeroIdaVueltas + 1;

                    HistorialIdaVuelta ultimoHiv = hDiario.HistorialIdaVuelta.OrderBy(h => h.Id).ToList().Last();

                    ultimoHiv.HoraTermino = DateTime.Now;
                    ultimoHiv.DuracionRecorrido = ultimoHiv.HoraInicio - DateTime.Now;
                }

            }
            db.SaveChanges();

        }

        void IniciarParaderoHistorial(Micro _micro)
        {
            //tomar el ultimo historial idavuelta (deberia de estar incompleto aun garantizado)
            HistorialDiario HDhoy = _micro.HistorialDiario.Where(hd => hd.Fecha == DateTime.Today).FirstOrDefault();
            HistorialIdaVuelta ultimoHIV = HDhoy.HistorialIdaVuelta.OrderBy(h => h.Id).ToList().Last();

            //revisar si el ultimo historialParadero ya existe (se nota porque no tiene el campo tiempo detenido asignado)
            HistorialParadero ultimoHP = ultimoHIV.HistorialParadero.OrderBy(h => h.Id).ToList().Last();

            if (ultimoHP.TiempoDetenido != timeSpanCero)
            {
                //llega al paradero
                HistorialParadero hpNuevo = new HistorialParadero();
                hpNuevo.HoraLlegada = DateTime.Now;
                hpNuevo.TiempoDetenido = new TimeSpan(0, 0, 0);

                ultimoHIV.HistorialParadero.Add(hpNuevo);
            }
        }

        void TerminarParaderoHistorial(Micro _micro)
        {
            //sale del paradero y marca la duracion de cuanto tiempo estuvo en el area

            //tomar el ultimo historial idavuelta (deberia de estar incompleto aun garantizado)
            HistorialDiario HDhoy = _micro.HistorialDiario.Where(hd => hd.Fecha == DateTime.Today).FirstOrDefault();
            HistorialIdaVuelta ultimoHIV = HDhoy.HistorialIdaVuelta.OrderBy(h => h.Id).ToList().Last();

            //el ultimo historial paradero se edita
            HistorialParadero ultimoHP = ultimoHIV.HistorialParadero.OrderBy(h => h.Id).ToList().Last();
            ultimoHP.TiempoDetenido = DateTime.Now - ultimoHP.HoraLlegada;
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

        //POST: odata/Usuarios(5)/SeleccionarParaderoDX
        //Parametros: IdParadero
        [HttpPost]
        public string SeleccionarParaderoDX([FromODataUri] int key, ODataActionParameters parameters)
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
            return "okap";
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

        public int Clamp(int val, int min, int max)
        {
            if (val < min) return min;
            else if (val > max) return max;
            else return val;
        }



        #endregion
    }
}
