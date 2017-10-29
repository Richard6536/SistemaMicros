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

        private TimeSpan TiempoEsperaMaxima = new TimeSpan(0, 0, 15);
        //POST: odata/Lineas/RecomendarRutaDX
        //Parametros: latInicio,lngInicio, latFinal,lngFinal, BusquedaDetallada
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
            bool busquedaDetallada = (bool)parameters["BusquedaDetallada"];

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

            //por cada linea buscar paraderos mas cercanos a punto inicial y final
            //se decide linea en la que se camina menos y las rutas de puntoInicio y final a sus respectivos paraderos
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
                    GMapRoute ruta = RutaCaminandoV2(inicio, new PointLatLng(p.Latitud, p.Longitud), false);

                    while (ruta == null)
                    {
                        ruta = RutaCaminandoV2(inicio, new PointLatLng(p.Latitud, p.Longitud), false);

                        if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
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
                    GMapRoute ruta = RutaCaminandoV2(final, new PointLatLng(p.Latitud, p.Longitud), false);
                    while (ruta == null)
                    {
                        ruta = RutaCaminandoV2(final, new PointLatLng(p.Latitud, p.Longitud), false);

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

                if ((pInicioIda.Id == pFinalIda.Id) && (pInicioVuelta.Id == pFinalVuelta.Id))
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

                    Coordenada coorInicioIda = pInicioIda.Coordenada;
                    Coordenada coorInicioVuelta = pInicioVuelta.Coordenada;
                    Coordenada coorFinalIda = pFinalIda.Coordenada;
                    Coordenada coorFinalVuelta = pFinalVuelta.Coordenada;

                    bool ambosIda = false;
                    bool ambosVuelta = false;

                    if (coorInicioIda.Orden < coorFinalIda.Orden)
                        ambosIda = true;
                    if (coorInicioVuelta.Orden < coorFinalVuelta.Orden)
                        ambosVuelta = true;


                    posibleDistMenor = rutaInicioParaderoMenorIda.Distance + rutaFinalParaderoMenorVuelta.Distance;
                    inicioSeleccionado = pInicioIda;
                    rutaInicioSeleccionado = rutaInicioParaderoMenorIda;
                    finalSeleccionado = pFinalVuelta;
                    rutaFinalSeleccionado = rutaFinalParaderoMenorVuelta;

                    if (ambosIda)
                    {
                        double dist = rutaInicioParaderoMenorIda.Distance + rutaFinalParaderoMenorIda.Distance;
                        if (dist < posibleDistMenor)
                        {
                            posibleDistMenor = dist;
                            inicioSeleccionado = pInicioIda;
                            rutaInicioSeleccionado = rutaInicioParaderoMenorIda;
                            finalSeleccionado = pFinalIda;
                            rutaFinalSeleccionado = rutaFinalParaderoMenorIda;
                        }
                    }
                    if (ambosVuelta)
                    {
                        double dist = rutaInicioParaderoMenorVuelta.Distance + rutaFinalParaderoMenorVuelta.Distance;
                        if (dist < posibleDistMenor)
                        {
                            posibleDistMenor = dist;
                            inicioSeleccionado = pInicioVuelta;
                            rutaInicioSeleccionado = rutaInicioParaderoMenorVuelta;
                            finalSeleccionado = pFinalVuelta;
                            rutaFinalSeleccionado = rutaFinalParaderoMenorVuelta;
                        }
                    }

                    //si distancia posible menor que distancia menor 

                    if (posibleDistMenor < distanciaMenor)
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

            GMapRoute rutaCaminandoDirecto = RutaCaminandoV2(inicio, final, true);
            #region Sacar la ruta caminando para comparar si conviene o no usarla
            while (rutaCaminandoDirecto == null)
            {
                rutaCaminandoDirecto = RutaCaminandoV2(inicio, final, true);

                if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                {
                    return new List<Coordenada>();
                }
            }
            #endregion

            //Se revisan los paraderos adyacentes para confirmar el mas cercano en detalle
            //luego decidir si usar ruta caminando o micro

            List<Coordenada> coordenadasSiguiendoRuta = null;
            if (busquedaDetallada && lineaMenor != null)
            {
                ObtenerParaderoAdyacenteMasCercano(inicio, pInicioMenor, horaInicio, out pInicioMenor, out rutaInicioMenor);
                if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                    return new List<Coordenada>();
                ObtenerParaderoAdyacenteMasCercano(final, pFinalMenor, horaInicio, out pFinalMenor, out rutaFinalMenor);
                if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                    return new List<Coordenada>();

                coordenadasSiguiendoRuta = CoordenadasSiguiendoLaRuta(lineaMenor, pInicioMenor, pFinalMenor);
                if (coordenadasSiguiendoRuta == null)
                {
                    lineaMenor = null;
                }
            }

            if (lineaMenor != null)
            {
                if (rutaCaminandoDirecto.Distance < (rutaInicioMenor.Distance + rutaFinalMenor.Distance))
                    lineaMenor = null;
                else
                    rutaCaminandoDirecto = null;
            }

            //Se usa ruta por micro
            if (lineaMenor != null)
            {
                List<Coordenada> coordenadasRecomendacion = new List<Coordenada>();

                if(coordenadasSiguiendoRuta == null)
                    coordenadasSiguiendoRuta = CoordenadasSiguiendoLaRuta(lineaMenor, pInicioMenor, pFinalMenor);

                #region Si se usó el metodo de ruta directa caminando, hay que recrear la ruta correcta tomando en cuenta las calles
                if (rutaInicioMenor.Points.Count == 2)
                {
                    //entre punto inicio y paraderoInicio
                    rutaInicioMenor = RutaCaminandoV2(inicio, new PointLatLng(pInicioMenor.Latitud, pInicioMenor.Longitud), true);

                    while (rutaInicioMenor == null)
                    {
                        rutaInicioMenor = RutaCaminandoV2(inicio, new PointLatLng(pInicioMenor.Latitud, pInicioMenor.Longitud), true);

                        if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                        {
                            return new List<Coordenada>();
                        }
                    }
                }

                if (rutaFinalMenor.Points.Count == 2)
                {
                    //entre punto final y paraderoFinal
                    rutaFinalMenor = RutaCaminandoV2(final, new PointLatLng(pFinalMenor.Latitud, pFinalMenor.Longitud), true);
                    while (rutaFinalMenor == null)
                    {
                        rutaFinalMenor = RutaCaminandoV2(final, new PointLatLng(pFinalMenor.Latitud, pFinalMenor.Longitud), true);
                        if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                        {
                            return new List<Coordenada>();
                        }
                    }
                        
                }
                #endregion

                #region Rellenar las coor recomendadas con las 3 rutas hechas
                List<PointLatLng> puntosInicio = rutaInicioMenor.Points;
                List<PointLatLng> puntosFinal = rutaFinalMenor.Points;

                for (int i = 0; i < puntosInicio.Count; i++)
                {
                    PointLatLng punto = puntosInicio[i];
                    Coordenada c = new Coordenada() { Id = lineaMenor.Id, Latitud = punto.Lat, Longitud = punto.Lng };

                    coordenadasRecomendacion.Add(c);
                }

                for (int i = 0; i < coordenadasSiguiendoRuta.Count; i++)
                {
                    coordenadasSiguiendoRuta[i].Id = lineaMenor.Id;
                    coordenadasRecomendacion.Add(coordenadasSiguiendoRuta[i]);
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
            //Se recomienda caminar
            else if (rutaCaminandoDirecto != null)
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


        //POST: odata/Lineas/RecomendarRutaDetalle
        //Parametros: latInicio,lngInicio, latFinal,lngFinal, BusquedaDetallada
        [HttpPost]
        public LineaRecomendada RecomendarRutaDetalle(ODataActionParameters parameters)
        {
            DateTime horaInicio = DateTime.Now;
            List<Coordenada> vertices = new List<Coordenada>();

            if (parameters == null)
                return new LineaRecomendada();

            double latInicio = (double)parameters["latInicio"];
            double lngInicio = (double)parameters["lngInicio"];
            double latFinal = (double)parameters["latFinal"];
            double lngFinal = (double)parameters["lngFinal"];
            bool busquedaDetallada = (bool)parameters["BusquedaDetallada"];

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

            //por cada linea buscar paraderos mas cercanos a punto inicial y final
            //se decide linea en la que se camina menos y las rutas de puntoInicio y final a sus respectivos paraderos
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
                    GMapRoute ruta = RutaCaminandoV2(inicio, new PointLatLng(p.Latitud, p.Longitud), false);

                    while (ruta == null)
                    {
                        ruta = RutaCaminandoV2(inicio, new PointLatLng(p.Latitud, p.Longitud), false);

                        if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                        {
                            return new LineaRecomendada();
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
                    GMapRoute ruta = RutaCaminandoV2(final, new PointLatLng(p.Latitud, p.Longitud), false);
                    while (ruta == null)
                    {
                        ruta = RutaCaminandoV2(final, new PointLatLng(p.Latitud, p.Longitud), false);

                        if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                        {
                            return new LineaRecomendada();
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

                if ((pInicioIda.Id == pFinalIda.Id) && (pInicioVuelta.Id == pFinalVuelta.Id))
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

                    Coordenada coorInicioIda = pInicioIda.Coordenada;
                    Coordenada coorInicioVuelta = pInicioVuelta.Coordenada;
                    Coordenada coorFinalIda = pFinalIda.Coordenada;
                    Coordenada coorFinalVuelta = pFinalVuelta.Coordenada;

                    bool ambosIda = false;
                    bool ambosVuelta = false;

                    if (coorInicioIda.Orden < coorFinalIda.Orden)
                        ambosIda = true;
                    if (coorInicioVuelta.Orden < coorFinalVuelta.Orden)
                        ambosVuelta = true;


                    posibleDistMenor = rutaInicioParaderoMenorIda.Distance + rutaFinalParaderoMenorVuelta.Distance;
                    inicioSeleccionado = pInicioIda;
                    rutaInicioSeleccionado = rutaInicioParaderoMenorIda;
                    finalSeleccionado = pFinalVuelta;
                    rutaFinalSeleccionado = rutaFinalParaderoMenorVuelta;

                    if (ambosIda)
                    {
                        double dist = rutaInicioParaderoMenorIda.Distance + rutaFinalParaderoMenorIda.Distance;
                        if (dist < posibleDistMenor)
                        {
                            posibleDistMenor = dist;
                            inicioSeleccionado = pInicioIda;
                            rutaInicioSeleccionado = rutaInicioParaderoMenorIda;
                            finalSeleccionado = pFinalIda;
                            rutaFinalSeleccionado = rutaFinalParaderoMenorIda;
                        }
                    }
                    if (ambosVuelta)
                    {
                        double dist = rutaInicioParaderoMenorVuelta.Distance + rutaFinalParaderoMenorVuelta.Distance;
                        if (dist < posibleDistMenor)
                        {
                            posibleDistMenor = dist;
                            inicioSeleccionado = pInicioVuelta;
                            rutaInicioSeleccionado = rutaInicioParaderoMenorVuelta;
                            finalSeleccionado = pFinalVuelta;
                            rutaFinalSeleccionado = rutaFinalParaderoMenorVuelta;
                        }
                    }

                    //si distancia posible menor que distancia menor 

                    if (posibleDistMenor < distanciaMenor)
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

            GMapRoute rutaCaminandoDirecto = RutaCaminandoV2(inicio, final, true);
            #region Sacar la ruta caminando para comparar si conviene o no usarla
            while (rutaCaminandoDirecto == null)
            {
                rutaCaminandoDirecto = RutaCaminandoV2(inicio, final, true);

                if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                {
                    return new LineaRecomendada();
                }
            }
            #endregion

            //Se revisan los paraderos adyacentes para confirmar el mas cercano en detalle
            //luego decidir si usar ruta caminando o micro

            List<Coordenada> coordenadasSiguiendoRuta = null;
            if (busquedaDetallada && lineaMenor != null)
            {
                ObtenerParaderoAdyacenteMasCercano(inicio, pInicioMenor, horaInicio, out pInicioMenor, out rutaInicioMenor);
                if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                    return new LineaRecomendada();
                ObtenerParaderoAdyacenteMasCercano(final, pFinalMenor, horaInicio, out pFinalMenor, out rutaFinalMenor);
                if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                    return new LineaRecomendada();

                coordenadasSiguiendoRuta = CoordenadasSiguiendoLaRuta(lineaMenor, pInicioMenor, pFinalMenor);
                if (coordenadasSiguiendoRuta == null)
                {
                    lineaMenor = null;
                }
            }

            if (lineaMenor != null)
            {
                if (rutaCaminandoDirecto.Distance < (rutaInicioMenor.Distance + rutaFinalMenor.Distance))
                    lineaMenor = null;
                else
                    rutaCaminandoDirecto = null;
            }

            //Se usa ruta por micro
            if (lineaMenor != null)
            {
                if (coordenadasSiguiendoRuta == null)
                    coordenadasSiguiendoRuta = CoordenadasSiguiendoLaRuta(lineaMenor, pInicioMenor, pFinalMenor);

                #region Si se usó el metodo de ruta directa caminando, hay que recrear la ruta correcta tomando en cuenta las calles
                if (rutaInicioMenor.Points.Count == 2)
                {
                    //entre punto inicio y paraderoInicio
                    rutaInicioMenor = RutaCaminandoV2(inicio, new PointLatLng(pInicioMenor.Latitud, pInicioMenor.Longitud), true);

                    while (rutaInicioMenor == null)
                    {
                        rutaInicioMenor = RutaCaminandoV2(inicio, new PointLatLng(pInicioMenor.Latitud, pInicioMenor.Longitud), true);

                        if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                        {
                            return new LineaRecomendada();
                        }
                    }
                }

                if (rutaFinalMenor.Points.Count == 2)
                {
                    //entre punto final y paraderoFinal
                    rutaFinalMenor = RutaCaminandoV2(final, new PointLatLng(pFinalMenor.Latitud, pFinalMenor.Longitud), true);
                    while (rutaFinalMenor == null)
                    {
                        rutaFinalMenor = RutaCaminandoV2(final, new PointLatLng(pFinalMenor.Latitud, pFinalMenor.Longitud), true);
                        if (DateTime.Now - horaInicio > TiempoEsperaMaxima)
                        {
                            return new LineaRecomendada();
                        }
                    }

                }
                #endregion

                List<PointLatLng> puntosInicio = rutaInicioMenor.Points;
                List<PointLatLng> puntosFinal = rutaFinalMenor.Points;

                return new LineaRecomendada(lineaMenor.Id, pInicioMenor.Id,pFinalMenor.Id, puntosInicio, puntosFinal, coordenadasSiguiendoRuta);
            }
            //Se recomienda caminar
            else if (rutaCaminandoDirecto != null)
            {
                return new LineaRecomendada(rutaCaminandoDirecto.Points);
            }
            else
            {
                return new LineaRecomendada();
            }

        }




        void ObtenerParaderoAdyacenteMasCercano(PointLatLng _origen, Paradero _paradero, DateTime _tiempoInicio, out Paradero _parMasCercano, out GMapRoute _rutaCercana)
        {
            _parMasCercano = null;
            _rutaCercana = null;

            int rangoRevisar = 3;

            Linea _linea = _paradero.Ruta.Linea2;
            List<Paradero> paraderosLinea = new List<Paradero>();

            #region Rellenar paraderos linea
            List<Paradero> parIda = _linea.Ruta.Paradero.OrderBy(p => p.Orden).ToList();
            List<Paradero> parVuelta = _linea.Ruta1.Paradero.OrderBy(p => p.Orden).ToList();
            for (int i = 0; i < parIda.Count; i++)
            {
                paraderosLinea.Add(parIda[i]);
            }
            for (int i = 0; i < parVuelta.Count; i++)
            {
                paraderosLinea.Add(parVuelta[i]);
            }
            #endregion

            int indexParOriginal = -1;

            for (int i = 0; i < paraderosLinea.Count; i++)
            {
                if (paraderosLinea[i].Id == _paradero.Id)
                {
                    indexParOriginal = i;
                    break;
                }
            }

            int indexMenor = indexParOriginal - rangoRevisar;
            int indexMayor = indexParOriginal + rangoRevisar;

            double distMenor = double.MaxValue;

            for (int i = 0; i < paraderosLinea.Count; i++)
            {
                if( i >= indexMenor && i <= indexMayor)
                {
                    GMapRoute ruta = RutaCaminandoV2(_origen, new PointLatLng(paraderosLinea[i].Latitud, paraderosLinea[i].Longitud), true);

                    while(ruta == null)
                    {
                        if (DateTime.Now - _tiempoInicio > TiempoEsperaMaxima)
                        {
                            ruta = RutaCaminandoV2(_origen, new PointLatLng(paraderosLinea[i].Latitud, paraderosLinea[i].Longitud), true);
                            return;
                        }
                    }

                    if(ruta.Distance < distMenor)
                    {
                        distMenor = ruta.Distance;
                        _parMasCercano = paraderosLinea[i];
                        _rutaCercana = ruta;
                    }
                }
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
            List<Paradero> paraderosIda = _linea.Ruta.Paradero.OrderBy(p => p.Orden).ToList();
            List<Paradero> paraderosVuelta = _linea.Ruta1.Paradero.OrderBy(p => p.Orden).ToList();

            List<Paradero> paraderosLinea = paraderosIda;

            for (int i = 0; i < paraderosVuelta.Count; i++)
            {
                paraderosLinea.Add(paraderosVuelta[i]);
            }

            return paraderosLinea;
        }

        private GMapRoute RutaCaminandoV2(PointLatLng inicio, PointLatLng final, bool _SiguiendoDirecciones)
        {
            if (_SiguiendoDirecciones == false)
            {
                List<PointLatLng> puntos = new List<PointLatLng>();
                puntos.Add(inicio);
                puntos.Add(final);

                GMapRoute ruta = new GMapRoute(puntos, "rutadirecta");

                return ruta;
            }
            else
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

        }

        private List<Coordenada> CoordenadasSiguiendoLaRuta(Linea _linea, Paradero _pInicial, Paradero _pFinal)
        {

            List<Coordenada> coorIda = _linea.Ruta.Coordenada.OrderBy(c => c.Orden).ToList();
            List<Coordenada> coorVuelta = _linea.Ruta1.Coordenada.OrderBy(c => c.Orden).ToList();

            List<Coordenada> coordenadasLinea = new List<Coordenada>();

            for (int i = 0; i < coorIda.Count; i++)
            {
                coordenadasLinea.Add(coorIda[i]);
            }
            for (int i = 0; i < coorVuelta.Count; i++)
            {
                coordenadasLinea.Add(coorVuelta[i]);
            }

            Coordenada coorInicio = _pInicial.Coordenada;
            Coordenada coorFinal = _pFinal.Coordenada;

            List<Coordenada> coorHastaFinal = new List<Coordenada>();

            bool comenzarRellenado = false;
            bool finalEncontrado = false;

            for (int i = 0; i < coordenadasLinea.Count; i++)
            {
                Coordenada coorActual = coordenadasLinea[i];

                if (coorActual.Id == coorInicio.Id)
                    comenzarRellenado = true;

                if(comenzarRellenado == true && finalEncontrado == false)
                {
                    coorHastaFinal.Add(coorActual);
                }

                if (comenzarRellenado == true && coorActual.Id == coorFinal.Id)
                    finalEncontrado = true;
            }



            if (finalEncontrado == false)
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