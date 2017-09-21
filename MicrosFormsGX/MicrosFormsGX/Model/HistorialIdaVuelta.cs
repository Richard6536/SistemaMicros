using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

using System.Diagnostics;
using MicrosFormsGX.Classes;

namespace MicrosFormsGX.Model
{
    [Table("HistorialIdaVuelta")]
    public class HistorialIdaVuelta
    {
        [Key]
        public int Id { get; set; }

        public int Orden { get; set; }

        public int PasajerosTransportados { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraTermino { get; set; }

        public TimeSpan DuracionRecorrido { get; set; }


        public int IdDiario { get; set; }
        [ForeignKey("IdDiario")]
        public virtual HistorialDiario HistorialDiario { get; set; }

        public virtual List<HistorialParadero> HistorialesParaderos { get; set; }


        public HistorialIdaVuelta()
        { }

        public static List<HistorialParadero> ObtenerHistorialesParaderos(int _idHistorialIdaVuelta)
        {
            var BD = new MicroSystemContext();

            List<HistorialParadero> historiales = BD.HistorialesIdaVuelta.Where(hiv => hiv.Id == _idHistorialIdaVuelta).FirstOrDefault().HistorialesParaderos;

            return historiales;
        }

        public static HistorialIdaVuelta BuscarPorId(int _id)
        {
            var BD = new MicroSystemContext();

            HistorialIdaVuelta hiv = BD.HistorialesIdaVuelta.Where(h => h.Id == _id).FirstOrDefault();

            return hiv;
        }
    }
}
