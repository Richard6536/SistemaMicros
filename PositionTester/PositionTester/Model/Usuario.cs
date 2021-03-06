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

using System.Windows.Forms;
using System.Device.Location;
using System.IO;
using System.Net;
using GMap.NET;

namespace PositionTester.Model
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

        public static void ActualizarPosicion(int _id, double _lat, double _lng, bool _actualizarRecorrido)
        {

            var BD = new MicroSystemContext();
            var user = BD.Usuarios.Where(u => u.Id == _id).FirstOrDefault();
            user.Latitud = _lat;
            user.Longitud = _lng;

   
            if (_actualizarRecorrido)
            {

                if (user.Rol == RolUsuario.Chofer && user.MicroChoferId != null)
                {
                    Micro micro = user.MicroChofer.Micro;
                    if (micro.SiguienteVerticeId != null && micro.LineaId != null)
                    {
                        Linea lineaAsociada = micro.Linea;
                        var choferCoordenada = new GeoCoordinate(user.Latitud, user.Longitud);

                        Paradero pActualizado = null; //null o con valor para actualizar vertice
                        #region Manejar Paraderos

                        if (micro.MicroParaderoId != null)
                        {
                            double DistanciaLimiteParadero = 100;
                            Paradero sigParadero = micro.MicroParadero.Paradero;

                            double distAntigua = micro.MicroParadero.DistanciaEntre;

                            var sigParaderoCoordenada = new GeoCoordinate(sigParadero.Latitud, sigParadero.Longitud);
                            double distSigParadero = choferCoordenada.GetDistanceTo(sigParaderoCoordenada);

                            if (distSigParadero <= DistanciaLimiteParadero/2)
                            {
                                pActualizado = sigParadero;
                            }

                            //si salio del radio determinado del paradero, se actualiza el siguiente paradero
                            if (distSigParadero >= DistanciaLimiteParadero && distAntigua <= DistanciaLimiteParadero)
                            {
                                List<Paradero> paraderosLinea = new List<Paradero>();

                                #region LLenar los paraderos de la linea
                                List<Paradero> paraderosIda = lineaAsociada.RutaIda.Paraderos.OrderBy(p => p.Orden).ToList();
                                List<Paradero> paraderosVuelta = lineaAsociada.RutaVuelta.Paraderos.OrderBy(p => p.Orden).ToList();

                                for (int i = 0; i < paraderosIda.Count; i++) //ida
                                {
                                    paraderosLinea.Add(paraderosIda[i]);
                                }

                                for (int i = 0; i < paraderosVuelta.Count; i++)//ida
                                {
                                    paraderosLinea.Add(paraderosVuelta[i]);
                                }

                                paraderosLinea = paraderosLinea.OrderBy(p => p.Id).ToList();
                                #endregion

                                for (int i = 0; i < paraderosLinea.Count; i++)
                                {
                                    if (sigParadero.Id == paraderosLinea[i].Id)
                                    {
                                        //if para ver si se llego al paradero final
                                        if (i + 1 == paraderosLinea.Count)
                                        {
                                            //Se llego al paradero final
                                            MicroParadero mp = micro.MicroParadero;
                                            micro.MicroParadero = null;
                                            BD.MicroParaderos.Remove(mp);
                                            break;
                                        }

                                        Paradero siguiente = paraderosLinea[i + 1];
                                        double distPosibleSig = choferCoordenada.GetDistanceTo(new GeoCoordinate(siguiente.Latitud, siguiente.Longitud));

                                        micro.MicroParadero.Paradero = siguiente;
                                        micro.MicroParadero.DistanciaEntre = distPosibleSig;
                                    }
                                }
                                
                            }
                            else
                            {
                                //caso contrario se actualiza la distancia del microparadero
                                micro.MicroParadero.DistanciaEntre = distSigParadero;
                            }

                        }

                        #endregion

                        #region Manejar Coordenadas

                        double distLimiteVertices = 100;

                        Coordenada sigCoor = micro.SiguienteVertice;
                        var sigVerticeCoordenada = new GeoCoordinate(sigCoor.Latitud, sigCoor.Longitud);
                        double distSigCoor = choferCoordenada.GetDistanceTo(sigVerticeCoordenada);

                        if (pActualizado != null)
                        {
                            sigCoor = BD.Coordenadas.Where(c => c.Latitud == pActualizado.Latitud && c.Longitud == pActualizado.Longitud).FirstOrDefault();
                            sigVerticeCoordenada = new GeoCoordinate(pActualizado.Latitud, pActualizado.Longitud);
                            distSigCoor = choferCoordenada.GetDistanceTo(sigVerticeCoordenada);

                            if(sigCoor != null)
                            {
                                micro.SiguienteVertice = sigCoor;
                            }
                        }

                        if (distSigCoor <= distLimiteVertices)
                        {
                            List<Coordenada> coordenadasLinea = Usuario.ObtenerCoordenadasLinea(BD, lineaAsociada.Id);
                            for (int i = 0; i < coordenadasLinea.Count; i++)
                            {
                                if (coordenadasLinea[i].Id == sigCoor.Id)
                                {

                                    int c = 1;

                                    int indexSiguiente = Clamp(i + c, 0, coordenadasLinea.Count - 1);

                                    if (indexSiguiente == coordenadasLinea.Count - 1)
                                    {
                                        //termina recorrido
                                        user.MicroChofer.Micro.SiguienteVertice = null;
                                        user.MicroChofer.Micro.SiguienteVerticeId = null;
                                        break;
                                    }

                                    Coordenada posibleSig = coordenadasLinea[i + c];
                                    double distPosibleSig = choferCoordenada.GetDistanceTo(new GeoCoordinate(posibleSig.Latitud, posibleSig.Longitud));

                                    while (distPosibleSig <= distLimiteVertices)
                                    {
                                        c++;
                                        indexSiguiente = Clamp(i + c, 0, coordenadasLinea.Count - 1);
                                        if (indexSiguiente == coordenadasLinea.Count - 1)
                                        {
                                            i = int.MaxValue; //sale del for
                                            user.MicroChofer.Micro.SiguienteVertice = null;
                                            user.MicroChofer.Micro.SiguienteVerticeId = null;
                                            //termina recorrido
                                            break;
                                        }

                                        posibleSig = coordenadasLinea[i + c];
                                        distPosibleSig = choferCoordenada.GetDistanceTo(new GeoCoordinate(posibleSig.Latitud, posibleSig.Longitud));
                                    }
                                    micro.SiguienteVertice = posibleSig;
                                    
                                }
                            }

                            //Identificar siguiente coordendada 
                            //si la siguiente coordenada sigue dentro del rango pasar al siguiente
                            //el primero fuera del rango se actualiza
                        }
                        #endregion


                    }
                }
                
            }
            
            BD.SaveChanges();

        }

        public static void ActualizarMultiplesPosiciones(List<int> _Ids,  List<PointLatLng> _posiciones)
        {
            var BD = new MicroSystemContext();
            for (int i = 0; i < _Ids.Count; i++)
            {
                int id = _Ids[i];
                var user = BD.Usuarios.Where(u => u.Id == id).FirstOrDefault();
                user.Latitud = _posiciones[i].Lat;
                user.Longitud = _posiciones[i].Lng;
            }

            BD.SaveChanges();
        }


        public static void PararActualizaciónPosicion(int _id)
        {
            var BD = new MicroSystemContext();
            var usuarioSeleccionado = BD.Usuarios.Where(u => u.Id == _id).FirstOrDefault();

            usuarioSeleccionado.TransmitiendoPosicion = false;

            if (usuarioSeleccionado.Rol == RolUsuario.Chofer)
            {
                if (usuarioSeleccionado.MicroChoferId != null)
                {
                    Micro m = usuarioSeleccionado.MicroChofer.Micro;
                    m.SiguienteVertice = null;
                    m.SiguienteVerticeId = null;
                    if (m.MicroParaderoId != null)
                    {
                        MicroParadero mp = m.MicroParadero;
                        BD.MicroParaderos.Remove(mp);
                    }
                }
            }
            BD.SaveChanges();

        }

        public static void PararActualizacionTodos()
        {
            var BD = new MicroSystemContext();

            List<Usuario> todos = BD.Usuarios.ToList();

            foreach(Usuario u in todos)
            {
                u.TransmitiendoPosicion = false;

                if(u.Rol == RolUsuario.Chofer)
                {
                    if(u.MicroChoferId != null)
                    {
                        Micro m = u.MicroChofer.Micro;
                        m.SiguienteVertice = null;
                        m.SiguienteVerticeId = null;
                        if (m.MicroParaderoId != null)
                        {
                            MicroParadero mp = m.MicroParadero;
                            BD.MicroParaderos.Remove(mp);
                        }
                    }
                }
            }

            BD.SaveChanges();
        }

        public static List<Coordenada> ObtenerCoordenadasLinea(MicroSystemContext db, int _idLinea)
        {
            Linea linea = db.Lineas.Where(l => l.Id == _idLinea).FirstOrDefault();
            List<Coordenada> coordenadas = new List<Coordenada>();
            Ruta rutaIda = linea.RutaIda;
            Ruta rutaVuelta = linea.RutaVuelta;

            List<Coordenada> coordenadasIda = rutaIda.Coordenadas.OrderBy(c => c.Orden).ToList();
            List<Coordenada> coordenadasVuelta = rutaVuelta.Coordenadas.OrderBy(c => c.Orden).ToList();

            for (int i = 0; i < coordenadasIda.Count; i++)
            {
                coordenadas.Add(coordenadasIda[i]);
            }

            for (int i = 0; i < coordenadasVuelta.Count; i++)
            {
                coordenadas.Add(coordenadasVuelta[i]);
            }

            return coordenadas;
        }

        public static int Clamp(int val, int min, int max)
        {
            if (val < min) return min;
            else if (val > max) return max;
            else return val;
        }

        void POST(string url, string jsonContent)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            long length = 0;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;
                }
            }
            catch (WebException ex)
            {
                // Log exception and throw as for GET example above
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
