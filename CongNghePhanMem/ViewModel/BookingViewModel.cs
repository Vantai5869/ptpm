using CongNghePhanMem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CongNghePhanMem.ViewModel
{
    public class BookingViewModel : ViewModel
    {
        public ICommand OrderCommand { get; set; }
        public ICommand PaymentCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }

        private ObservableCollection<TableModel> _List;
        public ObservableCollection<TableModel> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private TableModel _SelectedItem;
        private string _name;
        public string name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public TableModel SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    name = SelectedItem.name;
                }
            }
        }
        public BookingViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                listTable();
            });

            OrderCommand = new RelayCommand<object>((p) => {
                if (SelectedItem == null)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                var selected_id = SelectedItem.id.ToString();
                Thread th = new Thread(() => ApiHandle.GetData(apiStatusTableTypeUrl + selected_id + "/1"));
                th.Start();
                SelectedItem.status = "OrangeRed";
                //foreach (Window item in Application.Current.Windows)
                //{
                //    if (item.DataContext == this) item.Close();
                //}
                var Oder = new FoodOderViewModel(selected_id);
                var foodOder = new FoodOderWindow();
              
                foodOder.Show();
            });

            PaymentCommand = new RelayCommand<object>((p) => {
                if (SelectedItem == null)
                    return false; 
                return true;
            }, (p) =>
            {
                var id_table = SelectedItem.id.ToString();
                var oderBill = new OderBill(apiTableBillUrl, id_table);
                oderBill.Show();
            });
        }
        void listTable()
        {
            List = new ObservableCollection<TableModel>();
            string tableString = "";
            tableString = ApiHandle.GetData(apiTableUrl);
            var respon = JsonConvert.DeserializeObject<List<TableModel>>(tableString);
            foreach (var item in respon)
            {
                List.Add(item);
            }
        }
    }
}
