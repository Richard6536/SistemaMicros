using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GMap.NET;
using RestServiceGX.Models;

namespace RestServiceGX.Classes
{
    public class LineaRecomendada
    {
        public int IdLinea { get; set; }
        public int IdParaderoInicio { get; set; }
        public int IdParaderoFinal { get; set; }

        public List<Posicion> RutaInicio { get; set; }
        public List<Posicion> RutaFinal { get; set; }
        public List<Posicion> RutaMicro { get; set; }
        public List<Posicion> RutaCaminando { get; set; }

        public LineaRecomendada()
        {
            IdLinea = -1;
            IdParaderoInicio = -1;
            IdParaderoFinal = -1;

            RutaInicio = new List<Posicion>();
            RutaFinal = new List<Posicion>();
            RutaMicro = new List<Posicion>();
            RutaCaminando = new List<Posicion>();
        }

        public LineaRecomendada(int _idLinea, int _idParaderoInicio, int _idParaderoFinal, List<PointLatLng> _rutaInicio, List<PointLatLng> _rutaFinal, List<Coordenada> _rutaMicro)
        {
            IdLinea = _idLinea;
            IdParaderoInicio = _idParaderoInicio;
            IdParaderoFinal = _idParaderoFinal;
            RutaCaminando = new List<Posicion>();

            RutaInicio = new List<Posicion>();

            for (int i = 0; i < _rutaInicio.Count; i++)
            {
                RutaInicio.Add(new Posicion(_rutaInicio[i].Lat, _rutaInicio[i].Lng));
            }

            RutaFinal = new List<Posicion>();

            for (int i = 0; i < _rutaFinal.Count; i++)
            {
                RutaFinal.Add(new Posicion(_rutaFinal[i].Lat, _rutaFinal[i].Lng));
            }

            RutaMicro = new List<Posicion>();

            for (int i = 0; i < _rutaMicro.Count; i++)
            {
                RutaMicro.Add(new Posicion(_rutaMicro[i].Latitud, _rutaMicro[i].Longitud));
            }
        }

        public LineaRecomendada(List<PointLatLng> _rutaCaminando)
        {
            IdLinea = -1;
            IdParaderoInicio = -1;
            IdParaderoFinal = -1;

            RutaInicio = new List<Posicion>();
            RutaFinal = new List<Posicion>();
            RutaMicro = new List<Posicion>();
            RutaCaminando = new List<Posicion>();

            for (int i = 0; i < _rutaCaminando.Count; i++)
            {
                RutaCaminando.Add(new Posicion(_rutaCaminando[i].Lat, _rutaCaminando[i].Lng));
            }
        }
    }
}