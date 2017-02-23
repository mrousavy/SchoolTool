using Android.App;
using Android.OS;
using Android.Support.V7.App;
using WebUntisSharp;

namespace SchoolTool {
    [Activity(Label = "SchoolTool", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity {
        private WebUntis _untis;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }


        //TODO: Login Method &  [_untis = new WebUntis();]  Login
    }
}