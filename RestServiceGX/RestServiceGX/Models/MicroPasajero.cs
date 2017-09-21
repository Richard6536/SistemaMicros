//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestServiceGX.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MicroPasajero
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public System.DateTime HoraCreacion { get; set; }
        public double LatitudCreacion { get; set; }
        public double LongitudCreacion { get; set; }
        public int ParaderoId { get; set; }
        public int MicroId { get; set; }
        public int PasajeroId { get; set; }
    
        public virtual Micro Micro { get; set; }
        public virtual Paradero Paradero { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
