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
using RestServiceGX.Models;
using RestServiceGX.Classes;

using System.Device.Location;

namespace RestServiceGX.Controllers
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
        private MicroSystemDBEntities db = new MicroSystemDBEntities();

        //Seleccionar paradero
        //Deseleccionar paradero
        //NuevaCalificacion

        // POST: odata/Micros(5)/IniciarRecorrido
        [HttpPost]
        public IHttpActionResult IniciarRecorrido([FromODataUri] int key)
        {
            Micro micro = db.Micro.Where(m => m.Id == key).FirstOrDefault();

            if (micro.LineaId != null && micro.MicroChoferId != null)
            {
                IniciarRecorridoHistorial(micro);

                Ruta rIda = micro.Linea.Ruta;

                Paradero primerParadero = rIda.Paradero.OrderBy(p => p.Orden).ToList()[0];
                Coordenada primerCoordenada = rIda.Coordenada.Where(c => c.Orden == 0).FirstOrDefault();
                Usuario chofer = micro.MicroChofer.Usuario;
                chofer.TransmitiendoPosicion = true;

                if (micro.MicroParaderoId != null)
                {
                    MicroParadero mp = micro.MicroParadero;
                    db.MicroParadero.Remove(mp);
                }

                var geoMicro = new GeoCoordinate(micro.MicroChofer.Usuario.Latitud, micro.MicroChofer.Usuario.Longitud);
                var geoParadero = new GeoCoordinate(primerParadero.Latitud, primerParadero.Longitud);

                MicroParadero mpNuevo = new MicroParadero();
                mpNuevo.Micro1 = micro;
                mpNuevo.Paradero = primerParadero;
                mpNuevo.DistanciaEntre = geoMicro.GetDistanceTo(geoParadero);

                micro.MicroParadero = mpNuevo;
                micro.Coordenada = primerCoordenada;

                db.MicroParadero.Add(mpNuevo);
                db.SaveChanges();
            }

            return Ok();
        }

        // POST: odata/Micros(5)/IniciarRecorridoV2
        // parametros: IdUser
        [HttpPost]
        public bool IniciarRecorridoV2([FromODataUri] int key, ODataActionParameters parameters)
        {
            int idUser = (int)parameters["IdUser"];

            Usuario user = db.Usuario.Where(u => u.Id == idUser).FirstOrDefault();
            Micro micro = db.Micro.Where(m => m.Id == key).FirstOrDefault();

            if (user.MicroChoferId == null)
                return false;
            if (user.MicroChofer1.Micro1.Id != micro.Id)
                return false;

            if (micro.LineaId != null && micro.MicroChoferId != null)
            {
                IniciarRecorridoHistorial(micro);

                Ruta rIda = micro.Linea.Ruta;

                Paradero primerParadero = rIda.Paradero.OrderBy(p => p.Orden).ToList()[0];
                Coordenada primerCoordenada = rIda.Coordenada.Where(c => c.Orden == 0).FirstOrDefault();
                Usuario chofer = micro.MicroChofer.Usuario;
                chofer.TransmitiendoPosicion = true;

                if (micro.MicroParaderoId != null)
                {
                    MicroParadero mp = micro.MicroParadero;
                    db.MicroParadero.Remove(mp);
                }

                var geoMicro = new GeoCoordinate(micro.MicroChofer.Usuario.Latitud, micro.MicroChofer.Usuario.Longitud);
                var geoParadero = new GeoCoordinate(primerParadero.Latitud, primerParadero.Longitud);

                MicroParadero mpNuevo = new MicroParadero();
                mpNuevo.Micro1 = micro;
                mpNuevo.Paradero = primerParadero;
                mpNuevo.DistanciaEntre = geoMicro.GetDistanceTo(geoParadero);

                micro.MicroParadero = mpNuevo;
                micro.Coordenada = primerCoordenada;

                db.MicroParadero.Add(mpNuevo);
                db.SaveChanges();
            }

            return true;
        }



        private void IniciarRecorridoHistorial(Micro _micro)
        {
            List<HistorialDiario> hDiarios = _micro.HistorialDiario.ToList();

            //con lista vacia se crea un nuevo historial diario y de idavuelta
            if (hDiarios.Count == 0)
            {
                HistorialDiario HDnuevo = new HistorialDiario();
                HDnuevo.Fecha = DateTime.Today;
                HDnuevo.NombreChofer = _micro.MicroChofer.Usuario.Nombre;
                HDnuevo.HoraInicio = DateTime.Now;
                HDnuevo.HoraFinal = DateTime.Now;
                HDnuevo.CalificacionDiaria = 0;
                HDnuevo.CalificacionesRecibidas = 0;

                _micro.HistorialDiario.Add(HDnuevo);

                HistorialIdaVuelta HIVnuevo = new HistorialIdaVuelta();
                HIVnuevo.HoraInicio = DateTime.Now;
                HIVnuevo.HoraTermino = DateTime.Now;
                HIVnuevo.DuracionRecorrido = new TimeSpan(0, 0, 0);
                HIVnuevo.Orden = HDnuevo.HistorialIdaVuelta.Count + 1;

                HDnuevo.HistorialIdaVuelta.Add(HIVnuevo);
                db.SaveChanges();
                return;
            }

            HistorialDiario hDiaro = null;
            //se busca si ya hay un historial diario con la fecha de hoy y se trabaja con ese
            //solo se crea un nuevo historia idavuelta
            for (int i = 0; i < hDiarios.Count; i++)
            {
                HistorialDiario hDiaroActual = hDiarios[i];

                if (hDiaroActual.Fecha == DateTime.Today)
                {
                    hDiaro = hDiaroActual;

                    HistorialIdaVuelta HIVnuevo = new HistorialIdaVuelta();
                    HIVnuevo.HoraInicio = DateTime.Now;
                    HIVnuevo.HoraTermino = DateTime.Now;
                    HIVnuevo.Orden = hDiaroActual.HistorialIdaVuelta.Count + 1;
                    hDiaro.HistorialIdaVuelta.Add(HIVnuevo);
                }

            }
            //caso contrario se crea un nuevo historial diario y idavuelta para el dia de hoy
            if (hDiaro == null)
            {
                HistorialDiario HDnuevo = new HistorialDiario();
                HDnuevo.Fecha = DateTime.Today;
                HDnuevo.NombreChofer = _micro.MicroChofer.Usuario.Nombre;
                HDnuevo.HoraInicio = DateTime.Now;
                HDnuevo.HoraFinal = DateTime.Now;
                HDnuevo.CalificacionDiaria = 0;
                HDnuevo.CalificacionesRecibidas = 0;

                _micro.HistorialDiario.Add(HDnuevo);

                HistorialIdaVuelta HIVnuevo = new HistorialIdaVuelta();
                HIVnuevo.Orden = 1;
                HIVnuevo.HoraInicio = DateTime.Now;
                HIVnuevo.HoraTermino = DateTime.Now;

                HDnuevo.HistorialIdaVuelta.Add(HIVnuevo);
            }

            db.SaveChanges();
        }

        //// POST: odata/Micros(5)/DetenerRecorrido
        //[HttpPost]
        //public IHttpActionResult DetenerRecorrido([FromODataUri] int key)
        //{
        //    Micro micro = db.Micro.Where(m => m.Id == key).FirstOrDefault();

        //    TerminarRecorridoHistorial(micro);

        //    micro.Coordenada = null;
        //    micro.SiguienteVerticeId = null;

        //    Usuario chofer = micro.MicroChofer.Usuario;
        //    chofer.TransmitiendoPosicion = false;

        //    if (micro.MicroParaderoId != null)
        //    {
        //        MicroParadero mp = micro.MicroParadero;
        //        db.MicroParadero.Remove(mp);
        //    }
        //    db.SaveChanges();

        //    return Ok();
        //}

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

            micro.NumeroCalificaciones++;      
            micro.Calificacion = (micro.Calificacion + cal) / micro.NumeroCalificaciones;

            HistorialCalificacionNuevo(micro, cal);
            
            db.SaveChanges();

            return micro.Calificacion;
        }


        void HistorialCalificacionNuevo(Micro _micro, float _calificacion)
        {
            HistorialDiario HDhoy = _micro.HistorialDiario.Where(hd => hd.Fecha == DateTime.Today).FirstOrDefault();

            HDhoy.CalificacionesRecibidas++;

            var calificacionDiaria = HDhoy.CalificacionDiaria;

            try
            {
                HDhoy.CalificacionDiaria = (HDhoy.CalificacionDiaria + _calificacion) / HDhoy.CalificacionesRecibidas;
            }
            catch(Exception)
            {
                HDhoy.CalificacionDiaria = _calificacion;
            }
            
        }

        //POST: odata/Micros(5)/ObtenerMiParadero
        //Parametros: nop
        [HttpPost]
        public Paradero ObtenerMiParadero([FromODataUri] int key)
        {
            Micro micro = db.Micro.Where(m => m.Id == key).FirstOrDefault();

            if (micro == null)
            {
                return new Paradero() { Id = -1 };
            }
            else if (micro.MicroParaderoId == null)
            {
                return new Paradero() { Id = -1 };
            }
            else
            {
                Paradero p = micro.MicroParadero.Paradero;
                return p;
            }
        }

        //POST: odata/Micros(5)/ObtenerHistorialesDiarios
        [HttpPost]
        public List<HistorialDiario> ObtenerHistorialesDiarios([FromODataUri] int key)
        {
            Micro micro = db.Micro.Where(m => m.Id == key).FirstOrDefault();

            List<HistorialDiario> hDiarios = micro.HistorialDiario.ToList();

            return hDiarios;
        }


        #region metodo originales
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
        #endregion


        //private void TerminarRecorridoHistorial(Micro _micro)
        //{
        //    List<HistorialDiario> hDiarios = _micro.HistorialDiario.ToList();

        //    HistorialDiario hDiario = null;
        //    //se busca el historial diario con la fecha de hoy (siempre deberia haber uno)
        //    //se editan los tiempos finales del historial diario y del ultimo historial idavuelta
        //    for (int i = 0; i < hDiarios.Count; i++)
        //    {
        //        hDiario = hDiarios[i];

        //        if (hDiario.Fecha == DateTime.Today)
        //        {
        //            hDiario.HoraFinal = DateTime.Now;
        //            hDiario.NumeroIdaVueltas = hDiario.NumeroIdaVueltas + 1;

        //            HistorialIdaVuelta ultimoHiv = hDiario.HistorialIdaVuelta.OrderBy(h => h.Orden).ToList().Last();

        //            ultimoHiv.HoraTermino = DateTime.Now;
        //            ultimoHiv.DuracionRecorrido = DateTime.Now - ultimoHiv.HoraInicio;

        //            //------------Calcular kilometros-------
        //            //se toman kilometros recorridos desde fin dela linea hasta el principio
        //            List<Coordenada> coorIda = _micro.Linea.Ruta.Coordenada.OrderBy(c => c.Orden).ToList();
        //            List<Coordenada> coorVuelta = _micro.Linea.Ruta1.Coordenada.OrderBy(c => c.Orden).ToList();

        //            double metrosTotales = 0;

        //            for (int z = 0; z < coorIda.Count - 1; z++)
        //            {
        //                var sCoord = new GeoCoordinate(coorIda[i].Latitud, coorIda[i].Longitud);
        //                var eCoord = new GeoCoordinate(coorIda[i + 1].Latitud, coorIda[i + 1].Longitud);

        //                metrosTotales += sCoord.GetDistanceTo(eCoord);
        //            }

        //            for (int z = 0; z < coorVuelta.Count - 1; z++)
        //            {
        //                var sCoord = new GeoCoordinate(coorVuelta[i].Latitud, coorVuelta[i].Longitud);
        //                var eCoord = new GeoCoordinate(coorVuelta[i + 1].Latitud, coorVuelta[i + 1].Longitud);

        //                metrosTotales += sCoord.GetDistanceTo(eCoord);
        //            }

        //            float KilometrosTotales = (float)(metrosTotales / 1000);
        //            hDiario.KilometrosRecorridos += KilometrosTotales;
                    
        //        }

        //    }
        //    db.SaveChanges();

        //}

       
    }
}