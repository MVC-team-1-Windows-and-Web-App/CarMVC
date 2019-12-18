using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMVCClasses
{
    public class ApiPhone
    {
        public int PhoneId { get; set; }
        [Required][DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

    }
}
