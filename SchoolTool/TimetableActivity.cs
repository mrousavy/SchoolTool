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
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using mrousavy.APIs.WebUntisSharp.WebUnitsJsonSchemes.Classes;

namespace SchoolTool {
    [Activity(Theme = "@style/Theme.AppCompat.Light", Label = "SchoolTool", MainLauncher = false,
        Icon = "@drawable/logo")]
    public class TimetableActivity : AppCompatActivity, DatePickerDialog.IOnDateSetListener {

        // TODO: Set the timetable dynamically with a date from the date dialog picker and the class from the spinner
        // change the style

        Spinner _classspinner;
        ArrayAdapter<string> _adapter;
        private const int DateDialog = 1;
        private int _year = System.DateTime.Now.Year, _month = System.DateTime.Now.Month, _day = System.DateTime.Now.Day;
        Button _calendarbutton;
        Button _settings;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Timetable);

            _classspinner = FindViewById<Spinner>(Resource.Id.chooseclass);

            _adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);

            _classspinner.Adapter = _adapter;

            //TODO: Insert Classes with the WebUntis API

            if(StaticWebUntis.Classes != null)
                //foreach(Class c in StaticWebUntis.Classes)
                //{
                //    _adapter.Add(c.name);
                //}

            _adapter.AddAll(new List<string>( StaticWebUntis.Classes.Select(c => c.name)));

            _classspinner.ItemSelected += Spinner_ItemSelected;

            _calendarbutton = FindViewById<Button>(Resource.Id.fordate);

            _calendarbutton.Text = _day + "." + (_month + 1) + "." + _year;

            _calendarbutton.Click += delegate {
                ShowDialog(DateDialog);
            };

            _settings = FindViewById<Button>(Resource.Id.settingsbutton);

            _settings.Click += delegate
            {
                StartActivity(typeof(SettingsActivity));
            };
        }

        [Obsolete("deprecated")]
        protected override Dialog OnCreateDialog(int id) {
            switch (id) {
                case DateDialog:
                    return new DatePickerDialog(this, this, _year, _month, _day);
            }
            return null;
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e) {
            string chosenclass = Convert.ToString(_adapter.GetItem(e.Position));
            //TODO
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
            this._year = year;
            this._month = monthOfYear;
            this._day = dayOfMonth;
            Toast.MakeText(this, "You have selected: " + _day + "." + (_month + 1) + "." + _year, ToastLength.Long).Show();
            _calendarbutton.Text = _day + "." + (_month + 1) + "." + _year;
        }
    }
}