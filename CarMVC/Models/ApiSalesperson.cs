using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApiClasses
{
    class ApiSalesperson
    {
        public int SalespersonId { get; set; }
        public string SalespersonFirstName { get; set; }
        public string SalespersonLastName { get; set; }
        public string SalespersonAddress { get; set; }
        public string SalespersonPhoneNumber { get; set; }
        public int LocationId { get; set; }
    }
}
