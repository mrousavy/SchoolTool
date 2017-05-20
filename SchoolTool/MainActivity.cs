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
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Changed for testing purposes
            SetContentView(Resource.Layout.Login);
        }
    }
}