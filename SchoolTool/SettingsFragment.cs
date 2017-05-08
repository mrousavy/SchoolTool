using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SchoolTool
{
    public class SettingsFragment : Fragment
    {
        private List<Item> settingsItems;
        private ListView settingsListView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Settings, container, false);

            settingsListView = view.FindViewById<ListView>(Resource.Id.settingsView);
            settingsItems = new List<Item>();

            settingsItems.Add(new Item { settingName = "ggg", img = Resource.Drawable.Icon });
            settingsItems.Add(new Item { settingName = "ggg2", img = Resource.Drawable.Icon });
            settingsItems.Add(new Item { settingName = "ggg3", img = Resource.Drawable.Icon });
            settingsItems.Add(new Item { settingName = "ggg4", img = Resource.Drawable.Icon });

            new ListViewAdapter(view.Context, settingsItems);

            return view;
        }
    }
}