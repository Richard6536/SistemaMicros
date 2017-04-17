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
using Plugin.Geolocator;
using Android.Gms.Maps;
using Android.Locations;
using Android.Gms.Maps.Model;

namespace MicrosAndroid
{
    [Activity(Label = "LocationActivity")]
    public class LocationActivity : Activity
    {

        Button btnPosition;
        TextView latitud, longitud;

        public static readonly string LLAVE_NOMBRE = "llNombre";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Location);
            btnPosition = (Button)FindViewById(Resource.Id.btnPosition);
            btnPosition.Click += BtnPosition_Click;
        }

        private async void BtnPosition_Click(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 2;

            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            latitud = (TextView)FindViewById(Resource.Id.txtLat);
            longitud = (TextView)FindViewById(Resource.Id.txtLon);

            latitud.Text = position.Latitude.ToString();
            longitud.Text = position.Longitude.ToString();


            Intent intent = new Intent(this, typeof(UserActivity)); //A donde quiero llevar la información
            intent.PutExtra(UserActivity.LatitudeKey, position.Latitude.ToString());
            intent.PutExtra(UserActivity.LongitudeKey, position.Longitude.ToString());
            //Envío de información a través de la llave creada
            StartActivity(intent); //Iniciar envio

        }
    }
}