using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

using System.Diagnostics;


namespace MicrosFormsGX.Model
{
    [Table("Coordenada")]
    public class Coordenada
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Orden { get; set; }

        [Required]
        public double Latitud { get; set; }
        [Required]
        public double Longitud { get; set; }

        public Coordenada() { }

        public Coordenada(double _lat, double _lng, int _orden)
        {
            Latitud = _lat;
            Longitud = _lng;
            Orden = _orden;
        }


        public static Coordenada BuscarPorId(int _id)
        {
            var BD = new MicroSystemContext();

            Coordenada coordenada = BD.Coordenadas.Where(c => c.Id == _id).FirstOrDefault();

            return coordenada;
        }

    }
}
