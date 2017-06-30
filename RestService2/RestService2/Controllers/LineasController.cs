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
    builder.EntitySet<Linea>("Lineas");
    builder.EntitySet<Ruta>("Ruta"); 
    builder.EntitySet<Micro>("Micro"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class LineasController : ODataController
    {
        private MicroSystemDBEntities10 db = new MicroSystemDBEntities10();

        //POST: odata/Lineas(5)/ObtenerChoferesActivos
        //Parametros: 
        [HttpPost]
        public List<Usuario> ObtenerChoferes([FromODataUri] int key)
        {
            Linea linea = db.Linea.Where(l => l.Id == key).FirstOrDefault();
            List<Micro> microsLinea = linea.Micro.ToList();
            List<Usuario> choferesActivos = new List<Usuario>();

            for (int i = 0; i < microsLinea.Count; i++)
            {
                if(microsLinea[i].MicroChoferId != null)
                {
                    microsLinea[i].MicroChofer.Usuario.Id = microsLinea[i].Id;
                    choferesActivos.Add(microsLinea[i].MicroChofer.Usuario);
                }
            }

            return choferesActivos;         
        }

        //POST: odata/Lineas/RecomendarRutaDX
        //Parametros: latInicio,lngInicio, latFinal,lngFinal
        [HttpPost]
        public List<Coordenada> RecomendarRutaDX(ODataActionParameters parameters)
        {
            List<Coordenada> vertices = new List<Coordenada>();

            if (parameters == null)
                return vertices;

            double latInicio = (double)parameters["latInicio"];
            double lngInicio = (double)parameters["lngInicio"];
            double latFinal = (double)parameters["latFinal"];
            double lngFinal = (double)parameters["lngFinal"];

            PointLatLng inicio = new PointLatLng(latInicio, lngInicio);
            PointLatLng final = new PointLatLng(latFinal, lngFinal);

            List<Linea> todasLineas = db.Linea.ToList();
            List<Paradero> paraderosLinea;

            double distanciaMenor = double.MaxValue;

            Linea lineaMenor = null;
            List<Coordenada> coordenadasMenor = null;
            GMapRoute rutaInicioMenor = null;
            GMapRoute rutaFinalMenor = null;

            bool pFinalEnRutaVuelta = false;

            foreach(Linea linea in todasLineas)
            {
                paraderosLinea = obtenerParaderoLinea(linea);
                int contador;
                #region Busca el paradero más cercano (junto con la ruta hasta ahí) a partir del punto de Inicio
                GMapRoute rutaInicioParaderoMenor = null;
                Paradero pInicio = null;
                foreach(Paradero p in paraderosLinea)
                {
                    GMapRoute ruta = RutaCaminando(inicio, new PointLatLng(p.Latitud, p.Longitud));
                    contador = 0;
                    while(ruta == null && contador < 15)
                    {
                        ruta = RutaCaminando(inicio, new PointLatLng(p.Latitud, p.Longitud));
                        contador++;
                    }

                    if (ruta != null)
                    {
                        if (rutaInicioParaderoMenor == null)
                        {
                            rutaInicioParaderoMenor = ruta;
                            pInicio = p;
                        }
                        else if (ruta.Distance < rutaInicioParaderoMenor.Distance)
                        {
                            rutaInicioParaderoMenor = ruta;
                            pInicio = p;
                        }
                    }
                }
                #endregion

                #region Buscar el paradero más cercano (junto a la ruta hasta ahi) a partir del punto final
                GMapRoute rutaFinalParaderoMenor = null;
                Paradero pFinal = null;
                foreach(Paradero p in paraderosLinea)
                {
                    GMapRoute ruta = RutaCaminando(final, new PointLatLng(p.Latitud, p.Longitud));
                    contador = 0;
                    while(ruta == null && contador < 15)
                    {
                        RutaCaminando(final, new PointLatLng(p.Latitud, p.Longitud));
                        contador++;
                    }

                    if (ruta != null)
                    {
                        if (rutaFinalParaderoMenor == null)
                        {
                            rutaFinalParaderoMenor = ruta;
                            pFinal = p;
                        }
                        else if (ruta.Distance < rutaFinalParaderoMenor.Distance)
                        {
                            rutaFinalParaderoMenor = ruta;
                            pFinal = p;
                        }
                    }
                }

                if(pFinal != null)
                {
                    if(pFinal.Ruta == pFinal.Ruta.Linea2.Ruta1) //si es la ruta una ruta de vuelta
                    {
                        pFinalEnRutaVuelta = true;
                    }
                }
                #endregion

                List<Coordenada> coorEntreParaderos = CoordenadasSiguiendoLaRuta(pInicio.Latitud, pInicio.Longitud, pFinal.Latitud, pFinal.Longitud, pFinalEnRutaVuelta, pFinal);
                
                if(coorEntreParaderos != null)
                {
                    double distancia = DistanciaCoordenadas(coorEntreParaderos); //distancia del paradero de inicio al final
                    double distInicioParadero = rutaInicioParaderoMenor.Distance; //distancia desde punto inicio al paradero inicio
                    double distFinalParadero = rutaFinalParaderoMenor.Distance; //distancia desde punto final al paradero final

                    double distTotal = distancia + distInicioParadero + distFinalParadero;

                    if(distTotal < distanciaMenor)
                    {
                        distanciaMenor = distTotal;

                        lineaMenor = linea;
                        coordenadasMenor = coorEntreParaderos;
                        rutaInicioMenor = rutaInicioParaderoMenor;
                        rutaFinalMenor = rutaFinalParaderoMenor;
                    }
                }

            }
            
            if(lineaMenor != null)
            {
                List<Coordenada> coordenadasRecomendacion = new List<Coordenada>();

                #region Rellenar las coor recomendadas con las 3 rutas hechas
                List<PointLatLng> puntosInicio = rutaInicioMenor.Points;
                List<PointLatLng> puntosFinal = rutaFinalMenor.Points;

                for (int i = 0; i < puntosInicio.Count; i++)
                {
                    PointLatLng punto = puntosInicio[i];
                    Coordenada c = new Coordenada() { Id = lineaMenor.Id, Latitud = punto.Lat, Longitud = punto.Lng };

                    coordenadasRecomendacion.Add(c);
                }

                for (int i = 0; i < coordenadasMenor.Count; i++)
                {
                    coordenadasMenor[i].Id = lineaMenor.Id;
                    coordenadasRecomendacion.Add(coordenadasMenor[i]);
                }

                for (int i = puntosFinal.Count - 1; i >= 0 ; i--)
                {
                    PointLatLng punto = puntosFinal[i];
                    Coordenada c = new Coordenada() { Id = lineaMenor.Id, Latitud = punto.Lat, Longitud = punto.Lng };

                    coordenadasRecomendacion.Add(c);
                }
                #endregion

                return coordenadasRecomendacion;
            }
            else
            {
                return new List<Coordenada>();
            }
            
        }

        #region Originales
        // GET: odata/Lineas
        [EnableQuery]
        public IQueryable<Linea> GetLineas()
        {
            return db.Linea;
        }

        // GET: odata/Lineas(5)
        [EnableQuery]
        public SingleResult<Linea> GetLinea([FromODataUri] int key)
        {
            return SingleResult.Create(db.Linea.Where(linea => linea.Id == key));
        }

        // PUT: odata/Lineas(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Linea> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Linea linea = db.Linea.Find(key);
            if (linea == null)
            {
                return NotFound();
            }

            patch.Put(linea);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(linea);
        }

        // POST: odata/Lineas
        public IHttpActionResult Post(Linea linea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Linea.Add(linea);
            db.SaveChanges();

            return Created(linea);
        }

        // PATCH: odata/Lineas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Linea> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Linea linea = db.Linea.Find(key);
            if (linea == null)
            {
                return NotFound();
            }

            patch.Patch(linea);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(linea);
        }

        // DELETE: odata/Lineas(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Linea linea = db.Linea.Find(key);
            if (linea == null)
            {
                return NotFound();
            }

            db.Linea.Remove(linea);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        //Ruta de ida
        // GET: odata/Lineas(5)/Ruta
        [EnableQuery]
        public SingleResult<Ruta> GetRuta([FromODataUri] int key)
        {
            return SingleResult.Create(db.Linea.Where(m => m.Id == key).Select(m => m.Ruta));
        }

        //Ruta de vuelta
        // GET: odata/Lineas(5)/Ruta1
        [EnableQuery]
        public SingleResult<Ruta> GetRuta1([FromODataUri] int key)
        {
            return SingleResult.Create(db.Linea.Where(m => m.Id == key).Select(m => m.Ruta1));
        }

        //Todas las rutas de esta linea
        // GET: odata/Lineas(5)/Ruta2
        [EnableQuery]
        public IQueryable<Ruta> GetRuta2([FromODataUri] int key)
        {
            return db.Linea.Where(m => m.Id == key).SelectMany(m => m.Ruta2);
        }

        //Todas las micros de esta linea
        // GET: odata/Lineas(5)/Micro
        [EnableQuery]
        public IQueryable<Micro> GetMicro([FromODataUri] int key)
        {
            return db.Linea.Where(m => m.Id == key).SelectMany(m => m.Micro);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineaExists(int key)
        {
            return db.Linea.Count(e => e.Id == key) > 0;
        }
        #endregion

        #region Metodos Extra
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

        private List<Paradero> obtenerParaderoLinea(Linea _linea )
        {
            List<Paradero> paraderosIda = _linea.Ruta.Paradero.OrderBy(p => p.Id).ToList();
            List<Paradero> paraderosVuelta = _linea.Ruta1.Paradero.OrderBy(p => p.Id).ToList();

            List<Paradero> paraderosLinea = paraderosIda;

            for (int i = 0; i < paraderosVuelta.Count; i++)
            {
                paraderosLinea.Add(paraderosVuelta[i]);
            }

            return paraderosLinea;
        }

        private GMapRoute RutaCaminando(PointLatLng inicio, PointLatLng final)
        {
            GDirections direccion;
            var rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, inicio, final, false, false, true, false, false);

            double distancia;
            if (direccion == null)
            {
                //problemas de internet o ruta imposible
                return null;
            }

            GMapRoute ruta = new GMapRoute(direccion.Route, "rutaUserParadero");
            return ruta;
        }

        private List<Coordenada> CoordenadasSiguiendoLaRuta(double latInicio, double lngInicio, double latFinal, double lngFinal, bool _finalEnRutaVuelta, Paradero _pFinal)
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

            //si elparadero final esta en la ruta de vuelta repite el proceso desde el principio de la otra ruta
            if(_finalEnRutaVuelta)
            {
                Ruta rutaVuelta = _pFinal.Ruta;
                sigCoor = rutaVuelta.Coordenada;

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
            }

            #endregion

            if (encontrado == false)
            {
                //No se puede llegar al punto final siguiendo la ruta
                return null;
            }

            return coorHastaFinal;

        }

        private double DistanciaCoordenadas(List<Coordenada> _coor)
        {
            double distMetros = 0;

            for (int i = 0; i < _coor.Count - 1; i++)
            {
                distMetros += DistanciaEntrePuntos(new PointLatLng(_coor[i].Latitud, _coor[i].Longitud),
                                                    new PointLatLng(_coor[i + 1].Latitud, _coor[i + 1].Longitud));
            }

            return distMetros;
        }

        #endregion
    }
}
