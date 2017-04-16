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

namespace MicrosForms.Model
{
    [Table("Ruta")]
    public class Ruta
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(25, MinimumLength = 3,ErrorMessage ="El nombre debe tener un mínimo de 3 carácteres y máximo de 25")]
        public string Nombre { get; set; }

        public virtual List<Paradero> Paraderos { get; set; }

        public int InicioId { get; set; }
        public int? LineaId { get; set; }

        [ForeignKey("InicioId")]
        public virtual Coordenada Coordenada { get; set; }
        [ForeignKey("LineaId")]
        public virtual Linea Linea { get; set; }

        public Ruta() { }

        public static bool CrearRuta(string _nombre, List<Coordenada> _vertices, List<Paradero> _paraderos)
        {

            var BD = new MicroSystemContext();

            Ruta nuevaRuta = new Ruta();

            foreach (Paradero p in _paraderos)
            {
                p.Ruta = nuevaRuta;
                BD.Paraderos.Add(p);
            }

            nuevaRuta.Nombre = _nombre;
            nuevaRuta.Coordenada = _vertices[0];
            nuevaRuta.Paraderos = _paraderos;

            for (int i = 1; i < _vertices.Count; i++)
            {
                BD.Coordenadas.Add(_vertices[i]);
            }

            BD.Rutas.Add(nuevaRuta);

            try
            {
                BD.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string mensaje = "errores \n";

                foreach (var error in ex.EntityValidationErrors.First().ValidationErrors)
                {
                    mensaje += error.ErrorMessage + "\n";
                }
                MessageBox.Show(mensaje);

                return false;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public static List<Ruta> BuscarTodasLasRutas()
        {
            var BD = new MicroSystemContext();

            List<Ruta> rutas = BD.Rutas.ToList();

            return rutas;
        }

        public static Ruta BuscarPorId(int _id)
        {
            var BD = new MicroSystemContext();

            Ruta ruta = BD.Rutas.Where(r => r.Id == _id).FirstOrDefault();

            return ruta;
        }

        public static Ruta BuscarRutaPorNombre(string _nombre)
        {
            var BD = new MicroSystemContext();

            Ruta ruta = BD.Rutas.Where(r => r.Nombre == _nombre).FirstOrDefault();

            return ruta;
        }

        public static List<Paradero> ObtenerParaderosDeRuta(Ruta _ruta)
        {
            var BD = new MicroSystemContext();

            List<Paradero> paraderos = _ruta.Paraderos.ToList();

            return paraderos;
        }

        public static List<Coordenada> ObtenerVerticesDeInicioAFin(Ruta _ruta)
        {
            var BD = new MicroSystemContext();

            List<Coordenada> vertices = new List<Coordenada>();

            Coordenada actual = _ruta.Coordenada;

            vertices.Add(actual);

            while(actual != null)
            {
                vertices.Add(actual);
                actual = actual.Siguiente;
            }

            return vertices;
        }

    }
}
