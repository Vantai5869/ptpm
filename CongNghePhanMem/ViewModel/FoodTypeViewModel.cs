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
    public class FoodTypeViewModel : ViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
      
        public ICommand LoadedWindowCommand { get; set; }

        private ObservableCollection<FoodTypeModel> _fTypeList;
        public ObservableCollection<FoodTypeModel> fTypeList { get => _fTypeList; set { _fTypeList = value; OnPropertyChanged(); } }

        private FoodTypeModel _SelectedItem;
        public FoodTypeModel SelectedItem
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


        // mọi thứ xử lý sẽ nằm trong này
        public FoodTypeViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
               
                loadList();
            });

            // thêm
            AddCommand = new RelayCommand<object>((p) =>
             {
                 if (string.IsNullOrEmpty(name))
                     return false;
                 if (fTypeList.Any(x => x.name == name))
                 {
                     //MessageBox.Show(name);
                     return false;
                 }
                 return true;

             }, (p) =>
             {
                 var fType = new FoodTypeModel(1, name);
                 MultipartContent data = new MultipartContent() {
                { new StringContent(name), "name"},
                { new StringContent("active"), "status"},
                };
                 Thread th = new Thread(() => ApiHandle.UploadData(null, apiFoodTypeUrl, data));
                 th.Start();
                  fTypeList.Add(fType);
             });
            
            // Sửa
            EditCommand = new RelayCommand<object>((p) =>
             {
                 if (SelectedItem == null)
                     return false;
                 if (string.IsNullOrEmpty(name))
                     return false;
                 if (fTypeList.Any(x => x.name == name))
                 {
                     return false;
                 }
                 return true;

             }, (p) =>
             {
                 var selected_id = SelectedItem.id.ToString();
                 MultipartContent data = new MultipartContent() {
                { new StringContent(name), "name"},
                { new StringContent("active"), "status"},
                };
                 Thread th = new Thread(() => ApiHandle.UploadData(null, apiEditFoodTypeUrl + selected_id, data));
                 th.Start();
                 
                 SelectedItem.name = name;
              

             });

            // Xóa
            DeleteCommand = new RelayCommand<object>((p) =>
             {
                 if (string.IsNullOrEmpty(name))
                     return false;
                 if (SelectedItem== null)
                     return false;
                 return true;

             }, (p) =>
             {
                    string selected_id = "";
                    selected_id = SelectedItem.id.ToString();
                
                 Thread th = new Thread(() => ApiHandle.Delete( apiDeleteFoodTypeUrl + selected_id));
                 th.Start();
                 SelectedItem.name = name;
                 foreach (var item in fTypeList)
                 {
                     if (item.name == name)
                     {
                         fTypeList.Remove(item);
                         break;
                     }
                 }
             });

        }

        void loadList()
        {
            fTypeList = new ObservableCollection<FoodTypeModel>();
           
            foodTypeString = ApiHandle.GetData(apiFoodTypeUrl);
            var respon = JsonConvert.DeserializeObject<List<FoodTypeModel>>(foodTypeString);
            foreach (var item in respon)
            {
                fTypeList.Add(item);
            }
        }

      
       
    }
}