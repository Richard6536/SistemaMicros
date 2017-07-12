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


namespace PositionTester.Model
{
    [Table("HistorialDiario")]
    public class HistorialDiario
    {
        [Key]
        public int Id { get; set; }

        public string NombreChofer { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFinal { get; set; }

        public float KilometrosRecorridos { get; set; }

        public int CalificacionesRecibidas { get; set; }

        public int CalificacionDiaria { get; set; }

        public int PasajerosTransportados { get; set; }

        public int NumeroIdaVueltas { get; set; }


        public int IdMicro { get; set; }
        [ForeignKey("IdMicro")]
        public virtual Micro Micro { get; set; }

        public virtual List<HistorialIdaVuelta> HistorialesIdaVuelta { get; set; }

        public HistorialDiario()
        { }


        public static List<HistorialIdaVuelta> ObtenerHistorialesIdaVuelta(int _idHistorialDiario)
        {
            var BD = new MicroSystemContext();

            List<HistorialIdaVuelta> historiales = BD.HistorialesDiarios.Where(hd => hd.Id == _idHistorialDiario).FirstOrDefault().HistorialesIdaVuelta;

            return historiales;
        }

        public static Micro ObtenerMicro(int _idHistorialDiario)
        {
            var BD = new MicroSystemContext();

            Micro micro = BD.HistorialesDiarios.Where(hd => hd.Id == _idHistorialDiario).FirstOrDefault().Micro;

            return micro;

        }

        public static HistorialDiario BuscarPorId(int _idHistorialDiario)
        {
            var BD = new MicroSystemContext();

            HistorialDiario historial = BD.HistorialesDiarios.Where(hd => hd.Id == _idHistorialDiario).FirstOrDefault();

            return historial;
        }
    }
}
