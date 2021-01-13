using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongNghePhanMem.ViewModel;

namespace CongNghePhanMem.Model
{
    public class UserModel : BaseViewModel
    {
        private string _name;
        public string name { get => _name; set { _name = value; OnPropertyChanged(); } }
        private string _password;
        public string status { get => _password; set { _password = value; OnPropertyChanged(); } }

        public UserModel(int v1, string v2, string v3)
        {
            this.name = v2;
            this.status = v3;
        }
    }
}
