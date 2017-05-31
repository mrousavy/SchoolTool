using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V7.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SchoolTool
{
    [Activity(Theme = "@style/SchoolToolDefault", Label = "SettingsActivity")]
    public class SettingsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Settings);

            //The switch to turn notifications on or off
            Switch notifier = FindViewById<Switch>(Resource.Id.changeInTimetableSwitch);
            
            //alarm TextView
            TextView alarm = FindViewById<TextView>(Resource.Id.alarmTextView);

            //favourite timetable layout
            RelativeLayout favouriteTimetableLayout = FindViewById<RelativeLayout>(Resource.Id.favouriteTimetableLayout);
            //output of the favourite timetable
            TextView favouriteTimetableOutput = FindViewById<TextView>(Resource.Id.favouriteTimetableOutput);

            //starting timetable layout
            RelativeLayout startingTimetableLayout = FindViewById<RelativeLayout>(Resource.Id.startingTimetableLayout);
            //output of starting timetable
            TextView startingTimetableOutput = FindViewById<TextView>(Resource.Id.startingTimetableOutput);


            //TODO: misc - populate string array with all classes from school

            //TODO: switch - if turned on enable notifications on timetable changes if off then otherwise
            //TODO: alarm - when clicked on the textview open alarm window
            //TODO: favourite timetable layout - when clicked on this layout it should open a popup with a searchbar and all classes to choose
            //TODO: favourite timetable output - when class is chosen it should be displayed in this textview
            //TODO: starting timetable layout  - when clicked on this layout it should open a popup with 2 radiobuttons, 1 for last viewed and 1 for favourite class
            //TODO: starting timetable output  - when option is chosen it should be displayed in this textview
        }
    }
}