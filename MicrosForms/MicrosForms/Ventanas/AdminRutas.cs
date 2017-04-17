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

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;


namespace MicrosForms.Ventanas
{
    public partial class AdminRutas : Form
    {
        bool editarMapaExistente = false;
        bool rehacerPresionado = false;
        Ruta rutaAEditar;

        bool editandoMapa = false;
        bool editandoParaderos = false;

        GMapOverlay previewOverlay;
        GMapOverlay completeOverlay;
        GMapOverlay paraderosOverlay;

        GMapOverlay otrosMarkersOverlay;

        List<GMarkerGoogle> markParaderos;
        List<GMarkerGoogle> otrosMarkersList;

        List<PointLatLng> posVertices;
        List<PointLatLng> puntosClickeados;

        GMarkerGoogle puntoInicioFragmentos;
        List<GMapRoute> fragmentosDeRuta;


        public AdminRutas()
        {
            InitializeComponent();

            IniciarMapa();

            panelEditCreate.Visible = false;

            markParaderos = new List<GMarkerGoogle>();
            posVertices = new List<PointLatLng>();
            puntosClickeados = new List<PointLatLng>();
            otrosMarkersList = new List<GMarkerGoogle>();

            previewOverlay = new GMapOverlay("preview");
            completeOverlay = new GMapOverlay("complete");
            paraderosOverlay = new GMapOverlay("paraderos");
            otrosMarkersOverlay = new GMapOverlay("otrosMarkers");

            gmapController.Overlays.Add(previewOverlay);
            gmapController.Overlays.Add(completeOverlay);
            gmapController.Overlays.Add(paraderosOverlay);
            gmapController.Overlays.Add(otrosMarkersOverlay);

            CargarCombobox();
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
            gmapController.MaxZoom = 18;
            gmapController.Zoom = 14;

            gmapController.IgnoreMarkerOnMouseWheel = true;
        }

        #region toolstrips

        private void líneasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminLineas());
        }

        private void microsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminMicros());
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new AdminUsuarios());
        }

        private void ventanaInicio_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new InicioReal());
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.CambiarForm(this, new Login());
        }
        #endregion

        //EDITAR
        private void btnEditarRuta_Click(object sender, EventArgs e)
        {
            editarMapaExistente = true;

            panelEditCreate.Visible = true;

            btnEditarRuta.Enabled = false;
            btnEliminarRuta.Enabled = false;
            btnCrearNueva.Enabled = false;
            cmbListaRutas.Enabled = false;

            btnAceptarParaderos.Enabled = false;
            btnAceptarRuta.Enabled = false;
            btnDeshacer.Enabled = false;

            lblTituloPanel.Text = "Editar ruta";
            lblNombreRuta.Text = "Editar nombre";

            btnCrearRuta.Text = "Rehacer ruta";
            btnCrearParaderos.Text = "Editar paraderos";

            markParaderos = new List<GMarkerGoogle>();
            otrosMarkersList = new List<GMarkerGoogle>();
            fragmentosDeRuta = new List<GMapRoute>();

            previewOverlay.Clear();
            completeOverlay.Clear();
            paraderosOverlay.Clear();
            otrosMarkersOverlay.Clear();

            rutaAEditar = Ruta.BuscarPorId(Convert.ToInt32(cmbListaRutas.SelectedValue));
            txtNombreEditRuta.Text = rutaAEditar.Nombre;

            CargarRutaEnMapa(rutaAEditar);
        }
        //CREAR
        private void btnCrearNueva_Click(object sender, EventArgs e)
        {
            panelEditCreate.Visible = true;

            btnEditarRuta.Enabled = false;
            btnEliminarRuta.Enabled = false;
            btnCrearNueva.Enabled = false;
            cmbListaRutas.Enabled = false;

            btnAceptarParaderos.Enabled = false;
            btnAceptarRuta.Enabled = false;
            btnDeshacer.Enabled = false;

            lblTituloPanel.Text = "Crear nueva ruta";
            lblNombreRuta.Text = "Nombre";

            btnCrearRuta.Text = "Crear ruta";
            btnCrearParaderos.Text = "Crear paraderos";

            txtNombreEditRuta.Text = "";

            markParaderos = new List<GMarkerGoogle>();
            otrosMarkersList = new List<GMarkerGoogle>();
            fragmentosDeRuta = new List<GMapRoute>();

            previewOverlay.Clear();
            completeOverlay.Clear();
            paraderosOverlay.Clear();
            otrosMarkersOverlay.Clear();

        }


        private void gmapController_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double lat = gmapController.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gmapController.FromLocalToLatLng(e.X, e.Y).Lng;

            ClickNuevoPuntoRuta(lat, lng);
            CrearPosicionParadero(lat, lng);
        }



        #region EDICION RUTA
        
        private void btnCrearRuta_Click(object sender, EventArgs e)
        {
            //CREAR/REHACER RUTA DEPENDIENDO DEL BOTÓN PRESIONADO
            editandoMapa = true;
            rehacerPresionado = true;

            btnCrearRuta.Enabled = false;
            btnGuardarCambios.Enabled = false;
            btnCancelarRuta.Enabled = false;
            btnCrearParaderos.Enabled = false;
            btnAceptarParaderos.Enabled = false;

            btnAceptarRuta.Enabled = true;
            btnDeshacer.Enabled = false;

            posVertices = new List<PointLatLng>();
            puntosClickeados = new List<PointLatLng>();

            otrosMarkersOverlay.Clear();
            previewOverlay.Clear();

            RefreshMap();
        }
   
        void ClickNuevoPuntoRuta(double _lat, double _lng)
        {
            //extiende la ruta creada
            if (editandoMapa)
            {
                puntosClickeados.Add(new PointLatLng(_lat, _lng));

                if(puntosClickeados.Count == 1)
                {
                    puntoInicioFragmentos = new GMarkerGoogle(new PointLatLng(_lat, _lng), GMarkerGoogleType.yellow_small);
                    puntoInicioFragmentos.ToolTipText = "Punto de inico";
                    otrosMarkersList.Add(puntoInicioFragmentos);
                    otrosMarkersOverlay.Markers.Add(puntoInicioFragmentos);
                }

                if (puntosClickeados.Count > 1)
                {
                    GDirections direccion;

                    int puntoActual = puntosClickeados.Count - 1;
                    int puntoAnterior = puntoActual - 1;

                    var rutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, puntosClickeados[puntoAnterior], puntosClickeados[puntoActual], false, false, false, false, false);
                    if (direccion == null)
                    {
                        MessageBox.Show("No fue posible crear una ruta al lugar indicado.\nSe recomienda revisar su conexión a internet, por ser necesaria en la búsqueda de rutas.");
                        puntosClickeados.Remove(puntosClickeados.Last());
                        return;
                    }
                    GMapRoute ultimoFragmentoRuta = new GMapRoute(direccion.Route, "rutaPrev");
                    fragmentosDeRuta.Add(ultimoFragmentoRuta);
                    previewOverlay.Routes.Add(ultimoFragmentoRuta);

                    RefreshMap();

                    for (int i = 0; i < direccion.Route.Count; i++)
                    {
                        PointLatLng punto = direccion.Route[i];
                        posVertices.Add(punto);
                    }
                }

                btnDeshacer.Enabled = true;
            }
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            //deshace el ultimo trozo de ruta creado

            if(editandoMapa && puntosClickeados.Count == 1)
            {
                otrosMarkersOverlay.Markers.Remove(puntoInicioFragmentos);
                puntosClickeados.RemoveAt(puntosClickeados.Count - 1);
                btnDeshacer.Enabled = false;

                RefreshMap();
            }

            if(editandoMapa && puntosClickeados.Count >= 2)
            {
                GMapRoute ultimoFragmento = fragmentosDeRuta.Last();
                List<PointLatLng> verticesUltimoFragmento = ultimoFragmento.Points;

                foreach(PointLatLng p in verticesUltimoFragmento)
                {
                    posVertices.Remove(p);
                }
                fragmentosDeRuta.Remove(ultimoFragmento);
                puntosClickeados.RemoveAt(puntosClickeados.Count - 1);
                previewOverlay.Routes.Remove(ultimoFragmento);
            }

        }

        private void btnAceptarRuta_Click(object sender, EventArgs e)
        {
            editandoMapa = false;

            btnCrearRuta.Enabled = true;
            btnGuardarCambios.Enabled = true;
            btnCancelarRuta.Enabled = true;
            btnCrearParaderos.Enabled = true;


            btnAceptarRuta.Enabled = false;
            btnDeshacer.Enabled = false;

        }


        private List<Coordenada> CrearVertices()
        {
            //se revisan los puntos de la ruta para crear las coordenadas y asociarlas unas a otras
            //usado antes de guardar datos

            List<Coordenada> vertices = new List<Coordenada>();

            for (int i = 0; i < posVertices.Count; i++)
            {
                PointLatLng punto = posVertices[i];

                Coordenada c = new Coordenada(punto.Lat, punto.Lng, null);
                vertices.Add(c);
            }

            for (int i = 0; i < vertices.Count; i++)
            {
                if (i < vertices.Count - 1)
                {
                    Coordenada actual = vertices[i];
                    Coordenada sigVertice = vertices[i + 1];

                    actual.Siguiente = sigVertice;
                }
            }

            return vertices;
        }

        #endregion





        #region EDICION PARADEROS

        private void btnCrearParaderos_Click(object sender, EventArgs e)
        {
            editandoParaderos = true;

            btnCrearRuta.Enabled = false;
            btnCrearParaderos.Enabled = false;
            btnDeshacer.Enabled = false;
            btnAceptarRuta.Enabled = false;
            btnGuardarCambios.Enabled = false;
            btnCancelarRuta.Enabled = false;

            btnAceptarParaderos.Enabled = true;

        }

        private void btnAceptarParaderos_Click(object sender, EventArgs e)
        {
            editandoParaderos = false;

            btnCrearRuta.Enabled = true;
            btnCrearParaderos.Enabled = true;
            btnDeshacer.Enabled = true;
            btnAceptarRuta.Enabled = true;
            btnGuardarCambios.Enabled = true;
            btnCancelarRuta.Enabled = true;

            btnAceptarParaderos.Enabled = false;

            btnDeshacer.Enabled = false;
            btnAceptarRuta.Enabled = false;
        }

        void CrearPosicionParadero(double _lat, double _lng)
        {
            //Se hace doble click en el lugar donde se quiere hacer un paradero

            if(editandoParaderos)
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(_lat, _lng), GMarkerGoogleType.purple_small);

                markParaderos.Add(paraderoMarker);
                paraderosOverlay.Markers.Add(paraderoMarker);             
            }
        }

        private List<Paradero> CrearParaderos()
        {
            //se revisan los elementos de la lista de markParaderos para crear los paraderos de verdad
            //usado antes de guardar datos

            List<Paradero> paraderos = new List<Paradero>();

            foreach (var mark in markParaderos)
            {
                Paradero p = new Paradero(mark.Position.Lat, mark.Position.Lng);
                paraderos.Add(p);
            }

            return paraderos;
        }

        private void gmapController_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (editandoParaderos)
            {
                GMarkerGoogle m = markParaderos.Find(mp => mp.Position.Lat == item.Position.Lat && mp.Position.Lng == item.Position.Lng);

                paraderosOverlay.Markers.Remove(item);
                markParaderos.Remove(m);
                RefreshMap();
            }
        }

        private void gmapController_OnMarkerEnter(GMapMarker item)
        {
            if (editandoParaderos)
            {
                GMarkerGoogle m = markParaderos.Find(mp => mp.Position.Lat == item.Position.Lat && mp.Position.Lng == item.Position.Lng);

                if (m != null)
                {
                    item.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    item.ToolTipText = "Click para borrar";
                }
            }
        }

        private void gmapController_OnMarkerLeave(GMapMarker item)
        {
        }

        #endregion




        //CANCELAR
        private void btnCancelarRuta_Click(object sender, EventArgs e)
        {

            txtNombreEditRuta.Text = "";

            paraderosOverlay.Clear();
            previewOverlay.Clear();
            completeOverlay.Clear();
            otrosMarkersOverlay.Clear();

            RefreshMap();

            if(cmbListaRutas.SelectedValue +"" != "")
            {
                btnEditarRuta.Enabled = true;
                cmbListaRutas.Enabled = true;
                btnEliminarRuta.Enabled = true;
            }           

            btnCrearNueva.Enabled = true;
            

            panelEditCreate.Visible = false;

            editarMapaExistente = false;
            rehacerPresionado = false;

            CargarCombobox();
        }
        //GUARDAR CAMBIOS EN BASE DE DATOS
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if(editarMapaExistente)
            {
                GuardarCambiosEdicion();
            }
            else
            {
                GuardarCambiosCreacion();
            }


        }

        void GuardarCambiosEdicion()
        {
            List<Coordenada> vertices = new List<Coordenada>() ;
            List<Paradero> paraderos = CrearParaderos();

            bool resultado;

            if (rehacerPresionado)
            {
                vertices = CrearVertices();

                if (vertices.Count < 2)
                {
                    MessageBox.Show("No puede guardar una ruta vacía.");
                    return;
                }

                resultado = Ruta.EditarRuta(rutaAEditar, txtNombreEditRuta.Text, vertices, paraderos, true);
            }

            resultado = Ruta.EditarRuta(rutaAEditar, txtNombreEditRuta.Text, vertices, paraderos, false);

            if (resultado)
            {
                panelEditCreate.Visible = false;

                btnEditarRuta.Enabled = true;
                btnCrearNueva.Enabled = true;
                cmbListaRutas.Enabled = true;

                MessageBox.Show("Ruta \"" + txtNombreEditRuta.Text + "\" editada correctamente");

                CargarCombobox();

                for (int i = 0; i < cmbListaRutas.Items.Count; i++)
                {
                    cmbListaRutas.SelectedIndex = i;

                    if (cmbListaRutas.Text == txtNombreEditRuta.Text)
                        break;
                }


                editarMapaExistente = false;
                rehacerPresionado = false;
            }

        }

        void GuardarCambiosCreacion()
        {
            List<Coordenada> vertices = CrearVertices();
            List<Paradero> paraderos = CrearParaderos();

            if (vertices.Count < 2)
            {
                MessageBox.Show("No puede guardar una ruta vacía.");
                return;
            }

            if (Ruta.BuscarRutaPorNombre(txtNombreEditRuta.Text) != null)
            {
                MessageBox.Show("El nombre de esa ruta ya existe.");
                return;
            }


            bool resultado = Ruta.CrearRuta(txtNombreEditRuta.Text, vertices, paraderos);

            if (resultado)
            {
                panelEditCreate.Visible = false;

                btnEditarRuta.Enabled = true;
                btnCrearNueva.Enabled = true;
                cmbListaRutas.Enabled = true;

                MessageBox.Show("Ruta \"" + txtNombreEditRuta.Text + "\" creada exitósamente");

                CargarCombobox();
                cmbListaRutas.SelectedIndex = cmbListaRutas.Items.Count - 1;


                editarMapaExistente = false;
                rehacerPresionado = false;
            }


        }




        void RefreshMap()
        {
            gmapController.Zoom = gmapController.Zoom + 1;
            gmapController.Zoom = gmapController.Zoom - 1;
        }

        void CargarCombobox()
        {
            if (!ConnectionTester.IsConnectionActive())
                return;

            cmbListaRutas.DataSource = Ruta.BuscarTodasLasRutas();

            cmbListaRutas.DisplayMember = "Nombre";
            cmbListaRutas.ValueMember = "Id";

            if(cmbListaRutas.Text != "")
            {
                //cargar mapa
                Ruta ruta = Ruta.BuscarPorId(Convert.ToInt32(cmbListaRutas.SelectedValue));
                CargarRutaEnMapa(ruta);
                btnEditarRuta.Enabled = true;
                btnEliminarRuta.Enabled = true;
            }
            else
            {
                btnEditarRuta.Enabled = false;
                btnEliminarRuta.Enabled = false;
            }
        }

        private void cmbListaRutas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbListaRutas.Text != "")
            {
                try
                {
                    Ruta ruta = Ruta.BuscarPorId(Convert.ToInt32(cmbListaRutas.SelectedValue));
                    CargarRutaEnMapa(ruta);
                }
                catch
                {
                    //cae cuando aun no se inicializan componentes
                    return;
                }
            }
        }

        void CargarRutaEnMapa(Ruta _ruta)
        {
            if (!ConnectionTester.IsConnectionActive())
                return;

            previewOverlay.Clear();
            completeOverlay.Clear();
            paraderosOverlay.Clear();
            otrosMarkersOverlay.Clear();

            markParaderos.Clear();
            otrosMarkersList.Clear();

           
            List<Paradero> paraderos = Ruta.ObtenerParaderosDeRuta(_ruta);
            List<Coordenada> vertices = Ruta.ObtenerVerticesDeInicioAFin(_ruta);


            foreach(Paradero p in paraderos) //Crear paraderos en el mapa
            {
                GMarkerGoogle paraderoMarker = new GMarkerGoogle(new PointLatLng(p.Latitud, p.Longitud), GMarkerGoogleType.purple_small);

                markParaderos.Add(paraderoMarker);
                paraderosOverlay.Markers.Add(paraderoMarker);
            }

            Coordenada actual;
            Coordenada siguiente;
            for (int i = 0; i < vertices.Count - 1; i++)
            {

                actual = vertices[i];
                siguiente = vertices[i + 1];

                if (i == 0)
                {
                    gmapController.Position = new PointLatLng(actual.Latitud, actual.Longitud);
                    GMarkerGoogle InicioMarker = new GMarkerGoogle(new PointLatLng(actual.Latitud, actual.Longitud), GMarkerGoogleType.yellow_small);
                    InicioMarker.ToolTipText = "Inicio";
                    otrosMarkersList.Add(InicioMarker);
                    otrosMarkersOverlay.Markers.Add(InicioMarker);
                }

                if (i == vertices.Count - 2)
                {
                    GMarkerGoogle FinalMarker = new GMarkerGoogle(new PointLatLng(siguiente.Latitud, siguiente.Longitud), GMarkerGoogleType.yellow_small);
                    FinalMarker.ToolTipText = "Final";
                    otrosMarkersList.Add(FinalMarker);
                    otrosMarkersOverlay.Markers.Add(FinalMarker);
                }

                List<PointLatLng> puntos = new List<PointLatLng>();
                puntos.Add(new PointLatLng(actual.Latitud, actual.Longitud));
                puntos.Add(new PointLatLng(siguiente.Latitud, siguiente.Longitud));

                GMapPolygon polygon = new GMapPolygon(puntos, "mypolygon");
                polygon.Stroke = new Pen(Color.Red, 4);

                previewOverlay.Polygons.Add(polygon);      
            }

            RefreshMap();



        }

        private void btnEliminarRuta_Click(object sender, EventArgs e)
        {
            //MENSAJE DE CONFIRMACION DE BORRADO
            //NO PERMITIR BORRAR SI LA RUTA ESTÄ ASOCIADA A UNA LINEA

            int idRuta = Convert.ToInt32(cmbListaRutas.SelectedValue);
            bool resultado = Ruta.EliminarRuta(idRuta);

            if(resultado)
            {
                MessageBox.Show("Ruta borrada exitosamente");

                otrosMarkersOverlay.Clear();
                previewOverlay.Clear();
                paraderosOverlay.Clear();

                CargarCombobox();
            }
            else
            {
                MessageBox.Show("Algun error");
            }
        }
    }
}
