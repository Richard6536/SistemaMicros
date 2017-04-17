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
        public virtual Coordenada Inicio { get; set; }
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
            nuevaRuta.Inicio = _vertices[0];
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

            Coordenada actual = _ruta.Inicio;

            vertices.Add(actual);

            while(actual != null)
            {
                vertices.Add(actual);
                actual = actual.Siguiente;
            }

            return vertices;
        }

        public static bool EditarRuta(Ruta _ruta, string _nombre, List<Coordenada> _vertices, List<Paradero> _paraderos, bool sobreEscribirVertices)
        {
            var BD = new MicroSystemContext();

            Ruta _rutaBD = BD.Rutas.Where(r => r.Id == _ruta.Id).FirstOrDefault();

            
            if (sobreEscribirVertices)
            {
                //Se registra el inicio antiguo y se asocian los nuevos vertices con la ruta
                Coordenada inicioAntiguo = _rutaBD.Inicio;
                _rutaBD.Inicio = _vertices[0];

                for (int i = 1; i < _vertices.Count; i++)
                {
                    BD.Coordenadas.Add(_vertices[i]);
                }

                //Se borran las coordenadas antiguas
                List<Coordenada> aBorrar = new List<Coordenada>();
                Coordenada actual = BD.Coordenadas.Where(c => c.Id == inicioAntiguo.Id).FirstOrDefault();

                while (actual != null)
                {
                    aBorrar.Add(actual);
                    actual = actual.Siguiente;
                }

                foreach (Coordenada c in aBorrar)
                {
                    BD.Coordenadas.Remove(c);
                }

            }

            #region BORRAR PARADEROS ANTIGUOS

            List<Paradero> paraderosAntiguos = new List<Paradero>();
            foreach (Paradero p in _rutaBD.Paraderos)
            {
                paraderosAntiguos.Add(p);
            }
            foreach (Paradero pa in paraderosAntiguos)
            {
                BD.Paraderos.Remove(pa);
            }

            #endregion


            foreach (Paradero p in _paraderos)
            {
                p.Ruta = _rutaBD;
                BD.Paraderos.Add(p);
            }
            _rutaBD.Nombre = _nombre;


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
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;

        }

        public static bool EliminarRuta(int _id)
        {
            try
            {
                var BD = new MicroSystemContext();

                Ruta rutaABorrar = BD.Rutas.Where(r => r.Id == _id).FirstOrDefault();

                #region BORRADO DE COORDENADAS

                List<Coordenada> aBorrar = new List<Coordenada>();
                Coordenada actual = BD.Coordenadas.Where(c => c.Id == rutaABorrar.InicioId).FirstOrDefault();

                while (actual != null)
                {
                    aBorrar.Add(actual);
                    actual = actual.Siguiente;
                }

                foreach (Coordenada c in aBorrar)
                {
                    BD.Coordenadas.Remove(c);
                }
                #endregion

                BD.Rutas.Remove(rutaABorrar);

                BD.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

            
        }

    }
}
