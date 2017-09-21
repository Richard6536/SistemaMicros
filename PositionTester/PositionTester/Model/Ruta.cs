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
using System.Windows.Forms;

namespace PositionTester.Model
{
    [Table("Ruta")]
    public class Ruta
    {
        public enum TipoRuta { ida, vuelta }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(30, MinimumLength = 3, ErrorMessage = "El email debe tener un mínimo de 3 carácteres y un máximo de 30")]
        public string Nombre { get; set; }

        [Required]
        public TipoRuta TipoDeRuta { get; set; }

        public virtual List<Paradero> Paraderos { get; set; }
        public virtual List<Coordenada> Coordenadas { get; set; }

        public int LineaId { get; set; }

        [ForeignKey("LineaId")]
        public virtual Linea Linea { get; set; }

        public Ruta() { }



        public void AsignarRutaComoUsable()
        {
            var BD = new MicroSystemContext();

            Ruta ruta = BD.Rutas.Where(r => r.Id == Id).FirstOrDefault();
            Linea linea = BD.Lineas.Where(l => l.Id == ruta.LineaId).FirstOrDefault();

            if(ruta.TipoDeRuta == TipoRuta.ida)
            {
                linea.RutaIda = ruta;
            }
            else if(ruta.TipoDeRuta == TipoRuta.vuelta)
            {
                linea.RutaVuelta = ruta;
            }

            BD.SaveChanges();
        }

        public static List<Ruta> BuscarTodasLasRutas()
        {
            var BD = new MicroSystemContext();

            List<Ruta> rutas = BD.Rutas.ToList();

            return rutas;
        }

        public static List<Ruta> BuscarTodasLasRutasSinLinea()
        {
            var BD = new MicroSystemContext();

            List<Ruta> rutas = new List<Ruta>();

            foreach(Ruta r in BD.Rutas.ToList())
            {
                if(r.Linea == null)
                {
                    rutas.Add(r);
                }
            }

            return rutas;
        }

        public static Ruta BuscarPorId(int _id)
        {
            var BD = new MicroSystemContext();

            Ruta ruta = BD.Rutas.Where(r => r.Id == _id).FirstOrDefault();

            return ruta;
        }

        public static Ruta BuscarPorNombre(string _nombre)
        {
            var BD = new MicroSystemContext();

            Ruta ruta = BD.Rutas.Where(r => r.Nombre == _nombre).FirstOrDefault();

            return ruta;
        }

        

        public static List<Paradero> ObtenerParaderosRuta(Ruta _ruta)
        {
            var DB = new MicroSystemContext();

            Ruta ruta = DB.Rutas.Where(r => r.Id == _ruta.Id).FirstOrDefault();

            List<Paradero> paraderos = ruta.Paraderos;

            return paraderos;
        }


    }
}
