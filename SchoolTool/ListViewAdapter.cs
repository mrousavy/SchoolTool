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

namespace SchoolTool
{
    class ListViewAdapter : BaseAdapter<Item>
    {
        private List<Item> items;
        private Context context;

        public ListViewAdapter(Context context, List<Item> items)
        {
            this.items = items;
            this.context = context;
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Item this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
                row = LayoutInflater.From(context).Inflate(Resource.Layout.Settings_ListView_Item, null, false);

            TextView settingText = row.FindViewById<TextView>(Resource.Id.settingsText);
            settingText.Text = items[position].settingName;

            ImageView settingIMG = row.FindViewById<ImageView>(Resource.Id.settingsIMG);
            settingIMG.SetImageResource(items[position].img);

            return row;
        }
    }
}