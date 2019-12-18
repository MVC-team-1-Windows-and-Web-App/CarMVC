using CarMVC.Models;
using CarMVCClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMVC.Controllers
{
    public class InventoryController : Controller
    {
        WebServiceClient client = new WebServiceClient();
        public ActionResult Inventory()
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
            ApiCar car = new ApiCar();
            car.CarColor = form["CarColor"];
            car.CarType = form["CarType"];
            car.CarModel = form["CarModel"];
            car.CarPrice = Convert.ToDecimal(form["CarPrice"]);
            car.CarCommission = Convert.ToDecimal(form["CarCommission"]);
            if (!client.CreateCar(car))
            {
                return View(car);
            }
            else
            {
                return RedirectToAction("Inventory");
            }

        }

        public ActionResult Delete(int id)
        {
            ApiCar car = client.GetCar(id);

            return View(car);
        }

        [HttpPost]
        public ActionResult Delete(int id, bool? del)
        {

            if (client.DeleteCar(id))
            {
                ViewBag.message = "Car bye";
            }
            else
            {
                ViewBag.message = "Car not bye";
            }
            return RedirectToAction("Inventory");
        }

        public ActionResult Details(int id)
        {
            return View(client.GetCar(id));
        }

        public ActionResult Edit(int id)
        {
            return View(client.GetCar(id));
        }

        [HttpPost]
        public ActionResult Edit(ApiCar car)
        {
            if (client.UpdateCar(car))
            {
                ViewBag.message = "Car Changed";
            }
            else
            {
                ViewBag.message = "Car not Changed ??";
            }
            return RedirectToAction("Details", new { id = car.CarId });
        }
    }
}