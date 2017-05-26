﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using MicrosForms.Ventanas;
using MicrosForms.Ventanas.Creaciones;

namespace MicrosForms
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var formInicio = new AdminUsuarios();
            formInicio.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(formInicio);
        }
    }
}
