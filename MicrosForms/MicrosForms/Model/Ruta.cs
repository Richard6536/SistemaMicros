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

        public int RecorridoId { get; set; }

        public virtual List<Coordenada> Vertices { get; set; }

        [ForeignKey("RecorridoId")]
        public virtual Recorrido Recorrido { get; set; }

    }
}
