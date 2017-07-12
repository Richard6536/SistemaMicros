using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PositionTester.Model
{
    [Table("UsuarioParadero")]
    public class UsuarioParadero
    {
        [Key]
        public int Id { get; set; }

        public int ParaderoId { get; set; }
        [ForeignKey("ParaderoId")]
        public virtual Paradero Paradero { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        public UsuarioParadero() { }
    }
}
