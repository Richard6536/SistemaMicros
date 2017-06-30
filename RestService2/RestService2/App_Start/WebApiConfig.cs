using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using RestService2.Models;
using RestService2.Classes;


namespace RestService2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();


            builder.EntitySet<Usuario>("Usuarios");
            builder.EntitySet<MicroChofer>("MicroChoferes");
            builder.EntitySet<UsuarioParadero>("UsuarioParaderos");
            builder.EntitySet<MicroParadero>("MicroParaderos");
            builder.EntitySet<Ruta>("Rutas");
            builder.EntitySet<Coordenada>("Coordenadas");
            builder.EntitySet<Linea>("Lineas");
            builder.EntitySet<Paradero>("Paraderos");
            builder.EntitySet<Micro>("Micros");
            builder.EntitySet<HistorialDiario>("HistorialesDiarios");
            builder.EntitySet<HistorialIdaVuelta>("HistorialesIdaVuelta");
            builder.EntitySet<HistorialParadero>("HistorialesParaderos");
            builder.EntitySet<MicroPasajero>("MicroPasajeros");

            #region Usuario
            ActionConfiguration mensajeNormal = builder.Entity<Usuario>().Collection.Action("Mensaje");
            mensajeNormal.Returns<string>();

            ActionConfiguration mensajeParametros = builder.Entity<Usuario>().Collection.Action("MensajeParametros");
            mensajeParametros.Returns<string>();
            mensajeParametros.Parameter<int>("Edad");
            mensajeParametros.Parameter<string>("Nombre");

            ActionConfiguration esValido = builder.Entity<Usuario>().Collection.Action("EsValido");
            esValido.ReturnsFromEntitySet<Usuario>("Usuarios");
            esValido.Parameter<string>("Email");
            esValido.Parameter<string>("Password");

            ActionConfiguration editarDatos = builder.Entity<Usuario>().Action("EditarDatos");
            editarDatos.Returns<IHttpActionResult>();
            editarDatos.Parameter<string>("Nombre");
            editarDatos.Parameter<string>("Password");

            ActionConfiguration existeMail = builder.Entity<Usuario>().Collection.Action("ExisteMail");
            existeMail.Returns<bool>();
            existeMail.Parameter<string>("Email");

            ActionConfiguration actualizarPosicion = builder.Entity<Usuario>().Action("ActualizarPosicion");
            actualizarPosicion.Returns<IHttpActionResult>();
            actualizarPosicion.Parameter<double>("Latitud");
            actualizarPosicion.Parameter<double>("Longitud");

            ActionConfiguration detenerPosicion = builder.Entity<Usuario>().Action("DetenerPosicionUpdate");
            detenerPosicion.Returns<IHttpActionResult>();

            ActionConfiguration obtenerMicro = builder.Entity<Usuario>().Action("ObtenerMicro");
            obtenerMicro.ReturnsFromEntitySet<Micro>("Micros");

            ActionConfiguration seleccionarParadero = builder.Entity<Usuario>().Action("SeleccionarParaderoDX");
            seleccionarParadero.Returns<string>();
            seleccionarParadero.Parameter<int>("IdParadero");

            ActionConfiguration deseleccionarParadero = builder.Entity<Usuario>().Action("DeseleccionarParadero");
            deseleccionarParadero.Returns<IHttpActionResult>();

            ActionConfiguration obtenerPosUsuario = builder.Entity<Usuario>().Action("ObtenerPosicion");
            obtenerPosUsuario.Returns<Posicion>();

            #endregion

            #region Ruta

            ActionConfiguration listaCoordenadas = builder.Entity<Ruta>().Action("ListaCoordenadas");
            listaCoordenadas.ReturnsCollectionFromEntitySet<Coordenada>("Coordenadas");

            #endregion

            #region Paradero

            ActionConfiguration usuariosSelecionaron = builder.Entity<Paradero>().Action("UsuariosQueSeleccionaron");
            usuariosSelecionaron.ReturnsCollection<UsuarioParaderoDeluxe>();

            ActionConfiguration microMasCercana = builder.Entity<Paradero>().Action("MicroParaderoMasCercano");
            microMasCercana.ReturnsFromEntitySet<MicroParadero>("MicroParaderos");

            #endregion

            #region Micro

            ActionConfiguration iniciarRecorrido = builder.Entity<Micro>().Action("IniciarRecorrido");
            iniciarRecorrido.Returns<IHttpActionResult>();

            ActionConfiguration detenerRecorrido = builder.Entity<Micro>().Action("DetenerRecorrido");
            detenerRecorrido.Returns<IHttpActionResult>();

            ActionConfiguration microSeleccionParadero = builder.Entity<Micro>().Action("SeleccionarParadero");
            microSeleccionParadero.Returns<IHttpActionResult>();
            microSeleccionParadero.Parameter<int>("IdParadero");

            ActionConfiguration microDeseleccionParadero = builder.Entity<Micro>().Action("DeseleccionarParadero");
            microDeseleccionParadero.Returns<IHttpActionResult>();

            ActionConfiguration nuevaCalificacion = builder.Entity<Micro>().Action("NuevaCalificacion");
            nuevaCalificacion.Returns<float>();
            nuevaCalificacion.Parameter<int>("Calificacion");

            ActionConfiguration obtenerMiParadero = builder.Entity<Micro>().Action("ObtenerMiParadero");
            obtenerMiParadero.ReturnsCollectionFromEntitySet<Paradero>("Paraderos");

            ActionConfiguration obtenerHistoriales = builder.Entity<Micro>().Action("ObtenerHistorialesDiarios");
            obtenerHistoriales.ReturnsCollectionFromEntitySet<HistorialDiario>("HistorialesDiarios");

            #endregion

            #region Linea
            ActionConfiguration choferesActivos = builder.Entity<Linea>().Action("ObtenerChoferes");
            choferesActivos.ReturnsCollectionFromEntitySet<Usuario>("Usuarios");

            ActionConfiguration recRuta = builder.Entity<Linea>().Collection.Action("RecomendarRutaDX");
            recRuta.Parameter<double>("latInicio");
            recRuta.Parameter<double>("lngInicio");
            recRuta.Parameter<double>("latFinal");
            recRuta.Parameter<double>("lngFinal");
            recRuta.ReturnsCollectionFromEntitySet<Coordenada>("Coordenadas");
            #endregion

            #region Historiales

            ActionConfiguration obtHistorialIdaVuelta = builder.Entity<HistorialDiario>().Action("ObtenerHistorialesIdaVuelta");
            obtHistorialIdaVuelta.ReturnsCollectionFromEntitySet<HistorialIdaVuelta>("HistorialesIdaVuelta");

            ActionConfiguration obtHistoralParadero = builder.Entity<HistorialIdaVuelta>().Action("ObtenerHistorialesParaderos");
            obtHistoralParadero.ReturnsCollectionFromEntitySet<HistorialParadero>("HistorialesParaderos");

            #endregion

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
