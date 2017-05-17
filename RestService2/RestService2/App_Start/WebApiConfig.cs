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

            #region Usuario
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

            ActionConfiguration obtenerMicro = builder.Entity<Usuario>().Action("ObtenerMicro");
            obtenerMicro.ReturnsFromEntitySet<Micro>("Micros");

            ActionConfiguration seleccionarParadero = builder.Entity<Usuario>().Action("SeleccionarParadero");
            seleccionarParadero.Returns<IHttpActionResult>();
            seleccionarParadero.Parameter<int>("IdParadero");

            ActionConfiguration deseleccionarParadero = builder.Entity<Usuario>().Action("DeseleccionarParadero");
            deseleccionarParadero.Returns<IHttpActionResult>();

            #endregion

            #region Ruta

            ActionConfiguration listaCoordenadas = builder.Entity<Ruta>().Action("ListaCoordenadas");
            listaCoordenadas.ReturnsCollectionFromEntitySet<Coordenada>("Coordenadas");

            #endregion

            #region Paradero

            ActionConfiguration usuariosSelecionaron = builder.Entity<Paradero>().Action("UsuariosQueSeleccionaron");
            usuariosSelecionaron.ReturnsCollectionFromEntitySet<Usuario>("Usuarios");

            ActionConfiguration microsSeleccionaron = builder.Entity<Paradero>().Action("MicrosQueSeleecionaron");
            microsSeleccionaron.ReturnsCollectionFromEntitySet<Micro>("Micros");

            #endregion

            #region Micro

            ActionConfiguration microPosicion = builder.Entity<Micro>().Action("ObtenerPosicion");
            microPosicion.Returns<Posicion>();

            ActionConfiguration microSeleccionParadero = builder.Entity<Micro>().Action("SeleccionarParadero");
            microSeleccionParadero.Returns<IHttpActionResult>();
            microSeleccionParadero.Parameter<int>("IdParadero");

            ActionConfiguration microDeseleccionParadero = builder.Entity<Micro>().Action("DeseleccionarParadero");
            microDeseleccionParadero.Returns<IHttpActionResult>();

            ActionConfiguration nuevaCalificacion = builder.Entity<Micro>().Action("NuevaCalificacion");
            nuevaCalificacion.Returns<float>();
            nuevaCalificacion.Parameter<int>("Calificacion");

            #endregion


            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
