﻿using System;
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
        
        public enum RolUsuario { Normal, Chofer, Admin, Bloqueado }

        [Key, ForeignKey("UsuarioParadero")]
        public int Id { get; set; }

        [Required, StringLength(25, MinimumLength = 3, ErrorMessage = "El nombre de usuario debe tener un mínimo de 3 carácteres y máximo de 25"), 
            Index("NombreIndex", IsUnique = true)]
        public string Nombre { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, StringLength(50, MinimumLength = 3, ErrorMessage = "El email debe tener un mínimo de 3 carácteres y un máximo de 50")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public RolUsuario Rol { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public bool TransmitiendoPosicion { get; set; }

        public int? UsuarioParaderoId { get; set; }
        public int? MicroChoferId { get; set; }
        
        [ForeignKey("UsuarioParaderoId")]
        public virtual UsuarioParadero UsuarioParadero { get; set; }

        [ForeignKey("MicroChoferId")]
        public virtual MicroChofer MicroChofer { get; set; }

        public Usuario() { }



        public static bool EditarUsuario(int _id, string _nuevoNombre, string _nuevoEmail, RolUsuario _nuevoRol, string _nuevaPassword)
        {
            var BD = new MicroSystemContext();

            Usuario user = BD.Usuarios.Where(u => u.Id == _id).FirstOrDefault();

            user.Nombre = _nuevoNombre;
            user.Rol = _nuevoRol;
            user.Email = _nuevoEmail;
            user.Password = _nuevaPassword;

            try
            {
                BD.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool AsignarMicro(int _idUser, Micro _micro)
        {
            var BD = new MicroSystemContext();

            Usuario user = BD.Usuarios.Where(u => u.Id == _idUser).FirstOrDefault();

            if (user.MicroChoferId == null && _micro == null)
            {
                return true;
            }         

            Micro microAntigua;
            Micro microNueva;

            if(user.MicroChoferId == null && _micro != null)
            {
                //crear microchofer y asignar
                microNueva = BD.Micros.Where(m => m.Patente == _micro.Patente).FirstOrDefault();
                MicroChofer mc = new MicroChofer();
                BD.MicroChoferes.Add(mc);
                mc.Micro = microNueva;
                mc.Chofer = user;
                user.MicroChofer = mc;
                microNueva.MicroChofer = mc;             
            }

            if(user.MicroChoferId != null && _micro == null)
            {
                //borrar microchofer
                MicroChofer mc = user.MicroChofer;
                microAntigua = user.MicroChofer.Micro;

                microAntigua.MicroChofer = null;
                user.MicroChofer = null;

                BD.MicroChoferes.Remove(mc);
            }

            if(user.MicroChoferId != null && _micro != null)
            {
                //borrar de la micro antigua la relacion con microchofer
                //asignar con la nueva micro
                MicroChofer mc = user.MicroChofer;
                microAntigua = user.MicroChofer.Micro;
                microNueva = BD.Micros.Where(m => m.Patente == _micro.Patente).FirstOrDefault();

                microAntigua.MicroChofer = null;
                microNueva.MicroChofer = mc;
                mc.Micro = microNueva;
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

 

        public static List<Usuario> BuscarTodosUsuarios()
        {
            var BD = new MicroSystemContext();
            var usuariosSeleccionados = BD.Usuarios.ToList();


            return usuariosSeleccionados;
        }

        public static List<Usuario> BuscarTodosLosUsuariosPorRol(Usuario.RolUsuario _rol)
        {
            var BD = new MicroSystemContext();
            List<Usuario> usuariosSeleccionados = new List<Usuario>();
            var todosLosUsuarios = BD.Usuarios.ToList();

            for (int i = 0; i < todosLosUsuarios.Count; i++)
            {
                if(todosLosUsuarios[i].Rol == _rol)
                {
                    usuariosSeleccionados.Add(todosLosUsuarios[i]);
                }
            }

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

        public static Usuario BuscarUsuarioPorNombre(string _nombre)
        {
            var BD = new MicroSystemContext();
            var usuarioSeleccionado = BD.Usuarios.Where(
                    usuario =>
                               usuario.Nombre == _nombre).FirstOrDefault();

            return usuarioSeleccionado;

        }

        public static Usuario BuscarUsuarioPorMail(string _mail)
        {
            var BD = new MicroSystemContext();
            var usuarioSeleccionado = BD.Usuarios.Where(
                    usuario =>
                               usuario.Email == _mail).FirstOrDefault();

            return usuarioSeleccionado;

        }

        public static bool yaExisteUsuario(string _nombre)
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

        public static void ActualizarPosicion(int _id, double _lat, double _lng)
        {
            var BD = new MicroSystemContext();
            var usuarioSeleccionado = BD.Usuarios.Where(u => u.Id == _id).FirstOrDefault();

            usuarioSeleccionado.Latitud = _lat;
            usuarioSeleccionado.Longitud = _lng;
            usuarioSeleccionado.TransmitiendoPosicion = true;
            BD.SaveChanges();
        }

        public static void PararActualizaciónPosicion(int _id)
        {
            var BD = new MicroSystemContext();
            var usuarioSeleccionado = BD.Usuarios.Where(u => u.Id == _id).FirstOrDefault();

            usuarioSeleccionado.TransmitiendoPosicion = false;
            BD.SaveChanges();

        }

        public static void PararActualizacionTodos()
        {
            var BD = new MicroSystemContext();

            List<Usuario> todos = BD.Usuarios.ToList();

            foreach(Usuario u in todos)
            {
                u.TransmitiendoPosicion = false;
            }

            BD.SaveChanges();
        }

    }
}