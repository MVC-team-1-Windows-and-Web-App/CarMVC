using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApiClasses
{
    class ApiSale
    {
        public int SaleId { get; set; }
        public int CustimerId { get; set; }
        public int CarId { get; set; }
        public int SalesPersonId { get; set; }
        public string SaleDate { get; set; }
        public double SaleTotal { get; set; }
        public int SaleQuantity { get; set; }

    }
}
