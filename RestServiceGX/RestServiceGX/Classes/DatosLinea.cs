using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestServiceGX.Models;

namespace RestServiceGX.Classes
{
    public class DatosLinea
    {
        public MicroParaderoDX MicroParaderoCercano { get; set; }
        public MicroDX MicroAboradada { get; set; }
        public List<UsuarioDX> Choferes { get; set; }
        public int IdLineaChoferes { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }

    }
}