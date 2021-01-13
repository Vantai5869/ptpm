using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CongNghePhanMem.ViewModel;
namespace CongNghePhanMem.Model
{
    public class FoodModel:BaseViewModel
    {
        public int id { get; set; }
        private string _name;
        public string name { get => _name; set { _name = value; OnPropertyChanged(); } }
        
        private string _price;
        public string price { get => _price; set { _price = value; OnPropertyChanged(); } }

        private string _image = string.Empty;
        public object image
        {
            get
            {
                if (string.IsNullOrEmpty(_image))
                    return DependencyProperty.UnsetValue;

                return _image;
            }
            set { _image = (string)value; OnPropertyChanged(); }
        }
        //public string image { get; set; }
        public int food_type_id { get; set; }

        public FoodModel(int v1, string v2, string v3, string v4, int v5)
        {
            this.id = v1;
            this.name = v2;
            this.price = v3;
            this.image = v4;
            this.food_type_id = v5;
        }
        public override string ToString()
        {
            return "ho ten: " + name + " gia:  " + price;
        }

    }
}
