using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosForms.Model
{
    [Table("Coordenada")]
    public class Coordenada
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Latitud { get; set; }
        [Required]
        public double Longitud { get; set; }

        public int? RutaId { get; set; }

        [ForeignKey("RutaId")]
        public virtual Ruta Ruta { get; set; }



        public static Coordenada BuscarCoordenada(int _id)
        {
            var BD = new MicroSystemContext();
            var coordenada = BD.Coordenadas.Where(
                    coornedada =>
                               coornedada.Id == _id).FirstOrDefault(); 
            return coordenada;

        }
    }
}
