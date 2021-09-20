using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Login_FrontEnd
{
    class DataAdapter : BaseAdapter<Login_FrontEnd.Models.Login>
    {
        private readonly Activity context;
        private readonly List<Login_FrontEnd.Models.Login> items;

        public DataAdapter(Activity context, List<Login_FrontEnd.Models.Login> items)
        {
            this.context = context;
            this.items = items;
        }

        public override Login_FrontEnd.Models.Login this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.DisplayCustomerData, null);
            view.FindViewById<TextView>(Resource.Id.lbPassword).Text = item.Password;
            view.FindViewById<TextView>(Resource.Id.lbName).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.lbEmail).Text = item.Email;
            return view;
        }
    }
}