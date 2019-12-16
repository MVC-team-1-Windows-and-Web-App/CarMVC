using CarMVC.Models;
using CarMVCClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMVC.Controllers
{
    public class SaleController : Controller
    {
        WebServiceClient client = new WebServiceClient();

        // GET: Sale
        public ActionResult Sales()
        {
            List<ApiSale> sales = client.GetSales();
            return View(sales);
        }

        public ActionResult Create() {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            ApiSale sale = new ApiSale()
            {
                CustomerId = Int32.Parse(form["CustomerId"]),
                CarId = Int32.Parse(form["CarId"]),
                SalesPersonId = Int32.Parse(form["SalesPersonId"]),
                SaleDate = DateTime.Parse(form["SaleDate"]),
                SaleQuantity = Int32.Parse(form["SaleQuantity"]),
                SaleTotal = Decimal.Parse(form["SaleTotal"]),
            };
            

            if (client.CreateSale(sale))
            {
                return RedirectToAction("Sales");
            }
            else
            {
                return View(sale);
            }
        }
    }
}