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
    
    public partial class MicroChofer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MicroChofer()
        {
            this.Micro = new HashSet<Micro>();
            this.Usuario1 = new HashSet<Usuario>();
        }
    
        public int Id { get; set; }
        public int MicroId { get; set; }
        public int ChoferId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Micro> Micro { get; set; }
        public virtual Micro Micro1 { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario1 { get; set; }
    }
}
