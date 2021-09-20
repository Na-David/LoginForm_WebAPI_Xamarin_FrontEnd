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
    [Activity(Label = "Dashboard")]
    public class Dashboard : Activity
    {
        ListView CustomerList;
        List<Login_FrontEnd.Models.Login> myList = new List<Login_FrontEnd.Models.Login>(); 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Dashboard_Layout);

            CustomerList = FindViewById<ListView>(Resource.Id.listView1);
            myList = DatabaseManager.GetLoginData();
        }
    }
}