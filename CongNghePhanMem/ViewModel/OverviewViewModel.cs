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
    public class OverviewViewModel : ViewModel
    {
        public ICommand LoadedWindowCommand { get; set; }

        private ObservableCollection<OverviewModel> _List;
        public ObservableCollection<OverviewModel> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        public OverviewViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => { loadList(); });
           
        }

        void loadList()
        {
            List = new ObservableCollection<OverviewModel>();
            string tableString = "";
            tableString = ApiHandle.GetData(apiOverview);
            var respon = JsonConvert.DeserializeObject<List<OverviewModel>>(tableString);
            
            foreach (var item in respon)
            {
                List.Add(item);
            }
        }
    }
}
