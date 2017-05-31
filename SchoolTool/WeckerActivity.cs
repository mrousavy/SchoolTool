
using Android.App;
using Android.OS;

namespace SchoolTool {
    [Activity(Label = "WeckerActivity")]
    public class WeckerActivity : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Wecker);
        }
    }
}