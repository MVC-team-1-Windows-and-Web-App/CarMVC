using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMVCClasses
{
    public class ApiSalesperson
    {
        public int SalespersonId { get; set; }
        public string SalespersonFirstName { get; set; }
        public string SalespersonLastName { get; set; }
        public string SalespersonAddress { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string SalespersonPhoneNumber { get; set; }
        public int LocationId { get; set; }
    }
}
