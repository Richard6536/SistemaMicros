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

        public int RutaInicioId { get; set; }
        [ForeignKey("RutaInicioId")]
        public virtual Ruta RutaInicio { get; set; }

        public int RutaFinId { get; set; }
        [ForeignKey("RutaFinId")]
        public virtual Ruta RutaFin { get; set; }

        public Linea() { }


        public static bool CrearLinea(string _nombre, int _idaID, int _vueltaID)
        {
            try
            {
                var BD = new MicroSystemContext();

                Linea nuevaLinea = new Linea();

                nuevaLinea.Nombre = _nombre;
                nuevaLinea.Micros = new List<Micro>();

                Ruta rutaIda = BD.Rutas.Where(r => r.Id == _idaID).FirstOrDefault();
                Ruta rutaVuelta = BD.Rutas.Where(r => r.Id == _vueltaID).FirstOrDefault();

                nuevaLinea.RutaInicio = rutaIda;
                nuevaLinea.RutaFin = rutaVuelta;

                BD.Lineas.Add(nuevaLinea);

                try
                {
                    BD.SaveChanges();
                    nuevaLinea.RutaInicio.Linea = nuevaLinea;
                    nuevaLinea.RutaFin.Linea = nuevaLinea;
                    BD.SaveChanges();
                    return true;
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
                    //MessageBox.Show("El nombre de línea ya existe.");
                    MessageBox.Show(ex.Message);
                    
                    return false;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Imposible completar operación");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error creando la línea");
                MessageBox.Show(ex.Message);
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


    }
}
