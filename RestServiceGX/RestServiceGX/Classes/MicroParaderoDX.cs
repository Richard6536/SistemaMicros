using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServiceGX.Classes
{
    public class MicroParaderoDX
    {
        public int Id { get; set; }

        public int ParaderoId { get; set; }
        public int MicroId { get; set; }
        public double DistanciaEntre { get; set; }
    }
}