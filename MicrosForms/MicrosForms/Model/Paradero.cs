﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicrosForms.Model
{
    [Table("Paradero")]
    public class Paradero
    {
        [Key]
        public int Id { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public virtual List<Ruta> Rutas { get; set; }

        public virtual List<UsuarioParadero> UsuariosParaderos { get; set; }
        public virtual List<MicroParadero> MicrosParaderos { get; set; }
    }
}
