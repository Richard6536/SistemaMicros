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
using MicrosForms.Classes;

namespace MicrosForms.Model
{
    [Table("HistorialIdaVuelta")]
    public class HistorialIdaVuelta
    {
        [Key]
        public int Id { get; set; }

        public int PasajerosTransportados { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraTermino { get; set; }

        public TimeSpan DuracionRecorrido { get; set; }



    }
}
