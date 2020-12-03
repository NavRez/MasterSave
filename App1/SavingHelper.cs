using System;
using Java.Util;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    class SavingHelper
    {
        public static double Cost { get; set; }
        //public static int Counter { get; set; }
        public static Calendar internalCal = Java.Util.Calendar.Instance;

        public static void ConvertBills(string c)
        {
            //Counter = GetCounter(count);
            Cost = GetCurrBills(c);
        }

        //public static int GetCounter(int c)
        //{
        //   return c;
        //}

        public static double GetCurrBills(string c)
        {
            double costVal;
            try
            {
                costVal = double.Parse(c);
            }
            catch (Exception e)
            {
                return 0;
            }

            double result = Math.Ceiling(costVal);
            result = Math.Round(result, 2);
    

            if (result == costVal)
            {
                result = (double)(costVal * 1.05);
            }

            return (double)result; 
        }
    }
}