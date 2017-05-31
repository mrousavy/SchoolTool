using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using mrousavy.APIs.WebUntisSharp;
using System;

namespace SchoolTool {
    [Activity(Theme = "@style/Loading", Label = "Login")]
    public class LoginActivity : AppCompatActivity {
        private EditText _school, _username, _password;
        private ImageButton _login;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);

            //Login button calls Login Method onClick-Event
            _login = FindViewById<ImageButton>(Resource.Id.loginButton);
            _login.Click += Login_Click;

            //Input fields for school, username and password
            _school = FindViewById<EditText>(Resource.Id.schoolInput);
            _username = FindViewById<EditText>(Resource.Id.unameInput);
            _password = FindViewById<EditText>(Resource.Id.pwordInput);

            //TODO: When button is clicked it calls Login(View) where it has to check if fields are not empty and correct then it should go to the timetable
        }

        private async void Login_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrWhiteSpace(_username.Text))
                    throw new Exception("Username cannot be empty!");
                if (string.IsNullOrWhiteSpace(_password.Text))
                    throw new Exception("Password cannot be empty!");
                if (string.IsNullOrWhiteSpace(_school.Text))
                    throw new Exception("School Url cannot be empty!");

                StaticWebUntis.Untis = await WebUntis.New(_username.Text, _password.Text, _school.Text);
                new DataManager(this).SaveData(_username.Text, _password.Text, _school.Text);
                StartActivity(typeof(MainActivity));
            } catch (Exception ex) {
                // invalid username/password/school
                Toast.MakeText(this, "Error! " + ex.Message, ToastLength.Long);
            }
        }



    }
}