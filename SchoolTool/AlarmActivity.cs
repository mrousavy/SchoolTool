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

namespace SchoolTool {
    [Activity(Theme = "@style/SchoolToolDefault", Label = "Alarm")]
    public class AlarmActivity : AppCompatActivity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Alarm);

            TimePicker alarm = FindViewById<TimePicker>(Resource.Id.alarmPicker);

            CheckBox monday = FindViewById<CheckBox>(Resource.Id.monday);
            CheckBox tuesday = FindViewById<CheckBox>(Resource.Id.tuesday);
            CheckBox wednesday = FindViewById<CheckBox>(Resource.Id.wednesday);
            CheckBox thursday = FindViewById<CheckBox>(Resource.Id.thursday);
            CheckBox friday = FindViewById<CheckBox>(Resource.Id.friday);

            SeekBar volume = FindViewById<SeekBar>(Resource.Id.volumeBar);

            Switch onOff = FindViewById<Switch>(Resource.Id.onOffToggle);

            //button call save-Method onClick
            Button save = FindViewById<Button>(Resource.Id.saveButton);

            //TODO: you can change the switch to turn the alarm on or off and its text also changes to the current state
            //TODO: if you press the save button it should check how many hours before it should wake up + on which days + on which volume + make toast that its saved
        }
    }
}