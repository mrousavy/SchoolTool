using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using mrousavy.APIs.WebUntisSharp.WebUnitsJsonSchemes.Classes;
using System;
using System.Collections.Generic;

namespace SchoolTool {
    [Activity(Theme = "@style/SchoolToolDefault", Label = "SettingsActivity")]
    public class SettingsActivity : AppCompatActivity {
        private DataManager _dataman;
        private List<Class> _classes;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Settings);

            //The switch to turn notifications on or off
            Switch notifier = FindViewById<Switch>(Resource.Id.changeInTimetableSwitch);
            notifier.CheckedChange += Notifier_CheckedChange;

            //alarm TextView
            TextView alarm = FindViewById<TextView>(Resource.Id.alarmTextView);
            alarm.Click += delegate {
                StartActivity(typeof(WeckerActivity));
            };

            //favourite timetable layout
            Spinner favouriteTimetableLayout = FindViewById<Spinner>(Resource.Id.favouriteTimetable); //changed, because it's now a spinner
            favouriteTimetableLayout.Click += FavouriteTimetableLayout_Click;

            //starting timetable layout
            Spinner startingTimetableLayout = FindViewById<Spinner>(Resource.Id.startingTimetable); //changed, because it's now a spinner
            startingTimetableLayout.Click += StartingTimetableLayout_Click;


            //logout button - calls Logout on Click
            Button logout = FindViewById<Button>(Resource.Id.logoutButton);
            logout.Click += Logout_Click;

            _dataman = new DataManager(this);
        }

        private void Logout_Click(object sender, EventArgs e) {
            _dataman.DeleteLogin();
            _dataman.DeleteClasses();
            StartActivity(typeof(MainActivity));
        }

        private void StartingTimetableLayout_Click(object sender, System.EventArgs e) {
            //TODO: open picker layout

            //TODO: set TextView text
            //TextView favouriteTimetableOutput = FindViewById<TextView>(Resource.Id.favouriteTimetableOutput);
        }

        private void FavouriteTimetableLayout_Click(object sender, System.EventArgs e) {
            //TODO: open picker layout

            //TODO: set TextView text
            //FindViewById<TextView>(Resource.Id.startingTimetableOutput);
        }

        private void Notifier_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            _dataman.NotifyChanges = e.IsChecked;
        }
    }
}