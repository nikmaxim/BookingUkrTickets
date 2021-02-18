using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

namespace BookingUkrTickets
{
    class Connection
    {
        internal static CookieContainer cc = new CookieContainer();
        internal static CookieCollection cookiesCollection;
        internal static Dictionary<int, string> idTrains = new Dictionary<int, string>
        {
            // Some keys and value
        };
        internal static (string, string) userAuthData = ("", "");

        internal static JsonTrainSearchResponse FindTrains(string departure, string destination, string departureDatedepa)
        {
            string result = "";
            string postData = "from=" + departure + "&to=" + destination + "&date=" + departureDatedepa + "&time=00%3A00";
            byte[] requestData = Encoding.ASCII.GetBytes(postData);
            var req = (HttpWebRequest)WebRequest.Create("https://booking.uz.gov.ua/ru/train_search/");
            req.Proxy = null;
            req.CookieContainer = cc;
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            req.AllowAutoRedirect = true;
            req.ContentLength = requestData.Length;
            using (Stream s = req.GetRequestStream())
                s.Write(requestData, 0, requestData.Length);
            using (var response = (HttpWebResponse)req.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }

            var jsonObject = JsonConvert.DeserializeObject<JsonTrainSearchResponse>(result);
            
            return jsonObject;                
        }

        internal static void Authentication()
        {
            if (string.IsNullOrEmpty(userAuthData.Item1) || string.IsNullOrEmpty(userAuthData.Item2))
            {
                MessageBox.Show("Данные для аутентификации отсутствуют!");
                return;
            }
            byte[] requestData = Encoding.ASCII.GetBytes($"email={userAuthData.Item1}&pwd={userAuthData.Item2}");
            var req = (HttpWebRequest)WebRequest.Create("https://booking.uz.gov.ua/ru/authorization/login/");
            req.Proxy = null;
            req.CookieContainer = cc;
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            req.ContentLength = requestData.Length;
            using (Stream s = req.GetRequestStream())
                s.Write(requestData, 0, requestData.Length);
            using (var response = (HttpWebResponse)req.GetResponse())
                cookiesCollection = response.Cookies;
            MessageBox.Show("Успешно!");
        }

        internal static void Deauthentication()
        {
            var req = (HttpWebRequest)WebRequest.Create("https://booking.uz.gov.ua/ru/authorization/logout/");
            req.Proxy = null;
            req.CookieContainer = cc;
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            using (Stream s = req.GetRequestStream())
            using (var response = (HttpWebResponse)req.GetResponse()) { }

            MessageBox.Show("Успешно!");
        }
    }
}
