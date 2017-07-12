using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using PositionTester.Model;

namespace PositionTester.Classes
{
    public class FormManager
    {
        public static bool cerrandoAplicacion = false;

        public static void CambiarForm(Form current, Form next)
        {
            
            FormCollection forms = Application.OpenForms;
            bool existe = false;
            foreach (Form f in forms)
            {
                if (f.GetType() == next.GetType())
                {
                    current.Hide();
                    existe = true;
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.BringToFront();
                    f.Show();

                }
            }
            if (existe == false)
            {
                current.Hide();

                next.StartPosition = FormStartPosition.CenterScreen;
                next.BringToFront();
                next.Show();

            }
        }

        public static DialogResult MostrarShowDialog(Form current, Form next)
        {
            current.Enabled = false;

            next.StartPosition = FormStartPosition.CenterScreen;
            next.MaximizeBox = false;
            next.MinimizeBox = false;
            next.FormBorderStyle = FormBorderStyle.FixedDialog;
            next.ShowDialog();
            current.Enabled = true;
            return next.DialogResult;
        }

    }
}
