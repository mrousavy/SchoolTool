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
    [Activity(Theme = "@style/SchoolToolDefault", MainLauncher = true, Label = "SettingsTEMP")]
    public class SettingsTEMP : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Settings);

            Spinner classSpinner = FindViewById<Spinner>(Resource.Id.favouriteTimetable);
            ArrayAdapter<String> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);

            classSpinner.Adapter = adapter;

            adapter.Add("Lieblingsklasse");
            adapter.Add("3DHIT");
            adapter.Add("3CHIT");
            adapter.Add("3AHIT");
            adapter.Add("3BHIT");



            Spinner optionSpinner = FindViewById<Spinner>(Resource.Id.startingTimetable);
            ArrayAdapter<String> optionAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem);

            optionSpinner.Adapter = optionAdapter;

            optionAdapter.Add("Startstundenplan");
            optionAdapter.Add("Lieblingsstundenplan");
            optionAdapter.Add("Zuletzt angesehener");
        }
    }
}