using System;
using Android.App;
using Android.Support.V7.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App1
{

	[Activity(Label = "App1", Theme = "@style/AppTheme", MainLauncher = true)]
	public class LoginActivity : AppCompatActivity
	{
		Button login;
		Button signup;

		protected override void OnCreate(Bundle savedInstanceState) {

			base.OnCreate(savedInstanceState);
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_login);

			//Initializing button from layout
			login =(Button)FindViewById(Resource.Id.login);
			login.Click += OnLogin;
			signup = (Button)FindViewById(Resource.Id.signup);
			signup.Click += OnSignup;
		}

		public void OnSignup(Object sender, EventArgs e)
		{
			Toast.MakeText(BaseContext.ApplicationContext, "Opening Signup Page...", ToastLength.Short);
			signup.SetBackgroundColor(Android.Graphics.Color.Aqua);
			var NxtAct = new Intent(this, typeof(SignupActivity));
			StartActivity(NxtAct);
		}
		public void OnLogin(Object sender, EventArgs e)
		{
			Toast.MakeText(BaseContext.ApplicationContext, "Loggin Successful!", ToastLength.Short);
			login.SetBackgroundColor(Android.Graphics.Color.Aqua);
			var NxtAct = new Intent(this, typeof(MainActivity));
			StartActivity(NxtAct);
		}
	}
}