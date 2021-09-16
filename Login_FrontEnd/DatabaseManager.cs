using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Login_FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Login_FrontEnd
{
    public class DatabaseManager
    {
        public static List<Login> GetLoginData()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync("http://10.0.2.2:53853/api/Logins");
            var Login_Obj = JsonConvert.DeserializeObject<List<Login>>(response.Result);
            return Login_Obj.ToList();
        }
        public static void Register_Login(string Register_Username, string Register_Password, string Register_Name, string Register_Email)
        {
            try
            {
                // Define the object of login class and pass the values of the parameters to objet variables.

                Login login_obj = new Login
                {
                    Username = Register_Username,
                    Password = Register_Password,
                    Name = Register_Name,
                    Email = Register_Email
                };
                
                var httpClient = new HttpClient();
                var Json = JsonConvert.SerializeObject(login_obj);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                httpClient.PostAsync(string.Format("http://10.0.2.2:53853/api/Logins"), httpContent);
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Insert Registration Data Error" + e.Message);
            }
        }
    }
}