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
    [Activity(Theme="@style/Loading", Label = "Login")]
    public class LoginActivity : AppCompatActivity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);

            //Login button calls Login Method onClick-Event
            ImageButton login = FindViewById<ImageButton>(Resource.Id.loginButton);

            //Input fields for school, username and password
            EditText school = FindViewById<EditText>(Resource.Id.schoolInput);
            EditText uname = FindViewById<EditText>(Resource.Id.unameInput);
            EditText pword = FindViewById<EditText>(Resource.Id.pwordInput);

            //TODO: When button is clicked it calls Login(View) where it has to check if fields are not empty and correct then it should go to the timetable
        }
    }
}