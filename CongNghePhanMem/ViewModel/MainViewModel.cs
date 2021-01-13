using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CongNghePhanMem.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand StaffCommand { get; set; }
        public ICommand FoodCommand { get; set; }
        public ICommand BillCommand { get; set; }
        public ICommand FoodTypeCommand { get; set; }
        public ICommand BookingCommand { get; set; }
        public ICommand TableCommand { get; set; }

        // mọi thứ xử lý sẽ nằm trong này
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                Isloaded = true;
                //LoginWindow loginWindow = new LoginWindow();
                //loginWindow.ShowDialog();
            });

            StaffCommand = new RelayCommand<object>((p) => { return true; }, (p) => { StaffWindow wd = new StaffWindow(); wd.ShowDialog(); });
            FoodCommand = new RelayCommand<object>((p) => { return true; }, (p) => { FoodWindow wd = new FoodWindow(); wd.ShowDialog(); });
            BillCommand = new RelayCommand<object>((p) => { return true; }, (p) => { BillWindow wd = new BillWindow(); wd.ShowDialog(); });
            FoodTypeCommand = new RelayCommand<object>((p) => { return true; }, (p) => { FoodTypeWindow wd = new FoodTypeWindow(); wd.ShowDialog(); });
            BookingCommand = new RelayCommand<object>((p) => { return true; }, (p) => { BookingWindow wd = new BookingWindow(); wd.ShowDialog(); });
            TableCommand = new RelayCommand<object>((p) => { return true; }, (p) => { TableWindow wd = new TableWindow(); wd.ShowDialog(); });
        }
    }
}