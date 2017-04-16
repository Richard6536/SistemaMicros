using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace MicrosForms.Classes
{
    public class FormManager
    {
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
                    f.Show();
                    f.Focus();
                }
            }
            if (existe == false)
            {
                current.Hide();
                next.Show();
                next.Focus();
            }
        }


        //ShowDialog
        //this.Enabled = false;
        //var forms = new AreasQuePidenInsumo(codigoInsumo);
        //forms.ShowDialog();
        //this.Enabled = true;

        //volver
        //this.DialogResult = DialogResult.OK;


    }
}
