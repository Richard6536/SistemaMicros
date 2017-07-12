using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServiceGX.Classes
{
    public class UsuarioDX
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public bool TransmitiendoPosicion { get; set; }
    }
}