﻿using System;
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

namespace SchoolTool {
    [Activity(Theme = "@style/Theme.AppCompat.Light", Label = "SchoolTool", MainLauncher = false,
        Icon = "@drawable/logo")]
    public class TimetableActivity : AppCompatActivity, DatePickerDialog.IOnDateSetListener {

        // TODO: Set the timetable dynamically with a date from the date dialog picker and the class from the spinner
        // change the style

        Spinner _classspinner;
        ArrayAdapter<string> _adapter;
        private const int DateDialog = 1;
        private int _year, _month, _day;
        Button _calendarbutton;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Timetable);

            _classspinner = FindViewById<Spinner>(Resource.Id.chooseclass);

            _adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);

            _classspinner.Adapter = _adapter;

            //TODO: Insert Classes with the WebUntis API

            _adapter.Add("Get Timetable");
            _adapter.Add("3DHIT");
            _adapter.Add("3CHIT");
            _adapter.Add("3AHIT");
            _adapter.Add("3BHIT");

            _classspinner.ItemSelected += Spinner_ItemSelected;

            _calendarbutton = FindViewById<Button>(Resource.Id.fordate);

            _calendarbutton.Click += delegate {
                ShowDialog(DateDialog);
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
            Toast.MakeText(this, "You have selected: " + _day + "." + (_month + 1) + "." + year, ToastLength.Long).Show();
            _calendarbutton.Text = _day + "." + (_month + 1) + "." + year;
        }
    }
}