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
    class Linea
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }

        public virtual List<Micro> Micros { get; set; }
    }
}
