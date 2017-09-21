using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using MetroFramework;

namespace MicrosFormsGX.Classes
{
    public class FormManager
    {
        public static Form formAbiertaActual = null;
        public static bool cerrandoAplicacion = false;

        public static void CambiarForm(Form current, Form next)
        {
            
            FormCollection forms = Application.OpenForms;
            Form theForm = null;

            foreach (Form f in forms)
            {
                if (f.GetType() == next.GetType())
                {
                    theForm = f;
                }
            }

            if(theForm != null)
            {
                current.Hide();
                theForm.StartPosition = FormStartPosition.CenterScreen;
                theForm.BringToFront();
                theForm.Show();
            }
            else
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
            next.MaximizeBox = true;
            next.MinimizeBox = false;
            next.ShowDialog();         
            current.Enabled = true;
            return next.DialogResult;

           
        }

    }
}
