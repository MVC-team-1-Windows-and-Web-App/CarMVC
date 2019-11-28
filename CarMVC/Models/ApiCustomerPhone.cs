using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerEntityLibrary
{
    class ApiCustomerPhone
    {
        public int CustomerPhoneId { get; set; }
        public int CustomerId { get; set; }
        public int PhoneId { get; set; }
        public string CustomerPhoneType { get; set; }
    }
}
