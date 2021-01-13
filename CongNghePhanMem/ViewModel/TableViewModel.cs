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
    public class TableViewModel:ViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }

        private ObservableCollection<TableModel> _List;
        public ObservableCollection<TableModel> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private TableModel _SelectedItem;
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

        private string _name;
        public string name { get => _name; set { _name = value; OnPropertyChanged(); } }

        public TableViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => { loadList(); });
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(name))
                    return false;
                if (List.Any(x => x.name == name))
                {
                    return false;
                }
                return true;

            }, (p) =>
            {
                var table = new TableModel(1, name, "active");
                MultipartContent data = new MultipartContent() {
                    {new StringContent(name),"name"}
                };
                Thread th = new Thread(() => ApiHandle.UploadData(null, apiTableUrl, data));
                th.Start();
                List.Add(table);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                if (string.IsNullOrEmpty(name))
                    return false;
                if (List.Any(x => x.name == name))
                {
                    return false;
                }
                return true;

            }, (p) =>
            {
                var selected_id = SelectedItem.id.ToString();
                MultipartContent data = new MultipartContent() {
                    { new StringContent(name),"name"},
                    { new StringContent("active"),"status"},
                };
                Thread th = new Thread(() => ApiHandle.UploadData(null, apiEditTableUrl + selected_id, data));
                th.Start();

                SelectedItem.name = name;
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(name))
                    return false;
                if (SelectedItem == null)
                    return false;
                return true;

            }, (p) =>
            {
                string selected_id = "";
                selected_id = SelectedItem.id.ToString();

                Thread th = new Thread(() => ApiHandle.Delete(apiDeleteTableUrl + selected_id));
                th.Start();
                SelectedItem.name = name;
                foreach (var item in List)
                {
                    if (item.name == name)
                    {
                        List.Remove(item);
                        break;
                    }
                }
            });
        }

        void loadList()
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
