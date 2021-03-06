﻿using System;
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

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

using System.Device.Location;

namespace RestServiceGX.Controllers
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
        private MicroSystemDBEntities db = new MicroSystemDBEntities();
        private TimeSpan timeSpanCero = new TimeSpan(0, 0, 0);
        private TimeSpan tiempoParaSubirMicro = new TimeSpan(0, 0, 30);
        private double metrosUserDeteccionMicro = 10;
        private double metrosDifParaSubirMicro = 150;

        private float metrosMicroParadero = 25;
        private float metrosActVertice = 65;

        //Validar
        //Editar
        //existe mail
        //actualizar posicion
        //detener actualizacion de posicion
        //Obtener micro de chofer
        //Seleccionar paradero (id paradero)
        //Deseleccionar paradero (sin id)

        //odata/Usuarios(5)/ObtenerDatosLineaFusion
        //Parametros: IdLinea 
        [HttpPost]
        public DatosLinea ObtenerDatosLineaFusion([FromODataUri] int key, ODataActionParameters parameters)
        {
            int idLinea = (int)parameters["IdLinea"];

            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();
            Linea linea = db.Linea.Where(l => l.Id == idLinea).FirstOrDefault();

            MicroParaderoDX microParaderoFinal = new MicroParaderoDX() { Id = -1 };
            MicroDX microAborada = new MicroDX() { Id = -1 };
            List<UsuarioDX> listaChoferes = new List<UsuarioDX>();      
            
            if(linea == null)
            {
                return new DatosLinea { Choferes = listaChoferes, MicroAboradada = microAborada, MicroParaderoCercano = microParaderoFinal };
            }


            #region Obtener MicroParaderoMasCercano

            if (user.UsuarioParaderoId != null)
            {

                double distEntreParaderos = 0;
                Paradero paradero = user.UsuarioParadero.Paradero;

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
                Coordenada sigCoor;

                //suma distancia entre paradero y el anterior
                //queda asignado como paradero el anterior
                //si el anterior tampoco tiene microparaderos se repite el proceso
                //retorna un microparadero con id -1 si no existen micros desde ese paradero al inicio

                bool continuarMetodo = true;
                int cantidadMicros = microParaderos.Count;
                while (cantidadMicros == 0)
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
                                DistanciaVerticesSiguiendoRuta(coordenadasLinea, paradero.Coordenada, rutaVuelta.Coordenada.Where(c => c.Orden == 0).FirstOrDefault());

                            cantidadMicros = microParaderos.Count;
                            continue;
                        }
                    }

                    paraderosRuta = rutaAUsar.Paradero.ToList().OrderBy(p => p.Orden).ToList();

                    //busca paradero
                    //suma distancia con paradero anterior
                    //reasigna paradero y microparaderos con los datos del anterior

                    Paradero paraderoAnterior = paraderosRuta.Where(p => p.Orden == paradero.Orden - 1).FirstOrDefault();

                    if (paraderoAnterior != null)
                    {
                        distEntreParaderos +=
                            DistanciaVerticesSiguiendoRuta(coordenadasLinea, paraderoAnterior.Coordenada, paradero.Coordenada);

                        paradero = paraderoAnterior;
                        microParaderos = paradero.MicroParadero.ToList();
                        cantidadMicros = microParaderos.Count;
                    }
                    else
                    {
                        continuarMetodo = false;
                        cantidadMicros = -1;
                    }
                }

                if (continuarMetodo)
                {
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

                        if (coorInicio.Id == coorFinal.Id || coorInicio.Orden >= coorFinal.Orden)
                        {
                            coorHastaParadero.Add(coorFinal);
                        }
                        else
                        {
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
                        }

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

                    if (mpMenor != null)
                    {
                        MicroParaderoDX mpReturn = new MicroParaderoDX();
                        mpReturn.Id = mpMenor.Id;
                        mpReturn.MicroId = mpMenor.MicroId;
                        mpReturn.ParaderoId = mpMenor.ParaderoId;
                        mpReturn.DistanciaEntre = mpMenor.DistanciaEntre;

                        microParaderoFinal = mpReturn;
                        
                    }
                }
            }
            #endregion

            #region Obtener mi micro abordada

            foreach (MicroPasajero mp in user.MicroPasajero)
            {
                if (mp.Estado == "Arriba")
                {
                    MicroDX mDX = new MicroDX();
                    mDX.Id = mp.Micro.Id;
                    mDX.Patente = mp.Micro.Patente;
                    mDX.Calificacion = mp.Micro.Calificacion;

                    microAborada = mDX;
                }
            }
            #endregion

            #region Obtener lista de choferes


            bool contListaChoferes = true;
            if (linea == null)
                contListaChoferes = false;

            if (contListaChoferes)
            {
                List<Micro> microsLinea = linea.Micro.ToList();
                List<UsuarioDX> choferesActivos = new List<UsuarioDX>();

                for (int i = 0; i < microsLinea.Count; i++)
                {
                    if (microsLinea[i].MicroChoferId != null)
                    {
                        microsLinea[i].MicroChofer.Usuario.Id = microsLinea[i].Id;
                        Usuario uActual = microsLinea[i].MicroChofer.Usuario;

                        UsuarioDX userDX = new UsuarioDX();
                        userDX.Id = uActual.Id;
                        userDX.Latitud = uActual.Latitud;
                        userDX.Longitud = uActual.Longitud;
                        userDX.Nombre = uActual.Nombre;
                        userDX.TransmitiendoPosicion = uActual.TransmitiendoPosicion;

                        choferesActivos.Add(userDX);
                        
                    }
                }

                listaChoferes = choferesActivos;
            }

            #endregion

            DatosLinea fusionDatosLinea = new DatosLinea();



            fusionDatosLinea.MicroParaderoCercano = microParaderoFinal;
            fusionDatosLinea.MicroAboradada = microAborada;
            fusionDatosLinea.Choferes = listaChoferes;
            fusionDatosLinea.IdLineaChoferes = idLinea;


            return fusionDatosLinea;

        }


        //odata/Usuarios(5)/ObtenerDatosRecorridoFusion
        //Parametros: nope
        [HttpPost]
        public DatosRecorrido ObtenerDatosRecorridoFusion([FromODataUri] int key)
        {
            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();
            int IdSigParadero = -1;
            int IdSigVertice = -1;
            MicroDX miMicro = null;
            List<UsuarioParaderoDeluxe> listaUP = new List<UsuarioParaderoDeluxe>();

            if (user == null)
                return new DatosRecorrido() { IdSiguienteParadero = -1 };
            else if (user.MicroChoferId == null)
                return new DatosRecorrido() { IdSiguienteParadero = -1 };
            else if (user.MicroChofer1.Micro1.LineaId == null)
                return new DatosRecorrido() { IdSiguienteParadero = -1 };

            #region Obtener mi micro

            MicroDX microFallida = new MicroDX() { Id = -1 };
            try
            {
                Micro m =  user.MicroChofer1.Micro1;

                MicroDX mc = new MicroDX();
                mc.Id = m.Id;
                mc.Calificacion = m.Calificacion;
                mc.Patente = m.Patente;


                double kilometros = ObtenerKilometrajeDiario(m);
                mc.KilometrosDia = kilometros;
                miMicro = mc;
            }
            catch
            {
                miMicro = microFallida;
            }

            #endregion

            #region Obtener usuarios que seleccionaron el siguiente paradero y la Id siguiente paradero

            try
            {
                Paradero paradero = user.MicroChofer1.Micro1.MicroParadero.Paradero;
                IdSigParadero = paradero.Id;

                List<UsuarioParadero> usuarioParaderos = paradero.UsuarioParadero.ToList();

                List<UsuarioParaderoDeluxe> upDeluxe = new List<UsuarioParaderoDeluxe>();

                Usuario userUP;

                foreach (UsuarioParadero usuarioParadero in usuarioParaderos)
                {
                    //crear ruta por medio de gmap desde el usuario al paradero
                    //sacar y asignar distancia
                    //no es necesario registrar la ruta en si en ningun lado, solo distancia

                    userUP = usuarioParadero.Usuario1;

                    PointLatLng puntoInicio = new PointLatLng(userUP.Latitud, userUP.Longitud);
                    PointLatLng puntoFinal = new PointLatLng(paradero.Latitud, paradero.Longitud);

                    GMapRoute ruta = RutaCaminando(puntoInicio, puntoFinal);
                    double distancia = -1;

                    //while (ruta == null)
                    //{
                    //    ruta = RutaCaminando(puntoInicio, puntoFinal);
                    //}
                    //double distancia = ruta.Distance;

                    if (ruta != null)
                        distancia = ruta.Distance;

                    usuarioParadero.DistanciaEntre = distancia;

                    upDeluxe.Add(new UsuarioParaderoDeluxe()
                    { UsuarioId = userUP.Id, Latitud = userUP.Latitud, Longitud = userUP.Longitud, Distancia = distancia });
                }
                listaUP = upDeluxe;
            }
            catch
            {
                listaUP = new List<UsuarioParaderoDeluxe>();
                IdSigParadero = -1;
            }
            #endregion

            try
            {
                IdSigVertice = user.MicroChofer1.Micro1.SiguienteVerticeId.Value;
            }
            catch(Exception)
            {
                IdSigVertice = -1;
            }

            db.SaveChanges();

            DatosRecorrido datosDevolver = new DatosRecorrido();
            datosDevolver.IdSiguienteParadero = IdSigParadero;
            datosDevolver.MiMicro = miMicro;
            datosDevolver.UsuarioParaderos = listaUP;
            datosDevolver.IdSiguienteVertice = IdSigVertice;

            return datosDevolver;
        }



        //POST: odata/Usuarios(5)/Mover
        //Parametros: Latitud,Longitud
        [HttpPost]
        public IHttpActionResult Mover([FromODataUri] int key, ODataActionParameters parameters)
        {
            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();

            double lat = (double)parameters["Latitud"];
            double lng = (double)parameters["Longitud"];

            user.Latitud = lat;
            user.Longitud = lng;

            db.SaveChanges();

            return Ok();
        }


        //POST: odata/Usuarios/EsValido
        //Parametros: Email,Password
        [HttpPost]
        public Usuario EsValido( ODataActionParameters parameters)
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

        //POST: odata/Usuarios(5)/ObtenerMiMicroAbordada
        public Micro ObtenerMiMicroAbordada([FromODataUri] int key)
        {
            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();
            Micro microAbordada = new Micro() { Id = -1 };

            foreach(MicroPasajero mp in user.MicroPasajero)
            {
                if(mp.Estado == "Arriba")
                {
                    microAbordada = mp.Micro;
                }
            }

            return microAbordada;
        }

        //POST: odata/Usuarios(5)/ActualizarPosicionChofer
        //Parametros: Latitud, Longitud
        [HttpPost]
        public DatosRecorrido ActualizarPosicionChofer([FromODataUri] int key, ODataActionParameters parameters)
        {
            double latitud = (double)parameters["Latitud"];
            double longitud = (double)parameters["Longitud"];

            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();
            PointLatLng posAnterior = new PointLatLng(user.Latitud, user.Longitud);

            user.Latitud = latitud;
            user.Longitud = longitud;
            user.TransmitiendoPosicion = false; //se cambia  atrue dependiendo de factores


            if (user.Rol != 1 || user.MicroChoferId == null)
                return new DatosRecorrido();


            #region Actualizar Recorrido
            Micro micro = user.MicroChofer1.Micro1;
            if (micro.SiguienteVerticeId != null && micro.LineaId != null)
            {
                user.TransmitiendoPosicion = true;
                Linea lineaAsociada = micro.Linea;
                var choferCoordenada = new GeoCoordinate(user.Latitud, user.Longitud);

                Paradero p = ActualizarParaderos(micro, choferCoordenada, lineaAsociada);
                ActualizarVertices(micro, user, choferCoordenada, lineaAsociada, p);
            }
            #endregion


            int IdSigParadero = -1;
            int IdSigVertice = -1;
            MicroDX miMicro = null;
            List<UsuarioParaderoDeluxe> listaUP = new List<UsuarioParaderoDeluxe>();

            if (user == null)
                return new DatosRecorrido() { IdSiguienteParadero = -1 };
            else if (user.MicroChoferId == null)
                return new DatosRecorrido() { IdSiguienteParadero = -1 };
            else if (user.MicroChofer1.Micro1.LineaId == null)
                return new DatosRecorrido() { IdSiguienteParadero = -1 };

            #region Obtener mi micro

            MicroDX microFallida = new MicroDX() { Id = -1 };
            try
            {
                Micro m = user.MicroChofer1.Micro1;

                MicroDX mc = new MicroDX();
                mc.Id = m.Id;
                mc.Calificacion = m.Calificacion;
                mc.Patente = m.Patente;


                double kilometros = ObtenerKilometrajeDiarioV2(posAnterior, new PointLatLng(latitud,longitud), m);
                mc.KilometrosDia = kilometros;
                miMicro = mc;
            }
            catch
            {
                miMicro = microFallida;
            }

            #endregion

            #region Obtener usuarios que seleccionaron el siguiente paradero y la Id siguiente paradero

            try
            {
                Paradero paradero = user.MicroChofer1.Micro1.MicroParadero.Paradero;
                IdSigParadero = paradero.Id;

                List<UsuarioParadero> usuarioParaderos = paradero.UsuarioParadero.ToList();

                List<UsuarioParaderoDeluxe> upDeluxe = new List<UsuarioParaderoDeluxe>();

                Usuario userUP;

                foreach (UsuarioParadero usuarioParadero in usuarioParaderos)
                {
                    //crear ruta por medio de gmap desde el usuario al paradero
                    //sacar y asignar distancia
                    //no es necesario registrar la ruta en si en ningun lado, solo distancia

                    userUP = usuarioParadero.Usuario1;

                    PointLatLng puntoInicio = new PointLatLng(userUP.Latitud, userUP.Longitud);
                    PointLatLng puntoFinal = new PointLatLng(paradero.Latitud, paradero.Longitud);

                    GMapRoute ruta = RutaCaminando(puntoInicio, puntoFinal);

                    while (ruta == null)
                    {
                        ruta = RutaCaminando(puntoInicio, puntoFinal);
                    }

                    double distancia = ruta.Distance;
                    usuarioParadero.DistanciaEntre = distancia;

                    upDeluxe.Add(new UsuarioParaderoDeluxe()
                    { UsuarioId = userUP.Id, Latitud = userUP.Latitud, Longitud = userUP.Longitud, Distancia = distancia });
                }
                listaUP = upDeluxe;
            }
            catch
            {
                listaUP = new List<UsuarioParaderoDeluxe>();
                IdSigParadero = -1;
            }
            #endregion

            try
            {
                IdSigVertice = user.MicroChofer1.Micro1.SiguienteVerticeId.Value;
            }
            catch (Exception)
            {
                IdSigVertice = -1;
            }

            db.SaveChanges();

            DatosRecorrido datosDevolver = new DatosRecorrido();
            datosDevolver.IdSiguienteParadero = IdSigParadero;
            datosDevolver.MiMicro = miMicro;
            datosDevolver.UsuarioParaderos = listaUP;
            datosDevolver.IdSiguienteVertice = IdSigVertice;

            return datosDevolver;
        }

        //POST: odata/Usuarios(5)/ActualizarPosicionPasajero
        //Parametros: Latitud, Longitud, IdLinea
        [HttpPost]
        public DatosLinea ActualizarPosicionPasajero([FromODataUri] int key, ODataActionParameters parameters)
        {
            double latitud = (double)parameters["Latitud"];
            double longitud = (double)parameters["Longitud"];

            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();

            user.Latitud = latitud;
            user.Longitud = longitud;
            user.TransmitiendoPosicion = false; //se cambia  atrue dependiendo de factores

            if (user.Rol != 0)
                return new DatosLinea();


            if (user.UsuarioParaderoId != null)
                user.TransmitiendoPosicion = true;
            if (user.MicroPasajero.Count > 0)
                user.TransmitiendoPosicion = true;

            ActualizarSubidaBajadaDeMicro(user);

            int idLinea = (int)parameters["IdLinea"];

            Linea linea = db.Linea.Where(l => l.Id == idLinea).FirstOrDefault();

            MicroParaderoDX microParaderoFinal = new MicroParaderoDX() { Id = -1 };
            MicroDX microAborada = new MicroDX() { Id = -1 };
            List<UsuarioDX> listaChoferes = new List<UsuarioDX>();

            if (linea == null)
            {
                return new DatosLinea { Choferes = listaChoferes, MicroAboradada = microAborada, MicroParaderoCercano = microParaderoFinal };
            }


            #region Obtener MicroParaderoMasCercano

            if (user.UsuarioParaderoId != null)
            {

                double distEntreParaderos = 0;
                Paradero paradero = user.UsuarioParadero.Paradero;

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
                Coordenada sigCoor;

                //suma distancia entre paradero y el anterior
                //queda asignado como paradero el anterior
                //si el anterior tampoco tiene microparaderos se repite el proceso
                //retorna un microparadero con id -1 si no existen micros desde ese paradero al inicio

                bool continuarMetodo = true;
                int cantidadMicros = microParaderos.Count;
                while (cantidadMicros == 0)
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
                                DistanciaVerticesSiguiendoRuta(coordenadasLinea, paradero.Coordenada, rutaVuelta.Coordenada.Where(c => c.Orden == 0).FirstOrDefault());

                            cantidadMicros = microParaderos.Count;
                            continue;
                        }
                    }

                    paraderosRuta = rutaAUsar.Paradero.ToList().OrderBy(p => p.Orden).ToList();

                    //busca paradero
                    //suma distancia con paradero anterior
                    //reasigna paradero y microparaderos con los datos del anterior

                    Paradero paraderoAnterior = paraderosRuta.Where(p => p.Orden == paradero.Orden - 1).FirstOrDefault();

                    if (paraderoAnterior != null)
                    {
                        distEntreParaderos +=
                            DistanciaVerticesSiguiendoRuta(coordenadasLinea, paraderoAnterior.Coordenada, paradero.Coordenada);

                        paradero = paraderoAnterior;
                        microParaderos = paradero.MicroParadero.ToList();
                        cantidadMicros = microParaderos.Count;
                    }
                    else
                    {
                        continuarMetodo = false;
                        cantidadMicros = -1;
                    }
                }

                if (continuarMetodo)
                {
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

                        if (coorInicio.Id == coorFinal.Id || coorInicio.Orden >= coorFinal.Orden)
                        {
                            coorHastaParadero.Add(coorFinal);
                        }
                        else
                        {
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
                        }

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

                    if (mpMenor != null)
                    {
                        MicroParaderoDX mpReturn = new MicroParaderoDX();
                        mpReturn.Id = mpMenor.Id;
                        mpReturn.MicroId = mpMenor.MicroId;
                        mpReturn.ParaderoId = mpMenor.ParaderoId;
                        mpReturn.DistanciaEntre = mpMenor.DistanciaEntre;

                        microParaderoFinal = mpReturn;

                    }
                }
            }
            #endregion

            #region Obtener mi micro abordada

            foreach (MicroPasajero mp in user.MicroPasajero)
            {
                if (mp.Estado == "Arriba")
                {
                    MicroDX mDX = new MicroDX();
                    mDX.Id = mp.Micro.Id;
                    mDX.Patente = mp.Micro.Patente;
                    mDX.Calificacion = mp.Micro.Calificacion;

                    microAborada = mDX;
                }
            }
            #endregion

            #region Obtener lista de choferes


            bool contListaChoferes = true;
            if (linea == null)
                contListaChoferes = false;

            if (contListaChoferes)
            {
                List<Micro> microsLinea = linea.Micro.ToList();
                List<UsuarioDX> choferesActivos = new List<UsuarioDX>();

                for (int i = 0; i < microsLinea.Count; i++)
                {
                    if (microsLinea[i].MicroChoferId != null)
                    {
                        microsLinea[i].MicroChofer.Usuario.Id = microsLinea[i].Id;
                        Usuario uActual = microsLinea[i].MicroChofer.Usuario;

                        UsuarioDX userDX = new UsuarioDX();
                        userDX.Id = uActual.Id;
                        userDX.Latitud = uActual.Latitud;
                        userDX.Longitud = uActual.Longitud;
                        userDX.Nombre = uActual.Nombre;
                        userDX.TransmitiendoPosicion = uActual.TransmitiendoPosicion;

                        choferesActivos.Add(userDX);

                    }
                }

                listaChoferes = choferesActivos;
            }

            #endregion

            DatosLinea fusionDatosLinea = new DatosLinea();

            fusionDatosLinea.MicroParaderoCercano = microParaderoFinal;
            fusionDatosLinea.MicroAboradada = microAborada;
            fusionDatosLinea.Choferes = listaChoferes;
            fusionDatosLinea.IdLineaChoferes = idLinea;


            return fusionDatosLinea;

        }

        //POST: odata/Usuarios(5)/ActualizarPosicion
        //Parametros: Latitud, Longitud
        [HttpPost]
        public IHttpActionResult ActualizarPosicion([FromODataUri] int key, ODataActionParameters parameters)
        {
            double latitud = (double)parameters["Latitud"];
            double longitud = (double)parameters["Longitud"];

            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();

            user.Latitud = latitud;
            user.Longitud = longitud;
            user.TransmitiendoPosicion = false; //se cambia  atrue dependiendo de factores

            //Si es chofer y si esta asociado a una siguiente coordenada
            //no se usa paradero o no se podria saber cuando termina le recorrido (llegar a la ultima coordenada)
            //ir actualizando siguientes paraderos y siguientes vertices
            if (user.Rol == 1 && user.MicroChoferId != null)
            {
                Micro micro = user.MicroChofer1.Micro1;
                if (micro.SiguienteVerticeId != null && micro.LineaId != null)
                {
                    user.TransmitiendoPosicion = true;
                    Linea lineaAsociada = micro.Linea;
                    var choferCoordenada = new GeoCoordinate(user.Latitud, user.Longitud);

                    Paradero p = ActualizarParaderos(micro, choferCoordenada, lineaAsociada);
                    ActualizarVertices(micro, user, choferCoordenada, lineaAsociada, p);
                }

            }

            //si es usuario normal
            else if (user.Rol == 0)
            {
                if (user.UsuarioParaderoId != null)
                {
                    user.TransmitiendoPosicion = true;
                }
                if (user.MicroPasajero.Count > 0)
                {
                    user.TransmitiendoPosicion = true;
                }


                ActualizarSubidaBajadaDeMicro(user);
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
            user.TransmitiendoPosicion = false;

            //Si es chofer y si esta asociado a una siguiente coordenada
            //no se usa paradero o no se podria saber cuando termina le recorrido (llegar a la ultima coordenada)
            //ir actualizando siguientes paraderos y siguientes vertices
            if (user.Rol == 1 && user.MicroChoferId != null)
            {
                Micro micro = user.MicroChofer1.Micro1;
                if (micro.SiguienteVerticeId != null && micro.LineaId != null)
                {
                    user.TransmitiendoPosicion = true;
                    Linea lineaAsociada = micro.Linea;
                    var choferCoordenada = new GeoCoordinate(user.Latitud, user.Longitud);

                    Paradero p = ActualizarParaderos(micro, choferCoordenada, lineaAsociada);
                    ActualizarVertices(micro, user, choferCoordenada, lineaAsociada, p);
                }
            }

            //si es usuario normal
            else if (user.Rol == 0)
            {
                if (user.UsuarioParaderoId != null)
                {
                    user.TransmitiendoPosicion = true;
                }
                if (user.MicroPasajero.Count > 0)
                {
                    user.TransmitiendoPosicion = true;
                }

                ActualizarSubidaBajadaDeMicro(user);
            }

            db.SaveChanges();

            return pos;
        }

        // POST: odata/Usuarios(5)/ObtenerPosicionChofer
        [HttpPost]
        public DatosRecorrido ObtenerPosicionChofer([FromODataUri] int key)
        {

            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();
            Posicion pos = new Posicion(user.Latitud, user.Longitud);
            user.TransmitiendoPosicion = false;

            if (user.Rol != 1 || user.MicroChoferId == null)
                return new DatosRecorrido();

            #region ActualizarRecorrido
            Micro micro = user.MicroChofer1.Micro1;
            if (micro.SiguienteVerticeId != null && micro.LineaId != null)
            {
                user.TransmitiendoPosicion = true;
                Linea lineaAsociada = micro.Linea;
                var choferCoordenada = new GeoCoordinate(user.Latitud, user.Longitud);

                Paradero p = ActualizarParaderos(micro, choferCoordenada, lineaAsociada);
                ActualizarVertices(micro, user, choferCoordenada, lineaAsociada, p);
            }
            #endregion

            int IdSigParadero = -1;
            int IdSigVertice = -1;
            MicroDX miMicro = null;
            List<UsuarioParaderoDeluxe> listaUP = new List<UsuarioParaderoDeluxe>();

            if (user == null)
                return new DatosRecorrido() { IdSiguienteParadero = -1 };
            else if (user.MicroChoferId == null)
                return new DatosRecorrido() { IdSiguienteParadero = -1 };
            else if (user.MicroChofer1.Micro1.LineaId == null)
                return new DatosRecorrido() { IdSiguienteParadero = -1 };

            #region Obtener mi micro

            MicroDX microFallida = new MicroDX() { Id = -1 };
            try
            {
                Micro m = user.MicroChofer1.Micro1;

                MicroDX mc = new MicroDX();
                mc.Id = m.Id;
                mc.Calificacion = m.Calificacion;
                mc.Patente = m.Patente;


                double kilometros = ObtenerKilometrajeDiario(m);
                mc.KilometrosDia = kilometros;
                miMicro = mc;
            }
            catch
            {
                miMicro = microFallida;
            }

            #endregion

            #region Obtener usuarios que seleccionaron el siguiente paradero y la Id siguiente paradero

            try
            {
                Paradero paradero = user.MicroChofer1.Micro1.MicroParadero.Paradero;
                IdSigParadero = paradero.Id;

                List<UsuarioParadero> usuarioParaderos = paradero.UsuarioParadero.ToList();

                List<UsuarioParaderoDeluxe> upDeluxe = new List<UsuarioParaderoDeluxe>();

                Usuario userUP;

                foreach (UsuarioParadero usuarioParadero in usuarioParaderos)
                {
                    //crear ruta por medio de gmap desde el usuario al paradero
                    //sacar y asignar distancia
                    //no es necesario registrar la ruta en si en ningun lado, solo distancia

                    userUP = usuarioParadero.Usuario1;

                    PointLatLng puntoInicio = new PointLatLng(userUP.Latitud, userUP.Longitud);
                    PointLatLng puntoFinal = new PointLatLng(paradero.Latitud, paradero.Longitud);

                    GMapRoute ruta = RutaCaminando(puntoInicio, puntoFinal);

                    while (ruta == null)
                    {
                        ruta = RutaCaminando(puntoInicio, puntoFinal);
                    }

                    double distancia = ruta.Distance;
                    usuarioParadero.DistanciaEntre = distancia;

                    upDeluxe.Add(new UsuarioParaderoDeluxe()
                    { UsuarioId = userUP.Id, Latitud = userUP.Latitud, Longitud = userUP.Longitud, Distancia = distancia });
                }
                listaUP = upDeluxe;
            }
            catch
            {
                listaUP = new List<UsuarioParaderoDeluxe>();
                IdSigParadero = -1;
            }
            #endregion

            try
            {
                IdSigVertice = user.MicroChofer1.Micro1.SiguienteVerticeId.Value;
            }
            catch (Exception)
            {
                IdSigVertice = -1;
            }

            db.SaveChanges();

            DatosRecorrido datosDevolver = new DatosRecorrido();
            datosDevolver.IdSiguienteParadero = IdSigParadero;
            datosDevolver.MiMicro = miMicro;
            datosDevolver.UsuarioParaderos = listaUP;
            datosDevolver.IdSiguienteVertice = IdSigVertice;

            datosDevolver.Latitud = pos.Latitud;
            datosDevolver.Longitud = pos.Longitud;

            return datosDevolver;
        }

        // POST: odata/Usuarios(5)/ObtenerPosicionPasajero
        //Parametros: IdLinea
        [HttpPost]
        public DatosLinea ObtenerPosicionPasajero([FromODataUri] int key, ODataActionParameters parameters)
        {

            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();
            Posicion pos = new Posicion(user.Latitud, user.Longitud);
            user.TransmitiendoPosicion = false;

            if (user.Rol != 1)
                return new DatosLinea();


            if (user.UsuarioParaderoId != null)
                user.TransmitiendoPosicion = true;
            if (user.MicroPasajero.Count > 0)
                user.TransmitiendoPosicion = true;

            ActualizarSubidaBajadaDeMicro(user);

            int idLinea = (int)parameters["IdLinea"];

            Linea linea = db.Linea.Where(l => l.Id == idLinea).FirstOrDefault();

            MicroParaderoDX microParaderoFinal = new MicroParaderoDX() { Id = -1 };
            MicroDX microAborada = new MicroDX() { Id = -1 };
            List<UsuarioDX> listaChoferes = new List<UsuarioDX>();

            if (linea == null)
            {
                return new DatosLinea { Choferes = listaChoferes, MicroAboradada = microAborada, MicroParaderoCercano = microParaderoFinal };
            }


            #region Obtener MicroParaderoMasCercano

            if (user.UsuarioParaderoId != null)
            {

                double distEntreParaderos = 0;
                Paradero paradero = user.UsuarioParadero.Paradero;

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
                Coordenada sigCoor;

                //suma distancia entre paradero y el anterior
                //queda asignado como paradero el anterior
                //si el anterior tampoco tiene microparaderos se repite el proceso
                //retorna un microparadero con id -1 si no existen micros desde ese paradero al inicio

                bool continuarMetodo = true;
                int cantidadMicros = microParaderos.Count;
                while (cantidadMicros == 0)
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
                                DistanciaVerticesSiguiendoRuta(coordenadasLinea, paradero.Coordenada, rutaVuelta.Coordenada.Where(c => c.Orden == 0).FirstOrDefault());

                            cantidadMicros = microParaderos.Count;
                            continue;
                        }
                    }

                    paraderosRuta = rutaAUsar.Paradero.ToList().OrderBy(p => p.Orden).ToList();

                    //busca paradero
                    //suma distancia con paradero anterior
                    //reasigna paradero y microparaderos con los datos del anterior

                    Paradero paraderoAnterior = paraderosRuta.Where(p => p.Orden == paradero.Orden - 1).FirstOrDefault();

                    if (paraderoAnterior != null)
                    {
                        distEntreParaderos +=
                            DistanciaVerticesSiguiendoRuta(coordenadasLinea, paraderoAnterior.Coordenada, paradero.Coordenada);

                        paradero = paraderoAnterior;
                        microParaderos = paradero.MicroParadero.ToList();
                        cantidadMicros = microParaderos.Count;
                    }
                    else
                    {
                        continuarMetodo = false;
                        cantidadMicros = -1;
                    }
                }

                if (continuarMetodo)
                {
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

                        if (coorInicio.Id == coorFinal.Id || coorInicio.Orden >= coorFinal.Orden)
                        {
                            coorHastaParadero.Add(coorFinal);
                        }
                        else
                        {
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
                        }

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

                    if (mpMenor != null)
                    {
                        MicroParaderoDX mpReturn = new MicroParaderoDX();
                        mpReturn.Id = mpMenor.Id;
                        mpReturn.MicroId = mpMenor.MicroId;
                        mpReturn.ParaderoId = mpMenor.ParaderoId;
                        mpReturn.DistanciaEntre = mpMenor.DistanciaEntre;

                        microParaderoFinal = mpReturn;

                    }
                }
            }
            #endregion

            #region Obtener mi micro abordada

            foreach (MicroPasajero mp in user.MicroPasajero)
            {
                if (mp.Estado == "Arriba")
                {
                    MicroDX mDX = new MicroDX();
                    mDX.Id = mp.Micro.Id;
                    mDX.Patente = mp.Micro.Patente;
                    mDX.Calificacion = mp.Micro.Calificacion;

                    microAborada = mDX;
                }
            }
            #endregion

            #region Obtener lista de choferes


            bool contListaChoferes = true;
            if (linea == null)
                contListaChoferes = false;

            if (contListaChoferes)
            {
                List<Micro> microsLinea = linea.Micro.ToList();
                List<UsuarioDX> choferesActivos = new List<UsuarioDX>();

                for (int i = 0; i < microsLinea.Count; i++)
                {
                    if (microsLinea[i].MicroChoferId != null)
                    {
                        microsLinea[i].MicroChofer.Usuario.Id = microsLinea[i].Id;
                        Usuario uActual = microsLinea[i].MicroChofer.Usuario;

                        UsuarioDX userDX = new UsuarioDX();
                        userDX.Id = uActual.Id;
                        userDX.Latitud = uActual.Latitud;
                        userDX.Longitud = uActual.Longitud;
                        userDX.Nombre = uActual.Nombre;
                        userDX.TransmitiendoPosicion = uActual.TransmitiendoPosicion;

                        choferesActivos.Add(userDX);

                    }
                }

                listaChoferes = choferesActivos;
            }

            #endregion

            DatosLinea fusionDatosLinea = new DatosLinea();



            fusionDatosLinea.MicroParaderoCercano = microParaderoFinal;
            fusionDatosLinea.MicroAboradada = microAborada;
            fusionDatosLinea.Choferes = listaChoferes;
            fusionDatosLinea.IdLineaChoferes = idLinea;

            fusionDatosLinea.Latitud = pos.Latitud;
            fusionDatosLinea.Longitud = pos.Longitud;

            return fusionDatosLinea;
        }


        void ActualizarSubidaBajadaDeMicro(Usuario _user)
        {
            GeoCoordinate posUser = new GeoCoordinate(_user.Latitud, _user.Longitud);
            List<MicroPasajero> mPasajeros = _user.MicroPasajero.ToList();
            List<MicroPasajero> mPasajerosABorrar = new List<MicroPasajero>();

            bool yaEstaEnMicro = false;
            MicroPasajero mpArriba = null;
            #region Revisa si ya esta subido en una micro
            foreach (MicroPasajero mp in mPasajeros)
            {
                if (mp.Estado == "Arriba")
                {
                    yaEstaEnMicro = true;
                    mpArriba = mp;
                }
            }
            #endregion

            if (yaEstaEnMicro)
            {
                //si ya esta arriba de la micro revisar si se baja
                GeoCoordinate posMicro = new GeoCoordinate(mpArriba.Micro.MicroChofer.Usuario.Latitud, mpArriba.Micro.MicroChofer.Usuario.Longitud);
                double distEntre = posUser.GetDistanceTo(posMicro);

                if(distEntre > metrosUserDeteccionMicro)
                {
                    //Se bajo de la micro
                    db.MicroPasajero.Remove(mpArriba); //deberia de ser el unico micropasajero en la lista (por la forma en que se crean)
                }
            }
            else
            {
                bool subioAMicro = false;
                #region Revisar los de estado "PosiblePasajero" y comprobar si es pasajero real o se aleja
                foreach (MicroPasajero mpas in mPasajeros)
                {
                    if (mpas.Estado == "PosiblePasajero")
                    {
                        GeoCoordinate posCreacion = new GeoCoordinate(mpas.LatitudCreacion, mpas.LongitudCreacion);

                        double posMicroLat = mpas.Micro.MicroChofer.Usuario.Latitud;
                        double posMicroLng = mpas.Micro.MicroChofer.Usuario.Longitud;
                        GeoCoordinate posMicro = new GeoCoordinate(posMicroLat, posMicroLng);

                        double distEntre = posUser.GetDistanceTo(posMicro);
                        TimeSpan tiempoTranscurrido = DateTime.Now - mpas.HoraCreacion;
                        double distDesdeCreacion = posUser.GetDistanceTo(posCreacion);

                        if (tiempoTranscurrido > tiempoParaSubirMicro)
                        {
                            if (distEntre < metrosUserDeteccionMicro)
                            {//paso el rango de tiempo y el usuario sigue al lado de la micro

                                if (distDesdeCreacion > metrosDifParaSubirMicro)
                                {//usuario se considera arriba de la micro

                                    subioAMicro = true;
                                    UsuarioParadero up = _user.UsuarioParadero;
                                    db.UsuarioParadero.Remove(up);
                                    mpas.Estado = "Arriba";

                                    ParaderoHistorialNuevoPasajero(mpas.Micro);

                                    break;
                                }
                                else
                                {
                                    //como el usuario sigue al lado de la micro, pero la distancia no es suficiente
                                    //para considerarlo arriba, se reinicia el contador
                                    mpas.HoraCreacion = DateTime.Now;
                                    mpas.LatitudCreacion = _user.Latitud;
                                    mpas.LongitudCreacion = _user.Longitud;
                                }
                            }
                            else
                            {
                                //el usuario esta lejos de la micro despues del rango de tiempo
                                //se deshecha esta relacion
                                mPasajerosABorrar.Add(mpas);
                            }

                        }
                    }
                }
                #endregion

                #region Si se subio a una micro deshechar las demas relaciones (tambien deshecha las que pasado el tiempo limite se alejaron de la micro)
                if (subioAMicro)
                {
                    foreach (MicroPasajero mp in mPasajeros)
                    {
                        if (mp.Estado == "PosiblePasajero")
                        {
                            mPasajerosABorrar.Add(mp);
                        }
                    }
                }

                for (int i = 0; i < mPasajerosABorrar.Count; i++)
                {
                    db.MicroPasajero.Remove(mPasajerosABorrar[i]);
                }
                #endregion
            }


            //si usuario tiene seleccionado un paradero esta vigilante de asociarse a las micros como "PosiblePasajero"
            //cuando el user se considera que ya se subio a una micro deja de tener seleccionado el paradero y no entra aqui
            if (_user.UsuarioParaderoId != null)
            {
                Paradero p = _user.UsuarioParadero.Paradero;
                List<Micro> microsLLendo = new List<Micro>();
                foreach (MicroParadero mp in p.MicroParadero)
                {
                    microsLLendo.Add(mp.Micro1);
                }
                //por cada micro revisar que tan lejos esta del pasajero

                foreach (Micro m in microsLLendo)
                {
                    GeoCoordinate posMicro = new GeoCoordinate(m.MicroChofer.Usuario.Latitud, m.MicroChofer.Usuario.Longitud);
                    double distEntre = posUser.GetDistanceTo(posMicro);

                    if (distEntre < metrosUserDeteccionMicro)
                    {
                        MicroPasajero existe = _user.MicroPasajero.Where(mp => mp.MicroId == m.Id).FirstOrDefault();
                        if (existe == null)
                        {
                            //Crea asociacion MicroPasajero
                            MicroPasajero mpNuevo = new MicroPasajero();
                            mpNuevo.Estado = "PosiblePasajero";
                            mpNuevo.HoraCreacion = DateTime.Now;
                            mpNuevo.LatitudCreacion = posUser.Latitude;
                            mpNuevo.LongitudCreacion = posUser.Longitude;
                            mpNuevo.Micro = m;
                            mpNuevo.Paradero = p;

                            _user.MicroPasajero.Add(mpNuevo);
                        }
                    }
                }
            }

        }

        Paradero ActualizarParaderos(Micro _micro, GeoCoordinate _choferCoordenada, Linea _lineaAsociada)
        {
            Paradero pAlcanzado = null;


            if (_micro.MicroParaderoId != null)
            {
                double DistanciaLimiteParadero = metrosMicroParadero;
                Paradero sigParadero = _micro.MicroParadero.Paradero;

                double distAntigua = _micro.MicroParadero.DistanciaEntre;

                var sigParaderoCoordenada = new GeoCoordinate(sigParadero.Latitud, sigParadero.Longitud);
                double distSigParadero = _choferCoordenada.GetDistanceTo(sigParaderoCoordenada);

                //si la distancia antigua es mayor que el limite y la nueva distancia es menor
                //se llego al paradero
                if (distSigParadero <= DistanciaLimiteParadero && distAntigua > DistanciaLimiteParadero)
                {
                    IniciarParaderoHistorial(_micro);
                    pAlcanzado = sigParadero;
                    _micro.MicroParadero.DistanciaEntre = distSigParadero;
                }
                //si salio del radio determinado del paradero, se actualiza el siguiente paradero
                else if (distSigParadero >= DistanciaLimiteParadero && distAntigua < DistanciaLimiteParadero)
                {
                    List<Paradero> paraderosLinea = new List<Paradero>();
                    TerminarParaderoHistorial(_micro);

                    #region LLenar los paraderos de la linea
                    List<Paradero> paraderosIda = _lineaAsociada.Ruta.Paradero.OrderBy(p => p.Orden).ToList();
                    List<Paradero> paraderosVuelta = _lineaAsociada.Ruta1.Paradero.OrderBy(p => p.Orden).ToList();

                    for (int i = 0; i < paraderosIda.Count; i++) //ida
                    {
                        paraderosLinea.Add(paraderosIda[i]);
                    }

                    for (int i = 0; i < paraderosVuelta.Count; i++)//ida
                    {
                        paraderosLinea.Add(paraderosVuelta[i]);
                    }
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

                            if(distPosibleSig < DistanciaLimiteParadero)
                            {
                                IniciarParaderoHistorial(_micro);
                                pAlcanzado = siguiente;
                            }

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
            db.SaveChanges();
            return pAlcanzado;

        }

        void ActualizarVertices(Micro _micro, Usuario _user, GeoCoordinate _choferCoordenada, Linea _lineaAsociada, Paradero _paraderoActualizado)
        {

            double distLimiteVertices = metrosActVertice;

            Coordenada sigCoor = _micro.Coordenada;
            var sigVerticeCoordenada = new GeoCoordinate(sigCoor.Latitud, sigCoor.Longitud);
            double distSigCoor = _choferCoordenada.GetDistanceTo(sigVerticeCoordenada);

            if (_paraderoActualizado != null)
            {
                sigCoor = _paraderoActualizado.Coordenada;

                sigVerticeCoordenada = new GeoCoordinate(_paraderoActualizado.Latitud, _paraderoActualizado.Longitud);
                distSigCoor = _choferCoordenada.GetDistanceTo(sigVerticeCoordenada);
                if (sigCoor != null)
                {
                    _micro.Coordenada = sigCoor;
                }
            }

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
                            _micro.Coordenada = null;
                            _micro.SiguienteVerticeId = null;
                            _user.TransmitiendoPosicion = false;
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
                                _micro.Coordenada = null;
                                _micro.SiguienteVerticeId = null;
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

                    HistorialIdaVuelta ultimoHiv = hDiario.HistorialIdaVuelta.OrderBy(h => h.Orden).ToList().Last();

                    ultimoHiv.HoraTermino = DateTime.Now;
                    ultimoHiv.DuracionRecorrido = DateTime.Now - ultimoHiv.HoraInicio;


                    //se toman kilometros recorridos desde fin dela linea hasta el principio
                    List<Coordenada> coorIda = _micro.Linea.Ruta.Coordenada.OrderBy(c => c.Orden).ToList();
                    List<Coordenada> coorVuelta = _micro.Linea.Ruta1.Coordenada.OrderBy(c => c.Orden).ToList();

                    double metrosTotales = 0;

                    for (int z = 0; z < coorIda.Count - 1; z++)
                    {
                        var sCoord = new GeoCoordinate(coorIda[i].Latitud, coorIda[i].Longitud);
                        var eCoord = new GeoCoordinate(coorIda[i + 1].Latitud, coorIda[i + 1].Longitud);

                        metrosTotales += sCoord.GetDistanceTo(eCoord);
                    }

                    for (int z = 0; z < coorVuelta.Count - 1; z++)
                    {
                        var sCoord = new GeoCoordinate(coorVuelta[i].Latitud, coorVuelta[i].Longitud);
                        var eCoord = new GeoCoordinate(coorVuelta[i + 1].Latitud, coorVuelta[i + 1].Longitud);

                        metrosTotales += sCoord.GetDistanceTo(eCoord);
                    }

                    float KilometrosTotales = (float)(metrosTotales / 1000);
                    hDiario.KilometrosRecorridos += KilometrosTotales;
                }

            }
            db.SaveChanges();

        }

        double ObtenerKilometrajeDiario(Micro _micro)
        {
            List<HistorialDiario> historialesDiarios = _micro.HistorialDiario.ToList();
            HistorialDiario histHoy = historialesDiarios.Where(h => h.Fecha == DateTime.Today).FirstOrDefault();

            double kilometrosAnteriores = histHoy.KilometrosRecorridos;
            List<Coordenada> coorLinea = ObtenerCoordenadasLinea(_micro.LineaId.Value);

            Coordenada sigCoor = _micro.Coordenada;
            int tipoRuta = sigCoor.Ruta.TipoDeRuta; //0 = ida, 1 = vuelta

            Coordenada coorFinal = null;

            #region Encontrar coordenada final
            for (int i = 0; i < coorLinea.Count; i++)
            {
                Coordenada coorActual = coorLinea[i];
   
                if (coorActual.Orden == sigCoor.Orden && coorActual.Ruta.TipoDeRuta == tipoRuta &&  i > 0)
                {
                    coorFinal = coorLinea[i - 1];
                }

            }
            #endregion
            
            if (coorFinal == null)
                return 0;


            double kilometros = 0;

            #region Sumar Kilometros de inicio a la coordenada Final
            GeoCoordinate geoInicio;
            GeoCoordinate geoFinal;

            for (int i = 0; i < coorLinea.Count; i++)
            {
                if(i < coorLinea.Count -1)
                {
                    Coordenada coor1 = coorLinea[i];
                    Coordenada coor2 = coorLinea[i + 1];

                    if(coor2.Id != coorFinal.Id)
                    {
                        geoInicio = new GeoCoordinate(coor1.Latitud, coor1.Longitud);
                        geoFinal = new GeoCoordinate(coor2.Latitud, coor2.Longitud);

                        double k = geoInicio.GetDistanceTo(geoFinal) / 1000;
                        kilometros += k;
                    }
                    else
                    {
                        break;
                    }

                }
            }
            #endregion


            //GeoCoordinate posMicro = new GeoCoordinate(_micro.MicroChofer.Usuario.Latitud, _micro.MicroChofer.Usuario.Longitud);
            //GeoCoordinate posVerticeAnterior = new GeoCoordinate(coorFinal.Latitud, coorFinal.Longitud);

            //double distExtra = posMicro.GetDistanceTo(posVerticeAnterior) / 1000;

            //kilometros += distExtra;

            return kilometros + kilometrosAnteriores ;
        }

        double ObtenerKilometrajeDiarioV2(PointLatLng _posAnterior, PointLatLng _posActual, Micro _micro)
        {
            List<HistorialDiario> historialesDiarios = _micro.HistorialDiario.ToList();
            HistorialDiario histHoy = historialesDiarios.Where(h => h.Fecha == DateTime.Today).FirstOrDefault();

            GeoCoordinate coorAnterior = new GeoCoordinate(_posAnterior.Lat, _posAnterior.Lng);
            GeoCoordinate coorActual = new GeoCoordinate(_posActual.Lat, _posActual.Lng);

            float kilometros = (float)coorAnterior.GetDistanceTo(coorActual);

            histHoy.KilometrosRecorridos += kilometros;


            return histHoy.KilometrosRecorridos;
        }

        void IniciarParaderoHistorial(Micro _micro)
        {
            //tomar el ultimo historial idavuelta (deberia de estar incompleto aun garantizado)
            HistorialDiario HDhoy = _micro.HistorialDiario.Where(hd => hd.Fecha == DateTime.Today).FirstOrDefault();
            HistorialIdaVuelta ultimoHIV = HDhoy.HistorialIdaVuelta.OrderBy(h => h.Orden).ToList().Last();

            //si no existe ningun historial paradero, se crea el primero
            if (ultimoHIV.HistorialParadero.Count == 0)
            {
                HistorialParadero hpNuevo = new HistorialParadero();
                hpNuevo.HoraLlegada = DateTime.Now;
                hpNuevo.TiempoDetenido = new TimeSpan(0, 0, 0);
                hpNuevo.Orden = 1;

                ultimoHIV.HistorialParadero.Add(hpNuevo);
            }
            else
            {
                //revisar si el ultimo historialParadero ya existe (se nota porque no tiene el campo tiempo detenido asignado)
                HistorialParadero ultimoHP = ultimoHIV.HistorialParadero.OrderBy(h => h.Orden).ToList().Last();

                //si el ultimo historial paradero tiene cerrado sus datos
                //se crea nuevo historial
                if (ultimoHP.TiempoDetenido != timeSpanCero)
                {
                    //llega al paradero
                    HistorialParadero hpNuevo = new HistorialParadero();
                    hpNuevo.HoraLlegada = DateTime.Now;
                    hpNuevo.TiempoDetenido = new TimeSpan(0, 0, 0);
                    hpNuevo.Orden = ultimoHIV.HistorialParadero.Count + 1;

                    ultimoHIV.HistorialParadero.Add(hpNuevo);
                }
            }

        }

        void ParaderoHistorialNuevoPasajero(Micro _micro)
        {
            //agrega que se subio pasajero en el ultimo historial paradero

            HistorialDiario HDhoy = _micro.HistorialDiario.Where(hd => hd.Fecha == DateTime.Today).FirstOrDefault();
            HistorialIdaVuelta ultimoHIV = HDhoy.HistorialIdaVuelta.OrderBy(h => h.Orden).ToList().Last();
            //el ultimo historial paradero se edita
            try
            {
                HistorialParadero ultimoHP = ultimoHIV.HistorialParadero.OrderBy(h => h.Orden).ToList().Last();
                ultimoHP.PasajerosRecibidos++;
                ultimoHIV.PasajerosTransportados++;
                HDhoy.PasajerosTransportados++;
            }
            catch
            {

            }

        }

        void TerminarParaderoHistorial(Micro _micro)
        {
            //sale del paradero y marca la duracion de cuanto tiempo estuvo en el area

            //tomar el ultimo historial idavuelta (deberia de estar incompleto aun garantizado)
            HistorialDiario HDhoy = _micro.HistorialDiario.Where(hd => hd.Fecha == DateTime.Today).FirstOrDefault();
            HistorialIdaVuelta ultimoHIV = HDhoy.HistorialIdaVuelta.OrderBy(h => h.Orden).ToList().Last();

            //el ultimo historial paradero se edita
            HistorialParadero ultimoHP = ultimoHIV.HistorialParadero.OrderBy(h => h.Orden).ToList().Last();
            ultimoHP.TiempoDetenido = DateTime.Now - ultimoHP.HoraLlegada;
        }


        //POST: odata/Usuarios(5)/DetenerPosicionUpdate
        [HttpPost]
        public IHttpActionResult DetenerPosicionUpdate([FromODataUri] int key)
        {
            Usuario user = db.Usuario.Where(u => u.Id == key).FirstOrDefault();

            user.TransmitiendoPosicion = false;

            if (user.Rol == 1) //chofer
            {
                if (user.MicroChoferId != null)
                {
                    Micro m = user.MicroChofer1.Micro1;
                    m.Coordenada = null;

                    if (m.MicroParaderoId != null)
                    {
                        MicroParadero mp = m.MicroParadero;
                        db.MicroParadero.Remove(mp);

                        for (int i = 0; i < m.MicroPasajero.Count; i++)
                        {
                            db.MicroPasajero.Remove(m.MicroPasajero.ToList()[i]);
                        }
                    }
                }
            }

            if(user.Rol == 0)
            {
                if(user.UsuarioParaderoId != null)
                {
                    UsuarioParadero up = user.UsuarioParadero;

                    db.UsuarioParadero.Remove(up);
                }


                for (int i = 0; i < user.MicroPasajero.Count; i++)
                {
                    db.MicroPasajero.Remove(user.MicroPasajero.ToList()[i]);
                }
            }


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

            if(paradero == null)
            {              
                if(user.UsuarioParaderoId != null) //si resive valores no validos se borra la relacion
                {
                    UsuarioParadero up = user.UsuarioParadero;
                    db.UsuarioParadero.Remove(up);
                    db.SaveChanges();
                }             
                return ("ParaderoNull");
            }

            if (user.UsuarioParaderoId != null)
            {
                UsuarioParadero up = user.UsuarioParadero;

                if(idParadero == up.ParaderoId)
                {
                    //es el mismo paradero actual, se ignora
                    return "mismoParadero";
                }

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




        // Post: odata/Usuarios/Mensaje
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
            string mensaje = "Mi nombre es " + nombre + " y tengo " + edad + " años";

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

            List<Coordenada> coorIda = linea.Ruta.Coordenada.OrderBy(c => c.Orden).ToList();
            List<Coordenada> coorVuelta = linea.Ruta1.Coordenada.OrderBy(c => c.Orden).ToList();

            for (int i = 0; i < coorIda.Count; i++)
            {
                coordenadas.Add(coorIda[i]);
            }

            for (int i = 0; i < coorVuelta.Count; i++)
            {
                coordenadas.Add(coorVuelta[i]);
            }


            return coordenadas;
        }

        public int Clamp(int val, int min, int max)
        {
            if (val < min) return min;
            else if (val > max) return max;
            else return val;
        }

        private double DistanciaVerticesSiguiendoRuta(List<Coordenada> _coorLinea, Coordenada coorInicio, Coordenada coorFinal)
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

        private double DistanciaEntrePuntos(PointLatLng punto1, PointLatLng punto2)
        {

            var sCoord = new GeoCoordinate(punto1.Lat, punto1.Lng);
            var eCoord = new GeoCoordinate(punto2.Lat, punto2.Lng);

            return sCoord.GetDistanceTo(eCoord);
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


        #endregion
    }
}