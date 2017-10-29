using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PositionTester.Model;
using PositionTester.Classes;
using PositionTester.Model.DatosTemporales;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using System.Device.Location;

namespace PositionTester
{
    public partial class Form1 : Form
    {
        LineaTP lineaActual;

        List<Usuario> usuariosControlados;
        List<Usuario> usuariosControlarRecorrido;
        List<GMarkerGoogle> usersMarkers;

        Usuario userControlandoActual;
        List<Usuario> usersControlados;

        
        GMapOverlay previewOverlay;
        GMapOverlay paraderosOverlay;
        GMapOverlay otrosMarkersOverlay;
        GMapOverlay userControladoOverlay;

        GMapOverlay points_; //para dibujar circulos


        public Form1()
        {
            if (!ConnectionTester.IsConnectionActive())
                return;

            CargarDatos();
            InitializeComponent();
            IniciarMapa();
            CargarComboboxLineas();

            usuariosControlados = new List<Usuario>();
            usuariosControlarRecorrido = new List<Usuario>();
            usersMarkers = new List<GMarkerGoogle>();
            lblUserMoviendo.Text = "";
            button1.Text = "false";

            usersControlados = new List<Usuario>();
        }

        double latOsorno = -40.574984;
        double lngOsorno = -73.125183;

        void IniciarMapa()
        {
            gmapController.MapProvider = GMapProviders.GoogleMap;

            gmapController.DragButton = MouseButtons.Left;
            gmapController.CanDragMap = true;
            gmapController.Position = new PointLatLng(latOsorno, lngOsorno);

            gmapController.MinZoom = 4;
            gmapController.MaxZoom = 19;
            gmapController.Zoom = 14;

            gmapController.IgnoreMarkerOnMouseWheel = true;

            previewOverlay = new GMapOverlay();
            paraderosOverlay = new GMapOverlay();
            otrosMarkersOverlay = new GMapOverlay();
            userControladoOverlay = new GMapOverlay();
            points_  = new GMapOverlay("pointCollection");

            gmapController.Overlays.Add(previewOverlay);
            gmapController.Overlays.Add(paraderosOverlay);
            gmapController.Overlays.Add(otrosMarkersOverlay);
            gmapController.Overlays.Add(userControladoOverlay);
            gmapController.Overlays.Add(points_);


        }

        #region ComboBox lineas
        void CargarComboboxLineas()
        {
            //List<Linea> lineasCMB = Linea.ObtenerTodasLasLineas();
            //List<Linea> lineasCMBOrdenadas = lineasCMB.OrderBy(l => l.Nombre).ToList();

            List<LineaTP> lineasCMB = LineaTP.todasLineas.OrderBy(l => l.Nombre).ToList();
            
            cmbLineas.DataSource = lineasCMB;

            cmbLineas.DisplayMember = "Nombre";
            cmbLineas.ValueMember = "Id";

            //lineaActual = Linea.BuscarLinea(Convert.ToInt32(cmbLineas.SelectedValue));
            lineaActual = LineaTP.todasLineas.Where(l => l.Id == Convert.ToInt32(cmbLineas.SelectedValue)).FirstOrDefault();

            if (lineaActual != null)
            {
                CargarLineaActual();
            }
        }

        void CargarLineaActual()
        {
            previewOverlay.Clear();
            paraderosOverlay.Clear();
            otrosMarkersOverlay.Clear();

            //Ruta rIda = Ruta.BuscarPorId(lineaActual.RutaIdaId.Value);
            //Ruta rVuelta = Ruta.BuscarPorId(lineaActual.RutaVueltaId.Value);
            RutaTP rIda = lineaActual.rutaIda;
            RutaTP rVuelta = lineaActual.rutaVuelta;

            MapController.CargarRutaEnMapaOffline(rIda, gmapController, paraderosOverlay, previewOverlay, Color.Red);
            MapController.CargarRutaEnMapaOffline(rVuelta, gmapController, paraderosOverlay, previewOverlay, Color.Blue);

            //List<Coordenada> coor = Ruta.ObtenerVerticesDeInicioAFin(rIda);
            List<Coordenada> coor = rIda.listaCoordenadas;
            MapController.CrearMarcadorInicio(coor, gmapController, otrosMarkersOverlay, "Inicio ruta de Ida", GMarkerGoogleType.red);
        }

        private void btnBorrarLinea_Click(object sender, EventArgs e)
        {
            previewOverlay.Clear();
            paraderosOverlay.Clear();
            otrosMarkersOverlay.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //lineaActual = Linea.BuscarLinea(Convert.ToInt32(cmbLineas.SelectedValue));
                lineaActual = LineaTP.todasLineas.Where(l => l.Id == Convert.ToInt32(cmbLineas.SelectedValue)).FirstOrDefault();
                CargarLineaActual();
            }
            catch
            {

            }

        }
        #endregion

        private bool ActualizarRecorrido = false;

        private void btnTomarControl_Click(object sender, EventArgs e)
        {
            Usuario userActual = Usuario.BuscarUsuarioPorMail(txtEmail.Text);

            if(userActual == null)
            {
                MessageBox.Show("No existe ese mail");
                return;
            }

            //crear marcador con su posicion

            GMarkerGoogle userMarker = new GMarkerGoogle(new PointLatLng(userActual.Latitud, userActual.Longitud), GMarkerGoogleType.green_small);

            userMarker.ToolTipText = userActual.Email;
            userMarker.Tag = userActual.Id;
            userControladoOverlay.Markers.Add(userMarker);

            usuariosControlados.Add(userActual);
            usersMarkers.Add(userMarker);
            Usuario.ActualizarPosicion(userActual.Id, userMarker.Position.Lat, userMarker.Position.Lng, ActualizarRecorrido);

        }

        List<int> listaIDControlados = new List<int>();
        List<PointLatLng> listaPosicionesControladas = new List<PointLatLng>();

        private void timer1_Tick(object sender, EventArgs e)
        {


            //if (userControlandoActual == null)
            //    return;

            //GMarkerGoogle userMarker = usersMarkers.Where(m => m.Tag + "" == userControlandoActual.Id.ToString()).FirstOrDefault();

            //if (userMarker == null)
            //    return;


            //Usuario.ActualizarPosicion(userControlandoActual.Id, userMarker.Position.Lat, userMarker.Position.Lng, ActualizarRecorrido);

            //lblMicroId.Text = "---";
            //lblMicroPatente.Text = "---";
            //lblSigParadero.Text = "---";
            //lblSigVertice.Text = "---";


            //lblUserMoviendo.Text = userControlandoActual.Email;

            //if (userControlandoActual.MicroChoferId != null)
            //{
            //    Micro micro = MicroChofer.GetMicro(userControlandoActual.MicroChoferId.Value);
            //    lblMicroId.Text = micro.Id + "";
            //    lblMicroPatente.Text = micro.Patente;

            //    if (micro.MicroParaderoId != null)
            //    {
            //        Paradero p = MicroParadero.GetParadero(micro.MicroParaderoId.Value);
            //        lblSigParadero.Text = p.Id + "";
            //    }
            //    if (micro.SiguienteVerticeId != null)
            //    {
            //        lblSigVertice.Text = micro.SiguienteVerticeId.Value + "";
            //    }
            //}

            if (usersControlados.Count == 0)
                return;

            listaIDControlados.Clear();
            listaPosicionesControladas.Clear();

            foreach (Usuario u in usersControlados)
            {
                GMarkerGoogle userMarker = usersMarkers.Where(m => m.Tag + "" == u.Id.ToString()).FirstOrDefault();

                if (userMarker == null)
                    continue;

                listaIDControlados.Add(u.Id);
                listaPosicionesControladas.Add(new PointLatLng(userMarker.Position.Lat, userMarker.Position.Lng));

                //Usuario.ActualizarPosicion(u.Id, userMarker.Position.Lat, userMarker.Position.Lng, ActualizarRecorrido);

                lblMicroId.Text = "---";
                lblMicroPatente.Text = "---";
                lblSigParadero.Text = "---";
                lblSigVertice.Text = "---";


                lblUserMoviendo.Text = u.Email;

                if (u.MicroChoferId != null)
                {
                    Micro micro = MicroChofer.GetMicro(u.MicroChoferId.Value);
                    lblMicroId.Text = micro.Id + "";
                    lblMicroPatente.Text = micro.Patente;

                    if (micro.MicroParaderoId != null)
                    {
                        Paradero p = MicroParadero.GetParadero(micro.MicroParaderoId.Value);
                        lblSigParadero.Text = p.Id + "";
                    }
                    if (micro.SiguienteVerticeId != null)
                    {
                        lblSigVertice.Text = micro.SiguienteVerticeId.Value + "";
                    }
                }
            }

            Usuario.ActualizarMultiplesPosiciones(listaIDControlados, listaPosicionesControladas);
        }

        private void gmapController_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            GMarkerGoogle marker = (GMarkerGoogle)item;

            if (usersMarkers.Contains(marker) == false)
                return;

            Usuario userClickeado = usuariosControlados.Where(u => u.Id == Convert.ToInt32(marker.Tag)).FirstOrDefault();
            //if (e.Button == MouseButtons.Right)
            //{
            //    //Boton derecho detiene la actualizacion de posicion del marcador y lo borra      
            //    Usuario.PararActualizaciónPosicion(userClickeado.Id);
            //    userControladoOverlay.Markers.Remove(marker);

            //    usuariosControlados.Remove(userClickeado);
            //    usersMarkers.Remove(marker);
            //    lblUserMoviendo.Text = "";
            //    lblMicroId.Text = "---";
            //    lblMicroPatente.Text = "---";
            //    lblSigParadero.Text = "---";
            //    lblSigVertice.Text = "---";
            //}
            //else
            //{
            //    lblMicroId.Text = "---";
            //    lblMicroPatente.Text = "---";
            //    lblSigParadero.Text = "---";
            //    lblSigVertice.Text = "---";

            //    if (userControlandoActual != null)
            //    {
            //        userControlandoActual = null;
            //        lblUserMoviendo.Text = "";
            //    }
            //    else
            //    {
            //        userControlandoActual = userClickeado;
            //        lblUserMoviendo.Text = userControlandoActual.Email;

            //        if (userClickeado.MicroChoferId != null)
            //        {
            //            Micro micro = MicroChofer.GetMicro(userClickeado.MicroChoferId.Value);
            //            lblMicroId.Text = micro.Id + "";
            //            lblMicroPatente.Text = micro.Patente;

            //            if (micro.MicroParaderoId != null)
            //            {
            //                Paradero p = MicroParadero.GetParadero(micro.MicroParaderoId.Value);
            //                lblSigParadero.Text = p.Id + "";
            //            }
            //            if (micro.SiguienteVerticeId != null)
            //            {
            //                lblSigVertice.Text = micro.SiguienteVerticeId.Value + "";
            //            }
            //        }
            //    }
            //}

            if (e.Button == MouseButtons.Right)
            {
                //Boton derecho detiene la actualizacion de posicion del marcador y lo borra      
                Usuario.PararActualizaciónPosicion(userClickeado.Id);
                userControladoOverlay.Markers.Remove(marker);

                usuariosControlados.Remove(userClickeado);
                usersMarkers.Remove(marker);
                lblUserMoviendo.Text = "";
                lblMicroId.Text = "---";
                lblMicroPatente.Text = "---";
                lblSigParadero.Text = "---";
                lblSigVertice.Text = "---";
            }
            else
            {
                lblMicroId.Text = "---";
                lblMicroPatente.Text = "---";
                lblSigParadero.Text = "---";
                lblSigVertice.Text = "---";


                if (usersControlados.Count > 0)
                {
                    usersControlados.Clear();
                    lblUserMoviendo.Text = "";
                }
                else
                {
                    usersControlados.Clear();
                    usersControlados.Add(userClickeado);
                    lblUserMoviendo.Text = userClickeado.Email;

                    if (userClickeado.MicroChoferId != null)
                    {
                        Micro micro = MicroChofer.GetMicro(userClickeado.MicroChoferId.Value);
                        lblMicroId.Text = micro.Id + "";
                        lblMicroPatente.Text = micro.Patente;

                        if (micro.MicroParaderoId != null)
                        {
                            Paradero p = MicroParadero.GetParadero(micro.MicroParaderoId.Value);
                            lblSigParadero.Text = p.Id + "";
                        }
                        if (micro.SiguienteVerticeId != null)
                        {
                            lblSigVertice.Text = micro.SiguienteVerticeId.Value + "";
                        }
                    }
                }
            }
        }

        private void gmapController_MouseMove(object sender, MouseEventArgs e)
        {
            //if (userControlandoActual == null)
            //    return;

            //GMarkerGoogle userMarker = usersMarkers.Where(m => Convert.ToInt32(m.Tag) == userControlandoActual.Id).FirstOrDefault();
            ////marcador sigue al mouse
            //double lat = gmapController.FromLocalToLatLng(e.X, e.Y).Lat;
            //double lng = gmapController.FromLocalToLatLng(e.X, e.Y).Lng;

            //if(userMarker != null)
            //    userMarker.Position = new PointLatLng(lat, lng);

            //if (usersControlados.Count == 0)
            //    return;

            foreach(Usuario u in usersControlados)
            {
                GMarkerGoogle userMarker = usersMarkers.Where(m => Convert.ToInt32(m.Tag) == u.Id).FirstOrDefault();
                //marcador sigue al mouse
                double lat = gmapController.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = gmapController.FromLocalToLatLng(e.X, e.Y).Lng;

                if (userMarker != null)
                    userMarker.Position = new PointLatLng(lat, lng);

                if (usersControlados.Count == 0)
                    return;
            }

            if (usersControlados.Count == 1)
            {
                lblUserMoviendo.Text = usersControlados[0].Email;
            }
            else if(usersControlados.Count > 1)
            {
                lblUserMoviendo.Text = "Moviendo mas de 1";
            }
        }

        private void gmapController_MouseLeave(object sender, EventArgs e)
        {
            //userControlandoActual = null;

            usersControlados.Clear();
        }

        private void btnDetenerTodo_Click(object sender, EventArgs e)
        {
            Usuario.PararActualizacionTodos();

            userControladoOverlay.Clear();

            lblUserMoviendo.Text = "";
            lblSigVertice.Text = "---";
            lblSigParadero.Text = "---";
            lblMicroPatente.Text = "---";
            lblMicroId.Text = "---";

            usersMarkers.Clear();
            usuariosControlados.Clear();
            usuariosControlarRecorrido.Clear();
        }

        private void btnIniciarRecorrido_Click(object sender, EventArgs e)
        {
            var BD = new MicroSystemContext();
            Usuario userActual = BD.Usuarios.Where(u => u.Email == txtEmail.Text).FirstOrDefault();

            if (userActual == null)
            {
                MessageBox.Show("No existe ese mail");
                return;
            }
            if (userActual.Rol != Usuario.RolUsuario.Chofer)
            {
                MessageBox.Show("Usuario no es chofer.");
                return;
            }
            if(userActual.MicroChoferId == null)
            {
                MessageBox.Show("Usuario sin micro asignada");
                return;
            }
            if (userActual.MicroChofer.Micro.LineaId == null)
            {
                MessageBox.Show("Micro del chofer no asignada a una linea");
                return;
            }

            usuariosControlarRecorrido.Add(userActual);
            userActual.TransmitiendoPosicion = true;

            

            if (ActualizarRecorrido)
            {
                Micro micro = userActual.MicroChofer.Micro;
                Ruta rIda = micro.Linea.RutaIda;

                Paradero primerParadero = rIda.Paraderos.OrderBy(p => p.Id).ToList()[0];
                Coordenada primerCoordenada = rIda.Coordenadas.Where(c => c.Orden == 0).FirstOrDefault();

                if (micro.MicroParaderoId != null)
                {
                    MicroParadero mp = micro.MicroParadero;
                    BD.MicroParaderos.Remove(mp);
                }

                var geoMicro = new GeoCoordinate(userActual.Latitud, userActual.Longitud);
                var geoParadero = new GeoCoordinate(primerParadero.Latitud, primerParadero.Longitud);

                MicroParadero mpNuevo = new MicroParadero();
                mpNuevo.Micro = micro;
                mpNuevo.Paradero = primerParadero;
                mpNuevo.DistanciaEntre = geoMicro.GetDistanceTo(geoParadero);

                micro.MicroParadero = mpNuevo;
                micro.SiguienteVertice = primerCoordenada;

                BD.MicroParaderos.Add(mpNuevo);
            }
            BD.SaveChanges();
            

        }

        private void btnDetenerRecorrido_Click(object sender, EventArgs e)
        {
            var BD = new MicroSystemContext();
            Usuario userActual = BD.Usuarios.Where(u => u.Email == txtEmail.Text).FirstOrDefault();

            if (userActual == null)
            {
                MessageBox.Show("No existe ese mail");
                return;
            }
            if (userActual.MicroChoferId == null)
            {
                MessageBox.Show("Usuario sin micro asignada");
                return;
            }
            if (userActual.MicroChofer.Micro.LineaId == null)
            {
                MessageBox.Show("Micro del chofer no asignada a una linea");
                return;
            }

            #region Quitar usuario de la lista de controlar recorrido
            Usuario aBorrar = null;
            foreach(Usuario u in usuariosControlarRecorrido)
            {
                if(u.Id == userActual.Id)
                {
                    aBorrar = u;
                }
            }
            if(aBorrar != null)
                usuariosControlarRecorrido.Remove(aBorrar);
            #endregion

            userActual.TransmitiendoPosicion = false;
            Micro micro = userActual.MicroChofer.Micro;
            micro.SiguienteVertice = null;
            micro.SiguienteVerticeId = null;
            if (micro.MicroParaderoId != null)
            {
                MicroParadero mp = micro.MicroParadero;
                BD.MicroParaderos.Remove(mp);
            }
            BD.SaveChanges();
        }

        private void CargarDatos()
        {
            MicroSystemContext db = new MicroSystemContext();

            List<Linea> todasLineas = db.Lineas.ToList();
            List<Ruta> todasRutas = db.Rutas.ToList();

            List<LineaTP> lineasPrograma = new List<LineaTP>();
            List<RutaTP> rutasPrograma = new List<RutaTP>();

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
            }

            foreach (Linea l in todasLineas)
            {
                LineaTP lineaTP = new LineaTP();
                lineaTP.Id = l.Id;
                lineaTP.Nombre = l.Nombre;
                lineaTP.Micros = Linea.ObtenerMicrosDeLinea(l.Id);

                lineaTP.rutaIda = rutasPrograma.Where(r => r.Id == l.RutaIdaId).FirstOrDefault();
                lineaTP.rutaVuelta = rutasPrograma.Where(r => r.Id == l.RutaVueltaId).FirstOrDefault();
                lineaTP.rutasDeLinea = rutasPrograma.Where(r => r.LineaId == l.Id).ToList();

                lineasPrograma.Add(lineaTP);
            }

            LineaTP.todasLineas = lineasPrograma;
            RutaTP.todasRutas = rutasPrograma;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ActualizarRecorrido == false)
            {
                ActualizarRecorrido = true;
                button1.Text = "true";
            }
            else
            {
                ActualizarRecorrido = false;
                button1.Text = "false";
            }
        }





        private void gmapController_MouseClick(object sender, MouseEventArgs e)
        {
            double lat = 0;
            double lng = 0;


            if (e.Button == MouseButtons.Right)
            {
                lat = gmapController.FromLocalToLatLng(e.X, e.Y).Lat;
                lng = gmapController.FromLocalToLatLng(e.X, e.Y).Lng;
            }
            else
            {
                return;
            }

            CreateCircle(lat, lng, 150);

        }


        private void CreateCircle(Double lat, Double lon, double radius)
        {
            PointLatLng point = new PointLatLng(lat, lon);
            int segments = 1000;

            List<PointLatLng> gpollist = new List<PointLatLng>();

            for (int i = 0; i < segments; i++)
                gpollist.Add(FindPointAtDistanceFrom(point, i, radius / 1000));

            GMapPolygon gpol = new GMapPolygon(gpollist, "pol");
            gpol.Stroke.Width = 0.001f;

            points_.Clear();
            points_.Polygons.Add(gpol);
        }

        public static PointLatLng FindPointAtDistanceFrom(GMap.NET.PointLatLng startPoint, double initialBearingRadians, double distanceKilometres)
        {
            const double radiusEarthKilometres = 6371.01;
            var distRatio = distanceKilometres / radiusEarthKilometres;
            var distRatioSine = Math.Sin(distRatio);
            var distRatioCosine = Math.Cos(distRatio);

            var startLatRad = DegreesToRadians(startPoint.Lat);
            var startLonRad = DegreesToRadians(startPoint.Lng);

            var startLatCos = Math.Cos(startLatRad);
            var startLatSin = Math.Sin(startLatRad);

            var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));

            var endLonRads = startLonRad + Math.Atan2(
                          Math.Sin(initialBearingRadians) * distRatioSine * startLatCos,
                          distRatioCosine - startLatSin * Math.Sin(endLatRads));

            return new GMap.NET.PointLatLng(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads));
        }

        public static double DegreesToRadians(double degrees)
        {
            const double degToRadFactor = Math.PI / 180;
            return degrees * degToRadFactor;
        }

        public static double RadiansToDegrees(double radians)
        {
            const double radToDegFactor = 180 / Math.PI;
            return radians * radToDegFactor;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void gmapController_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        bool spacePressing = false;
        private void gmapController_KeyPress(object sender, KeyPressEventArgs e)
        {
            spacePressing = true;
            
        }

        private void gmapController_KeyUp(object sender, KeyEventArgs e)
        {
            spacePressing = false;
            usersControlados.Clear();
        }

        private void gmapController_OnMarkerEnter(GMapMarker item)
        {
            if(spacePressing == true)
            {
                GMarkerGoogle marker = (GMarkerGoogle)item;

                if (usersMarkers.Contains(marker) == false)
                    return;

                Usuario userClickeado = usuariosControlados.Where(u => u.Id == Convert.ToInt32(marker.Tag)).FirstOrDefault();

     
                lblMicroId.Text = "---";
                lblMicroPatente.Text = "---";
                lblSigParadero.Text = "---";
                lblSigVertice.Text = "---";

                //if (userControlandoActual != null)
                //{
                //    userControlandoActual = null;
                //    lblUserMoviendo.Text = "";
                //}
                //else
                //{

                //userControlandoActual = userClickeado;
                //lblUserMoviendo.Text = userControlandoActual.Email;

                usersControlados.Add(userClickeado);
                if(usersControlados.Count == 1)
                {
                    lblUserMoviendo.Text = usersControlados[0].Email;
                }

                if (userClickeado.MicroChoferId != null)
                {
                    Micro micro = MicroChofer.GetMicro(userClickeado.MicroChoferId.Value);
                    lblMicroId.Text = micro.Id + "";
                    lblMicroPatente.Text = micro.Patente;

                    if (micro.MicroParaderoId != null)
                    {
                        Paradero p = MicroParadero.GetParadero(micro.MicroParaderoId.Value);
                        lblSigParadero.Text = p.Id + "";
                    }
                    if (micro.SiguienteVerticeId != null)
                    {
                        lblSigVertice.Text = micro.SiguienteVerticeId.Value + "";
                    }
                }
                
                


            }
        }

 
    }
}
