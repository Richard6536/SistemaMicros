 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosForms.Model
{
    [Table("Linea")]
    public class Linea
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public virtual List<Micro> Micros { get; set; }

        public int RutaInicioId { get; set; }
        [ForeignKey("RutaInicioId")]
        public virtual Ruta RutaInicio { get; set; }

        public int RutaFinId { get; set; }
        [ForeignKey("RutaFinId")]
        public virtual Ruta RutaFin { get; set; }


    }
}
