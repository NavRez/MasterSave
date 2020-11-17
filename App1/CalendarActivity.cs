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
using Com.Telerik.Widget.Calendar;
using Com.Telerik.Widget.Calendar.Events;
using Java.Util;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace App1
{
    [Activity(Label = "CalendarActivity")]
    public class CalendarActivity : Activity
    {
        CosmosAccess cosmosAccess = new CosmosAccess();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_calendar);

            var temp = cosmosAccess.RetrieveDict();

            RadCalendarView calendarView = (RadCalendarView)FindViewById(Resource.Id.calendarView);
            calendarView.SelectionMode = CalendarSelectionMode.Single;

            Calendar calendar = Java.Util.Calendar.Instance;
            long start = calendar.TimeInMillis;
            int year = calendar.Time.Year;
            int month = calendar.Time.Month;
            string snippetTime = String.Format("{0}-{1}", year.ToString(), month.ToString());
            calendar.Add(CalendarField.Hour, 3);
            long end = calendar.TimeInMillis;
            Event newEvent = new Event(temp["sample1"].ToString(), start, end);
            //temp.["sample1"] is the key in the collection 

            calendar.Add(CalendarField.Hour, 1);
            start = calendar.TimeInMillis;
            calendar.Add(CalendarField.Hour, 1);
            end = calendar.TimeInMillis;
            Event newEvent2 = new Event("Walk to work", start, end);
            newEvent2.EventColor = Android.Graphics.Color.Green;

            IList<Event> events = new List<Event>();
            events.Add(newEvent);
            events.Add(newEvent2);

            calendarView.EventAdapter.Events = events;
            calendarView.EventsDisplayMode = EventsDisplayMode.Popup;

            // Create your application here
        }
    }
}