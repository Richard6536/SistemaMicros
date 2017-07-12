using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosFormsGX.Model
{
    [Table("MicroPasajero")]
    public class MicroPasajero
    {
        [Key]
        public int Id { get; set; }

        public string Estado { get; set; } // Arriba, PosiblePasajero

        public DateTime HoraCreacion { get; set; }
        public double LatitudCreacion { get; set; }
        public double LongitudCreacion { get; set; }

        public int MicroId { get; set; }
        [ForeignKey("MicroId")]
        public virtual Micro Micro { get; set; }

        public int PasajeroId { get; set; }
        [ForeignKey("PasajeroId")]
        public virtual Usuario Pasajero { get; set; }

        public MicroPasajero() { }

    }
}
