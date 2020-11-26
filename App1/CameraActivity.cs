using System;
using Android;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Widget;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace App1
{
    [Activity(Label = "CameraActivity", Theme = "@style/AppTheme")]
    public class CameraActivity : Activity
    {
        Button captureButton;
        ImageView imageView;
        static int count = 0;
        Vision vision;
        LinearLayout linearLayout;

        readonly string[] permissions =
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera
        };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_camera);

            linearLayout = (LinearLayout)FindViewById(Resource.Id.cameraLayout);
            AnimationDrawable animationDrawable = (AnimationDrawable)linearLayout.Background;
            animationDrawable.SetEnterFadeDuration(2000);
            animationDrawable.SetExitFadeDuration(4000);
            animationDrawable.Start();

            captureButton = (Button)FindViewById(Resource.Id.capureButton);
            imageView = (ImageView)FindViewById(Resource.Id.pictureView);

            captureButton.Click += CaptureButton_Click;
            RequestPermissions(permissions, 0);
        }

        async void TakePicture()
        {
            await CrossMedia.Current.Initialize();
            MediaFile photo;
            if (CrossMedia.Current.IsCameraAvailable)
            {
                string name = String.Format("Receipt{0}.jpg", count.ToString());
                photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions 
                { 
                    Directory = "MasterSaveReceipts",
                    CompressionQuality = 60,
                    Name = name
                
                });
                count++;
                if (photo == null)
                {
                    return;
                }

                byte[] bus = System.IO.File.ReadAllBytes(photo.Path);
                vision = new Vision(photo.Path);
                Bitmap bitmap = BitmapFactory.DecodeByteArray(bus, 0, bus.Length);
                imageView.SetImageBitmap(bitmap);
                vision.LoadJson();
            }
            else
            {
                photo = await CrossMedia.Current.PickPhotoAsync();
            }
        }

        private void CaptureButton_Click(object sender, EventArgs e)
        {
            TakePicture();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}