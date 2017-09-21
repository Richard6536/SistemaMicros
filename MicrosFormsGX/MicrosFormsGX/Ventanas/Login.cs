using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using MicrosFormsGX.Model;
using MicrosFormsGX.Ventanas.Creaciones;
using MicrosFormsGX.Ventanas;
using MicrosFormsGX.Classes;
using MicrosFormsGX.Model.DatosTemporales;
using MetroFramework;

namespace MicrosFormsGX.Ventanas
{
   
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public int porcentajeTotal = 0;
        LoadingScreenInicial loadingScreen;
        public Login()
        {
            Thread t = new Thread(new ThreadStart(IniciarLoadingScreen));
            t.Start();
            CargarDatos();
            InitializeComponent();
            t.Abort();
        }

        void IniciarLoadingScreen()
        {
            loadingScreen = new LoadingScreenInicial(this);
            Application.Run(loadingScreen);
        }

        private void CargarDatos()
        {
            if (!ConnectionTester.IsConnectionActive())
                return;

            MicroSystemContext db = new MicroSystemContext();

            List<Linea> todasLineas = db.Lineas.ToList();
            List<Ruta> todasRutas = db.Rutas.ToList();

            List<LineaTP> lineasPrograma = new List<LineaTP>();
            List<RutaTP> rutasPrograma = new List<RutaTP>();

            porcentajeTotal = 10;

            float porcentajePorRuta = 80;

            if(todasRutas.Count > 0)
                porcentajePorRuta = 80 / todasRutas.Count;

            foreach (Ruta r in todasRutas)
            {
                RutaTP rutaTP = new RutaTP();
                rutaTP.Id = r.Id;
                rutaTP.Nombre = r.Nombre;
                rutaTP.TipoRuta = r.TipoDeRuta;
                rutaTP.LineaId = r.LineaId;

                List<Paradero> paraderos = Ruta.ObtenerParaderosRuta(r);
                rutaTP.Paraderos = paraderos;

                List<Coordenada> coors = r.Coordenadas;
                rutaTP.listaCoordenadas = coors;

                rutasPrograma.Add(rutaTP);

                porcentajeTotal += (int)porcentajePorRuta;
            }

            foreach (Linea l in todasLineas)
            {
                LineaTP lineaTP = new LineaTP();
                lineaTP.Id = l.Id;
                lineaTP.Nombre = l.Nombre;
                lineaTP.Tarifa = l.Tarifa;
                lineaTP.Micros = Linea.ObtenerMicrosDeLinea(l.Id);

                lineaTP.rutaIda = rutasPrograma.Where(r => r.Id == l.RutaIdaId).FirstOrDefault();
                lineaTP.rutaVuelta = rutasPrograma.Where(r => r.Id == l.RutaVueltaId).FirstOrDefault();
                lineaTP.rutasDeLinea = rutasPrograma.Where(r => r.LineaId == l.Id).ToList();

                lineasPrograma.Add(lineaTP);
            }

            porcentajeTotal = 100;

            LineaTP.todasLineas = lineasPrograma;
            RutaTP.todasRutas = rutasPrograma;

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            string mail = txtEmail.Text;
            string pass = txtPassword.Text;
            var db = new MicroSystemContext();
            List<Usuario> users = db.Usuarios.ToList();

            if (!ConnectionTester.IsConnectionActive())
            {
                return;
            }

            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                MetroMessageBox.Show(this,"No deje campos en blanco","Notificación");             
                return;
            }

            if (Usuario.VerificarExistenciaUsusuarios() == false)
            {
                MetroMessageBox.Show(this, "No hay usuarios creados en la base de datos. Se procederá a crear el primer adminsitrador.", "Notificación");

                txtEmail.Text = "";
                txtPassword.Text = "";

                this.Enabled = false;
                var form = new CrearPrimerUsuario();

                form.ShowDialog();

                this.Enabled = true;

            }
            else
            {
                if (Usuario.EsPasswordValida(mail, pass))
                {
                    txtEmail.Text = "";
                    txtPassword.Text = "";

                    FormManager.CambiarForm(this, new InicioReal());            
                }
                else
                {
                    MetroMessageBox.Show(this, "Usuario/contraseña no válidos", "Notificación");
                }
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.cerrandoAplicacion = true;
            Application.Exit();
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            FormManager.formAbiertaActual = this;
        }

        
    }
}
