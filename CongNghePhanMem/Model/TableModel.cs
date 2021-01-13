using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongNghePhanMem.ViewModel;

namespace CongNghePhanMem.Model
{
    public class TableModel : BaseViewModel
    {
        public int id { get; set; }
        private string _name;
        public string name { get => _name; set { _name = value; OnPropertyChanged(); } }
       private string _status;
        public string status { get => _status; set { _status = value; OnPropertyChanged(); } }

        public TableModel(int v1, string v2, string v3)
        {
            this.id = v1;
            this.name = v2;
            this.status = v3;
            
        }
        public override string ToString()
        {
            return " ";
        }
    }
}
