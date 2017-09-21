using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Windows.Forms;

namespace PositionTester.Model
{
    [Table("Paradero")]
    public class Paradero
    {
        [Key]
        public int Id { get; set; }

        public int Orden { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public int RutaId { get; set; }
        public int CoordenadaId { get; set; }

        [ForeignKey("RutaId")]
        public virtual Ruta Ruta { get; set; }

        [ForeignKey("CoordenadaId")]
        public virtual Coordenada Coordenada { get; set; }

        public virtual List<UsuarioParadero> UsuariosParaderos { get; set; }
        public virtual List<MicroParadero> MicrosParaderos { get; set; }

        public Paradero() { }


        public static Paradero BuscarPorId(int _id)
        {
            var BD = new MicroSystemContext();

            Paradero paraderoBuscado = BD.Paraderos.Where(p => p.Id == _id).FirstOrDefault();

            return paraderoBuscado;
        }
        
    }
}
