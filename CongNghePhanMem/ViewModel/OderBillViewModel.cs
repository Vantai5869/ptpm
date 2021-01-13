using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CongNghePhanMem.Model;
using Newtonsoft.Json;
using xNet;

namespace CongNghePhanMem.ViewModel
{
    public class OderBillViewModel : ViewModel
    {
        public static string tableId;
        public string payTotal { get; set; }
        public string payTime{ get; set; }
        private ObservableCollection<BillModel> _List;
        public ObservableCollection<BillModel> List { get => _List; set { _List = value; OnPropertyChanged(); } }

     
        public OderBillViewModel(string id_table)
        {
            tableId = id_table;
        }
            public OderBillViewModel()
        {
            var respon = loadList();
            var total = 0.0;
            foreach (var item in respon)
            {
                total += item.pay;
            }
            payTotal = total.ToString() + " VND";
            payTime = DateTime.Now.ToString();
          
        }

        public List<BillModel> loadList()
        {
            List = new ObservableCollection<BillModel>();
            string billString = "";
            billString = ApiHandle.GetData(apiTableBillUrl+tableId);
            var respon = JsonConvert.DeserializeObject<List<BillModel>>(billString);
            foreach (var item in respon)
            {
                List.Add(item);
            }
            return respon;
        }
    }
}
