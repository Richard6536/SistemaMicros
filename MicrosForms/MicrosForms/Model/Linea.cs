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
        [Key, ForeignKey("Recorrido")]
        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }

        public int RecorridoId { get; set; }

        [ForeignKey("RecorridoId")]
        public virtual Recorrido Recorrido { get; set; }

        public virtual List<Micro> Micros { get; set; }
    }
}
