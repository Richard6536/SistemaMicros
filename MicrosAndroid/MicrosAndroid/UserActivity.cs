using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Java.Util;
using static Android.Gms.Maps.GoogleMap;
using Android.Gms.Tasks;
using Android.Locations;
using static Android.Provider.SyncStateContract;
using Android.Gms.Common.Apis;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MicrosAndroid
{
    [Activity(Label = "UserActivity", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/MyTheme")]
    public class UserActivity : AppCompatActivity, IOnMapReadyCallback
    {


        private Android.Support.V7.Widget.Toolbar mToolbar;
        private DrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private Android.Widget.ListView mLeftDrawer;
        private ArrayAdapter mLeftAdapter;
        private List<String> mLeftDataSet;

        //Lista de Marker
        ArrayList markerOptions = new ArrayList();
        

        public static readonly string LatitudeKey = "latKey";
        public static readonly string LongitudeKey = "longKey";
        
        //Double lat = -40.572133;
        //Double lon = -73.1340846;
        private GoogleMap gmap;

        private String[] arraySpinner;

        public void ListarSpinner()
        {
            this.arraySpinner = new String[]
            {
                "Linea 1", "Linea 2", "Linea 3", "Linea 4", "Linea 5"
            };


            Spinner spiner = (Spinner)FindViewById(Resource.Id.spinner1);
            ArrayAdapter<String> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, arraySpinner);
            spiner.Adapter = adapter;
            
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            gmap = googleMap;
            PolyLines();



            //double latitude = Convert.ToDouble(Intent.GetStringExtra(LatitudeKey));
            //double longitude = Convert.ToDouble(Intent.GetStringExtra(LongitudeKey));

            //gmap.MapType = GoogleMap.MapTypeNormal;
            //gmap.UiSettings.ZoomControlsEnabled = true;
            //gmap.UiSettings.CompassEnabled = true;

            //MarkerOptions marker = new MarkerOptions();
            //marker.SetPosition(new LatLng(latitude, longitude));
            //marker.SetTitle("Mi posición");
            //marker.SetSnippet("Lat: "+latitude.ToString()+" Lng: "+longitude.ToString());
            //gmap.AddMarker(marker);

            //LatLng location = new LatLng(latitude, longitude); //Osorno
            //CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            //builder.Target(location);
            //builder.Zoom(18);
            //builder.Bearing(155);
            //CameraPosition cameraPosition = builder.Build();
            //CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            //gmap.MoveCamera(cameraUpdate);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserMap);

            setupmaygoogleMap();
            ListarSpinner();

            mToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<Android.Widget.ListView>(Resource.Id.left_drawer);

            SetSupportActionBar(mToolbar);

            mLeftDataSet = new List<string>();
            mLeftDataSet.Add("Item 1");
            mLeftDataSet.Add("Item 2");
            mLeftAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
            mLeftDrawer.Adapter = mLeftAdapter;

            //----------------------------------------

            //SupportActionBar.Title = "Yay for the Toolbar!";

            mDrawerToggle = new DrawerToggle(
                this,                       //Host Activity
                mDrawerLayout,              //DrawerLayout
                Resource.String.openDrawer, //Opened Message
                Resource.String.closeDrawer //Closed Message
                );

            mDrawerLayout.AddDrawerListener(mDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            mDrawerToggle.SyncState();

            if(savedInstanceState != null)
            {
                if(savedInstanceState.GetString("DrawerState") == "Opened")
                {
                    SupportActionBar.SetTitle(Resource.String.openDrawer);
                }
                else
                {
                    SupportActionBar.SetTitle(Resource.String.closeDrawer);
                }
                
            }
            else
            {
                //Inicializar en "closeDrawer" al llegar a este Activity 
                SupportActionBar.SetTitle(Resource.String.closeDrawer);
            }


            //var lblNombre = (TextView)FindViewById(Resource.Id.txtNombre);
            //var nombre = Intent.GetStringExtra(LLAVE_NOMBRE);

            //lblNombre.Text = nombre;
        }

        public void PolyLines ()
        {

            List<Position> RouteCoordinates = new List<Position>();
            RouteCoordinates.Add(new Position(-40.5757084, -73.1291547));
            RouteCoordinates.Add(new Position(-40.5753662, -73.126805));
            RouteCoordinates.Add(new Position(-40.5729825, -73.1255498));
            RouteCoordinates.Add(new Position(-40.5722654, -73.1357207));
            RouteCoordinates.Add(new Position(-40.5757084, -73.1291547));

            var polylineOptions = new PolylineOptions();
            polylineOptions.InvokeColor(0x66FF0000);

            foreach (var position in RouteCoordinates)
            {
                polylineOptions.Add(new LatLng(position.Latitude, position.Longitude));
            }

            gmap.AddPolyline(polylineOptions);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }

        private void setupmaygoogleMap()
        {
            if (gmap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.action_menu, menu);
        //    return base.OnCreateOptionsMenu(menu);
        //}

        protected override void OnSaveInstanceState(Bundle outState)
        {
            if(mDrawerLayout.IsDrawerOpen((int)GravityFlags.Left))
            {
                outState.PutString("DrawerState", "Opened");
            }
            else
            {
                outState.PutString("DrawerState", "Closed");
            }
            base.OnSaveInstanceState(outState);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            mDrawerToggle.SyncState();
        }

        //public void OnMapClick(LatLng point)
        //{
        //    MarkerOptions marker = new MarkerOptions();
        //    marker.SetPosition(new LatLng(point.Latitude, point.Longitude));
        //    marker.SetTitle("Mi posición");
        //    marker.SetSnippet("Lat: " + point.Latitude.ToString() + " Lng: " + point.Longitude.ToString());
        //    gmap.AddMarker(marker);
        //}
    }
}