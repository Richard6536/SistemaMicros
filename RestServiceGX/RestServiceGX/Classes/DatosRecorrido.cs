using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServiceGX.Classes
{
    public class DatosRecorrido
    {
        public int IdSiguienteParadero { get; set; }
        public int IdSiguienteVertice { get; set; }
        public MicroDX MiMicro { get; set; }
        public List<UsuarioParaderoDeluxe>  UsuarioParaderos { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}