using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.Gms.Maps.GoogleMap;

namespace SigmaDzuwenaliaXamarin
{
    enum MapState { PLACING_POLICE, PLACING_FLANKI, PLACING_DROP, NULL };



    class MapController : AppCompatActivity, IOnMapReadyCallback, IOnMapClickListener
    {
        private const int _iconSize=35;
        static public MapState MapState= MapState.NULL;
        private GoogleMap _googleMap;

        

        private void MarkPolice(DateTime date, LatLng pos)
        {
            var markerOption = new MarkerOptions().SetPosition(pos);
            markerOption.SetTitle(date.ToString());
            var bmDescriptor = BitmapDescriptorFactory.FromBitmap(resizeMapIcons(2130837627, _iconSize, _iconSize));
            markerOption.SetIcon(bmDescriptor);
            _googleMap.AddMarker(markerOption);
        }

        public void OnMapClick(LatLng point)
        {
            var markerOption = new MarkerOptions().SetPosition(point);
            markerOption.SetTitle("test");
            var bmDescriptor = BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed);
            switch (MapController.MapState)
            {
                case (MapState.PLACING_POLICE):
                    MarkPolice(DateTime.Now, point);
                    ConnectionHelper.SendPolice(point); 
                    break;
                case (MapState.NULL):
                    bmDescriptor = BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueYellow);
                    break;
            }
            MapController.MapState = MapState.NULL;
            
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            //location layer on
            googleMap.MyLocationEnabled = true;
            googleMap.SetOnMapClickListener(this);

            _googleMap = googleMap;
            foreach (var a in ConnectionHelper.GetAllPolice())
            {
                MarkPolice(a.PatrolDate, new LatLng(a.XCoordinate, a.YCoordinate));
            }
        }


        private Bitmap resizeMapIcons(int id, int width, int height)
        {
            var imageBitmap = BitmapFactory.DecodeResource(Android.App.Application.Context.Resources, id);
            Bitmap resizedBitmap = Bitmap.CreateScaledBitmap(imageBitmap, width, height, false);
            return resizedBitmap;
        }
    }
}