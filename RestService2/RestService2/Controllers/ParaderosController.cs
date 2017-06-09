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

using System.Device.Location;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

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
        private MicroSystemDBEntities6 db = new MicroSystemDBEntities6();


        //Entregar usuarios que seleccionaron tal paradero
        //Obtener micros dirigiendose a tal paradero



        // POST: odata/Paraderos(5)/UsuariosQueSeleccionaron
        // nota: retorna en campo DistanciaEntre valor -1 si esque hay algun error de internet o más probablemente la ruta es imposible
        [HttpPost]
        public List<UsuarioParadero> UsuariosQueSeleccionaron([FromODataUri] int key)
        {
            Paradero paradero = db.Paradero.Where(p => p.Id == key).FirstOrDefault();
            List<UsuarioParadero> usuarioParaderos = paradero.UsuarioParadero.ToList();

            Usuario user;

            foreach(UsuarioParadero usuarioParadero in usuarioParaderos)
            {
                //crear ruta por medio de gmap desde el usuario al paradero
                //sacar y asignar distancia
                //no es necesario registrar la ruta en si en ningun lado, solo distancia

                user = usuarioParadero.Usuario1;

                GDirections direccion;

                PointLatLng puntoInicio = new PointLatLng(user.Latitud, user.Longitud);
                PointLatLng puntoFinal = new PointLatLng(paradero.Latitud, paradero.Longitud);

                var rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, puntoInicio, puntoFinal, false, false, true, false, false);

                double distancia;
                if (direccion == null)
                {
                    //problemas de internet o ruta imposible
                    usuarioParadero.DistanciaEntre = -1;
                    continue;
                }

                GMapRoute ultimoFragmentoRuta = new GMapRoute(direccion.Route, "rutaUserParadero");
                distancia = ultimoFragmentoRuta.Distance;
                usuarioParadero.DistanciaEntre = distancia;

            }

            return usuarioParaderos;
        }

        // POST: odata/Paraderos(5)/MicrosQueSeleccionaron
        [HttpPost]
        public List<MicroParadero> MicrosQueSeleccionaron([FromODataUri] int key)
        {
            Paradero paradero = db.Paradero.Where(p => p.Id == key).FirstOrDefault();

            List<MicroParadero> microParaderos = paradero.MicroParadero.ToList();

            List<Coordenada> coorHastaParadero;
            Ruta rutaIda;
            Ruta rutaVuelta;
            Micro micro;
            Coordenada sigCoor;

            foreach (MicroParadero microParadero in microParaderos)
            {
                coorHastaParadero = new List<Coordenada>();

                micro = microParadero.Micro1;
                rutaIda = micro.Linea.Ruta;
                rutaVuelta = micro.Linea.Ruta1;
                sigCoor = micro.Coordenada;

                coorHastaParadero.Add(sigCoor);

                bool encontrado = false;

                while(sigCoor != null)
                {
                    sigCoor = sigCoor.Coordenada2;
                    coorHastaParadero.Add(sigCoor);

                    if(sigCoor.Latitud == paradero.Latitud && sigCoor.Longitud == paradero.Longitud)
                    {
                        encontrado = true;
                        break;
                    }
                }

                //si encontrado sigue en falso significa que
                //la ruta que se reviso antes era la de ida y falta revisar la de vuelta
                if(encontrado == false)
                {
                    sigCoor = rutaVuelta.Coordenada;
                    coorHastaParadero.Add(sigCoor);

                    while (sigCoor != null)
                    {
                        sigCoor = sigCoor.Coordenada2;
                        coorHastaParadero.Add(sigCoor);

                        if (sigCoor.Latitud == paradero.Latitud && sigCoor.Longitud == paradero.Longitud)
                        {
                            break;
                        }
                    }
                }

                //sacar distancia siguiendo la ruta entre micro y el paradero

                double distMetros = DistanciaEntrePuntos(new PointLatLng(micro.MicroChofer.Usuario.Latitud, micro.MicroChofer.Usuario.Longitud),
                                                        new PointLatLng(coorHastaParadero[0].Latitud, coorHastaParadero[0].Longitud));

                for (int i = 0; i < coorHastaParadero.Count - 1; i++)
                {
                    distMetros += DistanciaEntrePuntos(new PointLatLng(coorHastaParadero[i].Latitud, coorHastaParadero[i].Longitud),
                                                        new PointLatLng(coorHastaParadero[i+1].Latitud, coorHastaParadero[i+1].Longitud));
                }

                microParadero.DistanciaEntre = distMetros;
            }

            return microParaderos;
        }

        private double DistanciaEntrePuntos(PointLatLng punto1, PointLatLng punto2)
        {
            //GMapRoute r = new GMapRoute("asdf");
            //r.Points.Add(punto1);
            //r.Points.Add(punto2);

            //double distance = r.Distance;

            var sCoord = new GeoCoordinate(punto1.Lat, punto1.Lng);
            var eCoord = new GeoCoordinate(punto2.Lat, punto2.Lng);

            return sCoord.GetDistanceTo(eCoord);
        }

        #region metodos originales

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
    #endregion


}
