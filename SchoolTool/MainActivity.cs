using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using mrousavy.APIs.WebUntisSharp;
using System;

namespace SchoolTool {
    [Activity(Label = "SchoolTool", MainLauncher = true, Icon = "@drawable/logo")]
    public class MainActivity : AppCompatActivity {
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

            DataManager dataman = new DataManager(this);
            string schoolUrl = dataman.SchoolUrl;
            string username = dataman.Username;
            string password = dataman.Password;
            _school.Text = schoolUrl;
            _username.Text = username;
            _password.Text = password;

            if (string.IsNullOrWhiteSpace(schoolUrl) && string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
                Login();
        }

        private void Login_Click(object sender, EventArgs e) {
            Login();
        }

        private async void Login() {
            try {
                if (string.IsNullOrWhiteSpace(_school.Text))
                    throw new Exception("School Url cannot be empty!");
                if (string.IsNullOrWhiteSpace(_username.Text))
                    throw new Exception("Username cannot be empty!");
                if (string.IsNullOrWhiteSpace(_password.Text))
                    throw new Exception("Password cannot be empty!");

                //TODO: show loading bar
                Toast.MakeText(this, "Logging in...", ToastLength.Long).Show();
                //FindViewById<ImageButton>(Resource.Id.loadingLoginBar).Visibility = Android.Views.ViewStates.Visible;

                if (_school.Text.ToLower() == "tgm") {
                    _school.Text = "https://stpl.tgm.ac.at/WebUntis/jsonrpc.do?school=tgm";
                }

                StaticWebUntis.Untis = await WebUntis.New(_username.Text, _password.Text, _school.Text);
                DataManager dataman = new DataManager(this);

                //cache login
                dataman.SaveData(_username.Text, _password.Text, _school.Text);

                //load classes
                dataman.LoadClasses();

                if (StaticWebUntis.Classes == null) {
                    try {
                        //classes not yet set, cache them
                        //int schoolyear = (await StaticWebUntis.Untis.GetSchoolyear()).id;
                        //TODO: remove "9" placeholder
                        StaticWebUntis.Classes = await StaticWebUntis.Untis.GetClasses("9");
                        dataman.CacheClasses();
                    }
                    catch { }
                }

                StartActivity(typeof(TimetableActivity));
            } catch (Exception ex) {
                // invalid username/password/school
                Toast.MakeText(this, "Error! " + ex.Message, ToastLength.Long).Show();
            }

            //TODO: hide loading bar
            //FindViewById<ImageButton>(Resource.Id.loadingLoginBar).Visibility = Android.Views.ViewStates.Gone;
        }
    }
}
