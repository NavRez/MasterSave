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

namespace App1
{
    [Activity(Label = "CalendarActivity")]
    public class CalendarActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_calendar);

            RadCalendarView calendarView = (RadCalendarView) FindViewById(Resource.Id.calendarView);

            Calendar calendar = Java.Util.Calendar.Instance;
            long start = calendar.TimeInMillis;
            calendar.Add(CalendarField.Hour, 3);
            long end = calendar.TimeInMillis;
            Event newEvent = new Event("Heeeere's Jonny",start,end);

            calendar.Add(CalendarField.Hour, 1);
            start = calendar.TimeInMillis;
            calendar.Add(CalendarField.Hour, 1);
            end = calendar.TimeInMillis;
            Event newEvent2 = new Event("Oh no Jonny is dead", start, end);
            newEvent2.EventColor = Android.Graphics.Color.Green;

            IList<Event> events = new List<Event>();
            events.Add(newEvent);
            events.Add(newEvent2);

            calendarView.EventAdapter.Events = events;

            //return calendarView;

            // Create your application here
        }
    }
}