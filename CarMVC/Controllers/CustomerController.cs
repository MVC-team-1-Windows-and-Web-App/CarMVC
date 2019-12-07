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

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form) 
        {
            ApiCustomer customer = new ApiCustomer();
            customer.CustomerFirstName = form["CustomerFirstName"];
            customer.CustomerLastName = form["CustomerLastName"];
            customer.CustomerPhoneId = Int32.Parse(form["CustomerPhoneId"]);
            customer.CustomerAddress = form["CustomerAddress"];
            customer.CustomerDOB = DateTime.Parse(form["CustomerDOB"]);
            if (!client.CreateCustomer(customer))
            {
                return View(customer);
            }
            else { 
                return RedirectToAction("Customers");
            }

        }
    }
}