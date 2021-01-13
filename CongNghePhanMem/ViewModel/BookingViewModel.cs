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
        public ICommand ChangeTableCommand { get; set; }
        public ICommand MergeTableCommand { get; set; }
        static string table_id_get_1 = "";
        static int dem = 0;
        static string check = "";
        private ObservableCollection<TableModel> _List;
        public ObservableCollection<TableModel> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private TableModel _SelectedItem;
        private string _name;
        public string name { get => _name; set { _name = value; OnPropertyChanged(); } }
        private string _id_select;
        public string id_select { get => _id_select; set { _id_select = value; OnPropertyChanged(); } }

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
                    id_select = SelectedItem.id.ToString();
                    if (table_id_get_1 != id_select && dem != 0)
                    {
                        dem = 0;
                        if (check == "change")
                        {
                            ApiHandle.GetData(apiChangeTableUrl + table_id_get_1 + "/" + id_select);
                        } else
                        {
                            ApiHandle.GetData(apiMergeTableUrl + table_id_get_1 + "/" + id_select);
                        }
                        listTable();
                    }
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

            ChangeTableCommand = new RelayCommand<object>((p) => {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                if (dem==0)
                {
                    check = "change";
                    table_id_get_1 = id_select;
                }
                dem++;
            });
            MergeTableCommand = new RelayCommand<object>((p) => {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) =>
            {
                if (dem == 0)
                {
                    check = "merge";
                    table_id_get_1 = id_select;
                }
                dem++;
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
