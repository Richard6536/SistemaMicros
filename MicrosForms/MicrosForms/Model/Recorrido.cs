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
    class Recorrido
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(4), MaxLength(20)]
        public string RutaIda { get; set; }

        [Required, MinLength(4), MaxLength(20)]
        public string RutaVuelta { get; set; }

        public virtual List<Paradero> Paraderos { get; set; }
    }
}
