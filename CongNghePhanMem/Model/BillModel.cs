using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongNghePhanMem.Model
{
    public class BillModel
    {
        public BillModel(string ten_mon, double price, int number, double pay,int table_id)
        {
            this.name = ten_mon;
            this.price = price;
            this.number = number;
            this.pay = pay;
            this.table_id = table_id;
        }

        public string name { get; set; }
        public double price { get; set; }
        public int number { get; set; }
        public double pay { get; set; }
        public int table_id { get; set; }
    }
}
