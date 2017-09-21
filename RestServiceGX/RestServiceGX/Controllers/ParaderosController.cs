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

using System.Device.Location;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

using RestServiceGX.Classes;

namespace RestServiceGX.Controllers
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
        private MicroSystemDBEntities db = new MicroSystemDBEntities();


        //Entregar usuarios que seleccionaron tal paradero
        //Obtener micros dirigiendose a tal paradero



        // POST: odata/Paraderos(5)/UsuariosQueSeleccionaron
        // nota: retorna en campo DistanciaEntre valor -1 si esque hay algun error de internet o más probablemente la ruta es imposible
        //regresa distancia en kilometros
        [HttpPost]
        public List<UsuarioParaderoDeluxe> UsuariosQueSeleccionaron([FromODataUri] int key)
        {
            Paradero paradero = db.Paradero.Where(p => p.Id == key).FirstOrDefault();

            if (paradero == null)
            {
                return new List<UsuarioParaderoDeluxe>();
            }

            List<UsuarioParadero> usuarioParaderos = paradero.UsuarioParadero.ToList();

            List<UsuarioParaderoDeluxe> upDeluxe = new List<UsuarioParaderoDeluxe>();

            Usuario user;

            foreach (UsuarioParadero usuarioParadero in usuarioParaderos)
            {
                //crear ruta por medio de gmap desde el usuario al paradero
                //sacar y asignar distancia
                //no es necesario registrar la ruta en si en ningun lado, solo distancia

                user = usuarioParadero.Usuario1;

                PointLatLng puntoInicio = new PointLatLng(user.Latitud, user.Longitud);
                PointLatLng puntoFinal = new PointLatLng(paradero.Latitud, paradero.Longitud);

                GMapRoute ruta = RutaCaminando(puntoInicio, puntoFinal);

                while (ruta == null)
                {
                    ruta = RutaCaminando(puntoInicio, puntoFinal);
                }

                double distancia = ruta.Distance;
                usuarioParadero.DistanciaEntre = distancia;

                upDeluxe.Add(new UsuarioParaderoDeluxe()
                { UsuarioId = user.Id, Latitud = user.Latitud, Longitud = user.Longitud, Distancia = distancia });

            }

            db.SaveChanges();

            return upDeluxe;
        }


        // POST: odata/Paraderos(5)/MicroParaderoMasCercano
        //regresa distancia en metros
        [HttpPost]
        public MicroParadero MicroParaderoMasCercano([FromODataUri] int key)
        {
            double distEntreParaderos = 0;

            Paradero paradero = db.Paradero.Where(p => p.Id == key).FirstOrDefault();

            if (paradero == null)
            {
                return new MicroParadero() { Id = -1 };
            }

            Ruta rutaIda = paradero.Ruta.Linea2.Ruta;
            Ruta rutaVuelta = paradero.Ruta.Linea2.Ruta1;
            List<Coordenada> coordenadasLinea = new List<Coordenada>();

            #region Rellenar coordenadasLinea
            List<Coordenada> coorIda = rutaIda.Coordenada.OrderBy(c => c.Orden).ToList();
            List<Coordenada> coorVuelta = rutaVuelta.Coordenada.OrderBy(c => c.Orden).ToList();

            for (int i = 0; i < coorIda.Count; i++)
            {
                coordenadasLinea.Add(coorIda[i]);
            }
            for (int i = 0; i < coorVuelta.Count; i++)
            {
                coordenadasLinea.Add(coorVuelta[i]);
            }
            #endregion

            List<MicroParadero> microParaderos = paradero.MicroParadero.ToList();
            Micro micro;

            //suma distancia entre paradero y el anterior
            //queda asignado como paradero el anterior
            //si el anterior tampoco tiene microparaderos se repite el proceso
            //retorna un microparadero con id -1 si no existen micros desde ese paradero al inicio

            while (microParaderos.Count == 0)
            {
                //buscar paradero anterior
                List<Paradero> paraderosRuta;
                Ruta rutaAUsar;

                if (paradero.Ruta.Id == rutaIda.Id)
                {
                    rutaAUsar = rutaIda;
                }
                else
                {
                    rutaAUsar = rutaVuelta;

                    if (paradero.Orden == 0)
                    {
                        //si entra aqui es que el paradero era el primero de la ruta de vuelta
                        //se suma la distancia desde ese paradero al ultimo paradero dela ruta de ida
                        //se asigna ese paradero como punto de inicio

                        distEntreParaderos +=
                            DistanciaVerticesSiguiendoRuta(coordenadasLinea, rutaVuelta.Coordenada.Where(c => c.Orden == 0).FirstOrDefault(), paradero.Coordenada);

                        paradero = rutaIda.Paradero.OrderBy(p => p.Orden).ToList().Last();
                        microParaderos = paradero.MicroParadero.ToList();

                        distEntreParaderos +=
                            DistanciaVerticesSiguiendoRuta(coordenadasLinea, paradero.Coordenada , rutaVuelta.Coordenada.Where(c => c.Orden == 0).FirstOrDefault());

                        continue;
                    }
                }

                paraderosRuta = rutaAUsar.Paradero.ToList().OrderBy(p => p.Orden).ToList();

                //busca paradero
                //suma distancia con paradero anterior
                //reasigna paradero y microparaderos con los datos del anterior

                Paradero paraderoAnterior = paraderosRuta.Where(p => p.Orden == paradero.Orden - 1).FirstOrDefault();

                if(paraderoAnterior != null)
                {
                    distEntreParaderos +=
                        DistanciaVerticesSiguiendoRuta(coordenadasLinea, paraderoAnterior.Coordenada, paradero.Coordenada);

                    paradero = paraderoAnterior;
                    microParaderos = paradero.MicroParadero.ToList();
                }
                else
                {
                    return new MicroParadero() { Id = -1 };
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

                Coordenada coorInicio = micro.Coordenada;
                Coordenada coorFinal = paradero.Coordenada;

                #region Rellenar coordenadas hasta el paradero
                bool comenzarRellenado = false;
                bool finalEncontrado = false;

                for (int i = 0; i < coordenadasLinea.Count; i++)
                {
                    Coordenada coorActual = coordenadasLinea[i];

                    if (coorActual.Id == coorInicio.Id)
                        comenzarRellenado = true;

                    if (comenzarRellenado == true && finalEncontrado == false)
                    {
                        coorHastaParadero.Add(coorActual);
                    }

                    if (comenzarRellenado == true && coorActual.Id == coorFinal.Id)
                        finalEncontrado = true;
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
                    if (distMetros < distMenor)
                    {
                        distMenor = distMetros;
                        mpMenor = microParadero;
                    }
                }
            }

            mpMenor.DistanciaEntre = distMenor + distEntreParaderos;

            if(mpMenor == null)
            {
                return new MicroParadero() { Id = -1 };
            }

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

        private double DistanciaVerticesSiguiendoRuta(List<Coordenada> _coorLinea , Coordenada coorInicio, Coordenada coorFinal)
        {
            List<Coordenada> coordenadasLinea = _coorLinea;
            List<Coordenada> coorHastaFinal = new List<Coordenada>();

            bool comenzarRellenado = false;
            bool finalEncontrado = false;

            for (int i = 0; i < coordenadasLinea.Count; i++)
            {
                Coordenada coorActual = coordenadasLinea[i];

                if (coorActual.Id == coorInicio.Id)
                    comenzarRellenado = true;

                if (comenzarRellenado == true && finalEncontrado == false)
                {
                    coorHastaFinal.Add(coorActual);
                }

                if (comenzarRellenado == true && coorActual.Id == coorFinal.Id)
                    finalEncontrado = true;
            }

            if (finalEncontrado == false)
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

        private GMapRoute RutaCaminando(PointLatLng inicio, PointLatLng final)
        {
            GDirections direccion;
            var rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, inicio, final, false, false, true, false, false);

            if (direccion == null)
            {
                //problemas de internet o ruta imposible
                return null;
            }

            GMapRoute ruta = new GMapRoute(direccion.Route, "rutaUserParadero");
            return ruta;
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