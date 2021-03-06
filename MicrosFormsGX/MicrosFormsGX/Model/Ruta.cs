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

using MicrosFormsGX.Classes;
using MetroFramework;

using System.Device.Location;

namespace MicrosFormsGX.Model
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


        public static Ruta CrearRuta(int _idLinea, string _nombre, TipoRuta _tipo, List<Coordenada> _coordenadas, List<Paradero> _paraderos)
        {
            var BD = new MicroSystemContext();
            Linea linea = BD.Lineas.Where(l => l.Id == _idLinea).FirstOrDefault();

            Ruta ruta = new Ruta();
            ruta.Nombre = _nombre;
            ruta.Coordenadas = _coordenadas;
            ruta.Paraderos = _paraderos;
            ruta.TipoDeRuta = _tipo;
            ruta.Linea = linea;

            foreach (Paradero p in _paraderos)
            {
                GeoCoordinate posParadero = new GeoCoordinate(p.Latitud, p.Longitud);

                foreach (Coordenada c in _coordenadas)
                {
                    GeoCoordinate posCoordenada = new GeoCoordinate(c.Latitud, c.Longitud);
                    double distEntre = posCoordenada.GetDistanceTo(posParadero);

                    if (distEntre < 5)
                    {
                        p.Coordenada = c;
                        break;
                    }
                }
            }

            BD.Rutas.Add(ruta);

            try
            {
                BD.SaveChanges();
                return ruta;
            }
            catch (DbEntityValidationException ex)
            {
                string mensaje = "errores \n";

                foreach (var error in ex.EntityValidationErrors.First().ValidationErrors)
                {
                    mensaje += error.ErrorMessage + "\n";
                }

                MetroMessageBox.Show(FormManager.formAbiertaActual, mensaje);

                return null;
            }
            catch (DbUpdateException ex)
            {
                MetroMessageBox.Show(FormManager.formAbiertaActual, ex.Message);    

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Imposible completar operación");
                return null;
            }

        }

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

        //public static bool EditarRuta(Ruta _ruta, List<Coordenada> _vertices, bool sobreEscribirVertices)
        //{
        //    var BD = new MicroSystemContext();

        //    Ruta _rutaBD = BD.Rutas.Where(r => r.Id == _ruta.Id).FirstOrDefault();

            
        //    if (sobreEscribirVertices)
        //    {
        //        //Se registra el inicio antiguo y se asocian los nuevos vertices con la ruta
        //        Coordenada inicioAntiguo = _rutaBD.Inicio;
        //        _rutaBD.Inicio = _vertices[0];

        //        for (int i = 1; i < _vertices.Count; i++)
        //        {
        //            BD.Coordenadas.Add(_vertices[i]);
        //        }

        //        //Se borran las coordenadas antiguas
        //        List<Coordenada> aBorrar = new List<Coordenada>();
        //        Coordenada actual = BD.Coordenadas.Where(c => c.Id == inicioAntiguo.Id).FirstOrDefault();

        //        while (actual != null)
        //        {
        //            aBorrar.Add(actual);
        //            actual = actual.Siguiente;
        //        }

        //        foreach (Coordenada c in aBorrar)
        //        {
        //            BD.Coordenadas.Remove(c);
        //        }

        //    }

        //    try
        //    {
        //        BD.SaveChanges();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        string mensaje = "errores \n";

        //        foreach (var error in ex.EntityValidationErrors.First().ValidationErrors)
        //        {
        //            mensaje += error.ErrorMessage + "\n";
        //        }
        //        MetroMessageBox.Show(FormManager.formAbiertaActual, mensaje);

        //        return false;
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        MetroMessageBox.Show(FormManager.formAbiertaActual, ex.Message);
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MetroMessageBox.Show(FormManager.formAbiertaActual, ex.Message);
        //        return false;
        //    }

        //    return true;

        //}

        public static bool EliminarRuta(int _id)
        {
            try
            {
                var BD = new MicroSystemContext();

                Ruta rutaABorrar = BD.Rutas.Where(r => r.Id == _id).FirstOrDefault();

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
