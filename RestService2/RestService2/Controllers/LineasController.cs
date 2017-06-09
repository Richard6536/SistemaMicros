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
        private MicroSystemDBEntities6 db = new MicroSystemDBEntities6();

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
                    choferesActivos.Add(microsLinea[i].MicroChofer.Usuario);
                }
            }

            return choferesActivos;         
        }

        //POST: odata/Lineas/RecomendarRuta
        //Parametros: latInicio,lngInicio, latFinal,lngFinal

        [HttpPost]
        public List<Coordenada> RecomendarRuta(ODataActionParameters parameters)
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

            //Recorrer cada linea y por cada linea

            //Desde punto inicio generar ruta a cada paradero
            //Desde punto final generar ruta a cada paradero
            //Seleccionar el de distancia menor en cada caso
            //recorriendo la ruta se calcula la distancia desde ese paradero al otro 
            //Se descarta si estan en direccion contraria en la que se dirige la ruta
            //Se suman distancia inicio al paradero + final al paradero + distancia entre paraderos siguiendo la ruta

            //Se debe obtener la distancia menor y recomendar la linea con esa id
            //y retornar la suma de esas 3 partes de la ruta para resaltarla






            return vertices;
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




        #endregion
    }
}
