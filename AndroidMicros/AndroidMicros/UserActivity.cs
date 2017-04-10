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

namespace AndroidMicros
{
    [Activity(Label = "UserActivity")]
    public class UserActivity : Activity, IOnMapReadyCallback
    {
        public static readonly string LLAVE_NOMBRE = "llNombre";

        Double lat = -40.572133;
        Double lon = -73.1340846;
        private GoogleMap gmap;

        public void OnMapReady(GoogleMap googleMap)
        {
            gmap = googleMap;

            gmap.MapType = GoogleMap.MapTypeNormal;
            gmap.UiSettings.ZoomControlsEnabled = true;
            gmap.UiSettings.CompassEnabled = true;

            LatLng location = new LatLng(lat, lon); //Osorno
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(18);
            builder.Bearing(155);
            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            gmap.MoveCamera(cameraUpdate);
        }   

        protected override void OnCreate(Bundle savedInstanceState)
        {   
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.User);

            setupmaygoogleMap();

            //var lblNombre = (TextView)FindViewById(Resource.Id.txtNombre);
            //var nombre = Intent.GetStringExtra(LLAVE_NOMBRE);

            //lblNombre.Text = nombre;
        }
        private void setupmaygoogleMap()
        {
            if (gmap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }
    }
}