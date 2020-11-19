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
            Date date;
            long start = calendar.TimeInMillis;
            int year = SettingsHelper.Year;
            int month = SettingsHelper.Month;
            int day = SettingsHelper.Day;
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

            calendar.Add(CalendarField.Hour, 1);

            string answer ="";
            IList<Event> events = new List<Event>();

            foreach (List<string> lister in cosmosAccess.TextsList)
            {
                if (lister.Count != 0)
                {
                    int seCount = 0;
                    foreach (string stringList in lister)
                    {
                        if (seCount == 0)
                        {
                            string[] time = stringList.Split("T");
                            if (time.Length == 2)
                            {
                                string[] dateTimes = time[0].Split("-");
                                date = new Date(Int32.Parse(dateTimes[0])-1900, (Int32.Parse(dateTimes[1])-1), Int32.Parse(dateTimes[2]));
                                calendar.Time = date;//  .setTime(date);
                                seCount++;
                            }
                            else
                            {
                                seCount++;
                            }
                        }
                        

                        start = calendar.TimeInMillis;
                        calendar.Add(CalendarField.Minute, 1);
                        answer = stringList;
                        end = calendar.TimeInMillis;
                        Event nEvent = new Event(answer, start, end);
                        nEvent.EventColor = Android.Graphics.Color.Red;
                        events.Add(nEvent);
                    }

                }
              
            }
            


            events.Add(newEvent);
            events.Add(newEvent2);

            calendarView.EventAdapter.Events = events;
            calendarView.EventsDisplayMode = EventsDisplayMode.Popup;

            // Create your application here
        }
    }
}