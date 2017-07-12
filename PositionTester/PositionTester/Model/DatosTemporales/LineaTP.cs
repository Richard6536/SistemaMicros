using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionTester.Model.DatosTemporales
{
    public class LineaTP
    {
        public static List<LineaTP> todasLineas = new List<LineaTP>();

        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Micro> Micros { get; set; }

        public RutaTP rutaIda { get; set; }
        public RutaTP rutaVuelta { get; set; }

        public List<RutaTP> rutasDeLinea { get; set; }

        public List<RutaTP> ObtenerRutasPorTipo(Ruta.TipoRuta _tipo)
        {
            List<RutaTP> rutas = new List<RutaTP>();

            foreach (RutaTP r in rutasDeLinea)
            {
                if (r.TipoRuta == _tipo)
                {
                    rutas.Add(r);
                }
            }
            return rutas;
        }
    }
}
