using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SchoolTool {
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            // Has to be set before Activity is created
            SetTheme(Resource.Style.SchoolToolDefault);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Login);
            // Create your application here
        }
    }
}