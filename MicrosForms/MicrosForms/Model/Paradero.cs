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

        [Required]
        public Coordenada Posicion { get; set; }

        public virtual List<Recorrido> Recorridos { get; set; }
        public virtual List<Usuario> Usuarios { get; set; }
        public virtual List<Micro> Micros { get; set; }
    }
}
