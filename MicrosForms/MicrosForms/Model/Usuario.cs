using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosForms.Model
{
    [Table("Usuario")]
    public class Usuario
    {

        public enum RolUsuario { normal, chofer, admin }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(20), MinLength(4), Index("NombreIndex", IsUnique = true)]
        public string Nombre { get; set; }

        [Required, StringLength(20), MinLength(4)]
        public string Password { get; set; }

        [Required]
        public Coordenada Posicion { get; set; }

        [Required]
        public RolUsuario Rol { get; set; }

        public int? MicroId { get; set; }
        public int? ParaderoSelectedId { get; set; }

        [ForeignKey("MicroId")]
        public virtual Micro Micro { get; set; }
        [ForeignKey("ParaderoSelectedId")]
        public virtual Paradero ParaderoSelected { get; set; }



    }
}
