using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosForms.Model
{
    [Table("Paradero")]
    class Paradero
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public float Latitud { get; set; }
        [Required]
        public float Longitud { get; set; }

        public virtual List<Recorrido> Recorridos { get; set; }
        public virtual List<Usuario> Usuarios { get; set; }
        public virtual List<Micro> Micros { get; set; }
    }
}
