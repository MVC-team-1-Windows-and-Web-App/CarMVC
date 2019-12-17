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
            ApiCar car = new ApiCar() {

                CarId = Int32.Parse(form["CarId"]),
                CarColor = form["CarColor"].ToString(),
                CarType = form["CarType"].ToString(),
                CarModel = form["CarModel"].ToString(),
                CarPrice = Convert.ToDouble(form["CarPrice"]),
                CarCommission = Convert.ToDouble(form["CarCommission"]),
            };



            if (client.CreateCar(car))
            {
                return RedirectToAction("Cars");
            }
            else
            {
                return View(car);
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
                ViewBag.message = "Car Nuked,Tesla overtook them";
            }
            else
            {
                ViewBag.message = "Could Not Sell this bagnole";
            }
            return RedirectToAction("Cars");
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
                ViewBag.message = "Car Updated";
            }
            else
            {
                ViewBag.message = "Car not Changed, error";
            }
            return RedirectToAction("Details", new { id = car.CarId });
        }
    }
}