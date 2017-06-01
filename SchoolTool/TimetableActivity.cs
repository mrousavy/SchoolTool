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

namespace SchoolTool
{
    [Activity(Theme="@style/Theme.AppCompat.Light", Label = "SchoolTool", MainLauncher = false, Icon = "@drawable/logo")]
    public class TimetableActivity : AppCompatActivity, DatePickerDialog.IOnDateSetListener
    {

        // TODO: Set the timetable dynamically with a date from the date dialog picker and the class from the spinner
        // change the style

        Spinner classspinner;
        ArrayAdapter<String> adapter;
        private const int DATE_DIALOG = 1;
        private int year, month, day;
        Button calendarbutton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Timetable);

            classspinner = FindViewById<Spinner>(Resource.Id.chooseclass);

            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);

            classspinner.Adapter = adapter;

            //TODO: Insert Classes with the WebUntis API

            adapter.Add("Get Timetable");
            adapter.Add("3DHIT");
            adapter.Add("3CHIT");
            adapter.Add("3AHIT");
            adapter.Add("3BHIT");

            classspinner.ItemSelected += new System.EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

            calendarbutton = FindViewById<Button>(Resource.Id.fordate);

            calendarbutton.Click += delegate
            {
                ShowDialog(DATE_DIALOG);
            };
        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case DATE_DIALOG:
                    {
                        return new DatePickerDialog(this, this, year, month, day);
                    }
                    break;
                default:
                    break;
            }
            return null;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String chosenclass = Convert.ToString(adapter.GetItem(e.Position));
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            this.year = year;
            this.month = monthOfYear;
            this.day = dayOfMonth;
            Toast.MakeText(this, "You have selected: " + day + "." + (month + 1) + "." + year, ToastLength.Long).Show();
            calendarbutton.Text = day + "." + (month + 1) + "." + year;
        }
    }
}