using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServiceGX.Classes
{
    public class Posicion
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public Posicion(double lat, double lng)
        {
            Latitud = lat;
            Longitud = lng;
        }
    }
}