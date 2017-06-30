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

using RestService2.Classes;

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
        private MicroSystemDBEntities10 db = new MicroSystemDBEntities10();


        //Entregar usuarios que seleccionaron tal paradero
        //Obtener micros dirigiendose a tal paradero



        // POST: odata/Paraderos(5)/UsuariosQueSeleccionaron
        // nota: retorna en campo DistanciaEntre valor -1 si esque hay algun error de internet o más probablemente la ruta es imposible
        //regresa distancia en kilometros
        [HttpPost]
        public List<UsuarioParaderoDeluxe> UsuariosQueSeleccionaron([FromODataUri] int key)
        {
            Paradero paradero = db.Paradero.Where(p => p.Id == key).FirstOrDefault();

            if(paradero == null)
            {
                return new List<UsuarioParaderoDeluxe>();
            }

            List<UsuarioParadero> usuarioParaderos = paradero.UsuarioParadero.ToList();

            List<UsuarioParaderoDeluxe> upDeluxe = new List<UsuarioParaderoDeluxe>();

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
                    user.Id = -1;
                    usuarioParadero.DistanciaEntre = -1;
                    upDeluxe.Add(new UsuarioParaderoDeluxe(){ UsuarioId = -1 });
                    continue;
                }

                GMapRoute ruta = new GMapRoute(direccion.Route, "rutaUserParadero");
                distancia = ruta.Distance;
                usuarioParadero.DistanciaEntre = distancia;

                upDeluxe.Add(new UsuarioParaderoDeluxe()
                { UsuarioId = user.Id, Latitud = user.Latitud, Longitud = user.Longitud, Distancia = distancia });

            }

            return upDeluxe;
        }


        // POST: odata/Paraderos(5)/MicroParaderoMasCercano
        //regresa distancia en metros
        [HttpPost]
        public MicroParadero MicroParaderoMasCercano([FromODataUri] int key)
        {
            double distEntreParaderos = 0;

            Paradero paradero = db.Paradero.Where(p => p.Id == key).FirstOrDefault();

            if(paradero == null)
            {
                return new MicroParadero() { Id = -1 };
            }

            Ruta rutaIda = paradero.Ruta.Linea2.Ruta;
            Ruta rutaVuelta = paradero.Ruta.Linea2.Ruta1;

            List<MicroParadero> microParaderos = paradero.MicroParadero.ToList();            
            Micro micro;
            Coordenada sigCoor;

            //suma distancia entre paradero y el anterior
            //queda asignado como paradero el anterior
            //si el anterior tampoco tiene microparaderos se repite el proceso
            //retorna un microparadero con id -1 si no existen micros desde ese paradero al inicio

            while(microParaderos.Count == 0 )
            {
                //buscar paradero anterior
                List<Paradero> paraderosRuta;
                Ruta rutaAUsar;

                if(paradero.Ruta.Id == rutaIda.Id)
                {
                    rutaAUsar = rutaIda;
                }
                else
                {
                    rutaAUsar = rutaVuelta;

                    if(rutaVuelta.Paradero.ToList()[0].Id == paradero.Id)
                    {
                        //si entra aqui es que el paradero era el primero de la ruta de vuelta
                        //se suma la distancia desde ese paradero al ultimo paradero dela ruta de ida
                        //se asigna ese paradero como punto de inicio

                        distEntreParaderos +=
                            DistanciaVerticesSiguiendoRuta(rutaVuelta.Coordenada.Latitud, rutaVuelta.Coordenada.Longitud, paradero.Latitud, paradero.Longitud);

                        paradero = rutaIda.Paradero.ToList().Last();
                        microParaderos = paradero.MicroParadero.ToList();

                        distEntreParaderos +=
                            DistanciaVerticesSiguiendoRuta(paradero.Latitud, paradero.Longitud, rutaVuelta.Coordenada.Latitud, rutaVuelta.Coordenada.Longitud);

                        continue;
                    }
                }

                paraderosRuta = rutaAUsar.Paradero.ToList().OrderBy(p => p.Id).ToList();

                //busca paradero
                //suma distancia con paradero anterior
                //reasigna paradero y microparaderos con los datos del anterior

                for (int i = 0; i < paraderosRuta.Count; i++)
                {
                    if (paraderosRuta[i].Id == paradero.Id)
                    {
                        Paradero par = paraderosRuta[i];

                        if (par == paraderosRuta.First())
                        {
                            //es el primer paradero dela ruta de ida
                            return new MicroParadero() { Id = -1 };
                        }
                        else
                        {
                            Paradero anterior = paraderosRuta[i - 1];
                            //saca distancia entre estos paraderos
                            distEntreParaderos +=
                                DistanciaVerticesSiguiendoRuta(anterior.Latitud, anterior.Longitud, paradero.Latitud, paradero.Longitud);

                            paradero = paraderosRuta[i - 1];
                            microParaderos = paradero.MicroParadero.ToList();
                        }
                        break;
                    }
                }
            }

            List<Coordenada> coorHastaParadero;
            double distMenor = double.MaxValue;
            MicroParadero mpMenor = null;
            bool sw = true;
            foreach (MicroParadero microParadero in microParaderos)
            {
                coorHastaParadero = new List<Coordenada>();

                micro = microParadero.Micro1;
                sigCoor = micro.Coordenada;

                coorHastaParadero.Add(sigCoor);

                #region Rellenar coordenadas hasta paradero
                bool encontrado = false;

                while (sigCoor != null)
                {
                    sigCoor = sigCoor.Coordenada2;
                    coorHastaParadero.Add(sigCoor);

                    if (sigCoor.Latitud == paradero.Latitud && sigCoor.Longitud == paradero.Longitud)
                    {
                        encontrado = true;
                        break;
                    }
                }

                //si encontrado sigue en falso significa que
                //la ruta que se reviso antes era la de ida y falta revisar la de vuelta
                if (encontrado == false)
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
                #endregion

                #region Sacar distancia entre Micro y paradero siguiendo la ruta
                double distMetros = DistanciaEntrePuntos(new PointLatLng(micro.MicroChofer.Usuario.Latitud, micro.MicroChofer.Usuario.Longitud),
                                                        new PointLatLng(coorHastaParadero[0].Latitud, coorHastaParadero[0].Longitud));

                for (int i = 0; i < coorHastaParadero.Count - 1; i++)
                {
                    distMetros += DistanciaEntrePuntos(new PointLatLng(coorHastaParadero[i].Latitud, coorHastaParadero[i].Longitud),
                                                        new PointLatLng(coorHastaParadero[i + 1].Latitud, coorHastaParadero[i + 1].Longitud));
                }

                microParadero.DistanciaEntre = distMetros;


                #endregion

                if (sw)
                {
                    mpMenor = microParadero;
                    distMenor = distMetros;
                    sw = false;
                }
                else
                {
                    if(distMetros < distMenor)
                    {
                        distMenor = distMetros;
                        mpMenor = microParadero;
                    }
                }
            }

            mpMenor.DistanciaEntre = distMenor + distEntreParaderos;

            return mpMenor;
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

        private double DistanciaVerticesSiguiendoRuta(double latInicio, double lngInicio, double latFinal, double lngFinal)
        {
            Coordenada coorInicio = db.Coordenada.Where(c => c.Latitud == latInicio && c.Longitud == lngInicio).FirstOrDefault();
            Coordenada coorFinal = db.Coordenada.Where(c => c.Latitud == latFinal && c.Longitud == lngFinal).FirstOrDefault();

            List<Coordenada> coorHastaFinal = new List<Coordenada>();

            #region Rellenar lista de coordenadas
            coorHastaFinal.Add(coorInicio);

            Coordenada sigCoor = coorInicio.Coordenada2;
            bool encontrado = false;
            while (sigCoor != null)
            {
                coorHastaFinal.Add(sigCoor);

                if (sigCoor.Latitud == latFinal && sigCoor.Longitud == lngFinal)
                {
                    encontrado = true;
                    break;
                }

                sigCoor = sigCoor.Coordenada2;
            }
            #endregion

            if (encontrado == false)
            {
                //No se puede llegar al punto final siguiendo la ruta
                return -1;
            }

            double distMetros = 0;

            for (int i = 0; i < coorHastaFinal.Count - 1; i++)
            {
                distMetros += DistanciaEntrePuntos(new PointLatLng(coorHastaFinal[i].Latitud, coorHastaFinal[i].Longitud),
                                                    new PointLatLng(coorHastaFinal[i + 1].Latitud, coorHastaFinal[i + 1].Longitud));
            }

            return distMetros;
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
