using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MicrosForms.Classes;
using MicrosForms.Model;
using MicrosForms.Ventanas;
using MicrosForms.Ventanas.Creaciones;
using MicrosForms.Ventanas.Ediciones;

namespace MicrosForms.Ventanas.Historiales
{
    public partial class HistorialesIdaVuelta : Form
    {
        List<HistorialIdaVuelta> historialesIdaVuelta;

        public HistorialesIdaVuelta(int _idHistorialDiario)
        {
            InitializeComponent();

            lblPatente.Text = MicrosForms.Model.HistorialDiario.ObtenerMicro(_idHistorialDiario).Patente;
            lblFecha.Text = MicrosForms.Model.HistorialDiario.BuscarPorId(_idHistorialDiario).Fecha + "";

            historialesIdaVuelta = MicrosForms.Model.HistorialDiario.ObtenerHistorialesIdaVuelta(_idHistorialDiario);
        }
    }
}
