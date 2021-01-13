using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using xNet;
using MultipartContent = xNet.MultipartContent;
namespace CongNghePhanMem.Model
{
    class ApiHandle
    {
        public static string loginToken= "";
        public static string GetData(string url, string cookie = null, string Token = null)
        {
            var html = "";
            loginToken = loginToken.Replace("\"", "");
            HttpRequest http = new HttpRequest();
            http.Cookies = new CookieDictionary();
            
            http.AddHeader("Token", loginToken);
            try
            {
                html = http.Get(url).ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show(url);
            }

            return html;
        }

        public static bool UploadData(HttpRequest http, string url, MultipartContent data = null, string contentType = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.AddHeader("Token", loginToken);
                http.Cookies = new CookieDictionary();
            }
            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }
            string html = http.Post(url, data).ToString();
            return true;
        }
       public static string Login(HttpRequest http, string url, MultipartContent data = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieDictionary();
            }
            loginToken = http.Post(url, data).ToString();
            return loginToken;
        }
        public static bool UpDate(HttpRequest http, string url, MultipartContent data = null, string contentType = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.AddHeader("Token", loginToken);
                http.Cookies = new CookieDictionary();
            }
            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }
            string html = http.Post(url, data).ToString();
            return true;
        }

        public static bool Delete(string url, string cookie = null)
        {
            var html = "";
            HttpRequest http = new HttpRequest();
            http.AddHeader("Token", loginToken);
            http.Cookies = new CookieDictionary();
            html = http.Get(url).ToString();
            return true;
        }
        public static bool OverviewStore(HttpRequest http, string url, MultipartContent data = null, string contentType = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
                {
                    http = new HttpRequest();
                    http.AddHeader("Token", loginToken);
                    http.Cookies = new CookieDictionary();
                }
                if (!string.IsNullOrEmpty(userArgent))
                {
                    http.UserAgent = userArgent;
                }
                string html = http.Post(url, data).ToString();
                return true;
        }

    }
}
