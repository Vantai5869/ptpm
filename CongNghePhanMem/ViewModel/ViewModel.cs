using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CongNghePhanMem.Model;
using xNet;

namespace CongNghePhanMem.ViewModel
{
    public class ViewModel : BaseViewModel
    {
        
        public static string apiFoodTypeUrl, apiEditFoodTypeUrl, apiDeleteFoodTypeUrl, foodTypeString,
            apiFoodUrl, apiEditFoodUrl, apiDeleteFoodUrl, apiSearchFoodUrl, apiTableUrl, apiEditTableUrl, apiDeleteTableUrl,
            apiBillUrl, apiDeleteBillTypeUrl, apiDeleteBillUrl, apigetByFoodTypeUrl, apiTableBillUrl, apiStatusTableTypeUrl,apiLogin, apiOverview, LoginToken = null;
        public ICommand BtnLoginCommand { get; set; }
        public ICommand BtnLoginExitCommand { get; set; }

        public string TxtUsername
        {
            get; set; 
        }

        public string TxtPassword
        {
            get => txtPassword;
            set
            {
                txtPassword = handleStrPass(value.Length );
                if (value.Length > 0)
                {
                    RealtxtPassword += value.Substring(value.Length-1);
                    if (RealtxtPassword.Length > value.Length)
                    {
                        RealtxtPassword = RealtxtPassword.Remove(RealtxtPassword.Length - 2,2);
                    }
                }
                else
                {
                    RealtxtPassword = "";
                }
               
                   
                OnPropertyChanged();
            }
        }
        public string handleStrPass(int length)
        {
            string strPass = "";
            for(int i = 0; i < length; i++)
            {
                strPass += "*";
            }
            return strPass;
        }
        private string txtPassword;
        private string RealtxtPassword;
        public ViewModel()
        {
            UrlDifine(1);
           
            BtnLoginCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TxtUsername))
                    return false;
                if (string.IsNullOrEmpty(RealtxtPassword))
                    return false;
                return true;

            }, (p) =>
            {
            MultipartContent data = new MultipartContent() {
                    { new StringContent(TxtUsername), "name"},
                    { new StringContent(RealtxtPassword), "password"},
                    };
               
               LoginToken = ApiHandle.Login(null, apiLogin, data);
               if(LoginToken == "0")
                {
                    MessageBox.Show("Sai thông tin đăng nhập!");
                    return;
                }
                var MainWD = new MainWindow();
                foreach (Window item in Application.Current.Windows)
                {
                    if (item.DataContext == this) item.Close();
                }
                MainWD.Show();
                return;
            });
            BtnLoginExitCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                foreach (Window item in Application.Current.Windows)
                {
                    if (item.DataContext == this) item.Close();
                }
            });
        
        }

        // url
        public static void UrlDifine(int num)// 1 hosting online, else local
        {
            if (num == 1)
            {
                apiFoodUrl = "https://rescom.000webhostapp.com/api/food";
                apiEditFoodUrl = "https://rescom.000webhostapp.com/api/food/update/";
                apiDeleteFoodUrl = "https://rescom.000webhostapp.com/api/food/delete/";
                apiSearchFoodUrl = "https://rescom.000webhostapp.com/api/food/search/";
                apigetByFoodTypeUrl = "https://rescom.000webhostapp.com/api/food/get/foodtype/";

                //foodtype
                apiFoodTypeUrl = "https://rescom.000webhostapp.com/api/foodtype";
                apiEditFoodTypeUrl = "https://rescom.000webhostapp.com/api/foodtype/update/";
                apiDeleteFoodTypeUrl = "https://rescom.000webhostapp.com/api/foodtype/delete/";

                //bill
                apiBillUrl = "https://rescom.000webhostapp.com/api/bill";
                apiTableBillUrl = "https://rescom.000webhostapp.com/api/bill/get/";
                apiDeleteBillTypeUrl = "https://rescom.000webhostapp.com/api/bill/delete/";
                apiDeleteBillUrl = "https://rescom.000webhostapp.com/api/delete/bill/";
                apiStatusTableTypeUrl = "https://rescom.000webhostapp.com/api/table/status/";

                //table
                apiTableUrl = "https://rescom.000webhostapp.com/api/table";
                apiEditTableUrl = "https://rescom.000webhostapp.com/api/table/update/";
                apiDeleteTableUrl = "https://rescom.000webhostapp.com/api/table/delete/";

                //login
                apiLogin = "https://rescom.000webhostapp.com/api/login";

                //overview
                apiOverview = "https://rescom.000webhostapp.com/api/overview";
            }
            else
            {
                apiFoodUrl = "http://res.com/api/food";
                apiEditFoodUrl = "http://res.com/api/food/update/";
                apiDeleteFoodUrl = "http://res.com/api/food/delete/";
                apiSearchFoodUrl = "http://res.com/api/food/search/";
                apigetByFoodTypeUrl = "http://res.com/api/food/get/foodtype/";

                //foodtype
                apiFoodTypeUrl = "http://res.com/api/foodtype";
                apiEditFoodTypeUrl = "http://res.com/api/foodtype/update/";
                apiDeleteFoodTypeUrl = "http://res.com/api/foodtype/delete/";

                //bill
                apiBillUrl = "http://res.com/api/bill";
                apiTableBillUrl = "http://res.com/api/bill/get/";
                apiDeleteBillTypeUrl = "http://res.com/api/bill/delete";
                apiDeleteBillUrl = "http://res.com/api/delete/bill/";
                apiStatusTableTypeUrl = "http://res.com/api/table/status/";

                //table
                apiTableUrl = "http://res.com/api/table";
                apiEditTableUrl = "http://res.com/api/table/update/";
                apiDeleteTableUrl = "http://res.com/api/table/delete/";

                //login
                apiLogin = "http://res.com/api/login";

                //overview
                apiOverview = "http://res.com/api/overview";
            }
        }
    }
}
