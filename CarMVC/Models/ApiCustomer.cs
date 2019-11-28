using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApiClasses
{
    public class ApiCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public int CustomerPhoneId { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerDOB { get; set; }
    }
}
