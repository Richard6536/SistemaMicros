﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using PositionTester.Model;


namespace PositionTester.Classes
{
    public class ConnectionTester
    {
        public static bool IsConnectionActive()
        {
            try
            {
                var BD = new MicroSystemContext();

                List<Usuario> test = BD.Usuarios.ToList();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conectado a la base de datos.");
                return false;
            }
                     
        }
    }
}
