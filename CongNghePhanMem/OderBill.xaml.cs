using CongNghePhanMem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using xNet;

namespace CongNghePhanMem
{
    /// <summary>
    /// Interaction logic for BillWindow.xaml
    /// </summary>
    public partial class OderBill : Window
    { 
        public static string apiDeleteBillUrl, apiStatusTableTypeUrl, apiTableUrl, apiOverview,totalPay = "0";
        public static void UrlDifine(int num)// 1 hosting online, else local
        {

            if (num == 1)
            {

                apiDeleteBillUrl = "https://rescom.000webhostapp.com/api/delete/bill/";

                apiStatusTableTypeUrl = "https://rescom.000webhostapp.com/api/table/status/";
                apiTableUrl = "https://rescom.000webhostapp.com/api/table";
                //overview
                apiOverview = "https://rescom.000webhostapp.com/api/overview";

            }
            else
            {

                apiDeleteBillUrl = "http://res.com/api/delete/bill/";
                apiStatusTableTypeUrl = "http://res.com/api/table/status/";
                apiTableUrl = "http://res.com/api/table";
                //overview
                apiOverview = "http://res.com/api/overview";

            }
        }
        public string tableId;
        public OderBill(string url, string table_id)
        {
            
            tableId = table_id;
            InitializeComponent();
            UrlDifine(0);
            getBill(url, lvBill);;
        }

        public void getBill(string apiUrl, ListBox lv)
        {
            var resp = ApiHandle.GetData(apiUrl + tableId);
            var respon = JsonConvert.DeserializeObject<List<BillModel>>(resp.ToString());
            this.Dispatcher.Invoke((Action)(() =>
            {
                lv.ItemsSource = respon;
            }));
            var total = 0.0;
            foreach(var item in respon)
            {
                 total += item.pay;
            }
            totalPay = total.ToString();
            payTotal.Text = total.ToString()+" VND";
            payTime.Text = DateTime.Now.ToString();
        }

        private void PrintClick(object sender, RoutedEventArgs e)
        {
            //luu gid lieu vao overview trước khi delete bill
            MultipartContent data = new MultipartContent() {
                    {new StringContent(totalPay),"totalpay"}
                };
            Thread th = new Thread(() => ApiHandle.UploadData(null, apiTableUrl, data));
            th.Start();
            ApiHandle.OverviewStore(null, apiOverview,data);

            ApiHandle.GetData(apiDeleteBillUrl+tableId);
            ApiHandle.GetData(apiStatusTableTypeUrl + tableId+"/0");

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(areaBill, "In hóa đơn!");
            }
            this.Close();
            var bookingTable = new BookingWindow();
            bookingTable.Show();
        }

       

    }
}
