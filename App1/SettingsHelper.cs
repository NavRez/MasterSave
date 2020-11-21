using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Java.Util;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    class SettingsHelper
    {
        public static int Month { get; set; }
        public static int Day { get; set; }
        public static int Year { get; set; }

        public static Calendar internalCal = Java.Util.Calendar.Instance;


        public static void ConvertVals(string d, string m, string y)
        {
            Month = MonthToInt(m);
            Day = GetDay(d);
            Year = GetYear(y);

            if (Month == 0 || Year == 0)
            {
                Day = 0;
                Month = internalCal.Time.Month + 1;
                Year = internalCal.Time.Year + 1900;
            }
            
        }

        public static int MonthToInt(string m)
        {
            switch (m)
            {
                case "January":
                    return 1;
                case "February":
                    return 2;
                case "March":
                    return 3;
                case "April":
                    return 4;
                case "May":
                    return 5;
                case "June":
                    return 6;
                case "July":
                    return 7;
                case "August":
                    return 8;
                case "September":
                    return 9;
                case "October":
                    return 10;
                case "November":
                    return 11;
                case "December":
                    return 12;
                default:
                    return 0;
            }
        }

        public static int GetDay(string d)
        {
            int dayVal = 0;
            try
            {
                dayVal = Int32.Parse(d);
            }
            catch(Exception e)
            {
                return 0;
            }
            

            if (dayVal > 31) {

                return 0;
            }
            else if (dayVal <= 30 && (Month == 4 || Month == 6 || Month == 9 || Month == 11))
            {
                return dayVal;
            }
            else if (dayVal <= 31 && (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12))
            {
                return dayVal;
            }
            else if(dayVal <= 28 && Month == 2)
            {
                return dayVal;
            }
            else
            {
                return 0;
            }
        }

        public static int GetYear(string y)
        {
            int yearVal = 0;

            try
            {
                yearVal = Int32.Parse(y);
            }
            catch (Exception e)
            {
                return 0;
            }

            if (yearVal <= 2019)
            {
                return 0;
            }
            else
            {
                return yearVal;
            }
        }
    }
}