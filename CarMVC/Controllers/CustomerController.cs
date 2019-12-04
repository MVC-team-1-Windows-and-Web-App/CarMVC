using CarMVCClasses;
using CarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMVC.Controllers
{
    public class CustomerController : Controller
    {

        WebServiceClient client = new WebServiceClient();
        // GET: Customer
        public ActionResult Customers() {

            List<ApiCustomer> customers = client.GetCustomers();

            return View(customers);
        }
    }
}