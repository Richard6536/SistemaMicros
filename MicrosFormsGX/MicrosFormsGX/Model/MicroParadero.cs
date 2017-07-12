using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosFormsGX.Model
{
    [Table("MicroParadero")]
    public class MicroParadero
    {
        [Key]
        public int Id { get; set; }

        public double DistanciaEntre { get; set; }

        public int ParaderoId { get; set; }
        [ForeignKey("ParaderoId")]
        public virtual Paradero Paradero { get; set; }

        public int MicroId { get; set; }
        [ForeignKey("MicroId")]
        public virtual Micro Micro { get; set; }

        public MicroParadero() { }
    }
}
