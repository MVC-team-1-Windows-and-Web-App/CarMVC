using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMVCClasses
{
    public class ApiSale
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int SalesPersonId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SaleTotal { get; set; }
        public int SaleQuantity { get; set; }

    }
}
