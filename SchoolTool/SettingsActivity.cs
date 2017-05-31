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
            RelativeLayout favouriteTimetableLayout = FindViewById<RelativeLayout>(Resource.Id.favouriteTimetableLayout);
            favouriteTimetableLayout.Click += FavouriteTimetableLayout_Click;

            //starting timetable layout
            RelativeLayout startingTimetableLayout = FindViewById<RelativeLayout>(Resource.Id.startingTimetableLayout);
            startingTimetableLayout.Click += StartingTimetableLayout_Click;


            //logout button - calls Logout on Click
            Button logout = FindViewById<Button>(Resource.Id.logoutButton);

            //TODO: *NEW* when clicking on logout button it should logout, and open the login screen
            
            _dataman = new DataManager(this);

            LoadClasses();
        }

        private async void LoadClasses() {
            try {
                int schoolyear = (await StaticWebUntis.Untis.GetSchoolyear()).id;
                _classes = await StaticWebUntis.Untis.GetClasses(schoolyear.ToString());
            } catch (Exception e) {
                Toast.MakeText(this, "Error loading classes: " + e, ToastLength.Long).Show();
            }
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