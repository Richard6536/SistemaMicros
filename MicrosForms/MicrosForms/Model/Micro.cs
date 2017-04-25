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
    [Table("Micro")]
    public class Micro
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength( 6, MinimumLength = 6, ErrorMessage = "La patente debe tener un tamaño de 6 carácteres")]
        public string Patente { get; set; }

        [Required]
        public int Calificacion { get; set; }
        
        public int? LineaId { get; set; }

        public int? MicroParaderoId { get; set; }
        public int? MicroChoferId { get; set; }

        
        [ForeignKey("LineaId")]
        public virtual Linea Linea { get; set; }

        [ForeignKey("MicroParaderoId")]
        public virtual MicroParadero MicroParadero { get; set; }

        [ForeignKey("MicroChoferId")]
        public virtual MicroChofer MicroChofer { get; set; }

        public Micro() { }

        public static bool CrearMicro(string _patente, Linea _linea, Usuario _chofer)
        {
            try
            {
                var BD = new MicroSystemContext();

                Micro nuevaMicro = new Micro();

                nuevaMicro.Patente = _patente;
                nuevaMicro.Calificacion = 0;
                
                if(_linea != null)
                {
                    Linea linea = BD.Lineas.Where(l => l.Id == _linea.Id).FirstOrDefault();
                    nuevaMicro.Linea = linea;
                }

                MicroChofer mc = new MicroChofer();
                Usuario choferDB = new Usuario();
                if (_chofer != null)
                {
                    choferDB = BD.Usuarios.Where(c => c.Id == _chofer.Id).FirstOrDefault();                 
                    mc.Micro = nuevaMicro;
                    mc.Chofer = choferDB;
                    BD.MicroChoferes.Add(mc);
                }

                BD.Micros.Add(nuevaMicro);

                try
                {
                    BD.SaveChanges();

                    if(_chofer != null)
                    {
                        nuevaMicro.MicroChofer = mc;
                        choferDB.MicroChofer = mc;
                        BD.SaveChanges();
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    string mensaje = "Se encontraron los siguientes errores:";

                    foreach (var error in ex.EntityValidationErrors.First().ValidationErrors)
                    {
                        mensaje += "\n-" + error.ErrorMessage;
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

                return true;

            }
            catch (Exception)
            {
                Debug.WriteLine("Error creando usuario");
                return false;
            }
        }

        public static bool EditarPatente(int _id, string _nuevaPatente)
        {
            var BD = new MicroSystemContext();

            Micro micro = BD.Micros.Where(m => m.Id == _id).FirstOrDefault();
            micro.Patente = _nuevaPatente;
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
                    mensaje += "\n-" + error.ErrorMessage;
                }
                MessageBox.Show(mensaje);

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool AsignarChofer(int _id, Usuario _nChofer)
        {

            var BD = new MicroSystemContext();

            Micro micro = BD.Micros.Where(m => m.Id == _id).FirstOrDefault();
            MicroChofer mcAntiguo = micro.MicroChofer; //null si no hay
            Usuario choferAntiguo = null;

            if (mcAntiguo != null)
                choferAntiguo = mcAntiguo.Chofer;

            if(_nChofer == null && mcAntiguo == null)
            {
                //no hacer nada
                return true;
            }

            if(_nChofer == null)
            {
                BD.MicroChoferes.Remove(mcAntiguo);
                BD.SaveChanges();
                return true;
            }

            Usuario nuevoChofer = BD.Usuarios.Where(u => u.Id == _nChofer.Id).FirstOrDefault();
            MicroChofer mcNuevo = new MicroChofer();

            if(choferAntiguo != null && nuevoChofer != null && choferAntiguo != nuevoChofer)
            {
                //reemplazar choferantiguo en la relacion microchofer
                mcAntiguo.Chofer.MicroChofer = null;
                mcAntiguo.Chofer = nuevoChofer;
                nuevoChofer.MicroChofer = mcAntiguo;
            }
            else if(mcAntiguo == null && nuevoChofer != null)
            {
                //Crear relacion microchofer
                mcNuevo.Micro = micro;
                mcNuevo.Chofer = nuevoChofer;
                micro.MicroChofer = mcNuevo;
                nuevoChofer.MicroChofer = mcNuevo;
                BD.MicroChoferes.Add(mcNuevo);
            }
            try
            {
                BD.SaveChanges();

                //if(mcAntiguo == null && nuevoChofer != null)
                //{
                //    micro.MicroChofer = mcNuevo;
                //    nuevoChofer.MicroChofer = mcNuevo;
                //}

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool AsignarLinea(int _id, Linea _nlinea)
        {
            var BD = new MicroSystemContext();

            Micro micro = BD.Micros.Where(m => m.Id == _id).FirstOrDefault();
            Linea lineaAntigua = micro.Linea; //null si no tenia

            if(_nlinea == null)
            {
                micro.Linea = null;
                BD.SaveChanges();
                return true;
            }

            Linea nuevaLinea = BD.Lineas.Where(u => u.Id == _nlinea.Id).FirstOrDefault();

            if(nuevaLinea != null && nuevaLinea != lineaAntigua)
            {
                micro.Linea = nuevaLinea;
            }

            try
            {
                BD.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool yaExisteMicro(string _patente)
        {
            bool yaExiste = true;

            var BD = new MicroSystemContext();
            var usuarioSeleccionado = BD.Micros.Where(u => u.Patente == _patente).FirstOrDefault();

            if (usuarioSeleccionado == null)
                yaExiste = false;

            return yaExiste;
        }

        public static Micro BuscarPorPatente(string  _patente)
        {
            var BD = new MicroSystemContext();

            Micro micro = BD.Micros.Where(m => m.Patente == _patente).FirstOrDefault();

            return micro;
        }

        public static Micro BuscarMicro(int _id)
        {
            var BD = new MicroSystemContext();

            Micro micro = BD.Micros.Where(m => m.Id == _id).FirstOrDefault();

            return micro;
        }

        public static List<Micro> BuscarTodasLasMicros()
        {
            var BD = new MicroSystemContext();

            List<Micro> todasMicros = BD.Micros.ToList();

            return todasMicros;
        }
    }
}
