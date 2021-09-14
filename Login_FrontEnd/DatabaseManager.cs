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
using System.Text;

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
        /*
        public static async void Register_Login1(string Register_Username, string Register_Password, string Register_Name, string Register_Email)
        {
            try
            {
                Login login_obj = new Login
                {
                    Username = Register_Username,
                    Password = Register_Password,
                    Name = Register_Name,
                    Email = Register_Email
                };
                string url = "http://10.0.2.2:53853/api/Logins";
                HttpClient client = new HttpClient();
                string JsonData = JsonConvert.SerializeObject(login_obj);
                StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();
                HttpResponseHeaders responseData = JsonConvert.DeserializeObject<HttpResponseHeaders>(result); 
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Insert Registration Data Error" + e.Message);
            }
        }
        */
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
        /*
                public static void FetchLogin(string Username_para)
                {
                    try
                    {
                        Login Login_Obj = new Login
                        {
                            Username = Username_para
                        };
                        var httpClient = new HttpClient();
                        var Json = JsonConvert.SerializeObject(Login_Obj);
                        HttpContent httpContent = new StringContent(Json);
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                        var response = httpClient.GetAsync(string.Format("http://10.0.2.2:53853/api/Logins/{0}", Login_Obj));
                        Console.WriteLine(response);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Update student Data Error " + e.Message);
                    }

                }
        */


        /*
Login login_obj_2 = new Login();
login_obj_2.Username = Register_Username;
login_obj_2.Password = Register_Password;
login_obj_2.Name = Register_Name;
login_obj_2.Email = Register_Email;
*/

    }
}