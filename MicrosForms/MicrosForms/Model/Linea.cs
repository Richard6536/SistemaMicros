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

        [Required, StringLength(20, MinimumLength = 3,ErrorMessage = "El nombre debe tener un mínimo de 3 carácteres y máximo de 20")]
        public string Nombre { get; set; }

        public virtual List<Micro> Micros { get; set; }

        public int RutaInicioId { get; set; }
        [ForeignKey("RutaInicioId")]
        public virtual Ruta RutaInicio { get; set; }

        public int RutaFinId { get; set; }
        [ForeignKey("RutaFinId")]
        public virtual Ruta RutaFin { get; set; }

        public Linea() { }


    }
}
