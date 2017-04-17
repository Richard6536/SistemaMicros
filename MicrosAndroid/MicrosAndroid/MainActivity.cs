using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace MicrosAndroid
{
    [Activity(Label = "Iniciar Sesión",  MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private EditText txtNombre, txtPass;
        private Button btnIngresar;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            txtNombre = (EditText)FindViewById(Resource.Id.editTextNombre);
            txtPass = (EditText)FindViewById(Resource.Id.editTextPassword);
            btnIngresar = (Button)FindViewById(Resource.Id.btnIngresar);

            btnIngresar.Click += delegate {
                var ingresoDatos = Validar(txtNombre.Text, txtPass.Text);
                if (ingresoDatos == "correcto")
                {
                    Intent intent = new Intent(this, typeof(LocationActivity)); //A donde quiero llevar la información
                    intent.PutExtra(LocationActivity.LLAVE_NOMBRE, txtNombre.Text); //Envío de información a través de la llave creada
                    StartActivity(intent); //Iniciar envio
                }
                if (ingresoDatos == "incorrecto")
                {
                    AlertDialog();
                }
            };

        }

        public void AlertDialog()
        {
            Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);

            AlertDialog alertDialog = builder.Create();
            alertDialog.SetTitle("Error de Validación");
            alertDialog.SetMessage("El Usuario o Contraseña son incorrectas");
            alertDialog.SetButton("Ok", (s, ev) =>
            {

            });

            alertDialog.Show();

        }

        private string Validar(string nombre, string pass)
        {
            if (nombre == "Richard" && pass == "1234")
            {
                return "correcto";
            }
            else
            {
                return "incorrecto";
            }

        }
    }
}

