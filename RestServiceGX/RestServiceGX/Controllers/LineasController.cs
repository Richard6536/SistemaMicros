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


namespace RestServiceGX.Controllers
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
        private MicroSystemDBEntities db = new MicroSystemDBEntities();

        //POST: odata/Lineas/TestGmap
        [HttpPost]
        public int TestGmap()
        {
            PointLatLng p1 = new PointLatLng(-40.572542, -73.105419);
            PointLatLng p2 = new PointLatLng(-40.564914, -73.104175);

            GDirections direccion;
            var rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, p1, p2, false, false, true, false, false);

            if (direccion == null)
            {
                //problemas de internet o ruta imposible
                return -1;
            }

            GMapRoute ruta = new GMapRoute(direccion.Route, "rutaUserParadero");


            if (ruta == null)
            {
                return -2;
            }
            else
            {
                return 88;
            }
        }


        //POST: odata/Lineas(5)/ObtenerChoferes
        //Parametros:      
        [HttpPost]
        public List<Usuario> ObtenerChoferes([FromODataUri] int key)
        {
            Linea linea = db.Linea.Where(l => l.Id == key).FirstOrDefault();

            if (linea == null)
                return new List<Usuario>();

            List<Micro> microsLinea = linea.Micro.ToList();
            List<Usuario> choferesActivos = new List<Usuario>();

            for (int i = 0; i < microsLinea.Count; i++)
            {
                if (microsLinea[i].MicroChoferId != null)
                {
                    microsLinea[i].MicroChofer.Usuario.Id = microsLinea[i].Id;
                    choferesActivos.Add(microsLinea[i].MicroChofer.Usuario);
                }
            }

            return choferesActivos;
        }

        private TimeSpan TiempoEsperaMaxima = new TimeSpan(0, 3, 0);
        //POST: odata/Lineas/RecomendarRutaDX
        //Parametros: latInicio,lngInicio, latFinal,lngFinal
        [HttpPost]
        public List<Coordenada> RecomendarRutaDX(ODataActionParameters parameters)
        {
            DateTime horaInicio = DateTime.Now;
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
            GMapRoute rutaInicioMenor = null;
            Paradero pInicioMenor = null;
            GMapRoute rutaFinalMenor = null;
            Paradero pFinalMenor = null;

            //GMapRoute recomendacionCaminandoMenor = null;

            foreach (Linea linea in todasLineas)
            {
                paraderosLinea = obtenerParaderoLinea(linea);
                
                GMapRoute rutaInicioParaderoMenorIda = null;
                GMapRoute rutaInicioParaderoMenorVuelta = null;
                Paradero pInicioIda = null;
                Paradero pInicioVuelta = null;
                #region Busca el paradero más cercano en ambas rutas (junto con la ruta hasta ahí) a partir del punto de Inicio
                foreach (Paradero p in paraderosLinea)
                {
                    GMapRoute ruta = RutaCaminando(inicio, new PointLatLng(p.Latitud, p.Longitud));

                    while (ruta == null)
                    {
                        ruta = RutaCaminando(inicio, new PointLatLng(p.Latitud, p.Longitud));

                        if(DateTime.Now - horaInicio > TiempoEsperaMaxima)
                        {
                            return new List<Coordenada>();
                        }
                    }
                    if (p.Ruta.TipoDeRuta == 0)
                    {
                        //Se va buscando la ruta caminando mas cercana al paradero de ida
                        if (rutaInicioParaderoMenorIda == null)
                        {
                            rutaInicioParaderoMenorIda = ruta;
                            pInicioIda = p;
                        }
                        else if (ruta.Distance < rutaInicioParaderoMenorIda.Distance)
                        {
                            rutaInicioParaderoMenorIda = ruta;
                            pInicioIda = p;
                        }
                    }
                    else
                    {
                        //Se va buscando la ruta caminando mas cercana al paradero de vuelta
                        if (rutaInicioParaderoMenorVuelta == null)
                        {
                            rutaInicioParaderoMenorVuelta = ruta;
                            pInicioVuelta = p;
                        }
                        else if (ruta.Distance < rutaInicioParaderoMenorVuelta.Distance)
                        {
                            rutaInicioParaderoMenorVuelta = ruta;
                            pInicioVuelta = p;
                        }
                    }

                }


                #endregion
                //tambien buscar el paradero mas cercano en la ruta de ida y vuelta               

                GMapRoute rutaFinalParaderoMenorIda = null;
                GMapRoute rutaFinalParaderoMenorVuelta = null;
                Paradero pFinalIda = null;
                Paradero pFinalVuelta = null;
                #region Buscar el paradero más cercano en ambas rutas (junto a la ruta hasta ahi) a partir del punto final
                foreach (Paradero p in paraderosLinea)
                {
                    GMapRoute ruta = RutaCaminando(final, new PointLatLng(p.Latitud, p.Longitud));
                    while (ruta == null)
                    {
                        ruta = RutaCaminando(final, new PointLatLng(p.Latitud, p.Longitud));

                        if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                        {
                            return new List<Coordenada>();
                        }
                    }

                    if (p.Ruta.TipoDeRuta == 0)
                    {//Se va buscando la ruta caminando mas cercana al paradero de ida

                        if (rutaFinalParaderoMenorIda == null)
                        {
                            rutaFinalParaderoMenorIda = ruta;
                            pFinalIda = p;
                        }
                        else if (ruta.Distance < rutaFinalParaderoMenorIda.Distance)
                        {
                            rutaFinalParaderoMenorIda = ruta;
                            pFinalIda = p;
                        }
                    }
                    else
                    {//Se va buscando la ruta caminando mas cercana al paradero de vuelta

                        if (rutaFinalParaderoMenorVuelta == null)
                        {
                            rutaFinalParaderoMenorVuelta = ruta;
                            pFinalVuelta = p;
                        }
                        else if (ruta.Distance < rutaFinalParaderoMenorVuelta.Distance)
                        {
                            rutaFinalParaderoMenorVuelta = ruta;
                            pFinalVuelta = p;
                        }
                    }

                }
                #endregion

                if((pInicioIda.Id == pFinalIda.Id) && (pInicioVuelta.Id == pFinalVuelta.Id))
                {
                    continue;
                }
                else
                {
                    double posibleDistMenor = double.MaxValue;
                    Paradero inicioSeleccionado = null;
                    GMapRoute rutaInicioSeleccionado = null;
                    Paradero finalSeleccionado = null;
                    GMapRoute rutaFinalSeleccionado = null;

                    Coordenada coorInicioIda = CoordenadaAsociadaAParadero(pInicioIda);
                    Coordenada coorInicioVuelta = CoordenadaAsociadaAParadero(pInicioVuelta);
                    Coordenada coorFinalIda = CoordenadaAsociadaAParadero(pFinalIda);
                    Coordenada coorFinalVuelta = CoordenadaAsociadaAParadero(pFinalVuelta);

                    bool ambosIda = false;
                    bool ambosVuelta = false;

                    if (coorInicioIda.Id > coorFinalIda.Id)
                        ambosIda = true;
                    if (coorInicioVuelta.Id > coorFinalVuelta.Id)
                        ambosVuelta = true;


                    posibleDistMenor = rutaInicioParaderoMenorIda.Distance + rutaFinalParaderoMenorVuelta.Distance;
                    inicioSeleccionado = pInicioIda;
                    rutaInicioSeleccionado = rutaInicioParaderoMenorIda;
                    finalSeleccionado = pFinalVuelta;
                    rutaFinalSeleccionado = rutaFinalParaderoMenorVuelta;

                    if (ambosIda)
                    {
                        double dist = rutaInicioParaderoMenorIda.Distance + rutaFinalParaderoMenorIda.Distance;
                        if(dist < posibleDistMenor)
                        {
                            posibleDistMenor = dist;
                            inicioSeleccionado = pInicioIda;
                            rutaInicioSeleccionado = rutaInicioParaderoMenorIda;
                            finalSeleccionado = pFinalIda;
                            rutaFinalSeleccionado = rutaFinalParaderoMenorIda;
                        }
                    }
                    if(ambosVuelta)
                    {
                        double dist = rutaInicioParaderoMenorVuelta.Distance + rutaFinalParaderoMenorVuelta.Distance;
                        if(dist <posibleDistMenor)
                        {
                            posibleDistMenor = dist;
                            inicioSeleccionado = pInicioVuelta;
                            rutaInicioSeleccionado = rutaInicioParaderoMenorVuelta;
                            finalSeleccionado = pFinalVuelta;
                            rutaFinalSeleccionado = rutaFinalParaderoMenorVuelta;
                        }
                    }

                    //si distancia posible menor que distancia menor 

                    if(posibleDistMenor < distanciaMenor)
                    {
                        distanciaMenor = posibleDistMenor;
                        lineaMenor = linea;

                        rutaInicioMenor = rutaInicioSeleccionado;
                        pInicioMenor = inicioSeleccionado;
                        rutaFinalMenor = rutaFinalSeleccionado;
                        pFinalMenor = finalSeleccionado;
                    }
                }
            }

            //SACAR AQUI LA RUTA CAMINANDO ENTRE PUNTOS Y COMPARARLO CON LA RECOMENDACION MENOR

            GMapRoute rutaCaminandoDirecto = RutaCaminando(inicio, final);
            #region Sacar la ruta caminando para comparar si conviene o no usarla
            while (rutaCaminandoDirecto == null)
            {
                rutaCaminandoDirecto = RutaCaminando(inicio, final);

                if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                {
                    return new List<Coordenada>();
                }
            }
            #endregion

            if (lineaMenor != null)
            {
                if (rutaCaminandoDirecto.Distance < (rutaInicioMenor.Distance + rutaFinalMenor.Distance))
                {
                    //caminar del punto inicial al final es menor distancia que
                    //caminar hasta el paradero inicial y caminar del paradero al punto final

                    lineaMenor = null;
                }
                else
                {
                    rutaCaminandoDirecto = null;
                }
            }

            if (lineaMenor != null)
            {
                List<Coordenada> coordenadasRecomendacion = new List<Coordenada>();

                List<Coordenada> verticesEntreParaderos = CoordenadasSiguiendoLaRuta(pInicioMenor, pFinalMenor);
                #region Rellenar las coor recomendadas con las 3 rutas hechas
                List<PointLatLng> puntosInicio = rutaInicioMenor.Points;
                List<PointLatLng> puntosFinal = rutaFinalMenor.Points;

                for (int i = 0; i < puntosInicio.Count; i++)
                {
                    PointLatLng punto = puntosInicio[i];
                    Coordenada c = new Coordenada() { Id = lineaMenor.Id, Latitud = punto.Lat, Longitud = punto.Lng };

                    coordenadasRecomendacion.Add(c);
                }

                for (int i = 0; i < verticesEntreParaderos.Count; i++)
                {
                    verticesEntreParaderos[i].Id = lineaMenor.Id;
                    coordenadasRecomendacion.Add(verticesEntreParaderos[i]);
                }

                for (int i = puntosFinal.Count - 1; i >= 0; i--)
                {
                    PointLatLng punto = puntosFinal[i];
                    Coordenada c = new Coordenada() { Id = lineaMenor.Id, Latitud = punto.Lat, Longitud = punto.Lng };

                    coordenadasRecomendacion.Add(c);
                }
                #endregion

                return coordenadasRecomendacion;
            }
            else if(rutaCaminandoDirecto != null)
            {
                List<Coordenada> coordenadasRecomendacion = new List<Coordenada>();
                for (int i = 0; i < rutaCaminandoDirecto.Points.Count; i++)
                {
                    PointLatLng punto = rutaCaminandoDirecto.Points[i];
                    Coordenada c = new Coordenada() { Id = -1, Latitud = punto.Lat, Longitud = punto.Lng };

                    coordenadasRecomendacion.Add(c);
                }
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
            var sCoord = new GeoCoordinate(punto1.Lat, punto1.Lng);
            var eCoord = new GeoCoordinate(punto2.Lat, punto2.Lng);

            return sCoord.GetDistanceTo(eCoord);
        }

        private List<Paradero> obtenerParaderoLinea(Linea _linea)
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

            if (direccion == null)
            {
                //problemas de internet o ruta imposible
                return null;
            }

            GMapRoute ruta = new GMapRoute(direccion.Route, "rutaUserParadero");
            return ruta;
        }

        private GMapRoute RutaCaminandoV2(PointLatLng inicio, PointLatLng final)
        {
            List<PointLatLng> puntos = new List<PointLatLng>();
            puntos.Add(inicio);
            puntos.Add(final);

            GMapRoute ruta = new GMapRoute(puntos,"rutadirecta");

            return ruta;
        }

        private List<Coordenada> CoordenadasSiguiendoLaRuta(Paradero _pInicial, Paradero _pFinal)
        {
            List<Coordenada> allCoord = db.Coordenada.ToList();
            Coordenada coorInicio = null;
            Coordenada coorFinal = null;

            #region encontrar coordenada inicial y final
            foreach (Coordenada coor in allCoord)
            {
                GeoCoordinate coorPos = new GeoCoordinate(coor.Latitud, coor.Longitud);

                GeoCoordinate geoInicio = new GeoCoordinate(_pInicial.Latitud, _pInicial.Longitud);
                GeoCoordinate geoFinal = new GeoCoordinate(_pFinal.Latitud, _pFinal.Longitud);

                if(coorInicio == null && coorPos.GetDistanceTo(geoInicio) < 4)
                {
                    coorInicio = coor;
                }
                if(coorFinal == null && coorPos.GetDistanceTo(geoFinal) < 4)
                {
                    coorFinal = coor;
                }

                if(coorInicio != null && coorFinal != null)
                {
                    break;
                }

            }
            #endregion

            List<Coordenada> coorHastaFinal = new List<Coordenada>();

            #region Rellenar lista de coordenadas
            coorHastaFinal.Add(coorInicio);

            Coordenada sigCoor = coorInicio.Coordenada2;
            bool encontrado = false;
            while (sigCoor != null)
            {
                coorHastaFinal.Add(sigCoor);

                if (sigCoor.Latitud == coorFinal.Latitud && sigCoor.Longitud == coorFinal.Longitud)
                {
                    encontrado = true;
                    break;
                }
                sigCoor = sigCoor.Coordenada2;
            }

            //si elparadero final esta en la ruta de vuelta repite el proceso desde el principio de la otra ruta
            //tambien paradero inicial debe estar en ruta de ida para entrar
            if ( _pInicial.Ruta.TipoDeRuta == 0 && _pFinal.Ruta.TipoDeRuta == 1 && encontrado == false)
            {
                Ruta rutaVuelta = _pFinal.Ruta;
                sigCoor = rutaVuelta.Coordenada;

                while (sigCoor != null)
                {
                    coorHastaFinal.Add(sigCoor);

                    if (sigCoor.Latitud == coorFinal.Latitud && sigCoor.Longitud == coorFinal.Longitud)
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

        private Coordenada CoordenadaAsociadaAParadero(Paradero _paradero)
        {
            List<Coordenada> allCoord = db.Coordenada.ToList();
            GeoCoordinate posParadero = new GeoCoordinate(_paradero.Latitud, _paradero.Longitud);
            Coordenada coorEncontrado = null;

            foreach (Coordenada coor in allCoord)
            {
                GeoCoordinate coorPos = new GeoCoordinate(coor.Latitud, coor.Longitud);

                if (coorEncontrado == null && coorPos.GetDistanceTo(posParadero) < 3)
                {
                    coorEncontrado = coor;
                }
            }

            return coorEncontrado;
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