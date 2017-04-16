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
    [Table("Usuario")]
    public class Usuario
    {
        
        public enum RolUsuario { normal, chofer, admin }

        [Key, ForeignKey("UsuarioParadero")]
        public int Id { get; set; }

        [Required, StringLength(25, MinimumLength = 3, ErrorMessage = "El nombre de usuario debe tener un mínimo de 3 carácteres y máximo de 25"), 
            Index("NombreIndex", IsUnique = true)]
        public string Nombre { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "El email debe tener un mínimo de 3 carácteres y un máximo de 25")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public RolUsuario Rol { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public int? UsuarioParaderoId { get; set; }
        public int? MicroChoferId { get; set; }
        
        [ForeignKey("UsuarioParaderoId")]
        public virtual UsuarioParadero UsuarioParadero { get; set; }

        [ForeignKey("MicroChoferId")]
        public virtual MicroChofer MicroChofer { get; set; }

        public Usuario() { }


        public static bool CrearUsuario(string _nombre, string _email, RolUsuario _rol, string _password)
        {
            try
            {
                var BD = new MicroSystemContext();

                Usuario nuevoUsuario = new Usuario();

                string passEncriptada = PasswordHash.CreateHash(_password.Trim());

                nuevoUsuario.Nombre = _nombre;
                nuevoUsuario.Rol = _rol;
                nuevoUsuario.Email = _email;
                nuevoUsuario.Password = passEncriptada;

                BD.Usuarios.Add(nuevoUsuario);

                try
                {
                    BD.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    //mensajeError = ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;

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
                    //mensajeError = "El nombre de usuario ya existe";
                    MessageBox.Show("El nombre de usuario ya existe");
                    return false;
                }
                catch (Exception ex)
                {
                    //mensajeError = "Imposible completar su solicitud. Intente más tarde";
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

        public static bool EsPasswordValida(String _nombre, String _pass)
        {

            try
            {
                var BD = new MicroSystemContext();

                var usuarioSeleccionado = BD.Usuarios.Where(u => u.Nombre == _nombre).FirstOrDefault();

                bool resultPass = PasswordHash.ValidatePassword(_pass, usuarioSeleccionado.Password);

                return resultPass;
            }
            catch (Exception)
            {
                //no existe
                return false;
            }

        }

        public static List<Usuario> BuscarTodosUsuarios()
        {
            var BD = new MicroSystemContext();
            var usuariosSeleccionados = BD.Usuarios.ToList();


            return usuariosSeleccionados;
        }

        public static bool VerificarExistenciaUsusuarios()
        {
            try
            {
                var BD = new MicroSystemContext();
                var usuariosSeleccionados = BD.Usuarios.ToList();

                if (usuariosSeleccionados.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                Debug.WriteLine("Error conexion");
                return false;
            }

        }

        public static Usuario BuscarUsuario(int _id)
        {
            var BD = new MicroSystemContext();
            var usuarioSeleccionado = BD.Usuarios.Where(
                    usuario =>
                               usuario.Id == _id).FirstOrDefault(); 

            return usuarioSeleccionado;

        }

        public static bool ExisteYaUsuario(string _nombre)
        {
            bool yaExiste = true;

            var BD = new MicroSystemContext();
            var usuarioSeleccionado = BD.Usuarios.Where(u => u.Nombre == _nombre).FirstOrDefault();

            if (usuarioSeleccionado == null)
                yaExiste = false;

            return yaExiste;
        }

        public static void ActualizarUsuario(int _id, String _pass, RolUsuario _rol)
        {
            var BD = new MicroSystemContext();
            var usuarioSeleccionado = BD.Usuarios.Where(
                    usuario =>
                               usuario.Id == _id).FirstOrDefault(); //Busco por id

            //String passEncriptada = PasswordHash.CreateHash(_pass.Trim());
            //usuarioSeleccionado.Password = passEncriptada;
            usuarioSeleccionado.Password = _pass;
            usuarioSeleccionado.Rol = _rol;

            BD.SaveChanges();

        }

        public static void ActualizarRolUsuario(int _id, RolUsuario _rol)
        {
            var BD = new MicroSystemContext();
            var usuarioSeleccionado = BD.Usuarios.Where(
                    usuario =>
                               usuario.Id == _id).FirstOrDefault(); //Busco por id
            usuarioSeleccionado.Rol = _rol;

            BD.SaveChanges();

        }



        public static void Eliminar(int _id)
        {
            var BD = new MicroSystemContext();
            var usuarioSeleccionado = BD.Usuarios.Where(
                    usuario =>
                               usuario.Id == _id).FirstOrDefault();

            BD.Usuarios.Remove(usuarioSeleccionado);
            BD.SaveChanges();
        }



    }
}
