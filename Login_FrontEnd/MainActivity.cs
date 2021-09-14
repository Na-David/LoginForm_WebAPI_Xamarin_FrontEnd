using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Login_FrontEnd
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText Username_Obj;
        EditText Password_Obj;
        Button btn_Login;
        Button btn_SignUp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Username_Obj = FindViewById<EditText>(Resource.Id.loginUsername);
            Password_Obj = FindViewById<EditText>(Resource.Id.loginPassword);
            btn_Login = FindViewById<Button>(Resource.Id.loginButton);
            btn_SignUp = FindViewById<Button>(Resource.Id.loginSignUp);

            btn_Login.Click += Login_Function;
            btn_SignUp.Click += Signin_Function;


        }

        public void Signin_Function(object sender, EventArgs e)
        {
            StartActivity(typeof(Register));
        }

        public void Login_Function(object sender, EventArgs e)
        {
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

}