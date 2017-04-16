using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosForms.Model
{
    [Table("Micro")]
    public class Micro
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(6, ErrorMessage = "La patente debe tener un tamaño de 6 carácteres")]
        public string Patente { get; set; }

        [Required]
        public int Calificacion { get; set; }
        
        public int? LineaId { get; set; }

        public int? MicroParaderoId { get; set; }
        public int? MicroChoferId { get; set; }

        
        [ForeignKey("LineaId")]
        public virtual Linea Linea { get; set; }

        [ForeignKey("MicroParaderoId")]
        public virtual MicroParadero MicroParadero { get; set; }

        [ForeignKey("MicroChoferId")]
        public virtual MicroChofer MicroChofer { get; set; }

        public Micro() { }
    }
}
