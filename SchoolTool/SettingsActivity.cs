using System;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V7.App;
using Android.App;
using Android.OS;
using Android.Widget;

namespace SchoolTool {
    [Activity(Theme = "@style/SchoolToolDefault", Label = "SettingsTEMP")]
    public class SettingsActivity : AppCompatActivity {
        private DataManager _dataman;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Settings);

            //fav class selector
            Spinner classSpinner = FindViewById<Spinner>(Resource.Id.favouriteTimetable);
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);

            classSpinner.Adapter = adapter;

            if (StaticWebUntis.Classes != null)
                adapter.AddAll(new List<string>(StaticWebUntis.Classes.Select(u => u.name)));
            else
                Toast.MakeText(this, "Error: Could not load classes!", ToastLength.Long).Show();


            //timetable on startup selector
            Spinner optionSpinner = FindViewById<Spinner>(Resource.Id.startingTimetable);
            ArrayAdapter<string> optionAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);

            optionSpinner.Adapter = optionAdapter;

            optionAdapter.Add("Startstundenplan");
            optionAdapter.Add("Lieblingsstundenplan");
            optionAdapter.Add("Zuletzt angesehener");

            //logout button - calls Logout on Click
            Button logout = FindViewById<Button>(Resource.Id.logoutButton);
            logout.Click += Logout_Click;

            //logout button - calls Logout on Click
            TextView alarm = FindViewById<TextView>(Resource.Id.alarmTextView);
            alarm.Click += delegate {
                StartActivity(typeof(AlarmActivity));
            };

            //The switch to turn notifications on or off
            Switch notifier = FindViewById<Switch>(Resource.Id.changeInTimetableSwitch);
            notifier.CheckedChange += Notifier_CheckedChange;

            _dataman = new DataManager(this);
        }



        private void Logout_Click(object sender, EventArgs e) {
            _dataman.DeleteLogin();
            _dataman.DeleteClasses();
            StartActivity(typeof(MainActivity));
        }

        private void Notifier_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) {
            _dataman.NotifyChanges = e.IsChecked;
        }
    }
}