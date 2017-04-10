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

namespace MicrosForms.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        
        public enum RolUsuario { normal, chofer, admin }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(20), MinLength(4), Index("NombreIndex", IsUnique = true)]
        public string Nombre { get; set; }

        [Required, StringLength(20), MinLength(4)]
        public string Password { get; set; }

        [Required, StringLength(30), MinLength(4)]
        public string Email { get; set; }

        [Required]
        public Coordenada Posicion { get; set; }

        [Required]
        public RolUsuario Rol { get; set; }

        public int? MicroId { get; set; }
        public int? ParaderoSelectedId { get; set; }

        [ForeignKey("MicroId")]
        public virtual Micro Micro { get; set; }
        [ForeignKey("ParaderoSelectedId")]
        public virtual Paradero ParaderoSelected { get; set; }


        public static String CrearUsuario(String _nombre, RolUsuario _rol, String _password)
        {
            try
            {
                var BD = new MicroSystemContext();

                Usuario nuevoUsuario = new Usuario();

                //String passEncriptada = PasswordHash.CreateHash(_password.Trim());

                nuevoUsuario.Nombre = _nombre;
                nuevoUsuario.Rol = _rol;
                nuevoUsuario.Password = _password;
                //nuevoUsuario.Password = passEncriptada;

                nuevoUsuario.Posicion = new Coordenada();

                String mensajeError = "";

                BD.Usuarios.Add(nuevoUsuario);

                try
                {
                    BD.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    mensajeError = ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                }
                catch (DbUpdateException ex)
                {
                    mensajeError = "El nombre de usuario ya existe";
                }
                catch (Exception ex)
                {
                    mensajeError = "Imposible completar su solicitud. Intente más tarde";
                }

                return mensajeError;

            }
            catch (Exception)
            {
                Debug.WriteLine("Error creando usuario");
                throw;
            }

        }

        public static bool EsPasswordValida(String _nombre, String _pass)
        {

            try
            {
                var BD = new MicroSystemContext();

                var usuarioSeleccionado = BD.Usuarios.Where(
                    usuario =>
                               usuario.Nombre == _nombre).FirstOrDefault();

                String resultPass = usuarioSeleccionado.Password;

                if (resultPass != _pass)
                    return false;
                
                return true;
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
