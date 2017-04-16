using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosForms.Model
{
    [Table("MicroChofer")]
    public class MicroChofer
    {
        [Key]
        public int Id { get; set; }


        public int MicroId { get; set; }
        [ForeignKey("MicroId")]
        public virtual Micro Micro { get; set; }

        public int ChoferId { get; set; }
        [ForeignKey("ChoferId")]
        public virtual Usuario Chofer { get; set; }

        public MicroChofer() { }
    }
}
