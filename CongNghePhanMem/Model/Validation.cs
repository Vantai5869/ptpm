using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongNghePhanMem.Model
{
    class Validation
    {
        public static bool validate(string str = null, string str2 =null,string str3=null)
        {
            if (str == null || str == "" || str2 == null || str2 == "" || str3 == null || str3 == "")
            {
                return false;
            }
            return true;
        }
    }
}
