using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosFormsGX.Model.DatosTemporales
{
    public class RutaTP
    {
        public static List<RutaTP> todasRutas = new List<RutaTP>();

        public int Id { get; set; }
        public string Nombre { get; set; }
        public Ruta.TipoRuta TipoRuta { get; set; }

        public int LineaId { get; set; }

        public List<Paradero> Paraderos { get; set; }
        public List<Coordenada> listaCoordenadas { get; set; }
    }
}
