using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CongNghePhanMem.ViewModel;
namespace CongNghePhanMem.Model
{
    public class FoodTypeModel:BaseViewModel
    {
        public int id { get; set; }
        private string _name;
        public string name { get=>_name; set { _name = value; OnPropertyChanged(); } }


        public FoodTypeModel(int v1, string v2)
        {
            this.id = v1;
            this.name = v2;
        }
        public override string ToString()
        {
            return " ";
        }

    }
}
