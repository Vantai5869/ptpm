using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongNghePhanMem.ViewModel;

namespace CongNghePhanMem.Model
{
    public class OverviewModel : BaseViewModel
    {
        private int _totalpay;
        public int totalpay { get => _totalpay; set { _totalpay = value; OnPropertyChanged(); } }
        private string _date;
        public string date { get => _date; set { _date = value; OnPropertyChanged(); } }

        public OverviewModel(int v1, string v2)
        {
            this.totalpay = v1;
            this.date = v2;
            
        }
    }
}
