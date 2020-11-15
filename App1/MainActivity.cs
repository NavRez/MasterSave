using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System;
using Android.Content;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ImageButton cameraButton;
        ImageButton calenderButton;
        RelativeLayout relativeLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            calenderButton = (ImageButton)FindViewById(Resource.Id.calendarButton);
            calenderButton.Click += OnCalendar;

            cameraButton = (ImageButton)FindViewById(Resource.Id.cameraButton);
            cameraButton.Click += OnCamera;

            /*System.Threading.Tasks.Task.Run(() =>
            {
                relativeLayout = (RelativeLayout)FindViewById(Resource.Id.mainActivityLayout);
                relativeLayout.
            });*/
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [Java.Interop.Export("OnToast")]
        public void OnToast(View view)
        {

           var hello = CosmosAccess.RetrieveDict();


        }
        public void OnCamera(Object sender, EventArgs e)
        {
            cameraButton.SetBackgroundColor(Android.Graphics.Color.DeepPink);
            var NxtAct = new Intent(this, typeof(CameraActivity));
            StartActivity(NxtAct);
        }

        public void OnCalendar(Object sender, EventArgs e)
        {
            var NxtAct = new Intent(this, typeof(CalendarActivity));
            StartActivity(NxtAct);
        }



    }
}