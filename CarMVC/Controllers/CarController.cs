using CarMVC.Models;
using CarMVCClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMVC.Controllers
{

    public class CarController : Controller
    {

        WebServiceClient client = new WebServiceClient();



        // GET: Car
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Cars()
        {
            List<ApiCar> cars = client.GetCars();
            return View(cars);
        }

        public ActionResult Create()
        {
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