using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System;
using Android.Content;
using Android.Graphics.Drawables;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ImageButton cameraButton;
        ImageButton calenderButton;
        ImageButton settingButton;
        LinearLayout linearLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            linearLayout = (LinearLayout)FindViewById(Resource.Id.mainActivityLayout);
            //relativeLayout = (RelativeLayout)FindViewById(Resource.Id.mainActivityLayout);
            //AnimationDrawable animationDrawable = (AnimationDrawable)relativeLayout.Background;
            //animationDrawable.SetEnterFadeDuration(2000);
            //animationDrawable.SetExitFadeDuration(4000);
            //animationDrawable.Start();

            calenderButton = (ImageButton)FindViewById(Resource.Id.calendarButton);
            calenderButton.Click += OnCalendar;

            cameraButton = (ImageButton)FindViewById(Resource.Id.cameraButton);
            cameraButton.Click += OnCamera;

            settingButton = (ImageButton)FindViewById(Resource.Id.settingsbutton);
            settingButton.Click += OnSettings;

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [Java.Interop.Export("OnToast")]
        public void OnToast(View view)
        {

           //var hello = CosmosAccess.RetrieveDict();


        }
        public void OnCamera(Object sender, EventArgs e)
        {
            var context = Android.App.Application.Context;
            var tostMessage = String.Format("Opening Camera");
            var durtion = ToastLength.Long;
            Toast.MakeText(context, tostMessage, durtion).Show();

            var NxtAct = new Intent(this, typeof(CameraActivity));
            StartActivity(NxtAct);
        }

        public void OnCalendar(Object sender, EventArgs e)
        {
            var context = Android.App.Application.Context;
            var tostMessage = String.Format("Now Showing Calendar");
            var durtion = ToastLength.Long;
            Toast.MakeText(context, tostMessage, durtion).Show();

            var NxtAct = new Intent(this, typeof(CalendarActivity));
            StartActivity(NxtAct);
        }
        public void OnSettings(Object sender, EventArgs e)
        {
            var context = Android.App.Application.Context;
            Toast.MakeText(context, "Opening Settings", ToastLength.Short);
            var NxtAct = new Intent(this, typeof(SettingsActivity));
            StartActivity(NxtAct);
        }



    }
}