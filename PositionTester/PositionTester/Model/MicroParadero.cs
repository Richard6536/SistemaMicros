using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PositionTester.Model
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


        public static Micro GetMicro(int _microParaderoId)
        {
            var BD = new MicroSystemContext();

            MicroParadero microParadero = BD.MicroParaderos.Where(mp => mp.Id == _microParaderoId).FirstOrDefault();

            Micro micro = BD.Micros.Where(m => m.Id == microParadero.MicroId).FirstOrDefault();

            return micro;
        }

        public static Paradero GetParadero(int _microParaderoId)
        {
            var BD = new MicroSystemContext();
            MicroParadero microParadero = BD.MicroParaderos.Where(mp => mp.Id == _microParaderoId).FirstOrDefault();

            Paradero paradero = BD.Paraderos.Where(u => u.Id == microParadero.ParaderoId).FirstOrDefault();

            return paradero;
        }
    }
}
