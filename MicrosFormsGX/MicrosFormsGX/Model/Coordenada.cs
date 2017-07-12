using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

using System.Diagnostics;


namespace MicrosFormsGX.Model
{
    [Table("Coordenada")]
    public class Coordenada
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Latitud { get; set; }
        [Required]
        public double Longitud { get; set; }

        public int? SiguienteCoordenadaId { get; set; }

        [ForeignKey("SiguienteCoordenadaId")]
        public virtual Coordenada Siguiente { get; set; }

        public Coordenada() { }

        public Coordenada(double _lat, double _lng, Coordenada _sigVertice)
        {
            Latitud = _lat;
            Longitud = _lng;
            Siguiente = _sigVertice;
        }

        public static void BorrarCadenaDeCoordenadas(Coordenada _coordenada, MicroSystemContext _BD)
        {
            List<Coordenada> aBorrar = new List<Coordenada>();

            Coordenada actual = _coordenada;

            while (actual != null)
            {
                aBorrar.Add(actual);
                actual = actual.Siguiente;
            }

            foreach (Coordenada c in aBorrar)
            {
                _BD.Coordenadas.Remove(c);
            }

            _BD.SaveChanges();
        }

        public static Coordenada BuscarPorId(int _id)
        {
            var BD = new MicroSystemContext();

            Coordenada coordenada = BD.Coordenadas.Where(c => c.Id == _id).FirstOrDefault();

            return coordenada;
        }

    }
}
