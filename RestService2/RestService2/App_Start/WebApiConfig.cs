using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using RestService2.Models;


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


            ActionConfiguration mensaje = builder.Entity<Usuario>().Collection.Action("Mensaje");
            mensaje.Returns<string>();


            ActionConfiguration mensajeParametros = builder.Entity<Usuario>().Collection.Action("MensajeParametros");
            mensajeParametros.Returns<string>();
            mensajeParametros.Parameter<int>("Edad");
            mensajeParametros.Parameter<string>("Nombre");

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
