using System;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;

namespace SigmaDzuwenaliaXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private MapController mapController;

        readonly string[] PermissionsLocation =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            mapController = new MapController();

            //TODO permission management
            while (CheckSelfPermission(PermissionsLocation[0]) == Permission.Denied ||
                CheckSelfPermission(PermissionsLocation[1])==Permission.Denied)
            {
                RequestPermissions(PermissionsLocation, 1);
            }



            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(mapController);



            //syf
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);


            Button report = FindViewById<Button>(Resource.Id.reportPolice);
            report.Click += ReportPoliceOnClick; 

        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_flanki)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

       
        private void ReportPoliceOnClick(object sender, EventArgs eventArgs)
        {
            MapController.MapState = MapState.PLACING_POLICE;
        }
        


    }


}
