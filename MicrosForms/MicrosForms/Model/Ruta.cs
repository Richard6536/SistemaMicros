using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosForms.Model
{
    [Table("Ruta")]
    public class Ruta
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20), MinLength(4)]
        public string Nombre { get; set; }

        public virtual List<Paradero> Paraderos { get; set; }

        public int InicioId { get; set; }
        public int LineaId { get; set; }

        [ForeignKey("InicioId")]
        public virtual Coordenada Coordenada { get; set; }
        [ForeignKey("LineaId")]
        public virtual Linea Linea { get; set; }

    }
}
