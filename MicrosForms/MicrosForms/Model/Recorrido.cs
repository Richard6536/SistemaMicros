using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosForms.Model
{
    [Table("Recorrido")]
    public class Recorrido
    {
        [Key]
        public int Id { get; set; }

        public int? LineaId { get; set; }
        public int? RutaIdaId { get; set; }
        public int? RutaVueltaId { get; set; }

        [ForeignKey("LineaId")]
        public virtual Linea Linea { get; set; }
        [ForeignKey("RutaIdaId")]
        public virtual Ruta RutaIda { get; set; }
        [ForeignKey("RutaVueltaId")]
        public virtual Ruta RutaVuelta { get; set; }

        public virtual List<Paradero> Paraderos { get; set; }
    }
}
