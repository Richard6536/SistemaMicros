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
using MicrosFormsGX.Classes;

namespace MicrosFormsGX.Model
{
    [Table("HistorialParadero")]
    public class HistorialParadero
    {
        [Key]
        public int Id { get; set; }

        public int Orden { get; set; }

        public DateTime HoraLlegada { get; set; }

        public TimeSpan TiempoDetenido { get; set; }

        public int PasajerosRecibidos { get; set; }


        public int IdIdaVuelta { get; set; }
        [ForeignKey("IdIdaVuelta")]
        public virtual HistorialIdaVuelta HistorialIdaVuelta { get; set; }

        public HistorialParadero()
        {

        }

    }
}
