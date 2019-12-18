using CarMVC.Models;
using CarMVCClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMVC.Controllers
{
    public class SalespersonController : Controller
    {
        WebServiceClient client = new WebServiceClient();
        public ActionResult Salespersons()
        {

            List<ApiSalesperson> salespersons = client.GetSalespersons();

            return View(salespersons);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            ApiSalesperson salesperson = new ApiSalesperson();
            salesperson.SalespersonFirstName = form["SalespersonFirstName"];
            salesperson.SalespersonLastName = form["SalespersonLastName"];
            salesperson.SalespersonAddress = form["SalespersonAddress"];
            salesperson.SalespersonPhoneNumber = form["SalespersonPhoneNumber"];
            salesperson.LocationId = Int32.Parse(form["Locationid"]);
            if (client.GetLocation(salesperson.LocationId) != null)
                if (client.CreateSalesperson(salesperson))
                {
                    return RedirectToAction("Salespersons");
                }

            return View(salesperson);
            
            

        }

        public ActionResult Delete(int id)
        {
            ApiSalesperson salesperson = client.GetSalesperson(id);

            return View(salesperson);
        }

        [HttpPost]
        public ActionResult Delete(int id, bool? del)
        {

            if (client.DeleteSalesperson(id))
            {
                ViewBag.message = "Salesperson bye";
            }
            else
            {
                ViewBag.message = "Salesperson not bye";
            }
            return RedirectToAction("Salespersons");
        }

        public ActionResult Details(int id)
        {
            return View(client.GetSalesperson(id));
        }

        public ActionResult Edit(int id)
        {
            return View(client.GetSalesperson(id));
        }

        [HttpPost]
        public ActionResult Edit(ApiSalesperson salesperson)
        {
            if (client.UpdateSalesperson(salesperson))
            {
                ViewBag.message = "Salesperson Changed";
            }
            else
            {
                ViewBag.message = "Salesperson not Changed ??";
            }
            return RedirectToAction("Salespersons");
        }
    }
}