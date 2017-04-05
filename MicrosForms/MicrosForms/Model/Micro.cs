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
    class Micro
    {
        [Key, ForeignKey("Usuario")]
        public int Id { get; set; }

        [Required, MaxLength(6), MinLength(6)]
        public string Patente { get; set; }

        [Required]
        public int Clasificacion { get; set; }

        public int? UserId { get; set; }
        public int? LineaId { get; set; }
        public int? SigParaderoId { get; set; }


        [ForeignKey("UserId")]
        public virtual Usuario Usuario { get; set; }
        [ForeignKey("LineaId")]
        public virtual Linea Linea { get; set; }
        [ForeignKey("SigParaderoId")]
        public virtual Paradero SigParadero { get; set; }

    }
}
