using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using WebUntisSharp;

namespace SchoolTool
{
    [Activity(Label = "SchoolTool", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        private WebUntis _untis;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            //Get Button from View
            Button btn = FindViewById<Button>(Resource.Id.btnTest);
            //Set On Click Handler
            btn.Click += delegate
            {
                //_untis = new WebUntis(username, password, schoolUrl, client);
                Toast.MakeText(this, "Test", ToastLength.Short).Show();
            };
        }

        //TODO: Login Method &  [_untis = new WebUntis();]  Login
    }
}