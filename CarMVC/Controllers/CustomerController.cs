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


        public ActionResult Delete(int id)
        {
            ApiCustomer customer = client.GetCustomer(id);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(int id,bool? del)
        {
            
            if (client.DeleteCustomer(id))
            {
                ViewBag.message = "Customer Nuked";
            }
            else
            {
                ViewBag.message = "Could Not Nuke Customer";
            }
            return RedirectToAction("Customers");
        }

        public ActionResult Details(int id)
        {
            return View(client.GetCustomer(id));
        }

        public ActionResult Edit(int id)
        {
            return View(client.GetCustomer(id));
        }

        [HttpPost] 
        public ActionResult Edit(ApiCustomer customer)
        {
            if (client.UpdateCustomer(customer))
            {
                ViewBag.message = "Customer Changed";
            }
            else 
            {
                ViewBag.message = "Customer not Changed, error";
            }
            return RedirectToAction("Details", new { id = customer.CustomerId });
        }
    }
    //hello world
}