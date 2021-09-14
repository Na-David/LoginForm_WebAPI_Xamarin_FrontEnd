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
using System.Threading.Tasks;

namespace Login_FrontEnd
{
    [Activity(Label = "Register")]
    public class Register : Activity
    {
        EditText R_Username;
        EditText R_Password;
        EditText R_Name;
        EditText R_Email;
        Button btn_Register;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Register);

            R_Username = FindViewById<EditText>(Resource.Id.R_Username);
            R_Password = FindViewById<EditText>(Resource.Id.R_Password);
            R_Name = FindViewById<EditText>(Resource.Id.R_Name);
            R_Email = FindViewById<EditText>(Resource.Id.R_Email);
            btn_Register = FindViewById<Button>(Resource.Id.btn_Register);

            btn_Register.Click += Register_Function;
        }

        public void Register_Function(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(R_Username.Text)) || 
                (string.IsNullOrWhiteSpace(R_Password.Text)) ||
                (string.IsNullOrWhiteSpace(R_Name.Text)) ||
                (string.IsNullOrWhiteSpace(R_Email.Text)))
            {
                Toast.MakeText(this, "Please fill in the blanks", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "You are now registered", ToastLength.Long).Show();
                DatabaseManager.Register_Login(R_Username.Text, R_Password.Text, R_Name.Text, R_Email.Text);
                this.Finish();
                StartActivity(typeof(MainActivity));
            }

        }
    }
}