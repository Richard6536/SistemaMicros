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
    public partial class HistorialesParaderos : Form
    {
        List<HistorialParadero> historialesParadero;

        public HistorialesParaderos(int _idHistorialIdaVuelta)
        {
            InitializeComponent();

            historialesParadero = HistorialIdaVuelta.ObtenerHistorialesParaderos(_idHistorialIdaVuelta);
        }
    }
}
