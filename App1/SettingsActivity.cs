using System;

using Android.App;
using Android.OS;
using Android.Widget;

namespace App1
{
    [Activity(Label = "SettingsActivity")]
    public class SettingsActivity : Activity
    {
        EditText year;
        EditText month;
        EditText day;
        Button button;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_settings);
            button = (Button)FindViewById(Resource.Id.submitbutton);
            year = (EditText)FindViewById(Resource.Id.yearText);
            month = (EditText)FindViewById(Resource.Id.monthText);
            day = (EditText)FindViewById(Resource.Id.dayText);
            // Create your application here
            button.Click += OnSubmit;
        }

        public void OnSubmit(object sender, EventArgs e)
        {
            SettingsHelper.ConvertVals(day.Text, month.Text, year.Text);
            var context = Android.App.Application.Context;
            if (SettingsHelper.Day == 0)
            {
                var tostMessage = String.Format("Date set to mm:yyyy : {0}-{1}",SettingsHelper.Month.ToString(), SettingsHelper.Year.ToString());
                var durtion = ToastLength.Long;
                Toast.MakeText(context, tostMessage, durtion).Show();
            }
            else
            {
                var tostMessage = String.Format("Date set to dd:mm:yyyy : {0}:{1}:{2}", SettingsHelper.Day.ToString(), SettingsHelper.Month.ToString(), SettingsHelper.Year.ToString());
                var durtion = ToastLength.Long;
                Toast.MakeText(context, tostMessage, durtion).Show();
            }
          
            OnBackPressed();
        }
    }
}