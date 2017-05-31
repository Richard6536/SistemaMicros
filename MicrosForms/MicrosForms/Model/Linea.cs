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
using MicrosForms.Classes;

using System.Windows.Forms;

namespace MicrosForms.Model
{
    [Table("Linea")]
    public class Linea
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(20, MinimumLength = 1,ErrorMessage = "El nombre debe tener un mínimo de 1 carácter y máximo de 20")]
        [Index("NombreIndex", IsUnique = true)]
        public string Nombre { get; set; }

        public virtual List<Micro> Micros { get; set; }


        public int? RutaIdaId { get; set; }
        public int? RutaVueltaId { get; set; }

        [ForeignKey("RutaIdaId")]
        public virtual Ruta RutaIda { get; set; }
        [ForeignKey("RutaVueltaId")]
        public virtual Ruta RutaVuelta { get; set; }

        public virtual List<Ruta> Rutas { get; set; }


        public Linea() { }


        public static Linea CrearLinea(string _nombre)
        {
            try
            {
                var BD = new MicroSystemContext();

                Linea nuevaLinea = new Linea();

                nuevaLinea.Nombre = _nombre;
                nuevaLinea.Micros = new List<Micro>();
                nuevaLinea.Rutas = new List<Ruta>();


                BD.Lineas.Add(nuevaLinea);

                try
                {
                    BD.SaveChanges();
                    return nuevaLinea;
                }
                catch (DbEntityValidationException ex)
                {
                    string mensaje = "errores \n";

                    foreach (var error in ex.EntityValidationErrors.First().ValidationErrors)
                    {
                        mensaje += error.ErrorMessage + "\n";
                    }

                    MessageBox.Show(mensaje);

                    return null;
                }
                catch (DbUpdateException ex)
                {
                    //MessageBox.Show("El nombre de línea ya existe.");
                    MessageBox.Show(ex.Message);
                    
                    return null;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Imposible completar operación");
                    return null;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error creando la línea");
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static bool EditarNombre(int _idLinea, string _nuevoNombre)
        {
            var BD = new MicroSystemContext();

            Linea linea = BD.Lineas.Where(l => l.Id == _idLinea).FirstOrDefault();
            linea.Nombre = _nuevoNombre;

            try
            {
                BD.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                string mensaje = "Se encontraron los siguientes errores:";

                foreach (var error in ex.EntityValidationErrors.First().ValidationErrors)
                {
                    mensaje += "\n"+error.ErrorMessage;
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
                Debug.WriteLine("Imposible completar operación");
                return false;
            }
        }


        public static List<Linea> ObtenerTodasLasLineas()
        {
            var BD = new MicroSystemContext();

            var lineas = BD.Lineas.ToList();

            return lineas;
        }

        public static Linea BuscarLinea(int _id)
        {
            var BD = new MicroSystemContext();

            Linea linea = BD.Lineas.Where(l => l.Id == _id).FirstOrDefault();

            return linea;
        }

        public static Linea BuscarLineaPorNombre(string _nombre)
        {
            var BD = new MicroSystemContext();

            Linea linea = BD.Lineas.Where(l => l.Nombre == _nombre).FirstOrDefault();

            return linea;
        }

        public static List<Ruta> ObtenerRutasPorTipo(int _idLinea, Ruta.TipoRuta _tipo)
        {
            var BD = new MicroSystemContext();

            Linea linea = BD.Lineas.Where(l => l.Id == _idLinea).FirstOrDefault();
            List<Ruta> rutasPorTipo = new List<Ruta>();

            foreach(Ruta r in linea.Rutas)
            {
                if(r.TipoDeRuta == _tipo)
                {
                    rutasPorTipo.Add(r);
                }
            }

            rutasPorTipo.OrderBy(r => r.Nombre);
            return rutasPorTipo;

        }

        public static List<Ruta> ObtenerTodasLasRutas(int _idLinea)
        {
            var BD = new MicroSystemContext();

            Linea linea = BD.Lineas.Where(l => l.Id == _idLinea).FirstOrDefault();
            List<Ruta> todas = linea.Rutas;

            return todas;
        }

        public static List<Micro> ObtenerMicrosDeLinea(int _idLinea)
        {
            var BD = new MicroSystemContext();

            Linea linea = BD.Lineas.Where(l => l.Id == _idLinea).FirstOrDefault();
            List<Micro> micros = linea.Micros;

            return micros;
        }

        public static List<Usuario> ObtenerChoferes(int _idLinea)
        {
            var BD = new MicroSystemContext();

            Linea linea = BD.Lineas.Where(l => l.Id == _idLinea).FirstOrDefault();

            List<Usuario> choferes = new List<Usuario>();

            foreach(Micro m in linea.Micros)
            {
                if(m.MicroChofer != null)
                {
                    choferes.Add(m.MicroChofer.Chofer);
                }
            }

            return choferes;
        }

        public static void EliminarLinea(int _idLinea)
        {
            //asumiendo que no hay rutas asociadas
            var BD = new MicroSystemContext();

            Linea linea = BD.Lineas.Where(l => l.Id == _idLinea).FirstOrDefault();
            List<Ruta> rutas = new List<Ruta>();

            foreach(Ruta r in linea.Rutas)
            {
                rutas.Add(r);
            }

            for (int i = 0; i < rutas.Count; i++)
            {
                Ruta rutaActual = rutas[i];
                Coordenada coordenda = BD.Coordenadas.Where(c => c.Id == rutaActual.InicioId).FirstOrDefault();

                Coordenada.BorrarCadenaDeCoordenadas(coordenda, BD);
            }

            BD.SaveChanges();

            BD.Lineas.Remove(linea);

            BD.SaveChanges();
        }
    }
}
