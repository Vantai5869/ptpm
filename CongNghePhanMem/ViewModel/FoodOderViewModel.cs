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
using Microsoft.Win32;
using Newtonsoft.Json;
using xNet;

namespace CongNghePhanMem.ViewModel
{
    public class FoodOderViewModel : ViewModel
    {
        public ICommand AddCommand1 { get; set; }
        public ICommand AddCommand2 { get; set; }
        public ICommand AddCommand3 { get; set; }
        public ICommand AddCommand4 { get; set; }
        public ICommand AddCommand5 { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand OpenFileCommand { get; set; }
        public ICommand EnterTextCommand { get; set; }
        public ICommand PaymentCommand { get; set; }
      
        public ICommand LoadedWindowCommand { get; set; }

        private ObservableCollection<FoodModel> _foodList;
      
        public ObservableCollection<FoodModel> foodList { get => _foodList; set { _foodList = value; OnPropertyChanged(); } }
       
        private ObservableCollection<FoodTypeModel> _fTypeList;
        public ObservableCollection<FoodTypeModel> fTypeList { get => _fTypeList; set { _fTypeList = value; OnPropertyChanged(); } }

        private ObservableCollection<BillModel> _fBillList;
        public ObservableCollection<BillModel> fBillList { get => _fBillList; set { _fBillList = value; OnPropertyChanged(); } }


        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                if (value != null)
                {
                    filter = value;
                    if(filter !="")
                    loadFoodList(apiSearchFoodUrl + filter);
                }
            }
        }

        private  string filter;
        public static string tableId;
        private FoodModel _SelectedItem;
        public FoodModel SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    name = SelectedItem.name;
                    price = SelectedItem.price;
                    image = SelectedItem.image;
                    foodtypeId = SelectedItem.food_type_id;
                }
              
            }
        }

        // get food theo loại
        private FoodTypeModel _SelectedItemFType;
        public FoodTypeModel SelectedItemFType
        {
            get => _SelectedItemFType;
            set
            {
                _SelectedItemFType = value;
                OnPropertyChanged();
                if (SelectedItemFType != null)
                {
                    id_FType = SelectedItemFType.id.ToString();
                    loadFoodList(apigetByFoodTypeUrl + id_FType);
                }
            }
        }

         // Lấy tên loại món ăn khi thêm
        private FoodTypeModel _SelectedItemFTypeOnPost;
        public FoodTypeModel SelectedItemFTypeOnPost
        {
            get => _SelectedItemFTypeOnPost;
            set
            {
                _SelectedItemFTypeOnPost = value;
                OnPropertyChanged();
                if (SelectedItemFTypeOnPost != null)
                {
                    id_FType_OnPost = SelectedItemFTypeOnPost.id.ToString();
                }
            }
        }


        public bool dialogCheck = false;
        private string _name;
        public string name { get => _name; set { _name = value; OnPropertyChanged(); } }
        
        private string _id_FType;
        public string id_FType { get => _id_FType; set { _id_FType = value; OnPropertyChanged(); } }
        
        private string _id_FType_OnPost;
        public string id_FType_OnPost { get => _id_FType_OnPost; set { _id_FType_OnPost = value; OnPropertyChanged(); } }

        private string _price;
        public string price { get => _price; set { _price = value; OnPropertyChanged(); } }

        private int _foodtypeId;
        public int foodtypeId { get => _foodtypeId; set { _foodtypeId = value; OnPropertyChanged(); } }
        
        private string _image=string.Empty;
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

        public string EnterText
        {
            get
            {
                return enterText;
            }
            set
            {
                if (value != null)
                {
                    enterText = value;
                    
                }
            }
        }
        private string enterText;
        public FoodOderViewModel(string id_table)
        {
            tableId = id_table;
        }
            public FoodOderViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                loadFoodList(apiFoodUrl);
                loadFoodTypeList();
                loadFoodBillList(apiTableBillUrl);
               

            });

            // thêm
            AddCommand1 = new RelayCommand<object>((p) =>
            {
               
                if (SelectedItem == null)
                    return false;
                
                return true;

            }, (p) =>
            {

                string number = "1";
                addFoodToBill(number);
              
            });
            AddCommand2 = new RelayCommand<object>((p) =>
            {
               
                if (SelectedItem == null)
                    return false;
                
                return true;

            }, (p) =>
            {

                string number = "2";
                addFoodToBill(number);
              
            });
            AddCommand3 = new RelayCommand<object>((p) =>
            {
               
                if (SelectedItem == null)
                    return false;
                
                return true;

            }, (p) =>
            {

                string number = "3";
                addFoodToBill(number);
              
            });
            AddCommand4 = new RelayCommand<object>((p) =>
            {
               
                if (SelectedItem == null)
                    return false;
                
                return true;

            }, (p) =>
            {

                string number = "4";
                addFoodToBill(number);
              
            });
            AddCommand5 = new RelayCommand<object>((p) =>
            {
               
                if (SelectedItem == null)
                    return false;
                
                return true;

            }, (p) =>
            {

                string number = "5";
                addFoodToBill(number);
              
            });

          
            EnterTextCommand = new RelayCommand<object>((p) =>
            {
               
                if (SelectedItem == null)
                    return false;
                
                return true;

            }, (p) =>
            {
                if (enterText != null)
                {
                    string number = enterText;
                    addFoodToBill(number);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng");
                }
              
            });

            // Sửa
            EditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(name))
                    return false;
                if (SelectedItem == null)
                    return false;
                if (foodList.Any(x => x.name == name) && foodList.Any(x => x.price == price)&& (SelectedItemFTypeOnPost == null) && foodList.Any(x => x.image == image))
                {
                    return false;
                }
                return true;

            }, (p) =>
            {
                var fType = new FoodModel(1, name, price, image.ToString(), foodtypeId);
                MultipartContent data;
                if (SelectedItemFTypeOnPost == null)
                {
                    id_FType_OnPost = foodtypeId.ToString();
                }

                if (dialogCheck == false)
                {
                     data = new MultipartContent() {
                    { new StringContent(name), "name"},
                    { new StringContent(price), "price"},
                    { new StringContent(id_FType_OnPost), "food_type_id"},
                    };
                }
                else
                {
                    data = new MultipartContent() {
                    { new StringContent(name), "name"},
                    { new StringContent(price), "price"},
                    { new FileContent(image.ToString()), "image", "1.jpg"},
                    { new StringContent(id_FType_OnPost), "food_type_id"},
                    };
                }
                  
                Thread th = new Thread(() => ApiHandle.UploadData(null, apiEditFoodUrl+SelectedItem.id.ToString(), data));
                th.Start();
                SelectedItem.name = name;
                SelectedItem.price = price;
                SelectedItem.image = image.ToString();
            });

            // Xóa
            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(name))
                    return false;
                if (SelectedItem == null)
                    return false;
                return true;

            }, (p) =>
            {
              
                Thread th = new Thread(() => ApiHandle.Delete(apiDeleteFoodUrl + SelectedItem.id.ToString()));
                th.Start();
                SelectedItem.name = name;
                foreach (var item in foodList)
                {
                    if (item.name == name)
                    {
                        foodList.Remove(item);
                        break;
                    }
                }
            });

            // OpenFileCommand
            OpenFileCommand = new RelayCommand<object>((p) =>
            {
                return true;

            }, (p) =>
            {
                OpenFileDialog dialog = new OpenFileDialog();

                if (dialog.ShowDialog() == true)
                {
                    image = dialog.FileName;
                    dialogCheck = true;
                }
            });

        }

        void addFoodToBill(string number)
        {
            int price = int.Parse(SelectedItem.price);
            int numbertmp = int.Parse(number);
            double pay = numbertmp * price;
            var fBill = new BillModel(name, price, int.Parse(number), pay, int.Parse(tableId));
            MultipartContent data = new MultipartContent() {
                    { new StringContent(name), "name"},
                    { new StringContent(price.ToString()), "price"},
                    { new StringContent(number), "number"},
                    { new StringContent(pay.ToString()), "pay"},
                    { new StringContent(tableId), "table_id"},
                    };
            

            Thread th = new Thread(() => ApiHandle.UploadData(null, apiBillUrl, data));
            th.Start();
            fBillList.Add(fBill);

        }
        void loadFoodList(string url)
        {
            foodList = new ObservableCollection<FoodModel>();
           
            string foodString = ApiHandle.GetData(url);
            var respon = JsonConvert.DeserializeObject<List<FoodModel>>(foodString);
            foreach (var item in respon)
            {
                foodList.Add(item);
            }
        }

        void loadFoodTypeList()
        {
            fTypeList = new ObservableCollection<FoodTypeModel>();

            foodTypeString = ApiHandle.GetData(apiFoodTypeUrl);
            var respon = JsonConvert.DeserializeObject<List<FoodTypeModel>>(foodTypeString);
            foreach (var item in respon)
            {
                fTypeList.Add(item);
            }
        }
     void loadFoodBillList(string apiUrl)
        {
            fBillList = new ObservableCollection<BillModel>();
           
            foodTypeString = ApiHandle.GetData(apiUrl+tableId);
            var respon = JsonConvert.DeserializeObject<List<BillModel>>(foodTypeString);
            foreach (var item in respon)
            {
                fBillList.Add(item);
            }
        }
    }
}