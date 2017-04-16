using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;


namespace MicrosForms.Model
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


    }
}
