using Android.App;
using Android.OS;

namespace SchoolTool {
    [Activity(Label = "SchoolTool", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            WebUnitsHelper.GetTeachers(8);
        }
    }
}

