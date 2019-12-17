using CarMVCClasses;
using CarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMVC.Controllers
{
    public class LocationController : Controller
    {
        WebServiceClient client = new WebServiceClient();

        public ActionResult Locations()
        {

            List<ApiLocation> locations = client.GetLocations();

            return View(locations);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            ApiLocation location = new ApiLocation();
            location.LocationAddress = form["LocationAddress"];
            location.LocationStateProv = form["LocationStateProv"];
            if (client.CreateLocation(location))
            {
                return RedirectToAction("Locations");
            }
            else
            {
                return View(location);                
            }

        }

        public ActionResult Delete(int id)
        {
            ApiLocation location = client.GetLocation(id);

            return View(location);
        }

        [HttpPost]
        public ActionResult Delete(int id, bool? del)
        {

            if (client.DeleteLocation(id))
            {
                ViewBag.message = "Location ANNIHALATED";
            }
            else
            {
                ViewBag.message = "Could Not ANNIHALATE location";
            }
            return RedirectToAction("Locations");
        }

        public ActionResult Details(int id)
        {
            return View(client.GetLocation(id));
        }

        public ActionResult Edit(int id)
        {
            return View(client.GetLocation(id));
        }

        [HttpPost]
        public ActionResult Edit(ApiLocation location)
        {
            if (client.UpdateLocation(location))
            {
                ViewBag.message = "Location Changed";
            }
            else
            {
                ViewBag.message = "Location not Changed, error";
            }
            return RedirectToAction("Details", new { id = location.LocationId });
        }
    }
}