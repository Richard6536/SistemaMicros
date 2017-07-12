using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosFormsGX.Model
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

        public static Micro GetMicro(int _MicroChoferId)
        {
            var BD = new MicroSystemContext();

            MicroChofer microChofer = BD.MicroChoferes.Where(mc => mc.Id == _MicroChoferId).FirstOrDefault();

            Micro micro = BD.Micros.Where(m => m.Id == microChofer.MicroId).FirstOrDefault();

            return micro;
        }

        public static Usuario GetChofer(int _MicroChoferId)
        {
            var BD = new MicroSystemContext();
            MicroChofer microChofer = BD.MicroChoferes.Where(mc => mc.Id == _MicroChoferId).FirstOrDefault();
            Usuario chofer = BD.Usuarios.Where(u => u.Id == microChofer.ChoferId).FirstOrDefault();

            return chofer;
        }
    }
}
